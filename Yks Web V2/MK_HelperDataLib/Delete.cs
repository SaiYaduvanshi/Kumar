using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MK_HelperDataLib
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
                Log.I_LOG("I_USERS tablosundan"+ Id + "numaralı satır silindi.", "I_KULLANICILOG", ref durum);
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

                SqlCommand com = new SqlCommand("DELETE FROM I_YETKI WHERE YT_YETKIID=@ID", con);
                com.Parameters.AddWithValue("@ID", ID);
                Log.I_LOG("I_YETKI tablosundan" + ID + "numaralı satır silindi.", "I_YETKILOG", ref durum);
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
                Log.I_LOG("I_YETKIDETAY tablosundan" + ID + "numaralı satır silindi.", "I_YETKILOG", ref durum);
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
        public static void D_PROJE(string ID, ref bool durum) /* TODO: Sorulacak */
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("DELETE FROM I_PROJE WHERE PRJ_ID=@ID", con);
                Log.I_LOG("I_PROJE tablosundan" + ID + "numaralı satır silindi.", "I_IHBARLOG", ref durum);
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
        public static void D_IS(string ID, ref bool durum)/* TODO: Sorulacak */
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("DELETE FROM I_IS WHERE IS_ID=@ID", con);
                com.Parameters.AddWithValue("@ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IS tablosundan" + ID + "numaralı satır silindi.", "I_IHBARLOG", ref durum);
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
        public static void D_EKIPTELEFON(string ID, ref bool durum) /* TODO: Sorulacak */
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("DELETE FROM I_EKIPTELEFON WHERE E_ID=@ID", con);
                com.Parameters.AddWithValue("@ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_EKIPTELEFON tablosundan" + ID + "numaralı satır silindi.", "I_KANALLOG", ref durum);
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
                Log.I_LOG("I_IHBARKAPANIS tablosundan" + ID + "numaralı satır silindi.", "I_IHBARLOG", ref durum);
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

         public static bool D_TEMPTELEFON()
        {
            SqlConnection con = new SqlConnection();
            try
            {
                
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("DELETE FROM I_TEMP_TELEFON", con);
                int deger = com.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;

            }
        }
         public static bool D_IHBARTAKIP(string I_IHBARID)
         {
             SqlConnection con = new SqlConnection();
             try
             {
                bool durum = false;
                 Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE FROM I_IHBARTAKIP WHERE I_IHBARID=@I_IHBARID AND I_KULLANICI=@I_KULLANICI", con);
                 com.Parameters.AddWithValue("@I_IHBARID", I_IHBARID);
                 com.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
                 int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBARTAKIP tablosundan" + I_IHBARID + "numaralı satır silindi.", "I_KANALLOG", ref durum);
                con.Close();
                 return true;
             }
             catch
             {
                 con.Close();
                 return false;

             }
         }
         public static bool D_EKIPTAKIP(string I_EKIPID)
         {
             SqlConnection con = new SqlConnection();
             try
             {
                bool durum = false;
                Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE FROM I_EKIPTAKIP WHERE EK_KODU=@EK_KODU AND EK_KULLANICI=@EK_KULLANICI", con);
                 com.Parameters.AddWithValue("@EK_KODU", I_EKIPID);
                 com.Parameters.AddWithValue("@EK_KULLANICI", StatikData.USR_SICILNO);
                 int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_EKIPTAKIP tablosundan" + I_EKIPID + "numaralı satır silindi.", "I_KANALLOG", ref durum);
                con.Close();
                 return true;
             }
             catch
             {
                 con.Close();
                 return false;

             }
         }
         public static bool D_DUYURU(string I_DUYURUID)
         {
             SqlConnection con = new SqlConnection();
             try
             {
                bool durum = false;
                Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE FROM I_DUYURU WHERE [D_ID]=@ID", con);
                 com.Parameters.AddWithValue("@ID", I_DUYURUID);
                 int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_DUYURU tablosundan" + I_DUYURUID + "numaralı satır silindi.", "I_KULLANICILOG", ref durum);
                con.Close();
                 return true;
             }
             catch
             {
                 con.Close();
                 return false;

             }
         }
         public static bool D_TARIHTENEOLMUS(string I_TBID)  /* TODO: Sorulacak */
        {
             SqlConnection con = new SqlConnection();
             try
             {
                bool durum = false;
                Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE FROM [I_TARIHTE_NEOLMUS] WHERE [TB_ID]=@ID", con);
                 com.Parameters.AddWithValue("@ID", I_TBID);
                 int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_TARIHTE_NEOLMUS tablosundan" + I_TBID + "numaralı satır silindi.", "I_KULLANICILOG", ref durum);
                con.Close();
                 return true;
             }
             catch
             {
                 con.Close();
                 return false;

             }
         }
       /////////14.03.2018//////////////
         public static void D_KAMERA_LOKASYON(string Id, ref bool durum)
         {
             SqlConnection con = new SqlConnection();
             try
             {

                 Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE I_KAMERA_LOKASYON WHERE KMR_ID=@Id ", con);
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

         public static void D_MARKER_KISAYOL(string Id, ref bool durum)
         {
             SqlConnection con = new SqlConnection();
             try
             {

                 Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE I_MARKER_KISAYOL WHERE MRK_ID=@Id ", con);
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
         public static void D_MARKER_KISAYOL_GRUP(string Id, ref bool durum)
         {
             SqlConnection con = new SqlConnection();
             try
             {

                 Connection.OpenConnection(ref con);
                 SqlCommand com = new SqlCommand("DELETE I_KISAYOLGRUP WHERE MKYG_ID=@Id ", con);
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
    }
}
