using System;
using System.Collections.Generic;
using static Timothys_Digital_Solutions_Company_Website_Windows.configuration.Config;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_Website_Logo
    {
        public static string file_path;

        public static string No_logo_found()
        {
            string output;

            output = "<a href=\"" + configuration.Config.Domain() + "\">" +
                    "<img alt=\"no-file.png\" " +
                    "src=\"" + configuration.Config.Domain() + "/images/no-file.png\" " +
                    "style=\"width: 50%\" /></a>";

            return output;
        }

        public static string Logo_found()
        {
            string output;

            output = "<a href=\"https://www.timothysdigitalsolutions.com/\">" +
                    "<img alt=\"" + file_path + "\" " +
                    "src=\"" + configuration.Config.Domain() + "/media/" + file_path + "\" " +
                    "style=\"width: 50%\" /></a>";

            return output;
        }
    }
}