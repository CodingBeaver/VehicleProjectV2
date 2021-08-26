using System;

namespace Commons
{
    public interface IVehicleModel
    {
        Guid? Id { get; set; }

        Guid MakeId { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }
    }
}