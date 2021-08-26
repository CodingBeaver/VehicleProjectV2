using Commons;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.VehicleService
{
    public class VehicleModelService : IVehicleModelService
    {
        public IModelRepository ModelRepo { get; set; }

        public VehicleModelService(IMakeRepository makeRepo, IModelRepository modelRepo)
        {
           
            ModelRepo = modelRepo;
        }


        public async Task<List<IVehicleModel>> ModelGetAll(Filter filter, Sort sort, Paging paging)
        {
            var response = await ModelRepo.GetAll(filter, sort, paging);
            return response;
        }

        public async Task<IVehicleModel> ModelById(Guid id)
        {
            var response = await ModelRepo.GetById(id);
            return response;
        }

        public async Task AddModel(IVehicleModel model)
        {
            await ModelRepo.Add(model);
        }

        public async Task<IVehicleModel> UpdateModel(IVehicleModel model, Guid id)
        {
            var response = await ModelRepo.Update(model, id);
            return response;
        }

        public async Task DeleteModel(Guid id)
        {
            await ModelRepo.Delete(id);
        }
    }
}
