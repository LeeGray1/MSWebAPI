using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Tutorial_API_New
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{word}",
                defaults: new { word = RouteParameter.Optional, word2 = RouteParameter.Optional}
            );
        }
    }
}
