using System.Collections.Generic;
using System.Web.Http;
using Cards.Extensions.Tfs.Core;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class AreasController : ApiController
    {
        [HttpGet]
        [Route("api/Areas")]
        public List<Area> GetAll()
        {
            var area = new Area();

            return area.GetAll();
        }


        [HttpGet]
        [Route("api/Areas/{id}")]
        public Area GetByID(int id)
        {
            var area = new Area();

            return area.Get(id);
        }

        [HttpPost]
        [Route("api/Areas")]
        public Area Add(Area area)
        {
            return area.Add(area.Name);
        }

        [HttpPut]
        [Route("api/Areas/{id}")]
        public Area Edit(int id, Area area)
        {
            area.ID = id;

            return area.Update(area);
        }

        [HttpHead]
        [Route("api/Areas/{id}")]
        public void Delete(int id)
        {
            var area = new Area();

            area.Remove(id);
        }
    }
}
