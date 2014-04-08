using Cards.Extensions.Tfs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    public class AreasController : ApiController
    {

        [Authorize]
        [Route("api/v1/areas")]
        public List<Area> GetAreas()
        {
            return new List<Area>()
            {
                new Area() { ID = 1, Name = "Backlog" }
            };

        }

    }
}
