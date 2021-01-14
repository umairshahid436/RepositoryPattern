using Booteq.Entities;
using BooteqPointOfSale.Business.Interfaces;
using BooteqPointOfSale.Business.Service;
using BooteqPointOfSale.Data.Interfaces;

namespace BooteqPointOfSale.Business.Services
{
    public class WorkerService : GenericService<Worker, int>, IWorkerService
    {
        public WorkerService(IWorkerRespository workerRepository) : base(workerRepository)
        {
        }
    }
}
