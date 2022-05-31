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
    public interface IPigHouseCleaning2pigService : IServiceBase<PigHouseCleaning2pig, PigHouseCleaning2pigDto>
    {
    }
    public class PigHouseCleaning2pigService : ServiceBase<PigHouseCleaning2pig, PigHouseCleaning2pigDto>, IPigHouseCleaning2pigService
    {
        private readonly IRepositoryBase<PigHouseCleaning2pig> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public PigHouseCleaning2pigService(
            IRepositoryBase<PigHouseCleaning2pig> repo,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            MapperConfiguration configMapper
            )
            : base(repo, unitOfWork, mapper, configMapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configMapper = configMapper;
        }

    }
}
