using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_Footer_Content;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_Footer_Content : models.Footer_Content_Processor
    {
        public static string show_website;
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        //Global variable for total number of footer sections
        public static int number_of_footer_sections;

        //Global variable for all footer sections
        public static List<string> footer_sections;

        //This method packages web page search results into
        //global variables.
        public static void Search_footer_content_section()
        {
            if (show_website.Equals("yes"))
            {
                connection = use_connection;

                number_of_footer_sections = Search_row_count();
                footer_sections = Search_footer_content();
            }
        }

        //The footer content is composed.
        public static string Request_footer_content()
        {
            string footer_content = "";

            if (show_website.Equals("yes"))
            {
                if (number_of_footer_sections > 0)
                {
                    views.Show_Footer_Content.footer_sections = footer_sections;

                    footer_content = views.Show_Footer_Content.Show_footer_content();
                }
            }

            return footer_content;
        }
    }
}