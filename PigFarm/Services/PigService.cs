using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PigFarm.Constants;
using PigFarm.Data;
using PigFarm.DTO;
using PigFarm.Helpers;
using PigFarm.Models;
using PigFarm.Services.Base;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
namespace PigFarm.Services
{
    public interface IPigService : IServiceBase<Pig, PigDto>
    {
        Task<object> GetPigs(string farmGuid, int top, int skip, string filter, string selected);
        Task<object> GetPigsByPen(DataManager data, string penGuid, string recordGuid, string type);
        Task<object> GetPigs2(DataManager data, string farmGuid);
        Task<object> GetFarms();
        Task<object> GetAreas(string farmGuid);
        Task<object> GetBarns(string farmGuid, string areaGuid);
        Task<object> GetCullingTanks(string farmGuid, string areaGuid);
        Task<object> GetRooms(string farmGuid, string areaGuid, string barnGuid);
        Task<object> GetPens(string farmGuid, string areaGuid, string barnGuid, string roomGuid);
        Task<object> LoadData(DataManager data, string farmGuid, string makeOrderGuid, string lang);
        Task<object> LoadData(DataManager data, string farmGuid, string pen, string pigType, string pigPhase, string lang);
        Task<object> GetAudit(object id);
        Task<object> GetPigByNo(string no);
        Task<OperationResult> RemoveRecord2Pig(Record2Pig request);
        Task<OperationResult> AddRecord2Pig(Record2Pig request);
        Task<object> GetPigsByPenAndRecord(string penGuid, string recordGuid, string type);

        Task<object> GetSelectedPig(string[] guid, string recordGuid, string type);
        Task<object> GetSelectedPig(string[] guid);
        Task<object> GetSelectedPigsByRecord(string recordGuid, string type);
        Task<object> GetPigByManyPen(MultiplePigParams multiplePigParams);
        Task<object> GetSelectedPig(SelectedPigParams p);
    }
    public class PigService : ServiceBase<Pig, PigDto>, IPigService
    {
        private readonly IRepositoryBase<Pig> _repo;
        private readonly IRepositoryBase<Disease> _repoDisease;
        private readonly IRepositoryBase<MakeOrder> _repoMakeOrder;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<Farm> _repoFarm;
        private readonly IRepositoryBase<Area> _repoArea;
        private readonly IRepositoryBase<Barn> _repoBarn;
        private readonly IRepositoryBase<Room> _repoRoom;
        private readonly IRepositoryBase<Pen> _repoPen;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IRepositoryBase<CullingTank> _repoCullingTank;
        private readonly IRepositoryBase<Record2Pig> _repoRecord2Pig;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PigFarmContext _context;
        private readonly MapperConfiguration _configMapper;
        private readonly IConfiguration _configuration;
        public PigService(
            IRepositoryBase<Pig> repo,
            IRepositoryBase<Disease> repoDisease,
            IRepositoryBase<Record2Pig> repoRecord2Pig,
            IRepositoryBase<MakeOrder> repoMakeOrder,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<Farm> repoFarm,
            IRepositoryBase<Area> repoArea,
            IRepositoryBase<Barn> repoBarn,
            IRepositoryBase<CullingTank> repoCullingTank,
            IRepositoryBase<Room> repoRoom,
            IRepositoryBase<Pen> repoPen,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            PigFarmContext context,
            MapperConfiguration configMapper,
            IConfiguration configuration

            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
             _configuration = configuration;
            _repo = repo;
            _context = context;
            _repoDisease = repoDisease;
            _repoRecord2Pig = repoRecord2Pig;
            _repoMakeOrder = repoMakeOrder;
            _repoCodeType = repoCodeType;
            _repoFarm = repoFarm;
            _repoArea = repoArea;
            _repoBarn = repoBarn;
            _repoCullingTank = repoCullingTank;
            _repoRoom = repoRoom;
            _repoPen = repoPen;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> GetPigByManyPen(MultiplePigParams multiplePigParams) {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
            var pens = string.Join(",", multiplePigParams.pens);

                string sql = "SP_GetPigsByManyPens";
                var parameters = new { @Farm_GUID = multiplePigParams.FarmGuid, @Room_GUID = multiplePigParams.RoomGuid, Pen_List = pens };
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
           
            var datasource = _repo.FindAll().Select(x => new
            {
                Id = x.Id,
                Guid = x.Guid,
                FarmGuid = x.FarmGuid,
                PenGuid = x.PenGuid,
                RoomGuid = x.RoomGuid,
                Name = x.Idno,
                EarNo = x.EarNo,
                Status = x.Status
            }).AsQueryable();

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

            if (data.Skip == 0)
            {
                var itemNo = new List<dynamic>() {
                   new {
                    Guid = "",
                    Name = "No Item"
                }
                };
                return (await datasource.Select(x => new
                {
                    Guid = x.Guid,
                    Name = x.Name
                }).ToListAsync()).Union(itemNo);
            }
            return await datasource.Select(x => new
            {
                Guid = x.Guid,
                Name = x.Name
            }).ToListAsync();
        }
        public async Task<OperationResult> CheckExistIDNO(string Idno)
        {
            var item = await _repo.FindAll(x => x.Idno == Idno && x.Status == 1).AnyAsync();
            if (item)
            {
                return new OperationResult { StatusCode = HttpStatusCode.OK, Message = "The Id NO already existed!", Success = false };
            }
            operationResult = new OperationResult
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Data = item
            };
            return operationResult;
        }

        public async Task<OperationResult> CheckExistEarNo(string earNo)
        {
            var item = await _repo.FindAll(x => x.EarNo == earNo && x.Status == 1).AnyAsync();
            if (item)
            {
                return new OperationResult { StatusCode = HttpStatusCode.OK, Message = "The Ear NO already existed!", Success = false };
            }
            operationResult = new OperationResult
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Data = item
            };
            return operationResult;
        }

        public async Task<OperationResult> CheckExistEarTag(string earTag)
        {
            var item = await _repo.FindAll(x => x.EarTag == earTag && x.Status == 1).AnyAsync();
            if (item)
            {
                return new OperationResult { StatusCode = HttpStatusCode.OK, Message = "The Ear Tag already existed!", Success = false };
            }
            operationResult = new OperationResult
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Data = item
            };
            return operationResult;
        }
        public async Task<OperationResult> CheckExistRfidtag(string rfidtag)
        {
            var item = await _repo.FindAll(x => x.Rfidtag == rfidtag && x.Status == 1).AnyAsync();
            if (item)
            {
                return new OperationResult { StatusCode = HttpStatusCode.OK, Message = "The RFID Tag already existed!", Success = false };
            }
            operationResult = new OperationResult
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Data = item
            };
            return operationResult;
        }

        public override async Task<OperationResult> AddAsync(PigDto model)
        {
            try
            {
                var checkIdno = await CheckExistIDNO(model.Idno);
                if (!checkIdno.Success) return checkIdno;

                var checkEarNo = await CheckExistEarNo(model.EarNo);
                if (!checkEarNo.Success) return checkEarNo;

                var checkEarTag = await CheckExistEarTag(model.EarTag);
                if (!checkEarTag.Success) return checkEarTag;

                var checkRfidtag = await CheckExistRfidtag(model.Rfidtag);
                if (!checkRfidtag.Success) return checkRfidtag;

                var item = _mapper.Map<Pig>(model);
                item.Status = 1;
                if (!string.IsNullOrEmpty(item.MakeOrderGuid))
                {
                    var maxItem = await _repo.FindAll(x => x.Status == 1).Select(x => x.Sequence).MaxAsync();
                    item.Sequence = maxItem.HasValue && maxItem.Value > 0 ? maxItem.Value + 1 : 1;
                }
                _repo.Add(item);

                await _unitOfWork.SaveChangeAsync();

                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.AddSuccess,
                    Success = true,
                    Data = model
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }
        public override async Task<OperationResult> UpdateAsync(PigDto model)
        {
            var item = await _repo.FindAll(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (item.Idno != model.Idno)
            {
                var checkIdno = await CheckExistIDNO(model.Idno);
                if (!checkIdno.Success) return checkIdno;
            }

            if (item.EarNo != model.EarNo)
            {
                var checkEarNo = await CheckExistEarNo(model.EarNo);
                if (!checkEarNo.Success) return checkEarNo;
            }


            if (item.EarTag != model.EarTag)
            {
                var checkEarTag = await CheckExistEarTag(model.EarTag);
                if (!checkEarTag.Success) return checkEarTag;
            }

            if (item.Rfidtag != model.Rfidtag)
            {
                var checkRfidtag = await CheckExistRfidtag(model.Rfidtag);
                if (!checkRfidtag.Success) return checkRfidtag;
            }


            //item.Id = model.Id;
            item.PigType = model.PigType;
            item.Outsourcing = model.Outsourcing;
            item.FarmGuid = model.FarmGuid;
            item.AreaGuid = model.AreaGuid;
            item.BarnGuid = model.BarnGuid;
            item.RoomGuid = model.RoomGuid;
            item.PenGuid = model.PenGuid;
            item.CullingTankGuid = model.CullingTankGuid;
            item.FatherGuid = model.FatherGuid;
            item.MotherGuid = model.MotherGuid;
            item.Idno = model.Idno;
            item.EarNo = model.EarNo;
            item.EarTag = model.EarTag;
            item.Rfidtag = model.Rfidtag;
            item.Birthday = model.Birthday;
            item.DayAge = model.DayAge;
            item.Sex = model.Sex;
            item.Weight = model.Weight;
            item.WeightDate = model.WeightDate;
            item.WeightDayAge = model.WeightDayAge;
            item.Breed = model.Breed;
            item.BirthPenGuid = model.BirthPenGuid;
            item.EnterOrigin = model.EnterOrigin;
            item.EnterDate = model.EnterDate;
            item.EnterDept = model.EnterDept;
            item.TransferMoney = model.TransferMoney;
            item.TransferDate = model.TransferDate;
            item.TransferFrom = model.TransferFrom;
            item.FarrowStatus = model.FarrowStatus;
            item.FarrowComment = model.FarrowComment;
            item.SuckingCheckInDate = model.SuckingCheckInDate;
            item.SuckingCheckInStatus = model.SuckingCheckInStatus;
            item.SuckingCheckOutDate = model.SuckingCheckOutDate;
            item.SuckingCheckOutStatus = model.SuckingCheckOutStatus;
            item.GrowerCheckInDate = model.GrowerCheckInDate;
            item.GrowerCheckInStatus = model.GrowerCheckInStatus;
            item.GrowerCheckOutDate = model.GrowerCheckOutDate;
            item.GrowerCheckOutStatus = model.GrowerCheckOutStatus;
            item.FinisherCheckInDate = model.FinisherCheckInDate;
            item.FinisherCheckInStatus = model.FinisherCheckInStatus;
            item.FinisherCheckOutDate = model.FinisherCheckOutDate;
            item.FinisherCheckOutStatus = model.FinisherCheckOutStatus;

            item.NurseryCheckInDate = model.NurseryCheckInDate;
            item.NurseryCheckInStatus = model.NurseryCheckInStatus;
            item.NurseryCheckOutDate = model.NurseryCheckOutDate;
            item.NurseryCheckOutStatus = model.NurseryCheckOutStatus;

            item.CancelFlag = model.CancelFlag;
            item.Comment = model.Comment;
            item.CreateDate = model.CreateDate;
            item.CreateBy = model.CreateBy;
            item.UpdateDate = model.UpdateDate;
            item.UpdateBy = model.UpdateBy;
            item.Status = model.Status;
            item.Guid = model.Guid;
            item.Phase = model.Phase;
            item.Sequence = model.Sequence;
            item.MakeOrderGuid = model.MakeOrderGuid;
            _repo.Update(item);
            try
            {
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
        public async Task<object> GetPigs2(DataManager data, string farmGuid)
        {
            var datasource = _repo.FindAll(x => x.Status == 1)
                .Select(x => new
                {
                    x.Guid,
                    x.Id,
                    Name = x.Idno
                });
            // var count = await datasource.CountAsync();
            if (data.Where != null) // for filtering
                datasource = QueryableDataOperations.PerformWhereFilter(datasource, data.Where, data.Where[0].Condition);
            if (data.Sorted != null)//for sorting
                datasource = QueryableDataOperations.PerformSorting(datasource, data.Sorted);
            if (data.Search != null)
                datasource = QueryableDataOperations.PerformSearching(datasource, data.Search);
            //count = await datasource.CountAsync();
            if (data.Skip >= 0)//for paging
                datasource = QueryableDataOperations.PerformSkip(datasource, data.Skip);
            if (data.Take > 0)//for paging
                datasource = QueryableDataOperations.PerformTake(datasource, data.Take);
            return new
            {
                value = await datasource.ToListAsync()
            };
        }

        public async Task<object> LoadData(DataManager data, string farmGuid, string pen, string pigType, string pigPhase, string lang)
        {
            if (!string.IsNullOrEmpty(pen) && !string.IsNullOrEmpty(pigPhase) && !string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.PenGuid == pen && x.Phase == pigPhase && x.PigType == pigType
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else if (!string.IsNullOrEmpty(pen) && !string.IsNullOrEmpty(pigPhase) && string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.PenGuid == pen && x.Phase == pigPhase
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else if (!string.IsNullOrEmpty(pen) && string.IsNullOrEmpty(pigPhase) && !string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.PenGuid == pen && x.PigType == pigType
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else if (!string.IsNullOrEmpty(pen) && string.IsNullOrEmpty(pigPhase) && string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.PenGuid == pen
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else if (string.IsNullOrEmpty(pen) && !string.IsNullOrEmpty(pigPhase) && string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.Phase == pigPhase
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else if (string.IsNullOrEmpty(pen) && string.IsNullOrEmpty(pigPhase) && !string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.PigType == pigType
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else if (string.IsNullOrEmpty(pen) && !string.IsNullOrEmpty(pigPhase) && !string.IsNullOrEmpty(pigType))
            {
                var datasource = (from a in _repo.FindAll(x =>
                                    x.Status == 1 && x.FarmGuid == farmGuid && x.PigType == pigType && x.Phase == pigPhase
                                  )
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }
            else
            {
                var datasource = (from a in _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid)
                                  join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                                  from t in ab.DefaultIfEmpty()
                                  join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                                  from p in ac.DefaultIfEmpty()
                                  join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                                  from e in ad.DefaultIfEmpty()
                                  select new PigDto
                                  {
                                      Id = a.Id,
                                      PigType = a.PigType,
                                      Outsourcing = a.Outsourcing,
                                      FarmGuid = a.FarmGuid,
                                      AreaGuid = a.AreaGuid,
                                      BarnGuid = a.BarnGuid,
                                      RoomGuid = a.RoomGuid,
                                      PenGuid = a.PenGuid,
                                      CullingTankGuid = a.CullingTankGuid,
                                      FatherGuid = a.FatherGuid,
                                      MotherGuid = a.MotherGuid,
                                      Idno = a.Idno,
                                      EarNo = a.EarNo,
                                      EarTag = a.EarTag,
                                      Rfidtag = a.Rfidtag,
                                      Birthday = a.Birthday,
                                      DayAge = a.DayAge,
                                      Sex = a.Sex,
                                      Weight = a.Weight,
                                      WeightDate = a.WeightDate,
                                      WeightDayAge = a.WeightDayAge,
                                      Breed = a.Breed,
                                      BirthPenGuid = a.BirthPenGuid,
                                      EnterOrigin = a.EnterOrigin,
                                      EnterDate = a.EnterDate,
                                      EnterDept = a.EnterDept,
                                      TransferMoney = a.TransferMoney,
                                      TransferDate = a.TransferDate,
                                      TransferFrom = a.TransferFrom,
                                      FarrowStatus = a.FarrowStatus,
                                      FarrowComment = a.FarrowComment,
                                      SuckingCheckInDate = a.SuckingCheckInDate,
                                      SuckingCheckInStatus = a.SuckingCheckInStatus,
                                      SuckingCheckOutDate = a.SuckingCheckOutDate,
                                      SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                                      GrowerCheckInDate = a.GrowerCheckInDate,
                                      GrowerCheckInStatus = a.GrowerCheckInStatus,
                                      GrowerCheckOutDate = a.GrowerCheckOutDate,
                                      GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                                      FinisherCheckInDate = a.FinisherCheckInDate,
                                      FinisherCheckInStatus = a.FinisherCheckInStatus,
                                      FinisherCheckOutDate = a.FinisherCheckOutDate,
                                      FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                                      NurseryCheckInDate = a.NurseryCheckInDate,
                                      NurseryCheckInStatus = a.NurseryCheckInStatus,
                                      NurseryCheckOutDate = a.NurseryCheckOutDate,
                                      NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                                      CancelFlag = a.CancelFlag,
                                      Comment = a.Comment,
                                      CreateDate = a.CreateDate,
                                      CreateBy = a.CreateBy,
                                      UpdateDate = a.UpdateDate,
                                      UpdateBy = a.UpdateBy,
                                      Status = a.Status,
                                      Guid = a.Guid,
                                      Phase = a.Phase,
                                      Sequence = a.Sequence,
                                      MakeOrderGuid = a.MakeOrderGuid,
                                      SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                      PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                      PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

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
                return new
                {
                    Result = await datasource.ToListAsync(),
                    Count = count
                };
            }

        }
        private IQueryable<PigDto> Datasource(string farmGuid, string lang)
        {
            return (from a in _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid)
                    join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.PIG_SEX && x.Status == "Y") on a.Sex equals Convert.ToDecimal(b.CodeNo) into ab
                    from t in ab.DefaultIfEmpty()
                    join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals c.CodeNo into ac
                    from p in ac.DefaultIfEmpty()
                    join d in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Phase && x.Status == "Y") on a.Phase equals d.CodeNo into ad
                    from e in ad.DefaultIfEmpty()
                    select new PigDto
                    {
                        Id = a.Id,
                        PigType = a.PigType,
                        Outsourcing = a.Outsourcing,
                        FarmGuid = a.FarmGuid,
                        AreaGuid = a.AreaGuid,
                        BarnGuid = a.BarnGuid,
                        RoomGuid = a.RoomGuid,
                        PenGuid = a.PenGuid,
                        CullingTankGuid = a.CullingTankGuid,
                        FatherGuid = a.FatherGuid,
                        MotherGuid = a.MotherGuid,
                        Idno = a.Idno,
                        EarNo = a.EarNo,
                        EarTag = a.EarTag,
                        Rfidtag = a.Rfidtag,
                        Birthday = a.Birthday,
                        DayAge = a.DayAge,
                        Sex = a.Sex,
                        Weight = a.Weight,
                        WeightDate = a.WeightDate,
                        WeightDayAge = a.WeightDayAge,
                        Breed = a.Breed,
                        BirthPenGuid = a.BirthPenGuid,
                        EnterOrigin = a.EnterOrigin,
                        EnterDate = a.EnterDate,
                        EnterDept = a.EnterDept,
                        TransferMoney = a.TransferMoney,
                        TransferDate = a.TransferDate,
                        TransferFrom = a.TransferFrom,
                        FarrowStatus = a.FarrowStatus,
                        FarrowComment = a.FarrowComment,
                        SuckingCheckInDate = a.SuckingCheckInDate,
                        SuckingCheckInStatus = a.SuckingCheckInStatus,
                        SuckingCheckOutDate = a.SuckingCheckOutDate,
                        SuckingCheckOutStatus = a.SuckingCheckOutStatus,
                        GrowerCheckInDate = a.GrowerCheckInDate,
                        GrowerCheckInStatus = a.GrowerCheckInStatus,
                        GrowerCheckOutDate = a.GrowerCheckOutDate,
                        GrowerCheckOutStatus = a.GrowerCheckOutStatus,
                        FinisherCheckInDate = a.FinisherCheckInDate,
                        FinisherCheckInStatus = a.FinisherCheckInStatus,
                        FinisherCheckOutDate = a.FinisherCheckOutDate,
                        FinisherCheckOutStatus = a.FinisherCheckOutStatus,
                        NurseryCheckInDate = a.NurseryCheckInDate,
                        NurseryCheckInStatus = a.NurseryCheckInStatus,
                        NurseryCheckOutDate = a.NurseryCheckOutDate,
                        NurseryCheckOutStatus = a.NurseryCheckOutStatus,
                        CancelFlag = a.CancelFlag,
                        Comment = a.Comment,
                        CreateDate = a.CreateDate,
                        CreateBy = a.CreateBy,
                        UpdateDate = a.UpdateDate,
                        UpdateBy = a.UpdateBy,
                        Status = a.Status,
                        Guid = a.Guid,
                        Phase = a.Phase,
                        Sequence = a.Sequence,
                        MakeOrderGuid = a.MakeOrderGuid,
                        SexName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                        PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                        PhaseName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,

                    }).OrderByDescending(x => x.Id).AsQueryable();
        }
        public async Task<object> LoadData(DataManager data, string farmGuid, string makeOrderGuid, string lang)
        {
            var datasource = Datasource(farmGuid, lang);
            if (!string.IsNullOrEmpty(makeOrderGuid) && !string.IsNullOrEmpty(makeOrderGuid))
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

        public override async Task<List<PigDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1)
                .OrderByDescending(x => x.Id)
                .ProjectTo<PigDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }

        private async Task UpdateMakeOrder(Pig pig)
        {
            var order = await _repoMakeOrder.FindAll(x => x.Guid == pig.MakeOrderGuid && x.Status == 1).FirstOrDefaultAsync();
            var maxPig = await _repo.FindAll(x => x.MakeOrderGuid == order.Guid && x.Status == 1).CountAsync();
            order.OrderAmound = maxPig;
            _repoMakeOrder.Update(order);
        }
        public override async Task<OperationResult> DeleteAsync(object id)
        {
            try
            {
                var item = _repo.FindByID(id);
                item.Status = 0;
                item.CancelFlag = "Y";
                _repo.Update(item);




                await _unitOfWork.SaveChangeAsync();
                if (!string.IsNullOrEmpty(item.MakeOrderGuid))
                {
                    await UpdateMakeOrder(item);
                }
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
        public async Task<object> GetPigs(string farmGuid, int top, int skip, string filter, string selected)
        {
            var selectedData = await _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.Guid == selected).Select(x => new PigDrodownlistDto
            {
                Id = x.Id,
                Guid = x.Guid,
                Name = x.Idno
            }).ToListAsync();

            if (string.IsNullOrEmpty(filter) == true)
            {

                var query = _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1)
                    .OrderBy(x => x.Id)
                    .Skip(skip)
                    .Take(top)
                    .Select(x => new PigDrodownlistDto
                    {
                        Id = x.Id,
                        Guid = x.Guid,
                        Name = x.Idno
                    });

                var data = await query.ToListAsync();
                var list = new List<PigDrodownlistDto>();
                if (skip == 0)
                {
                    var itemNo = new PigDrodownlistDto
                    {
                        Id = 0,
                        Guid = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }
            else
            {
                var query = _repo.FindAll(x => x.Idno.Contains(filter) && x.FarmGuid == farmGuid && x.Status == 1).OrderBy(x => x.Id).Skip(skip).Take(top).Select(x => new PigDrodownlistDto
                {
                    Id = x.Id,
                    Guid = x.Guid,
                    Name = x.Idno
                });

                var data = await query.ToListAsync();
                var list = new List<PigDrodownlistDto>();
                if (skip == 0)
                {
                    var itemNo = new PigDrodownlistDto
                    {
                        Id = 0,
                        Guid = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }


        }

        public async Task<object> GetFarms()
        => await _repoFarm.FindAll(x => x.Status == 1)
        .OrderByDescending(x => x.Id)
        .Select(x => new { x.Guid, Name = x.FarmName })
        .ToListAsync();

        public async Task<object> GetAreas(string farmGuid)
        => await _repoArea.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid)
        .OrderByDescending(x => x.Id)
        .Select(x => new { x.Guid, Name = x.AreaName })
        .ToListAsync();


        public async Task<object> GetBarns(string farmGuid, string areaGuid)
        => await _repoBarn.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid && x.AreaGuid == areaGuid)
        .OrderByDescending(x => x.Id)
        .Select(x => new { x.Guid, Name = x.BarnName })
        .ToListAsync();

        public async Task<object> GetCullingTanks(string farmGuid, string areaGuid)
         => await _repoCullingTank.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid && x.AreaGuid == areaGuid)
        .OrderByDescending(x => x.Id)
        .Select(x => new { x.Guid, Name = x.CullingTankName })
        .ToListAsync();

        public async Task<object> GetRooms(string farmGuid, string areaGuid, string barnGuid)
          => await _repoRoom.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid && x.AreaGuid == areaGuid && x.BarnGuid == barnGuid)
        .OrderByDescending(x => x.Id)
        .Select(x => new { x.Guid, Name = x.RoomName })
        .ToListAsync();

        public async Task<object> GetPens(string farmGuid, string areaGuid, string barnGuid, string roomGuid)
          => await _repoPen.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid && x.AreaGuid == areaGuid && x.BarnGuid == barnGuid && x.RoomGuid == roomGuid)
        .OrderByDescending(x => x.Id)
        .Select(x => new { x.Guid, Name = x.PenName })
        .ToListAsync();
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

        public async Task<object> GetPigByNo(string no)
        {
            return await _repo.FindAll(x => x.Idno == no).FirstOrDefaultAsync();
        }

        public async Task<object> GetPigsByPen(DataManager data, string penGuid, string recordGuid, string type)
        {
            var datasource = _repo.FindAll(x => x.Status == 1 && x.PenGuid == penGuid)
           .OrderByDescending(x => x.Id)
           .Select(x => new
           {
               x.Id,
               Name = x.Idno,
               x.Guid,
               Checked = (from a in _repoRecord2Pig.FindAll() where a.PigGuid == x.Guid && a.RecordGuid == recordGuid select a).First() != null
           });
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

        public async Task<OperationResult> RemoveRecord2Pig(Record2Pig request)
        {
            try
            {
                var ap = await _repoRecord2Pig.FindAll(x => x.RecordGuid == request.RecordGuid && x.Type == request.Type && x.PigGuid == request.PigGuid).FirstOrDefaultAsync();
                _repoRecord2Pig.Remove(ap);
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

        public async Task<OperationResult> AddRecord2Pig(Record2Pig request)
        {
            try
            {

                var item = new Record2Pig
                {
                    RecordGuid = request.RecordGuid,
                    Type = request.Type,
                    PigGuid = request.PigGuid
                };
                _repoRecord2Pig.Add(item);
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
        public async Task<object> GetPigsByPenAndRecord(string penGuid, string recordGuid, string type)
        {
            return await _repoRecord2Pig.FindAll(x => x.RecordGuid == recordGuid && x.Type == type).Select(x => x.PigGuid).ToListAsync();

        }
        public async Task<object> GetSelectedPig(string[] guid, string recordGuid, string type)
        {
            var items = await _repo.FindAll(x => guid.Contains(x.Guid)).Select(x => new
            {
                Guid = x.Guid,
                Name = x.Idno
            }).ToListAsync();
            var model = from a in items
                        join b in _repoRecord2Pig.FindAll(x=> x.Type == type && x.RecordGuid == recordGuid) on a.Guid equals b.PigGuid into ab
                        from c in ab.DefaultIfEmpty()

                        select new {
                        PigGuid = a.Guid,
                        Name = a.Name,
                        RecordValue = c != null ? c.RecordValue: null,
                        RecordWeight = c != null ? c.RecordWeight: null,
                        RecordAmount = c != null ? c.RecordAmount: null,
                        RecordDisease = c != null ? c.RecordDisease: "",
                        RecordDiseaseName = c!= null ? (from  e in _repoDisease.FindAll() where c.RecordDisease == e.Guid select e.DiseaseName ).FirstOrDefault() : "",
                        RecordNext = c != null ? c.RecordNext: "",
                        Id =  c != null ? c.Id: 0,

                        };
            return model;
        }
         public async Task<object> GetSelectedPig(SelectedPigParams p)
        {
            var pigs = p.Pigs;
            var items = await _repo.FindAll(x => pigs.Contains(x.Guid)).Select(x => new
            {
                Guid = x.Guid,
                Name = x.Idno
            }).ToListAsync();
            var model = from a in items
                        join b in _repoRecord2Pig.FindAll(x=> x.RecordGuid == p.RecordGuid) on a.Guid equals b.PigGuid into ab
                        from c in ab.DefaultIfEmpty()

                        select new {
                        PigGuid = a.Guid,
                        Name = a.Name,
                        RecordValue = c != null ? c.RecordValue: null,
                        RecordWeight = c != null ? c.RecordWeight: null,
                        RecordAmount = c != null ? c.RecordAmount: null,
                        RecordDisease = c != null ? c.RecordDisease: "",
                        RecordDiseaseName = c!= null ? (from  e in _repoDisease.FindAll() where c.RecordDisease == e.Guid select e.DiseaseName ).FirstOrDefault() : "",
                        RecordNext = c != null ? c.RecordNext: "",
                        Id =  c != null ? c.Id: 0,

                        };
            return model;
        }

        public async Task<object> GetSelectedPig(string[] guid)
        {
            var items = await _repo.FindAll(x => guid.Contains(x.Guid)).Select(x => new
            {
                Guid = x.Guid,
                Name = x.Idno
            }).ToListAsync();
           
            return items;
        }
        public async Task<object> GetSelectedPigsByRecord(string recordGuid, string type)
        {
            var item = await _repoRecord2Pig.FindAll(x => x.RecordGuid == recordGuid && x.Type == type).Select(x => new { Guid = x.PigGuid }).ToListAsync();
            if (item.Count == 0) return new List<dynamic> { };
            return item;
        }
    }
}
