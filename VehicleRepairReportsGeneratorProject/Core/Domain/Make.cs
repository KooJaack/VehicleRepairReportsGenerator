using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VehicleRepairReportsGeneratorProject
{
    public class Make
    {
        public Make()
        {
            Models = new ObservableCollection<Model>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VinSymbol { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
