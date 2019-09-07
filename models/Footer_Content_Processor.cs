using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.models
{
    public abstract class Footer_Content_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection;

        private static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        private static void Create_new_table()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE company_footer_content " +
                        "(row_id INT NOT NULL, footer_content TEXT NOT NULL, " +
                        "date_received TEXT NOT NULL, time_received TEXT NOT NULL, " +
                        "PRIMARY KEY (row_id)) ENGINE = MYISAM;";

                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                LOGGER.Debug("The 'company_footer_content' " +
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
                    command.CommandText = "SELECT row_id FROM " +
                    "company_footer_content ORDER BY row_id DESC";

                    output = (int)command.ExecuteScalar();
                }
            } catch (MySqlException e)
            {
                LOGGER.Debug(e);

                output = 0;
            }

            return output;
        }

        protected static List<string> Search_footer_content()
        {
            List<string> output = new List<string>();
            int footer_section_count = 0;

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT footer_content FROM " +
                        "company_footer_content ORDER BY row_id ASC";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output.Add("footer content found");
                            output.Add(reader.GetString("footer_content"));

                            footer_section_count++;
                        }
                    }
                }

                if (footer_section_count == 0)
                {
                    output.Add("footer content not found");
                }
            }
            catch (MySqlException)
            {
                LOGGER.Debug("The 'company_footer_content' " +
                    "table is corrupt or does not exist");

                Create_new_table();

                output.Add("page error");
            }

            return output;
        }
    }
}