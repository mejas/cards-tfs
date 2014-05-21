using Cards.Extensions.Tfs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

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
            var identity = HttpContext.Current.Request.LogonUserIdentity;

            return new Area() { ID = id, Name = "Backlog", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue, CreatedUser = identity.Name, ModifiedUser = identity.Name };
        }

        [HttpPost]
        [Route("api/Areas")]
        public Area Add(Area area)
        {
            return area;
        }

        [HttpPut]
        [Route("api/Areas/{id}")]
        public Area Edit(int id, Area area)
        {
            area.ID = id;
            return area;
        }

        [HttpDelete]
        [Route("api/Areas/{id}")]
        public void Delete(int id)
        {
        }

    }
}
