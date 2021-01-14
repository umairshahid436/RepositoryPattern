using Booteq.Entities;
using BooteqPointOfSale.Business.Interfaces;
using BooteqPointOfSale.Business.Service;
using BooteqPointOfSale.Data.Interfaces;

namespace BooteqPointOfSale.Business.Services
{
    public class WorkerTypeService : GenericService<WorkerType, int>, IWorkerTypeService
    {
        public WorkerTypeService(IWorkerTypeRespository workerTypeRepository) : base(workerTypeRepository)
        {
        }
    }
}
