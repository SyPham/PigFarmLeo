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
    public interface IBomMoveService : IServiceBase<BomMove, BomMoveDto>
    {
        Task<object> LoadData(DataManager data);
        Task<object> LoadData(DataManager data, string bomGuid, string lang);
        Task<object> GetAudit(object id);
    }
    public class BomMoveService : ServiceBase<BomMove, BomMoveDto>, IBomMoveService
    {
        private readonly IRepositoryBase<BomMove> _repo;
        private readonly IRepositoryBase<Pen> _repoPen;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public BomMoveService(
            IRepositoryBase<BomMove> repo,
            IRepositoryBase<Pen> repoPen,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoPen = repoPen;
            _repoCodeType = repoCodeType;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> LoadData(DataManager data, string bomGuid, string lang)
        {
            //IQueryable<BomMoveDto> datasource = _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<BomMoveDto>(_configMapper);

            var datasource = (from a in _repo.FindAll(x => x.BomGuid == bomGuid && x.Status == 1)
                              join bf1 in _repoPen.FindAll(x => x.Status == 1) on a.BeforePenGuid equals bf1.Guid into abf1
                              from bf in abf1.DefaultIfEmpty()
                              join af1 in _repoPen.FindAll(x => x.Status == 1) on a.AfterPenGuid equals af1.Guid into aaf1
                              from af in aaf1.DefaultIfEmpty()
                            
                              join c in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Move_Type && x.Status == "Y") on a.MoveType equals c.CodeNo into ac
                              from p in ac.DefaultIfEmpty()
                              join d1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Status && x.Status == "Y") on a.PigStatus equals d1.CodeNo into ad1
                              from d in ad1.DefaultIfEmpty()
                              join e1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Move_InOut && x.Status == "Y") on a.MoveInOut equals e1.CodeNo into ae1
                              from e in ae1.DefaultIfEmpty()
                            //   join f1 in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Move_ApplyDays && x.Status == "Y") on a.ApplyDays equals f1.CodeNo into af1
                            //   from f in af1.DefaultIfEmpty()
                              select new BomMoveDto
                              {
                                  Id = a.Id,
                                  BomGuid = a.BomGuid,
                                  MoveNo = a.MoveNo,
                                  MoveName = a.MoveName,
                                  Comment = a.Comment,
                                  CreateDate = a.CreateDate,
                                  CancelFlag = a.CancelFlag,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                
                                  BeforePenGuid = a.BeforePenGuid,
                                  AfterPenGuid = a.AfterPenGuid,
                                  MoveInOut = a.MoveInOut,
                                  PigStatus = a.PigStatus,
                                  MoveType = a.MoveType,
                                  ApplyDays = a.ApplyDays,
                                  BeforePenName = bf == null ? "" : bf.PenName,
                                  AfterPenName = af == null ? "" : af.PenName,
                                  MoveTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,
                                  PigStatusName = d == null ? "" : lang == Languages.EN ? d.CodeNameEn ?? d.CodeName : lang == Languages.VI ? d.CodeNameVn ?? d.CodeName : lang == Languages.CN ? d.CodeNameCn ?? d.CodeName : d.CodeName,
                                  MoveInOutName = e == null ? "" : lang == Languages.EN ? e.CodeNameEn ?? e.CodeName : lang == Languages.VI ? e.CodeNameVn ?? e.CodeName : lang == Languages.CN ? e.CodeNameCn ?? e.CodeName : e.CodeName,
                                //   ApplyDaysName = f == null ? "" : lang == Languages.EN ? f.CodeNameEn ?? f.CodeName : lang == Languages.VI ? f.CodeNameVn ?? f.CodeName : lang == Languages.CN ? f.CodeNameCn ?? f.CodeName : f.CodeName,
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
            IQueryable<BomMoveDto> datasource = _repo.FindAll(x => x.Status == 1).ProjectTo<BomMoveDto>(_configMapper);
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
        public override async Task<List<BomMoveDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<BomMoveDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(BomMoveDto model)
        {
            var item = _mapper.Map<BomMove>(model);
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
        public override async Task<OperationResult> UpdateAsync(BomMoveDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);
            item.BomGuid = model.BomGuid;
            item.MoveNo = model.MoveNo;
            item.MoveName = model.MoveName;
            item.BeforePenGuid = model.BeforePenGuid;
            item.AfterPenGuid = model.AfterPenGuid;
            item.PigStatus = model.PigStatus;
            item.MoveType = model.MoveType;
            item.MoveInOut = model.MoveInOut;
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
