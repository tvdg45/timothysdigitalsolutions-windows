using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_CSS_Responsive_Design_Screens
    {
        public static List<List<string>> responsive_design_screens;

        public static string Show_responsive_design_screens()
        {
            string output = "";

            output += "<style type=\"text/css\">\n";

            for (int i = 0; i < responsive_design_screens[0].Count; i++)
            {
                output += responsive_design_screens[0][i] + " {\n\n";
                output += responsive_design_screens[1][i] + "\n\n";
                output += "\n}\n\n";
            }

            output += "</style>";

            return output;
        }
    }
}
