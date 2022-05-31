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
    public interface IBomVectorControlService : IServiceBase<BomVectorControl, BomVectorControlDto>
    {
        Task<object> LoadData(DataManager data);
        Task<object> LoadData(DataManager data, string bomGuid, string lang);
        Task<object> GetAudit(object id);
    }
    public class BomVectorControlService : ServiceBase<BomVectorControl, BomVectorControlDto>, IBomVectorControlService
    {
        private readonly IRepositoryBase<BomVectorControl> _repo;
        private readonly IRepositoryBase<VectorControl> _repoVectorControl;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public BomVectorControlService(
            IRepositoryBase<BomVectorControl> repo,
            IRepositoryBase<VectorControl> repoVectorControl,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoVectorControl = repoVectorControl;
            _repoCodeType = repoCodeType;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> LoadData(DataManager data, string bomGuid, string lang)
        {
            //IQueryable<BomVectorControlDto> datasource = _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<BomVectorControlDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
                              join b1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.BOM_Vector_Control_Type && x.Status == "Y") on a.VectorControlType equals b1.CodeNo into ab1
                              from v in ab1.DefaultIfEmpty()
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.VectorControl_UseType && x.Status == "Y") on a.UseType equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()
                              join e1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.VectorControl_UseUnit && x.Status == "Y") on a.UseUnit equals e1.CodeNo into ae1
                              from e in ae1.DefaultIfEmpty()

                              join g1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.VectorControl_Capacity && x.Status == "Y") on a.Capacity equals g1.CodeNo into ag1
                              from g in ag1.DefaultIfEmpty()

                              join h1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.VectorControl_Frequency && x.Status == "Y") on a.Frequency equals h1.CodeNo into ah1
                              from h in ah1.DefaultIfEmpty()

                              join k1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.VectorControl_ApplyDays && x.Status == "Y") on a.ApplyDays equals k1.CodeNo into ak1
                              from k in ak1.DefaultIfEmpty()

                              join c in _repoVectorControl.FindAll(x =>  x.Status == 1) on a.VectorControlGuid equals c.Guid into cn
                              from n in cn.DefaultIfEmpty()
                              select new BomVectorControlDto
                              {
                                  Id = a.Id,
                                  BomGuid = a.BomGuid,
                                  VectorControlType = a.VectorControlType,
                                  VectorControlName = a.VectorControlName,
                                  CancelFlag = a.CancelFlag,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  UseType = a.UseType,
                                  UseUnit = a.UseUnit,
                                  Capacity = a.Capacity,
                                  Frequency = a.Frequency,
                                  ApplyDays = a.ApplyDays,
                                  VectorControlGuidName = n == null ? "" :n.VectorControlName,
                                  UseTypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,
                                  UseUnitName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,
                                  CapacityName = g == null ? "" : lang == Languages.EN ? g.CodeNameEn ?? g.CodeName : lang == Languages.VI ? g.CodeNameVn ?? g.CodeName : lang == Languages.CN ? g.CodeNameCn ?? g.CodeName : g.CodeName,
                                  FrequencyName = h == null ? "" : lang == Languages.EN ? h.CodeNameEn ?? h.CodeName : lang == Languages.VI ? h.CodeNameVn ?? h.CodeName : lang == Languages.CN ? h.CodeNameCn ?? h.CodeName : h.CodeName,
                                  ApplyDaysName = k == null ? "" : lang == Languages.EN ? k.CodeNameEn ?? k.CodeName : lang == Languages.VI ? k.CodeNameVn ?? k.CodeName : lang == Languages.CN ? k.CodeNameCn ?? k.CodeName : k.CodeName,
                                  VectorControlTypeName = v == null ? "" : lang == Languages.EN ? v.CodeNameEn ?? v.CodeName : lang == Languages.VI ? v.CodeNameVn ?? v.CodeName : lang == Languages.CN ? v.CodeNameCn ?? v.CodeName : v.CodeName,

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
            IQueryable<BomVectorControlDto> datasource = _repo.FindAll(x => x.Status == 1).ProjectTo<BomVectorControlDto>(_configMapper);
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
        public override async Task<List<BomVectorControlDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<BomVectorControlDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(BomVectorControlDto model)
        {
            var item = _mapper.Map<BomVectorControl>(model);
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
        public override async Task<OperationResult> UpdateAsync(BomVectorControlDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);
            item.BomGuid = model.BomGuid;
            item.VectorControlType = model.VectorControlType;
            item.VectorControlName = model.VectorControlName;
            item.VectorControlGuid = model.VectorControlGuid;
            item.UseType = model.UseType;
            item.UseUnit = model.UseUnit;
            item.Capacity = model.Capacity;
            item.Frequency = model.Frequency;
            item.ApplyDays = model.ApplyDays;
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
