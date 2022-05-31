using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
    public interface IPenService : IServiceBase<Pen, PenDto>
    {
        Task<object> GetPens(string farmGuid, int top, int skip, string filter, string selected);
        Task<object> GetPensMultiDropdowns(string farmGuid, string roomGuid, int top, int skip, string filter, string selected);
        Task<object> GetPens(string farmGuid);
        Task<object> LoadData(DataManager data, string roomGuid, string makeOrderGuid);
        Task<object> LoadData(DataManager data, string farmGuid, string areaGuid, string barnGuid, string roomGuid);
        Task<object> GetAudit(object id);
        Task<OperationResult> MapMakeOrderToPen(MapMakeOrderToPenDto request);
        Task<object> GetPenByMakeOrderGuid(string makeOrderGuid);
        Task<object> GetPenByRecord(string recordGuid, string type);

        Task<OperationResult> RemoveRecord2Pen(Record2Pen request);
        Task<OperationResult> AddRecord2Pen(Record2Pen request);
        Task<object> GetSelectedPen(string[] guid);
        Task<object> GetPensByRoomAndRecord(string roomGuid, string recordGuid, string type);
        Task<object> GetPensByFarmGuidAndRoomGuid(string farmGuid, string roomGuid);
    }
    public class PenService : ServiceBase<Pen, PenDto>, IPenService
    {
        private readonly IRepositoryBase<Pen> _repo;
        private readonly IRepositoryBase<Record2Pen> _repoRecord2Pen;
        private readonly IRepositoryBase<MakeOrder2Pen> _repoMakeOrder2Pen;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IRepositoryBase<MakeOrder> _repoMakeOrder;
        private readonly IRepositoryBase<Pig> _repoPig;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        private readonly PigFarmContext _context;
        private readonly IConfiguration _configuration;

        public PenService(
            IRepositoryBase<Pen> repo,
            IRepositoryBase<Record2Pen> repoRecord2Pen,
            IRepositoryBase<MakeOrder2Pen> repoMakeOrder2Pen,
            IRepositoryBase<XAccount> repoXAccount,
            IRepositoryBase<MakeOrder> repoMakeOrder,
            IRepositoryBase<Pig> repoPig,
            PigFarmContext context,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper,
            IConfiguration configuration
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _context = context;
            _repoRecord2Pen = repoRecord2Pen;
            _repoMakeOrder2Pen = repoMakeOrder2Pen;
            _repoXAccount = repoXAccount;
            _repoMakeOrder = repoMakeOrder;
            _repoPig = repoPig;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
            _configuration = configuration;
        }
         public async Task<object> GetPensByFarmGuidAndRoomGuid(string farmGuid, string roomGuid) {
              using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                string sql = "SP_GetPensByFarmGuidAndRoomGuid";
                var parameters = new { @Farm_GUID = farmGuid, @Room_GUID = roomGuid };
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
        public override async Task<OperationResult> AddAsync(PenDto model)
        {
            try
            {
                var item = _mapper.Map<Pen>(model);
                item.Status = 1;
                //item.Guid = Guid.NewGuid().ToString("N") + DateTime.Now.ToString("ssff").ToUpper();


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
        public override async Task<List<PenDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<PenDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }

        public override async Task<object> GetDataDropdownlist(DataManager data)
        {
            var datasource = _repo.FindAll().AsQueryable();

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
                 var results = await datasource.Select(x => new
                {
                    Guid = x.Guid,
                    Name = $"{x.PenNo} - {x.PenName} ({(from a in _repoPig.FindAll() where a.Status == 1 && a.PenGuid == x.Guid select a.Id).Count()})" 
                }).ToListAsync();
            if (data.Skip == 0)
            {
               var itemNo = new
                {
                    Guid = "",
                    Name = "No Item",
                };
                results.Insert(0, itemNo);
                return results;
            }
            return results;
        }
        public async Task<object> GetPensMultiDropdowns(string farmGuid, string roomGuid, int top, int skip, string filter, string selected)
        {
            top = top > 0 ? top : 10;
            var pens = JsonConvert.DeserializeObject<List<string>>(selected);
            if (pens == null)
                pens = new List<string> { };
            var selectedData = await _repo.FindAll(x => x.FarmGuid == farmGuid && x.RoomGuid == roomGuid && x.Status == 1 && pens.Contains(x.Guid)).Select(x => new
            {
                x.Id,
                x.Guid,
                x.PenNo,
                Name = $"{x.PenNo} - {x.PenName}"
            }).ToListAsync();

            if (string.IsNullOrEmpty(filter) == true)
            {

                var query = _repo.FindAll(x => x.FarmGuid == farmGuid && x.RoomGuid == roomGuid && x.Status == 1)
                    .OrderBy(x => x.Id)
                    .Skip(skip)
                    .Take(top)
                    .Select(x => new
                    {
                        x.Id,
                        x.Guid,
                        x.PenNo,
                        Name = $"{x.PenNo} - {x.PenName}"
                    });

                var data = await query.ToListAsync();


                var list = new List<dynamic>();
                if (skip == 0)
                {
                    var itemNo = new
                    {
                        Id = 0,
                        Guid = "",
                        PenNo = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }
            else
            {
                var query = _repo.FindAll(x => (x.PenName.Contains(filter) || x.PenNo.Contains(filter)) && x.FarmGuid == farmGuid && x.RoomGuid == roomGuid && x.Status == 1).OrderBy(x => x.Id).Skip(skip).Take(top).Select(x => new
                {
                    x.Id,
                    x.Guid,
                    x.PenNo,
                    Name = $"{x.PenNo} - {x.PenName}"
                });

                var data = await query.ToListAsync();
                var list = new List<dynamic>();
                if (skip == 0)
                {
                    var itemNo = new
                    {
                        Id = 0,
                        Guid = "",
                        PenNo = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }


        }

        public async Task<object> GetPens(string farmGuid, int top, int skip, string filter, string selected)
        {
            var selectedData = await _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.Guid == selected).Select(x => new
            {
                x.Id,
                x.Guid,
                x.PenNo,
                Name = $"{x.PenNo} - {x.PenName}"
            }).ToListAsync();

            if (string.IsNullOrEmpty(filter) == true)
            {

                var query = _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1)
                    .OrderBy(x => x.Id)
                    .Skip(skip)
                    .Take(top)
                    .Select(x => new
                    {
                        x.Id,
                        x.Guid,
                        x.PenNo,
                        Name = $"{x.PenNo} - {x.PenName}"
                    });

                var data = await query.ToListAsync();


                var list = new List<dynamic>();
                if (skip == 0)
                {
                    var itemNo = new
                    {
                        Id = 0,
                        Guid = "",
                        PenNo = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }
            else
            {
                var query = _repo.FindAll(x => (x.PenName.Contains(filter) || x.PenNo.Contains(filter)) && x.FarmGuid == farmGuid && x.Status == 1).OrderBy(x => x.Id).Skip(skip).Take(top).Select(x => new
                {
                    x.Id,
                    x.Guid,
                    x.PenNo,
                    Name = $"{x.PenNo} - {x.PenName}"
                });

                var data = await query.ToListAsync();
                var list = new List<dynamic>();
                if (skip == 0)
                {
                    var itemNo = new
                    {
                        Id = 0,
                        Guid = "",
                        PenNo = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }


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
        public async Task<object> LoadData(DataManager data, string farmGuid, string areaGuid, string barnGuid, string roomGuid)
        {
            var datasource = _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid && x.AreaGuid == areaGuid && x.BarnGuid == barnGuid && x.RoomGuid == roomGuid)
            .OrderByDescending(x => x.Id)
            .Select(x => new
            {
                x.Id,
                x.PenName,
                x.PenNo,
                x.Guid
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

        public async Task<object> LoadData(DataManager data, string roomGuid, string makeOrderGuid)
        {
            var datasource = _repo.FindAll(x => x.Status == 1 && x.RoomGuid == roomGuid)
            .OrderByDescending(x => x.Id)
            .Select(x => new
            {
                x.Id,
                x.PenName,
                x.PenNo,
                x.Guid,
                Checked = (from a in _repoMakeOrder2Pen.FindAll() where a.PenGuid == x.Guid && a.MakeOrderGuid == makeOrderGuid select a).Any()
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

        public async Task<object> GetPens(string farmGuid)
        {
            var query = _repo.FindAll(x => x.Status == 1).Select(x => new
            {
                x.Id,
                x.Guid,
                x.PenName
            });

            var data = await query.ToListAsync();
            return data;
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

        public async Task<OperationResult> MapMakeOrderToPen(MapMakeOrderToPenDto request)
        {
            var pigs = await _repoPig.FindAll(x => x.MakeOrderGuid == request.MakeOrderGuid).ToListAsync();
            pigs.ForEach(x =>
            {
                x.PenGuid = request.PenGuid;
            });
            try
            {
                _repoPig.UpdateRange(pigs);
                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.UpdateSuccess,
                    Success = true,
                    Data = pigs.FirstOrDefault()
                };
            }
            catch (Exception ex)
            {
                operationResult = ex.GetMessageError();
            }
            return operationResult;
        }

        public async Task<object> GetPenByMakeOrderGuid(string makeOrderGuid)
        {
            var pig = await _repoPig.FindAll(x => x.MakeOrderGuid == makeOrderGuid).FirstOrDefaultAsync();
            if (pig != null) return new
            {
                Guid = pig.PenGuid
            };
            else return new
            {
                Guid = string.Empty
            };
        }

        public async Task<object> GetPenByRoom(string recordGuid, string type)
        {
            var item = await _repoRecord2Pen.FindAll(x => x.RecordGuid == recordGuid && x.Type == type).FirstOrDefaultAsync();
            if (item == null) return null;
            return item.PenGuid;
        }

        public async Task<OperationResult> RemoveRecord2Pen(Record2Pen request)
        {
            try
            {
                var ap = await _repoRecord2Pen.FindAll(x => x.RecordGuid == request.RecordGuid && x.Type == request.Type && x.PenGuid == request.PenGuid).FirstOrDefaultAsync();
                _repoRecord2Pen.Remove(ap);
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

        public async Task<OperationResult> AddRecord2Pen(Record2Pen request)
        {
            try
            {

                var item = new Record2Pen
                {
                    RecordGuid = request.RecordGuid,
                    Type = request.Type,
                    PenGuid = request.PenGuid
                };
                _repoRecord2Pen.Add(item);
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
        public async Task<object> GetSelectedPen(string[] guid)
        {
            var items = await _repo.FindAll(x => guid.Contains(x.Guid)).Select(x => new
            {
                Guid = x.Guid,
                Name = $"{x.PenNo} - {x.PenName}"
            }).ToListAsync();
            return items;
        }
        public async Task<object> GetPenByRecord(string recordGuid, string type)
        {
            var item = await _repoRecord2Pen.FindAll(x => x.RecordGuid == recordGuid && x.Type == type).FirstOrDefaultAsync();
            if (item == null) return null;
            return item;
        }
        public async Task<object> GetPensByRoomAndRecord(string roomGuid, string recordGuid, string type)
        {
            var item = await _repoRecord2Pen.FindAll(x => x.RecordGuid == recordGuid && x.Type == type).Select(x => new { Guid = x.PenGuid }).ToListAsync();
            if (item.Count == 0) return new List<dynamic>{};
            return item;
        }
    }
}
