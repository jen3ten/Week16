﻿using System.Web;
using System.Web.Mvc;

namespace Week16_KLGradebookExample_04272016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
