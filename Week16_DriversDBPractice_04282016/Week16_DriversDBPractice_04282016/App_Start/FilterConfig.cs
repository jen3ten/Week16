using System.Web;
using System.Web.Mvc;

namespace Week16_DriversDBPractice_04282016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
