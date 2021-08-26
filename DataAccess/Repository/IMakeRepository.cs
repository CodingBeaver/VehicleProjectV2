using System.Collections.Generic;
using System.Threading.Tasks;
using Commons;
using System;

namespace DataAccess.Repository
{
    public interface IMakeRepository
    {
        Task<List<IVehicleMake>> GetAll(Filter filter, Sort sort, Paging paging);

        Task<IVehicleMake> GetById(Guid id);

        Task Add(IVehicleMake make);

        Task<IVehicleMake> Update(IVehicleMake make, Guid id);

        Task Delete(Guid id);
    }
}