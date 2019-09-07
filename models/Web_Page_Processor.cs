using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.configuration.Config;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Url_Cleaner;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Find_And_Replace;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.models
{
    public abstract class Web_Page_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection;

        private static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        //global variables
        private static string url;
        private static string page;

        //mutators
        protected static void Set_url(string this_url)
        {
            url = this_url;
        }

        protected static void Set_page(string this_page)
        {
            page = this_page;
        }

        //accessors
        private static string Get_url()
        {
            return url;
        }

        private static string Get_page()
        {
            return page;
        }

        private static void Create_new_table()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE company_web_pages " +
                        "(row_id INT NOT NULL, page_content_draft TEXT NOT NULL, " +
                        "page_name TEXT NOT NULL, page_description TEXT NOT NULL, " +
                        "page_keywords TEXT NOT NULL, page_content TEXT NOT NULL, " +
                        "page_directory TEXT NOT NULL, page_status TEXT NOT NULL, " +
                        "date_received TEXT NOT NULL, time_received TEXT NOT NULL, " +
                        "PRIMARY KEY (row_id)) ENGINE = MYISAM;";

                    command.ExecuteNonQuery();
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("The 'company_web_pages' " +
                    "table was not created because it already exists.  " +
                    "This is not necessarily an error.");
            }
        }

        protected static int Search_row_count()
        {
            int output;

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT row_id FROM company_web_pages " +
                    "ORDER BY row_id DESC";

                    output = (int)command.ExecuteScalar();
                }
            }
            catch (MySqlException e)
            {
                LOGGER.Debug(e);

                output = 0;
            }

            return output;
        }

        //Search web page details based on URL or page query.
        protected static List<string> Search_web_pages()
        {
            List<string> output = new List<string>();
            List<string> find = new List<string>();
            List<string> replace = new List<string>();
            string page_directory;
            int page_count = 0;

            string get_url = Get_url();
            string get_page = Get_page();

            get_url = utilities.Url_Cleaner.After_domain_and_before_directory(get_url);
            get_url = utilities.Url_Cleaner.Erase_last_slash_in_url(get_url);
            page_directory = utilities.Url_Cleaner.Ignore_remaining_url_after_question_mark(get_url);

            //find values
            find.Add(Domain().Replace("https://", ""));

            //replace values
            replace.Add("");

            page_directory = utilities.Find_And_Replace.Find_and_replace(find,
                replace, page_directory);

            if (page_directory.Equals(""))
            {
                page_directory = "home";
            }

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT row_id, page_content_draft, " +
                        "page_name, page_description, page_keywords, page_content, " +
                        "page_directory, page_status, date_received, time_received " +
                        "FROM company_web_pages WHERE " +
                        "page_directory = @prepare_page_directory " +
                        "ORDER BY row_id DESC LIMIT 1";

                    if (!(utilities.Form_Validation.Is_string_null_or_whitespace(get_page)))
                    {
                        command.Parameters.AddWithValue("@prepare_page_directory",
                            get_page);
                    } else
                    {
                        command.Parameters.AddWithValue("@prepare_page_directory",
                            page_directory);
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output.Add("page found");
                            output.Add(reader.GetUInt64("row_id").ToString());
                            output.Add(reader.GetString("page_content_draft"));
                            output.Add(reader.GetString("page_name"));
                            output.Add(reader.GetString("page_description"));
                            output.Add(reader.GetString("page_keywords"));
                            output.Add(reader.GetString("page_content"));
                            output.Add(reader.GetString("page_directory"));
                            output.Add(reader.GetString("page_status"));
                            output.Add(reader.GetString("date_received"));
                            output.Add(reader.GetString("time_received"));

                            page_count++;
                        }
                    }
                }

                if (page_count == 0)
                {
                    output.Add("page not found");
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("The 'company_web_pages' " +
                    "table is corrupt or does not exist");

                Create_new_table();

                output.Add("page error");
            }

            return output;
        }
    }
}