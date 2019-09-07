using System;
using System.Collections.Generic;
using static Timothys_Digital_Solutions_Company_Website_Windows.configuration.Config;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_Website_Icon
    {
        public static string file_path;

        public static string No_icon_found()
        {
            string output;

            output = "<script>$('head').append('<link rel=\"icon\" href=\"" +
                configuration.Config.Domain() +
                "/images/no-file.png\" sizes=\"32x32\" />');</script>\n";

            return output;
        }

        public static string Icon_found()
        {
            string output;

            output = "<script>$('head').append('<link rel=\"icon\" href=\"" +
                configuration.Config.Domain() +
                "/media/" + file_path + "\" sizes=\"32x32\" />');</script>\n";

            return output;
        }
    }
}