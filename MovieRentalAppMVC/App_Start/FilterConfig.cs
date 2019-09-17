using System.Web;
using System.Web.Mvc;

namespace MovieRentalAppMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());

            //to avoid opening app in the http://localhost:54278 and allow it only in https://localhost:44342
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
