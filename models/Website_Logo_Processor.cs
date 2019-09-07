using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.models
{
    public abstract class Website_Logo_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection;

        private static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        private static void Create_new_table()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE company_website_logo " +
                        "(row_id INT NOT NULL, file_path TEXT NOT NULL, " +
                        "date_received TEXT NOT NULL, time_received TEXT NOT NULL, " +
                        "PRIMARY KEY (row_id)) ENGINE = MYISAM;";

                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                LOGGER.Debug("The 'company_website_logo' " +
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
                    command.CommandText = "SELECT row_id FROM company_website_logo " +
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

        protected static string Search_website_logo()
        {
            string output = "";

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT file_path FROM " +
                        "company_website_logo ORDER BY row_id ASC LIMIT 1";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = reader.GetString("file_path");
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                LOGGER.Debug("The 'company_website_logo' " +
                    "table is corrupt or does not exist");

                Create_new_table();

                output = "page error";
            }

            return output;
        }
    }
}