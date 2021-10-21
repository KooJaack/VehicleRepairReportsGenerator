using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VehicleRepairReportsGeneratorProject
{
    public class Model
    {
        public Model()
        {
            Engines = new ObservableCollection<Engine>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VinSymbol { get; set; }
        public int YearProductionStart { get; set; }
        public int YearProductionEnd { get; set; }
        public Make Make { get; set; }
        public ICollection<Engine> Engines { get; set; }
    }
}
