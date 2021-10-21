using System.Collections.Generic;

namespace VehicleRepairReportsGeneratorProject
{
    interface IModelRepository : IRepository<Model>
    {
        IEnumerable<Model> getModelsInYearsRange(int startYear, int endYear);
        IEnumerable<Model> getAllModelsByMake(int makeId);
        IEnumerable<Model> getAllModelsByEngine(int engineId);
        Model getByVinSymbol(string vinSymbol);
    }
}
