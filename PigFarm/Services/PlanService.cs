﻿using AutoMapper;
using PigFarm.Data;
using PigFarm.DTO;
using PigFarm.Models;
using PigFarm.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PigFarm.Services
{
    public interface IPlanService: IServiceBase<Plan, PlanDto>
    {
    }
    public class PlanService : ServiceBase<Plan, PlanDto>, IPlanService
    {
        private readonly IRepositoryBase<Plan> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public PlanService(
            IRepositoryBase<Plan> repo, 
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
    }
}
