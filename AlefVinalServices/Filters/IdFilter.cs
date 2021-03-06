﻿using DataService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlefVinalServices.Filters
{
    public class IdFilter : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // REMARK! : Get value id
            //1)
            //var routeData = context.RouteData.Values;
            //var id = routeData["id"];
            //2)
            //var id_2 = context.Result;
            //3)
            //var routeData = context.RouteData.DataTokens;

            CookieOptions cookie = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(1)
            };
            context.HttpContext.Response.Cookies.Append("ValueId", "id", cookie);
        }
    }
}
