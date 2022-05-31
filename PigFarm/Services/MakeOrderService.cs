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
using NetUtility;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace PigFarm.Services
{
    public interface IMakeOrderService : IServiceBase<MakeOrder, MakeOrderDto>
    {
        Task<object> LoadData(DataManager data, string farmGuid);
        Task<object> LoadDataByType(DataManager data, string farmGuid, string pigType, string lang);
        Task<object> LoadMobileDataByType(DataManager data, string farmGuid, string pigType, string lang);
        Task<object> LoadData(DataManager data, string farmGuid, string customerGuid);
        Task<object> GetAudit(object id);
        Task<object> GetByGuid(string guid);
        Task<object> GetMakeOrderPen(string makeOrderGuid);
        Task<object> GetPensByRoom(string roomGuid);
        Task<object> GetMakeOrderPenDropdown(string makeOrderGuid);
        Task<OperationResult> StoreMakeOrder2Pen(StoreMakeOrder2PenDto request);
        Task<OperationResult> RemoveMakeOrder2Pen(RemoveMakeOrder2PenDto request);
        Task<OperationResult> AddMakeOrder2Pen(AddMakeOrder2PenDto request);
        Task<OperationResult> StoreRoomGuid(UpdateRoomGuidDto request);
        Task<object> GetMakeOrderByFarmGuid(string farmGuid);
    }
    public class MakeOrderService : ServiceBase<MakeOrder, MakeOrderDto>, IMakeOrderService
    {
        private readonly IRepositoryBase<MakeOrder> _repo;
        private readonly IRepositoryBase<Room> _repoRoom;
        private readonly IRepositoryBase<RecordEarTag> _repoRecordEarTag;
        private readonly IRepositoryBase<RecordMove> _repoRecordMove;
        private readonly IRepositoryBase<RecordWeighing> _repoRecordWeighing;
        private readonly IRepositoryBase<RecordImmunization> _repoRecordImmunization;
        private readonly IRepositoryBase<MakeOrder2Pen> _repoMakeOrder2Pen;
        private readonly IRepositoryBase<RecordCulling> _repoRecordCulling;
        private readonly IRepositoryBase<RecordDeath> _repoRecordDeath;
        private readonly IRepositoryBase<PigTreatment> _repoPigTreatment;
        private readonly IRepositoryBase<Pig> _repoPig;
        private readonly IRepositoryBase<Pen> _repoPen;
        private readonly IRepositoryBase<RecordFeeding> _repoRecordFeeding;
        private readonly IRepositoryBase<SystemConfig> _repoSystemConfig;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        private readonly IConfiguration _configuration;

        public MakeOrderService(
            IRepositoryBase<MakeOrder> repo,
            IRepositoryBase<Room> repoRoom,
            IRepositoryBase<RecordEarTag> repoRecordEarTag,
            IRepositoryBase<RecordMove> repoRecordMove,
            IRepositoryBase<RecordWeighing> repoRecordWeighing,
            IRepositoryBase<RecordImmunization> repoRecordImmunization,
            IRepositoryBase<MakeOrder2Pen> repoMakeOrder2Pen,
            IRepositoryBase<Pen> repoPen,
            IRepositoryBase<RecordFeeding> repoRecordFeeding,
            IRepositoryBase<RecordCulling> repoRecordCulling,
            IRepositoryBase<RecordDeath> repoRecordDeath,
            IRepositoryBase<PigTreatment> repoPigTreatment,
            IRepositoryBase<Pig> repoPig,
            IRepositoryBase<SystemConfig> repoSystemConfig,
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
            _repoRoom = repoRoom;
            _repoRecordEarTag = repoRecordEarTag;
            _repoRecordMove = repoRecordMove;
            _repoRecordWeighing = repoRecordWeighing;
            _repoRecordImmunization = repoRecordImmunization;
            _repoMakeOrder2Pen = repoMakeOrder2Pen;
            _repoRecordCulling = repoRecordCulling;
            _repoRecordDeath = repoRecordDeath;
            _repoPigTreatment = repoPigTreatment;
            _repoPig = repoPig;
            _repoPen = repoPen;
            _repoRecordFeeding = repoRecordFeeding;
            _repoSystemConfig = repoSystemConfig;
            _repoCodeType = repoCodeType;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
            _configuration = configuration;
        }
        public async Task<object> GetMakeOrderByFarmGuid(string farmGuid) {
              using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                string sql = "SP_GetMakeOrderByFarmGuid";
                var parameters = new { @Farm_GUID = farmGuid };
                try
                {
                   var datasource= await conn.QueryAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            return await Task.FromResult(datasource);
                }
                catch
                {
            return new List<dynamic> {};

                }

            }
          
        }
        public override async Task<object> GetDataDropdownlist(DataManager data)
        {
            var datasource = _repo.FindAll().AsQueryable();

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
                 var itemNo = new
                {
                    No = "",
                    Guid = "",
                    RoomGuid = "",
                    OrderName = "No Item",
                };
                var results = (await datasource.Select(x => new
                {
                    Id = x.Id,
                    Guid = x.Guid,
                    FarmGuid = x.FarmGuid,
                    RoomGuid = x.RoomGuid,
                    OrderName = x.OrderName,
                    No = x.OrderNo,
                    Status = x.Status
                }).Select(x => new
                {
                    No = x.No,
                    Guid = x.Guid,
                    RoomGuid = x.RoomGuid,
                    OrderName = $"{x.No} - {x.OrderName}"
                }).ToListAsync());
            if (data.Skip == 0)
            {
               
                results.Insert(0, itemNo);
                return results;
            }
            return results;
        }
        public async Task<OperationResult> StoreRoomGuid(UpdateRoomGuidDto request)
        {
            try
            {
                var item = await _repo.FindAll(x => x.Guid == request.Guid).FirstOrDefaultAsync();
                if (item.RoomGuid != request.RoomGuid)
                {
                    var ap = await _repoMakeOrder2Pen.FindAll(x => x.MakeOrderGuid == request.Guid).ToListAsync();
                    _repoMakeOrder2Pen.RemoveMultiple(ap);
                }
                item.RoomGuid = request.RoomGuid;
                _repo.Update(item);

                await _unitOfWork.SaveChangeAsync();
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
        public async Task<OperationResult> StoreMakeOrder2Pen(StoreMakeOrder2PenDto request)
        {
            try
            {
                var ap = await _repoMakeOrder2Pen.FindAll(x => x.MakeOrderGuid == request.Guid).ToListAsync();
                var pens = await _repoPen.FindAll(x => request.Pens.Contains(x.Guid)).Select(x => x.Guid).ToListAsync();

                if (ap.Any())
                {
                    _repoMakeOrder2Pen.RemoveMultiple(ap);
                    var xapList = new List<MakeOrder2Pen>();
                    foreach (var item in pens)
                    {
                        xapList.Add(new MakeOrder2Pen
                        {
                            PenGuid = item,
                            MakeOrderGuid = request.Guid,
                        });
                    }
                    _repoMakeOrder2Pen.AddRange(xapList);
                }
                else
                {
                    var xapList = new List<MakeOrder2Pen>();
                    foreach (var item in pens)
                    {
                        xapList.Add(new MakeOrder2Pen
                        {
                            PenGuid = item,
                            MakeOrderGuid = request.Guid
                        });
                    }
                    _repoMakeOrder2Pen.AddRange(xapList);
                }

                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.AddSuccess,
                    Success = true,
                    Data = request.Pens
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }

        public async Task<OperationResult> RemoveMakeOrder2Pen(RemoveMakeOrder2PenDto request)
        {
            try
            {
                var ap = await _repoMakeOrder2Pen.FindAll(x => x.MakeOrderGuid == request.Guid && x.PenGuid == request.PenGuid).FirstOrDefaultAsync();
                _repoMakeOrder2Pen.Remove(ap);
                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.AddSuccess,
                    Success = true,
                    Data = null
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }

        public async Task<OperationResult> AddMakeOrder2Pen(AddMakeOrder2PenDto request)
        {
            try
            {

                var item = new MakeOrder2Pen
                {
                    MakeOrderGuid = request.Guid,
                    PenGuid = request.PenGuid
                };
                _repoMakeOrder2Pen.Add(item);
                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.AddSuccess,
                    Success = true,
                    Data = null
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }


        public async Task<object> GetMakeOrderPenDropdown(string makeOrderGuid)
        {
            var query = from a in _repoPen.FindAll(x => x.Status == 1).AsNoTracking()
                        join b in _repoMakeOrder2Pen.FindAll(x => x.MakeOrderGuid == makeOrderGuid).AsNoTracking() on a.Guid equals b.PenGuid into gj
                        from x in gj.DefaultIfEmpty()
                        where x.MakeOrderGuid == null || x.MakeOrderGuid != makeOrderGuid

                        select new
                        {
                            a.Id,
                            a.Guid,
                            Name = a.PenName

                        };
            if (!string.IsNullOrEmpty(makeOrderGuid))
            {
                var query2 = from a in _repoPen.FindAll(x => x.Status == 1).AsNoTracking()
                             join b in _repoMakeOrder2Pen.FindAll().AsNoTracking() on a.Guid equals b.PenGuid
                             where b.MakeOrderGuid == makeOrderGuid
                             select new
                             {
                                 a.Id,
                                 a.Guid,
                                 Name = a.PenName
                             };
                var data = await query.ToListAsync();
                var data2 = await query2.ToListAsync();
                return data.Concat(data2).ToList();

            }
            return (await query.ToListAsync()).DistinctBy(x => x.Guid);
        }
        public async Task<object> GetMakeOrderPen(string makeOrderGuid)
        {
            var query = from a in _repoMakeOrder2Pen.FindAll(x => x.MakeOrderGuid == makeOrderGuid).AsNoTracking()
                        select new
                        {
                            a.PenGuid
                        };

            return await query.Select(x => x.PenGuid).ToListAsync();
        }

        public async Task<object> LoadData(DataManager data, string farmGuid)
        {
            IQueryable<MakeOrderDto> datasource = _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1)
                .OrderByDescending(x => x.Id)
                .ProjectTo<MakeOrderDto>(_configMapper);


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
        public async Task<object> LoadData(DataManager data, string farmGuid, string customerGuid)
        {
            IQueryable<MakeOrderDto> datasource = _repo.FindAll(x => x.FarmGuid == farmGuid && x.CustomerGuid == customerGuid && x.Status == 1).ProjectTo<MakeOrderDto>(_configMapper).OrderByDescending(x => x.Id);
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
        public override async Task<List<MakeOrderDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<MakeOrderDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        private async Task<OperationResult> Validate(MakeOrder model, string type)
        {
            var config = await _repoSystemConfig.FindAll(x => x.Status == 1 && x.Type == SystemConfigConst.Order && x.No == SystemConfigConst.Order_Amount).FirstOrDefaultAsync();
            var maxCount = config.Value.ToDecimal();
            if (maxCount < model.OrderAmound)
            {
                return new OperationResult
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Exceed the allowed amount",
                    Success = false,
                    Data = null
                };
            }
            return new OperationResult
            {
                StatusCode = HttpStatusCode.OK,
                Message = "",
                Success = true,
                Data = null
            };
        }

        private async Task<OperationResult> AddPigs(MakeOrder model, string type)
        {
            try
            {
                if (type == "Update")
                {
                    if (model.OrderAmound.HasValue && model.OrderAmound > 0)
                    {
                        var suffix = await _repoSystemConfig.FindAll(x => x.Status == 1 && x.Type == SystemConfigConst.Pig && x.No == SystemConfigConst.Pig_NO).FirstOrDefaultAsync();

                        var pigsRemove = new List<Pig> { };
                        var pigMaxSequence = await _repoPig.FindAll(x => x.MakeOrderGuid == model.Guid && x.Status == 1).Select(x => x.Sequence).MaxAsync();
                        if (pigMaxSequence.HasValue && pigMaxSequence.Value > model.OrderAmound)
                        {
                            decimal? removeCount = pigMaxSequence.Value - model.OrderAmound.Value;

                            for (int i = 0; i < removeCount.Value; i++)
                            {
                                var pigMax2Sequence = await _repoPig.FindAll(x => x.MakeOrderGuid == model.Guid && x.Status == 1).Select(x => x.Sequence).MaxAsync();
                                var j = i;
                                var removeSequence = pigMax2Sequence - j;
                                var removeItem = await _repoPig.FindAll(x => x.Sequence == removeSequence && x.MakeOrderGuid == model.Guid && x.Status == 1).FirstOrDefaultAsync();
                                removeItem.Status = 0;
                                pigsRemove.Add(removeItem);
                            }
                            _repoPig.UpdateRange(pigsRemove);
                            await _unitOfWork.SaveChangeAsync();
                            operationResult = new OperationResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                Message = MessageReponse.AddSuccess,
                                Success = true,
                                Data = null
                            };
                        }
                        if (pigMaxSequence.HasValue && pigMaxSequence.Value < model.OrderAmound)
                        {
                            var pigs = new List<Pig> { };
                            for (int i = 0; i < model.OrderAmound.Value; i++)
                            {
                                if ((i + 1) <= pigMaxSequence && pigMaxSequence.HasValue)
                                {
                                    continue;
                                }
                                var j = (i + 1) + "";
                                var pig = new Pig
                                {
                                    Idno = $"{j.PadLeft(5, '0')}_{suffix.Value}",
                                    EarNo = $"{j.PadLeft(5, '0')}",
                                    Sequence = j.ToDecimal(),
                                    Status = 1,
                                    MakeOrderGuid = model.Guid,
                                    FarmGuid = model.FarmGuid,
                                    PigType = model.PigType
                                };
                                pigs.Add(pig);
                            }
                            _repoPig.AddRange(pigs);
                            await _unitOfWork.SaveChangeAsync();
                            operationResult = new OperationResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                Message = MessageReponse.AddSuccess,
                                Success = true,
                                Data = null
                            };
                        }


                    }
                }
                else
                {
                    if (model.OrderAmound.HasValue && model.OrderAmound > 0)
                    {
                        var suffix = await _repoSystemConfig.FindAll(x => x.Status == 1 && x.Type == SystemConfigConst.Pig && x.No == SystemConfigConst.Pig_NO).FirstOrDefaultAsync();
                        var pigs = new List<Pig> { };
                        var pigsRemove = new List<Pig> { };
                        var pigMaxSequence = await _repoPig.FindAll(x => x.MakeOrderGuid == model.Guid && x.Status == 1).Select(x => x.Sequence).MaxAsync();
                        if (pigMaxSequence.HasValue)
                        {
                            for (int i = 0; i < model.OrderAmound.Value; i++)
                            {
                                if (i <= pigMaxSequence && pigMaxSequence.HasValue)
                                {
                                    continue;
                                }
                                var j = (i + 1) + "";
                                var pig = new Pig
                                {
                                    Idno = $"{j.PadLeft(5, '0')}_{suffix.Value}",
                                    EarNo = $"{j.PadLeft(5, '0')}",
                                    Sequence = j.ToDecimal(),
                                    Status = 1,
                                    MakeOrderGuid = model.Guid,
                                    FarmGuid = model.FarmGuid,
                                    PigType = model.PigType
                                };
                                pigs.Add(pig);
                            }
                            _repoPig.AddRange(pigs);
                            await _unitOfWork.SaveChangeAsync();
                            operationResult = new OperationResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                Message = MessageReponse.AddSuccess,
                                Success = true,
                                Data = null
                            };
                        }
                        else
                        {
                            for (int i = 0; i < model.OrderAmound.Value; i++)
                            {
                                var j = (i + 1) + "";
                                var pig = new Pig
                                {
                                    Idno = $"{j.PadLeft(5, '0')}_{suffix.Value}",
                                    EarNo = $"{j.PadLeft(5, '0')}",
                                    Sequence = j.ToDecimal(),
                                    Status = 1,
                                    MakeOrderGuid = model.Guid,
                                    FarmGuid = model.FarmGuid,
                                    PigType = model.PigType
                                };
                                pigs.Add(pig);
                            }
                            _repoPig.AddRange(pigs);
                            await _unitOfWork.SaveChangeAsync();
                            operationResult = new OperationResult
                            {
                                StatusCode = HttpStatusCode.OK,
                                Message = MessageReponse.AddSuccess,
                                Success = true,
                                Data = null
                            };
                        }



                    }
                }


            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;

        }
        private async Task StoreProcedureForChartBase(string farmGuid, string storeProcedureName)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                string sql = storeProcedureName;
                var parameters = new { Farm_GUID = farmGuid };
                try
                {
                    await conn.QueryAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                }
                catch
                {
                }

            }
        }

        public override async Task<OperationResult> AddAsync(MakeOrderDto model)
        {
            try
            {


                var item = _mapper.Map<MakeOrder>(model);
                var check = await Validate(item, "");
                if (check.Success == false)
                {
                    return check;
                }
                var configs = await _repoSystemConfig.FindAll(x => x.Type == SystemConfigConst.GrowDays && x.Status == 1).ToListAsync();
                if (configs.Any())
                {
                    var suckling = configs.FirstOrDefault(x => x.No == SystemConfigConst.Sucking);
                    var finisher = configs.FirstOrDefault(x => x.No == SystemConfigConst.Finisher);
                    var grower = configs.FirstOrDefault(x => x.No == SystemConfigConst.Grower);
                    var nursry = configs.FirstOrDefault(x => x.No == SystemConfigConst.Nursry);
                    float sucklingValue = suckling == null ? 0 : suckling.Value.ToFloat();
                    float finisherValue = finisher == null ? 0 : finisher.Value.ToFloat();
                    float growerValue = grower == null ? 0 : grower.Value.ToFloat();
                    float nursryValue = nursry == null ? 0 : nursry.Value.ToFloat();

                    var sucklingDays = sucklingValue + finisherValue + growerValue + nursryValue;
                    var nursryDays = finisherValue + growerValue + nursryValue;
                    var growerDays = finisherValue + growerValue;
                    var finisherDays = finisherValue;
                    if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Sucking.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(sucklingDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(sucklingDays) : null;
                    }
                    else if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Nursry.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(nursryDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(nursryDays) : null;
                    }
                    else if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Grower.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(growerDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(growerDays) : null;
                    } else if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Finisher.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(finisherDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(finisherDays) : null;
                    }
                }
                item.Status = 1;
                _repo.Add(item);
                await _unitOfWork.SaveChangeAsync();
                if (item.OrderAmound > 0)
                     AddPigs(item, "Add").ConfigureAwait(false).GetAwaiter();
                StoreProcedureForChartBase(model.FarmGuid, "Daily_AllSchedule_Update").ConfigureAwait(false).GetAwaiter();
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
        public override async Task<OperationResult> UpdateAsync(MakeOrderDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);

            item.FarmGuid = model.FarmGuid;
            item.CustomerGuid = model.CustomerGuid;
            item.OrderNo = model.OrderNo;
            item.OrderName = model.OrderName;
            item.OrderDate = model.OrderDate;
            item.DeliveryDate = model.DeliveryDate;
            item.EstimateEndDate = model.EstimateEndDate;
            item.EstimateStartDate = model.EstimateStartDate;

            item.RealEndDate = model.RealEndDate;
            item.RealStartDate = model.RealStartDate;

            item.OrderBreed = model.OrderBreed;
            item.OrderAmound = model.OrderAmound;
            item.PigType = model.PigType;
            item.OrderFarm = model.OrderFarm;
            item.OrderPrice = model.OrderPrice;
            item.Comment = model.Comment;
            item.RoomGuid = model.RoomGuid;
            item.BomGuid = model.BomGuid;
            item.InAmound = model.InAmound;
            item.CurrentAmound = model.CurrentAmound;
            item.CullingAmound = model.CullingAmound;
            item.DeathAmound = model.DeathAmound;
            item.SaleAmound = model.SaleAmound;
            item.DonateAmound = model.DonateAmound;

            item.CloseDate = model.CloseDate;
            item.CloseReason = model.CloseReason;
            item.CloseGuid = model.CloseGuid;
            item.AgreeDate = model.AgreeDate;
            item.AgreeReason = model.AgreeReason;
            item.AgreeGuid = model.AgreeGuid;
            var check = await Validate(item, "");
            if (check.Success == false)
            {
                return check;
            }

            var configs = await _repoSystemConfig.FindAll(x => x.Type == SystemConfigConst.GrowDays && x.Status == 1).ToListAsync();
                if (configs.Any())
                {
                    var suckling = configs.FirstOrDefault(x => x.No == SystemConfigConst.Sucking);
                    var finisher = configs.FirstOrDefault(x => x.No == SystemConfigConst.Finisher);
                    var grower = configs.FirstOrDefault(x => x.No == SystemConfigConst.Grower);
                    var nursry = configs.FirstOrDefault(x => x.No == SystemConfigConst.Nursry);
                    float sucklingValue = suckling == null ? 0 : suckling.Value.ToFloat();
                    float finisherValue = finisher == null ? 0 : finisher.Value.ToFloat();
                    float growerValue = grower == null ? 0 : grower.Value.ToFloat();
                    float nursryValue = nursry == null ? 0 : nursry.Value.ToFloat();

                    var sucklingDays = sucklingValue + finisherValue + growerValue + nursryValue;
                    var nursryDays = finisherValue + growerValue + nursryValue;
                    var growerDays = finisherValue + growerValue;
                    var finisherDays = finisherValue;
                    if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Sucking.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(sucklingDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(sucklingDays) : null;
                    }
                    else if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Nursry.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(nursryDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(nursryDays) : null;
                    }
                    else if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Grower.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(growerDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(growerDays) : null;
                    } else if (item.PigType.ToSafetyString().ToLowerCase() == SystemConfigConst.Finisher.ToLowerCase())
                    {
                        item.RealEndDate = item.RealStartDate.HasValue ? item.RealStartDate.Value.AddDays(finisherDays) : null;
                        item.EstimateEndDate = item.EstimateStartDate.HasValue ? item.EstimateStartDate.Value.AddDays(finisherDays) : null;
                    }
                }
                
            _repo.Update(item);

            try
            {
                await _unitOfWork.SaveChangeAsync();
                if (item.OrderAmound > 0)
                     AddPigs(item, "Update").ConfigureAwait(false).GetAwaiter();

                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.UpdateSuccess,
                    Success = true,
                    Data = item
                };
                 StoreProcedureForChartBase(model.FarmGuid, "Daily_AllSchedule_Update").ConfigureAwait(false).GetAwaiter();

            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }
        public override async Task<OperationResult> DeleteAsync(object id)
        {
            try
            {
                var item = await _repo.FindByIDAsync(id);
                item.Status = 0;
                _repo.Update(item);
                await _unitOfWork.SaveChangeAsync();

                var pigs = await _repoPig.FindAll(x => x.Status == 1 && x.MakeOrderGuid == item.Guid).ToListAsync();
                foreach (var pig in pigs)
                {
                    pig.Status = 0;
                }
                _repoPig.UpdateRange(pigs);

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
        private async Task<object> GetDatasource(string farmGuid, string pigType, string lang)
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                string sql = @"
                SELECT a.[ID] as Id
                    ,[Farm_GUID] as FarmGuid
                    ,[Customer_GUID]as CustomerGuid
                    ,[Order_NO]as OrderNO
                    ,[Order_Name]as OrderName
                    ,[Order_Date]as OrderDate
                    ,[Delivery_Date]as DeliveryDate
                    ,[Estimate_StartDate]as EstimateStartDate
                    ,[Estimate_EndDate]as EstimateEndDate
                    ,[Real_StartDate]as RealStartDate
                    ,[Real_EndDate]as RealEndDate
                    ,[Order_Breed]as OrderBreed
                    ,[Order_Amound]as OrderAmound
                    ,[Order_Type]as OrderType
                    ,[Order_Farm]as OrderFarm
                    ,[Order_Price]as OrderPrice
                    ,a.[COMMENT]as Comment
                    ,a.[CREATE_DATE]as CreateDate
                    ,a.[CREATE_BY]as CreateBy
                    ,a.[UPDATE_DATE]as UpdateDate
                    ,a.[UPDATE_BY]as UpdateBy
                    ,a.[DELETE_DATE]as DeleteDate
                    ,a.[DELETE_BY]as DeleteBy
                    ,a.[STATUS]as Status
                    ,[GUID]as Guid
                    ,[Pig_Type]as PigType
                    ,[BOM_GUID]as BomGuid
                    ,Room_GUID as a.RoomGuid
                    ,DonateAmound as a.DonateAmound
                    ,CloseDate as a.CloseDate
                    ,CloseReason as a.CloseReason
                    ,CloseGuid as a..CloseGuid
                    ,AgreeDate as a.AgreeDate
                    ,AgreeReason as a.AgreeReason
                    ,AgreeGuid as a.AgreeGuid
                    ,(CASE WHEN (CASE WHEN @lang = 'tw' THEN CODE_NAME
                            WHEN @lang = 'cn' THEN CODE_NAME_CN
                            WHEN @lang = 'en' THEN CODE_NAME_EN
                            WHEN @lang = 'vi' THEN CODE_NAME_VN
                            ELSE CODE_NAME END) is null THEN CODE_NAME END) AS OrderBreedName
                    ,DATEDIFF(Day, a.Real_StartDate, GETDATE()) AS DayAge
                    ,(a.Order_Amound - (SELECT COUNT(*) FROM Record_Culling rc WHERE rc.MakeOrder_GUID = a.GUID and rc.Status = 1) - (SELECT COUNT(*) FROM Record_Death rd WHERE rd.MakeOrder_GUID = a.GUID and rd.Status = 1) ) as CurrentAmount
                    ,(SELECT TOP 1 pe.Pen_Name FROM Pig pig LEFT JOIN Pen pe ON pig.Pen_GUID = pe.GUID WHERE pig.MakeOrder_GUID = a.GUID and pig.STATUS = 1 and pe.STATUS = 1) as PenName
                FROM [PigFarm].[dbo].[MakeOrder] a
                Left Join CODE_TYPE b on  a.Order_Breed = b.CODE_NO and b.CODE_TYPE = 'Breed'
                WHERE a.Pig_Type = @pigType and a.Farm_GUID = @farmGuid
                ";
                var parameters = new { farmGuid = farmGuid, pigType = pigType, lang = lang };
                try
                {
                    var data = conn.Query<MakeOrderDto>(sql, parameters).AsQueryable();
                    return data;
                }
                catch
                {
                    return new object[] { };
                }

            }
        }
        public async Task<object> LoadDataByType(DataManager data, string farmGuid, string pigType, string lang)
        {
            //IQueryable<MakeOrderDto> datasource = _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.PigType == pigType)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<MakeOrderDto>(_configMapper);

            var currentDate = DateTime.Now.Date;
            var datasource = (from a in _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.PigType == pigType)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Breed && x.Status == "Y") on a.OrderBreed equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()
                              join b in _repoRoom.FindAll(x => x.Status == 1).AsNoTracking() on a.RoomGuid equals b.Guid into gj
                              from x in gj.DefaultIfEmpty()
                              select new MakeOrderDto()
                              {
                                  Id = a.Id,
                                  CustomerGuid = a.CustomerGuid,
                                  OrderNo = a.OrderNo,
                                  OrderName = a.OrderName,
                                  OrderDate = a.OrderDate,
                                  DeliveryDate = a.DeliveryDate,
                                  EstimateStartDate = a.EstimateStartDate,
                                  EstimateEndDate = a.EstimateEndDate,
                                  RealStartDate = a.RealStartDate,
                                  RealEndDate = a.RealEndDate,
                                  OrderBreed = a.OrderBreed,
                                  OrderAmound = a.OrderAmound,
                                  PigType = a.PigType,
                                  OrderType = a.OrderType,
                                  OrderFarm = a.OrderFarm,
                                  OrderPrice = a.OrderPrice,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  FarmGuid = a.FarmGuid,
                                  BomGuid = a.BomGuid,
                                  RoomGuid = a.RoomGuid,
                                  InAmound = a.InAmound,
                                  CurrentAmound = a.CurrentAmound,
                                  CullingAmound = a.CullingAmound,
                                  DeathAmound = a.DeathAmound,
                                  SaleAmound = a.SaleAmound,
                                  DonateAmound = a.DonateAmound,
                                  CloseDate = a.CloseDate,
                                  CloseReason = a.CloseReason,
                                  CloseGuid = a.CloseGuid,
                                  AgreeDate = a.AgreeDate,
                                  AgreeReason = a.AgreeReason,
                                  AgreeGuid = a.AgreeGuid,
                                  OrderBreedName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                  DayAge = EF.Functions.DateDiffDay(a.RealStartDate, currentDate),
                                  CurrentAmount = a.OrderAmound - (from rc in _repoRecordCulling.FindAll().AsNoTracking() where rc.Status == 1 && rc.MakeOrderGuid == a.Guid select new { rc.Guid }).Count() - (from rc in _repoRecordDeath.FindAll().AsNoTracking() where rc.Status == 1 && rc.MakeOrderGuid == a.Guid select new { rc.Guid }).Count(),
                                  RoomName = x == null ? "" : x.RoomName

                              }).OrderByDescending(x => x.Id).AsQueryable();

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
            var Result = await datasource.ToListAsync();
            // foreach (var a in Result)
            // {
            //     a.CurrentAmount = a.OrderAmound - _repoRecordCulling.FindAll(b => b.Status == 1 && b.MakeOrderGuid == a.Guid).AsNoTracking().Count() - _repoRecordDeath.FindAll(b => b.Status == 1 && b.MakeOrderGuid == a.Guid).AsNoTracking().Count();

            // }
            return new
            {
                Result = Result,
                Count = count
            };
        }

        public async Task<object> LoadMobileDataByType(DataManager data, string farmGuid, string pigType, string lang)
        {
            //IQueryable<MakeOrderDto> datasource = _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.PigType == pigType)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<MakeOrderDto>(_configMapper);

            var currentDate = DateTime.Now.Date;
            var datasource = (from a in _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.PigType == pigType)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Breed && x.Status == "Y") on a.OrderBreed equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()
                              join b in _repoRoom.FindAll(x => x.Status == 1).AsNoTracking() on a.RoomGuid equals b.Guid into gj
                              from x in gj.DefaultIfEmpty()
                              select new MakeOrderMobileDto()
                              {
                                  Id = a.Id,
                                  CustomerGuid = a.CustomerGuid,
                                  OrderNo = a.OrderNo,
                                  OrderName = a.OrderName,
                                  OrderDate = a.OrderDate,
                                  DeliveryDate = a.DeliveryDate,
                                  EstimateStartDate = a.EstimateStartDate,
                                  EstimateEndDate = a.EstimateEndDate,
                                  RealStartDate = a.RealStartDate,
                                  RealEndDate = a.RealEndDate,
                                  OrderBreed = a.OrderBreed,
                                  OrderAmound = a.OrderAmound,
                                  PigType = a.PigType,
                                  OrderType = a.OrderType,
                                  OrderFarm = a.OrderFarm,
                                  OrderPrice = a.OrderPrice,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  FarmGuid = a.FarmGuid,
                                  BomGuid = a.BomGuid,
                                  RoomGuid = a.RoomGuid,
                                  InAmound = a.InAmound,
                                  CurrentAmound = a.CurrentAmound,
                                  CullingAmound = a.CullingAmound,
                                  DeathAmound = a.DeathAmound,
                                  SaleAmound = a.SaleAmound,
                                  DonateAmound = a.DonateAmound,
                                  CloseDate = a.CloseDate,
                                  CloseReason = a.CloseReason,
                                  CloseGuid = a.CloseGuid,
                                  AgreeDate = a.AgreeDate,
                                  AgreeReason = a.AgreeReason,
                                  AgreeGuid = a.AgreeGuid,
                                  OrderBreedName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                  DayAge = EF.Functions.DateDiffDay(a.RealStartDate, currentDate),
                                  CurrentAmount = a.OrderAmound - (from rc in _repoRecordCulling.FindAll().AsNoTracking() where rc.Status == 1 && rc.MakeOrderGuid == a.Guid select new { rc.Guid }).Count() - (from rc in _repoRecordDeath.FindAll().AsNoTracking() where rc.Status == 1 && rc.MakeOrderGuid == a.Guid select new { rc.Guid }).Count(),
                                  PenName = (from pi in _repoPig.FindAll()
                                             where pi.FarmGuid == farmGuid && pi.Status == 1 && pi.MakeOrderGuid == a.Guid
                                             join p in _repoPen.FindAll() on pi.PenGuid equals p.Guid into ap
                                             from pen in ap.DefaultIfEmpty()
                                             where pen.Status == 1
                                             select pen.PenName
                              ).FirstOrDefault(),
                                  RoomName = x == null ? "" : x.RoomName,

                                  RecordFeeding = (from pi in _repoRecordFeeding.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordImmunization = (from pi in _repoRecordImmunization.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordWeighing = (from pi in _repoRecordWeighing.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordMove = (from pi in _repoRecordMove.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordCulling = (from pi in _repoRecordCulling.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordDeath = (from pi in _repoRecordDeath.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordPigEar = (from pi in _repoRecordEarTag.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),
                                  RecordTreatment = (from pi in _repoPigTreatment.FindAll() where pi.MakeOrderGuid == a.Guid && pi.Status == 1 select pi.Id).Count(),

                              }).OrderByDescending(x => x.Id).AsQueryable();

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
            var Result = await datasource.ToListAsync();
            // foreach (var a in Result)
            // {
            //     a.CurrentAmount = a.OrderAmound - _repoRecordCulling.FindAll(b => b.Status == 1 && b.MakeOrderGuid == a.Guid).AsNoTracking().Count() - _repoRecordDeath.FindAll(b => b.Status == 1 && b.MakeOrderGuid == a.Guid).AsNoTracking().Count();

            // }
            return new
            {
                Result = Result,
                Count = count
            };
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

        public async Task<object> GetByGuid(string guid)
        {
            return await _repo.FindAll(x => x.Guid == guid).FirstOrDefaultAsync();

        }

        public async Task<object> GetPensByRoom(string roomGuid)
        {
            return await (from x in _repoPen.FindAll(x => x.Status == 1).AsNoTracking()
                          where x.RoomGuid == roomGuid
                          select new
                          {
                              x.Id,
                              x.Guid,
                              x.PenNo,
                              Name = $"{x.PenNo} - {x.PenName}"
                          }).ToListAsync();
        }
    }
}
