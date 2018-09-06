using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HelperDataLib
{
   public class Connection
    {
        private static string stringconn = "";
        public static string Datemode = "";
        public string Cstr
        {
            get { return stringconn; }
            set { stringconn = value; }
        }
        public static void baglanti()
        {
            try
            {
                string key = ConfigurationManager.AppSettings["ConfigPass"].ToString();
                string server = ConfigurationManager.AppSettings["Server"].ToString();
                string Database = ConfigurationManager.AppSettings["Database"].ToString();
                string User = ConfigurationManager.AppSettings["User"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
              
                stringconn = "data source='" + server  +"';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';Min Pool Size=20; Max Pool Size=500;";
                

            }
            catch
            {
                return;
            }
        }
        public static void baglantiCustomer()
        {
               try
               {
                      string key = ConfigurationManager.AppSettings["ConfigPass"].ToString();
                      string server = ConfigurationManager.AppSettings["Server"].ToString();
                      string Database = ConfigurationManager.AppSettings["Database2"].ToString();
                      string User = ConfigurationManager.AppSettings["User"].ToString();
                      string Password = ConfigurationManager.AppSettings["Password"].ToString();

                      stringconn = "data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';Min Pool Size=20; Max Pool Size=500;";


               }
               catch
               {
                      return;
               }
        }
        public static void baglantiLog()
        {
            try
            {
                string key = ConfigurationManager.AppSettings["ConfigPass"].ToString();
                string server = ConfigurationManager.AppSettings["Server"].ToString();
                string Database = ConfigurationManager.AppSettings["Database3"].ToString();
                string User = ConfigurationManager.AppSettings["User"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();

                stringconn = "data source='" + server + "';initial catalog='" + Database + "';User Id='" + User + "';Password='" + Password + "';Min Pool Size=20; Max Pool Size=500;";


            }
            catch
            {
                return;
            }
        }



        public static IDbConnection OpenConnection(ref SqlConnection oConn)
        {
            baglanti();
            oConn = new SqlConnection(stringconn);
            if (oConn.State != ConnectionState.Open)
            {

                oConn.Open();
            }
            return oConn;
        }


        public static IDbConnection OpenConnectionCustomer(ref SqlConnection oConn)
        {
               baglantiCustomer();
               oConn = new SqlConnection(stringconn);
               if (oConn.State != ConnectionState.Open)
               {

                      oConn.Open();
               }
               return oConn;
        }

        public static IDbConnection OpenConnectionLog(ref SqlConnection oConn)
        {
            baglantiLog();
            oConn = new SqlConnection(stringconn);
            if (oConn.State != ConnectionState.Open)
            {

                oConn.Open();
            }
            return oConn;
        }
    }
    
}
