using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class AreasController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<Area>))]
        [Route("api/Areas")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            var area = new Area();

            var result = area.GetAll();

            return request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpGet]
        [ResponseType(typeof(Area))]
        [Route("api/Areas/{id}")]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            var area = new Area();

            var result = area.Get(id);

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

        [HttpPost]
        [ResponseType(typeof(Area))]
        [Route("api/Areas")]
        public HttpResponseMessage Add(HttpRequestMessage request, Area area)
        {
            var result = area.Add(area.Name);

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.Created, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [ResponseType(typeof(Area))]
        [Route("api/Areas/{id}")]
        public Area Edit(int id, Area area)
        {
            area.ID = id;

            return area.Update(area);
        }

        [HttpHead]
        [ResponseType(typeof(void))]
        [Route("api/Areas/{id}")]
        public void Delete(HttpRequestMessage request, int id)
        {
            var area = new Area();

            area.Remove(id);

            request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
