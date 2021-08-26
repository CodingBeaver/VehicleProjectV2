using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entity;
using AutoMapper;
using Commons;
using PagedList;

namespace DataAccess.Repository
{
    public class MakeRepository : IMakeRepository
    {

        public VehicleContext Db { get; set; }
        IMapper Mapper { get; set; }

        public MakeRepository(VehicleContext context, IMapper mapper)
        {
            Db = context;
            Mapper = mapper;
        }

        public async Task<List<IVehicleMake>> GetAll(Filter filter, Sort sort, Paging paging)
        {
            IEnumerable<MakeEntity> makes = Db.VehicleMakes;

            if (filter.FilterString != null)
            {
                makes = makes.Where(m => m.Name.Contains(filter.FilterString));
            }
            if (sort != null)
            {
                switch (sort.SortDirection)
                {
                    case "asc":
                        makes = makes.OrderBy(s => s.Name);
                        break;
                    case "desc":
                        makes = makes.OrderByDescending(s => s.Name);
                        break;
                    default:
                        break;
                }
            }

            if (paging.Pages != null)
            {
                makes = makes.ToPagedList((int)paging.Pages, (int)paging.PageSize);
            }
            var response = await Task.Run(() => Mapper.Map<List<IVehicleMake>>(makes.ToList()));
            return response;
        }

        public async Task<IVehicleMake> GetById(Guid id)
        {
            MakeEntity response = await Db.VehicleMakes.FindAsync(id);
            return Mapper.Map<IVehicleMake>(response);
        }

        public async Task Add(IVehicleMake make)
        {
            MakeEntity newMake = Mapper.Map<MakeEntity>(make);
            await Task.Run(() => {
                var added = Db.VehicleMakes.Add(newMake);
                Console.WriteLine(added);
                return added;
            }
            );
            await Db.SaveChangesAsync();
        }

        public async Task<IVehicleMake> Update(IVehicleMake updatedMake, Guid id)
        {
            var make = Db.VehicleMakes.Find(id);
            if (make != null)
            {
                try
                {
                    make.Name = updatedMake.Name;
                    make.Abrv = updatedMake.Abrv;
                    await Db.SaveChangesAsync();
                    return await Task.Run(() => Mapper.Map<IVehicleMake>(make));
                }
                catch
                {
                    throw new Exception("Failed to update make");
                }
            }
            else
            {
                throw new ArgumentException("No make listed by that Id", nameof(id));

            }

        }

        public async Task Delete(Guid id)
        {
            var make = Db.VehicleMakes.Find(id);
            Db.VehicleMakes.Remove(make);
            await Db.SaveChangesAsync();



        }
    }
}
