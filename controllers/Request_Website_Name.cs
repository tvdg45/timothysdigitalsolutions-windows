using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_Website_Name : models.Website_Name_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        public static String Request_website_name()
        {
            connection = use_connection;

            return Search_website_name();
        }
    }
}