using BooteqPointOfSale.Business.Interface;
using BooteqPointOfSale.Data.Interfaces;
using System.Collections.Generic;

namespace BooteqPointOfSale.Business.Service
{
    public class GenericService<TEntity, TKey> : IGenericService<TEntity, TKey> where TEntity : class
    {
        protected readonly IGenericRepository<TEntity, TKey> _repository;

        public GenericService(IGenericRepository<TEntity, TKey> genericRepository)
        {
            _repository = genericRepository;
        }

        public List<TEntity> Get()
        {
            return _repository.Get();
           
        }


    }
}
