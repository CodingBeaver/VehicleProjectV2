using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Service.VehicleService;
using System.Web.Routing;
using System.Web.Optimization;
using Commons;
using WebApi.Models;


namespace WebApi.Controllers
{
    public class MakeController : ApiController
    {
        public IMapper Mapper { get; set; }
        public IVehicleMakeService MakeService { get; set; }



        public MakeController(IVehicleMakeService service, IMapper mapper)
        {
            MakeService = service;
            Mapper = mapper;
}
        [HttpGet]
        //[Route("api/make/{FilterSting?}&{SortField?}&{SortDirection?}&{Pages?}&{PagesSize?}")]
        public async Task<HttpResponseMessage> GetAll([FromUri] Commons.Filter filter, [FromUri] Sort sort, [FromUri] Paging paging)
        {
            try
            {
                var response = Mapper.Map<List<MakeRest>>(await MakeService.MakeGetAll(filter, sort, paging));
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(ex.Message);
            }

        }


        [HttpGet]
        public async Task<HttpResponseMessage> GetById([FromUri] Guid id)
        {
            var response = await MakeService.MakeById(id);
            if (response == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, response);
            }
            return Request.CreateResponse(response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] MakeRest newMake)
        {
            try
            {
                var make = Mapper.Map<IVehicleMake>(newMake);
                await MakeService.AddMake(make);
                return Request.CreateResponse(System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] MakeRest update, Guid id)
        {
            try
            {
                var make = Mapper.Map<IVehicleMake>(update);
                var response = await MakeService.UpdateMake(make, id);
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }


        }

        [HttpDelete]

        public async Task<HttpResponseMessage> Delete([FromUri] Guid id)
        {
            try
            {
                await MakeService.DeleteMake(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }






    }
}
