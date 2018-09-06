using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Management;

namespace MK_HelperDataLib
{
   public class Log
    {

        public static string I_LOG(string ID, string TABLOADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnectionLog(ref con);
                SqlCommand com = new SqlCommand("insert " + TABLOADI + " (KULLANICI,IP,MAC,ISLEM,TARIHSAAT) values(@KULLANICI,@IP,@MAC,@ISLEM,@TARIHSAAT);select IDENT_CURRENT('" + TABLOADI + "');", con);
                com.Parameters.AddWithValue("@KULLANICI", StatikData.USR_SICILNO);
                com.Parameters.AddWithValue("@IP", StatikData.SS_IP);
                com.Parameters.AddWithValue("@MAC", StatikData.SS_MACADDRESS);
                com.Parameters.AddWithValue("@ISLEM", ID);
                com.Parameters.AddWithValue("@TARIHSAAT", Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()));
                object deger = com.ExecuteScalar();
                durum = true;
                con.Close();
                return deger.ToString();
            }
            catch (Exception c)
            {
                con.Close();
                durum = false;
                return string.Empty;
            }
        }

        public static string InsertErrorLogAndShowErrorMessage(string sayfaAdi, string metotAdi, string errorMessage)
        {

            bool result = false;

            string deger = I_LOG(sayfaAdi + " Sayfası" + metotAdi + " Metotu : " + errorMessage, "I_ERRORLOG", ref result);

            return "Sayfa Adı:" + sayfaAdi + " Metot Adı: " + metotAdi + "Hata Mesajı: " + errorMessage;
        }




    }
}
