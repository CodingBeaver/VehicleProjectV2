using AutoMapper;
using Commons;
using Service.VehicleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ModelController : ApiController
    {
        public IMapper Mapper { get; set; }
        public IVehicleModelService ModelService { get; set; }

        public ModelController(IVehicleModelService service, IMapper mapper)
        {
            ModelService = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAll([FromUri] Filter filter, [FromUri] Sort sort, [FromUri] Paging paging)
        {
            try
            {
                var response = Mapper.Map<List<ModelRest>>(await ModelService.ModelGetAll(filter, sort, paging));
                return Request.CreateResponse(response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpGet]
        public async Task<HttpResponseMessage> GetById([FromUri] Guid id)
        {
            var response = await ModelService.ModelById(id);
            if (response == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, response);
            }
            return Request.CreateResponse(response);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] ModelRest newModel)
        {
            try
            {
                var model = Mapper.Map<IVehicleModel>(newModel);
                await ModelService.AddModel(model);
                return Request.CreateResponse(System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, ex.Message);
            }
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put([FromBody] ModelRest update, Guid id)
        {
            try
            {
                var model = Mapper.Map<IVehicleModel>(update);
                var response = await ModelService.UpdateModel(model, id);
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
                await ModelService.DeleteModel(id);
                return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}