using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PigFarm.Constants;
using PigFarm.Data;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Models;
using PigFarm.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
namespace PigFarm.Services
{
    public interface IRecordWeighingService : IServiceBase<RecordWeighing, RecordWeighingDto>
    {

        Task<object> LoadData(DataManager data, string farmGuid, string makeOrderGuid, string lang);
        Task<object> LoadData(DataManager data, string farmGuid, string lang);
        Task<object> GetAudit(object id);
        Task<OperationResult> ToggleRecordDate(object id);
        Task<RecordWeighingDto> GetByRecordGuidAsync(string upperGuid, string upperRecord);
    }
    public class RecordWeighingService : ServiceBase<RecordWeighing, RecordWeighingDto>, IRecordWeighingService
    {
        private readonly IRepositoryBase<RecordWeighing> _repo;
        private readonly IRepositoryBase<Pen> _repoPen;
        private readonly IRepositoryBase<Pig> _repoPig;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
                private readonly IRepositoryBase<Room> _repoRoom;
        private readonly IRepositoryBase<MakeOrder> _repoMakeOrder;
private readonly IRepositoryBase<Record2Room> _repoRecord2Room;
        private readonly IRepositoryBase<Record2Pen> _repoRecord2Pen;
        private readonly IRepositoryBase<Record2Pig> _repoRecord2Pig;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        private readonly IConfiguration _configuration;
        public RecordWeighingService(
            IRepositoryBase<RecordWeighing> repo,
            IRepositoryBase<MakeOrder> repoMakeOrder,
            IRepositoryBase<Room> repoRoom,
IRepositoryBase<Record2Room> repoRecord2Room,
            IRepositoryBase<Record2Pen> repoRecord2Pen,
            IRepositoryBase<Record2Pig> repoRecord2Pig,
            IRepositoryBase<Pen> repoPen,
            IRepositoryBase<Pig> repoPig,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper,
            IConfiguration configuration
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoMakeOrder = repoMakeOrder;
            _repoRoom = repoRoom;
_repoRecord2Room = repoRecord2Room;
            _repoRecord2Pen = repoRecord2Pen;
            _repoRecord2Pig = repoRecord2Pig;
            _repoPen = repoPen;
            _repoPig = repoPig;
            _repoCodeType = repoCodeType;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
            _configuration = configuration;
        }
        public override async Task<object> GetDataDropdownlist(DataManager data)
        {
              var datasource = _repo.FindAll().OrderByDescending(x=>x.EstDate).ThenByDescending(x=>x.Status).AsQueryable();
            var count = await datasource.CountAsync();
            if (data.Where != null) // for filtering
                datasource = QueryableDataOperations.PerformWhereFilter(datasource, data.Where, data.Where[0].Condition);
            if (data.Sorted != null)//for sorting
                datasource = QueryableDataOperations.PerformSorting(datasource, data.Sorted);
            if (data.Search != null)
                datasource = QueryableDataOperations.PerformSearching(datasource, data.Search);
            count = await datasource.CountAsync();
            if (data.Skip >= 0)//for paging
                datasource = QueryableDataOperations.PerformSkip(datasource, data.Skip);
            if (data.Take > 0)//for paging
                datasource = QueryableDataOperations.PerformTake(datasource, data.Take);
            return await datasource.ToListAsync();
        }
        public async Task<RecordWeighingDto> GetByRecordGuidAsync(string upperGuid, string upperRecord) {
            var item = await _repo.FindAll(x=> x.UpperGuid == upperGuid && x.UpperRecord == upperRecord).ProjectTo<RecordWeighingDto>(_configMapper).FirstOrDefaultAsync();
                return item;
        }
        public async Task<object> LoadData(DataManager data, string farmGuid, string lang)
        {

            IQueryable<RecordWeighingDto> datasource = Datasource(farmGuid, lang);
            var count = await datasource.CountAsync();
            if (data.Where != null) // for filtering
                datasource = QueryableDataOperations.PerformWhereFilter(datasource, data.Where, data.Where[0].Condition);
            if (data.Sorted != null)//for sorting
                datasource = QueryableDataOperations.PerformSorting(datasource, data.Sorted);
            if (data.Search != null)
                datasource = QueryableDataOperations.PerformSearching(datasource, data.Search);
            count = await datasource.CountAsync();
            if (data.Skip >= 0)//for paging
                datasource = QueryableDataOperations.PerformSkip(datasource, data.Skip);
            if (data.Take > 0)//for paging
                datasource = QueryableDataOperations.PerformTake(datasource, data.Take);
            return new
            {
                Result = await datasource.ToListAsync(),
                Count = count
            };
        }
        public async Task<object> LoadData(DataManager data, string farmGuid, string makeOrderGuid, string lang)
        {
            IQueryable<RecordWeighingDto> datasource = Datasource(farmGuid, lang);
            if (!string.IsNullOrEmpty(makeOrderGuid))
            {
                datasource = Datasource(farmGuid, lang).Where(x => x.MakeOrderGuid == makeOrderGuid);
            }
            var count = await datasource.CountAsync();
            if (data.Where != null) // for filtering
                datasource = QueryableDataOperations.PerformWhereFilter(datasource, data.Where, data.Where[0].Condition);
            if (data.Sorted != null)//for sorting
                datasource = QueryableDataOperations.PerformSorting(datasource, data.Sorted);
            if (data.Search != null)
                datasource = QueryableDataOperations.PerformSearching(datasource, data.Search);
            count = await datasource.CountAsync();
            if (data.Skip >= 0)//for paging
                datasource = QueryableDataOperations.PerformSkip(datasource, data.Skip);
            if (data.Take > 0)//for paging
                datasource = QueryableDataOperations.PerformTake(datasource, data.Take);
            return new
            {
                Result = await datasource.ToListAsync(),
                Count = count
            };
        }

        public override async Task<List<RecordWeighingDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<RecordWeighingDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(RecordWeighingDto model)
        {
            var item = _mapper.Map<RecordWeighing>(model);
            _repo.Add(item);
            try
            {
                await _unitOfWork.SaveChangeAsync();
                 int EXECUTE_STATUS = 3;
                if (model.Status == EXECUTE_STATUS) {
                await StoreProcedureRecord(item.Guid, SP.Record.Weighing);
                }
                 if (!string.IsNullOrEmpty(model.RoomGuid)) {
                    _repoRecord2Room.Add(new Record2Room {
                        Type = "Record_Weighing",
                        RecordGuid = item.Guid,
                        RoomGuid = model.RoomGuid
                    });
                }
                 if (model.Pens.Length > 0)
                {
                    var lists = new List<Record2Pen> { };
                    foreach (var pen in model.Pens)
                    {
                        lists.Add(new Record2Pen
                        {
                            RecordGuid = item.Guid,
                            Type = "Record_Weighing",
                            PenGuid = pen
                        });
                    }
                    _repoRecord2Pen.AddRange(lists);

                }
                if (model.Record2Pigs.Count > 0)
                {
                    var lists = new List<Record2Pig> { };
                    foreach (var x in model.Record2Pigs)
                    {
                        lists.Add(new Record2Pig
                        {
                            Type = "Record_Weighing",
                            RecordGuid = item.Guid,
                            PigGuid = x.PigGuid,
                            RecordAmount = x.RecordAmount,
                            RecordValue = x.RecordValue,
                            RecordDisease = x.RecordDisease,
                            RecordNext = x.RecordNext,
                            RecordWeight = x.RecordWeight
                        });
                    }
                    _repoRecord2Pig.AddRange(lists);
                }
                await _unitOfWork.SaveChangeAsync();

                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.AddSuccess,
                    Success = true,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }
        public override async Task<OperationResult> UpdateAsync(RecordWeighingDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);
            item.FarmGuid = model.FarmGuid;
            item.Type = model.Type;
            item.MakeOrderGuid = model.MakeOrderGuid;
            item.Comment = model.Comment;
            item.CreateDate = model.CreateDate;
            item.CreateBy = model.CreateBy;
            item.UpdateDate = model.UpdateDate;
            item.UpdateBy = model.UpdateBy;
            item.DeleteDate = model.DeleteDate;
            item.DeleteBy = model.DeleteBy;
            item.Status = model.Status;
            item.Guid = model.Guid;
            item.EstDate = model.EstDate;
            item.ApplyDate = model.ApplyDate;
            item.ApplyReason = model.ApplyReason;
            item.ApplyGuid = model.ApplyGuid;
            item.AgreeDate = model.AgreeDate;
            item.AgreeReason = model.AgreeReason;
            item.AgreeGuid = model.AgreeGuid;
            item.RejectDate = model.RejectDate;
            item.RejectReason = model.RejectReason;
            item.RejectGuid = model.RejectGuid;
            item.ExecuteDate = model.ExecuteDate;
            item.ExecuteReason = model.ExecuteReason;
            item.ExecuteGuid = model.ExecuteGuid;
            item.NetWeight = model.NetWeight;
            item.UseType = model.UseType;
            item.Weight = model.Weight;
            item.RecordResult = model.RecordResult;
            _repo.Update(item);
            try
            {
                if (!string.IsNullOrEmpty(model.RoomGuid)) {
                    _repoRecord2Room.Add(new Record2Room {
                        Type = "Record_Weighing",
                        RecordGuid = item.Guid,
                        RoomGuid = model.RoomGuid
                    });
                }
                  if (model.Pens.Length > 0)
                {
                    var oldPenList = await _repoRecord2Pen.FindAll(x => x.RecordGuid == model.Guid && x.Type == "Record_Weighing").ToListAsync();
                    var penLists = new List<Record2Pen> { };
                    foreach (var pen in model.Pens)
                    {
                        penLists.Add(new Record2Pen
                        {
                            Type = "Record_Weighing",
                            RecordGuid = item.Guid,
                            PenGuid = pen
                        });
                    }
                    if (oldPenList.Count > 0)
                        _repoRecord2Pen.RemoveMultiple(oldPenList);
                    if (penLists.Count > 0)
                        _repoRecord2Pen.AddRange(penLists);
                }

                if (model.Record2Pigs.Count > 0)
                {
                    var oldList = await _repoRecord2Pig.FindAll(x => x.RecordGuid == model.Guid && x.Type == "Record_Weighing").ToListAsync();
                    var lists = new List<Record2Pig> { };
                    foreach (var x in model.Record2Pigs)
                    {
                        lists.Add(new Record2Pig
                        {
                            Type = "Record_Weighing",
                            RecordGuid = item.Guid,
                            PigGuid = x.PigGuid,
                            RecordAmount = x.RecordAmount,
                            RecordValue = x.RecordValue,
                            RecordDisease = x.RecordDisease,
                            RecordNext = x.RecordNext,
                            RecordWeight = x.RecordWeight
                        });
                    }
                    if (oldList.Count > 0)
                        _repoRecord2Pig.RemoveMultiple(oldList);
                    if (lists.Count > 0)
                        _repoRecord2Pig.AddRange(lists);
                }
                await _unitOfWork.SaveChangeAsync();
                int EXECUTE_STATUS = 3;
                if (model.Status == EXECUTE_STATUS) {
                await StoreProcedureRecord(item.Guid, SP.Record.Weighing);
                }
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.UpdateSuccess,
                    Success = true,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }
        private async Task RemoveRecord(string RecordGuid)
        {
            var item1 = await _repoRecord2Room.FindAll(x=> x.RecordGuid == RecordGuid).ToListAsync();
            var item2 = await _repoRecord2Pen.FindAll(x=> x.RecordGuid == RecordGuid).ToListAsync();
            var item3 = await _repoRecord2Pig.FindAll(x=> x.RecordGuid == RecordGuid).ToListAsync();
            if(item1.Any())
                _repoRecord2Room.RemoveMultiple(item1);
            if (item2.Any())
                _repoRecord2Pen.RemoveMultiple(item2);
            if (item3.Any())
                _repoRecord2Pig.RemoveMultiple(item3);
        }
        public override async Task<OperationResult> DeleteAsync(object id)
        {
            var item = await _repo.FindByIDAsync(id);
            item.Status = -1;
            _repo.Update(item);
            try
            {
                await RemoveRecord(item.Guid);
                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.DeleteSuccess,
                    Success = true,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }
        public async Task<object> GetAudit(object id)
        {
            var data = await _repo.FindAll(x => x.Id.Equals(id)).AsNoTracking().Select(x => new { x.UpdateBy, x.CreateBy, x.UpdateDate, x.CreateDate }).FirstOrDefaultAsync();
            string createBy = "N/A";
            string createDate = "N/A";
            string updateBy = "N/A";
            string updateDate = "N/A";
            if (data == null)
                return new
                {
                    createBy,
                    createDate,
                    updateBy,
                    updateDate
                };
            if (data.UpdateBy.HasValue)
            {
                var updateAudit = await _repoXAccount.FindAll(x => x.AccountId == data.UpdateBy).AsNoTracking().Select(x => new { x.Uid }).FirstOrDefaultAsync();
                updateBy = updateBy != null ? updateAudit.Uid : "N/A";
                updateDate = data.UpdateDate.HasValue ? data.UpdateDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
            }
            if (data.CreateBy.HasValue)
            {
                var createAudit = await _repoXAccount.FindAll(x => x.AccountId == data.CreateBy).AsNoTracking().Select(x => new { x.Uid }).FirstOrDefaultAsync();
                createBy = createAudit != null ? createAudit.Uid : "N/A";
                createDate = data.CreateDate.HasValue ? data.CreateDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
            }
            return new
            {
                createBy,
                createDate,
                updateBy,
                updateDate
            };
        }

        public async Task<OperationResult> ToggleRecordDate(object id)
        {
            var item = await _repo.FindByIDAsync(id);
            _repo.Update(item);
            try
            {
                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.DeleteSuccess,
                    Success = true,
                    Data = item
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }

        private IQueryable<RecordWeighingDto> Datasource(string farmGuid, string lang)
        {
            return (from a in _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status != StatusConstants.Delete)
                    join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Record_Weighing_Type && x.Status == "Y") on a.Type equals b.CodeNo into ab
                    from t in ab.DefaultIfEmpty()
                    join st in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Order_Status && x.Status == "Y") on a.Status equals Convert.ToDecimal(st.CodeNo) into ast
                    from status in ast.DefaultIfEmpty()
                    join ap in _repoXAccount.FindAll(x => x.Status == "1") on a.ApplyGuid equals ap.Guid into aap
                    from apply in aap.DefaultIfEmpty()
                    join ag in _repoXAccount.FindAll(x => x.Status == "1") on a.AgreeGuid equals ag.Guid into aag
                    from agree in aag.DefaultIfEmpty()
                    join re in _repoXAccount.FindAll(x => x.Status == "1") on a.RejectGuid equals re.Guid into are
from reject in are.DefaultIfEmpty()
join exe in _repoXAccount.FindAll(x => x.Status == "1") on a.ExecuteGuid equals exe.Guid into aexe
from execute in aexe.DefaultIfEmpty()
join m in _repoMakeOrder.FindAll(x => x.Status == 1) on a.MakeOrderGuid equals m.Guid into am
from order in am.DefaultIfEmpty()
                    select new RecordWeighingDto
                    {
                        Id = a.Id,
                        FarmGuid = a.FarmGuid,
                        Type = a.Type,
                        MakeOrderGuid = a.MakeOrderGuid,
                        Comment = a.Comment,
                        CreateDate = a.CreateDate,
                        CreateBy = a.CreateBy,
                        UpdateDate = a.UpdateDate,
                        UpdateBy = a.UpdateBy,
                        DeleteDate = a.DeleteDate,
                        DeleteBy = a.DeleteBy,
                        Status = a.Status,
                        Guid = a.Guid,
                        EstDate = a.EstDate,
                        ApplyDate = a.ApplyDate,
                        ApplyReason = a.ApplyReason,
                        ApplyGuid = a.ApplyGuid,
                        AgreeDate = a.AgreeDate,
                        AgreeReason = a.AgreeReason,
                        AgreeGuid = a.AgreeGuid,
                        RejectDate = a.RejectDate,
                        RejectReason = a.RejectReason,
                        RejectGuid = a.RejectGuid,
                        ExecuteDate = a.ExecuteDate,
                        ExecuteReason = a.ExecuteReason,
                        ExecuteGuid = a.ExecuteGuid,

                        NetWeight = a.NetWeight,
                        UseType = a.UseType,
                        Weight = a.Weight,
                        RecordResult = a.RecordResult,

                        
                        TypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                        StatusName = status == null ? "" : lang == Languages.EN ? status.CodeNameEn ?? status.CodeName : lang == Languages.VI ? status.CodeNameVn ?? status.CodeName : lang == Languages.CN ? status.CodeNameCn ?? status.CodeName : status.CodeName,

                    ApplyName = apply == null ? "" : apply.AccountName,
                        AgreeName = agree == null ? "" : agree.AccountName,
                        RejectName = reject == null ? "" : reject .AccountName,
				ExecuteName = execute == null ? "" : execute.AccountName,
                 RoomName = (from room in _repoRoom.FindAll()
                join r2 in _repoRecord2Room.FindAll() on room.Guid equals r2.RoomGuid where r2.RecordGuid == a.Guid select room.RoomName).First(),
                    OrderNo = order == null ? "" : order.OrderNo,
                    }).OrderByDescending(x => x.Id).AsQueryable();
        }

    private async Task StoreProcedureRecord(string recordGuid, string storeProcedureName)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                string sql = storeProcedureName;
                var parameters = new { @record_GUID = recordGuid };
                try
                {
                    await conn.QueryAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                }

            }
        }


    }
}

