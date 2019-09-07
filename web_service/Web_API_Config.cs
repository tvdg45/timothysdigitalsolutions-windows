using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Timothys_Digital_Solutions_Company_Website_Windows.web_service
{
    public class Web_API_Config
    {
        //You might have to type the following command:
        //Install-Package Microsoft.AspNet.WebApi.Cors.
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.Routes.MapHttpRoute(

                name: "Website_CMS_API",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
