using System;

namespace VehicleRepairReportsGeneratorProject
{
    public class Car
    {
        public int Id { get; set; }
        public string Vin { get; set; }
        public string LicensePlate { get; set; }
        public short ProductionYear { get; set; }
        public Model Model { get; set; }
        public Engine Engine { get; set; }
    }
}
