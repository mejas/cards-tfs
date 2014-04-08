using System.Web;
using System.Web.Mvc;

namespace Cards.Extensions.Tfs.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
