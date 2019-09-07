using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_Footer_Content
    {
        public static List<string> footer_sections;

        public static string Show_footer_content()
        {
            string output;

            switch (footer_sections[0])
            {
                case "footer content not found":
                    output = "";
                break;
                case "page error":
                    output = "";
                break;
                default:
                    output = "";

                    for (int i = 0; i < footer_sections.Count; i++)
                    {
                        if (!(footer_sections[i].Equals("footer content found")))
                        {
                            output += "<div class=\"footer\" style=\"text-align: " +
                                "left; word-wrap: break-word\">\n";
                            output += "<div class=\"content_within_apps\">" +
                                footer_sections[i] + "</div>";
                            output += "</div>\n";
                        }
                    }
                break;
            }

            return output;
        }
    }
}