using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.models
{
    public abstract class Website_Links_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection;

        private static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        private static void Create_new_table()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE company_hyperlinks " +
                        "(row_id INT NOT NULL, link_name TEXT NOT NULL, " +
                        "page_url TEXT NOT NULL, open_new_window TEXT NOT NULL, " +
                        "date_received TEXT NOT NULL, time_received TEXT NOT NULL, " +
                        "PRIMARY KEY (row_id)) ENGINE = MYISAM;";

                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                LOGGER.Debug("The 'company_hyperlinks' " +
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
                    command.CommandText = "SELECT row_id FROM company_hyperlinks " +
                        "ORDER BY row_id ASC";

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

        protected static List<List<string>> Search_website_links()
        {
            List<List<string>> output = new List<List<string>>();
            List<string> name = new List<string>();
            List<string> url = new List<string>();
            List<string> new_window = new List<string>();
            int link_count = 0;

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT link_name, page_url, " +
                        "open_new_window FROM company_hyperlinks ORDER BY row_id ASC";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name.Add(reader.GetString("link_name"));
                            url.Add(reader.GetString("page_url"));
                            new_window.Add(reader.GetString("open_new_window"));

                            link_count++;
                        }
                    }
                }

                if (link_count < 1)
                {
                    name.Add("links not found");
                    url.Add("");
                    new_window.Add("");
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("The 'company_hyperlinks' " +
                    "table is corrupt or does not exist");

                Create_new_table();

                name.Add("page error");
                url.Add("");
                new_window.Add("");
            }

            output.Add(name);
            output.Add(url);
            output.Add(new_window);

            return output;
        }
    }
}
