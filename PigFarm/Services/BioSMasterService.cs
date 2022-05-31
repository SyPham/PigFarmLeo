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
    public interface IBioSMasterService : IServiceBase<BioSMaster, BioSMasterDto>
    {
        Task<object> LoadData(DataManager data, string farmGuid);
        Task<object> LoadData(DataManager data, string farmGuid, string pigType, string lang);
        Task<object> LoadData(DataManager data);
        Task<object> GetOrders(string farmGuid);
        Task<object> GetAudit(object id);

    }
    public class BioSMasterService : ServiceBase<BioSMaster, BioSMasterDto>, IBioSMasterService
    {
        private readonly IRepositoryBase<BioSMaster> _repo;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IRepositoryBase<MakeOrder> _repoMakeOrder;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public BioSMasterService(
            IRepositoryBase<BioSMaster> repo,
            IRepositoryBase<CodeType> repoCodeType,
            IRepositoryBase<MakeOrder> repoMakeOrder,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoCodeType = repoCodeType;
            _repoMakeOrder = repoMakeOrder;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> LoadData(DataManager data, string farmGuid, string pigType, string lang)
        {
            IQueryable<BioSMasterViewDto> datasource =
                (from a in _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.PigType == pigType)

                 join b in _repoMakeOrder.FindAll(x => x.Status == 1) on a.MakeOrderGuid equals b.Guid into gj
                 from c in gj.DefaultIfEmpty()
                 join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Pig_Type && x.Status == "Y") on a.PigType equals b.CodeNo into ab
                 from p in ab.DefaultIfEmpty()
                 select new BioSMasterViewDto
                 {
                     Id = a.Id,
                     FarmGuid = a.FarmGuid,
                     PigType = a.PigType,
                     Comment = a.Comment,
                     CreateBy = a.CreateBy,
                     CreateDate = a.CreateDate,
                     UpdateBy = a.UpdateBy,
                     UpdateDate = a.UpdateDate,
                     DeleteBy = a.DeleteBy,
                     DeleteDate = a.DeleteDate,
                     Status = a.Status,
                     Guid = a.Guid,
                     RecordDate = a.RecordDate,
                     RecordTime = a.RecordTime,
                     MakeOrderGuid = a.MakeOrderGuid,
                     MakeOrderName = c != null ? c.OrderName : "N/A",
                     PigTypeName = p == null ? "" : lang == Languages.EN ? p.CodeNameEn ?? p.CodeName : lang == Languages.VI ? p.CodeNameVn ?? p.CodeName : lang == Languages.CN ? p.CodeNameCn ?? p.CodeName : p.CodeName,

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
        public async Task<object> LoadData(DataManager data, string farmGuid)
        {
            IQueryable<BioSMasterViewDto> datasource =
                (from a in _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1)

                 join b in _repoMakeOrder.FindAll(x => x.Status == 1) on a.MakeOrderGuid equals b.Guid into gj
                 from c in gj.DefaultIfEmpty()

                 select new BioSMasterViewDto
                 {
                     Id = a.Id,
                     FarmGuid = a.FarmGuid,
                     PigType = a.PigType,
                     Comment = a.Comment,
                     CreateBy = a.CreateBy,
                     CreateDate = a.CreateDate,
                     UpdateBy = a.UpdateBy,
                     UpdateDate = a.UpdateDate,
                     DeleteBy = a.DeleteBy,
                     DeleteDate = a.DeleteDate,
                     Status = a.Status,
                     Guid = a.Guid,
                     RecordDate = a.RecordDate,
                     RecordTime = a.RecordTime,
                     MakeOrderGuid = a.MakeOrderGuid,
                     MakeOrderName = c != null ? c.OrderName : "N/A"
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
            IQueryable<BioSMasterDto> datasource = _repo.FindAll(x => x.Status == 1).OrderByDescending(x => x.Id).ProjectTo<BioSMasterDto>(_configMapper);
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
        public override async Task<List<BioSMasterDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<BioSMasterDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(BioSMasterDto model)
        {
            var check = await _repo.FindAll(x => x.Status == 1 && x.PigType == model.PigType && x.MakeOrderGuid == model.MakeOrderGuid).AnyAsync();

            if (check)
                return new OperationResult
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "The pig type or make order already existed!",
                    Success = false,
                    Data = null
                };
            var item = _mapper.Map<BioSMaster>(model);
            item.Status = 1;
            // //item.Guid = Guid.NewGuid().ToString("N") + DateTime.Now.ToString("ssff");

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
        public override async Task<OperationResult> UpdateAsync(BioSMasterDto model)
        {


            var item = await _repo.FindByIDAsync(model.Id);

            if (model.PigType != item.PigType || model.MakeOrderGuid != item.MakeOrderGuid)
            {
                var check = await _repo.FindAll(x => x.Status == 1 && x.PigType == model.PigType && x.MakeOrderGuid == model.MakeOrderGuid).AnyAsync();
                if (check)
                    return new OperationResult
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "The pig type or make order already existed!",
                        Success = false,
                        Data = null
                    };
            }


            item.FarmGuid = model.FarmGuid;
            item.PigType = model.PigType;
            item.Comment = model.Comment;
            item.RecordDate = model.RecordDate;
            item.RecordTime = model.RecordTime;
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

        public async Task<object> GetOrders(string farmGuid)
        {
            var datasource = from a in _repoMakeOrder.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1)
                             select new
                             {
                                 a.Id,
                                 a.Guid,
                                 Name = a.OrderName,
                                 a.OrderNo
                             };
            return await datasource.OrderByDescending(x => x.Id).ToListAsync();
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
