using System;
using System.Web;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class WindowsIdentityProvider : IIdentityProvider
    {
        public string GetUserName()
        {
            var session = (HttpContext.Current.Cache["Session"] as Session);

            if (session != null)
            {
                return session.DisplayName;
            }

            return String.Empty;
        }
    }
}
