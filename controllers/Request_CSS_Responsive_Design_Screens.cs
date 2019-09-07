using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_CSS_Responsive_Design_Screens;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_CSS_Responsive_Design_Screens : models.CSS_Responsive_Design_Screens_Processor
    {
        public static string show_website;
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        public static string Request_css_responsive_design_screens()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                connection = use_connection;

                if (!(Search_css_responsive_design_screens()[0][0].Equals(
                    "responsive design screens not found"))
                && !(Search_css_responsive_design_screens()[0][0].Equals("page error")))
                {
                    views.Show_CSS_Responsive_Design_Screens.responsive_design_screens = Search_css_responsive_design_screens();

                    output = views.Show_CSS_Responsive_Design_Screens.Show_responsive_design_screens();
                }
            }

            return output;
        }
    }
}
