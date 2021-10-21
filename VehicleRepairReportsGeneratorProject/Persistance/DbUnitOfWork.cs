using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRepairReportsGeneratorProject
{
    class DbUnitOfWork : IUnitOfWork
    {
        private readonly CarServiceContext _context;
        public DbUnitOfWork(CarServiceContext context)
        {
            _context = context;
            Cars = new CarRepository(_context);
            Engines = new EngineRepository(_context);
            Makes = new MakeRepository(_context);
            Models = new ModelRepository(_context);
        }
        public ICarRepository Cars { get; private set; }
        public IEngineRepository Engines { get; private set; }
        public IMakeRepository Makes { get; private set; }
        public IModelRepository Models { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
