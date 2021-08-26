using Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.VehicleService
{
    public interface IVehicleModelService
    {
        Task<List<IVehicleModel>> ModelGetAll(Filter filter, Sort sort, Paging paging);
        Task<IVehicleModel> ModelById(Guid id);

        Task AddModel(IVehicleModel make);

        Task<IVehicleModel> UpdateModel(IVehicleModel model, Guid id);

        Task DeleteModel(Guid id);
    }
}