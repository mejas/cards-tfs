using Cards.Extensions.Tfs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cards.Extensions.Tfs.Api.Controllers
{

    [Authorize]
    public class AreasController : ApiController
    {

        public List<Area> GetAllAreas()
        {
            return new List<Area>()
            {
                new Area() { ID = 1, Name = "Backlog", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue },
                new Area() { ID = 2, Name = "Todo", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue },
                new Area() { ID = 3, Name = "Doing", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue },
                new Area() { ID = 4, Name = "Done", CreatedDate = DateTime.MinValue, ModifiedDate = DateTime.MinValue }
            };

        }

    }
}
