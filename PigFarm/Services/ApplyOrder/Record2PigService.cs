using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public interface IRecord2PigService : IServiceBase<Record2Pig, Record2PigDto>
    {
        Task<OperationResult> UpdateWeightAsync(UpdateWeightParams model);
    }
    public class Record2PigService : ServiceBase<Record2Pig, Record2PigDto>, IRecord2PigService
    {
        private readonly IRepositoryBase<Record2Pig> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;
        public Record2PigService(
            IRepositoryBase<Record2Pig> repo,
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

        public async Task<OperationResult> UpdateWeightAsync(UpdateWeightParams model)
        {
            var items = await _repo.FindAll(x => x.Type == model.Type && x.RecordGuid == model.RecordGuid).ToListAsync();
            foreach (var item in items)
            {
                item.RecordValue = model.RecordValue;
            }
            _repo.UpdateRange(items);
            try
            {
                await _unitOfWork.SaveChangeAsync();
                operationResult = new OperationResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = MessageReponse.UpdateSuccess,
                    Success = true,
                    Data = items
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
