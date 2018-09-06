using MK_HelperDataLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace MK_HelperDataLib
{
   public class Select : IDisposable
   {


        public Select()
        {
            Dispose();
        }
       public static SqlConnection con = new SqlConnection();

        public static void S_IHBAR_GETDETAY(string IHBARID, ref string I_TELEFON, ref string I_ISIMSOYISIM, ref string I_IL, ref object I_ILCE, ref object I_KANAL, ref object I_MAHALLE, ref object I_CADDE, ref string I_SITE, ref string I_BINA, ref string I_BINANO, ref string I_DAIRE, ref string I_PLAKA, ref string I_ADRES, ref string I_LATITUDE, ref string I_LONGITUDE, ref string I_IHBARBILGISI, ref object I_USTOLAYKODU, ref object I_ALTOLAYKODU, ref string I_OPERATORNOT, ref string I_CINSIYET, ref string I_YAS, ref string I_MAIL, ref string I_DIGERBILGI, ref string I_TARIH, ref bool I_ONCELIK)
        {

            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT * FROM I_IHBAR WHERE I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ID", IHBARID);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    I_TELEFON = SDR["I_TELEFON"].ToString();
                    I_ISIMSOYISIM = SDR["I_ISIMSOYISIM"].ToString();
                    I_IL = SDR["I_IL"].ToString();
                    I_ILCE = SDR["I_ILCE"];
                    I_KANAL = SDR["I_KANAL"];
                    I_MAHALLE = SDR["I_MAHALLE"];
                    I_CADDE = SDR["I_CADDE"].ToString();
                    I_SITE = SDR["I_SITE"].ToString();
                    I_BINA = SDR["I_BINA"].ToString();
                    I_PLAKA = SDR["I_PLAKA"].ToString();
                    I_ADRES = SDR["I_ADRES"].ToString();
                    I_LATITUDE = SDR["I_LATITUDE"].ToString();
                    I_LONGITUDE = SDR["I_LONGITUDE"].ToString();
                    I_IHBARBILGISI = SDR["I_IHBARBILGISI"].ToString();
                    I_USTOLAYKODU = SDR["I_USTOLAYKODU"];
                    I_ALTOLAYKODU = SDR["I_ALTOLAYKODU"];
                    I_OPERATORNOT = SDR["I_OPERATORNOT"].ToString();
                    I_CINSIYET = SDR["I_CINSIYET"].ToString();
                    I_YAS = SDR["I_YAS"].ToString();
                    I_MAIL = SDR["I_MAIL"].ToString();
                    I_DIGERBILGI = SDR["I_DIGERBILGI"].ToString();
                    I_TARIH = SDR["I_TARIH"].ToString();
                    I_DAIRE = SDR["I_DAIRE"].ToString();
                    I_BINANO = SDR["I_BINANO"].ToString();
                    I_ONCELIK = Convert.ToBoolean(SDR["I_ONCELIKLI"].ToString());
                }

                con.Close();
                bool durum = false;
                Log.I_LOG(IHBARID + " idli 155 ihbar açıldı.", "I_IHBARLOG", ref durum);
            }
            catch
            {
                con.Close();
                return;
            }

        }
        public static System.Data.DataTable S_KARAKOL_YUKLE(string ILCEID)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_KARAKOL WHERE KRK_ILCE=@KRK_ILCE ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@KRK_ILCE", ILCEID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }

        public static System.Data.DataTable S_YAKINEKIPLER_YUKLE()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            try
            { 
                string sorgu = "select '' EK_KODU, '' ARC_PLAKA union all SELECT  EK_KODU,ARC_PLAKA FROM I_EKIP e join I_ARAC a on e.EK_ARACID=a.ARC_NO where e.EK_DURUM='True'  ";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.Fill(dtt); 
            }
            catch 
            { 
            }
            finally
            {
                con.Close();
            }
           
            return dtt;

        }

        public static System.Data.DataTable S_KANAL_ILCE_DETAY2(string ilce)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select  KNL_KODU,KNL_ILCE FROM I_KANAL where KNL_ILCE LIKE '%" + ilce + "%' AND KNL_TRAFIK = 1 AND KNL_DURUM = 1 AND KNL_YETKI = 'K'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_ARAC_YUKLE()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_ARAC ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ARACMARKA_YUKLE()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_MARKA ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ARACTIP_YUKLE()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_ARACTIPI ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ALARM_YUKLE()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_ALARM where A_DURUM='True'";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static void S_GetFormYetki(string YetkiId, string ModulId, ref bool Oku, ref bool Yaz, ref bool Sil)
       {
           try
           {
               Connection.OpenConnection(ref con);
               SqlCommand com2 = new SqlCommand("select * from I_YETKIDETAY WHERE YTD_YETKIID=@YETKIID AND YTD_MODULID=@MODULID", con);
               com2.Parameters.AddWithValue("@YETKIID", YetkiId);
               com2.Parameters.AddWithValue("@MODULID", ModulId);
               SqlDataReader dr = com2.ExecuteReader();
               if (dr.Read())
               {

                   Oku = Convert.ToBoolean(dr["YTD_OKU"].ToString());
                   Yaz = Convert.ToBoolean(dr["YTD_YAZ"].ToString());
                   Sil = Convert.ToBoolean(dr["YTD_SIL"].ToString());



               }
               con.Close();
           }
           catch
           {
               con.Close();
               return;
           }
       }
       public static void S_GET_LOKASYON(string ID, ref string ARC_LATITUDE, ref string ARC_LONGITUDE)
       {

           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("SELECT ARC_LATITUDE,ARC_LONGITUDE FROM I_ARAC WHERE ARC_ID=@ID", con);
               com.Parameters.AddWithValue("@ID", ID);
               SqlDataReader SDR = com.ExecuteReader();
               if (SDR.Read())
               {
                   ARC_LATITUDE = SDR["ARC_LATITUDE"].ToString();
                   ARC_LONGITUDE = SDR["ARC_LONGITUDE"].ToString();
                  
               }

               con.Close();
           }
           catch
           {
               con.Close();
               return;
           }

       }
        public static void S_PAGE_YETKIKOTROL(string MODULID)
        {
            bool durum = false;
            string[] arg = new string[999999];
            arg = StatikData.SS_MODULID.ToString().Split(',');
            foreach (string item in arg)
            {

                if (item == MODULID)
                {
                    durum = true;
                }

            }
            if (durum == false)
            {
               
            }
        }
        public static void S_KULLANICIGIRIS(string Sicilno, string Sifre, bool check, ref bool durum, ref string error)
        {
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand(" SELECT USR_ID,USR_SICILNO,USR_ADI,USR_SOYADI,YT_YETKIID,YT_YETKIADI,GRP_KODU,GRP_ADI,GRP_USRKODU,USR_SONGIRIS,USR_KANALYETKI,K.KNL_YETKI,USR_ILCE,USR_EKIPKODU,USR_KNLSEC,USR_SIFRE,K.KN_ADI,USR_KULLANICIADI,K.KNL_DIGERKANAL,USR_SONGIRIS  FROM I_USERS USR JOIN I_YETKI Y  ON  USR.USR_YETKIKODU=Y.YT_YETKIID JOIN I_GRUP G ON USR.USR_GRUPKODU=G.GRP_KODU left join I_KANAL K ON K.KNL_KODU=USR_KANALYETKI   WHERE USR_SICILNO=@SICILNO AND USR_SIFRE=@SIFRE AND USR_DURUM='True'", con);
                com.Parameters.AddWithValue("@SICILNO", Sicilno);
                com.Parameters.AddWithValue("@SIFRE", Sifre);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    durum = true;
                    S_MUSTERIMODUL_GET();
                    HttpContext.Current.Session["USR_SICILNO"] = Sicilno;
                    HttpContext.Current.Session["SS_ID"] = SDR["USR_ID"].ToString();
                    HttpContext.Current.Session["SS_ISIM"] = SDR["USR_ADI"].ToString();
                    HttpContext.Current.Session["SS_SOYADI"] = SDR["USR_SOYADI"].ToString();
                    HttpContext.Current.Session["SS_GRUPUSERS"] = SDR["GRP_USRKODU"].ToString();
                    HttpContext.Current.Session["SS_GRUPADI"] = SDR["GRP_ADI"].ToString();
                    HttpContext.Current.Session["SS_YETKIID"] = SDR["YT_YETKIID"].ToString();
                    HttpContext.Current.Session["SS_YETKIADI"] = SDR["YT_YETKIADI"].ToString();
                    HttpContext.Current.Session["SS_USR_SONGIRIS"] = SDR["USR_SONGIRIS"].ToString();
                    HttpContext.Current.Session["SS_KANAL"] = SDR["USR_KANALYETKI"].ToString();
                    HttpContext.Current.Session["SS_KNL_YETKI"] = SDR["KNL_YETKI"].ToString();
                    HttpContext.Current.Session["SS_ILCE"] = SDR["USR_ILCE"].ToString();
                    HttpContext.Current.Session["SS_EKIPKODU"] = SDR["USR_EKIPKODU"].ToString();
                    HttpContext.Current.Session["SS_GRUP"] = SDR["GRP_KODU"].ToString();
                    HttpContext.Current.Session["SS_SIFRE"] = SDR["USR_SIFRE"].ToString();
                    HttpContext.Current.Session["SS_KANAL_ADI"] = SDR["KN_ADI"].ToString();
                    HttpContext.Current.Session["SS_KULLANICIADI"] = SDR["USR_KULLANICIADI"].ToString();
                    HttpContext.Current.Session["SS_DIGERKANAL"] = SDR["KNL_DIGERKANAL"].ToString();
                    HttpContext.Current.Session["SS_GIRISTARIH"] = SDR["USR_SONGIRIS"].ToString();
                    HttpContext.Current.Session["SS_KNLSEC"] = Convert.ToBoolean(SDR["USR_KNLSEC"] != null ? SDR["USR_KNLSEC"] : false);
                    HttpContext.Current.Session["SS_MACADDRESS"] = GetMACAddress();
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            HttpContext.Current.Session["SS_IP"] = ip.ToString();
                        }
                    }
                    HttpContext.Current.Session["SS_IHBARLISTESI_COUNT"] = S_GETSORGU_COUNT("100");
                    HttpContext.Current.Session["SS_KAPALIIHBARLISTESI_COUNT"] = S_GETSORGU_COUNT("101");



                    Update.U_SONGIRIS_TARIHGUNCELLE(SDR["USR_ID"].ToString(), ref durum);
                    Log.I_LOG(Sicilno + " " + "Nolu personel sisteme giriş yaptı", "I_KULLANICILOG", ref durum);
                    HttpContext.Current.Response.Redirect("Default.aspx", false);
                }
                else
                {
                    durum = false;
                }
                con.Close();

            }
            catch (Exception c)
            {
                error = c.Message;
                con.Close();
                durum = false;
                return;
            }

        }
        public static string GetMACAddress()
        {
            string str = string.Empty;
            try
            {
                ManagementObjectCollection objects = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
                foreach (ManagementObject obj2 in objects)
                {
                    if ((str == string.Empty) && ((bool)obj2["IPEnabled"]))
                        str = obj2["MacAddress"].ToString();
                    obj2.Dispose();
                }
            }
            catch
            {
                str = "";
            }
            return str.Replace(":", "");
        }
        public static void S_MUSTERIMODUL_GET()
        {
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT MUS_MODULID,MUS_SUBMODULID FROM I_MUSTERIMODUL", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                 StatikData.SS_MODULID= SDR["MUS_MODULID"].ToString();
                   StatikData.SS_SUBMODULID= SDR["MUS_SUBMODULID"].ToString();

                }
                con.Close();
            }
            catch
            {
                con.Close();
                return;
            }

        }

        public static System.Data.DataTable S_MODUL_YUKLE()
        {
            string id = StatikData.SS_SUBMODULID.ToString();
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM I_MODUL WHERE MDL_MODULID IN (" + id + ")";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@MODULID", id);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_USTOLAY_YUKLE_WHERE(string ID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM I_USTOLAY where U_ID=@U_ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@U_ID", ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_USTOLAY_YUKLE()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM I_USTOLAY";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_ALTOLAY_YUKLE()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM I_ALTOLAY";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_ALTOLAY_YUKLE_WHERE(string Id)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM I_ALTOLAY where A_ID=@A_ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@A_ID", Id);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static void S_YETKI_GETVALUES(string MODULID, ref bool OKU, ref bool YAZ, ref bool SIL, ref bool EKSTRA, ref string USERS)
        {

            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT * FROM I_YETKIDETAY WHERE  YTD_YETKIID=@YETKIID AND YTD_MODULID=@MODULID", con);
                com.Parameters.AddWithValue("@YETKIID", StatikData.SS_YETKIID);
                com.Parameters.AddWithValue("@MODULID", MODULID);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {

                    OKU = Convert.ToBoolean(SDR["YTD_OKU"].ToString());
                    YAZ = Convert.ToBoolean(SDR["YTD_YAZ"].ToString());
                    SIL = Convert.ToBoolean(SDR["YTD_SIL"].ToString());
                    EKSTRA = Convert.ToBoolean(SDR["YTD_EKSTRA"].ToString());
                    USERS = S_GETGRUPUSERS();
                }

                con.Close();
            }
            catch
            {
                con.Close();
                return;
            }

        }
        public static void S_YETKI_GETVALUES_DETAY(string YETKIID, string MODULID, ref bool OKU, ref bool YAZ, ref bool SIL, ref bool EKSTRA, ref string USERS)
        {

            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT * FROM I_YETKIDETAY WHERE  YTD_YETKIID=@YETKIID AND YTD_MODULID=@MODULID", con);
                com.Parameters.AddWithValue("@YETKIID", YETKIID);
                com.Parameters.AddWithValue("@MODULID", MODULID);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {

                    OKU = Convert.ToBoolean(SDR["YTD_OKU"].ToString());
                    YAZ = Convert.ToBoolean(SDR["YTD_YAZ"].ToString());
                    SIL = Convert.ToBoolean(SDR["YTD_SIL"].ToString());
                    EKSTRA = Convert.ToBoolean(SDR["YTD_EKSTRA"].ToString());
                    USERS = S_GETGRUPUSERS();
                }

                con.Close();
            }
            catch
            {
                con.Close();
                return;
            }

        }
        public static System.Data.DataTable S_YETKI_GETVALUES_DETAY_LISTE(string YETKIID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Select *from I_MODUL m left join I_YETKIDETAY y on m.MDL_MODULID=y.YTD_MODULID  WHERE  YTD_YETKIID=@YETKIID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@YETKIID", YETKIID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_MODULLISTESI()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT MDL_ID,MDL_MODULID FROM I_MODUL";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_MODULLISTESI2(string YETKIID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Select *from I_MODUL m left join I_YETKIDETAY y on m.MDL_MODULID=y.YTD_MODULID WHERE  YTD_YETKIID=@YETKIID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@YETKIID", YETKIID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_MODULLISTESI3()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Select *,'False' as YTD_OKU,'False' as YTD_YAZ,'False' as YTD_SIL,'False' as YTD_EKSTRA from I_MODUL m left join I_YETKI y on m.MDL_MODULID=y.YT_YETKIID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
     
        public static System.Data.DataTable S_EKIP_TUM()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT  EK_KODU FROM I_EKIP  where EK_DURUM=@EK_DURUM";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@EK_DURUM", true);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_EKIP_WHERE(string ILCE)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT  EK_KODU FROM I_EKIP where EK_DURUM=@EK_DURUM";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@EK_DURUM", true);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_EKIP_ILCE_WHERE(string ILCE)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT  EK_KODU FROM I_EKIP where EK_DURUM=@EK_DURUM AND EK_ILCE=@EK_ILCE";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@EK_DURUM", true);
            daa.SelectCommand.Parameters.AddWithValue("@EK_ILCE", ILCE);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static string S_GETGRUPUSERS()
        {
            string USR_KULLANCIKODU = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT USR_KULLANCIKODU FROM I_USERS WHERE USR_GRUPKODU=@ID", con);
                com.Parameters.AddWithValue("@ID",StatikData.SS_GRUP);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    USR_KULLANCIKODU = SDR["USR_KULLANCIKODU"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return USR_KULLANCIKODU;
        }
        public static string S_GETALARM_ALTOLAY(string alarmid)
        {
            string A_ALTOLAYID = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT A_ALTOLAYID FROM I_ALARM WHERE A_ID=@ID", con);
                com.Parameters.AddWithValue("@ID", alarmid);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    A_ALTOLAYID = SDR["A_ALTOLAYID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return A_ALTOLAYID;
        }
        public static string S_GETOLAYKOD_ID(string ID)
        {
            string KOD = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT A_UID FROM I_ALTOLAY WHERE A_ID=@ID", con);
                com.Parameters.AddWithValue("@ID", ID);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    KOD = SDR["A_UID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return KOD;
        }
        public static string S_LOGKONTROL(string Inbarid, string kanal, string logid)
        {
            string L_ID = "";
            try
            {

                string INsorgu = "";
                INsorgu = Helper.KANALISLEM(kanal);   
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT L_ID FROM I_LOG WHERE L_IHBARID=@L_IHBARID AND L_SICILNO=@SICILNO AND L_KANAL in("+ INsorgu + ") and L_ISLEM=@ID", con);
                com.Parameters.AddWithValue("@SICILNO", HttpContext.Current.Session["USR_SICILNO"]);
                com.Parameters.AddWithValue("@L_IHBARID", Inbarid);

                com.Parameters.AddWithValue("@ID", logid);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    L_ID = SDR["L_ID"].ToString();
                }
                con.Close();
            }
            catch(Exception c)
            {
                con.Close();
            }
            return L_ID;
        }

        public static string S_EKIPKONTROL(string EG_EKKODU, string EG_IHKODU,string KANAL)
        {
            string L_ID = "";
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT EG_ID FROM I_IHBAREKIP WHERE EG_EKKODU=@EG_EKKODU AND  EG_IHKODU=@EG_IHKODU and EG_KANAL=@EG_KANAL", con);
                com.Parameters.AddWithValue("@EG_EKKODU", EG_EKKODU);
                com.Parameters.AddWithValue("@EG_IHKODU", EG_IHKODU);
                com.Parameters.AddWithValue("@EG_KANAL", KANAL);

                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    L_ID = SDR["EG_ID"].ToString();
                }
                con.Close();
            }
            catch (Exception c)
            {
                con.Close();
            }
            return L_ID;
        }
   
        public static System.Data.DataTable S_YETKI_YUKLE()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_YETKI";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_YETKI_MODUL_LISTESI()
        {

            SqlConnection con = new SqlConnection();
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT MDL_MODULID FROM I_MODUL";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_EKIPTELEFON_LISTESI(String kodu, string telefon, string adsoyad, string gorevi, string gorevyeri)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_EKIPTELEFON where 1=1 ";
            if (kodu != "")
            {
                sorgu += " and E_KODU = '" + kodu + "'";
            }
            if (telefon != "")
            {
                sorgu += " and E_TELEFON = '" + telefon + "'";
            }
            if (adsoyad != "")
            {
                sorgu += " and E_ISIMSOYISIM = '" + adsoyad + "'";
            }
            if (gorevi != "")
            {
                sorgu += " and E_GOREVI = '" + gorevi + "'";
            }
            if (gorevyeri != "")
            {
                sorgu += " and E_GOREVYERI = '" + gorevyeri + "'";
            }

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_EKIPTELEFON_LISTESI(String Telefon)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_EKIPTELEFON";
            if (Telefon!="")
            {
                sorgu += " where E_TELEFON = '" + Telefon + "'";
            }
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_EKIPTELEFON_LISTESI()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT [USR_SICILNO]
      ,[USR_ADI]
  FROM [dbo].[I_USERS]";
          
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_EKIPTELEFON_LISTESI_WHERE(string ID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_EKIPTELEFON where E_ID=@ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_USER_LISTESI()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *,(USR_ADI+' '+USR_SOYADI)AS USERAD FROM I_USERS U Left Join I_YETKI Y on U.USR_YETKIKODU=Y.YT_YETKIID left join I_GRUP G ON G.GRP_KODU=U.USR_GRUPKODU";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GRUP_LISTESI()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_GRUP";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_IHABARGRUP_LISTESI()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_IHBAR_GRUP ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static string S_GETTELEFONKONTROL(string TELEFON)
        {
            string id = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT E_ID FROM I_EKIPTELEFON where E_TELEFON=@E_TELEFON", con);
                com.Parameters.AddWithValue("@E_TELEFON", TELEFON);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    id = SDR["E_ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();

            }
            return id;
        }
        public static string S_GETYETKIADI_KONTROL(string YETKIADI)
        {
            string yetkiadi = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT YT_YETKIADI FROM I_YETKI where YT_YETKIADI=@YETKIADI", con);
            com.Parameters.AddWithValue("@YETKIADI", YETKIADI);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                yetkiadi = SDR["YT_YETKIADI"].ToString();
            }
            con.Close();
            return yetkiadi;
        }
        public static int S_GETMAXYETKIID()
        {
            int sayi = 0;

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT ISNULL(MAX(YT_ID),0)+1 AS SAYI FROM I_YETKI", con);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                sayi = Convert.ToInt32(SDR["SAYI"].ToString());
            }
            con.Close();
            return sayi;
        }
        public static int S_GETKULLANICIID()
        {
            int sayi = 0;

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT ISNULL(MAX(USR_KULLANCIKODU),0)+1 AS SAYI FROM I_USERS", con);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                sayi = Convert.ToInt32(SDR["SAYI"].ToString());
            }
            con.Close();
            return sayi;
        }
        public static int S_GETMAXGRUP()
        {
            int sayi = 0;

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT ISNULL(MAX(GRP_ID),0)+1 AS SAYI FROM I_GRUP", con);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                sayi = Convert.ToInt32(SDR["SAYI"].ToString());
            }
            con.Close();
            return sayi;
        }
        public static void S_USERS_GETDETAY(string USR_ID, ref string USR_SICILNO, ref string USR_ADI, ref string USR_SOYADI, ref string USR_KULLANICIADI, ref string USR_SIFRE, ref string USR_YETKIKODU, ref string USR_GRUPKODU, ref string USR_KANALYETKI, ref string USR_ONAYYETKI, ref string USR_TELEFON_EV, ref string USR_TELEFON_IS, ref string USR_TELEFON_GSM, ref string USR_RUTBE, ref string USR_GOREV, ref string USR_TELSIZKANAL, ref string USR_VARDIYA, ref string USR_DAHILI, ref object USR_IL, ref string USR_ILCE, ref string USR_SUBE, ref bool USR_DURUM, ref string USR_YETKIADI, ref string USR_GRUPADI, ref object USR_EKIPKODU, ref bool USR_KNLSEC)
        {

            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT * FROM I_USERS U Left Join I_YETKI Y on U.USR_YETKIKODU=Y.YT_YETKIID left join I_GRUP G ON G.GRP_KODU=U.USR_GRUPKODU WHERE U.USR_ID=@USR_ID", con);
                com.Parameters.AddWithValue("@USR_ID", USR_ID);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {

                    USR_SICILNO = SDR["USR_SICILNO"].ToString();
                    USR_ADI = SDR["USR_ADI"].ToString();
                    USR_SOYADI = SDR["USR_SOYADI"].ToString();
                    USR_KULLANICIADI = SDR["USR_KULLANICIADI"].ToString();
                    USR_SIFRE = SDR["USR_SIFRE"].ToString();
                    USR_YETKIKODU = SDR["USR_YETKIKODU"].ToString();
                    USR_GRUPKODU = SDR["USR_GRUPKODU"].ToString();
                    USR_KANALYETKI = SDR["USR_KANALYETKI"].ToString();
                    USR_ONAYYETKI = SDR["USR_ONAYYETKI"].ToString();
                    USR_TELEFON_EV = SDR["USR_TELEFON_EV"].ToString();
                    USR_TELEFON_IS = SDR["USR_TELEFON_IS"].ToString();
                    USR_TELEFON_GSM = SDR["USR_TELEFON_GSM"].ToString();
                    USR_RUTBE = SDR["USR_RUTBE"].ToString();
                    USR_GOREV = SDR["USR_GOREV"].ToString();
                    USR_TELSIZKANAL = SDR["USR_TELSIZKANAL"].ToString();
                    USR_VARDIYA = SDR["USR_VARDIYA"].ToString();
                    USR_DAHILI = SDR["USR_DAHILI"].ToString();
                    USR_IL = SDR["USR_IL"];
                    USR_ILCE = SDR["USR_ILCE"].ToString();
                    USR_SUBE = SDR["USR_SUBE"].ToString();
                    USR_DURUM = Convert.ToBoolean(SDR["USR_DURUM"].ToString());
                    USR_YETKIADI = SDR["YT_YETKIADI"].ToString();
                    USR_GRUPADI = SDR["GRP_ADI"].ToString();
                    USR_EKIPKODU = SDR["USR_EKIPKODU"];
                    USR_KNLSEC = Convert.ToBoolean(SDR["USR_KNLSEC"] != null ? SDR["USR_KNLSEC"] : false);
                }

                con.Close();
            }
            catch
            {
                con.Close();
                return;
            }

        }
        public static System.Data.DataTable S_TERMINAL()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_ARAC()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_ARAC where ARC_DURUM='True'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KANAL()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True' AND KNL_YETKI in ('K','I') AND KNL_TRAFIK='1'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KANAL_WHERE(string KANAL)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True' AND KNL_YETKI in ('K','I') AND KNL_TRAFIK='1' and KNL_KODU in("+KANAL+")";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_KANALGRUP()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT KG_GRUPADI,KG_KANAL FROM I_KANALGRUP where [KG_DURUM]=1";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_TRAFIKKANAL()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KANAL where KNL_TRAFIK=2 AND KNL_YETKI='K' order by KNL_KODU";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KANAL_TUM(string ilce)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select '' KNL_ID,'' KNL_KODU,'' KN_ADI,'' KNL_YETKI,'' KNL_TRAFIK,'' KNL_ILCE,'' KNL_DURUM,'' KNL_DIGERKANAL  union all SELECT * FROM I_KANAL where KNL_DURUM='True' and KN_ADI like '%" + ilce+"%'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KANAL_TUM2()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True' ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KANAL_ILCE()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True' AND KNL_YETKI='I'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_MESAJ(string IHBARID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_IHBAR_MESAJ where IN_IHID=@IN_IHID ORDER BY IN_TARIHSAAT DESC";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@IN_IHID", IHBARID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_MESAJTELEFON(string Telefon)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT IN_TARIHSAAT,IN_KULLANICI,IN_OLAYKODU,IN_MESAJ FROM I_IHBAR_MESAJ m INNER JOIN I_IHBAR i ON m.IN_IHID = i.I_ID  where i.I_TELEFON LIKE '%"+Telefon+"' ORDER BY IN_TARIHSAAT DESC";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_IL()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_IL order by AD asc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_ILCE(string ILID)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_ILCE WHERE ILID=@ILID order by AD asc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ILID", ILID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_Mahalle(string ILCEID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_MAHALLE WHERE I_ILCEID=@I_ILCEID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCEID", ILCEID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_MahalleIN(string ILCEID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_MAHALLE WHERE I_ILCEID In ("+ILCEID+")";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_CADDE(string ILCEID, string MAHALLEID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_CADDE WHERE I_SID=@I_SID AND I_TYPE='road'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_SID", MAHALLEID);
            daa.SelectCommand.Parameters.AddWithValue("@I_ILCEID", ILCEID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_CADDEIN(string ILCEID, string MAHALLEID)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_CADDE WHERE I_SID IN ("+MAHALLEID+ ") AND I_TYPE='road'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_SUBE()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_SUBE ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
 
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
     
        public static System.Data.DataTable S_IHBAR_GETDETAY_DETAY2(string Id)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *from I_IHBARDETAY WHERE ID_IHID=@ID and I_AKTIF='True' and (I_AMB='True' or I_ITF='True')";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", Id);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETKONUM(string tarih1, string tarih2)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT I_ISIMSOYISIM,I_LATITUDE,I_LONGITUDE FROM I_IHBAR where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_KULLANICI=@I_KULLANICI AND I_IHBARDURUM='False' ";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"]);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETKONUM_KANAL(string tarih1, string tarih2)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT I_ISIMSOYISIM,I_LATITUDE,I_LONGITUDE FROM I_IHBAR where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2  AND I_KANAL=@USR_KANALYETKI AND I_IHBARDURUM='False'";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI",HttpContext.Current.Session["SS_KANAL"].ToString());
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
      
        public static System.Data.DataTable S_GETIHBAR_EKIP(string tarih1, string tarih2, bool tip)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT distinct I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,I_ILCE,I.I_KULLANICI,I_USTOLAYKODU as I_OLAYADI,I_ALTOLAYKODU as I_ALTOLAYADI,I_TARIH as SAAT,I.I_IHBARDURUM,EG_ULASMATARIH,EG_SONTARIH,EG_KABULTARIH FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  JOIN I_IHBAREKIP IE ON I.I_ID=IE.EG_IHKODU  where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2 and EG_EKKODU=@EG_EKKODU and I.I_EKIPIHBAR=@I_EKIPIHBAR";

            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            daa.SelectCommand.Parameters.AddWithValue("@I_EKIPIHBAR", tip);
            daa.SelectCommand.Parameters.AddWithValue("@EG_EKKODU",StatikData.SS_EKIPKODU);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
     
        public static System.Data.DataTable S_GETIHBAR_LISTE(string tarih1, string tarih2)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *,I_ALTOLAYKODU as I_OLAYADI FROM I_IHBAR I join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_KULLANICI=@I_KULLANICI order by I_ONCELIKLI desc ,I_TARIH desc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"]);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL(string tarih1, string tarih2,string tip)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}

            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
         string sorgu = @"SELECT top("+ Helper.SS_IHBARLISTESI_COUNT+ ") i.I_ID,d.I_KANAL, I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL and T.I_KANAL in(" + INsorgu + @") ),cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE  L_IHBARID=i.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') and L.L_KANAL =D.I_KANAL), d.I_DURUM,i.I_LATITUDE,i.I_LONGITUDE,I_USTOLAYKODU,i.I_ISIMSOYISIM,i.I_TELEFON,i.I_IHBARTUR,i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,I_USTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,(case when i.I_MAHALLE!='' then (select mAX(I_ADI) FROM I_MAHALLE WHERE I_MAHID=i.I_MAHALLE) else '' end)as cmpt_mahalle,
cmpt_count=(select count(distinct(I_ID)) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True' AND  ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 group by I_TELEFON)   FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE   where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 and   k.KNL_KODU IN (" + INsorgu + ") and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' and I_IHBARTUR='" + tip + "' order by I_ONCELIKLI desc ,I_TARIH asc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_KONTROL(string tarih1, string tarih2, string tiplist)
        {
            string INsorgu = "";
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT  i.I_IHBARTUR, count(I_IHBARTUR) IHBARSAYISI FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID 
             where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 and d.I_KANAL IN (" + INsorgu + ") and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' and I_IHBARTUR IN  (" + tiplist + ") group by I_IHBARTUR";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_ICERIK(string tarih1, string tarih2,string ICERIK,string tip)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT  I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   
T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL and T.I_KANAL in(" + INsorgu + @") ),cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=i.I_ID  AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') and L.L_KANAL in(" + INsorgu + @")),d.I_DURUM,i.I_LATITUDE,i.I_LONGITUDE,i.I_IHBARTUR,I_USTOLAYKODU,i.I_ISIMSOYISIM,i.I_TELEFON,i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,I_USTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,cmpt_count=(select count(distinct(I_ID)) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True' AND  ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON  group by I_TELEFON)    FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE  where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 and k.KNL_KODU IN (" + INsorgu + ") and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' AND (I_IHBARBILGISI like '%" + ICERIK + "%' or I_ADRES like '%" + ICERIK + "%') and I_IHBARTUR='" + tip + "' order by I_ONCELIKLI desc ,I_TARIH desc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_ICERIK_2(string tarih1, string tarih2, string ICERIK, string tip)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   
T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL and T.I_KANAL in(" + INsorgu + @") ),cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=i.I_ID AND L_KANAL= L.L_ASILKANAL AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') and L.L_KANAL in(" + INsorgu + @")),d.I_DURUM,i.I_LATITUDE,i.I_LONGITUDE,i.I_IHBARTUR,I_USTOLAYKODU,i.I_ISIMSOYISIM,i.I_TELEFON,i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,I_USTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,cmpt_count=(select count(distinct(I_ID)) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True' AND  ii.I_TELEFON=i.I_TELEFON and I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON  group by I_TELEFON)    FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE  where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 and k.KNL_KODU IN (" + INsorgu + ") and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' AND (I_IHBARBILGISI like '%" + ICERIK + "%' or I_ADRES like '%" + ICERIK + "%')  order by I_ONCELIKLI desc ,I_TARIH desc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_KAPALI()
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",")==true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString()  + ""; 
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
           
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT top(" + Helper.SS_KAPALIIHBARLISTESI_COUNT + ") cmpt_kapanis=(select count(IK_ID) from I_IHBARKAPANIS WHERE IK_IHBARID=i.I_ID),d.I_KANAL,cmpt_count=(select count(distinct(I_ID)) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and d.I_UPDATEDATE>=dateadd(hour,-24,getdate()) and d.I_UPDATEDATE<=getdate() ) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + @") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and d.I_UPDATEDATE>=dateadd(hour,-24,getdate()) and d.I_UPDATEDATE<=getdate() group by I_TELEFON),I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL and T.I_KANAL =d.I_KANAL  ),cmpt_islemdurum=(SELECT
L_ISLEM =(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=i.I_ID  AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') and L.L_KANAL in(" + INsorgu + @")),cmpt_tarih=(SELECT L_TARIHSAAT=(select max(L_TARIHSAAT) from I_LOG WHERE L_IHBARID=i.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') and L.L_KANAL in(" + INsorgu + ")),i.I_LATITUDE,i.I_IHBARTUR,i.I_LONGITUDE,i.I_ISIMSOYISIM,i.I_TELEFON,i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,I_USTOLAYKODU,d.I_DURUM,(case when i.I_MAHALLE!='' then (select mAX(I_ADI) FROM I_MAHALLE WHERE I_ILCEID=i.I_ILCE AND I_MAHID=i.I_MAHALLE) else '' end)as cmpt_mahalle FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE   where d.I_UPDATEDATE>=dateadd(hour,-24,getdate()) and d.I_UPDATEDATE<=getdate()  AND k.KNL_KODU IN(" + INsorgu + ") and  d.I_AKTIF='True' AND d.I_DURUM='False'  order by cmpt_tarih desc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_KAPALI_ICERIK(string ICERIK)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT  cmpt_count=(select count(distinct(I_ID)) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and d.I_UPDATEDATE>=dateadd(hour,-24,getdate()) and d.I_UPDATEDATE<=getdate() ) ,cmpt_count2=(select max(ii.I_ID) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu + ") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True'  and ii.I_TELEFON=i.I_TELEFON and d.I_UPDATEDATE>=dateadd(hour,-24,getdate()) and d.I_UPDATEDATE<=getdate() group by I_TELEFON),I_TAKIPDURUM=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   T.I_IHBARID=i.I_ID AND T.I_KANAL=d.I_KANAL and T.I_KANAL in(" + INsorgu + @") ),cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=i.I_ID  AND L_KANAL= L.L_ASILKANAL AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=i.I_ID and L_ISLEM not in ('11') and L.L_KANAL in(" + INsorgu + @")),i.I_LATITUDE,i.I_IHBARTUR,i.I_LONGITUDE,i.I_ISIMSOYISIM,i.I_TELEFON,i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,I_USTOLAYKODU,d.I_DURUM  FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE  where d.I_UPDATEDATE>=dateadd(hour,-24,getdate()) and d.I_UPDATEDATE<=getdate()  AND k.KNL_KODU IN(" + INsorgu + ") and  d.I_AKTIF='True' AND d.I_DURUM='False' AND (I_IHBARBILGISI like '%" + ICERIK + "%' or I_ADRES like '%" + ICERIK + "%')  order by I_ONCELIKLI desc ,I_TARIH desc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static bool S_GetIhbarDurum(string Id,string ch)
        {
            bool durum = false;
            try
            {
               

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT d.I_DURUM  FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID  where i.I_ID='"+Id+"' and d.I_KANAL = '"+ ch + "' ", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    durum = Convert.ToBoolean(SDR["I_DURUM"].ToString());
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return durum;
        }
        public static bool S_GetIhbarEkipDurum(string Id)
        {
            bool durum = false;
            try
            {
                string INsorgu = "";
                //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
                //{
                //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
                //}
                //else
                //{
                //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
                //}
                INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT d.I_EKIP  FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID  where i.I_ID='" + Id + "' and d.I_KANAL IN(" + INsorgu + ")", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    durum = Convert.ToBoolean(SDR["I_EKIP"].ToString());
                }
                con.Close();
            }
            catch(Exception c)
            {
                con.Close();
            }
            return durum;
        }
        public static string S_GetIhbarDurum_Ekip(string Id)
        {
            string durum = "";
            try
            {

                 string INsorgu = "";
                //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
                //{
                //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
                //}
                //else
                //{
                //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
                //}
                INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT EG_SONTARIH  FROM I_IHBAREKIP   where EG_IHKODU='" + Id + "' AND EG_KANAL in(" + INsorgu + ")", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    durum = SDR["EG_SONTARIH"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return durum;
        }
        public static string S_GetIhbarEkipKontrol(string Id)
        {
            string durum = "";
            try
            {

                string INsorgu = "";
                //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
                //{
                //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
                //}
                //else
                //{
                //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
                //}
                INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT EG_ID  FROM I_IHBAREKIP   where EG_IHKODU='" + Id + "' AND EG_KANAL in(" + INsorgu + ")", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    durum = SDR["EG_ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return durum;
        }
        public static int S_GETIHBAR_KAPANIS_KANAL(string IK_IHBARID, string KANAL)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT COUNT(*) FROM I_IHBARKAPANIS WHERE IK_IHBARID=@IK_IHBARID AND IK_KANAL=@IK_KANAL";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@IK_IHBARID", IK_IHBARID);
            daa.SelectCommand.Parameters.AddWithValue("@IK_KANAL", KANAL);
            daa.Fill(dtt);
            con.Close();
            if (dtt != null && dtt.Rows.Count != 0)
            {
                return Convert.ToInt32(dtt.Rows[0][0]);
            }
            else
            {
                return 0;
            }


        }

        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_ILCE(string tarih1, string tarih2)
        {
            string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,cmpt_count=(select count(distinct(I_ID)) from I_IHBAR as ii join I_IHBARDETAY as d on ii.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=ii.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=ii.I_ILCE where  k.KNL_KODU IN (" + INsorgu+") and ii.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' and ii.I_TELEFON=i.I_TELEFON )  FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_ILCEKANAL IN("+INsorgu+") AND I_DURUM='İletilen' and I_IHBARDURUM='False' and I_IHBARDURUM_ILCE='False'";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_KAPALI_ILCE(string tarih1, string tarih2)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD  FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_ILCEKANAL IN(@USR_KANALYETKI) AND I_DURUM='İletilen' and I_IHBARDURUM='False' and I_IHBARDURUM_ILCE='True'";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
            daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI", Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString()));

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_LOG(string Id)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"

SELECT   cmpt_ihbardurum=(SELECT max(T.I_TIP) AS I_TAKIPDURUM  FROM I_IHBARTAKIP T where   
T.I_IHBARID=@L_IHBARID AND T.I_KANAL=L.L_ASILKANAL and T.I_KANAL in (" + INsorgu + ") ),L_ASILKANAL,(select KNL_KODU+' - '+KN_ADI from I_KANAL WHERE KNL_KODU=MAX(L.L_ASILKANAL))as L_ASILKANAL ,L_ISLEM =(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=@L_IHBARID AND (L_KANAL= L.L_ASILKANAL or L_ASILKANAL = L.L_ASILKANAL)  AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)),(case when max(L_ISLEM)=11 then null else max(L_TARIHSAAT) end)as L_TARIHSAAT,(case when max(L_ISLEM)=11 then null else L_SICILNO end)as L_SICILNO,LOGMESAJ=(case when (select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=@L_IHBARID AND (L_KANAL= L.L_ASILKANAL or L_ASILKANAL = L.L_ASILKANAL)  AND L_TARIHSAAT=MAX(l.L_TARIHSAAT))=9 THEN (select max(LOGMESAJ) FROM I_LOGMESAJ WHERE ID=(SELECT max(L_ISLEM) FROM I_LOG WHERE L_ID=max(l.L_ID)))+'('+(SELECT [dbo].[KANALISIMLERIGETIR](@L_IHBARID,L_ASILKANAL))+')' ELSE (select max(LOGMESAJ) FROM I_LOGMESAJ WHERE ID=(SELECT max(L_ISLEM) FROM I_LOG WHERE L_ID=max(l.L_ID))) END) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=@L_IHBARID  and L_ISLEM not in ('11')  AND L_SICILNO<>'NULL' group by L_ASILKANAL,L_SICILNO  UNION all SELECT cmpt_ihbardurum=null, L_KANAL as L_ASILKANAL,(select KNL_KODU+' - '+KN_ADI from I_KANAL WHERE KNL_KODU=L.L_KANAL)as L_ASILKANAL , L_ISLEM ='11',L_TARIHSAAT,(case when L_ISLEM=11 then null else L_SICILNO end)as L_SICILNO, LOGMESAJ='İşlem Yapılmadı' from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=@L_IHBARID  and L_ISLEM  in ('11') and L_KANAL not in((select s.L_KANAL from I_LOG s WHERE  s.L_IHBARID=@L_IHBARID  and s.L_ISLEM not in ('11') and s.L_KANAL=L_KANAL))group by L_ASILKANAL,L_SICILNO,l.L_TARIHSAAT,L_ISLEM,L_ID,L_KANAL  order by L_TARIHSAAT desc";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@L_IHBARID", Id);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static string S_GetToplamIhbar()
        {
            string COUNT = "";
            try
            {

                string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_KANAL IN ("+INsorgu+") AND I_IHBARDURUM='False'", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    COUNT = SDR["ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return COUNT;
        }
        public static string S_GetIhbarKontrol(string ihbarid, string kanal)
        {
            string COUNT = "";
            try
            {

                string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT ID_ID FROM I_IHBARDETAY WHERE I_KANAL IN("+INsorgu+") AND ID_IHID=@ID", con);
                com.Parameters.AddWithValue("@ID", ihbarid);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    COUNT = SDR["ID_ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return COUNT;
        }
        public static string S_GetToplamYonIhbar()
        {
            string COUNT = "";
            try
            {

                string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_ASILKANAL IN("+INsorgu+") AND I_IHBARDURUM='False' and I_ASILKANAL!=I_KANAL", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    COUNT = SDR["ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return COUNT;
        }
        public static string S_GetToplamIhbarKanal()
        {
            string COUNT = "";
            try
            {

                string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_KANAL in(" + INsorgu + @") and I_TARIH>=@tarih1 and I_TARIH<=@tarih2", con); 
                com.Parameters.AddWithValue("@tarih1",Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 00:00:00"));
                com.Parameters.AddWithValue("@tarih2", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 23:59:59"));
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    COUNT = SDR["ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return COUNT;
        }
        public static string S_GetToplamIhbar_ILCE()
        {
            string COUNT = "";
            try
            {

                string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_ILCEKANAL IN ("+INsorgu+") AND I_IHBARDURUM='False'", con);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    COUNT = SDR["ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return COUNT;
        }
        public static string S_GetToplamYonIhbar_ILCE()
        {
            string COUNT = "";
            try
            {

               string INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_ILCEKANAL IN ("+INsorgu+") AND I_IHBARDURUM='False' and I_ASILKANAL!=I_KANAL", con);

                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    COUNT = SDR["ID"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return COUNT;
        }
        public static string S_GEARAMADURUM()
        {
            string TELEFON = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand(@"
DECLARE @KID BIGINT  = 0;
DECLARE @TELEFON VARCHAR(50)  = '';

SELECT TOP 1 @KID=TMP_ID,@TELEFON =TMP_TELEFON FROM I_TEMP_TELEFON WHERE TMP_TARIH>=DATEADD(MINUTE,-30,GETDATE()) AND TMP_AGENT=@AGENT AND ISREAD = 0
if(@KID!=0)
begin
update I_TEMP_TELEFON SET ISREAD = 1 WHERE TMP_ID =@KID
end
SELECT @TELEFON AS TMP_TELEFON", con);
                //com.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).AddSeconds(-4).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                com.Parameters.AddWithValue("@AGENT", HttpContext.Current.Session["USR_SICILNO"]);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    TELEFON = SDR["TMP_TELEFON"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return TELEFON;
        }
        public static System.Data.DataTable S_GETARAMA_DETAY(string Telefon)
        {
            Connection.OpenConnectionCustomer(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            try
            {

                string sorgu = "select top(1) * from Contacts c join Numbers n on c.Id=n.ContactId where n.Number like '%"+Telefon+"'";

                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);

                daa.Fill(dtt);
                con.Close();
            }
            catch
            {
                con.Close();

            }
            return dtt;

        }

       //TEST CAGRI METODLARI
        public static System.Data.DataTable S_GETcontacts()
        {
            Connection.OpenConnectionCustomer(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            try
            {

                string sorgu = "select top 500 max(c.Name) ad,max(c.SurName) soyad,n.Number from Contacts c join Numbers n on c.Id=n.ContactId where Number<>''  group by Number order by number";

                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.Fill(dtt);
                con.Close();
            }
            catch
            {
                con.Close();

            }
            return dtt;

        }
        public static System.Data.DataTable S_GETTELEFON_LOKASYON(string IlceId, string Isim)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT LONG AS 'I_LONGITUDE' ,LAT AS 'I_LATITUDE','" + Isim + "' as I_ISIMSOYISIM FROM I_ILCE WHERE ILCEID=@IlceId";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@IlceId", IlceId);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static string S_GETTOPLAMPlaka(string Plaka)
        {
            string toplam = "0";
            try
            {

                if (Plaka != "")
                {
                    Connection.OpenConnection(ref con);
                    SqlCommand com = new SqlCommand("SELECT count(I_PLAKA)as Toplam FROM I_IHBAR WHERE I_PLAKA like '%" + Plaka + "'", con);
                    com.Parameters.AddWithValue("@I_PLAKA", Plaka);
                    SqlDataReader SDR = com.ExecuteReader();
                    if (SDR.Read())
                    {
                        toplam = SDR["Toplam"].ToString();
                    }
                    con.Close();
                }
            }
            catch
            {
                con.Close();
            }
            return toplam;
        }
        public static string S_GETTOPLAMCAGRI(string Telefon)
        {
            string toplam = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_TELEFON)as Toplam FROM I_IHBAR WHERE I_TELEFON = '"+Telefon+"'", con);
                com.Parameters.AddWithValue("@I_TELEFON", Telefon);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    toplam = SDR["Toplam"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return toplam;
        }
        public static string S_GETTOPLAMCAGRI_GUNLUK(string Telefon)
        {
            string toplam = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_TELEFON)as Toplam FROM I_IHBAR WHERE I_TELEFON = '"+Telefon+"' and I_TARIH>=@TARIH1 AND I_TARIH<=@TARIH2 ", con);
                com.Parameters.AddWithValue("@I_TELEFON", Telefon);
                com.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 00:00:00"));
                com.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 23:59:59"));

                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    toplam = SDR["Toplam"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return toplam;
        }

        public static string S_GETTOPLAMCAGRILAR(string Telefon, ref string rGUNLUK, ref string rTOPLAM)
        {
            string toplam = "";
            try
            {
                Connection.OpenConnection(ref con);
                System.Data.DataTable dtt = new System.Data.DataTable();
                string sorgu = "SELECT count(I_TELEFON) as Toplam, 'GUNLUK' DEGER FROM I_IHBAR WHERE I_TELEFON = '" + Telefon + "' and I_TARIH>=@TARIH1 AND I_TARIH<=@TARIH2  UNION SELECT count(I_TELEFON) as Toplam, 'TOPLAM' DEGER FROM I_IHBAR WHERE I_TELEFON = '" + Telefon + "'";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 00:00:00"));
                daa.SelectCommand.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 23:59:59"));
                daa.Fill(dtt);
                con.Close();

                if (dtt.Rows.Count > 0)
                {
                  DataRow drGunluk = dtt.Select("DEGER='GUNLUK'")[0];
                    rGUNLUK = drGunluk["TOPLAM"].ToString();
                  DataRow drToplam = dtt.Select("DEGER='TOPLAM'")[0];
                    rTOPLAM = drToplam["TOPLAM"].ToString();
                }
               


               /* Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT count(I_TELEFON) as Toplam, 'GUNLUK' DEGER FROM I_IHBAR WHERE I_TELEFON = '" + Telefon + "' and I_TARIH>=@TARIH1 AND I_TARIH<=@TARIH2  UNION SELECT count(I_TELEFON) as Toplam, 'TOPLAM' DEGER FROM I_IHBAR WHERE I_TELEFON = '" + Telefon + "'", con);
                com.Parameters.AddWithValue("@I_TELEFON", Telefon);
                com.Parameters.AddWithValue("@TARIH1", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 00:00:00"));
                com.Parameters.AddWithValue("@TARIH2", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd 23:59:59"));

                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    toplam = SDR["Toplam"].ToString();
                }
                SDR.Close();
                con.Close();*/
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                    con.Close();

            }
            return toplam;
        }
        public static System.Data.DataTable S_DASHBOARD(string tarih1, string tarih2)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT COUNT(I_ID) AS ADET,I_USTOLAYKODU,count((CASE WHEN I_IHBARDURUM='True' THEN '0' END)) AS ACIK,count((CASE WHEN I_IHBARDURUM='False' THEN '0' END)) AS KAPALI FROM I_IHBAR   WHERE I_TARIH>=@tarih1 AND I_TARIH<=@tarih2 GROUP BY I_USTOLAYKODU";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@tarih1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@tarih2", tarih2);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_EKIPDURUMLISTE(string ID)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select EK.EG_ID,EK.EG_EKKODU,EK.EG_KANAL,EK.EG_TARIH,EK.EG_ULASMATARIH,EK.EG_SONTARIH,EG_KABULTARIH,T.EK_TIP,T.EK_KODU, IK.IK_NOT, IK.IK_TIP   FROM I_IHBAREKIP AS EK left JOIN I_KANAL AS K ON EK.EG_KANAL=K.KNL_KODU LEFT JOIN I_EKIPTAKIP AS T ON T.EK_KODU=EK.EG_ID LEFT JOIN I_IHBARKAPANIS AS IK ON EK.EG_EKKODU = IK.IK_EKIP and EK.EG_IHKODU = IK.IK_IHBARID  where EK.EG_IHKODU=@ID";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static int S_GETIHBAR_EKIPDURUMLISTE(string ID,string KANAL)
        {
            int toplam = 0;
            try
            {

           
            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand(" select count(*) as toplam  FROM I_IHBAREKIP AS EK left JOIN I_KANAL AS K ON EK.EG_KANAL=K.KNL_KODU LEFT JOIN I_EKIPTAKIP AS T ON T.EK_KODU=EK.EG_ID where EK.EG_IHKODU=@ID and EK.EG_KANAL = @KANAL ", con);
            com.Parameters.AddWithValue("@ID", ID);
            com.Parameters.AddWithValue("@KANAL", KANAL);

            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                toplam =  Convert.ToInt32(SDR["toplam"]);
            }
            con.Close();
            }
            catch (Exception)
            {

                toplam = 0;
            }
            return toplam;
            

        }
        public static System.Data.DataTable S_GETIHBAR_LISTE_WHERE(string ID)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select EG_ULASMATARIH,EG_SONTARIH,EG_KABULTARIH  FROM I_IHBAREKIP  where EG_IHKODU=@ID";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_KAPANISLISTE(string ID)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select *from I_IHBARKAPANIS where IK_IHBARID=@ID";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETLOG(string tip)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select *from I_LOGMESAJ where LOGTIP=@ID";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", tip);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static int S_GETEKIP_KONTROL(string EKIP)
        {
            int sayi = 0;

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT EG_ID FROM I_IHBAREKIP WHERE EG_TARIH is not null and EG_ULASMATARIH is null and EG_SONTARIH is null and EG_EKKODU=@EKIP", con);
            com.Parameters.AddWithValue("@EKIP", EKIP);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                sayi = Convert.ToInt32(SDR["EG_ID"].ToString());
            }
            con.Close();
            return sayi;
        }
        public static System.Data.DataTable S_KANAL_ILCE_DETAY(string ilce)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select  KNL_KODU,KNL_ILCE FROM I_KANAL where KNL_ILCE LIKE '%" + ilce + "%'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_TRAFIKKANAL_ILCE_DETAY(string ilce)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " select  KNL_KODU,KNL_ILCE FROM I_KANAL where KNL_ILCE LIKE '%" + ilce + "%' AND KNL_TRAFIK = 2";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETARAYAN_LISTESI(string tarih1, string tarih2, string ihbarcitel)
        {
            System.Data.DataTable dtt = new System.Data.DataTable();
            try
            {
                Connection.OpenConnection(ref con);

                string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=I.I_ID  AND L_KANAL= L.L_ASILKANAL AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,M.I_ADI AS MAHALLE,C.AD AS ILCE,I_IHBARTUR  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID left join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID left join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID left join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
                if (ihbarcitel != "")
                {
                    sorgu += " and I_TELEFON = '" + ihbarcitel + "'";
                }

                sorgu += " order by I_TARIH desc";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
                daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);

                daa.Fill(dtt);
                con.Close();
            }
            catch
            {
                return null;
            }
            return dtt;

        }
        public static System.Data.DataTable S_GETARAYAN_LISTESI_MAHALLE(string tarih1, string tarih2, string mahalle)
        {
            System.Data.DataTable dtt = new System.Data.DataTable();
            try
            {
                Connection.OpenConnection(ref con);

                string sorgu = "SELECT distinct I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,M.I_ADI AS MAHALLE,C.AD AS ILCE,I_IHBARTUR  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID left join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID left join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID left join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
                if (mahalle != "")
                {
                    sorgu += " and I.I_MAHALLE = '" + mahalle + "'";
                }

                sorgu += " order by I_TARIH desc";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
                daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);

                daa.Fill(dtt);
                con.Close();
            }
            catch
            {
                return null;
            }
            return dtt;

        }
        public static System.Data.DataTable S_GETARAYAN_LISTESI_PLAKA(string tarih1, string tarih2, string plaka)
        {
            System.Data.DataTable dtt = new System.Data.DataTable();
            try
            {
                Connection.OpenConnection(ref con);

                string sorgu = "SELECT distinct I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,M.I_ADI AS MAHALLE,C.AD AS ILCE,I_IHBARTUR  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID left join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID left join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID left join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
                if (plaka != "")
                {
                    sorgu += " and I.I_PLAKA = '" + plaka + "'";
                }

                sorgu += " order by I_TARIH desc";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
                daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);

                daa.Fill(dtt);
                con.Close();
            }
            catch
            {
                return null;
            }
            return dtt;

        }
        public static string S_GETIHBARADET()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " SELECT  COUNT(*)AS SAYI FROM I_IHBAR where I_KULLANICI = '" + HttpContext.Current.Session["USR_SICILNO"] + "' and I_TARIH BETWEEN CONVERT(DATETIME, CONVERT(varchar(11),getdate(), 111 ) + ' 00:00:00', 111) and CONVERT(DATETIME, CONVERT(varchar(11),getdate(), 111 ) + ' 23:59:59', 111)";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            if (dtt.Rows.Count != 0)
                return dtt.Rows[0][0].ToString();
            else
                return "0";

        }

        public static string S_MAHALLEIHBARADET(string p)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " SELECT  COUNT(*) AS SAYI FROM I_IHBAR where  I_TARIH BETWEEN CONVERT(DATETIME, CONVERT(varchar(11),getdate(), 111 ) + ' 00:00:00', 111) and CONVERT(DATETIME, CONVERT(varchar(11),getdate(), 111 ) + ' 23:59:59', 111) AND I_MAHALLE = '"+p+"'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            if (dtt.Rows.Count != 0)
                return dtt.Rows[0][0].ToString();
            else
                return "0";
        }
     
        public static int S_EKIBEAIT_ENSON_IHBAR(string EKIP)
        {
            int sayi = 0;

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand(" select TOP(1) I.I_ID from I_IHBAR I JOIN I_IHBAREKIP E ON I.I_ID=E.EG_IHKODU WHERE E.EG_EKKODU='" + EKIP + "' ORDER BY E.EG_TARIH DESC", con);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                sayi = Convert.ToInt32(SDR["I_ID"].ToString());
            }
            con.Close();
            return sayi;
        }
        public static string S_EKIBEAIT_ENSON_IHBAR_TIP(string EKIP)
        {
            string sayi ="";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand(" select TOP(1) I.I_IHBARTUR from I_IHBAR I JOIN I_IHBAREKIP E ON I.I_ID=E.EG_IHKODU WHERE E.EG_EKKODU='" + EKIP + "' ORDER BY E.EG_TARIH DESC", con);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                sayi = SDR["I_IHBARTUR"].ToString();
            }
            con.Close();
            return sayi;
        }
        public static System.Data.DataTable S_GETIHBARTELEFON(string Telefon)
        {
            try
            {

                Connection.OpenConnection(ref con);
                System.Data.DataTable dtt = new System.Data.DataTable();
                string sorgu = "SELECT * FROM I_IHBAR WHERE I_TELEFON like '%" + Telefon + "' and  I_TARIH BETWEEN CONVERT(DATETIME, CONVERT(varchar(11),getdate(), 111 ) + ' 00:00:00', 111) and CONVERT(DATETIME, CONVERT(varchar(11),getdate(), 111 ) + ' 23:59:59', 111)  order by I_TARIH DESC";

                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", Telefon);

                daa.Fill(dtt);
                con.Close();
                return dtt;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        public static void S_GETKEYS(string KEY_FORM, string KEY_OBJECT, ref string KEY_CONTROL, ref string KEY_KEYVALUE)
        {

            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT KEY_CONTROL,KEY_KEYVALUE FROM I_KEYS WHERE KEY_FORM=@KEY_FORM and KEY_OBJECT=@KEY_OBJECT", con);
                com.Parameters.AddWithValue("@KEY_FORM", KEY_FORM);
                com.Parameters.AddWithValue("@KEY_OBJECT", KEY_OBJECT);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    KEY_CONTROL = SDR["KEY_CONTROL"].ToString();
                    KEY_KEYVALUE = SDR["KEY_KEYVALUE"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
                return;
            }

        }
        public static System.Data.DataTable S_GETIHBAR_KAPANIS_SONUC(string IK_IHBARID, string IK_EKIP)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_IHBARKAPANIS WHERE IK_IHBARID=@IK_IHBARID AND IK_EKIP=@IK_EKIP";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@IK_IHBARID", IK_IHBARID);
            daa.SelectCommand.Parameters.AddWithValue("@IK_EKIP", IK_EKIP);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_DUYURU()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM [I_DUYURU]";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_TARIHTEBUGUN(string gun, string ay)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT TB_ID, TB_GUN, TB_AY, TB_YIL, TB_GRUP  FROM  [I_TARIHTE_NEOLMUS] where (TB_GUN=@gun or @gun ='' ) and (TB_AY=@ay or @ay ='') ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@gun", gun);
            daa.SelectCommand.Parameters.AddWithValue("@ay", ay);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_TARIHTEBUGUNDETAY(string currentID)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT [TB_ID] ,[TB_GRUP] ,[TB_OLAY], [TB_YAPILACAKLAR], [TB_TARIH] FROM  [I_TARIHTE_NEOLMUS] where TB_ID=@ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", currentID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static bool S_EKIPULASTIMI(string ID)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT EG_ULASMATARIH FROM  [I_IHBAREKIP] where EG_ID=@ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
            daa.Fill(dtt);
            con.Close();
            if (dtt != null && dtt.Rows.Count != 0)
            {
                if (dtt.Rows[0][0].ToString()!="")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public static System.Data.DataTable S_GET_NOBETCIHEYETI(string basTarih, string bitTarih, string adSoyad, string telsizKodu, string Rutbe)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM [I_NOBET_HEYETI] where Nobet_Tarihi>=@basTarih and Nobet_Tarihi<=@bitTarih and ([Adi_Soyadi] = @adSoyad or  @adSoyad='') and ([Telsiz_Kodu] = @telsizKodu or @telsizKodu ='') and ([Rutbe] = @Rutbe or @Rutbe='') ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@basTarih", basTarih);
            daa.SelectCommand.Parameters.AddWithValue("@bitTarih", bitTarih.Replace("0001-01-01", Convert.ToDateTime(GetTime.Time()).ToString("yyyy-MM-dd")));
            daa.SelectCommand.Parameters.AddWithValue("@adSoyad", adSoyad);
            daa.SelectCommand.Parameters.AddWithValue("@telsizKodu", telsizKodu);
            daa.SelectCommand.Parameters.AddWithValue("@Rutbe", Rutbe);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_GET_I_GRUP()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select Distinct TB_GRUP from I_TARIHTE_NEOLMUS ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_KISISEL_BILGILER(string currentKisiNo)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_USERS where USR_ID=@KISINO";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@KISINO", currentKisiNo);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GUVENLIKSIRKETI()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_GUVENLIKSIRKET ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GUVENLIKSIRKETI_WHERE(string G_ID)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_GUVENLIKSIRKET where G_ID=@G_ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@G_ID", G_ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GUVENLIKSIRKET_ABONESI(string GUVENLIKSIRKETI)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_GUVENLIKMUSTERI WHERE GM_GID=@GM_GID ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@GM_GID", GUVENLIKSIRKETI);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GUVENLIKSIRKET_ABONESI_WHERE(string GM_ID)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_GUVENLIKMUSTERI WHERE GM_ID=@GM_ID ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@GM_ID", GM_ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_GUVENLIK_LISTESI(string tarih1, string tarih2,string guvenliksirketi, string guvenliksirketiadi, string guvenlikmusteri, string guvenlikmusteriadi, string alarmtur,string ilce,string sonuctur,string adres)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=I.I_ID AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11') ),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,D.I_DURUM AS DURUM2,(case when G_SIRKETADI is null then I.I_GUVENLIKSIRKETIADI else  G_SIRKETADI end) G_SIRKETADI, (case when GM_MUSTERIISIM is null then I.I_GUVENLIKSIR_ABONESIADI else  GM_MUSTERIISIM end) GM_MUSTERIISIM,I_OPERATORNOT,GM_ADRES,G_IRTIBATISMI,R.A_ADI,G_IRTIBATTELEFON  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID AND D.I_KANAL IN(" + INsorgu + ") left JOIN I_LOG L On I.I_ID=L.L_IHBARID join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID LEFT join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID LEFT JOIN I_GUVENLIKSIRKET G ON G.G_ID=I_GUVENLIKSIRKETI LEFT JOIN I_GUVENLIKMUSTERI GM ON GM.GM_GID=G.G_ID AND GM.GM_ID=I_GUVENLIKSIR_ABONESI left join I_ALARM R ON R.A_ALTOLAYID=A.A_ID and R.A_ID=I.I_GUVENLIK_ALARMTURU where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2 and I_IHBARTUR='GS'";


            if (guvenliksirketi != "")
            {
                sorgu += " and I_GUVENLIKSIRKETI IN (" + guvenliksirketi + ")";
            }
            if (guvenliksirketiadi != "")
            {
                sorgu += " and I_GUVENLIKSIRKETIADI LIKE '%" + guvenliksirketiadi + "%' ";
            }
            if (guvenlikmusteri != "")
            {
                sorgu += " and I_GUVENLIKSIR_ABONESI IN (" + guvenlikmusteri + ")";
            }
            if (guvenlikmusteriadi != "")
            {
                sorgu += " and I_GUVENLIKSIR_ABONESIADI LIKE '%" + guvenlikmusteriadi + "%'";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN (" + ilce + ")";
            }
            if (sonuctur != "")
            {
                sorgu += " and L.L_ISLEM IN (" + sonuctur + ")";
            }
            if (alarmtur != "")
            {
                sorgu += " and I_GUVENLIK_ALARMTURU IN (" + alarmtur + ")";
            }
            if (adres != "")
            {
                sorgu += " and GM_ADRES like '" + adres + "%'";
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
          
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_CALINTI_LISTESI(string tarih1, string tarih2, string ilce, string polisistasyonu, string aracmarkası, string aracmodeli,string plaka)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=I.I_ID  AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,D.I_DURUM AS DURUM2,I_CALARAC_ADET,I_CALARAC_RENK,I_CALARAC_MARKA,I_CALARAC_MODEL,I_CALARAC_ARACTIP,KR.KRK_ISIM,I_CALARAC_SADECEPLAKA,I_PLAKA,I_IHBARBILGISI,I_OPERATORNOT   FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID AND D.I_KANAL IN (" + INsorgu + ") left JOIN I_LOG L On I.I_ID=L.L_IHBARID join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID LEFT join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID left join I_KARAKOL KR ON KR.KRK_ID=I_CALARAC_KARAKOL  where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2 and I_IHBARTUR='CA'";


            if (polisistasyonu != "")
            {
                sorgu += " and KR.KRK_ID IN (" + polisistasyonu + ")";
            }
            if (aracmarkası != "")
            {
                sorgu += " and I_CALARAC_MARKA IN (" + aracmarkası + ")";
            }
            if (ilce != "")
            {
                sorgu += " and I_ILCE IN (" + ilce + ")";
            }

            if (plaka != "")
            {
                sorgu += " and I_PLAKA like '" + plaka + "%'";
            }
            if (aracmodeli != "")
            {
                sorgu += " and I_CALARAC_MODEL like '" + aracmodeli + "%'";
            }
            sorgu += " order by I_TARIH desc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);

            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GET_CALINTIARAC_DETAY(string Id)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT distinct cmpt_islemdurum=(SELECT
L_ISLEM=(select TOP 1 L_ISLEM from I_LOG WHERE L_IHBARID=I.I_ID  AND L_TARIHSAAT=MAX(l.L_TARIHSAAT)) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE l.L_IHBARID=I.I_ID and L_ISLEM not in ('11')),I_ID,I_TARIH,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,c.AD,M.I_ADI,I.I_KULLANICI,A.A_IHBAR as I_OLAYADI,I_TARIH as SAAT,US.U_IHBAR,I_CADDE,D.I_DURUM AS DURUM2,I_CALARAC_ADET,I_CALARAC_RENK,I_CALARAC_MARKA,I_CALARAC_MODEL,I_CALARAC_ARACTIP,KR.KRK_ISIM,I_CALARAC_SADECEPLAKA,I_PLAKA,I_IHBARBILGISI,I_OPERATORNOT,I_ADRES,I_ALTOLAYKODU  FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID  left JOIN I_LOG L On I.I_ID=L.L_IHBARID join I_ALTOLAY  A ON I.I_ALTOLAYKODU=A.A_ID LEFT join I_USTOLAY  US ON I.I_USTOLAYKODU=US.U_ID join I_ILCE C on c.ILCEID=I.I_ILCE left join I_MAHALLE M ON I.I_MAHALLE=M.I_MAHID and M.I_ILCEID=C.ILCEID left join I_KARAKOL KR ON KR.KRK_ID=I_CALARAC_KARAKOL  where  I_ID=@I_ID";


            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_ID", Id);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(Id + " idli çalıntı ihbar açıldı.", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_GUVENLIK_DETAY(string Id)
        {
         
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT  d.I_DURUM,i.I_LATITUDE,i.I_LONGITUDE,T.I_TIP AS I_TAKIPDURUM,I_USTOLAYKODU,i.I_ISIMSOYISIM,i.I_TELEFON,i.I_IHBARTUR,i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,I_USTOLAYKODU,i.I_ONCELIKLI,OL.A_IHBAR,C.AD,(case when i.I_MAHALLE!='' then (select mAX(I_ADI) FROM I_MAHALLE WHERE I_ILCEID=i.I_ILCE AND  I_MAHID=i.I_MAHALLE) else '' end)as cmpt_mahalle,(case when G_SIRKETADI is null then i.I_GUVENLIKSIRKETIADI else  G_SIRKETADI end) G_SIRKETADI, (case when GM_MUSTERIISIM is null then i.I_GUVENLIKSIR_ABONESIADI else  GM_MUSTERIISIM end) GM_MUSTERIISIM,I_OPERATORNOT,GM_ADRES,G_IRTIBATISMI,GM_TELEFON,I_BINA,I_BINANO,I_DAIRE,I_SITE,I_CADDE,G_IRTIBATTELEFON,A_ADI FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID left join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE left join I_IHBARTAKIP T on T.I_IHBARID=i.I_ID LEFT JOIN I_GUVENLIKSIRKET G ON G.G_ID=I_GUVENLIKSIRKETI LEFT JOIN I_GUVENLIKMUSTERI GM ON GM.GM_GID=G.G_ID AND GM.GM_ID=I_GUVENLIKSIR_ABONESI LEFT JOIN I_ALARM AL ON AL.A_ID=i.I_GUVENLIK_ALARMTURU where i.I_ID=@I_ID";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_ID", Id);
            daa.Fill(dtt);
            con.Close();
            bool durum = false;
            Log.I_LOG(Id + " idli güvenlik ihbar açıldı.", "I_IHBARLOG", ref durum);
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBARLATLON(string Id)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT  i.I_LATITUDE,i.I_LONGITUDE  FROM I_IHBAR as i where i.I_ID=@I_ID";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_ID", Id);
            daa.Fill(dtt);
            con.Close();
            bool durum = false; 
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_COUNT(string tarih1, string tarih2, string tip)
        {
            string INsorgu = "";
            //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
            //{
            //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
            //}
            //else
            //{
            //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
            //}
            INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT COUNT(*) as COUNT FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL join I_ALTOLAY OL ON OL.A_ID=i.I_ALTOLAYKODU left join I_ILCE C on c.ILCEID=i.I_ILCE  where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 and   k.KNL_KODU IN (" + INsorgu + ") and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' and I_IHBARTUR='" + tip + "' ";

            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);


            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static string S_SONIHBAR(string order)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = " SELECT TOP(1) D_ACIKLAMA ,D_TARIH FROM I_DUYURU ORDER BY NEWID() " + order + "";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            if (dtt.Rows.Count != 0)
                return dtt.Rows[0][0].ToString();
            else
                return "0";
        }
    
        public static System.Data.DataTable S_ISLEMSONUC_YUKLE(string istip)
        {
            string id = StatikData.SS_SUBMODULID.ToString();
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM I_LOGMESAJ WHERE LOGIHBAR = '" + istip + "' AND LOGDURUM='True'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static void S_GET_GUVENLIK_SIRKETI_KONTROL(ref string IHBARID)
        {

            try
            {
                string INsorgu = "";
                //if (HttpContext.Current.Session["SS_KANAL"].ToString().Contains(",") == true)
                //{
                //    INsorgu = "" + HttpContext.Current.Session["SS_KANAL"].ToString() + "";
                //}
                //else
                //{
                //    INsorgu = "'" + HttpContext.Current.Session["SS_KANAL"].ToString().Replace("'", "") + "'";
                //}
                INsorgu = Helper.KANALISLEM(HttpContext.Current.Session["SS_KANAL"].ToString());
                string tarih1 = Convert.ToDateTime(GetTime.Time()).AddSeconds(-10).ToString("yyyy-MM-dd HH:mm:ss");
                string tarih2 = Convert.ToDateTime(GetTime.Time()).AddSeconds(10).ToString("yyyy-MM-dd HH:mm:ss");
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT I_ID FROM I_IHBAR I JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID WHERE  I_IHBARDURUM=@I_IHBARDURUM AND I_IHBARTUR=@I_IHBARTUR and I_TARIH>=@tarih1 and I_TARIH<=@tarih2 and D.I_KANAL IN (" + INsorgu + ")", con);
                com.Parameters.AddWithValue("@I_IHBARDURUM", true);
                com.Parameters.AddWithValue("@I_IHBARTUR", "GS");
                com.Parameters.AddWithValue("@tarih1", tarih1);
                com.Parameters.AddWithValue("@tarih2",tarih2);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {

                    IHBARID = SDR["I_ID"].ToString();
                   
                }

                con.Close();
            }
            catch
            {
                con.Close();
                return;
            }

        }
        public static System.Data.DataTable S_TERMINALS()
        {


            Connection.OpenConnectionPergo(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"SELECT [TERMINAL]
      ,[UPPER_TERMINAL]
      ,[SHORT_NAME]
      ,[LONG_NAME]
      ,[COMPANY]
      ,[TTYPE]
      ,[ISUSE_EXPIRE]
      ,[CREATE_DATE]
      ,[START_DATE]
      ,[EXPIRE_DATE]
      ,[BLUETOOTH_MAC]
      ,[ISMESSAGE]
      ,[ISACTIVE]
      ,[ISONLINE]
      ,[IMAGE_INDEX]
      ,[STATUS]
      ,[SMS_RESTRICT]
      ,[FIRMWARE]
      ,[ON_CAUSE]
      ,[OFF_CAUSE]
      ,[RUN_MODE]
      ,[BATERY]
      ,[HARDWARE_VERSION]
      ,[UPDATE_FIRMWARE]
      ,[GPS_TRANSFER]
      ,[GPS_DIST_TRANSFER]
      ,[ACC_STATUS]
      ,[CELL_INFO]
      ,[GSM_NUMBER]
      ,[GSM_IMSI]
      ,[GSM_PERSON_NUMBER]
      ,[PERSON_FULLNAME]
      ,[CALL_WARNING_ALARM]
      ,[SEND_WARNING_ALARM]
      ,[SEND_WARNING_MSG]
      ,[OTHER_VALUE]
      ,[ONLINE_DATE]
      ,[OFFLINE_DATE]
      ,[POSITION_DATE]
      ,[LONGITUDE]
      ,[LATITUDE]
      ,[DIRECTION]
      ,[SPEED]
      ,[ALTITUDE]
      ,[SATELLITE]
      ,[HDOP]
      ,[DISTANCE]
      ,[SERVER_IP]
      ,[SERVER_PORT]
      ,[TERMINAL_IP]
      ,[TERMINAL_PORT]
      ,[VEHICLE_MARK]
      ,[VEHICLE_MODEL]
      ,[VEHICLE_COLOR]
      ,[VEHICLE_YEAR]
      ,[MAINTENANCE_KM]
      ,[GPS_KM]
      ,[FUEL_CONSUMPTION]
      ,[PING_DATE]
      ,[VEHICLE_KM]
      ,[TEMPERATURE]
      ,[FUEL_TANK1]
      ,[FUEL_TANK2]
      ,[EPARK_PK_GSM]
      ,[WRITE_OPTIONS]
      ,[CITY]
      ,[COUNTY]
      ,[DISTRICT]
      ,[QUARTER]
      ,[STREET]
      ,[PRIVATE_OPTIONS]
      ,[PRIVATE_DATA]
      ,[OPTIONS_DATA]
      ,[ISMISSION]
      ,[ISWORK_TIME]
      ,[WORK_TIME_START]
      ,[WORK_TIME_STOP]
      ,[ISNOTWORK_SATURDAY]
      ,[ISNOTWORK_SUNDAY]
      ,[ISGSM]
      ,[ACCESSORIES]
      ,[ISSPEED]
      ,[ISIDLE]
      ,[ISINPUT]
      ,[ISOUTPUT]
      ,[ISENTER]
      ,[ISCHANNEL]
      ,[ISCHANNEL_OTHER]
      ,[CLOSE_WA]
      ,[FUEL_CARD]
      ,[FUEL_BUY]
      ,[MISSION_PK]
      ,[ISWARNING_ALARM]
      ,[ISPOWERCUT]
      ,[ISMOVEMENT]
      ,[ISEPARK]
      ,[ISTAXIMETER]
      ,[ISCOMSTATUS]
      ,[ISTAXIID]
      ,[SEND_COMMANDS]
      ,[CONNECT_PDA_PK]
      ,[CONNECT_PDA_LAST_TIME]
      ,[HISTORY_PK]
      ,[ENTER_LAST_CP_PK]
      ,[ENTER_LAST_CPD_PK]
      ,[ENTER_BEFORE_PK]
      ,[ENTER_AFTER_PK]
      ,[ENTER_LAST_ACCESS_DATE]
      ,[ENTER_FL_ACCESS_DATE]
      ,[ISWORK]
      ,[ISSTOP_TIME]
      ,[MAX_STOP_TIME]
      ,[ISSTOP]
      ,[ISAREA]
      ,[ISROUTE]
      ,[GMT]
      ,[USEROAD_SPEED]
      ,[ROAD_SPEED_TOLERANS]
      ,[PICTURE_PATH]
      ,[ISSMS]
      ,[SMS_DATA]
      ,[FUEL_TYPE]
      ,[FUEL_TANK_CAPACITY]
      ,[NEAR_CHECK]
      ,[WEEKDAYS_KM]
      ,[WEEKEND_KM]
      ,[TRACK_VALUES]
      ,[TRACK_ALARM_INTERVAL]
  FROM [dbo].[TERMINAL]";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KISAYOLMARKER_YUKLE()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT  * FROM I_MARKER_KISAYOL";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KISAYOLMARKER_YUKLE(double lat, double lng, double km,int DataCount)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Declare @geog Geography;set @geog = Geography::Point(@LAT, @LONG, 4326); SELECT top "+ DataCount + @"  * FROM I_MARKER_KISAYOL where MAR_GEO.STDistance(@geog)<@KM  order by MAR_GEO.STDistance(@geog) asc";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@LAT", lat);
            daa.SelectCommand.Parameters.AddWithValue("@LONG", lng);
            daa.SelectCommand.Parameters.AddWithValue("@KM", km);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        /////////14.03.2018///////////////////////

        public static int S_MARKER_KISAYOL_SONID()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT MAX(MRK_ID) FROM I_MARKER_KISAYOL";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            int id = Convert.ToInt32(dtt.Rows[0][0]);
            return id;
        }
        public static int S_KAMERA_LOKASYON_SONID()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT MAX(KMR_ID) FROM I_KAMERA_LOKASYON";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            int id = Convert.ToInt32(dtt.Rows[0][0]);
            return id;
        }

        public static System.Data.DataTable S_KISAYOLMARKER_YUKLE(string merkezlat, string merkezlon, double menzil)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"
            Declare @geog Geography; 
 set @geog = Geography::Point(@LAT,@LON,4326); 
            SELECT  [MRK_ID]
      ,[MRK_ADI]
      ,[MRK_LAT]
      ,[MRK_LONG]
      ,[MRK_ICON]
      ,Geography::Point(MRK_LAT,MRK_LONG,4326) GEO  FROM I_MARKER_KISAYOL where Geography::Point(MRK_LAT,MRK_LONG,4326).STDistance(@geog)<@menzil  order by Geography::Point(MRK_LAT,MRK_LONG,4326).STDistance(@geog)";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
            da.SelectCommand.Parameters.AddWithValue("@LAT", merkezlat.Replace(",", "."));
            da.SelectCommand.Parameters.AddWithValue("@LON", merkezlon.Replace(",", "."));
            da.SelectCommand.Parameters.AddWithValue("@menzil", menzil);
            da.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_LOKASYON_BOLGE(string merkezlat, string merkezlon, double menzil)
        {

            Connection.OpenConnectionPergo(ref con);
            string sql = "Declare @geog Geography; " +
"set @geog = Geography::Point(@LAT,@LON,4326); " +
"SELECT * FROM [PergoTest].dbo.TERMINAL " +
"where Geography::Point(LATITUDE,LONGITUDE,4326).STDistance(@geog)<@menzil order by Geography::Point(LATITUDE,LONGITUDE,4326).STDistance(@geog)";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddWithValue("@LAT", merkezlat.Replace(",", "."));
            da.SelectCommand.Parameters.AddWithValue("@LON", merkezlon.Replace(",", "."));
            da.SelectCommand.Parameters.AddWithValue("@menzil", menzil);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            return dt;
        }
        //28,9353060722351
        public static System.Data.DataTable S_TERMINAL_EKIP(string TERMINAL)
        {
            //Connection.OpenConnection(ref con);
            Connection.OpenConnectionPergo(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM [PergoTest].dbo.TERMINAL WHERE TERMINAL=@TERMINAL";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@TERMINAL", TERMINAL);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }

        public static System.Data.DataTable S_KAMERA_GETIR()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM I_KAMERA_LOKASYON ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KAMERA_GETIR(string merkezlat, string merkezlon, double menzil)
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Declare @geog Geography; " +
"set @geog = Geography::Point(@LAT,@LON,4326); " +
"select * from I_KAMERA_LOKASYON lok   " +
"where lok.KMRGEO.STDistance(@geog)<@menzil ";
            sorgu += " order by lok.KMRGEO.STDistance(@geog)";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@LAT", merkezlat.Replace(",", "."));
            daa.SelectCommand.Parameters.AddWithValue("@LON", merkezlon.Replace(",", "."));
            daa.SelectCommand.Parameters.AddWithValue("@menzil", menzil);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KAMERAMARKER_YUKLE()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT    ILCE.AD +'-'+ MAH.I_ADI +'-'+ ISNULL(KMRSOKAK ,'') parseadres ,K.*  from I_KAMERA_LOKASYON K  LEFT JOIN I_ILCE ILCE ON K.KMRILCEID = ILCE.ILCEID LEFT JOIN I_MAHALLE MAH ON K.KMRMAHID = MAH.I_MAHID ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }


        public static System.Data.DataTable S_TERMINAL_LOKASYON_DOLDUR()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select TERMINALID from I_TERMINAL_LOKASYON  group by TERMINALID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_TERMINAL_LOKASYON_GETIR(string terminalid)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select * from I_TERMINAL_LOKASYON where TERMINALID=@TERMINALID order by TL_TARIH ASC";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@TERMINALID", terminalid);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }
        public static System.Data.DataTable S_TERMINAL_LOKASYON_GETIR_TARIHI(string terminalid, string tarih1, string tarih2)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *  FROM I_TERMINAL_LOKASYON TL INNER JOIN [PergoTest].dbo.TERMINAL T ON T.TERMINAL = TL.TERMINALID where TL.TERMINALID=@TERMINALID AND TL.TL_TARIH>=@t1 and TL.TL_TARIH<=@t2 order by TL.TL_TARIH ASC";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@TERMINALID", terminalid);
            daa.SelectCommand.Parameters.AddWithValue("@t1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@t2", tarih2);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_ADRESARAMA(string adres)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select I.AD AS ILCEADI,M.I_ADI AS MAHALLEADI,C.I_AD+' ('+M.I_ADI+')' AS CADDEADI,I.LAT AS ILCELAT,I.LONG AS ILCELONG,M.I_LAT AS MAHLAT,M.I_LONG AS MAHLONG,C.I_LAT AS CADLAT,C.I_LONG AS CADLONG  FROM I_ILCE I left JOIN I_MAHALLE M ON I.ILCEID=M.I_ILCEID left JOIN I_CADDE C ON C.I_ILCEID=I.ILCEID AND C.I_SID=M.I_MAHID where ((I.AD like '" + adres + "%' and M.I_ADI like '" + adres + "%') or C.I_AD like '" + adres + "%')";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_ADRESARAMA2(string adres)
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"select I.AD AS ADRES,I.LONG AS LONG,I.LAT AS LAT FROM I_ILCE I  where (I.AD like '%" + adres + "%') UNION select M.I_ADI AS ADRES,M.I_LONG AS LONG,M.I_LAT AS LAT FROM  I_MAHALLE M where(M.I_ADI like '%" + adres + "%') UNION select C.I_AD AS CADDEADI,C.I_LONG AS LONG,C.I_LAT AS LAT FROM I_CADDE C where(C.I_AD like '%" + adres + "%')";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KAMERALISTES_GETIR(string KMRILCEID)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select  KMRADI+' ('+KMRILCEID+')' as KMRADI, ILCE.AD +'-'+ MAH.I_ADI +'-'+ ISNULL(KMRSOKAK ,'') parseadres ,K.*  from I_KAMERA_LOKASYON K  LEFT JOIN I_ILCE ILCE ON K.KMRILCEID = ILCE.ILCEID LEFT JOIN I_MAHALLE MAH ON K.KMRMAHID = MAH.I_MAHID    where KMRILCEID = '" + KMRILCEID + "'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }

        public static List<ZoomLevel> GetZoomLevels()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Select * from ZoomLevels";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            List<ZoomLevel> zl = new List<ZoomLevel>();
            if (dtt.Rows.Count!=0)
            {
                foreach (DataRow item in dtt.Rows)
                {
                    ZoomLevel z = new ZoomLevel();
                    z.Id = Convert.ToInt32(item["Id"]);
                    z.Level = Convert.ToInt32(item["Level"]);
                    z.Range = Convert.ToInt32(item["Range"]);
                    z.Count = Convert.ToInt32(item["Count"]);

                    zl.Add(z);

                }
                return zl;
            }
            else
            {
                return null;
            }
        }
        public static System.Data.DataTable S_KAMERALISTES_GETIR_KAMERAADI(string kameraadi)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select   KMRADI+' ('+KMRILCEID+')' as KMRADI, ILCE.AD +'-'+ MAH.I_ADI +'-'+ ISNULL(KMRSOKAK ,'') parseadres ,K.*  from I_KAMERA_LOKASYON K  LEFT JOIN I_ILCE ILCE ON K.KMRILCEID = ILCE.ILCEID LEFT JOIN I_MAHALLE MAH ON K.KMRMAHID = MAH.I_MAHID    where K.KMRADI like '%" + kameraadi + "%'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }

        public static System.Data.DataTable S_KAMERALISTES_GETIR_KAMERAID(int kameraid)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select KMRCADDE,KMRADI,KMRLAT,KMRLON,KMRTIPI,KMRILID,KMRILCEID,KMRMAHID,KMRADRES,KMRNOT  from I_KAMERA_LOKASYON    where KMR_ID = '" + kameraid + "'";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }


        public static System.Data.DataTable S_KAMERALISTES_TUM_GETIR()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select KMRCADDE, KMRADI,KMRLAT,KMRLON,KMRTIPI,KMRILCEID,KMRMAHID  from I_KAMERA_LOKASYON    ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }
        public static System.Data.DataTable S_KISAYOLGRUP_YUKLE()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT  * FROM I_KISAYOLGRUP  ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@MKYG_KULLANICI",  HttpContext.Current.Session["USR_SICILNO"]);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_KISAYOL_GETIR()
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select MRK_ID,MKYG_ADI,MRK_ADI,MRK_LAT,MRK_LONG from I_MARKER_KISAYOL Y JOIN I_KISAYOLGRUP G ON Y.MAR_GRUP=G.MKYG_ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        } 

        public static System.Data.DataTable S_ENYAKIN_KARAKOL_GETIR(double LAT, double LONG)
        {
            Connection.OpenConnection(ref con);
            try
            {
                System.Data.DataTable dtt = new System.Data.DataTable();
                string sorgu = "Declare @geog Geography; set @geog = Geography::Point(@LAT,@LONG,4326); select TOP(1) *  from I_KARAKOL lok LEFT JOIN I_ILCE ILCE ON ILCE.ILCEID=lok.KRK_ILCE left join I_MAHALLE MAHALLE ON  lok.KRK_MAHALLE=MAHALLE.I_MAHID where lok.KRK_GEO.STDistance(@geog)<90000  order by lok.KRK_GEO.STDistance(@geog) asc";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@LAT", LAT);
                daa.SelectCommand.Parameters.AddWithValue("@LONG", LONG);
                daa.Fill(dtt);
                con.Close();
                return dtt;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        public static System.Data.DataTable S_ENYAKIN_KARAKOL_GETIR_DETAY(string KRK_ID)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT *FROM  I_KARAKOL K left JOIN I_ILCE I ON K.KRK_ILCE=I.ILCEID left JOIN I_MAHALLE M ON K.KRK_MAHALLE=M.I_MAHID AND I.ILCEID=M.I_ILCEID WHERE KRK_ID=@KRK_ID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@KRK_ID", KRK_ID);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }
        public static System.Data.DataTable S_ADRESARAMA_TUM()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = @"select ADRES=(C.I_AD +' ('+M.I_ADI+','+I.AD+')'),I.ILCEID AS ILCEID,M.I_MAHID, C.I_LONG AS LONG,C.I_LAT AS LAT,C.I_AD as SOKAK FROM I_ILCE I JOIN I_MAHALLE M ON I.ILCEID=M.I_ILCEID JOIN I_CADDE C ON I.ILCEID=C.I_ILCEID AND M.I_MAHID=C.I_SID ";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static string S_GETIHBARKULLANICI(string ihbarid)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT I_KULLANICI FROM I_IHBAR WHERE I_ID=@ihbarid";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@ihbarid", ihbarid);
            daa.Fill(dtt);
            con.Close();
            string id = dtt.Rows[0][0].ToString();
            return id;
        }
        public static string S_GETKULLANICIBILGI(string USR_SICILNO)
        {
            string ISIM = "";
            // İhbar Detayları (ID : 2365845,KAMERA,ihbarcının dahilisi,sicil,Ad soyad
            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT USR_DAHILI,USR_SICILNO,(USR_ADI+' '+USR_SOYADI)  AS ISIM ,[USR_TELEFON_EV],[USR_TELEFON_IS],[USR_TELEFON_GSM] FROM I_USERS where USR_SICILNO=@USR_SICILNO", con);
            com.Parameters.AddWithValue("@USR_SICILNO", USR_SICILNO);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                if (!string.IsNullOrEmpty(SDR["USR_DAHILI"].ToString()))
                     ISIM += SDR["USR_DAHILI"].ToString();
                if (!string.IsNullOrEmpty(SDR["USR_SICILNO"].ToString()))
                    ISIM += ","+SDR["USR_SICILNO"].ToString();
                if (!string.IsNullOrEmpty(SDR["ISIM"].ToString()))
                    ISIM += "," + SDR["ISIM"].ToString();
                if (!string.IsNullOrEmpty(SDR["USR_TELEFON_EV"].ToString()))
                    ISIM += "," + SDR["USR_TELEFON_EV"].ToString();
                if (!string.IsNullOrEmpty(SDR["USR_TELEFON_IS"].ToString()))
                    ISIM += "," + SDR["USR_TELEFON_IS"].ToString();
                if (!string.IsNullOrEmpty(SDR["USR_TELEFON_GSM"].ToString()))
                    ISIM += "," + SDR["USR_TELEFON_GSM"].ToString();
            }
            con.Close();
            return ISIM;
        }

        public static string S_GETSORGU_COUNT(string AYARKODU)
        {
            string AYR_SORGUCOUNT = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT AYR_DEGER FROM I_AYAR WHERE AYR_KODU='" + AYARKODU + "'", con);
                com.Parameters.AddWithValue("@ID", HttpContext.Current.Session["SS_GRUP"].ToString());
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    AYR_SORGUCOUNT = SDR["AYR_DEGER"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return AYR_SORGUCOUNT;
        }
        public static System.Data.DataTable S_HARITAICON_GETIR(double LAT, double LONG, double km)
        {
            Connection.OpenConnection(ref con);
            try
            {
                System.Data.DataTable dtt = new System.Data.DataTable();
                string sorgu = "Declare @geog Geography;set @geog = Geography::Point(@LAT, @LONG, 4326); select* from[MAP_ACCESSORY] M WITH(INDEX(IX_MAP_ACCESSORY)) JOIN I_MAP_ICONSET I ON M.GROUP1 = I.IC_MAP_GRPID AND M.GROUP2 = I.IC_MAP_GRPID2 where  GEO.STDistance(@geog) < @KM and LATITUDE LIKE '" + LAT.ToString().Substring(0, 5).Replace(",", ".") + "%' AND LONGITUDE LIKE '" + LONG.ToString().Substring(0, 5).Replace(",", ".") + "%' order by  GEO.STDistance(@geog) ";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.SelectCommand.Parameters.AddWithValue("@LAT", LAT);
                daa.SelectCommand.Parameters.AddWithValue("@LONG", LONG);
                daa.SelectCommand.Parameters.AddWithValue("@KM", km);
                daa.Fill(dtt);
                con.Close();
                return dtt;
            }
            catch(Exception EX)
            {
                con.Close();
                return null;
            }
        }
        public static System.Data.DataTable S_KOORDINAT_ADRESI_GETIR(double LAT, double LONG)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Declare @geog Geography;set @geog = Geography::Point(@LAT, @LONG, 4326);select TOP(1) I.AD AS ILCEADI,M.I_ADI AS MAHALLEADI,C.I_AD CADDEADI,I.LAT AS ILCELAT,I.LONG AS ILCELONG,M.I_LAT AS MAHLAT,M.I_LONG AS MAHLONG,C.I_LAT AS CADLAT,C.I_LONG AS CADLONG  FROM I_ILCE I left JOIN I_MAHALLE M ON I.ILCEID=M.I_ILCEID left JOIN I_CADDE C ON C.I_ILCEID=I.ILCEID AND C.I_SID=M.I_MAHID WHERE C.I_LAT LIKE '" + LAT.ToString().Substring(0, 6).Replace(",", ".") + "%' AND  C.I_LONG LIKE '" + LONG.ToString().Substring(0, 6).Replace(",", ".") + "%' AND C.I_GEO.STDistance(@geog) < 200 order by  C.I_GEO.STDistance(@geog)";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@LAT", LAT);
            daa.SelectCommand.Parameters.AddWithValue("@LONG", LONG);
            daa.Fill(dtt);
            string sorgu2 = "Declare @geog Geography;set @geog = Geography::Point('" + LAT.ToString().Replace(",",".") + "', '" + LONG.ToString().Replace(",", ".") + "', 4326);select TOP(1) I.AD AS ILCEADI,M.I_ADI AS MAHALLEADI,C.I_AD CADDEADI,I.LAT AS ILCELAT,I.LONG AS ILCELONG,M.I_LAT AS MAHLAT,M.I_LONG AS MAHLONG,C.I_LAT AS CADLAT,C.I_LONG AS CADLONG  FROM I_ILCE I left JOIN I_MAHALLE M ON I.ILCEID=M.I_ILCEID left JOIN I_CADDE C ON C.I_ILCEID=I.ILCEID AND C.I_SID=M.I_MAHID WHERE C.I_LAT LIKE '" + LAT.ToString().Substring(0, 6).Replace(",", ".") + "%' AND  C.I_LONG LIKE '" + LONG.ToString().Substring(0, 6).Replace(",", ".") + "%' AND C.I_GEO.STDistance(@geog) < 200 and C.I_AD LIKE '%SK%'  order by  C.I_GEO.STDistance(@geog)";
          
            con.Close();
            return dtt;
        }
        public static string S_MARKERADI_KONTROL(string markeradi)
        {
            string MRK_ADI = "";
            try
            {


                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("SELECT MRK_ADI FROM I_MARKER_KISAYOL where MRK_ADI='"+markeradi+"'", con);
                com.Parameters.AddWithValue("@ID", StatikData.SS_GRUP);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    MRK_ADI = SDR["MRK_ADI"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return MRK_ADI;
        }

        public static string S_GETCHNAMES(string channels)
        {
            try
            {
                string chname = "";
                Connection.OpenConnection(ref con);
                System.Data.DataTable dtt = new System.Data.DataTable();
                string sorgu = "SELECT [KN_ADI] FROM [dbo].[I_KANAL] WHERE KNL_KODU IN(" + channels + ") ";
                SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
                daa.Fill(dtt);
                con.Close();
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    if (i == dtt.Rows.Count-1)
                        chname += dtt.Rows[i][0].ToString();
                    else
                        chname += dtt.Rows[i][0].ToString() + ",";

                }
                return chname;
            }
            catch  
            {

                return "";
            }
         
            
        }
        public static string S_GETIHBARTYPE(string IHBARID)
        {
            string TYPE = "";
            try
            {
                Connection.OpenConnection(ref con);
                string sorgu = "select I_IHBARTUR from I_IHBAR where I_ID = @IHBARID";
                SqlCommand com = new SqlCommand(sorgu, con);
                com.Parameters.AddWithValue("@IHBARID", IHBARID);
                SqlDataReader SDR = com.ExecuteReader();
                if (SDR.Read())
                {
                    TYPE = SDR["I_IHBARTUR"].ToString();
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return TYPE;
        }

        
        public static System.Data.DataTable getTerminals(double LAT, double LONG, int KM)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Declare @geog Geography;set @geog = Geography::Point(@LAT, @LONG, 4326); select top 100 *,CONVERT(varchar(10), ROUND(Geography::Point(LATITUDE, LONGITUDE, 4326).STDistance(@geog),0)) +'m' as Distance1  from TERMINAL  where  Geography::Point(LATITUDE, LONGITUDE, 4326).STDistance(@geog) < @KM  and ISACTIVE = 1 order by  Geography::Point(LATITUDE, LONGITUDE, 4326).STDistance(@geog)";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@LAT", LAT);
            daa.SelectCommand.Parameters.AddWithValue("@LONG", LONG);
            daa.SelectCommand.Parameters.AddWithValue("@KM", KM);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }

        public static System.Data.DataTable S_KISAYOLMARKER_YUKLE_ARAC(double LAT, double LONG, int KM)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "Declare @geog Geography;set @geog = Geography::Point(@LAT, @LONG, 4326); select top 100 *,CONVERT(varchar(10), ROUND(Geography::Point(LATITUDE, LONGITUDE, 4326).STDistance(@geog),0)) +'m' as Distance1 ,idx as MRK_ID, SHORT_NAME as MRK_ADI,  LATITUDE as MRK_LAT , LONGITUDE as MRK_LONG,'' as MRK_ICON,'1383' as MAR_GRUP from TERMINAL  where  Geography::Point(LATITUDE, LONGITUDE, 4326).STDistance(@geog) < @KM  and ISACTIVE = 1 order by  Geography::Point(LATITUDE, LONGITUDE, 4326).STDistance(@geog)";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@LAT", LAT);
            daa.SelectCommand.Parameters.AddWithValue("@LONG", LONG);
            daa.SelectCommand.Parameters.AddWithValue("@KM", KM);
            daa.Fill(dtt);
            con.Close();
            return dtt;


        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
