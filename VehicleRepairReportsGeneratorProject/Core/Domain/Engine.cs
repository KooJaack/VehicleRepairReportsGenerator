using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VehicleRepairReportsGeneratorProject
{
    public class Engine
    {
        public Engine()
        {
            Models = new ObservableCollection<Model>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Displacement { get; set; }
        public int HorsePower { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
