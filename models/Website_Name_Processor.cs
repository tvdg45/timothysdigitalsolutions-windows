using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using static Timothys_Digital_Solutions_Company_Website_Windows.utilities.Form_Validation;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.models
{
    public abstract class Website_Name_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection;

        private static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        private static void Create_new_table()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE company_website_name (row_id " +
                        "INT NOT NULL, name TEXT NOT NULL, date_received " +
                        "TEXT NOT NULL, time_received TEXT NOT NULL, PRIMARY KEY " +
                        "(row_id)) ENGINE = MYISAM;";

                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {
                LOGGER.Debug("The 'company_website_name' " +
                    "table was not created because it already exists.  " +
                    "This is not necessarily an error.");
            }
        }

        protected static string Search_website_name()
        {
            string output = "";
            int website_name_count = 0;

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM company_website_name " +
                        "ORDER BY row_id DESC LIMIT 1";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            output = reader.GetString("name").ToString();

                            website_name_count++;
                        }
                    }
                }

                if (utilities.Form_Validation.Is_string_null_or_whitespace(output))
                {
                    output = "Timothy\'s Digital Solutions Framework";
                }

                if (website_name_count == 0)
                {
                    output = "Timothy\'s Digital Solutions Framework";
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("The 'company_website_name' " +
                    "table is corrupt or does not exist");

                Create_new_table();

                output = "Timothy\'s Digital Solutions Framework";
            }

            return output;
        }
    }
}
