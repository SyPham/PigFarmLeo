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
    public interface IPigHouseCleaning2penService : IServiceBase<PigHouseCleaning2pen, PigHouseCleaning2penDto>
    {
    }
    public class PigHouseCleaning2penService : ServiceBase<PigHouseCleaning2pen, PigHouseCleaning2penDto>, IPigHouseCleaning2penService
    {
        private readonly IRepositoryBase<PigHouseCleaning2pen> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public PigHouseCleaning2penService(
            IRepositoryBase<PigHouseCleaning2pen> repo,
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
