using AutoMapper;
using PigFarm.Data;
using PigFarm.DTO;
using PigFarm.Models;
using PigFarm.Services.Base;

namespace PigFarm.Services
{
    public interface IDailyFeedingService: IServiceBase<DailyFeeding, DailyFeedingDto>
    {
    }
    public class DailyFeedingService : ServiceBase<DailyFeeding, DailyFeedingDto>, IDailyFeedingService
    {
        private readonly IRepositoryBase<DailyFeeding> _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _configMapper;

        public DailyFeedingService(
            IRepositoryBase<DailyFeeding> repo,
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
