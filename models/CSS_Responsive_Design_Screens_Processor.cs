using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace Timothys_Digital_Solutions_Company_Website_Windows.models
{
    public abstract class CSS_Responsive_Design_Screens_Processor
    {
        public static MySql.Data.MySqlClient.MySqlConnection connection;

        private static readonly NLog.Logger LOGGER = NLog.LogManager.GetCurrentClassLogger();

        private static void Create_new_table()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE " +
                        "company_css_responsive_design_screens (row_id INT NOT NULL, " +
                        "screen_ratio TEXT NOT NULL, css_code_for_screen_ratio " +
                        "TEXT NOT NULL, PRIMARY KEY (row_id)) ENGINE = MYISAM;";

                    command.ExecuteNonQuery();
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("The 'company_css_responsive_design_screens' " +
                    "table was not created because it already exists.  " +
                    "This is not necessarily an error.");
            }
        }

        private static void Add_new_records()
        {
            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO company_css_responsive_design_screens (row_id, screen_ratio, " +
                        "css_code_for_screen_ratio) VALUES\n" +
                        "(1, '@media only screen and (min-width: 2001px)', " +
                        "'.embeded_media { width: 45%; height: 600px; border: 0px solid transparent; " +
                        "margin-left: 2%; margin-right: 2%; margin-top: 5px; margin-bottom: 5px; padding: 0px; " +
                        "background-color: transparent; }\r\n#logo_traditional_and_links_traditional_format { " +
                        "text-align: left; width: 100%; }\r\n#logo_traditional_and_links_responsive_format { " +
                        "display: none; }\r\n#page_name_traditional_or_responsive_format { text-align: center; " +
                        "width: 100%; }\r\n.content_within_apps { vertical-align: top; text-align: left; " +
                        "width: 79%; padding-top: 1%; padding-bottom: 1%; margin-left: 10.5%; margin-right: 10.5%; " +
                        "}\r\n.content { vertical-align: top; text-align: left; width: 80%; padding-top: 1%; " +
                        "padding-bottom: 1%; margin-left: 10%; margin-right: 10%; }\r\n#footer_traditional_format " +
                        "{ text-align: left; width: 100%; }\r\n#footer_responsive_format { display: none; }'),\n" +
                        "(2, '@media only screen and (min-width: 1001px) and (max-width: 2000px)', '.embeded_media " +
                        "{ width: 45%; height: 400px; border: 0px solid transparent; margin-left: 2%; " +
                        "margin-right: 2%; margin-top: 5px; margin-bottom: 5px; padding: 0px; background-color: " +
                        "transparent; }\r\n#logo_traditional_and_links_traditional_format { text-align: left; " +
                        "width: 100%; }\r\n#logo_traditional_and_links_responsive_format { display: none; " +
                        "}\r\n#page_name_traditional_or_responsive_format { text-align: center; width: 100%; " +
                        "}\r\n.content_within_apps { vertical-align: top; text-align: left; width: 79%; " +
                        "padding-top: 1%; padding-bottom: 1%; margin-left: 10.5%; margin-right: 10.5%; " +
                        "}\r\n.content { vertical-align: top; text-align: left; width: 80%; padding-top: 1%; " +
                        "padding-bottom: 1%; margin-left: 10%; margin-right: 10%; }\r\n#footer_traditional_format { " +
                        "text-align: left; width: 100%; }\r\n#footer_responsive_format { display: none; }'),\n" +
                        "(3, '@media only screen and (min-width: 501px) and (max-width: 1000px)', '.embeded_media " +
                        "{ width: 98%; height: 600px; border: 0px solid transparent; margin-left: 2%; " +
                        "margin-right: 2%; margin-top: 5px; margin-bottom: 5px; padding: 0px; background-color: " +
                        "transparent; }\r\n#logo_traditional_and_links_traditional_format { display: none; " +
                        "}\r\n#logo_traditional_and_links_responsive_format { text-align: left; width: 100%; " +
                        "}\r\n#page_name_traditional_or_responsive_format { text-align: center; width: 100%; " +
                        "}\r\n.content_within_apps { vertical-align: top; text-align: left; width: 95%; padding-top: " +
                        "1%; padding-bottom: 1%; margin-left: 2.25%; margin-right: 2.25%; }\r\n.content { " +
                        "vertical-align: top; text-align: left; width: 95%; padding-top: 1%; padding-bottom: 1%; " +
                        "margin-left: 2.25%; margin-right: 2.25%; }\r\n#footer_traditional_format { display: none; " +
                        "}\r\n#footer_responsive_format { text-align: left; width: 100%; }'),\n" +
                        "(4, '@media only screen and (max-width: 500px)', '.embeded_media { width: 98%; height: " +
                        "300px; border: 0px solid transparent; margin-left: 2%; margin-right: 2%; margin-top: 5px; " +
                        "margin-bottom: 5px; padding: 0px; background-color: transparent; " +
                        "}\r\n#logo_traditional_and_links_traditional_format { display: none; " +
                        "}\r\n#logo_traditional_and_links_responsive_format { text-align: left; width: 100%; " +
                        "}\r\n#page_name_traditional_or_responsive_format { text-align: center; width: 100%; " +
                        "}\r\n.content_within_apps { vertical-align: top; text-align: left; width: 95%; " +
                        "padding-top: 1%; padding-bottom: 1%; margin-left: 2.25%; margin-right: 2.25%; " +
                        "}\r\n.content { vertical-align: top; text-align: left; width: 95%; padding-top: 1%; " +
                        "padding-bottom: 1%; margin-left: 2.25%; margin-right: 2.25%; " +
                        "}\r\n#footer_traditional_format { display: none; }\r\n#footer_responsive_format { " +
                        "text-align: left; width: 100%; }');";

                    command.ExecuteNonQuery();
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("");
            }
        }

        protected static List<List<string>> Search_css_responsive_design_screens()
        {
            List<List<string>> output = new List<List<string>>();
            List<string> element = new List<string>();
            List<string> attribute = new List<string>();
            int responsive_design_screen_count = 0;

            try
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT screen_ratio, " +
                    "css_code_for_screen_ratio FROM " +
                    "company_css_responsive_design_screens ORDER BY row_id DESC";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            element.Add(reader.GetString("screen_ratio"));
                            attribute.Add(reader.GetString("css_code_for_screen_ratio"));

                            responsive_design_screen_count++;
                        }
                    }
                }

                if (responsive_design_screen_count < 1)
                {
                    element.Add("responsive design screens not found");
                    attribute.Add("");
                }
            } catch (MySqlException)
            {
                LOGGER.Debug("The 'company_css_responsive_design_screens' " +
                    "table was not created because it already exists.  " +
                    "This is not necessarily an error.");

                Create_new_table();
                Add_new_records();

                element.Add("page error");
                attribute.Add("");
            }

            output.Add(element);
            output.Add(attribute);

            return output;
        }
    }
}
