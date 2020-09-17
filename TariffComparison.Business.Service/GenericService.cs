using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TariffComparison.Business.Interface;
using TariffComparison.Data.Interface;

namespace TariffComparison.Business.Service
{
    public class GenericService<TDataModel, TBusinessModel, TKey> : IGenericService<TBusinessModel, TDataModel, TKey> where TBusinessModel : class where TDataModel : class
    {
        protected readonly IGenericRepository<TDataModel, TKey> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public GenericService(IMapper mapper, IGenericRepository<TDataModel, TKey> genericRepository, IUnitOfWork unitOfWork)
        {
            _repository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TBusinessModel> Add(TBusinessModel businessEntity)
        {
            var dataEntity = _mapper.Map<TBusinessModel, TDataModel>(businessEntity);
            dataEntity = await _repository.Add(dataEntity);
            if (_unitOfWork != null)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            businessEntity = _mapper.Map<TDataModel, TBusinessModel>(dataEntity);
            return businessEntity;
        }

        public virtual async Task<List<TBusinessModel>> Get()
        {
            var dataEntities = await _repository.Get();
            var businessEntities = _mapper.Map<List<TDataModel>, List<TBusinessModel>>(dataEntities);
            return businessEntities;
        }


    }
}
