using Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.VehicleService
{
    public interface IVehicleMakeService
    {
        Task<List<IVehicleMake>> MakeGetAll(Filter filter, Sort sort, Paging paging);
        Task<IVehicleMake> MakeById(Guid id);

        Task AddMake(IVehicleMake make);

        Task<IVehicleMake> UpdateMake(IVehicleMake make, Guid id);

        Task DeleteMake(Guid id);
    }
}