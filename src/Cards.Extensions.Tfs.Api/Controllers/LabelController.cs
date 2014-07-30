using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class LabelController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<Label>))]
        [Route("api/Labels")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            var label = new Label();

            var result = label.GetAll();

            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [ResponseType(typeof(Label))]
        [Route("api/Labels/{id}")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            var label = new Label();

            var result = label.Get(id);

            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [ResponseType(typeof(Label))]
        [Route("api/Labels")]
        public HttpResponseMessage Add(HttpRequestMessage request, Label label)
        {
            var result = label.Add(label.Name, label.ColorCode);

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [ResponseType(typeof(Label))]
        [Route("api/Labels/{id}")]
        public HttpResponseMessage Edit(HttpRequestMessage request, int id, Label label)
        {
            label.ID = id;

            var result = label.Update(label);

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpHead]
        [ResponseType(typeof(void))]
        [Route("api/Labels/{id}")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            var label = new Label();

            label.Remove(id);

            return request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}