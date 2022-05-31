using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
    public interface IRoomService : IServiceBase<Room, RoomDto>
    {
        Task<object> GetRooms(string farmGuid, int top, int skip, string filter, string selected);
        Task<object> LoadData(DataManager data, string farmGuid, string areaGuid, string barnGuid);
        Task<object> GetAudit(object id);
        Task<object> GetRoomByRecord(string recordGuid, string type);
        Task<OperationResult> RemoveRecord2Room(Record2Room request);
        Task<OperationResult> AddRecord2Room(Record2Room request);
        Task<object> GetRoomsByFarmGuid(string farmGuid, string barnGuid);
    }
    public class RoomService : ServiceBase<Room, RoomDto>, IRoomService
    {
        private readonly IRepositoryBase<Room> _repo;
        private readonly IRepositoryBase<Pig> _repoPig;
        private readonly IRepositoryBase<Room> _repoRoom;
        private readonly IRepositoryBase<Record2Room> _repoRecord2Room;
        private readonly IRepositoryBase<MakeOrder> _repoMakeOrder;
        private readonly IRepositoryBase<XAccount> _repoXAccount;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PigFarmContext _context;
        private readonly MapperConfiguration _configMapper;
        private readonly IConfiguration _configuration;
        public RoomService(
            IRepositoryBase<Room> repo,
            IRepositoryBase<Pig> repoPig,
            IRepositoryBase<Room> repoRoom,
IRepositoryBase<Record2Room> repoRecord2Room,
            IRepositoryBase<MakeOrder> repoMakeOrder,
            IRepositoryBase<XAccount> repoXAccount,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            PigFarmContext context,
            MapperConfiguration configMapper,
            IConfiguration configuration
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _context= context;
            _repoPig = repoPig;
            _repoRoom = repoRoom;
            _repoRecord2Room = repoRecord2Room;
            _repoMakeOrder = repoMakeOrder;
            _repoXAccount = repoXAccount;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
             _configuration = configuration;
        }
        public async Task<object> GetRoomsByFarmGuid(string farmGuid, string barnGuid) {
             using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                string sql = "SP_GetRoomsByFarmGuid";
                var parameters = new { @Farm_GUID =farmGuid, @Barn_GUID = barnGuid };
                try
                {
                   var datasource= await conn.QueryAsync(sql, parameters, commandType: CommandType.StoredProcedure);
            return datasource;
                }
                catch
                {
            return new List<dynamic> {};

                }

            }
            
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

            var results = (await datasource.Select(x => new
            {
                Id = x.Id,
                Guid = x.Guid,
                FarmGuid = x.FarmGuid,
                Name = $"{x.RoomNo} - {x.RoomName}",
                Status = x.Status
            }).Select(x => new
            {
                Guid = x.Guid,
                Name = $"{x.Name}"

            }).ToListAsync());
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

        public async Task<object> GetRooms(string farmGuid, int top, int skip, string filter, string selected)
        {
            var selectedData = await _repo.FindAll(x => x.FarmGuid == farmGuid && x.Status == 1 && x.Guid == selected).Select(x => new
            {
                x.Id,
                x.Guid,
                x.RoomNo,
                Name = $"{x.RoomNo} - {x.RoomName}"
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
                        x.RoomNo,
                        Name = $"{x.RoomNo} - {x.RoomName}"
                    });

                var data = await query.ToListAsync();


                var list = new List<dynamic>();
                if (skip == 0)
                {
                    var itemNo = new
                    {
                        Id = 0,
                        Guid = "",
                        RoomNo = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }
            else
            {
                var query = _repo.FindAll(x => (x.RoomName.Contains(filter) || x.RoomNo.Contains(filter)) && x.FarmGuid == farmGuid && x.Status == 1).OrderBy(x => x.Id).Skip(skip).Take(top).Select(x => new
                {
                    x.Id,
                    x.Guid,
                    x.RoomNo,
                    Name = $"{x.RoomNo} - {x.RoomName}"
                });

                var data = await query.ToListAsync();
                var list = new List<dynamic>();
                if (skip == 0)
                {
                    var itemNo = new
                    {
                        Id = 0,
                        Guid = "",
                        RoomNo = "",
                        Name = "No Item"
                    };
                    list.Add(itemNo);
                }
                list.AddRange(data.Union(selectedData).ToList());
                return list;
            }


        }

        public override async Task<OperationResult> AddAsync(RoomDto model)
        {
            try
            {
                var item = _mapper.Map<Room>(model);
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
        public override async Task<List<RoomDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<RoomDto>(_configMapper);

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
        public async Task<object> LoadData(DataManager data, string farmGuid, string areaGuid, string barnGuid)
        {
            var datasource = _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid && x.AreaGuid == areaGuid && x.BarnGuid == barnGuid)
                .OrderByDescending(x => x.Id)
                .Select(x => new
                {
                    x.Id,
                    x.RoomName,
                    x.RoomNo,
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
        public async Task<object> GetRoomByRecord(string recordGuid, string type) 
        => await _repoRecord2Room.FindAll(x => x.RecordGuid == recordGuid && x.Type == type).FirstOrDefaultAsync();

        public async Task<OperationResult> RemoveRecord2Room(Record2Room request)
        {
            try
            {
                var ap = await _repoRecord2Room.FindAll(x => x.RecordGuid == request.RecordGuid && x.Type == request.Type && x.RoomGuid == request.RoomGuid).FirstOrDefaultAsync();
                _repoRecord2Room.Remove(ap);
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

        public async Task<OperationResult> AddRecord2Room(Record2Room request)
        {
            try
            {

                var item = new Record2Room
                {
                    RecordGuid = request.RecordGuid,
                    Type = request.Type,
                    RoomGuid = request.RoomGuid
                };
                _repoRecord2Room.Add(item);
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

    }
}
