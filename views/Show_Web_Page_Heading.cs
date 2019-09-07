using System;
using System.Collections.Generic;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Find_And_Replace;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_Web_Page_Heading
    {
        public static string website_name;
        public static string page_description;
        public static string page_keywords;
        public static string page_name;

        public static string Show_description()
        {
            string output;

            if (page_description.Equals("no description"))
            {
                output = "";
            } else
            {
                output = "<script>$('head').append('<meta name=\"description\" content=\"" +
                        page_description + "\" />');</script>\n";
            }

            return output;
        }

        public static string Show_keywords()
        {
            string output;

            if (page_keywords.Equals("no keywords"))
            {
                output = "";
            } else
            {
                output = "<script>$('head').append('<meta name=\"keywords\" content=\"" +
                        page_keywords + "\" />');</script>\n";
            }

            return output;
        }

        public static string Show_title()
        {
            string output;

            List<string> find = new List<string>();
            List<string> replace = new List<string>();

            find.Add("'");
            replace.Add("\\'");

            switch (page_name)
            {
                case "no web pages":
                    output = "<script>$('title').append('There are no web pages.  " +
                        "Come back later. | " +
                            utilities.Find_And_Replace.Find_and_replace(find, replace,
                            website_name) + "');</script>\n";
                    break;
                case "page not found":
                    output = "<script>$('title').append('Shoot!  That page does not exist! | " +
                            utilities.Find_And_Replace.Find_and_replace(find, replace,
                            website_name) + "');</script>\n";
                    break;
                default:
                    if (page_name.Equals("Home") || page_name.Equals("page error")
                        || page_name.Equals("no page title"))
                    {
                        output = "<script>$('title').append('" +
                                utilities.Find_And_Replace.Find_and_replace(find, replace,
                                website_name) + "');</script>\n";
                    }
                    else
                    {
                        output = "<script>$('title').append('" +
                                utilities.Find_And_Replace.Find_and_replace(find,
                                replace, page_name) +
                                " | " + utilities.Find_And_Replace.Find_and_replace(find,
                                replace, website_name) +
                                "');</script>\n";
                    }
                    break;
            }

            return output;
        }
    }
}