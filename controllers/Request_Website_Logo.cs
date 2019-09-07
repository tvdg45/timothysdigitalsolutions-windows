using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_Website_Logo;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_Website_Logo : models.Website_Logo_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        public static string Request_website_logo()
        {
            string output;

            connection = use_connection;

            if (Search_row_count() == 1 && !(Search_website_logo().Equals(""))
                    && !(Search_website_logo().Equals("page error")))
            {
                views.Show_Website_Logo.file_path = Search_website_logo();

                output = views.Show_Website_Logo.Logo_found();
            }
            else
            {
                output = views.Show_Website_Logo.No_logo_found();
            }

            return output;
        }
    }
}