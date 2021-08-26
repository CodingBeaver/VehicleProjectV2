using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commons;

namespace DataAccess.Entity
{
    public class MakeEntity: IVehicleMake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public ICollection<ModelEntity> VehicleModels { get; set; }
    }
}
