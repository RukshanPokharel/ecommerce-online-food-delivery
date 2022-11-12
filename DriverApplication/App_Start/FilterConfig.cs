using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DriverApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        // used for authentication and authorization
        //public static void Configure(HttpConfiguration config)
        //{
        //    config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
        //}
    }
}
