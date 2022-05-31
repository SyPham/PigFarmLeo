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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace PigFarm.Services
{
    public interface IToDoListService : IServiceBase<ToDoList, ToDoListDto>
    {
        

    }
    public class ToDoListService : ServiceBase<ToDoList, ToDoListDto>, IToDoListService
    {
        private readonly IRepositoryBase<ToDoList> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public ToDoListService(
            IRepositoryBase<ToDoList> repo,
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
