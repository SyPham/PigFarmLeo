using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetUtility;
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

namespace PigFarm.Services
{
    public interface IFarmService : IServiceBase<Farm, FarmDto>
    {
        Task<object> GetFarms(int top, int skip, string filter, string selected);
        Task<object> LoadData(DataManager data, string farmGuid);
        Task<object> GetFarmsByAccount();
        Task<object> GetFarms();
        Task<object> GetAudit(object id);
    }
    public class FarmService : ServiceBase<Farm, FarmDto>, IFarmService
    {
        private readonly IRepositoryBase<Farm> _repo;
        private readonly IRepositoryBase<XAccountGroup> _repoXAccountGroup;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FarmService(
            IRepositoryBase<Farm> repo,
            IRepositoryBase<XAccountGroup> repoXAccountGroup,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper,
            IHttpContextAccessor httpContextAccessor
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoXAccountGroup = repoXAccountGroup;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<object> GetDataDropdownlist(DataManager data)
        {
            var datasource = _repo.FindAll().Select(x => new
            {
                Id = x.Id,
                Guid = x.Guid,

                Name = x.FarmName,
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
            return await datasource.ToListAsync();
        }

        public async Task<object> GetFarms(int top, int skip, string filter, string selected)
        {
            var selectedData = await _repo.FindAll(x => x.Status == 1 && x.Guid == selected).Select(x => new
            {
                x.Id,
                x.Guid,
                Name = x.FarmName
            }).ToListAsync();

            if (string.IsNullOrEmpty(filter) == true)
            {

                var query = _repo.FindAll(x => x.Status == 1)
                    .OrderBy(x => x.Id)
                    .Skip(skip)
                    .Take(top)
                    .Select(x => new
                    {
                        x.Id,
                        x.Guid,
                        Name = x.FarmName
                    });

                var data = await query.ToListAsync();
                return data.Union(selectedData).ToList();
            }
            else
            {
                var query = _repo.FindAll(x => x.FarmName.Contains(filter) && x.Status == 1).OrderBy(x => x.Id).Skip(skip).Take(top).Select(x => new
                {
                    x.Id,
                    x.Guid,
                    Name = x.FarmName
                });

                var data = await query.ToListAsync();
                return data.Union(selectedData).ToList();
            }


        }

        public async Task<OperationResult> CheckExistNo(string farmNo)
        {
            var item = await _repo.FindAll(x => x.FarmNo == farmNo && x.Status == 1).AnyAsync();
            if (item)
            {
                return new OperationResult { StatusCode = HttpStatusCode.OK, Message = "The Farm NO already existed!", Success = false };
            }
            operationResult = new OperationResult
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Data = item
            };
            return operationResult;
        }
        public override async Task<OperationResult> AddAsync(FarmDto model)
        {
            try
            {
                var checkFarmNo = await CheckExistNo(model.FarmNo);
                if (!checkFarmNo.Success) return checkFarmNo;
                var item = _mapper.Map<Farm>(model);
                item.Status = 1;
                //  //item.Guid = Guid.NewGuid().ToString("N") + DateTime.Now.ToString("ssff");
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

        public override async Task<OperationResult> UpdateAsync(FarmDto model)
        {
            var itemQuery = await _repo.FindAll(x => x.Id == model.Id && x.Status == 1).FirstOrDefaultAsync();
            var item = _mapper.Map<Farm>(itemQuery);
             if (item.FarmNo != model.FarmNo)
            {
                var checkFarmNo = await CheckExistNo(model.FarmNo);
                if (!checkFarmNo.Success) return checkFarmNo;
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
        public override async Task<List<FarmDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<FarmDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> DeleteAsync(object id)
        {
            var item = _repo.FindByID(id);
            item.CancelFlag = "Y";
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
        public async Task<object> LoadData(DataManager data, string farmGuid)
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var accountID = JWTExtensions.GetDecodeTokenByID(accessToken).ToDecimal();
            var query = await (from x in _repoXAccount.FindAll(x => x.Status == "1" && x.AccountId == accountID).AsNoTracking()
                               join b in _repoXAccountGroup.FindAll() on x.AccountGroup equals b.Guid into gj
                               from emp in gj.DefaultIfEmpty()
                               select new
                               {
                                   emp.GroupNo
                               }).FirstOrDefaultAsync();
            IQueryable<Farm2Dto> datasource = null;
            if (!string.IsNullOrEmpty(farmGuid) && query != null && query.GroupNo == "ADMIN")
            {
                datasource = _repo.FindAll(x => x.Status == 1).Select(x => new Farm2Dto
                {
                    Id = x.Id,
                    FarmName = x.FarmName,
                    FarmNo = x.FarmNo,
                    Guid = x.Guid
                }).OrderByDescending(x => x.Id);

            }
            else
            {
                datasource = _repo.FindAll(x => x.Status == 1 && x.Guid == farmGuid).Select(x => new Farm2Dto
                {
                    Id = x.Id,
                    FarmName = x.FarmName,
                    FarmNo = x.FarmNo,
                    Guid = x.Guid
                }).OrderByDescending(x => x.Id);
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

        public async Task<object> GetFarmsByAccount()
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            int accountID = JWTExtensions.GetDecodeTokenByID(accessToken);


            var account = await _repoXAccount.FindAll(x => x.AccountId == accountID).Select(x => new { x.FarmGuid, x.AccountGroup }).FirstOrDefaultAsync();
            if (account == null)
                return new List<dynamic>();

            var group = await _repoXAccountGroup.FindAll(x => x.Guid == account.AccountGroup).Select(x => new { x.GroupNo }).FirstOrDefaultAsync();

            if (group.GroupNo == SystemAccountGroup.Admin)
            {
                var datasource = await _repo.FindAll(x => x.Status == 1).Select(x => new
                {
                    x.Id,
                    x.FarmName,
                    x.Guid
                }).ToListAsync();
                return datasource;
            }
            else
            {
                if (account.FarmGuid == null)
                    return new List<dynamic>();
                var datasource = await _repo.FindAll(x => x.Status == 1 && x.Guid == account.FarmGuid).Select(x => new
                {
                    x.Id,
                    x.FarmName,
                    x.Guid
                }).ToListAsync();
                return datasource;
            }

        }
        public async Task<object> GetFarms()
        {
            var datasource = await _repo.FindAll(x => x.Status == 1).Select(x => new
            {
                x.Id,
                x.FarmName,
                x.Guid
            }).ToListAsync();
            return datasource;
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
