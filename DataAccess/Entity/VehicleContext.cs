using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class VehicleContext : DbContext
    {
        public VehicleContext() : base("name=ConnectionString")
        {
            Database.SetInitializer<VehicleContext>(new CreateDatabaseIfNotExists<VehicleContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MakeEntity>()
                .ToTable("VehicleMakes");
            modelBuilder.Entity<ModelEntity>()
                .ToTable("VehicleModels");
            base.OnModelCreating(modelBuilder);
        }
        // tables/entities

        public DbSet<MakeEntity> VehicleMakes { get; set; }


        public DbSet<ModelEntity> VehicleModels { get; set; }


    }
}
