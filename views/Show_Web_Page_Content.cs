using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_Web_Page_Content
    {
        public static string page_content;

        public static string Show_content()
        {
            string output;

            switch (page_content)
            {
                case "no web pages":
                    output = "<label style=\"font-size: 12pt\"><b>There are " +
                            "no web pages.  Come back later.</b></label>\n";
                    break;
                case "page not found":
                    output = "<label style=\"font-size: 12pt\"><b>Shoot!  " +
                            "That page does not exist!</b></label>\n";
                    break;
                case "no content":
                    output = "<label style=\"font-size: 12pt\"><b>There is " +
                            "no content.  Come back later.</b></label>\n";
                    break;
                case "page error":
                    output = "<label style=\"font-size: 12pt\"><b>There is " +
                            "no content.  Come back later.</b></label>\n";
                    break;
                default:
                    output = page_content;
                    break;
            }

            return output;
        }
    }
}