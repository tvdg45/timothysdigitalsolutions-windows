using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.configuration.Config;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_Web_Page_Heading;
using static Timothys_Digital_Solutions_Company_Website_Windows.views.Show_Web_Page_Content;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.controllers
{
    public class Request_Web_Page : models.Web_Page_Processor
    {
        public static string website_name;
        public static string url;
        public static string page;
        public static string page_preview;
        public static string show_website;
        public static MySql.Data.MySqlClient.MySqlConnection use_connection;

        //Global variable for total number of web pages
        public static int number_of_web_pages;

        //Global variable for all web page fields
        public static List<string> web_page;

        //This method packages web page search results into
        //global variables.
        public static void Search_web_page()
        {
            if (show_website.Equals("yes"))
            {
                connection = use_connection;

                if (url.Equals("null"))
                {
                    url = configuration.Config.Domain();
                }

                Set_url(url);
                Set_page(page);

                number_of_web_pages = Search_row_count();
                web_page = Search_web_pages();
            }
        }

        //The web page description is composed.
        public static string Request_page_description()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                views.Show_Web_Page_Heading.page_description = "no description";

                if (number_of_web_pages > 0)
                {
                    try
                    {
                        if (!(web_page[0].Equals("page error"))
                            && !(web_page[0].Equals("page not found"))
                            && (web_page[0].Equals("page found")
                            && !(web_page[4].Equals(""))))
                        {

                            views.Show_Web_Page_Heading.page_description = web_page[4];
                        }
                    } catch (Exception)
                    {
                        views.Show_Web_Page_Heading.page_description = "no description";
                    }
                }

                output = views.Show_Web_Page_Heading.Show_description();
            }

            return output;
        }

        //The web page keywords are composed.
        public static string Request_page_keywords()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                views.Show_Web_Page_Heading.page_keywords = "no keywords";

                if (number_of_web_pages > 0)
                {
                    try
                    {
                        if (!(web_page[0].Equals("page error"))
                            && !(web_page[0].Equals("page not found"))
                            && (web_page[0].Equals("page found")
                            && !(web_page[5].Equals(""))))
                        {
                            views.Show_Web_Page_Heading.page_keywords = web_page[5];
                        }
                    } catch (Exception)
                    {
                        views.Show_Web_Page_Heading.page_keywords = "no keywords";
                    }
                }

                output = views.Show_Web_Page_Heading.Show_keywords();
            }

            return output;
        }

        //The web page title is composed.
        public static string Request_title()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                views.Show_Web_Page_Heading.website_name = website_name;

                if (number_of_web_pages < 1)
                {
                    views.Show_Web_Page_Heading.page_name = "no web pages";
                }
                else
                {
                    try
                    {
                        switch (web_page[0])
                        {
                            case "page error":
                                views.Show_Web_Page_Heading.page_name = web_page[0];
                                break;
                            case "page not found":
                                views.Show_Web_Page_Heading.page_name = web_page[0];
                                break;
                            default:
                                views.Show_Web_Page_Heading.page_name = web_page[3];
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        views.Show_Web_Page_Heading.page_name = "no page title";
                    }
                }

                output = views.Show_Web_Page_Heading.Show_title();
            }

            return output;
        }

        //The web page body is composed.
        public static string Request_content()
        {
            string output = "";

            if (show_website.Equals("yes"))
            {
                if (number_of_web_pages < 1)
                {
                    views.Show_Web_Page_Content.page_content = "no web pages";
                } else
                {
                    try
                    {
                        if (web_page[0].Equals("page error"))
                        {
                            views.Show_Web_Page_Content.page_content = web_page[0];
                        }
                        else if (web_page[0].Equals("page not found"))
                        {
                            views.Show_Web_Page_Content.page_content = web_page[0];
                        }
                        else if (web_page[0].Equals("page found")
                          && web_page[6].Equals(""))
                        {
                            views.Show_Web_Page_Content.page_content = "no content";
                        }
                        else
                        {
                            views.Show_Web_Page_Content.page_content = web_page[6];
                        }
                    } catch (Exception)
                    {
                        views.Show_Web_Page_Content.page_content = "no content";
                    }
                }

                output = views.Show_Web_Page_Content.Show_content();
            }

            return output;
        }
    }
}