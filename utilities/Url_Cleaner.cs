using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Find_And_Replace;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Form_Validation;

namespace Timothys_Digital_Solutions_Company_Website_Windows.utilities
{
    public class Url_Cleaner : configuration.Config
    {
        private static readonly char[] forward_slash = { '/' };
        private static readonly char[] question_mark = { '?' };

        public static string After_domain_and_before_directory(string url)
        {
            string output = "";
            string[] parts = url.Split(forward_slash, 2);

            if (parts.Length == 2)
            {
                if (!(parts[1].Equals("")))
                {
                    output += parts[1];
                }
            }

            return output;
        }

        public static string Erase_last_slash_in_url(string url)
        {
            string output = "";
            string[] parts = url.Split(forward_slash, 1);
            List<string> find = new List<string>();
            List<string> replace = new List<string>();

            //find substrings
            find.Add("/");

            //replacement substrings
            replace.Add("");

            if (parts.Length == 1)
            {
                if (!(parts[0].Equals("")))
                {
                    output += Find_And_Replace.Find_and_replace(find, replace, parts[0]);
                }
            }

            return output;
        }

        public static string Ignore_remaining_url_after_question_mark(string url)
        {
            string output = "";
            string[] parts = url.Split(question_mark, 2);

            if (parts.Length == 1)
            {
                if (!(parts[0].Equals("")))
                {
                    output += parts[0];
                }
            }

            return output;
        }

        public static string Check_for_www(string url, string page)
        {
            string output = "";
            string page_query;
            string bad_query;
            string bad_domain_found = "";

            if (page.Equals("null") || utilities.Form_Validation.Is_string_null_or_whitespace(page))
            {
                List<string> each_bad_domain_home_page = Bad_domain();

                for (int row = 0; row < each_bad_domain_home_page.Count; row++)
                {
                    if (url.Equals(each_bad_domain_home_page[row]))
                    {
                        bad_domain_found = "yes";
                    }
                }

                //Website redirects to home page.
                if (bad_domain_found.Equals("yes"))
                {
                    output = "redirect to root directory";
                }
            }
            else
            {
                List<string> each_bad_domain_other_page = Bad_domain();

                page_query = url + "/index.php?page=" + page;

                for (int row = 0; row < each_bad_domain_other_page.Count; row++)
                {
                    bad_query = each_bad_domain_other_page[row] + "/index.php?page=" + page;

                    if (page_query.Equals(bad_query))
                    {
                        bad_domain_found = "yes";
                    }
                }

                //Website redirects to page query.
                if (bad_domain_found.Equals("yes"))
                {
                    output = "redirect to page query";
                }
            }

            return output;
        }
    }
}