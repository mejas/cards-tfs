using Cards.Extensions.Tfs.Core.Interfaces;
using System.Web;

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
