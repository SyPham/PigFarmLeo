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

namespace PigFarm.Services
{
    public interface IPigKindService: IServiceBase<PigKind, PigKindDto>
    {
    }
    public class PigKindService : ServiceBase<PigKind, PigKindDto>, IPigKindService
    {
        private readonly IRepositoryBase<PigKind> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public PigKindService(
            IRepositoryBase<PigKind> repo, 
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper,  configMapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }

        public override async Task<List<PigKindDto>> GetAllAsync()
        {
            var query = _repo.FindAll(x=> x.Status == true).ProjectTo<PigKindDto>(_configMapper);

            var data = await query.ToListAsync();
            return data;

        }
        public override async Task<OperationResult> DeleteAsync(object id)
        {
            var item = _repo.FindByID(id);
            item.Status = false;
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
