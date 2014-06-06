using System;
using System.Collections.Generic;
using System.Linq;
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
            WorkItem workItem = new WorkItem();

            var tfsItem = workItem.Get(tfsWorkItem);

            Card cardFromTFSItem = createCardFromWorkItem(workItem, areaID);

            var result = new Card().Add(cardFromTFSItem);

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.Accepted, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ResponseType(typeof(List<Card>))]
        [Route("api/Import/{areaID}")]
        public HttpResponseMessage ImportFromLiveTFSQuery(HttpRequestMessage request, int areaID)
        {
            var tfsArgs = request.GetQueryNameValuePairs();

            WorkItem workItem = new WorkItem();
            Card card = new Card();

            var tfsItems = workItem.Get(tfsArgs);

            List<Card> result = null;
            if (tfsItems != null)
            {
                result = new List<Card>();
                foreach (var tfsItem in tfsItems)
                {
                    result.Add(card.Add(createCardFromWorkItem(tfsItem, areaID)));
                }
            }

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.Accepted, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ResponseType(typeof(List<Card>))]
        [Route("api/Import/{areaID}")]
        public HttpResponseMessage ImportFromSavedTFSQuery(HttpRequestMessage request, string queryName, int areaID)
        {
            WorkItem workItem = new WorkItem();
            Card card = new Card();

            var tfsItems = workItem.Get(queryName);

            List<Card> result = null;
            if (tfsItems != null)
            {
                result = new List<Card>();
                foreach (var tfsItem in tfsItems)
                {
                    result.Add(card.Add(createCardFromWorkItem(tfsItem, areaID)));
                }
            }

            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.Accepted, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        private Card createCardFromWorkItem(WorkItem workItem, int areaID)
        {
            return new Card()
            {
                AreaID      = areaID,
                Name        = workItem.Title,
                Description = workItem.Description,
                TfsID       = workItem.ID,
                AssignedTo  = workItem.AssignedTo
            };
        }
    }
}