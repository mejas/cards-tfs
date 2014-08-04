using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Api.Controllers
{
    public class SessionController : ApiController
    {

        public Session Session 
        {
            get
            {
                if (HttpContext.Current.Cache["Session"] == null)
                {
                    HttpContext.Current.Cache["Session"] = new Session().CreateSession(HttpContext.Current.Request.LogonUserIdentity.Name);
                }

                return HttpContext.Current.Cache["Session"] as Session;
            }
            set
            {
                HttpContext.Current.Cache["Session"] = value;
            }
        }

        [HttpPost]
        [ResponseType(typeof(object))]
        [Route("api/Session")]
        public HttpResponseMessage New(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.Created, new { Name = Session.DisplayName });
        }

    }
}
