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
    public class ModelEntity: IVehicleModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? Id { get; set; }

        [ForeignKey("MakeEntity")]
        public Guid MakeId { get; set; }

        public MakeEntity MakeEntity { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }
    }
}
