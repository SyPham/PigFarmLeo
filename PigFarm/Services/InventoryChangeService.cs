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
    public interface IInventoryChangeService : IServiceBase<InventoryChange, InventoryChangeDto>
    {
        Task<object> LoadData(DataManager data, string farmGuid);
        Task<object> LoadChangeThingData(DataManager data, string farmGuid, string fromInventoryGuid);
        Task<object> LoadChangeMaterialData(DataManager data, string farmGuid, string fromInventoryGuid);
        Task<object> GetAudit(object id);
    }
    public class InventoryChangeService : ServiceBase<InventoryChange, InventoryChangeDto>, IInventoryChangeService
    {
        private readonly IRepositoryBase<InventoryChange> _repo;
        private readonly IRepositoryBase<Inventory> _repoInventory;
        private readonly IRepositoryBase<Thing> _repoThing;
        private readonly IRepositoryBase<Material> _repoMaterial;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public InventoryChangeService(
            IRepositoryBase<InventoryChange> repo,
            IRepositoryBase<Inventory> repoInventory,
            IRepositoryBase<Thing> repoThing,
            IRepositoryBase<Material> repoMaterial,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoInventory = repoInventory;
            _repoThing = repoThing;
            _repoMaterial = repoMaterial;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }

        public async Task<object> LoadChangeMaterialData(DataManager data, string farmGuid, string fromInventoryGuid)
        {
            IQueryable<InventoryChangeDto> datasource = from a in _repo.FindAll(x => x.FromInventoryGuid == fromInventoryGuid && x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking().OrderByDescending(x => x.Id)
                                                        join d in _repoMaterial.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking() on a.MaterialGuid equals d.Guid 
                                                        join c in _repoInventory.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking() on a.ToInventoryGuid equals c.Guid
                                                        select new InventoryChangeDto
                                                        {
                                                            Id = a.Id,
                                                            FarmGuid = a.FarmGuid,
                                                            ChangeGuid = a.ChangeGuid,
                                                            ThingGuid = a.ThingGuid,
                                                            MaterialGuid = a.MaterialGuid,
                                                            ChangeDate = a.ChangeDate,
                                                            ChangeTime = a.ChangeTime,
                                                            FromInventoryGuid = a.FromInventoryGuid,
                                                            ToInventoryGuid = a.ToInventoryGuid,
                                                            Comment = a.Comment,
                                                            CancelFlag = a.CancelFlag,
                                                            CreateDate = a.CreateDate,
                                                            CreateBy = a.CreateBy,
                                                            UpdateDate = a.UpdateDate,
                                                            UpdateBy = a.UpdateBy,
                                                            Status = a.Status,
                                                            Guid = a.Guid,
                                                            Material = d.Spec,
                                                            ToInventory = c.InventoryName,
                                                            Type = a.Type,
                                                            InventoryGuid = a.InventoryGuid,
                                                            InventoryType = a.InventoryType,
                                                            OriginalAmount = a.OriginalAmount,
                                                            InventoryAmount = a.InventoryAmount,
                                                        };


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


        public async Task<object> LoadChangeThingData(DataManager data, string farmGuid, string fromInventoryGuid)
        {
            IQueryable<InventoryChangeDto> datasource = from a in _repo.FindAll(x => x.FromInventoryGuid == fromInventoryGuid && x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking().OrderByDescending(x => x.Id)
                                                        join b in _repoThing.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking() on a.ThingGuid equals b.Guid
                                                        join c in _repoInventory.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking() on a.ToInventoryGuid equals c.Guid
                                                        select new InventoryChangeDto
                                                        {
                                                            Id = a.Id,
                                                            FarmGuid = a.FarmGuid,
                                                            ChangeGuid = a.ChangeGuid,
                                                            ThingGuid = a.ThingGuid,
                                                            MaterialGuid = a.MaterialGuid,
                                                            ChangeDate = a.ChangeDate,
                                                            ChangeTime = a.ChangeTime,
                                                            FromInventoryGuid = a.FromInventoryGuid,
                                                            ToInventoryGuid = a.ToInventoryGuid,
                                                            Comment = a.Comment,
                                                            CancelFlag = a.CancelFlag,
                                                            CreateDate = a.CreateDate,
                                                            CreateBy = a.CreateBy,
                                                            UpdateDate = a.UpdateDate,
                                                            UpdateBy = a.UpdateBy,
                                                            Status = a.Status,
                                                            Guid = a.Guid,
                                                            Thing = b.Spec,
                                                            ToInventory = c.InventoryName,
                                                            Type = a.Type,
                                                            InventoryGuid = a.InventoryGuid,
                                                            InventoryType = a.InventoryType,
                                                            OriginalAmount = a.OriginalAmount,
                                                            InventoryAmount = a.InventoryAmount,
                                                        };


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
            IQueryable<InventoryChangeDto> datasource = from a in _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking().OrderByDescending(x => x.Id)
                                                        join b in _repoThing.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking() on a.ThingGuid equals b.Guid into ab
                                                        from c in ab.DefaultIfEmpty()
                                                        join d in _repoMaterial.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid).AsNoTracking() on a.MaterialGuid equals d.Guid into de
                                                        from e in de.DefaultIfEmpty()
                                                        select new InventoryChangeDto
                                                        {
                                                            Id = a.Id,
                                                            FarmGuid = a.FarmGuid,
                                                            ChangeGuid = a.ChangeGuid,
                                                            ThingGuid = a.ThingGuid,
                                                            MaterialGuid = a.MaterialGuid,
                                                            ChangeDate = a.ChangeDate,
                                                            ChangeTime = a.ChangeTime,
                                                            FromInventoryGuid = a.FromInventoryGuid,
                                                            ToInventoryGuid = a.ToInventoryGuid,
                                                            Comment = a.Comment,
                                                            CancelFlag = a.CancelFlag,
                                                            CreateDate = a.CreateDate,
                                                            CreateBy = a.CreateBy,
                                                            UpdateDate = a.UpdateDate,
                                                            UpdateBy = a.UpdateBy,
                                                            Status = a.Status,
                                                            Guid = a.Guid,
                                                            Thing = c != null ? c.Spec : "N/A",
                                                            Material = e != null ? e.Spec : "N/A",
                                                            Type = a.Type,
                                                            InventoryGuid = a.InventoryGuid,
                                                            InventoryType = a.InventoryType,
                                                            OriginalAmount = a.OriginalAmount,
                                                            InventoryAmount = a.InventoryAmount,
                                                        };


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

        public override async Task<List<InventoryChangeDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<InventoryChangeDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(InventoryChangeDto model)
        {
            var item = _mapper.Map<InventoryChange>(model);
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

        public override async Task<OperationResult> DeleteAsync(object id)
        {
            var item = await _repo.FindByIDAsync(id);
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
