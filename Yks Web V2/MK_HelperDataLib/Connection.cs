using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MK_HelperDataLib
{
    public class Connection :  IDisposable
    {
        private static string stringconn = "";
        public static string Datemode = "";
        public static string server = "";
        public static string Database = "";
        public static string User = "";
        public static string Password = "";

        public static string Datemode2 = "";
        public static string server2 = "";
        public static string Database2 = "";
        public static string User2 = "";
        public static string Password2 = "";
        public static SqlConnection sqlcon = null;
        public static void Sqlconnection()
        {
            try
            {
                IniFiles inifiles = new IniFiles();
                inifiles.IniFile = Application.StartupPath + @"\DataBase.ini";
                server = inifiles.ReadIni("DB", "Server").ToString();
                Database = inifiles.ReadIni("DB", "Database").ToString();
                User = inifiles.ReadIni("DB", "User").ToString();
                Password = inifiles.ReadIni("DB", "Password").ToString();
                stringconn = "data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';";
            }
            catch
            {
                return;
            }
        }
        public static IDbConnection OpenConnection(ref SqlConnection oConn)
        {
            try
            {

                Sqlconnection();

                if (server == "")
                {
                    baglanti_web();
                }
                oConn = new SqlConnection(stringconn);
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.Open();
                }
            }
            catch (Exception ex)
            {
                oConn.Close();
            }
            return sqlcon;
        }
        public static void SqlconnectionCustomer()
        {
            try
            {
                //sql connection
                IniFiles inifiles = new IniFiles();
                inifiles.IniFile = Application.StartupPath + @"\DataBase.ini";
                server2 = inifiles.ReadIni("DB", "Server2").ToString();
                Database2 = inifiles.ReadIni("DB", "Database2").ToString();
                User2 = inifiles.ReadIni("DB", "User2").ToString();
                Password2 = inifiles.ReadIni("DB", "Password2").ToString();
                stringconn = "data source='" + server2 + "';initial catalog='" + Database2 + "';User Id='" + User2 + "';Password='" + Password2 + "';";
            }
            catch
            {
                return;
            }
        }
        public static void SqlconnectionPergo()
        {
            try
            {
                //sql connection
                IniFiles inifiles = new IniFiles();
                inifiles.IniFile = Application.StartupPath + @"\DataBase.ini";
                server3 = inifiles.ReadIni("DB", "Server3").ToString();
                Database3 = inifiles.ReadIni("DB", "Database3").ToString();
                User3 = inifiles.ReadIni("DB", "User3").ToString();
                Password3 = inifiles.ReadIni("DB", "Password3").ToString();
                stringconnPergo = "data source='" + server3 + "';initial catalog='" + Database3 + "';User Id='" + User3 + "';Password='" + Password3 + "';";
            }
            catch
            {
                return;
            }
        }
        public static IDbConnection OpenConnectionCustomer(ref SqlConnection oConn)
        {
            try
            {

                SqlconnectionCustomer();

                if (server2 == "")
                {
                    baglantiCustomer_web();
                }
                oConn = new SqlConnection(stringconn);
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.Open();
                }
            }
            catch (Exception ex)
            {
                oConn.Close();
            }
            return sqlcon;
        }

        public static IDbConnection OpenConnectionPergo(ref SqlConnection oConn)
        {
            try
            {

                SqlconnectionPergo();

                //if (server2 == "")
                //{
                //    baglantiCustomer_web();
                //}
                oConn = new SqlConnection(stringconnPergo);
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.Open();
                }
            }
            catch (Exception ex)
            {
                oConn.Close();
            }
            return sqlcon;
        }
        public static void baglanti_web()
        {
            try
            {

                string server = ConfigurationManager.AppSettings["Server"].ToString();
                string Database = ConfigurationManager.AppSettings["Database"].ToString();
                string User = ConfigurationManager.AppSettings["User"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();

                stringconn = "data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';Min Pool Size=20; Max Pool Size=500;";


            }
            catch
            {
                return;
            }
        }
        public static void baglantiCustomer_web()
        {
            try
            {

                string server = ConfigurationManager.AppSettings["Server2"].ToString();
                string Database = ConfigurationManager.AppSettings["Database2"].ToString();
                string User = ConfigurationManager.AppSettings["User2"].ToString();
                string Password = ConfigurationManager.AppSettings["Password2"].ToString();

                stringconn = "data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';Min Pool Size=20; Max Pool Size=500;";


            }
            catch
            {
                return;
            }
        }


        public static string stringconnPergo { get; set; }

        public static string server3 { get; set; }

        public static string Database3 { get; set; }

        public static string User3 { get; set; }

        public static string Password3 { get; set; }
        public static void SqlconnectionLog()
        {
            try
            {
                IniFiles inifiles = new IniFiles();
                inifiles.IniFile = Application.StartupPath + @"\DataBase.ini";
                server = inifiles.ReadIni("DB", "ServerLog").ToString();
                Database = inifiles.ReadIni("DB", "DatabaseLog").ToString();
                User = inifiles.ReadIni("DB", "UserLog").ToString();
                Password = inifiles.ReadIni("DB", "PasswordLog").ToString();
                stringconn = "data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';";
            }
            catch
            {
                return;
            }
        }
        public static IDbConnection OpenConnectionLog(ref SqlConnection oConn)
        {
            try
            {

                SqlconnectionLog();

                if (server == "")
                {
                    baglanti_web();
                }
                oConn = new SqlConnection(stringconn);
                if (oConn.State != ConnectionState.Open)
                {
                    oConn.Open();
                }
            }
            catch (Exception ex)
            {
                oConn.Close();
            }
            return sqlcon;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
    
}
