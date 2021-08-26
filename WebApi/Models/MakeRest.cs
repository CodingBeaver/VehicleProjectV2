using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Commons;
namespace WebApi.Models
{
    public class MakeRest : IVehicleMake
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}