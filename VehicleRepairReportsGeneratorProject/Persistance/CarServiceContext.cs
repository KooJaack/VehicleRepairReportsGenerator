using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRepairReportsGeneratorProject
{
    class CarServiceContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

        public CarServiceContext()
            :base("name=CarServiceContextConnection")
        {

        }
    }
}
