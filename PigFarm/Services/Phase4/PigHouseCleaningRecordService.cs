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
namespace PigFarm.Services
{
    public interface IPigHouseCleaningRecordService : IServiceBase<PigHouseCleaningRecord, PigHouseCleaningRecordDto>
    {
        Task<object> LoadData(DataManager data, string upperGuid, string lang);
        Task<object> LoadData(DataManager data, string lang);
        Task<object> GetAudit(object id);
Task<OperationResult> ToggleRecordDate(object id);
    }
    public class PigHouseCleaningRecordService : ServiceBase<PigHouseCleaningRecord, PigHouseCleaningRecordDto>, IPigHouseCleaningRecordService
    {
        private readonly IRepositoryBase<PigHouseCleaningRecord> _repo;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public PigHouseCleaningRecordService(
            IRepositoryBase<PigHouseCleaningRecord> repo,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoCodeType = repoCodeType;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
         public async Task<object> LoadData(DataManager data, string upperGuid, string lang)
        {
            //IQueryable<PigHouseCleaningRecordDto> datasource = _repo.FindAll(x => x.Status == 1 && x.UpperGuid == upperGuid)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<PigHouseCleaningRecordDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.Status == 1 && x.UpperGuid == upperGuid)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Cleaning_Record_Type && x.Status == "Y") on a.Type equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()

                              select new PigHouseCleaningRecordDto
                              {
                                  Id = a.Id,
                                  Type = a.Type,
                                  UpperGuid = a.UpperGuid,
                                  RecordDate = a.RecordDate,
                                  RecordTime = a.RecordTime,
                                  CleaningRecord = a.CleaningRecord,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  TypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
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
        public async Task<object> LoadData(DataManager data, string lang)
        {
            //IQueryable<PigHouseCleaningRecordDto> datasource = _repo.FindAll(x => x.Status == 1 && x.UpperGuid == upperGuid)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<PigHouseCleaningRecordDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.Status == 1)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Cleaning_Record_Type && x.Status == "Y") on a.Type equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()

                              select new PigHouseCleaningRecordDto
                              {
                                  Id = a.Id,
                                  Type = a.Type,
                                  UpperGuid = a.UpperGuid,
                                  RecordDate = a.RecordDate,
                                  RecordTime = a.RecordTime,
                                  CleaningRecord = a.CleaningRecord,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  TypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
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
        public override async Task<List<PigHouseCleaningRecordDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<PigHouseCleaningRecordDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }

        public override async Task<OperationResult> AddAsync(PigHouseCleaningRecordDto model)
        {
            var item = _mapper.Map<PigHouseCleaningRecord>(model);

            item.Status = 1;
            //item.Guid = Guid.NewGuid().ToString("N") + DateTime.Now.ToString("ssff");

            _repo.Add(item);
            try
            {
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
        public override async Task<OperationResult> DeleteAsync(object id)
        {
            var item = _repo.FindByID(id);
            item.Status = 0;
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
        public async Task<object> GetAudit(object id)
        {
            var data = await _repo.FindAll(x => x.Id.Equals(id)).AsNoTracking().Select(x=> new {x.UpdateBy, x.CreateBy, x.UpdateDate, x.CreateDate }).FirstOrDefaultAsync();
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
                var updateAudit = await _repoXAccount.FindAll(x => x.AccountId == data.UpdateBy).AsNoTracking().Select(x=> new { x.Uid }).FirstOrDefaultAsync();
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
             if (!item.RecordDate.HasValue && string.IsNullOrEmpty(item.RecordTime)) {
                item.RecordDate = DateTime.Now;
                item.RecordTime = DateTime.Now.ToString("HH:mm");
             } else {
                item.RecordDate = null;
                item.RecordTime = null;
             }

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
    }
}
