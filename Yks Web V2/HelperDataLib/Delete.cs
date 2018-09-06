using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web;

namespace HelperDataLib
{
   public class Delete
    {
     
       public static void D_GRUP(string Id, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {
             
               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE I_GRUP WHERE GRP_ID=@Id ", con);
               com.Parameters.AddWithValue("@Id", Id);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_KULLANICI(string Id, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {
             
               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_USERS WHERE USR_ID=@Id ", con);
               com.Parameters.AddWithValue("@Id", Id);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }

       public static void D_YETKI(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           Connection.OpenConnection(ref con);
           try
           {
            
               SqlCommand com = new SqlCommand("DELETE FROM I_YETKI WHERE YT_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_YETKI_DETAY(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {
               
               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_YETKIDETAY WHERE YTD_YETKIID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
     
       public static void D_EKIPTELEFON(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_EKIPTELEFON WHERE E_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_KAPALIIHBAR(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_IHBARKAPANIS WHERE IK_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_USTOLAY(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_USTOLAY WHERE U_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_ALTOLAY(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_ALTOLAY WHERE A_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_ILCE(string ILCEID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_ILCE WHERE ILCEID=@ILCEID", con);
               com.Parameters.AddWithValue("@ILCEID", ILCEID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_MAHALLE(string I_MAHID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_MAHALLE WHERE I_MAHID=@I_MAHID", con);
               com.Parameters.AddWithValue("@I_MAHID", I_MAHID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_CADDE(string I_MAHID,string caddead, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_CADDE WHERE I_SID=@I_SID AND I_AD=@I_AD", con);
               com.Parameters.AddWithValue("@I_SID", I_MAHID);
               com.Parameters.AddWithValue("@I_AD", caddead);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_ALTOLAY_TUM(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_ALTOLAY WHERE A_UID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_KANAL(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_KANAL WHERE KNL_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_SUBE(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_SUBE WHERE SB_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_EKIP(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_EKIP WHERE EK_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_ISLEMSONUC(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_ISLEMSONUC WHERE IS_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_KARALISTE(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_KARALISTE WHERE KR_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_KARAKOL(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_KARAKOL WHERE KRK_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_KANAL_GRUP(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_KANALGRUP WHERE KG_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_GUVENLIKSIRKET(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_GUVENLIKSIRKET WHERE G_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }


       public static void D_GUVENLIKMUSTERI(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_GUVENLIKMUSTERI WHERE GM_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }

       public static void D_ARACTIPI(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_ARACTIPI WHERE AT_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }
       public static void D_ALARM(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_ALARM WHERE A_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }

       public static void D_MARKA(string ID, ref bool durum)
       {
           SqlConnection con = new SqlConnection();
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("DELETE FROM I_MARKA WHERE O_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               int deger = com.ExecuteNonQuery();
               durum = true;
               con.Close();
           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }
       }

    }
}
