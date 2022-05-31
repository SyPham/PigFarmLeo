﻿using AutoMapper;
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
    public interface IBioS2penService : IServiceBase<BioS2pen, BioS2penDto>
    {
        Task<object> LoadData(DataManager data, string bioSMasterGuid);
        Task<object> LoadData(DataManager data);

    }
    public class BioS2penService : ServiceBase<BioS2pen, BioS2penDto>, IBioS2penService
    {
        private readonly IRepositoryBase<BioS2pen> _repo;
        private readonly IRepositoryBase<Pen> _repoPen;
        private readonly IRepositoryBase<BioSMaster> _repoBioSMaster;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public BioS2penService(
            IRepositoryBase<BioS2pen> repo,
            IRepositoryBase<Pen> repoPen,
            IRepositoryBase<BioSMaster> repoBioSMaster,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _repoPen = repoPen;
            _repoBioSMaster = repoBioSMaster;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }
        public async Task<object> LoadData(DataManager data, string bioSMasterGuid)
        {
            //IQueryable<BioS2penDto> datasource = _repo.FindAll().ProjectTo<BioS2penDto>(_configMapper);
            var datasource = (from a in _repo.FindAll(x=> x.BioSMasterGuid == bioSMasterGuid)
                             join b in _repoBioSMaster.FindAll(x => x.Status == 1) on a.BioSMasterGuid equals b.Guid
                             join c in _repoPen.FindAll(x => x.Status == 1) on a.PenGuid equals c.Guid
                             select new BioS2penDto
                             {
                                 Id = a.Id,
                                 PenGuid = a.PenGuid,
                                 BioSMasterGuid = a.BioSMasterGuid,
                                 PenName = c.PenName,
                                 BioSMasterName = b.Guid
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
            //IQueryable<BioS2penDto> datasource = _repo.FindAll().ProjectTo<BioS2penDto>(_configMapper);
            var datasource = from a in _repo.FindAll().OrderByDescending(x => x.Id)
                             join b in _repoBioSMaster.FindAll(x => x.Status == 1) on a.BioSMasterGuid equals b.Guid
                             join c in _repoPen.FindAll(x => x.Status == 1) on a.PenGuid equals c.Guid
                             select new BioS2penDto
                             {
                                 Id = a.Id,
                                 PenGuid = a.PenGuid,
                                 BioSMasterGuid = a.BioSMasterGuid,
                                 PenName = c.PenName,
                                 BioSMasterName = b.Guid
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
        public override async Task<List<BioS2penDto>> GetAllAsync()
        {
            var query = _repo.FindAll().ProjectTo<BioS2penDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> AddAsync(BioS2penDto model)
        {
            var check = await _repo.FindAll(x => x.PenGuid == model.PenGuid && x.BioSMasterGuid == model.BioSMasterGuid).AnyAsync();
            if (check)
                return new OperationResult
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "The pen or bio security master already existed!",
                    Success = false,
                    Data = null
                };
            var item = _mapper.Map<BioS2pen>(model);
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
        public override async Task<OperationResult> UpdateAsync(BioS2penDto model)
        {
            var item = await _repo.FindByIDAsync(model.Id);
            if (model.PenGuid != item.PenGuid || model.BioSMasterGuid != item.BioSMasterGuid)
            {
                var check = await _repo.FindAll(x => x.PenGuid == model.PenGuid && x.BioSMasterGuid == model.BioSMasterGuid).AnyAsync();
                if (check)
                    return new OperationResult
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "The pen or bio security master already existed!",
                        Success = false,
                        Data = null
                    };
            }

            item.BioSMasterGuid = model.BioSMasterGuid;
            item.PenGuid = model.PenGuid;
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
            _repo.Remove(item);
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
