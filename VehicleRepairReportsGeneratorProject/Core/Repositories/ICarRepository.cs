using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRepairReportsGeneratorProject
{
    interface ICarRepository : IRepository<Car>
    {
        Car GetCarByLicensePlate(string licenseplate);
        Car GetCarByVin(string vin);

    }
}
