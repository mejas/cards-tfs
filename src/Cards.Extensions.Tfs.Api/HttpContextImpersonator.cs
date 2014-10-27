using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Cards.Extensions.Tfs.Api
{
    public class HttpContextImpersonator : IDisposable
    {

        protected WindowsImpersonationContext Context { get; set; }

        private HttpContextImpersonator()
        {
        }

        public static HttpContextImpersonator Begin()
        {
            var impersonator = new HttpContextImpersonator();
            var identity = HttpContext.Current.User.Identity as WindowsIdentity;

            impersonator.Context = identity.Impersonate();
            return impersonator;
        }

        public void Undo()
        {
            if (Context != null)
            {
                Context.Undo();
            }
        }

        public void Dispose()
        {
            try 
            {
                Undo();
            }
            catch
            {
            }
        }
    }
}