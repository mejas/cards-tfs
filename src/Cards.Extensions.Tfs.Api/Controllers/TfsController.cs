using Cards.Extensions.Tfs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    public class TfsController : ApiController
    {

        [HttpGet]
        [ResponseType(typeof(WorkItem))]
        [Route("api/tfs/{workItemId}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int workItemId)
        {
            WorkItem workItem = null;

            using (var impersonator = HttpContextImpersonator.Begin())
            {
                workItem = new WorkItem();
                workItem = workItem.Get(workItemId);
            }

            return request.CreateResponse(HttpStatusCode.OK, workItem);
        }

    }
}
