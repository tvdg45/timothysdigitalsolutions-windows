using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_Website_Icon;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_Website_Icon : models.Website_Icon_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        public static string Request_website_icon()
        {
            string output;

            connection = use_connection;

            if (Search_row_count() == 1 && !(Search_website_icon().Equals(""))
                    && !(Search_website_icon().Equals("page error")))
            {
                views.Show_Website_Icon.file_path = Search_website_icon();

                output = views.Show_Website_Icon.Icon_found();
            }
            else
            {
                output = views.Show_Website_Icon.No_icon_found();
            }

            return output;
        }
    }
}