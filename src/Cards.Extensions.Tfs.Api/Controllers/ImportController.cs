using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Contracts;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    [Authorize]
    public class ImportController : ApiController
    {
        [HttpPost]
        [ResponseType(typeof(List<Card>))]
        [Route("api/Import")]
        public List<Card> Import(HttpRequestMessage request, 
                                    int tfsWorkItem, 
                                    string tfsAreaPath,
                                    string tfsIterationPath,
                                    string tfsUserName, 
                                    string tfsItemType, 
                                    int cardsAreaID)
        {

            var e = request.GetQueryNameValuePairs();

            return null;
        }
    }
}