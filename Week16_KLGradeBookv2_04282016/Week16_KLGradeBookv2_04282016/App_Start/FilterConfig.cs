﻿using System.Web;
using System.Web.Mvc;

namespace Week16_KLGradeBookv2_04282016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
