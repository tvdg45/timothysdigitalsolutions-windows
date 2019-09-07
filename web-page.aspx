<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="web-page.aspx.cs" Inherits="Timothys_Digital_Solutions_Company_Website_Windows.Web_page" %>
<%
    MySql.Data.MySqlClient.MySqlConnection use_open_connection = Timothys_Digital_Solutions_Company_Website_Windows.configuration.Config.OpenConnection();

    string url = Request.Form["url"];
    string page = Request.Form["page"];
    string page_preview = Request.Form["page_preview"];
    string show_website = Request.Form["show_website"];
    string print_web_page = "";

    if (Timothys_Digital_Solutions_Company_Website_Windows.utilities.Form_Validation.Is_string_null_or_whitespace(url))
    {
        url = "";
    }

    if (Timothys_Digital_Solutions_Company_Website_Windows.utilities.Form_Validation.Is_string_null_or_whitespace(page))
    {
        page = "";
    }

    if (Timothys_Digital_Solutions_Company_Website_Windows.utilities.Form_Validation.Is_string_null_or_whitespace(page_preview))
    {
        page_preview = "";
    }

    if (Timothys_Digital_Solutions_Company_Website_Windows.utilities.Form_Validation.Is_string_null_or_whitespace(show_website))
    {
        show_website = "";
    }

    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_CSS_Responsive_Design_Screens.show_website = Convert.ToString(show_website);

    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.show_website = Convert.ToString(show_website);

    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.url = Convert.ToString(url);
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.page = Convert.ToString(page);
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.page_preview = Convert.ToString(page_preview);
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.show_website = Convert.ToString(show_website);
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.use_connection = use_open_connection;

    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.url = Convert.ToString(url);
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.page = Convert.ToString(page);
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.show_website = Convert.ToString(show_website);

    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.use_connection = use_open_connection;
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_CSS_Responsive_Design_Screens.use_connection = use_open_connection;
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Icon.use_connection = use_open_connection;
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Logo.use_connection = use_open_connection;
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Name.use_connection = use_open_connection;

    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Footer_Content.show_website = Convert.ToString(show_website);

    //Search for web page
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.Search_web_page();

    //Search for website links
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.Search_website_link();

    //Search for footers
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Footer_Content.use_connection = use_open_connection;
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Footer_Content.Search_footer_content_section();

    //Find website name
    Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.website_name = Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Name.Request_website_name();

    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Icon.Request_website_icon() + "\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_CSS_Responsive_Design_Screens.Request_css_responsive_design_screens() + "\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.Request_page_description() + "\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.Request_page_keywords() + "\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.Request_title() + "\n";
    print_web_page += "<script>document.body.style.backgroundColor = \"#FBDFCC\";</script>\n\n";
    print_web_page += "<style type=\"text/css\">\n";
    print_web_page += "p, label, ul, ol, .pre_header { font-family: normal normal normal 'Open Sans', sans-serif; font-size: 12pt; color: #000000; cursor: text; }\n";
    print_web_page += ".footer p, .footer label, .footer ul, .footer ol { font-family: normal normal normal 'Open Sans', sans-serif; font-size: 12pt; color: #C88D81; cursor: text; }\n";
    print_web_page += "a { text-decoration: none; color: #C88D81; }\n";
    print_web_page += "a:hover { text-decoration: none; color: #C88D81; }\n";
    print_web_page += "a:visited { text-decoration: none; color: #C88D81; }\n";
    print_web_page += ".all_notifications a, #responsive_page_content a { text-decoration: none; color: #FBDFCC; }\n";
    print_web_page += ".all_notifications a:hover, #responsive_page_content a:hover { text-decoration: none; color: #FBDFCC; }\n";
    print_web_page += ".all_notifications a:visited, #responsive_page_content a:visited { text-decoration: none; color: #FBDFCC; }\n";
    print_web_page += ".show_vertical_menu { display: none; }\n";
    print_web_page += "#show_vertical_menu { display: none; text-align: right; color: #C88D81; width: 100%; }\n";
    print_web_page += "#hide_vertical_menu { display: none; text-align: right; color: #C88D81; width: 100%; }\n";
    print_web_page += "#click_show_vertical_menu:hover { cursor: pointer; text-align: right; color: #C88D81; width: 100%; }\n";
    print_web_page += "#click_hide_vertical_menu:hover { cursor: pointer; text-align: right; color: #C88D81; width: 100%; }\n";
    print_web_page += ".menu_label a { font-family: normal normal normal 'Open Sans', sans-serif; font-size: 12pt; }\n";
    print_web_page += ".menu_label a:hover { font-family: normal normal normal 'Open Sans', sans-serif; font-size: 12pt; color: #FBDFCC; }\n";
    print_web_page += ".focused_menu_label a { font-family: normal normal normal 'Open Sans', sans-serif; font-size: 12pt; color: #FBDFCC; }\n";
    print_web_page += ".focused_menu_label a:hover { font-family: normal normal normal 'Open Sans', sans-serif; font-size: 12pt; color: #FBDFCC; }\n";
    print_web_page += ".pre_header a, .content a { text-decoration: none; font-family: normal normal normal 'Open Sans', sans-serif; color: #5A403B; }\n";
    print_web_page += ".pre_header a:hover, .content a:hover { text-decoration: underline; }\n";
    print_web_page += ".content a:visited { text-decoration: none; font-family: normal normal normal 'Open Sans', sans-serif; color: #5A403B; }\n";
    print_web_page += ".foot_label { color: #C88D81; }\n";
    print_web_page += ".footer a, .foot_label a { color: #FBDFCC; }\n";
    print_web_page += ".footer a:hover, .foot_label a:hover { text-decoration: underline; }\n\n";
    print_web_page += ".signature_section {\n\n";
    print_web_page += "background-color: #5A403B;\n";
    print_web_page += "background-image: -webkit-repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "background-image: -moz-repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "background-image: -o-repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "background-image: repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "-webkit-background-size: 4px 4px;\n";
    print_web_page += "-moz-background-size: 4px 4px;\n";
    print_web_page += "background-size: 4px 4px;\n";
    print_web_page += "}\n\n";
    print_web_page += "input { font-family: arial, sans-serif; font-size: 12pt; background-color: #5A403B; color: #FBDFCC; border: 2px solid; padding: 2px; border-color: #5A403B; }\n";
    print_web_page += "input[type=text], input[type=password], textarea, select { font-family: arial, sans-serif; font-size: 12pt; background-color: white; color: #5A403B; border: 2px solid; padding: 2px; border-color: #5A403B; }\n";
    print_web_page += "input[type=text]:focus, input[type=password]:focus, select:focus, textarea:focus { background-color: white; border-color: #5A403B; color: #5A403B; border: 2px solid; padding: 2px; cursor: pointer; }\n";
    print_web_page += "input[type=submit]:hover, input[type=button]:hover, input[type=submit]:focus, input[type=button]:focus { background-color: transparent; border-color: #5A403B; color: #5A403B; border: 2px solid; padding: 2px; cursor: pointer; }\n";
    print_web_page += ".header { vertical-align: top; text-align: left; }\n\n";
    print_web_page += ".header, body {\n\n";
    print_web_page += "background-image: -webkit-repeating-radial-gradient(center center, rgba(0,0,0,.2), rgba(0,0,0,.2) 1px, transparent 1px, transparent 100%);\n";
    print_web_page += "background-image: -moz-repeating-radial-gradient(center center, rgba(0,0,0,.2), rgba(0,0,0,.2) 1px, transparent 1px, transparent 100%);\n";
    print_web_page += "background-image: -ms-repeating-radial-gradient(center center, rgba(0,0,0,.2), rgba(0,0,0,.2) 1px, transparent 1px, transparent 100%);\n";
    print_web_page += "background-image: repeating-radial-gradient(center center, rgba(0,0,0,.2), rgba(0,0,0,.2) 1px, transparent 1px, transparent 100%);\n";
    print_web_page += "-webkit-background-size: 3px 3px;\n";
    print_web_page += "-moz-background-size: 3px 3px;\n";
    print_web_page += "background-size: 3px 3px;\n";
    print_web_page += "}\n\n";
    print_web_page += ".footer {\n\n";
    print_web_page += "background-color: #5a3428;\n";
    print_web_page += "background-image: -webkit-repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "background-image: -moz-repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "background-image: -o-repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "background-image: repeating-linear-gradient(135deg, rgba(0,0,0,.3), rgba(0,0,0,.3) 1px, transparent 2px, transparent 2px, rgba(0,0,0,.3) 3px);\n";
    print_web_page += "-webkit-background-size: 4px 4px;\n";
    print_web_page += "-moz-background-size: 4px 4px;\n";
    print_web_page += "background-size: 4px 4px;\n";
    print_web_page += "}\n\n";
    print_web_page += "#logo_traditional_and_links_traditional_format, #logo_traditional_and_links_responsive_format { text-transform: uppercase; font-weight: bold; }\n\n";
    print_web_page += "textarea, input, select { margin-top: 6px; margin-bottom: 6px; font-size: 12pt; }\n";
    print_web_page += "input[type=submit], input[type=button] { margin-top: 6px; margin-bottom: 6px; font-size: 14pt; }\n\n";
    print_web_page += ".footer .foot_label { text-align: left; height: 100%; width: auto; word-wrap: break-word; }\n";
    print_web_page += "</style>\n";
    print_web_page += "<div class=\"pre_header\" style=\"background-color: #FBDFCC; vertical-align: top; text-align: left\">\n";
    print_web_page += "</div>\n";
    print_web_page += "<div class=\"header\" style=\"background-color: #5A403B; vertical-align: top; text-align: left\">\n";
    print_web_page += "<div id=\"logo_traditional_and_links_traditional_format\">\n";
    print_web_page += "<div style=\"display: table; text-align: left; width: 80%; padding-top: 15px; padding-bottom: 15px; margin-left: 10%; margin-right: 10%\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: left; width: 100%;\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: left; width: 30%;\">\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Logo.Request_website_logo() + "\n";
    print_web_page += "</div>\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right; width: 70%; vertical-align: middle; word-wrap: break-word\">\n";
    print_web_page += "<div style='text-align: right; vertical-align: top; width: 100%'><p>\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.Request_website_links_horizontal_format() + "\n";
    print_web_page += "</p></div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "<div id=\"logo_traditional_and_links_responsive_format\">\n";
    print_web_page += "<div style=\"display: table; text-align: left; width: 98%; padding-top: 15px; padding-bottom: 15px; margin-left: 1%; margin-right: 1%\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: left; width: 100%;\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: left; vertical-align: center; width: 50%;\">\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Logo.Request_website_logo() + "\n";
    print_web_page += "</div>\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right; width: 50%; vertical-align: middle\">\n";
    print_web_page += "<div id=\"show_vertical_menu\">\n";
    print_web_page += "<p><b><a id=\"click_show_vertical_menu\" onclick=\"onclick_show_vertical_menu()\">\n";
    print_web_page += "<div style=\"display: table; width: 100%; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right\">___</div></div></div>\n";
    print_web_page += "<div style=\"display: table; width: 100%; text-align: right; margin-top: -10px\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right\">___</div></div></div>\n";
    print_web_page += "<div style=\"display: table; width: 100%; text-align: right; margin-top: -10px\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right\">___</div></div></div></a></b></p>\n";
    print_web_page += "</div>\n";
    print_web_page += "<div id=\"hide_vertical_menu\">\n";
    print_web_page += "<p><b><a id=\"click_hide_vertical_menu\" onclick=\"onclick_hide_vertical_menu()\">\n";
    print_web_page += "<div style=\"display: table; width: 100%; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right\">___</div></div></div>\n";
    print_web_page += "<div style=\"display: table; width: 100%; text-align: right; margin-top: -10px\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right\">___</div></div></div>\n";
    print_web_page += "<div style=\"display: table; width: 100%; text-align: right; margin-top: -10px\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: right\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: right\">___</div></div></div></a></b></p>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "<div style=\"display: table; text-align: left; width: 98%; margin-left: 1%; margin-right: 1%\">\n";
    print_web_page += "<div style=\"display: table-row; text-align: left; width: 100%;\">\n";
    print_web_page += "<div style=\"display: table-cell; text-align: left; width: 100%; word-wrap: break-word\">\n";
    print_web_page += "<script type=\"text/javascript\">\n";
    print_web_page += "$(document).ready(function() {\n\n";
    print_web_page += "$(\"#show_vertical_menu\").fadeIn();\n";
    print_web_page += "});\n\n";
    print_web_page += "function onclick_show_vertical_menu() {\n\n";
    print_web_page += "$(\".show_vertical_menu\").slideDown(1200);\n";
    print_web_page += "$(\"#hide_vertical_menu\").slideDown(1200);\n";
    print_web_page += "$(\"#show_vertical_menu\").slideUp(1200);\n";
    print_web_page += "}\n\n";
    print_web_page += "function onclick_hide_vertical_menu() {\n\n";
    print_web_page += "$(\".show_vertical_menu\").slideUp(1200);\n";
    print_web_page += "$(\"#show_vertical_menu\").slideDown(1200);\n";
    print_web_page += "$(\"#hide_vertical_menu\").slideUp(1200);\n";
    print_web_page += "}\n";
    print_web_page += "</script>\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Website_Links.Request_website_links_vertical_format() + "\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "<div class=\"content\" style=\"vertical-align: top; text-align: left\">\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Web_Page.Request_content() + "\n";
    print_web_page += "</div>\n";
    print_web_page += "<div class=\"footer\" style=\"text-align: left; word-wrap: break-word\">\n";
    print_web_page += Timothys_Digital_Solutions_Company_Website_Windows.controllers.Request_Footer_Content.Request_footer_content() + "\n";
    print_web_page += "<div class=\"signature_section\">\n";
    print_web_page += "<div id=\"footer_traditional_format\">\n";
    print_web_page += "<div style=\"text-align: left; width: 80%; margin-left: 10%; margin-right: 10%; padding-top: 15px; padding-bottom: 10px;\">\n";
    print_web_page += "<span class=\"foot_label\">Powered by <b><a href=\"http://www.timothysdigitalsolutions.com/\">Timothy's Digital Solutions</a> Framework</b></span>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "<div id=\"footer_responsive_format\">\n";
    print_web_page += "<div style=\"text-align: center; width: 98%; margin-left: 1%; margin-right: 1%; padding-top: 15px; padding-bottom: 20px;\">\n";
    print_web_page += "<span class=\"foot_label\">Powered by <b><a href=\"http://www.timothysdigitalsolutions.com/\">Timothy's Digital Solutions</a> Framework</b></span>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";
    print_web_page += "</div>\n";

    Response.Write(print_web_page);
%>