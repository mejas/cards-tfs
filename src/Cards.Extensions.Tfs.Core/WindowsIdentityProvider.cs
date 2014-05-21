using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cards.Extensions.Tfs.Core
{
    public class WindowsIdentityProvider : IIdentityProvider
    {
        public string GetUserName()
        {
            return HttpContext.Current.Request.LogonUserIdentity.Name;
        }
    }
}
