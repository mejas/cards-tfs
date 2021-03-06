﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class CardsController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(List<Card>))]
        [Route("api/Cards/ByArea/{areaID}")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int areaID)
        {
            var card = new Card();

            var result = card.GetAll(areaID);

            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [ResponseType(typeof(Card))]
        [Route("api/Cards/{id}")]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            var card = new Card();

            var result = card.Get(id);

            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [ResponseType(typeof(Card))]
        [Route("api/Cards")]
        public HttpResponseMessage Add(HttpRequestMessage request, Card card)
        {
            var result = card.Add(card.Name, card.Description, card.AssignedTo, card.AreaID, card.TfsID);

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
        [ResponseType(typeof(Card))]
        [Route("api/Cards/{id}")]
        public HttpResponseMessage Edit(HttpRequestMessage request, int id, Card card)
        {
            card.ID = id;

            var result = card.Update(card);

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
        [ResponseType(typeof(Card))]
        [Route("api/Cards/{id}/Move")]
        public HttpResponseMessage Edit(HttpRequestMessage request, int id, Area area)
        {
            Card card = new Card();

            var result = card.Move(id, area);
            
            if (result != null)
            {
                return request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [HttpHead]
        [ResponseType(typeof(void))]
        [Route("api/Cards/{id}")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            var card = new Card();

            card.Remove(id);

            return request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}