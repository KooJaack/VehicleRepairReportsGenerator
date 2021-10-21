using System.Collections.Generic;
using System.Linq;

namespace VehicleRepairReportsGeneratorProject
{
    class MakeRepository : Repository<Make>, IMakeRepository
    {
        public MakeRepository(CarServiceContext context)
            :base(context)
        {

        }

        public IEnumerable<Make> getByName(string name)
        {
            return CarServiceContext.Makes.Where(m => m.Name == name);
        }

        public Make getByVinSymbol(string vinSymbol)
        {
            return CarServiceContext.Makes.Where(m => m.VinSymbol == vinSymbol).SingleOrDefault();
        }

        public CarServiceContext CarServiceContext
        {
            get { return Context as CarServiceContext; }
        }
    }
}
