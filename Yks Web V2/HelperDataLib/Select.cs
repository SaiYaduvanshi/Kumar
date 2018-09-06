using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace HelperDataLib
{
   public class Select
    {

       public static  SqlConnection con = new SqlConnection();
    
       public static void S_PAGE_YETKIKOTROL(string MODULID)
       {
           bool durum=false;
           string[] arg = new string[999999];
           arg = HttpContext.Current.Session["SS_MODULID"].ToString().Split(',');
           foreach (string item in arg)
           {
              
               if (item == MODULID)
               {
                   durum = true;
               }
              
           }
           if (durum == false)
           {
               HttpContext.Current.Response.Redirect("~/Default.aspx");
           }
       }
       public static void S_KULLANICIGIRIS(string Sicilno, string Sifre, bool check, ref bool durum)
       {
           try
           {
              
               string ip = HttpContext.Current.Request.UserHostAddress.ToString();
               string browser = HttpContext.Current.Request.Browser.Browser.ToString() + " " + HttpContext.Current.Request.Browser.Version.ToString();
               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand(" SELECT USR_ID,USR_SICILNO,USR_ADI,USR_SOYADI,YT_YETKIID,YT_YETKIADI,GRP_KODU,GRP_ADI,GRP_USRKODU,USR_SONGIRIS,USR_KANALYETKI,K.KNL_YETKI,USR_ILCE FROM I_USERS USR JOIN I_YETKI Y  ON  USR.USR_YETKIKODU=Y.YT_YETKIID left JOIN I_GRUP G ON USR.USR_GRUPKODU=G.GRP_KODU left join I_KANAL K ON K.KNL_KODU=USR_KANALYETKI   WHERE USR_SICILNO=@SICILNO AND USR_SIFRE=@SIFRE AND USR_DURUM='True'", con);
               com.Parameters.AddWithValue("@SICILNO", Sicilno);
               com.Parameters.AddWithValue("@SIFRE", Sifre);
               SqlDataReader SDR = com.ExecuteReader();
               if (SDR.Read())
               {
                   durum = true;
                   if (check == true)
                   {
                       HttpCookie oKCookie = new HttpCookie("girismail");
                       oKCookie.Value = Sicilno.Trim();
                       oKCookie.Expires = DateTime.Now.AddMonths(1);
                       HttpContext.Current.Response.Cookies.Add(oKCookie);
                       HttpCookie oKCookieS = new HttpCookie("girissifre");
                       oKCookieS.Value = Sifre.Trim();
                       oKCookieS.Expires = DateTime.Now.AddMonths(1);
                       HttpContext.Current.Response.Cookies.Add(oKCookieS);
                   }
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
                    HttpContext.Current.Session["SS_MACADRES"] = GetMAC();
                    HttpContext.Current.Session["SS_IPADRES"] = GetIPAdres();
                    HttpContext.Current.Session["SS_DATEMODE"] = "yyyy-MM-dd";
                    HttpContext.Current.Session["ORDERIHBAR"] = "UNCALL";
                    S_MUSTERIMODUL_GET();
                   Update.U_SONGIRIS_TARIHGUNCELLE(SDR["USR_ID"].ToString(),ref durum);
                   HttpContext.Current.Response.Redirect("Default.aspx",false);
               }
               else
               {
                   durum = false;
               }
               con.Close();

           }
           catch
           {
               con.Close();
               durum = false;
               return;
           }

       }
        private static string GetIPAdres()
        {
            string _ip = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    _ip = ip.ToString();
                }
            }
            return _ip;
        }

        private static string GetMAC()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
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
                   HttpContext.Current.Session["SS_MODULID"] = SDR["MUS_MODULID"].ToString();
                   HttpContext.Current.Session["SS_SUBMODULID"] = SDR["MUS_SUBMODULID"].ToString();
                  
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
           string id = HttpContext.Current.Session["SS_SUBMODULID"].ToString();
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT *FROM I_MODUL WHERE MDL_MODULID IN ("+id+")";
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
              string sorgu = "SELECT *FROM I_USTOLAY where U_ID=@U_ID ";
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
              string sorgu = "SELECT *FROM I_USTOLAY order by U_ID desc";
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
       public static System.Data.DataTable S_KULLANICILARI_YUKLE()
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_USERS";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ALTOLAY_YUKLE_WHERE(string ID)
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT *FROM I_ALTOLAY where A_UID=@ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ALTOLAY_YUKLE_WHERE_DETAY(string ID)
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_ALTOLAY where A_ID=@ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID", ID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }

       public static void S_YETKI_GETVALUES(string MODULID, ref bool OKU, ref bool YAZ, ref bool SIL,ref bool EKSTRA,ref string USERS)
       {
         
           try
           {

               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("SELECT * FROM I_YETKIDETAY WHERE  YTD_YETKIID=@YETKIID AND YTD_MODULID=@MODULID", con);
               com.Parameters.AddWithValue("@YETKIID", HttpContext.Current.Session["SS_YETKIID"].ToString());
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
       public static void S_YETKI_GETVALUES_DETAY(string YETKIID,string MODULID, ref bool OKU, ref bool YAZ, ref bool SIL, ref bool EKSTRA, ref string USERS)
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
       public static System.Data.DataTable S_EKIP()
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_EKIP E JOIN I_ILCE I ON E.EK_ILCE=I.ILCEID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }


        public static System.Data.DataTable S_EKIPGETIR()
        {


            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT  * FROM I_EKIP";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }



        public static System.Data.DataTable S_EKIP_WHERE(string ILCE)
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
       public static System.Data.DataTable S_EKIP_WHERE2(string ID)
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  * FROM I_EKIP where EK_ID=@EK_ID ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@EK_ID", ID);
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
                     com.Parameters.AddWithValue("@ID", HttpContext.Current.Session["SS_GRUP"].ToString());
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
       public static string S_LOGKONTROL(string Inbarid,string kanal,string logid)
       {
             string L_ID = "";
              try
              {


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT L_ID FROM I_LOG WHERE L_IHBARID=@L_IHBARID AND L_SICILNO=@SICILNO AND L_KANAL=@L_KANAL and L_ISLEM=@ID", con);
                     com.Parameters.AddWithValue("@SICILNO", HttpContext.Current.Session["USR_SICILNO"]);
                     com.Parameters.AddWithValue("@L_IHBARID", Inbarid);
                     com.Parameters.AddWithValue("@L_KANAL", kanal);
                     com.Parameters.AddWithValue("@ID", logid);
                     SqlDataReader SDR = com.ExecuteReader();
                     if (SDR.Read())
                     {
                            L_ID = SDR["L_ID"].ToString();
                     }
                     con.Close();
              }
              catch
              {
                     con.Close();
              }
              return L_ID;
       }
       public static string S_EKIPKONTROL(string EG_EKKODU, string EG_IHKODU)
       {
       string L_ID = "";
           try
           {


               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand("SELECT EG_ID FROM I_IHBAREKIP WHERE EG_EKKODU=@EG_EKKODU AND L_SICILNO=@SICILNO AND L_KANAL=@L_KANAL and L_ISLEM=@ID", con);
               com.Parameters.AddWithValue("@EG_EKKODU", EG_EKKODU);
               com.Parameters.AddWithValue("@EG_IHKODU", EG_IHKODU);
               SqlDataReader SDR = com.ExecuteReader();
               if (SDR.Read())
               {
                   L_ID = SDR["EG_ID"].ToString();
               }
               con.Close();
           }
           catch
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
       public static System.Data.DataTable S_EKIPTELEFON_LISTESI()
       {

          
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_EKIPTELEFON";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_EKIPTELEFON_LISTESI_WHERE (string ID)
       {

        
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_EKIPTELEFON where E_ID=@ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID",ID);
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
          public static System.Data.DataTable S_IHBARTUR_LISTESI()
       {

        
              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT I_IHBARTUR FROM I_IHBAR WHERE I_IHBARTUR<>'' GROUP BY I_IHBARTUR";
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
    
       public static string S_GETTELEFONKONTROL(string TELEFON)
       {
           string id = "";
       
           Connection.OpenConnection(ref con);
           SqlCommand com = new SqlCommand("SELECT E_ID FROM I_EKIPTELEFON where E_TELEFON=@E_TELEFON", con);
           com.Parameters.AddWithValue("@E_TELEFON", TELEFON);
           SqlDataReader SDR = com.ExecuteReader();
           if (SDR.Read())
           {
               id = SDR["E_ID"].ToString();
           }
           con.Close();
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
       public static void S_USERS_GETDETAY(string USR_ID, ref string USR_SICILNO, ref string USR_ADI, ref  string USR_SOYADI, ref  string USR_KULLANICIADI, ref  string USR_SIFRE, ref  string USR_YETKIKODU, ref  string USR_GRUPKODU, ref  string USR_KANALYETKI, ref  string USR_ONAYYETKI, ref  string USR_TELEFON_EV, ref  string USR_TELEFON_IS, ref  string USR_TELEFON_GSM, ref  string USR_RUTBE, ref  string USR_GOREV, ref string USR_TELSIZKANAL, ref string USR_VARDIYA, ref  string USR_DAHILI, ref string USR_IL, ref  string USR_ILCE, ref string USR_SUBE, ref  bool USR_DURUM,ref string USR_YETKIADI,ref string USR_GRUPADI,ref bool USR_KNL_SECIM)
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
                            USR_IL = SDR["USR_IL"].ToString();
                            USR_ILCE = SDR["USR_ILCE"].ToString();
                            USR_SUBE = SDR["USR_SUBE"].ToString();
                            USR_DURUM = Convert.ToBoolean(SDR["USR_DURUM"].ToString());
                            USR_YETKIADI = SDR["YT_YETKIADI"].ToString();
                            USR_GRUPADI = SDR["GRP_ADI"].ToString();
                            USR_KNL_SECIM = Convert.ToBoolean(SDR["USR_KNLSEC"].ToString());
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
              string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True'";
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_KANAL_TUM()
       {

            
              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT * FROM I_KANAL where KNL_DURUM='True'";
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_KANAL_TUM2()
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_KANAL order by KNL_ID desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_KANAL_WHERE(string ID)
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_KANAL where KNL_ID=@KNL_ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@KNL_ID", ID);
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
       public static System.Data.DataTable S_IL()
       {

         
              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT * FROM I_IL";
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_ILCE(string ILID)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT * FROM I_ILCE WHERE ILID=@ILID";
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
       public static System.Data.DataTable S_CADDE(string ILCEID,string MAHALLEID)
       {

        
              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT * FROM I_CADDE WHERE I_SID=@I_SID AND I_ILCEID=@I_ILCEID";
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@I_SID", MAHALLEID);
              daa.SelectCommand.Parameters.AddWithValue("@I_ILCEID", ILCEID);
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_SUBE(string ILID,string ILCEID)
       {
              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT * FROM I_SUBE WHERE SB_IL=@ILID AND SB_ILCE=@ILCEID";
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@ILID", ILID);
              daa.SelectCommand.Parameters.AddWithValue("@ILCEID", ILCEID);
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }




       public static System.Data.DataTable S_SUBE_TUM()
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_SUBE E JOIN I_ILCE I ON E.SB_ILCE=I.ILCEID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_SUBE_WHERE(string ID)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_SUBE E JOIN I_ILCE I ON E.SB_ILCE=I.ILCEID WHERE SB_ID=@SB_ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@SB_ID", ID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static void S_IHBAR_GETDETAY(string IHBARID,ref string I_TELEFON, ref string I_ISIMSOYISIM, ref string I_IL, ref string I_ILCE, ref string I_KANAL, ref string I_MAHALLE, ref string I_CADDE, ref string I_SITE, ref string I_BINA,ref string I_DAIRE, ref string I_PLAKA, ref  string I_ADRES, ref  string I_LATITUDE, ref  string I_LONGITUDE, ref  string I_IHBARBILGISI, ref  string I_USTOLAYKODU, ref  string I_ALTOLAYKODU, ref  string I_OPERATORNOT, ref  string I_CINSIYET, ref  string I_YAS, ref  string I_MAIL, ref  string I_DIGERBILGI, ref  string I_TARIH,ref bool I_ONCELIK)
       {
            
              try
              {

                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT distinct I_ID,I_TELEFON,I_ISIMSOYISIM,I_IL,CASE WHEN ILCE.AD is null THEN 'Belirsiz'  ELSE ILCE.AD END AS ILCEAD,I.I_KANAL,MH.I_ADI AS MAHADI,I_CADDE,I_SITE,I_BINA,I_PLAKA,I_ADRES,I_LATITUDE,I_LONGITUDE,I_IHBARBILGISI,UO.U_IHBAR as I_OLAYADI,AO.A_IHBAR as I_ALTOLAYADI,I.I_OPERATORNOT,I_CINSIYET,I_YAS,I_MAIL,I_DIGERBILGI,I.I_TARIH,I_DAIRE,I_ONCELIKLI,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER FROM I_IHBAR I left JOIN I_IHBARDETAY D ON I.I_ID=D.ID_IHID left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE left JOIN  I_KANAL KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE WHERE I_ID=@I_ID", con);
                     com.Parameters.AddWithValue("@I_ID", IHBARID);
                     SqlDataReader SDR = com.ExecuteReader();
                     if (SDR.Read())
                     {
                            I_TELEFON = SDR["I_TELEFON"].ToString();
                            I_ISIMSOYISIM = SDR["I_ISIMSOYISIM"].ToString();
                            I_IL = SDR["I_IL"].ToString();
                            I_ILCE = SDR["ILCEAD"].ToString();
                            I_KANAL = SDR["I_KANAL"].ToString();
                            I_MAHALLE = SDR["MAHADI"].ToString();
                            I_CADDE = SDR["I_CADDE"].ToString();
                            I_SITE = SDR["I_SITE"].ToString();
                            I_BINA = SDR["I_BINA"].ToString();
                            I_PLAKA = SDR["I_PLAKA"].ToString();
                            I_ADRES = SDR["I_ADRES"].ToString();
                            I_LATITUDE = SDR["I_LATITUDE"].ToString();
                            I_LONGITUDE = SDR["I_LONGITUDE"].ToString();
                            I_IHBARBILGISI = SDR["I_IHBARBILGISI"].ToString();
                            I_USTOLAYKODU = SDR["I_OLAYADI"].ToString();
                            I_ALTOLAYKODU = SDR["I_ALTOLAYADI"].ToString();
                            I_OPERATORNOT = SDR["I_OPERATORNOT"].ToString();
                            I_CINSIYET = SDR["I_CINSIYET"].ToString();
                            I_YAS = SDR["I_YAS"].ToString();
                            I_MAIL = SDR["I_MAIL"].ToString();
                            I_DIGERBILGI = SDR["I_DIGERBILGI"].ToString();
                            I_TARIH = SDR["I_TARIH"].ToString();
                            I_DAIRE = SDR["I_DAIRE"].ToString();
                            I_ONCELIK = Convert.ToBoolean(SDR["I_ONCELIKLI"].ToString());
                     }

                     con.Close();
              }
              catch
              {
                     con.Close();
                     return;
              }

       }
       public static System.Data.DataTable S_IHBAR_GETDETAY_DETAY2(string Id)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT *from I_IHBARDETAY WHERE ID_IHID=@ID and I_AKTIF='True'";

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
              daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
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
              daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI", HttpContext.Current.Session["SS_KANAL"].ToString());
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_RAPOR_TARIH(string tarih1, string tarih2)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT distinct I.I_ID,I_PLAKA,I_IHBARTUR,I_ONCELIKLI,D.I_AMB,D.I_ITF,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER,I_TARIH,D.I_KANAL,KNL.KN_ADI,L.L_ISLEM,LM.LOGMESAJ,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,MH.I_ADI AS MAHADI,I_ILCE,ILCE.AD ILCEAD,I.I_KULLANICI,I_USTOLAYKODU,UO.U_IHBAR as I_OLAYADI,I_ALTOLAYKODU,AO.A_IHBAR as I_ALTOLAYADI,I_TARIH as SAAT FROM I_IHBAR I   left JOIN (select TOP 1 * from I_IHBARDETAY) D ON I.I_ID=D.ID_IHID left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU  left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU  left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE  left JOIN (select TOP 1 * from I_LOG) L ON L.L_IHBARID=I.I_ID left JOIN (select TOP 1 * from I_LOGMESAJ) LM ON L_ISLEM = LM.ID  left JOIN (select TOP 1 * from I_KANAL) KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
           sorgu += " order by I_TARIH desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static System.Data.DataTable S_GETIHBAR_DURUM_RAPOR(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string kullanici)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT distinct I.I_ID,I_PLAKA,I_IHBARTUR,I_ONCELIKLI,D.I_AMB,D.I_ITF,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER,I_TARIH,D.I_KANAL,KNL.KN_ADI,L.L_ISLEM,LM.LOGMESAJ,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,MH.I_ADI AS MAHADI,I_ILCE,ILCE.AD ILCEAD,I.I_KULLANICI,I_USTOLAYKODU,UO.U_IHBAR as I_OLAYADI,I_ALTOLAYKODU,AO.A_IHBAR as I_ALTOLAYADI,I_TARIH as SAAT FROM I_IHBAR I   left JOIN (select TOP 1 * from I_IHBARDETAY) D ON I.I_ID=D.ID_IHID left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU  left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU  left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE  left JOIN (select TOP 1 * from I_LOG) L ON L.L_IHBARID=I.I_ID left JOIN (select TOP 1 * from I_LOGMESAJ) LM ON L_ISLEM = LM.ID  left JOIN (select TOP 1 * from I_KANAL) KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
           if (ihbarcitel != "")
           {
               sorgu += " and I_TELEFON like '%" + ihbarcitel + "%'";
           }
           if (ihbarciadi != "")
           {
               sorgu += " and I_ISIMSOYISIM like '%" + ihbarciadi + "%'";
           }
           if (ilce != "")
           {
               sorgu += " and I_ILCE=@I_ILCE";
           }
           if (mahalle != "")
           {
               sorgu += " and MH.I_ADI like '%" + mahalle + "%'";
           }
           if (cadde != "")
           {
               sorgu += " and I_CADDE like '%" + cadde + "%'";
           }
           if (plaka != "")
           {
               sorgu += " and I_PLAKA like '%" + plaka + "%'";
           }
           if (ustolay != "")
           {
               sorgu += " and I_IHBARTUR=@I_USTOLAYKODU";
           }
           if (altolay != "")
           {
               sorgu += " and I_ALTOLAYKODU=@I_ALTOLAYKODU";
           }
           if (kanal != "")
           {
               sorgu += " and D.I_KANAL IN (" + kanal + ")";
           }
           if (log != "")
           {
               sorgu += " and L.L_ISLEM IN (" + log + ")";
           }
           if (aramadurum != "(Tümü)")
           {
               sorgu += " and  I.I_DURUM = '" + aramadurum + "'";
           }
           if (kullanici != "")
           {
               sorgu += " and I.I_KULLANICI=@I_KULLANICI";
           }
           if (diger != "True")
           {
               if (diger == "1")
               {

                   sorgu += " and  D.I_ITF = 'True'";
               }
               if (diger == "2")
               {
                   sorgu += " and  D.I_AMB = 'True'";
               }
           }
           else
           {
               sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
           }
           sorgu += " order by I_TARIH desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
           //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
           //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
           daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
           //daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
           //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
           daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
           daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", kullanici);
           daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_EKIP_RAPOR(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string kullanici)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT distinct I_ID,CASE WHEN IE.EG_TARIH is null THEN 'Belirsiz' ELSE Convert(varchar,IE.EG_TARIH,120) END as GELISTARIH,IE.EG_KABULTARIH AS KABULTARIH,IE.EG_SONTARIH AS SONTARIH,CASE WHEN DATEDIFF(hour,IE.EG_KABULTARIH,IE.EG_SONTARIH) is null THEN '0' ELSE DATEDIFF(hour,IE.EG_KABULTARIH,IE.EG_SONTARIH) END AS 'SURE',I_PLAKA,I_IHBARTUR,I_ONCELIKLI,D.I_AMB,D.I_ITF,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER,I_TARIH,D.I_KANAL,KNL.KN_ADI,L.L_ISLEM,LM.LOGMESAJ,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,MH.I_ADI AS MAHADI,I_ILCE,CASE WHEN ILCE.AD is null THEN 'Belirsiz'  ELSE ILCE.AD END AS ILCEAD,I.I_KULLANICI,I_USTOLAYKODU,UO.U_IHBAR as I_OLAYADI,I_ALTOLAYKODU,AO.A_IHBAR as I_ALTOLAYADI,I_TARIH as SAAT FROM I_IHBAR I left JOIN left JOIN (select TOP 1 * from I_IHBARDETAY) D ON I.I_ID=D.ID_IHID left JOIN (select TOP 1 * from I_LOG) L ON L.L_IHBARID=I.I_ID  left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE  left JOIN (select TOP 1 * from I_LOGMESAJ) LM ON L_ISLEM = LM.ID left JOIN (select TOP 1 * from I_KANAL) KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE left JOIN I_IHBAREKIP IE ON IE.EG_IHKODU=I.I_ID where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
           if (ihbarcitel != "")
           {
               sorgu += " and I_TELEFON like '%" + ihbarcitel + "%'";
           }
           if (ihbarciadi != "")
           {
               sorgu += " and I_ISIMSOYISIM like '%" + ihbarciadi + "%'";
           }
           if (ilce != "")
           {
               sorgu += " and I_ILCE=@I_ILCE";
           }
           if (mahalle != "")
           {
               sorgu += " and MH.I_ADI like '%" + mahalle + "%'";
           }
           if (cadde != "")
           {
               sorgu += " and I_CADDE like '%" + cadde + "%'";
           }
           if (plaka != "")
           {
               sorgu += " and I_PLAKA like '%" + plaka + "%'";
           }
           if (ustolay != "")
           {
               sorgu += " and I_IHBARTUR=@I_USTOLAYKODU";
           }
           if (altolay != "")
           {
               sorgu += " and I_ALTOLAYKODU=@I_ALTOLAYKODU";
           }
           if (kanal != "")
           {
               sorgu += " and D.I_KANAL IN (" + kanal + ")";
           }
           if (log != "")
           {
               sorgu += " and L.L_ISLEM IN (" + log + ")";
           }
           if (aramadurum != "(Tümü)")
           {
               sorgu += " and  I.I_DURUM = '" + aramadurum + "'";
           }
           if (kullanici != "")
           {
               sorgu += " and I.I_KULLANICI=@I_KULLANICI";
           }
           if (diger != "True")
           {
               if (diger == "1")
               {

                   sorgu += " and  D.I_ITF = 'True'";
               }
               if (diger == "2")
               {
                   sorgu += " and  D.I_AMB = 'True'";
               }
           }
           else
           {
               sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
           }
           sorgu += " order by I_TARIH desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
           //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
           //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
           daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
           //daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
           //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
           daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
           daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", kullanici);
           daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_ILCE_RAPOR(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger, string kullanici)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT distinct I_ID,I_PLAKA,I_IHBARTUR,I_ONCELIKLI,D.I_AMB,D.I_ITF,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER,I_TARIH,D.I_KANAL,KNL.KN_ADI,L.L_ISLEM,LM.LOGMESAJ,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,MH.I_ADI AS MAHADI,I_ILCE,CASE WHEN ILCE.AD is null THEN 'Belirsiz'  ELSE ILCE.AD END AS ILCEAD,I.I_KULLANICI,I_USTOLAYKODU,UO.U_IHBAR as I_OLAYADI,I_ALTOLAYKODU,AO.A_IHBAR as I_ALTOLAYADI,I_TARIH as SAAT FROM I_IHBAR I left JOIN (select TOP 1 * from I_IHBARDETAY) D ON I.I_ID=D.ID_IHID left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU  left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU  left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE  left JOIN (select TOP 1 * from I_LOG) L ON L.L_IHBARID=I.I_ID left JOIN (select TOP 1 * from I_LOGMESAJ) LM ON L_ISLEM = LM.ID  left JOIN (select TOP 1 * from I_KANAL) KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
           if (ihbarcitel != "")
           {
               sorgu += " and I_TELEFON like '%" + ihbarcitel + "%'";
           }
           if (ihbarciadi != "")
           {
               sorgu += " and I_ISIMSOYISIM like '%" + ihbarciadi + "%'";
           }
           if (ilce != "")
           {
               sorgu += " and I_ILCE=@I_ILCE";
           }
           if (mahalle != "")
           {
               sorgu += " and MH.I_ADI like '%" + mahalle + "%'";
           }
           if (cadde != "")
           {
               sorgu += " and I_CADDE like '%" + cadde + "%'";
           }
           if (plaka != "")
           {
               sorgu += " and I_PLAKA like '%" + plaka + "%'";
           }
           if (ustolay != "")
           {
               sorgu += " and I_IHBARTUR=@I_USTOLAYKODU";
           }
           if (altolay != "")
           {
               sorgu += " and I_ALTOLAYKODU=@I_ALTOLAYKODU";
           }
           if (kanal != "")
           {
               sorgu += " and D.I_KANAL IN (" + kanal + ")";
           }
           if (log != "")
           {
               sorgu += " and L.L_ISLEM IN (" + log + ")";
           }
           if (aramadurum != "(Tümü)")
           {
               sorgu += " and  I.I_DURUM = '" + aramadurum + "'";
           }
           if (kullanici != "")
           {
               sorgu += " and I.I_KULLANICI=@I_KULLANICI";
           }
           if (diger != "True")
           {
               if (diger == "1")
               {

                   sorgu += " and  D.I_ITF = 'True'";
               }
               if (diger == "2")
               {
                   sorgu += " and  D.I_AMB = 'True'";
               }
           }
           else
           {
               sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
           }
           sorgu += " order by I_TARIH desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
           //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
           //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
           daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
           //daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
           //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
           daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
           daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", kullanici);
           daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_RAPOR(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum, string diger,string kullanici)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT distinct I.I_ID,I_PLAKA,I_IHBARTUR,I_ONCELIKLI,D.I_AMB,D.I_ITF,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER,I_TARIH,D.I_KANAL,KNL.KN_ADI,L.L_ISLEM,LM.LOGMESAJ,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,MH.I_ADI AS MAHADI,I_ILCE,ILCE.AD ILCEAD,I.I_KULLANICI,I_USTOLAYKODU,UO.U_IHBAR as I_OLAYADI,I_ALTOLAYKODU,AO.A_IHBAR as I_ALTOLAYADI,I_TARIH as SAAT FROM I_IHBAR I   left JOIN (select TOP 1 * from I_IHBARDETAY) D ON I.I_ID=D.ID_IHID left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU  left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU  left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE  left JOIN (select TOP 1 * from I_LOG) L ON L.L_IHBARID=I.I_ID left JOIN (select TOP 1 * from I_LOGMESAJ) LM ON L_ISLEM = LM.ID  left JOIN (select TOP 1 * from I_KANAL) KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2";
           if (ihbarcitel != "")
           {
               sorgu += " and I_TELEFON like '%" + ihbarcitel + "%'";
           }
           if (ihbarciadi != "")
           {
               sorgu += " and I_ISIMSOYISIM like '%" + ihbarciadi + "%'";
           }
           if (ilce != "")
           {
               sorgu += " and I_ILCE=@I_ILCE";
           }
           if (mahalle != "")
           {
               sorgu += " and MH.I_ADI like '%" + mahalle + "%'";
           }
           if (cadde != "")
           {
               sorgu += " and I_CADDE like '%" + cadde + "%'";
           }
           if (plaka != "")
           {
               sorgu += " and I_PLAKA like '%"+plaka+"%'";
           }
           if (ustolay != "")
           {
               sorgu += " and I_IHBARTUR=@I_USTOLAYKODU";
           }
           if (altolay != "")
           {
               sorgu += " and I_ALTOLAYKODU=@I_ALTOLAYKODU";
           }
           if (kanal != "")
           {
               sorgu += " and D.I_KANAL IN (" + kanal + ")";
           }
           if (log != "")
           {
               sorgu += " and L.L_ISLEM IN (" + log + ")";
           }
           if (aramadurum != "(Tümü)")
           {
               sorgu += " and  I.I_DURUM = '" + aramadurum + "'";
           }
           if (kullanici != "")
           {
               sorgu += " and I.I_KULLANICI=@I_KULLANICI";
           }
            if (diger != "True")
            {
                if (diger == "1")
                {

                    sorgu += " and  D.I_ITF = 'True'";
                }
                if (diger == "2")
                {
                    sorgu += " and  D.I_AMB = 'True'";
                }
            }
            else
            {
                sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
            }
            sorgu += " order by I_TARIH desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
           //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
           //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
           daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
           //daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
           //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
           daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
           daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", kullanici);
           daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_RAPOR_KULLANICI(string tarih1, string tarih2, string ihbarcitel, string ihbarciadi, string ilce, string mahalle, string cadde, string plaka, string ustolay, string altolay, string kanal, string log, string aramadurum,string diger)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT distinct I.I_ID,I_PLAKA,I_IHBARTUR,I_ONCELIKLI,D.I_AMB,D.I_ITF,CASE WHEN I.I_ONCELIKLI='True' AND D.I_AMB='True' THEN 'Öncelikli, Ambulans' WHEN I.I_ONCELIKLI='True' AND D.I_ITF='True' THEN 'Öncelikli, İtfaiye' WHEN I_ONCELIKLI='True' THEN 'Öncelikli' WHEN D.I_AMB='True' THEN 'Ambulans' WHEN D.I_ITF='True' THEN 'İtfaiye'  ELSE '' END AS DIGER,I_TARIH,D.I_KANAL,KNL.KN_ADI,L.L_ISLEM,LM.LOGMESAJ,I_KAYNAK,I_TELEFON,I.I_DURUM,I_ISIMSOYISIM,I_CADDE,I_MAHALLE,MH.I_ADI AS MAHADI,I_ILCE,ILCE.AD ILCEAD,I.I_KULLANICI,I_USTOLAYKODU,UO.U_IHBAR as I_OLAYADI,I_ALTOLAYKODU,AO.A_IHBAR as I_ALTOLAYADI,I_TARIH as SAAT FROM I_IHBAR I   left JOIN (select TOP 1 * from I_IHBARDETAY) D ON I.I_ID=D.ID_IHID left JOIN I_USTOLAY UO on UO.U_ID = I.I_USTOLAYKODU  left JOIN I_ALTOLAY AO on AO.A_ID = I.I_ALTOLAYKODU  left JOIN I_ILCE ILCE on ILCE.ILCEID = I.I_ILCE  left JOIN (select TOP 1 * from I_LOG) L ON L.L_IHBARID=I.I_ID left JOIN (select TOP 1 * from I_LOGMESAJ) LM ON L_ISLEM = LM.ID  left JOIN (select TOP 1 * from I_KANAL) KNL ON KNL.KNL_KODU = D.I_KANAL left JOIN I_MAHALLE MH ON MH.I_MAHID = I.I_MAHALLE where I.I_TARIH>=@I_TARIH1 and I.I_TARIH<=@I_TARIH2 and (D.I_KANAL IN ('" + HttpContext.Current.Session["SS_KANAL"].ToString() + "') or I.I_KULLANICI='" + HttpContext.Current.Session["USR_SICILNO"].ToString() + "')";
           if (ihbarcitel != "")
           {
               sorgu += " and I_TELEFON like '%" + ihbarcitel + "%'";
           }
           if (ihbarciadi != "")
           {
               sorgu += " and I_ISIMSOYISIM like '%" + ihbarciadi + "%'";
           }
           if (ilce != "")
           {
               sorgu += " and I_ILCE=@I_ILCE";
           }
           if (mahalle != "")
           {
               sorgu += " and MH.I_ADI like '%" + mahalle + "%'";
           }
           if (cadde != "")
           {
               sorgu += " and I_CADDE like'%" + cadde + "%'";
           }
           if (plaka != "")
           {
               sorgu += " and I_PLAKA=@I_PLAKA";
           }
           if (ustolay != "")
           {
               sorgu += " and I_IHBARTUR=@I_USTOLAYKODU";
           }
           if (altolay != "")
           {
               sorgu += " and I_ALTOLAYKODU=@I_ALTOLAYKODU";
           }
           if (kanal != "")
           {
               sorgu += " and D.I_KANAL IN (" + kanal + ")";
           }
           if (log != "")
           {
               sorgu += " and L.L_ISLEM IN (" + log + ")";
           }
           if (aramadurum != "")
           {
               sorgu += " and  I.I_DURUM = '" + aramadurum + "'";
           }
           if (diger != "True")
           {
               if (diger == "1")
               {

                   sorgu += " and  D.I_ITF = 'True'";
               }
               if (diger == "2")
               {
                   sorgu += " and  D.I_AMB = 'True'";
               }
           }
           else
           {
               sorgu += " and  I.I_ONCELIKLI = '" + diger + "'";
           }
           sorgu += " order by I_TARIH desc";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
           daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
           //daa.SelectCommand.Parameters.AddWithValue("@I_TELEFON", ihbarcitel);
           //daa.SelectCommand.Parameters.AddWithValue("@I_ISIMSOYISIM", ihbarciadi);
           daa.SelectCommand.Parameters.AddWithValue("@I_ILCE", ilce);
           //daa.SelectCommand.Parameters.AddWithValue("@I_MAHALLE", mahalle);
           //daa.SelectCommand.Parameters.AddWithValue("@I_CADDE", cadde);
           daa.SelectCommand.Parameters.AddWithValue("@I_PLAKA", plaka);
           daa.SelectCommand.Parameters.AddWithValue("@I_USTOLAYKODU", ustolay);
           daa.SelectCommand.Parameters.AddWithValue("@I_ALTOLAYKODU", altolay);
           daa.SelectCommand.Parameters.AddWithValue("@KANAL", kanal);
           daa.SelectCommand.Parameters.AddWithValue("@KULLANICI", HttpContext.Current.Session["SS_KANAL"].ToString());
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_LISTE(string tarih1, string tarih2)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT *,I_ALTOLAYKODU as I_OLAYADI FROM I_IHBAR where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_KULLANICI=@I_KULLANICI order by I_ONCELIKLI desc ,I_TARIH desc";
            
              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
              daa.SelectCommand.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
           
              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL(string tarih1, string tarih2)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,i.I_ONCELIKLI FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL where i.I_TARIH>=@I_TARIH1 and i.I_TARIH<=@I_TARIH2 AND k.KNL_KODU=@USR_KANALYETKI and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='True' order by I_ONCELIKLI desc ,I_TARIH desc";

              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
              daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI", HttpContext.Current.Session["SS_KANAL"].ToString());

              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_KAPALI(string tarih1, string tarih2)
       {


              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT i.I_ID,i.I_ILCE,i.I_TARIH,I_ALTOLAYKODU,i.I_ONCELIKLI,d.I_EKIP FROM I_IHBAR as i join I_IHBARDETAY as d on i.I_ID=d.ID_IHID join I_KANAL k on k.KNL_KODU=d.I_KANAL where i.I_TARIH>=@I_TARIH1 and i.I_TARIH<=@I_TARIH2 AND k.KNL_KODU=@USR_KANALYETKI and i.I_IHBARDURUM='True' and d.I_AKTIF='True' AND d.I_DURUM='False' order by I_ONCELIKLI desc ,I_TARIH desc";

              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
              daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI", HttpContext.Current.Session["SS_KANAL"].ToString());

              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_ILCE(string tarih1, string tarih2)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT *,''as I_OLAYADI FROM I_IHBAR where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_ILCEKANAL=@USR_KANALYETKI AND I_DURUM='İletilen' and I_IHBARDURUM='False' and I_IHBARDURUM_ILCE='False'";

              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
              daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI", HttpContext.Current.Session["SS_KANAL"].ToString());

              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_LISTE_KANAL_KAPALI_ILCE(string tarih1, string tarih2)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT *,''as I_OLAYADI FROM I_IHBAR where I_TARIH>=@I_TARIH1 and I_TARIH<=@I_TARIH2 AND I_ILCEKANAL=@USR_KANALYETKI AND I_DURUM='İletilen' and I_IHBARDURUM='False' and I_IHBARDURUM_ILCE='True'";

              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH1", tarih1);
              daa.SelectCommand.Parameters.AddWithValue("@I_TARIH2", tarih2);
              daa.SelectCommand.Parameters.AddWithValue("@USR_KANALYETKI", HttpContext.Current.Session["SS_KANAL"].ToString());

              daa.Fill(dtt);
              con.Close();
              return dtt;

       }
       public static System.Data.DataTable S_GETIHBAR_LOG(string Id)
       {

              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT L_KANAL,max(L_TARIHSAAT)as L_TARIHSAAT,L_SICILNO,LOGMESAJ=(select LOGMESAJ FROM I_LOGMESAJ WHERE ID=(SELECT L_ISLEM FROM I_LOG WHERE L_ID=max(l.L_ID))) from I_LOG l left join I_LOGMESAJ M on l.L_ISLEM= M.ID WHERE L_IHBARID=@L_IHBARID AND LOGMESAJ<>'işlem Yapılmadı' group by L_KANAL,L_SICILNO order by L_TARIHSAAT asc";
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


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_KANAL=@I_KANAL AND I_IHBARDURUM='False'", con);
                     com.Parameters.AddWithValue("@I_KANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
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
       public static string S_GetIhbarKontrol(string ihbarid,string kanal)
       {
             string COUNT = "";
              try
              {


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT ID_ID FROM I_IHBARDETAY WHERE I_KANAL=@I_KANAL AND ID_IHID=@ID", con);
                     com.Parameters.AddWithValue("@I_KANAL", kanal);
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


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_ASILKANAL=@I_ASILKANAL AND I_IHBARDURUM='False' and I_ASILKANAL!=I_KANAL", con);
                     com.Parameters.AddWithValue("@I_ASILKANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
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


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_ILCEKANAL=@I_KANAL AND I_IHBARDURUM='False'", con);
                     com.Parameters.AddWithValue("@I_KANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
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


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT count(I_ID)AS ID FROM I_IHBAR WHERE I_ILCEKANAL=@I_ASILKANAL AND I_IHBARDURUM='False' and I_ASILKANAL!=I_KANAL", con);
                     com.Parameters.AddWithValue("@I_ASILKANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
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
                     SqlCommand com = new SqlCommand("SELECT TMP_TELEFON FROM I_TEMP_TELEFON WHERE TMP_TARIH>=@TARIH AND TMP_AGENT=@AGENT", con);
                     com.Parameters.AddWithValue("@TARIH",DateTime.Now.AddSeconds(-4).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                     com.Parameters.AddWithValue("@AGENT", HttpContext.Current.Session["USR_SICILNO"].ToString());
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
              string sorgu = "select top(1) * from Contacts c join Numbers n on c.Id=n.ContactId where n.Number=@Telefon";

              SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
              daa.SelectCommand.Parameters.AddWithValue("@Telefon", Telefon);

              daa.Fill(dtt);
              con.Close();
              return dtt;

       }


       public static System.Data.DataTable S_GETTELEFON_LOKASYON(string IlceId,string Isim)
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
       public static string S_GETTOPLAMCAGRI(string Telefon)
       {
              string toplam = "";
              try
              {


                     Connection.OpenConnection(ref con);
                     SqlCommand com = new SqlCommand("SELECT count(I_TELEFON)as Toplam FROM I_IHBAR WHERE I_TELEFON=@I_TELEFON", con);
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
                     SqlCommand com = new SqlCommand("SELECT count(I_TELEFON)as Toplam FROM I_IHBAR WHERE I_TELEFON=@I_TELEFON and I_TARIH>=@TARIH1 AND I_TARIH<=@TARIH2 ", con);
                     com.Parameters.AddWithValue("@I_TELEFON", Telefon);
                     com.Parameters.AddWithValue("@TARIH1", DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                     com.Parameters.AddWithValue("@TARIH2", DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
    
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

       public static System.Data.DataTable S_LOKASYON(string key)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT LandmarkName,Location,Latitude,Longitude FROM I_LOKASYON WHERE (ID=@ID or @ID='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static DataTable S_LOKASYON_BOLGE(string merkezlat, string merkezlon, int menzil)
       {
           string sql = "Declare @geog Geography; " +
"set @geog = Geography::Point(@LAT,@LON,4326); " +
"select * from I_LOKASYON lok " +
"where lok.GEO.STDistance(@geog)<@menzil order by  lok.GEO.STDistance(@geog)";
           SqlDataAdapter da = new SqlDataAdapter(sql, con);
           da.SelectCommand.Parameters.AddWithValue("@LAT", merkezlat);
           da.SelectCommand.Parameters.AddWithValue("@LON", merkezlon);
           da.SelectCommand.Parameters.AddWithValue("@menzil", menzil); 
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt;
       }

       public static System.Data.DataTable S_DASHBOARD(string tarih1,string tarih2)
       {

            
              Connection.OpenConnection(ref con);
              System.Data.DataTable dtt = new System.Data.DataTable();
              string sorgu = "SELECT COUNT(I_ID) AS ADET,I_USTOLAYKODU FROM I_IHBAR WHERE I_TARIH>=@tarih1 AND I_TARIH<=@tarih2 GROUP BY I_USTOLAYKODU";
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
           string sorgu = " select EK.EG_ID,EK.EG_EKKODU,K.KN_ADI,EK.EG_TARIH,EK.EG_ULASMATARIH,EK.EG_SONTARIH  FROM I_IHBAREKIP AS EK JOIN I_KANAL AS K ON EK.EG_KANAL=K.KNL_KODU where EK.EG_IHKODU=@ID";

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
       public static System.Data.DataTable S_GETLOG_TUM()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_LOGMESAJ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static int S_GETEKIP_KONTROL(string EKIP)
       {
           int sayi = 0;

           Connection.OpenConnection(ref con);
           SqlCommand com = new SqlCommand("SELECT EG_ID FROM I_IHBAREKIP WHERE EG_TARIH is not null and EG_ULASMATARIH is null and EG_SONTARIH is null and EG_EKKODU=@EKIP", con);
           com.Parameters.AddWithValue("@EKIP",EKIP);
           SqlDataReader SDR = com.ExecuteReader();
           if (SDR.Read())
           {
               sayi = Convert.ToInt32(SDR["EG_ID"].ToString());
           }
           con.Close();
           return sayi;
       }
       public static System.Data.DataTable S_GETKARALISTE_TUM()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_KARALISTE";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETKARALISTE_WHERE(string ID)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_KARALISTE WHERE KR_ID=@KR_ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@KR_ID",ID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETKARAKOL_TUM()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select I.*,ILCE.AD as ILCEAD,MH.I_ADI AS MAHAD,IL.AD as ILAD from I_KARAKOL I left JOIN I_IL IL on IL.ILID = I.KRK_IL left JOIN I_ILCE ILCE on ILCE.ILCEID = I.KRK_ILCE left JOIN I_MAHALLE MH ON MH.I_MAHID = I.KRK_MAHALLE";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }


        public static System.Data.DataTable S_GETCADDE_TUM()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select C.*,I.AD AS ILCEADI from I_CADDE C LEFT JOIN I_ILCE I ON C.I_ILCEID=I.ILCEID";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }



        public static System.Data.DataTable S_GETKARAKOL_WHERE(string ID)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select * from I_KARAKOL WHERE KRK_ID=@KRK_ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@KRK_ID", ID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_TIP()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_TIP";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETISLEMSONUC_TIP()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_IS_TIP";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ISLEMSONUC_TUM()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_ISLEMSONUC";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GETISLEMSONUC_WHERE(string IS_ID)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = " select *from I_ISLEMSONUC WHERE IS_ID=@IS_ID";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@IS_ID", IS_ID);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_GRUP_KANAL_LISTESI()
       {


           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_KANALGRUP";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }

       public static System.Data.DataTable S_GET_GUVENLIK_MUSTERI(string key)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select  t3.I_ADI MAHALLEADI , t2.[AD] ILCEADI, t1.* from  [I_GUVENLIKMUSTERI] t1 left outer join [I_ILCE] t2 on t1.GM_ILCE = t2.[ILCEID] left outer join I_MAHALLE t3 on t1.GM_MAHALLE = t3.[I_MAHID] where (t1.GM_ID=@GMID or @GMID ='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@GMID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static System.Data.DataTable S_GET_ILCE_MAHALLE(string key)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select *,SUBSTRING(LAT,0,8) AS LAT,SUBSTRING(LONG,0,8) AS LONG from I_MAHALLE left join I_ILCE on I_MAHALLE.I_ILCEID=I_ILCE.ILCEID where (I_MAHID=@I_MAHID or @I_MAHID='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_MAHID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static System.Data.DataTable S_GET_ILCE_MAHALLE_CADDE(string key)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select * from I_MAHALLE left join I_ILCE on I_MAHALLE.I_ILCEID=I_ILCE.ILCEID left join I_CADDE ON I_CADDE.I_SID=I_MAHALLE.I_MAHID where (I_MAHID=@I_MAHID or @I_MAHID='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_MAHID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static System.Data.DataTable S_GET_ILCE_MAHALLE_CADDE2(string mahid,string caddead)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select * from I_MAHALLE left join I_ILCE on I_MAHALLE.I_ILCEID=I_ILCE.ILCEID left join I_CADDE ON I_CADDE.I_SID=I_MAHALLE.I_MAHID WHERE I_SID=@I_SID AND I_AD=@I_AD";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@I_SID", mahid);
           daa.SelectCommand.Parameters.AddWithValue("@I_AD", caddead);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static System.Data.DataTable S_GET_IL_ILCE(string key)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select I_ILCE.*,I_IL.AD AS ILAD from I_ILCE left join I_IL on I_ILCE.ILID=I_IL.ILID where (ILCEID=@ILCEID or @ILCEID='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ILCEID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }
       public static System.Data.DataTable S_GET_GUVENLIK_SIRKET(string key)
       {
           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "select  t3.I_ADI MAHALLEADI , t2.[AD] ILCEADI, t1.* from  [I_GUVENLIKSIRKET] t1 left outer join [I_ILCE] t2 on t1.G_ILCE = t2.[ILCEID] left outer join I_MAHALLE t3 on t1.G_MAHALLE = t3.[I_MAHID] where (t1.G_ID=@GMID or @GMID ='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@GMID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;
       }

       public static System.Data.DataTable S_SIRKET()
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_GUVENLIKSIRKET";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }


       public static System.Data.DataTable S_ARACTIPI(string key)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT * FROM I_ARACTIPI where (AT_ID=@ID or @ID='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
       public static System.Data.DataTable S_ALARM(string key)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT  A.*,A.A_ALTOLAYID,O.A_IHBAR,case A.A_DURUM  when 0 then 'False' when 1 then 'True' end DURUM  FROM I_ALARM A INNER JOIN I_ALTOLAY O on A.A_ALTOLAYID = O.A_ID where (A.A_ID=@ID or @ID='') ";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }

       public static System.Data.DataTable S_MARKA(string key)
       {

           Connection.OpenConnection(ref con);
           System.Data.DataTable dtt = new System.Data.DataTable();
           string sorgu = "SELECT NEWID() newid, * FROM I_MARKA where (O_ID=@ID or @ID='')";
           SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
           daa.SelectCommand.Parameters.AddWithValue("@ID", key);
           daa.Fill(dtt);
           con.Close();
           return dtt;

       }
        public static System.Data.DataTable S_LOG()
        { 
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "select  name , case name  when 'I_IHBARLOG' then 'IHBAR LOGLARI'   when 'I_KULLANICILOG' then 'KULLANICI LOGLARI'   when 'I_RAPORLOG' then 'RAPORLAMA LOGLARI'   when 'I_YETKILOG' then 'YETKİ LOGLARI'   when 'I_KANALLOG' then 'KANAL LOGLARI' ELSE '' END _text from YksLog.sys.tables";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);  
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_LOGFilter(string table, string kullanici, string tarih1, string tarih2)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT * FROM  YksLog.dbo." + table + " WHERE TARIHSAAT>=@tarih1 AND TARIHSAAT<=@tarih2 and (KULLANICI=@kullanici or @kullanici='')"; 
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@tarih1", tarih1);
            daa.SelectCommand.Parameters.AddWithValue("@tarih2", tarih2);
            daa.SelectCommand.Parameters.AddWithValue("@kullanici", kullanici);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }

        public static System.Data.DataTable S_GETIHBAR_DURUM_RAPOR_DASHBOARD()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT Case When I_DURUM = 'A.Kapattı' Then 'Arayan Kapattı' When I_DURUM = 'G.Arama' Then 'Gelen Arama' When I_DURUM = 'İletilen' Then 'İletilen Arama' When I_DURUM = 'Kayıt' Then 'Kayıt' Else I_DURUM End as _Text, I_DURUM,COUNT(*) as SAYI, Count(*) * 100 / (select count(*) from I_IHBAR) as YUZDE FROM[I_IHBAR] GROUP BY I_DURUM";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_USTOLAYDURUM_RAPOR_DASHBOARD()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            //string sorgu = "SELECT I_USTOLAYKODU,COUNT(*) as SAYI FROM[I_IHBAR] GROUP BY I_USTOLAYKODU";
            string sorgu = "SELECT U_IHBAR,COUNT(*) as SAYI FROM[I_IHBAR] INNER JOIN [I_USTOLAY] ON I_IHBAR.I_USTOLAYKODU=I_USTOLAY.U_ID GROUP BY U_IHBAR";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;

        }
        public static System.Data.DataTable S_GETIHBAR_TARIHSEL_RAPOR_DASHBOARD()
        {

            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT " +
            "CASE WHEN 1=1 THEN 'Son 3 Gün' END AS GUN,COUNT(*) AS ADET FROM I_IHBAR WHERE DATEDIFF(day, CONVERT(varchar, I_TARIH,10),GETDATE())<=3 " +
"UNION ALL SELECT CASE WHEN 1=1 THEN 'Son 1 Hafta' END AS GUN,COUNT(*) AS ADET FROM I_IHBAR WHERE DATEDIFF(day, CONVERT(varchar, I_TARIH,10),GETDATE())<=7 " +
"UNION ALL SELECT CASE WHEN 1=1 THEN 'Son 2 Hafta' END AS GUN,COUNT(*) AS ADET FROM I_IHBAR WHERE DATEDIFF(day, CONVERT(varchar, I_TARIH,10),GETDATE())<=14 " +
"UNION ALL SELECT CASE WHEN 1=1 THEN 'Son 1 Ay' END AS GUN,COUNT(*) AS ADET FROM I_IHBAR WHERE DATEDIFF(day, CONVERT(varchar, I_TARIH,10),GETDATE())<=30 ";
            //"UNION ALL SELECT CASE WHEN 1=1 THEN 'Toplam' END AS GUN,COUNT(*) AS ADET FROM I_IHBAR WHERE DATEDIFF(day, CONVERT(varchar, I_TARIH,10),GETDATE())>=1";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.Fill(dtt);
            con.Close();
            return dtt;
            // BU SQLIN ÇIKTISI KOLONLARI: GUN-ADET
        }


        public static string S_USTOLAY_KONTROL(string U_IHBAR_ADI)
        {
            string ustolay_adi = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT U_IHBAR FROM I_USTOLAY where U_IHBAR=@U_IHBAR_ADI", con);
            com.Parameters.AddWithValue("@U_IHBAR_ADI", U_IHBAR_ADI);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                ustolay_adi = SDR["U_IHBAR"].ToString();
            }
            con.Close();
            return ustolay_adi;
        }

        public static string S_EKIP_KONTROLYAP(string EK__KODU)
        {
            string ekip_kodu = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT EK_KODU FROM I_EKIP where EK_KODU=@EK_KODU", con);
            com.Parameters.AddWithValue("@EK_KODU", EK__KODU);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                ekip_kodu = SDR["EK_KODU"].ToString();
            }
            con.Close();
            return ekip_kodu;
        }

        public static string S_SUBE_KONTROL(string SB__K)
        {
            string S_kodu = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT SB_KODU FROM I_SUBE where SB_KODU=@SB_KODU", con);
            com.Parameters.AddWithValue("@SB_KODU", SB__K);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                S_kodu = SDR["SB_KODU"].ToString();
            }
            con.Close();
            return S_kodu;
        }

        public static string S_KANAL_KONTROL(string KANAL__K)
        {
            string k_kodu = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT KNL_KODU FROM I_KANAL where KNL_KODU=@KNL_KODU", con);
            com.Parameters.AddWithValue("@KNL_KODU", KANAL__K);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                k_kodu = SDR["KNL_KODU"].ToString();
            }
            con.Close();
            return k_kodu;
        }

        public static string S_KARALISTE_KONTROL(string TELNO)
        {
            string TNO = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT KR_TELEFON FROM I_KARALISTE where KR_TELEFON=@KR_TELEFON", con);
            com.Parameters.AddWithValue("@KR_TELEFON", TELNO);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                TNO = SDR["KR_TELEFON"].ToString();
            }
            con.Close();
            return TNO;
        }

        public static string convertphoneformat(string ph)
        {

            string C1 = ph.Substring(0, 3);
            string C2 = ph.Substring(3, 3);
            string C3 = ph.Substring(6, 4);
            string result = string.Concat("(" + C1 + ")" + "-" + C2 + "-" + C3);
            return result;
        }


        public static string convertcoordlatformat(string ph)
        {
            string result = string.Concat("41"+"."+ ph);
            return result;
        }

        public static string convertcoordlongformat(string ph)
        {
            string result = string.Concat("28" + "." + ph);
            return result;
        }

        public static string S_EKIPTELEFON_KONTROL(string E_KODU)
        {
            string EKOD= "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT E_KODU FROM I_EKIPTELEFON where E_KODU=@E_KODU", con);
            com.Parameters.AddWithValue("@E_KODU", E_KODU);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                EKOD = SDR["E_KODU"].ToString();
            }
            con.Close();
            return EKOD;
        }


        public static string S_KANALGRUP_KONTROL(string K_GRADI)
        {
            string KG_GAD = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT KG_GRUPADI FROM I_KANALGRUP where KG_GRUPADI LIKE '%'+@KG_GRUPADI+'%'", con);
            com.Parameters.AddWithValue("@KG_GRUPADI", K_GRADI);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                KG_GAD = SDR["KG_GRUPADI"].ToString();
            }
            con.Close();
            return KG_GAD;
        }

        public static System.Data.DataTable S_KARAKOL_KONTROL(string KRK_AD,string KRK_TEL)
        {
            Connection.OpenConnection(ref con);
            System.Data.DataTable dtt = new System.Data.DataTable();
            string sorgu = "SELECT KRK_ISIM,KRK_TELEFON1 FROM I_KARAKOL WHERE KRK_ISIM LIKE '%'+@KRK_ISIM+'%' AND KRK_TELEFON1=@KRK_TELEFON1";
            SqlDataAdapter daa = new SqlDataAdapter(sorgu, con);
            daa.SelectCommand.Parameters.AddWithValue("@KRK_ISIM", KRK_AD);
            daa.SelectCommand.Parameters.AddWithValue("@KRK_TELEFON1", KRK_TEL);
            daa.Fill(dtt);
            con.Close();
            return dtt;
        }

        public static string S_MUSTERI_KONTROL(string MUS)
        {
            string MUS_ADI = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT GM_MUSTERIISIM FROM I_GUVENLIKMUSTERI where GM_MUSTERIISIM LIKE '%'+@GM_MUSTERIISIM+'%'", con);
            com.Parameters.AddWithValue("@GM_MUSTERIISIM", MUS);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                MUS_ADI = SDR["GM_MUSTERIISIM"].ToString();
            }
            con.Close();
            return MUS_ADI;
        }

        public static string S_ALARM_KONTROL(string ALA)
        {
            string G_ALARM = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT A_ADI FROM I_ALARM where A_ADI LIKE '%'+@A_ADI+'%'", con);
            com.Parameters.AddWithValue("@A_ADI", ALA);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                G_ALARM = SDR["A_ADI"].ToString();
            }
            con.Close();
            return G_ALARM;
        }

        public static string S_ARACTIPI_KONTROL(string ATIPI)
        {
            string TIP = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT AT_ADI FROM I_ARACTIPI where AT_ADI LIKE '%'+@AT_ADI+'%'", con);
            com.Parameters.AddWithValue("@AT_ADI", ATIPI);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                TIP = SDR["AT_ADI"].ToString();
            }
            con.Close();
            return TIP;
        }

        public static string S_ARACMARKA_KONTROL(string A_MARKA)
        {
            string AMARKA = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT O_MARKASI FROM I_MARKA where O_MARKASI LIKE '%'+@O_MARKASI+'%'", con);
            com.Parameters.AddWithValue("@O_MARKASI", A_MARKA);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                AMARKA = SDR["O_MARKASI"].ToString();
            }
            con.Close();
            return AMARKA;
        }


        public static string S_GUVENLIKSIRKET_KONTROL(string G_SIRKET)
        {
            string GV_SIRKET = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT G_SIRKETADI FROM I_GUVENLIKSIRKET where G_SIRKETADI LIKE '%'+@G_SIRKETADI+'%'", con);
            com.Parameters.AddWithValue("@G_SIRKETADI", G_SIRKET);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                GV_SIRKET = SDR["G_SIRKETADI"].ToString();
            }
            con.Close();
            return GV_SIRKET;
        }

        public static string S_CADDE_KONTROL(string C_ADI)
        {
            string CADDE_ADI = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT I_ADI FROM I_CADDE where I_ADI LIKE '%'+@I_ADI+'%'", con);
            com.Parameters.AddWithValue("@I_ADI", C_ADI);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                CADDE_ADI = SDR["I_ADI"].ToString();
            }
            con.Close();
            return CADDE_ADI;
        }

        public static string S_ISLEMSONUCTURLERI_KONTROL(string ISL_ADI)
        {
            string ISLEM_ADI = "";

            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("SELECT IS_ADI FROM I_ISLEMSONUC where IS_ADI LIKE '%'+@IS_ADI+'%'", con);
            com.Parameters.AddWithValue("@IS_ADI", ISL_ADI);
            SqlDataReader SDR = com.ExecuteReader();
            if (SDR.Read())
            {
                ISLEM_ADI = SDR["IS_ADI"].ToString();
            }
            con.Close();
            return ISLEM_ADI;
        }

    }
}
