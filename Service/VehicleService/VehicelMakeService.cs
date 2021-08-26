using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;
using Commons;

namespace Service.VehicleService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public IMakeRepository MakeRepo { get; set; }


        public VehicleMakeService(IMakeRepository makeRepo)
        {
            MakeRepo = makeRepo;
        }

        public async Task<List<IVehicleMake>> MakeGetAll(Filter filter, Sort sort, Paging paging)
        {
            var response = await MakeRepo.GetAll(filter, sort, paging);

            return response;
        }

        public async Task<IVehicleMake> MakeById(Guid id)
        {
            return await MakeRepo.GetById(id);
        }

        public async Task AddMake(IVehicleMake make)
        {
            await MakeRepo.Add(make);
        }

        public async Task<IVehicleMake> UpdateMake(IVehicleMake make, Guid id)
        {
            var response = await MakeRepo.Update(make, id);
            return response;
        }

        public async Task DeleteMake(Guid id)
        {
            await MakeRepo.Delete(id);
        }
    }
}
