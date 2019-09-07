using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_Website_Links;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_Website_Links : models.Website_Links_Processor
    {
        public static string show_website;
        public static string url;
        public static string page;
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        //Global variable for total number of web pages
        public static int number_of_website_links;

        //Global variable for all website link fields
        public static List<List<string>> website_links;

        //This method packages web page search results into
        //global variables.
        public static void Search_website_link()
        {
            if (show_website.Equals("yes"))
            {
                connection = use_connection;

                number_of_website_links = Search_row_count();
                website_links = Search_website_links();
            }
        }

        //The web page links are composed.
        public static string Request_website_links_horizontal_format()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                if (number_of_website_links > 0)
                {
                    if (!(website_links[0][0].Equals("links not found"))
                            && !(website_links[0][0].Equals("page error")))
                    {
                        views.Show_Website_Links.url = url;
                        views.Show_Website_Links.page = page;
                        views.Show_Website_Links.website_links = website_links;

                        output += views.Show_Website_Links.Show_website_links_horizontal_format();
                    }
                }
            }

            return output;
        }

        //The web page links are composed.
        public static string Request_website_links_vertical_format()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                if (number_of_website_links > 0)
                {
                    if (!(website_links[0][0].Equals("links not found"))
                            && !(website_links[0][0].Equals("page error")))
                    {
                        views.Show_Website_Links.url = url;
                        views.Show_Website_Links.page = page;
                        views.Show_Website_Links.website_links = website_links;

                        output += views.Show_Website_Links.Show_website_links_vertical_format();
                    }
                }
            }

            return output;
        }
    }
}