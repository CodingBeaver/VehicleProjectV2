using System;

namespace Commons

{
    public interface IVehicleMake
    {
         Guid? Id { get; set; }
         string Name { get; set; }
         string Abrv { get; set; }
    }
}