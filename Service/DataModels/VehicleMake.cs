using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace Service.DataModels
{
    public class VehicleMake : IVehicleMake
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
