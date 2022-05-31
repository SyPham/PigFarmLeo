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
    public interface IPigTreatmentService : IServiceBase<PigTreatment, PigTreatmentDto>
    {
        Task<object> LoadData(DataManager data, string farmGuid, string lang, string penGuid, string pigGuid, DateTime? estDate);
        Task<object> LoadData(DataManager data, string upperGuid, string lang);
        Task<object> LoadData(DataManager data, string lang);
        Task<object> GetAudit(object id);
        Task<OperationResult> ToggleRecordDate(object id);
        Task<OperationResult> ToggleEstDate(object id);
    }
    public class PigTreatmentService : ServiceBase<PigTreatment, PigTreatmentDto>, IPigTreatmentService
    {
        private readonly IRepositoryBase<PigTreatment> _repo;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public PigTreatmentService(
            IRepositoryBase<PigTreatment> repo,
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
            //IQueryable<PigTreatmentDto> datasource = _repo.FindAll(x => x.Status == 1 && x.UpperGuid == upperGuid)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<PigTreatmentDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.Status == 1 && x.UpperGuid == upperGuid)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Treatment_Type && x.Status == "Y") on a.Type equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()

                              select new PigTreatmentDto
                              {
                                  Id = a.Id,
                                  Type = a.Type,
                                  UpperGuid = a.UpperGuid,
                                  RecordDate = a.RecordDate,
                                  RecordTime = a.RecordTime,
                                  EstDate = a.EstDate,
                                  EstTime = a.EstTime,
                                  Treatment = a.Treatment,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  PigGuid = a.PigGuid,
                                  PenGuid = a.PenGuid,
                                  FarmGuid = a.FarmGuid,
                                  CullingPenGuid = a.CullingPenGuid,
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
            //IQueryable<PigTreatmentDto> datasource = _repo.FindAll(x => x.Status == 1 && x.UpperGuid == upperGuid)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<PigTreatmentDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.Status == 1)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Treatment_Type && x.Status == "Y") on a.Type equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()

                              select new PigTreatmentDto
                              {
                                  Id = a.Id,
                                  Type = a.Type,
                                  UpperGuid = a.UpperGuid,
                                  RecordDate = a.RecordDate,
                                  RecordTime = a.RecordTime,
                                  EstDate = a.EstDate,
                                  EstTime = a.EstTime,
                                  Treatment = a.Treatment,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  PigGuid = a.PigGuid,
                                  PenGuid = a.PenGuid,
                                  FarmGuid = a.FarmGuid,
                                  CullingPenGuid = a.CullingPenGuid,
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

        public override async Task<List<PigTreatmentDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<PigTreatmentDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }

        public override async Task<OperationResult> AddAsync(PigTreatmentDto model)
        {
            var item = _mapper.Map<PigTreatment>(model);

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
            if (!item.RecordDate.HasValue && string.IsNullOrEmpty(item.RecordTime))
            {
                item.RecordDate = DateTime.Now;
                item.RecordTime = DateTime.Now.ToString("HH:mm");
            }
            else
            {
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
        public async Task<OperationResult> ToggleEstDate(object id)
        {
            var item = await _repo.FindByIDAsync(id);
            if (!item.EstDate.HasValue && string.IsNullOrEmpty(item.EstTime))
            {
                item.EstDate = DateTime.Now;
                item.EstTime = DateTime.Now.ToString("HH:mm");
            }
            else
            {
                item.EstDate = null;
                item.EstTime = null;
            }

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
        private IQueryable<PigTreatmentDto> Datasource(string farmGuid, string lang)
        {
           return (from a in _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid)
                          join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Treatment_Type && x.Status == "Y") on a.Type equals b.CodeNo into ab
                          from t in ab.DefaultIfEmpty()

                          select new PigTreatmentDto
                          {
                              Id = a.Id,
                              Type = a.Type,
                              UpperGuid = a.UpperGuid,
                              RecordDate = a.RecordDate,
                              RecordTime = a.RecordTime,
                              EstDate = a.EstDate,
                              EstTime = a.EstTime,
                              Treatment = a.Treatment,
                              Comment = a.Comment,
                              CreateDate = a.CreateDate,
                              CreateBy = a.CreateBy,
                              UpdateDate = a.UpdateDate,
                              UpdateBy = a.UpdateBy,
                              Status = a.Status,
                              Guid = a.Guid,
                              PigGuid = a.PigGuid,
                              PenGuid = a.PenGuid,
                              FarmGuid = a.FarmGuid,
                                  CullingPenGuid = a.CullingPenGuid,
                              TypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                          }).OrderByDescending(x => x.Id).AsQueryable();
        }
        public async Task<object> LoadData(DataManager data, string farmGuid, string lang, string penGuid, string pigGuid, DateTime? estDate)
        {
            IQueryable<PigTreatmentDto> datasource = Datasource(farmGuid, lang);
            if (string.IsNullOrEmpty(penGuid) && string.IsNullOrEmpty(pigGuid) && !estDate.HasValue)
            {
            }
            else if (string.IsNullOrEmpty(penGuid) && !string.IsNullOrEmpty(pigGuid) && estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.PigGuid == pigGuid && a.EstDate == estDate).OrderByDescending(x => x.Id).AsQueryable();
            }
            else if (!string.IsNullOrEmpty(penGuid) && string.IsNullOrEmpty(pigGuid) && estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.PenGuid == penGuid && a.EstDate == estDate).OrderByDescending(x => x.Id).AsQueryable();
            }
            else if (!string.IsNullOrEmpty(penGuid) && !string.IsNullOrEmpty(pigGuid) && !estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.PenGuid == penGuid && a.PigGuid == pigGuid).OrderByDescending(x => x.Id).AsQueryable();

            }
            else if (!string.IsNullOrEmpty(penGuid) && !string.IsNullOrEmpty(pigGuid) && estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.PenGuid == penGuid && a.PigGuid == pigGuid && a.EstDate == estDate).OrderByDescending(x => x.Id).AsQueryable();

            }
            else if (!string.IsNullOrEmpty(penGuid) && string.IsNullOrEmpty(pigGuid) && !estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.PenGuid == penGuid).OrderByDescending(x => x.Id).AsQueryable();

               
            }
            else if (string.IsNullOrEmpty(penGuid) && !string.IsNullOrEmpty(pigGuid) && !estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.PigGuid == pigGuid ).OrderByDescending(x => x.Id).AsQueryable();

            }
            else if (string.IsNullOrEmpty(penGuid) && string.IsNullOrEmpty(pigGuid) && estDate.HasValue)
            {
                datasource = Datasource(farmGuid, lang).Where(a => a.EstDate == estDate).OrderByDescending(x => x.Id).AsQueryable();

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


    }
}
