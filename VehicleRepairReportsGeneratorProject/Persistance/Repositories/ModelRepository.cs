using System.Collections.Generic;
using System.Linq;

namespace VehicleRepairReportsGeneratorProject
{
    class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(CarServiceContext context)
            :base(context)
        {

        }
        public IEnumerable<Model> getAllModelsByEngine(int engineId)
        {
            return CarServiceContext.Models.Where(m => m.Engines.Any(e => e.Id == engineId)).ToList();
        }

        public IEnumerable<Model> getAllModelsByMake(int makeId)
        {
            return CarServiceContext.Models.Where(m => m.Make.Id == makeId).ToList();
        }

        public IEnumerable<Model> getModelsInYearsRange(int startYear, int endYear)
        {
            return CarServiceContext.Models.Where(m => m.YearProductionStart > startYear && m.YearProductionStart < endYear).ToList();
        }

        public Model getByVinSymbol(string vinSymbol)
        {
            return CarServiceContext.Models.Where(m => m.VinSymbol == vinSymbol).SingleOrDefault();
        }

        public CarServiceContext CarServiceContext
        {
            get { return Context as CarServiceContext; }
        }
    }
}
