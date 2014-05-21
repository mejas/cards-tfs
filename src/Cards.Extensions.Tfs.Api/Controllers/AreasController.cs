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

        public List<Area> GetAllAreas()
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

        public Area GetAreaByID(int id)
        {
            var area = new Area();

            return area.Get(id);
        }

        public Area UpdateArea(Area area)
        {
<<<<<<< Updated upstream
            var identity = HttpContext.Current.Request.LogonUserIdentity;

            area.ModifiedUser = identity.Name;
            area.ModifiedDate = DateTime.UtcNow;

            return area;
=======
            return area.Add(area.Name);
        }

        [HttpPut]
        [Route("api/Areas/{id}")]
        public Area Edit(int id, Area area)
        {
            area.ID = id;

            return area.Update(area);
        }

        [HttpDelete]
        [Route("api/Areas/{id}")]
        public void Delete(int id)
        {
            var area = new Area();

            area.Remove(id);
>>>>>>> Stashed changes
        }

    }
}
