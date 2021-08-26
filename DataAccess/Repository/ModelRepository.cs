using AutoMapper;
using Commons;
using DataAccess.Entity;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ModelRepository : IModelRepository
    {
        public VehicleContext Db { get; set; }
        IMapper Mapper { get; set; }

        public ModelRepository(VehicleContext context, IMapper mapper)
        {
            Db = context;
            Mapper = mapper;
        }



        public async Task<List<IVehicleModel>> GetAll(Filter filter, Sort sort, Paging paging)
        {



            IEnumerable<ModelEntity> models = Db.VehicleModels;

            if (filter.FilterString != null)
            {
                models = models.Where(m => m.Name.Contains(filter.FilterString));
            }
            if (sort.SortField != null)
            {
                if (sort.SortField == "Name")
                {
                    switch (sort.SortDirection)
                    {
                        case "asc":
                            models = models.OrderBy(s => s.Name);
                            break;
                        case "desc":
                            models = models.OrderByDescending(s => s.Name);
                            break;
                        default:
                            break;
                    }
                }
                else if (sort.SortField == "MakeId")
                {

                    switch (sort.SortDirection)
                    {
                        case "asc":
                            models = models.OrderBy(s => s.MakeId);
                            break;
                        case "desc":
                            models = models.OrderByDescending(s => s.MakeId);
                            break;
                        default:
                            break;
                    }
                }
                else { throw new Exception("You can't sort Models by this field"); }
            }

            if (paging.Pages != null)
            {
                models = models.ToPagedList((int)paging.Pages, (int)paging.PageSize);
            }
            var response = await Task.Run(() => Mapper.Map<List<IVehicleModel>>(models.ToList()));
            return response;
        }

        public async Task<IVehicleModel> GetById(Guid id)
        {
            ModelEntity response = await Db.VehicleModels.FindAsync(id);
            return Mapper.Map<IVehicleModel>(response);
        }

        public async Task Add(IVehicleModel model)
        {
            ModelEntity newModel = Mapper.Map<ModelEntity>(model);

            var make = Db.VehicleMakes.Find(newModel.MakeId);
            if (make == null)
            {
                throw new Exception("No make by that id");
            }

            await Task.Run(() => {

                ModelEntity added = Db.VehicleModels.Add(newModel);
            }
            );
            await Db.SaveChangesAsync();
        }

        public Task<IVehicleModel> Update(IVehicleModel updatedModel, Guid id)
        {
            var model = Db.VehicleModels.Find(id);

            if (model != null)
            {
                try
                {
                    model.Name = updatedModel.Name;
                    model.MakeId = updatedModel.MakeId;
                    model.Abrv = updatedModel.Abrv;

                    Db.SaveChanges();
                    return Task.Run(() => Mapper.Map<IVehicleModel>(model));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentException("No model listed by that Id", nameof(id));

            }
        }


        public async Task Delete(Guid id)
        {
            var model = Db.VehicleModels.Find(id);
            Db.VehicleModels.Remove(model);
            await Db.SaveChangesAsync();



        }

    }
}
