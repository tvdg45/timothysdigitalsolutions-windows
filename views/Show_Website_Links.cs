using System;
using System.Collections.Generic;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Find_And_Replace;
using static Timothys_Digital_Solutions_Company_Website_Windows.configuration.Config;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.views
{
    public class Show_Website_Links
    {
        public static List<List<string>> website_links;
        public static string url;
        public static string page;

        private static string Url_constructor()
        {
            string output;

            if (utilities.Form_Validation.Is_string_null_or_whitespace(page))
            {
                output = url;
            }
            else
            {
                output = configuration.Config.Domain() + "/" + page;
            }

            return output;
        }

        //Unfocused menu label for horizonal link format
        private static string Unfocused_menu_label_horizonal_format(string link_name,
            string url, string new_window)
        {
            string output = "";

            //Open link in new tab
            if (new_window.Equals("yes"))
            {
                if (link_name.Length <= 60)
                {
                    output += "<span class=\"menu_label\" style=\"line-height: 40px; " +
                        "font-size: 12pt\"><a target=\'_blank\' style=\"" +
                        "padding-left: 15px; padding-right: 15px; margin-top: 12px; " +
                        "margin-bottom: 12px; font-weight: bold; " +
                        "text-transform: uppercase; white-space: nowrap\"" +
                        "href=\"" + url + "\">" + link_name + "</a></span>\n";
                }
                else
                {
                    output += "<span class=\"menu_label\" style=\"line-height: 40px; " +
                        "font-size: 12pt\"><a target=\'_blank\' style=\"" +
                        "padding-left: 15px; padding-right: 15px; margin-top: 12px; " +
                        "margin-bottom: 12px; font-weight: bold; " +
                        "text-transform: uppercase; white-space: normal\"" +
                        "href=\"" + url + "\">" + link_name + "</a></span>\n";
                }
            }
            else
            {
                if (link_name.Length <= 60)
                {
                    output += "<span class=\"menu_label\" style=\"line-height: 40px; " +
                        "font-size: 12pt\"><a style=\"padding-left: 15px; " +
                        "padding-right: 15px; margin-top: 12px; " +
                        "margin-bottom: 12px; font-weight: bold; " +
                        "text-transform: uppercase; white-space: nowrap\"" +
                        "href=\"" + url + "\">" + link_name + "</a></span>\n";
                }
                else
                {
                    output += "<span class=\"menu_label\" style=\"line-height: 40px; " +
                        "font-size: 12pt\"><a style=\"padding-left: 15px; " +
                        "padding-right: 15px; margin-top: 12px; margin-bottom: 12px; " +
                        "font-weight: bold; text-transform: uppercase; " +
                        "white-space: normal\" href=\"" + url + "\">" +
                        link_name + "</a></span>\n";
                }
            }

            return output;
        }

        //If a link is focused on this means that a loaded web page
        //url matches a page link url.
        public static string Show_website_links_horizontal_format()
        {
            string output = "";

            for (int i = 0; i < website_links[0].Count; i++)
            {
                if (Url_constructor().Equals(configuration.Config.Domain())
                    || Url_constructor().Equals(configuration.Config.Domain() + "/"))
                {
                    //Any link that is not focused on
                    output += Unfocused_menu_label_horizonal_format(website_links[0][i],
                            website_links[1][i], website_links[2][i]);
                }
                else if (website_links[1][i].Contains(Url_constructor()) &&
                  !(Url_constructor().Equals(configuration.Config.Domain())
                  || Url_constructor().Equals(configuration.Config.Domain() + "/")))
                {
                    //Open link in new tab
                    if (website_links[2][i].Equals("yes"))
                    {
                        if (website_links[0][i].Length <= 60)
                        {
                            output += "<span class=\"focused_menu_label\" " +
                                "style=\"line-height: 40px; font-size: 12pt\">"
                                + "<a target=\'_blank\' style=\"padding-left: 15px; " +
                                "padding-right: 15px; margin-top: 12px; " +
                                "margin-bottom: 12px; font-weight: bold; " +
                                "text-transform: uppercase; white-space: nowrap\" href=\"" +
                                website_links[1][i] + "\">" +
                                website_links[0][i] + "</a></span>\n";
                        } else
                        {
                            output += "<span class=\"focused_menu_label\" " +
                                "style=\"line-height: 40px; font-size: 12pt\">"
                                + "<a target=\'_blank\' style=\"padding-left: 15px; " +
                                "padding-right: 15px; margin-top: 12px; " +
                                "margin-bottom: 12px; font-weight: bold; " +
                                "text-transform: uppercase; " +
                                "white-space: normal\" href=\"" + website_links[1][i] +
                                "\">" + website_links[0][i] + "</a></span>\n";
                        }
                    } else
                    {
                        if (website_links[0][i].Length <= 60)
                        {
                            output += "<span class=\"focused_menu_label\" " +
                                "style=\"line-height: 40px; font-size: 12pt\">"
                                + "<a style=\"padding-left: 15px; padding-right: 15px; " +
                                "margin-top: 12px; margin-bottom: 12px; " +
                                "font-weight: bold; text-transform: uppercase; " +
                                "white-space: nowrap\" href=\"" + website_links[1][i]
                                + "\">" + website_links[0][i] + "</a></span>\n";
                        }
                        else
                        {
                            output += "<span class=\"focused_menu_label\" " +
                                "style=\"line-height: 40px; font-size: 12pt\">"
                                + "<a style=\"padding-left: 15px; padding-right: 15px; " +
                                "margin-top: 12px; margin-bottom: 12px; " +
                                "font-weight: bold; text-transform: uppercase; " +
                                "white-space: normal\" href=\"" + website_links[1][i] + "\">" +
                                website_links[0][i] + "</a></span>\n";
                        }
                    }
                } else
                {
                    //Any link that is not focused on
                    output += Unfocused_menu_label_horizonal_format(
                        website_links[0][i], website_links[1][i],
                        website_links[2][i]);
                }
            }

            return output;
        }

        //Unfocused menu label for vertical link format
        private static string Unfocused_menu_label_vertical_format(string link_name,
            string url, string new_window)
        {
            string output = "";

            //Open link in new tab
            if (new_window.Equals("yes"))
            {
                output += "<div class=\"show_vertical_menu\" style=\"text-align: left; " +
                    "display: none\"><span class=\"menu_label\" " +
                    "style=\"line-height: 40px; font-size: 12pt\">" +
                    "<a target=\"_blank\" style=\"padding-left: 15px; " +
                    "padding-right: 15px; margin-top: 12px; " +
                    "margin-bottom: 12px; font-weight: bold; text-transform: uppercase; " +
                    "white-space: normal\" href=\"" + url + "\">" + link_name +
                    "</a></span>\n" +
                    "</div>\n";
            } else
            {
                output += "<div class=\"show_vertical_menu\" style=\"text-align: left; " +
                    "display: none\"><span class=\"menu_label\" " +
                    "style=\"line-height: 40px; font-size: 12pt\">" +
                    "<a style=\"padding-left: 15px; padding-right: 15px; " +
                    "margin-top: 12px; margin-bottom: 12px; font-weight: bold; " +
                    "text-transform: uppercase; white-space: normal\" href=\"" +
                    url + "\">" + link_name + "</a></span>\n" +
                    "</div>\n";
            }

            return output;
        }

        //If a link is focused on this means that a loaded web page
        //url matches a page link url.
        public static string Show_website_links_vertical_format()
        {
            string output = "";

            for (int i = 0; i < website_links[0].Count; i++)
            {
                if (Url_constructor().Equals(configuration.Config.Domain())
                    || Url_constructor().Equals(configuration.Config.Domain() + "/"))
                {
                    //Any link that is not focused on
                    output += Unfocused_menu_label_vertical_format(website_links[0][i],
                            website_links[1][i], website_links[2][i]);
                }
                else if (website_links[1][i].Contains(Url_constructor()) &&
                  !(Url_constructor().Equals(configuration.Config.Domain())
                  || Url_constructor().Equals(configuration.Config.Domain() + "/")))
                {
                    //Open link in new tab
                    if (website_links[2][i].Equals("yes"))
                    {
                        output += "<div class=\"show_vertical_menu\" " +
                            "style=\"text-align: left; display: none\">" +
                            "<span class=\"focused_menu_label\" style=\"line-height: 40px; " +
                            "font-size: 12pt\"><a target=\"_blank\" " +
                            "style=\"padding-left: 15px; padding-right: 15px; " +
                            "margin-top: 12px; margin-bottom: 12px; font-weight: bold; " +
                            "text-transform: uppercase; white-space: normal\" href=\"" +
                            website_links[1][i] + "\">" + website_links[0][i] +
                            "</a></span>\n" +
                            "</div>\n";
                    }
                    else
                    {
                        output += "<div class=\"show_vertical_menu\" " +
                            "style=\"text-align: left; display: none\">" +
                            "<span class=\"focused_menu_label\" style=\"line-height: 40px; " +
                            "font-size: 12pt\"><a style=\"padding-left: 15px; " +
                            "padding-right: 15px; margin-top: 12px; " +
                            "margin-bottom: 12px; font-weight: bold; " +
                            "text-transform: uppercase; white-space: normal\" href=\"" +
                            website_links[1][i] + "\">" + website_links[0][i] +
                            "</a></span>\n" +
                            "</div>\n";
                    }
                }
                else
                {
                    //Any link that is not focused on
                    output += Unfocused_menu_label_vertical_format(website_links[0][i],
                            website_links[1][i], website_links[2][i]);
                }
            }

            return output;
        }
    }
}