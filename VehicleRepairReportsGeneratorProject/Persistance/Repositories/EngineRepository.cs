using System.Collections.Generic;
using System.Linq;

namespace VehicleRepairReportsGeneratorProject
{
    class EngineRepository : Repository<Engine>, IEngineRepository
    {
        public EngineRepository(CarServiceContext context)
            :base (context)
        {

        }
        public IEnumerable<Engine> getAllEnginesByModel(int modelId)
        {
            return CarServiceContext.Engines.Where(e => e.Models.Any(m => m.Id == modelId)).ToList();
        }

        public IEnumerable<Engine> getByName(string name)
        {
            return CarServiceContext.Engines.Where(e => e.Name == name).ToList();
        }
        public CarServiceContext CarServiceContext
        {
            get { return Context as CarServiceContext; }
        }
    }
}
