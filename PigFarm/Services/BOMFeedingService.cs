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
    public interface IBomFeedService : IServiceBase<BomFeeding, BomFeedingDto>
    {
        Task<object> LoadData(DataManager data, string bomGuid, string lang);
        Task<object> LoadData(DataManager data);
        Task<object> GetAudit(object id);
    }
    public class BomFeedService : ServiceBase<BomFeeding, BomFeedingDto>, IBomFeedService
    {
        private readonly IRepositoryBase<BomFeeding> _repo;
        private readonly IRepositoryBase<Feed> _repoFeed;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public BomFeedService(
            IRepositoryBase<BomFeeding> repo,
            IRepositoryBase<Feed> repoFeed,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoFeed = repoFeed;
            _repoCodeType = repoCodeType;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> LoadData(DataManager data, string bomGuid, string lang)
        {
            //IQueryable<BomFeedDto> datasource = _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<BomFeedDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Record_Feeding_Type && x.Status == "Y") on a.FeedType equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()

                              join ph1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Feeding_UseType && x.Status == "Y") on a.UseType equals ph1.CodeNo into ph1a
                              from ph in ph1a.DefaultIfEmpty()

                              join fn1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Feeding_Frequency && x.Status == "Y") on a.Frequency equals fn1.CodeNo into fn1a
                              from fn in fn1a.DefaultIfEmpty()

                              join mt1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Feeding_UseUnit && x.Status == "Y") on a.UseUnit equals mt1.CodeNo into mt1a
                              from mt in mt1a.DefaultIfEmpty()

                              join fr1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Feeding_Result && x.Status == "Y") on a.RecordResult equals fr1.CodeNo into fr1a
                              from fr in fr1a.DefaultIfEmpty()

                              join f1 in _repoFeed.FindAll(x => x.Status == 1) on a.FeedGuid equals f1.Guid into f1a
                              from f in f1a.DefaultIfEmpty()
                              select new BomFeedingDto
                              {
                                  Id = a.Id,
                                  BomGuid = a.BomGuid,
                                  FeedType = a.FeedType,
                                  FeedName = a.FeedName,
                                  FeedGuid = a.FeedGuid,
                                  Comment = a.Comment,
                                  CancelFlag = a.CancelFlag,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  UseType = a.UseType,
                                  UseUnit = a.UseUnit,
                                  Frequency = a.Frequency,
                                  RecordAmount = a.RecordAmount,
                                  RecordResult = a.RecordResult,
                                  EstAmount = a.EstAmount,
                                  ApplyDays = a.ApplyDays,
                                  TypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                  FeedGuidName = f == null ? "" : f.FeedName,
                                  RecordResultName = fr == null ? "" : lang == Languages.EN ? fr.CodeNameEn ?? fr.CodeName : lang == Languages.VI ? fr.CodeNameVn ?? fr.CodeName : lang == Languages.CN ? fr.CodeNameCn ?? fr.CodeName : fr.CodeName,
                                  UseUnitName = mt == null ? "" : lang == Languages.EN ? mt.CodeNameEn ?? mt.CodeName : lang == Languages.VI ? mt.CodeNameVn ?? mt.CodeName : lang == Languages.CN ? mt.CodeNameCn ?? mt.CodeName : mt.CodeName,
                                  UseTypeName = ph == null ? "" : lang == Languages.EN ? ph.CodeNameEn ?? ph.CodeName : lang == Languages.VI ? ph.CodeNameVn ?? ph.CodeName : lang == Languages.CN ? ph.CodeNameCn ?? ph.CodeName : ph.CodeName,
                                  FrequencyName = fn == null ? "" : lang == Languages.EN ? fn.CodeNameEn ?? fn.CodeName : lang == Languages.VI ? fn.CodeNameVn ?? fn.CodeName : lang == Languages.CN ? fn.CodeNameCn ?? fn.CodeName : fn.CodeName,


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
        public async Task<object> LoadData(DataManager data)
        {
            IQueryable<BomFeedDto> datasource = _repo.FindAll(x => x.Status == 1).ProjectTo<BomFeedDto>(_configMapper);
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
        public override async Task<List<BomFeedingDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<BomFeedingDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(BomFeedingDto model)
        {
            var item = _mapper.Map<BomFeeding>(model);
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
        public override async Task<OperationResult> UpdateAsync(BomFeedingDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);
            item.BomGuid = model.BomGuid;
            item.FeedType = model.FeedType;
            item.FeedName = model.FeedName;

            item.FeedGuid = model.FeedGuid;
            item.UseType = model.UseType;
            item.UseUnit = model.UseUnit;
            item.Frequency = model.Frequency;
            item.EstAmount = model.EstAmount;
            item.RecordAmount = model.RecordAmount;
            item.RecordResult = model.RecordResult;
           
            item.Comment = model.Comment;

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

        public override async Task<OperationResult> DeleteAsync(object id)
        {
            var item = _repo.FindByID(id);
            item.Status = 0;
            item.CancelFlag = "Y";

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
    }
}
