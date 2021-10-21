using System.Collections.Generic;

namespace VehicleRepairReportsGeneratorProject
{
    interface IEngineRepository : IRepository<Engine>
    {
        IEnumerable<Engine> getAllEnginesByModel(int modelId);
        IEnumerable<Engine> getByName(string name);
    }
}
