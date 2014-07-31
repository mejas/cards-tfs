using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class CardActivityController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<CardActivity>))]
        [Route("api/CardActivity/Card/{cardId}")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int cardId)
        {
            var cardActivity = new CardActivity();

            var result = cardActivity.GetAll(cardId);

            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [ResponseType(typeof(Label))]
        [Route("api/CardActivity/{activityId}")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int activityId)
        {
            var cardActivity = new CardActivity();

            var result = cardActivity.Get(activityId);

            return request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}