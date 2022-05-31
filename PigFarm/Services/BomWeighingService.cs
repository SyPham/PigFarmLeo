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

namespace PigFarm.Services
{
    public interface IBomWeighingService : IServiceBase<BomWeighing, BomWeighingDto>
    {
        Task<object> LoadData(DataManager data, string bomGuid, string lang);
        Task<object> GetAudit(object id);
    }
    public class BomWeighingService : ServiceBase<BomWeighing, BomWeighingDto>, IBomWeighingService
    {
        private readonly IRepositoryBase<BomWeighing> _repo;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public BomWeighingService(
            IRepositoryBase<BomWeighing> repo,
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
      
       public async Task<object> LoadData(DataManager data, string bomGuid, string lang)
        {
            //IQueryable<BomWeighingDto> datasource = _repo.FindAll(x => x.BomGuid == bomGuid && x.MakeOrderGuid == makeOrderGuid && x.Status == 1)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<BomWeighingDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Record_Weighing_Type && x.Status == "Y") on a.WeighingType equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()

                              join ph1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Weighing_UseType && x.Status == "Y") on a.UseType equals ph1.CodeNo into ph1a
                              from ph in ph1a.DefaultIfEmpty()

                              join fn1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Weighing_Frequency && x.Status == "Y") on a.Frequency equals fn1.CodeNo into fn1a
                              from fn in fn1a.DefaultIfEmpty()

                              join mt1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Weighing_UseUnit && x.Status == "Y") on a.UseUnit equals mt1.CodeNo into mt1a
                              from mt in mt1a.DefaultIfEmpty()

                         
                              select new BomWeighingDto
                              {
                                  Id = a.Id,
                                  BomGuid = a.BomGuid,
                                  WeighingName = a.WeighingName,
                                  WeighingType = a.WeighingType,
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
                                  ApplyDays = a.ApplyDays,
                                  StandardWeight = a.StandardWeight,
                                  WeighingTypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
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
        }        public override async Task<List<BomWeighingDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<BomWeighingDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(BomWeighingDto model)
        {
            var item = _mapper.Map<BomWeighing>(model);
            item.Status = 1;
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
        public override async Task<OperationResult> UpdateAsync(BomWeighingDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);
            item.BomGuid = model.BomGuid;
            item.WeighingType = model.WeighingType;
            item.WeighingName = model.WeighingName;
            item.Comment = model.Comment;
            item.UseUnit = model.UseUnit;
            item.Frequency = model.Frequency;
            item.UseType = model.UseType;
            item.ApplyDays = model.ApplyDays;
            item.StandardWeight = model.StandardWeight;
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
            var item = await _repo.FindByIDAsync(id);
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

    }
}
