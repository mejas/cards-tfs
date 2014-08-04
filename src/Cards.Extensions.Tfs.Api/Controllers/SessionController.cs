using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    public class SessionController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(object))]
        [Route("api/Session")]
        public HttpResponseMessage New(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.Created, new { Name = HttpContext.Current.Request.LogonUserIdentity.Name });
        }

    }
}
