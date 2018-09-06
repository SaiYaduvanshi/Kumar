using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Management;
using HelperDataLib;
using System.Web;

namespace HelperDataLib
{
    public class Log
    {

        public static void I_LOG(string ID, string TABLOADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            { 
                Connection.OpenConnectionLog(ref con);
                SqlCommand com = new SqlCommand("insert " + TABLOADI + " (KULLANICI,IP,MAC,ISLEM,TARIHSAAT) values(@KULLANICI,@IP,@MAC,@ISLEM,@TARIHSAAT)", con);
                com.Parameters.AddWithValue("@KULLANICI", HttpContext.Current.Session["USR_SICILNO"]);
                com.Parameters.AddWithValue("@IP", HttpContext.Current.Session["SS_IPADRES"]);
                com.Parameters.AddWithValue("@MAC", HttpContext.Current.Session["SS_MACADRES"]);
                com.Parameters.AddWithValue("@ISLEM", ID);
                com.Parameters.AddWithValue("@TARIHSAAT", Convert.ToDateTime(DateTime.Now.ToString()));
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch (Exception c)
            {
                con.Close();
                durum = false;
                return;
            }
        }




    }
}
