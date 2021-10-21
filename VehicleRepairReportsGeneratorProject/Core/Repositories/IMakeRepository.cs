using System.Collections.Generic;

namespace VehicleRepairReportsGeneratorProject
{
    interface IMakeRepository : IRepository<Make>
    {
        IEnumerable<Make> getByName(string name);
        Make getByVinSymbol(string vinSymbol);
    }
}
