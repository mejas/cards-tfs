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
        public List<Area> GetAllAreas()
        {
            var area = new Area();

            return area.GetAll();
        }

        public Area GetAreaByID(int id)
        {
            var identity = HttpContext.Current.Request.LogonUserIdentity;

            return new Area() { ID = id, Name = "Backlog", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue, CreatedUser = identity.Name, ModifiedUser = identity.Name };
        }

        public Area AddArea(string name)
        {
            throw new NotImplementedException();
        }

        public Area UpdateArea(Area area)
        {
            var identity = HttpContext.Current.Request.LogonUserIdentity;

            area.ModifiedUser = identity.Name;
            area.ModifiedDate = DateTime.UtcNow;

            return area;
        }

    }
}
