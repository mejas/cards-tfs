using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class ImportController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(Card))]
        [Route("api/Import/{areaId}")]
        public HttpResponseMessage ImportFromTFSID(HttpRequestMessage request, int tfsWorkItem, int areaID)
        {
            var session = HttpContext.Current.Cache["Session"] as Session;

            if (session != null)
            {
                WorkItem workItem = new WorkItem(session.TFSProvider);

                var tfsItem = new List<WorkItem>() { workItem.Get(tfsWorkItem) };

                var result = new Card().Add(tfsItem, areaID);

                if (result != null)
                {
                    return request.CreateResponse(HttpStatusCode.Accepted, result);
                }
            }

            return request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [ResponseType(typeof(List<Card>))]
        [Route("api/Import/{areaID}")]
        public HttpResponseMessage ImportFromSavedTFSQuery(HttpRequestMessage request, string queryName, int areaID)
        {
            var session = HttpContext.Current.Cache["Session"] as Session;

            if (session != null)
            {
                WorkItem workItem = new WorkItem(session.TFSProvider);
                Card card = new Card();

                var tfsItems = workItem.Get(queryName);

                List<Card> result = card.Add(tfsItems, areaID);

                if (result != null)
                {
                    return request.CreateResponse(HttpStatusCode.Accepted, result);
                }
            }

            return request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}