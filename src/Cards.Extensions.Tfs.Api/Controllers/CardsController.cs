using System.Collections.Generic;
using System.Web.Http;
using Cards.Extensions.Tfs.Core;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class CardsController : ApiController
    {
        [HttpGet]
        [Route("api/Cards/ByArea/{areaID}")]
        public List<Card> GetAll(int areaID)
        {
            var card = new Card();

            return card.GetAll(areaID);
        }

        [HttpGet]
        [Route("api/Cards/{id}")]
        public Card GetByID(int id)
        {
            var card = new Card();

            return card.Get(id);
        }

        [HttpPost]
        [Route("api/Cards")]
        public Card Add(Card card)
        {
            return card.Add(card.Name, card.Description, card.AreaID);
        }

        [HttpPut]
        [Route("api/Cards/{id}")]
        public Card Edit(int id, Card card)
        {
            card.ID = id;

            return card.Update(card);
        }

        [HttpHead]
        [Route("api/Cards/{id}")]
        public void Delete(int id)
        {
            var card = new Card();

            card.Remove(id);
        }
    }
}