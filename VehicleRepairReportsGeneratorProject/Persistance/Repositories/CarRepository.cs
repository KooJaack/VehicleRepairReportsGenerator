using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRepairReportsGeneratorProject
{
    class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarServiceContext context)
            :base(context)
        {

        }
        public Car GetCarByLicensePlate(string licenseplate)
        {
            return CarServiceContext.Cars.Where(c => c.LicensePlate == licenseplate).SingleOrDefault();
        }

        public Car GetCarByVin(string vin)
        {
            return CarServiceContext.Cars.Where(c => c.Vin == vin).SingleOrDefault();
        }

        public CarServiceContext CarServiceContext
        {
            get { return Context as CarServiceContext; }
        }
    }
}
