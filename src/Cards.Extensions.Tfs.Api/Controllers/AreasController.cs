using Cards.Extensions.Tfs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            var identity = HttpContext.Current.Request.LogonUserIdentity;

            return new List<Area>()
            {
                new Area() { ID = 1, Name = "Backlog", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue, CreatedUser = identity.Name, ModifiedUser = identity.Name },
                new Area() { ID = 2, Name = "Todo", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue, CreatedUser = identity.Name, ModifiedUser = identity.Name },
                new Area() { ID = 3, Name = "Doing", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue, CreatedUser = identity.Name, ModifiedUser = identity.Name },
                new Area() { ID = 4, Name = "Done", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue, CreatedUser = identity.Name, ModifiedUser = identity.Name }
            };

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
