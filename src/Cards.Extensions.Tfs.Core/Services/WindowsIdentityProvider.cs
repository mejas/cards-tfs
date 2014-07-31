using System.Web;
using Cards.Extensions.Tfs.Core.Interfaces;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class WindowsIdentityProvider : IIdentityProvider
    {
        public string GetUserName()
        {
            return HttpContext.Current.Request.LogonUserIdentity.Name;
        }
    }
}
