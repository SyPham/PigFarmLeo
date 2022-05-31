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
    public interface IFeedMaterialService : IServiceBase<FeedMaterial, FeedMaterialDto>
    {
        Task<object> LoadData(DataManager data, string farmGuid, string lang);
    }
    public class FeedMaterialService : ServiceBase<FeedMaterial, FeedMaterialDto>, IFeedMaterialService
    {
        private readonly IRepositoryBase<FeedMaterial> _repo;
        private readonly IRepositoryBase<CodeType> _repoCodeType;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public FeedMaterialService(
            IRepositoryBase<FeedMaterial> repo,
            IRepositoryBase<CodeType> repoCodeType,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoCodeType = repoCodeType;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> LoadData(DataManager data, string farmGuid, string lang)
        {
            //IQueryable<FeedMaterialDto> datasource = _repo.FindAll(x => x.Status == 1 && x.FarmGuid == farmGuid)
            //    .OrderByDescending(x => x.Id)
            //    .ProjectTo<FeedMaterialDto>(_configMapper);

            var datasource = (from a in _repo.FindAll(x => x.Status == 1)
                              join b in _repoCodeType.FindAll(x => x.CodeType1 == CodeTypeConst.Feed_Material_Type && x.Status == "Y") on a.FeedMaterialType equals b.CodeNo into ab
                              from t in ab.DefaultIfEmpty()
                              select new FeedMaterialDto
                              {
                                  Id = a.Id,
                                  FeedMaterialType = a.FeedMaterialType,
                                  FeedMaterialNo = a.FeedMaterialNo,
                                  FeedMaterialName = a.FeedMaterialName,
                                  FeedMaterialElement = a.FeedMaterialElement,
                                  FeedMaterialEffect = a.FeedMaterialEffect,
                                  FeedMaterialSideEffect = a.FeedMaterialSideEffect,
                                  FeedMaterialBreed = a.FeedMaterialBreed,
                                  FeedMaterialRange = a.FeedMaterialRange,
                                  FeedMaterialCare = a.FeedMaterialCare,
                                  Comment = a.Comment,
                                  CancelFlag = a.CancelFlag,
                                  CreateDate = a.CreateDate,
                                  CreateBy = a.CreateBy,
                                  UpdateDate = a.UpdateDate,
                                  UpdateBy = a.UpdateBy,
                                   DeleteDate  = a.DeleteDate,
                                  DeleteBy = a.DeleteBy,
                                  Status = a.Status,
                                  Guid = a.Guid,
                                  FarmGuid = a.FarmGuid,
                                   VendorGuid = a.VendorGuid,
                                  Location = a.Location,
                                   Spec = a.Spec,
                                  Amount = a.Amount,
                                  Price = a.Price,
                                  Cost = a.Cost,
                                  ExpireDate = a.ExpireDate,
                                  FeedMaterialTypeName = t == null ? "" : lang == Languages.EN ? t.CodeNameEn ?? t.CodeName : lang == Languages.VI ? t.CodeNameVn ?? t.CodeName : lang == Languages.CN ? t.CodeNameCn ?? t.CodeName : t.CodeName,

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

        public override async Task<List<FeedMaterialDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x => x.Status == 1).ProjectTo<FeedMaterialDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(FeedMaterialDto model)
        {
            var item = _mapper.Map<FeedMaterial>(model);
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


    }
}
