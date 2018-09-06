using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Data;

namespace HelperDataLib
{
    public class Insert
    {
     
        public static void I_YETKI(string YETKIADI, string YETKIID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
               
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_YETKI(YT_YETKIID,YT_YETKIADI) values(@YT_YETKIID,@YT_YETKIADI)", con);
                com.Parameters.AddWithValue("@YT_YETKIID", YETKIID);
                com.Parameters.AddWithValue("@YT_YETKIADI", YETKIADI);
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
        public static void I_YETKI_DETAY(string MODULID, bool OKU, bool YAZ, bool SIL,bool EKSTRA, string YETKIID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
               
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_YETKIDETAY(YTD_MODULID,YTD_OKU,YTD_YAZ,YTD_SIL,YTD_EKSTRA,YTD_YETKIID) values(@MODULID,@OKU,@YAZ,@SIL,@EKSTRA,@YETKIID)", con);
                com.Parameters.AddWithValue("@MODULID", MODULID);
                com.Parameters.AddWithValue("@OKU", OKU);
                com.Parameters.AddWithValue("@YAZ", YAZ);
                com.Parameters.AddWithValue("@SIL", SIL);
                com.Parameters.AddWithValue("@YETKIID", YETKIID);
                com.Parameters.AddWithValue("@EKSTRA", EKSTRA);
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

        public static bool I_KULLANICI(string USR_SICILNO, string USR_ADI, string USR_SOYADI, string USR_KULLANICIADI, string USR_SIFRE, string USR_YETKIKODU, string USR_GRUPKODU, string USR_KANALYETKI, string USR_ONAYYETKI, string USR_TELEFON_EV, string USR_TELEFON_IS, string USR_TELEFON_GSM, string USR_RUTBE, string USR_GOREV, string USR_TELSIZKANAL, string USR_VARDIYA, string USR_DAHILI, string USR_IL, string USR_ILCE, string USR_SUBE, bool USR_DURUM,string USR_EKIPKODU,bool USR_KNLSEC)
        {
               bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {
               
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_USERS(USR_SICILNO,USR_ADI,USR_SOYADI,USR_KULLANICIADI,USR_SIFRE,USR_YETKIKODU,USR_GRUPKODU,USR_KANALYETKI,USR_ONAYYETKI,USR_TELEFON_EV,USR_TELEFON_IS,USR_TELEFON_GSM,USR_RUTBE,USR_GOREV,USR_TELSIZKANAL,USR_VARDIYA,USR_DAHILI,USR_IL,USR_ILCE,USR_SUBE,USR_DURUM,USR_KAYITTARIH,USR_SONGIRIS,USR_EKIPKODU,USR_KNLSEC) values(@USR_SICILNO,@USR_ADI,@USR_SOYADI,@USR_KULLANICIADI,@USR_SIFRE,@USR_YETKIKODU,@USR_GRUPKODU,@USR_KANALYETKI,@USR_ONAYYETKI,@USR_TELEFON_EV,@USR_TELEFON_IS,@USR_TELEFON_GSM,@USR_RUTBE,@USR_GOREV,@USR_TELSIZKANAL,@USR_VARDIYA,@USR_DAHILI,@USR_IL,@USR_ILCE,@USR_SUBE,@USR_DURUM,@USR_KAYITTARIH,@USR_SONGIRIS,@USR_EKIPKODU,@USR_KNLSEC)", con);

                com.Parameters.AddWithValue("@USR_SICILNO", USR_SICILNO);
                com.Parameters.AddWithValue("@USR_ADI", USR_ADI);
                com.Parameters.AddWithValue("@USR_SOYADI", USR_SOYADI);
                com.Parameters.AddWithValue("@USR_KULLANICIADI", USR_KULLANICIADI);
                com.Parameters.AddWithValue("@USR_SIFRE", USR_SIFRE);
                com.Parameters.AddWithValue("@USR_YETKIKODU", USR_YETKIKODU);
                com.Parameters.AddWithValue("@USR_GRUPKODU", USR_GRUPKODU);
                com.Parameters.AddWithValue("@USR_KANALYETKI", USR_KANALYETKI);
                com.Parameters.AddWithValue("@USR_ONAYYETKI", USR_ONAYYETKI);
                com.Parameters.AddWithValue("@USR_TELEFON_EV", USR_TELEFON_EV);
                com.Parameters.AddWithValue("@USR_TELEFON_IS", USR_TELEFON_IS);
                com.Parameters.AddWithValue("@USR_TELEFON_GSM", USR_TELEFON_GSM);
                com.Parameters.AddWithValue("@USR_RUTBE", USR_RUTBE);
                com.Parameters.AddWithValue("@USR_GOREV", USR_GOREV);
                com.Parameters.AddWithValue("@USR_TELSIZKANAL", USR_TELSIZKANAL);
                com.Parameters.AddWithValue("@USR_VARDIYA", USR_VARDIYA);
                com.Parameters.AddWithValue("@USR_DAHILI", USR_DAHILI);
                com.Parameters.AddWithValue("@USR_IL", USR_IL);
                com.Parameters.AddWithValue("@USR_ILCE", USR_ILCE);
                com.Parameters.AddWithValue("@USR_SUBE", USR_SUBE);
                com.Parameters.AddWithValue("@USR_DURUM", USR_DURUM);
                com.Parameters.AddWithValue("@USR_KAYITTARIH", DateTime.Now);
                com.Parameters.AddWithValue("@USR_SONGIRIS", DBNull.Value);
                com.Parameters.AddWithValue("@USR_EKIPKODU", USR_EKIPKODU);
                com.Parameters.AddWithValue("@USR_KNLSEC", USR_KNLSEC);


                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch
            {
                con.Close();
                durum = false;
               
            }
            return durum;
        }
        public static void I_GRUP(string GRP_KODU, string GRP_ADI, string GRP_USRKODU, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
              
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_GRUP(GRP_KODU,GRP_ADI,GRP_USRKODU) values(@GRP_KODU,@GRP_ADI,@GRP_USRKODU)", con);
                com.Parameters.AddWithValue("@GRP_KODU", GRP_KODU);
                com.Parameters.AddWithValue("@GRP_ADI", GRP_ADI);
                com.Parameters.AddWithValue("@GRP_USRKODU", GRP_USRKODU);
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
        public static void I_ILCE(string ILCEID, string ILID, string ILCEAD,string LAT, string LONG, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_ILCE(ILCEID,ILID,AD,LONG,LAT) values(@ILCEID,@ILID,@AD,@LONG,@LAT)", con);
                com.Parameters.AddWithValue("@ILCEID", ILCEID);
                com.Parameters.AddWithValue("@ILID", ILID);
                com.Parameters.AddWithValue("@AD", ILCEAD);
                com.Parameters.AddWithValue("@LONG", LONG);
                com.Parameters.AddWithValue("@LAT", LAT);
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
        public static void I_MAHALLE(string I_ILCEID, string I_ADI,string I_LAT,string I_LONG, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_MAHALLE(I_ILCEID,I_ADI,I_LAT,I_LONG) values(@I_ILCEID,@I_ADI,@I_LAT,@I_LONG)", con);
                com.Parameters.AddWithValue("@I_ILCEID", I_ILCEID);
                com.Parameters.AddWithValue("@I_ADI", I_ADI);
                com.Parameters.AddWithValue("@I_LAT", I_LAT);
                com.Parameters.AddWithValue("@I_LONG", I_LONG);
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
        public static void I_CADDE(string I_SID,string I_ILCEID, string I_AD, string I_LAT, string I_LONG, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_CADDE(I_SID,I_ILCEID,I_AD,I_LAT,I_LONG) values(@I_SID,@I_ILCEID,@I_AD,@I_LAT,@I_LONG)", con);
                com.Parameters.AddWithValue("@I_SID", I_SID);
                com.Parameters.AddWithValue("@I_ILCEID", I_ILCEID);
                com.Parameters.AddWithValue("@I_AD", I_AD);
                com.Parameters.AddWithValue("@I_LAT", I_LAT);
                com.Parameters.AddWithValue("@I_LONG", I_LONG);
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
        public static bool I_IHBAR(string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string MAHALLE, string CADDE, string SITE, string BINA, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool ONCELIK, string KANAL, string I_KAYNAK,string TUR, ref int id)
        {
               bool durum = false;
               SqlConnection con = new SqlConnection();
               try
               {

                      Connection.OpenConnection(ref con);
                      SqlCommand com = new SqlCommand("insert I_IHBAR(I_TELEFON,I_ISIMSOYISIM,I_IL,I_ILCE,I_MAHALLE,I_CADDE,I_SITE,I_BINA,I_DAIRE,I_PLAKA,I_ADRES,I_LATITUDE,I_LONGITUDE,I_IHBARBILGISI,I_USTOLAYKODU,I_ALTOLAYKODU,I_OPERATORNOT,I_CINSIYET,I_YAS,I_MAIL,I_DIGERBILGI,I_TARIH,I_KULLANICI,I_DURUM,I_IHBARDURUM,I_ONCELIKLI,I_KANAL,I_KAYNAK,I_IHBARTUR) values(@I_TELEFON,@I_ISIMSOYISIM,@I_IL,@I_ILCE,@I_MAHALLE,@I_CADDE,@I_SITE,@I_BINA,@I_DAIRE,@I_PLAKA,@I_ADRES,@I_LATITUDE,@I_LONGITUDE,@I_IHBARBILGISI,@I_USTOLAYKODU,@I_ALTOLAYKODU,@I_OPERATORNOT,@I_CINSIYET,@I_YAS,@I_MAIL,@I_DIGERBILGI,@I_TARIH,@I_KULLANICI,@I_DURUM,@I_IHBARDURUM,@I_ONCELIKLI,@I_KANAL,@I_KAYNAK,@I_IHBARTUR);select  @@IDENTITY from I_IHBAR;", con);
                      com.Parameters.AddWithValue("@I_TELEFON", TELEFON);
                      com.Parameters.AddWithValue("@I_ISIMSOYISIM", ISIMSOYISIM);
                      com.Parameters.AddWithValue("@I_IL", IL);
                      com.Parameters.AddWithValue("@I_ILCE", ILCE);
                      com.Parameters.AddWithValue("@I_MAHALLE", MAHALLE);
                      com.Parameters.AddWithValue("@I_CADDE", CADDE);
                      com.Parameters.AddWithValue("@I_SITE", SITE);
                      com.Parameters.AddWithValue("@I_BINA", BINA);
                      com.Parameters.AddWithValue("@I_DAIRE", DAIRE);
                      com.Parameters.AddWithValue("@I_PLAKA", PLAKA);
                      com.Parameters.AddWithValue("@I_ADRES", ADRES);
                      com.Parameters.AddWithValue("@I_LATITUDE",LAT);
                      com.Parameters.AddWithValue("@I_LONGITUDE", LONG);
                      com.Parameters.AddWithValue("@I_IHBARBILGISI", IHBARBILGI);
                      com.Parameters.AddWithValue("@I_USTOLAYKODU", USTOLAYKODU);
                      com.Parameters.AddWithValue("@I_ALTOLAYKODU", ALTOLAYKODU);
                      com.Parameters.AddWithValue("@I_OPERATORNOT", OPERATORNOT);
                      com.Parameters.AddWithValue("@I_CINSIYET", CINSIYET);
                      com.Parameters.AddWithValue("@I_YAS", YAS);
                      com.Parameters.AddWithValue("@I_MAIL", MAIL);
                      com.Parameters.AddWithValue("@I_DIGERBILGI", DIGERBILGI);
                      com.Parameters.AddWithValue("@I_TARIH", DateTime.Now);
                      com.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
                      com.Parameters.AddWithValue("@I_DURUM", DURUM);
                      com.Parameters.AddWithValue("@I_IHBARDURUM", true);
                      com.Parameters.AddWithValue("@I_ONCELIKLI", ONCELIK);
                      com.Parameters.AddWithValue("@I_KANAL", KANAL);
                      com.Parameters.AddWithValue("@I_KAYNAK", I_KAYNAK);
                      com.Parameters.AddWithValue("@I_IHBARTUR", TUR);
                      object x = com.ExecuteScalar();
                      id = Convert.ToInt32(x);
                      durum = true;
                      con.Close();
               }
               catch
               {
                      con.Close();
                      durum = false;
                     
               }
               return durum;
        }
        public static void I_IHBAR_DETAY(string IH_ID, string IH_KANAL, ref bool durum)
        {
               SqlConnection con = new SqlConnection();
               try
               {

                      Connection.OpenConnection(ref con);
                      SqlCommand com = new SqlCommand("insert I_IHBARDETAY(ID_IHID,I_KANAL,I_TARIHSAAT,I_KULLANICI,I_OKUMA,I_AKTIF,I_DURUM) values(@ID_IHID,@I_KANAL,@I_TARIHSAAT,@I_KULLANICI,@I_OKUMA,@I_AKTIF,@I_DURUM)", con);
                      com.Parameters.AddWithValue("@ID_IHID", IH_ID);
                      com.Parameters.AddWithValue("@I_KANAL", IH_KANAL);
                      com.Parameters.AddWithValue("@I_TARIHSAAT", DateTime.Now);
                      com.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
                      com.Parameters.AddWithValue("@I_OKUMA", false);
                      com.Parameters.AddWithValue("@I_AKTIF", true);
                      com.Parameters.AddWithValue("@I_DURUM", true);
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
        public static void I_MESAJ(string IN_IHID, string IN_OLAYKODU, string IN_MESAJ, ref bool durum)
        {
               SqlConnection con = new SqlConnection();
               try
               {

                      Connection.OpenConnection(ref con);
                      SqlCommand com = new SqlCommand("insert I_IHBAR_MESAJ(IN_IHID,IN_OLAYKODU,IN_MESAJ,IN_TARIHSAAT,IN_KULLANICI) values(@IN_IHID,@IN_OLAYKODU,@IN_MESAJ,@IN_TARIHSAAT,@IN_KULLANICI)", con);
                      com.Parameters.AddWithValue("@IN_IHID", IN_IHID);
                      com.Parameters.AddWithValue("@IN_OLAYKODU", IN_OLAYKODU);
                      com.Parameters.AddWithValue("@IN_MESAJ", IN_MESAJ);
                      com.Parameters.AddWithValue("@IN_TARIHSAAT", DateTime.Now);
                      com.Parameters.AddWithValue("@IN_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
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
        public static void I_LOG(string L_IHBARID, string L_KANAL, string L_ISLEM, ref bool durum)
        {
               SqlConnection con = new SqlConnection();
               try
               {

                      Connection.OpenConnection(ref con);
                      SqlCommand com = new SqlCommand("insert I_LOG(L_IHBARID,L_SICILNO,L_KANAL,L_TARIHSAAT,L_ISLEM) values(@L_IHBARID,@L_SICILNO,@L_KANAL,@L_TARIHSAAT,@L_ISLEM)", con);
                      com.Parameters.AddWithValue("@L_IHBARID", L_IHBARID);
                      com.Parameters.AddWithValue("@L_ISLEM", L_ISLEM);
                      com.Parameters.AddWithValue("@L_KANAL", L_KANAL);
                      com.Parameters.AddWithValue("@L_TARIHSAAT", DateTime.Now);
                      com.Parameters.AddWithValue("@L_SICILNO", HttpContext.Current.Session["USR_SICILNO"].ToString());
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

        public static void I_EKIP_YONLENDIR(string EG_EKKODU, string EG_IHKODU, bool EG_EKDURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBAREKIP(EG_KANAL,EG_EKKODU,EG_IHKODU,EG_EKDURUM,EG_ILCEDURUM,EG_TARIH) values(@EG_KANAL,@EG_EKKODU,@EG_IHKODU,@EG_EKDURUM,@EG_ILCEDURUM,@EG_TARIH)", con);
                com.Parameters.AddWithValue("@EG_KANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
                com.Parameters.AddWithValue("@EG_EKKODU", EG_EKKODU);
                com.Parameters.AddWithValue("@EG_IHKODU", EG_IHKODU);
                com.Parameters.AddWithValue("@EG_EKDURUM", EG_EKDURUM);
                com.Parameters.AddWithValue("@EG_ILCEDURUM", false);
                com.Parameters.AddWithValue("@EG_TARIH", DateTime.Now);
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
        public static void I_EKIPTELEFON(string E_KODU, string E_TELEFON, string E_ISIMSOYISIM, string E_GOREVI, string E_GOREVYERI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_EKIPTELEFON(E_KODU,E_TELEFON,E_ISIMSOYISIM,E_GOREVI,E_GOREVYERI) values(@E_KODU,@E_TELEFON,@E_ISIMSOYISIM,@E_GOREVI,@E_GOREVYERI)", con);
                com.Parameters.AddWithValue("@E_KODU", E_KODU);
                com.Parameters.AddWithValue("@E_TELEFON",E_TELEFON);
                com.Parameters.AddWithValue("@E_ISIMSOYISIM", E_ISIMSOYISIM);
                com.Parameters.AddWithValue("@E_GOREVI", E_GOREVI);
                com.Parameters.AddWithValue("@E_GOREVYERI", E_GOREVYERI);
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
        public static void I_TUTANAK(string T_IHBARCIADI, string T_IHBARBOLGESI, string T_ADRES, string T_CINSIYET, string T_KONU, string T_IHBARBILGI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBARTUTANAK(T_IHBARCIADI,T_IHBARBOLGESI,T_ADRES,T_CINSIYET,T_KONU,T_IHBARBILGI) values(@T_IHBARCIADI,@T_IHBARBOLGESI,@T_ADRES,@T_CINSIYET,@T_KONU,@T_IHBARBILGI)", con);
                com.Parameters.AddWithValue("@T_IHBARCIADI", T_IHBARCIADI);
                com.Parameters.AddWithValue("@T_IHBARBOLGESI", T_IHBARBOLGESI);
                com.Parameters.AddWithValue("@T_ADRES", T_ADRES);
                com.Parameters.AddWithValue("@T_CINSIYET", T_CINSIYET);
                com.Parameters.AddWithValue("@T_KONU", T_KONU);
                com.Parameters.AddWithValue("@T_IHBARBILGI", T_IHBARBILGI);
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

        public static void I_IHBARKAPAT(string IK_NOT, string IK_IHBARID, string IK_EKIP, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBARKAPANIS(IK_KANAL,IK_NOT,IK_IHBARID,IK_TARIH,IK_EKIP) values(@IK_KANAL,@IK_NOT,@IK_IHBARID,@IK_TARIH,@IK_EKIP)", con);
                com.Parameters.AddWithValue("@IK_KANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
                com.Parameters.AddWithValue("@IK_NOT", IK_NOT);
                com.Parameters.AddWithValue("@IK_IHBARID", IK_IHBARID);
                com.Parameters.AddWithValue("@IK_TARIH", DateTime.Now);
                com.Parameters.AddWithValue("@IK_EKIP", IK_EKIP);
              
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
        public static void I_USTOLAY(string U_IHBAR, bool U_DURUM, bool U_ONCELIK, bool U_MAIL,string U_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_USTOLAY(U_IHBAR,U_DURUM,U_ONCELIK,U_MAIL,U_KANAL) values(@U_IHBAR,@U_DURUM,@U_ONCELIK,@U_MAIL,@U_KANAL)", con);
                com.Parameters.AddWithValue("@U_IHBAR", U_IHBAR);
                com.Parameters.AddWithValue("@U_DURUM", U_DURUM);
                com.Parameters.AddWithValue("@U_ONCELIK", U_ONCELIK);
                com.Parameters.AddWithValue("@U_MAIL", U_MAIL);
                com.Parameters.AddWithValue("@U_KANAL", U_KANAL);
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





        public static void I_ALTOLAY(string A_UID,string A_KANAL, string A_IHBAR, bool A_ONCELIK, bool A_ACIL, bool A_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_ALTOLAY(A_UID,A_IHBAR,A_ONCELIK,A_ACIL,A_DURUM,A_KANAL) values(@A_UID,@A_IHBAR,@A_ONCELIK,@A_ACIL,@A_DURUM,@A_KANAL)", con);
                com.Parameters.AddWithValue("@A_UID", A_UID);
                com.Parameters.AddWithValue("@A_IHBAR", A_IHBAR);
                com.Parameters.AddWithValue("@A_ONCELIK", A_ONCELIK);
                com.Parameters.AddWithValue("@A_ACIL", A_ACIL);
                com.Parameters.AddWithValue("@A_DURUM", A_DURUM);
                com.Parameters.AddWithValue("@A_KANAL", A_KANAL);
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
        public static void I_KANAL(string KANAL_KODU, bool KANALDURUM, string KANALADI, int KANALTRAFIK, string KANALYETKI, string KNL_ILCE, string KNL_DIGERKANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_KANAL(KNL_KODU,KNL_DURUM,KN_ADI,KNL_TRAFIK,KNL_YETKI,KNL_ILCE,KNL_DIGERKANAL) values(@KNL_KODU,@KNL_DURUM,@KN_ADI,@KNL_TRAFIK,@KNL_YETKI,@KNL_ILCE,@KNL_DIGERKANAL)", con);
                com.Parameters.AddWithValue("@KNL_KODU", KANAL_KODU);
                com.Parameters.AddWithValue("@KNL_DURUM", KANALDURUM);
                com.Parameters.AddWithValue("@KN_ADI", KANALADI);
                com.Parameters.AddWithValue("@KNL_TRAFIK", KANALTRAFIK);
                com.Parameters.AddWithValue("@KNL_YETKI", KANALYETKI);
                com.Parameters.AddWithValue("@KNL_ILCE", KNL_ILCE);
                //com.Parameters.AddWithValue("@KNL_TIP", KNL_TIP);
                com.Parameters.AddWithValue("@KNL_DIGERKANAL", KNL_DIGERKANAL);
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
        public static void I_SUBE(string SB_KODU, string SB_ADI, string SB_IL, string SB_ILCE, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_SUBE(SB_KODU,SB_ADI,SB_IL,SB_ILCE) values(@SB_KODU,@SB_ADI,@SB_IL,@SB_ILCE)", con);
                com.Parameters.AddWithValue("@SB_KODU", SB_KODU);
                com.Parameters.AddWithValue("@SB_ADI", SB_ADI);
                com.Parameters.AddWithValue("@SB_IL", SB_IL);
                com.Parameters.AddWithValue("@SB_ILCE", SB_ILCE);
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
        public static void I_EKIP(string EK_KODU, string EK_ILCE, string EK_LAT, string EK_LONG, bool EK_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_EKIP(EK_KODU,EK_ILCE,EK_LAT,EK_LONG,EK_DURUM) values(@EK_KODU,@EK_ILCE,@EK_LAT,@EK_LONG,@EK_DURUM)", con);
                com.Parameters.AddWithValue("@EK_KODU", EK_KODU);
                com.Parameters.AddWithValue("@EK_ILCE", EK_ILCE);
                com.Parameters.AddWithValue("@EK_LAT", EK_LAT);
                com.Parameters.AddWithValue("@EK_LONG", EK_LONG);
                com.Parameters.AddWithValue("@EK_DURUM", EK_DURUM);
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

        public static void I_KARALISTE(string KR_TELEFON, DateTime KR_BASLAMA, DateTime KR_BITIS, string KR_EKLEYEN, string KR_NEDEN, bool KR_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_KARALISTE(KR_TELEFON,KR_BASLAMA,KR_BITIS,KR_EKLEYEN,KR_NEDEN,KR_DURUM) values(@KR_TELEFON,@KR_BASLAMA,@KR_BITIS,@KR_EKLEYEN,@KR_NEDEN,@KR_DURUM)", con);
                com.Parameters.AddWithValue("@KR_TELEFON", KR_TELEFON);
                com.Parameters.AddWithValue("@KR_BASLAMA", KR_BASLAMA);
                com.Parameters.AddWithValue("@KR_BITIS", KR_BITIS);
                com.Parameters.AddWithValue("@KR_EKLEYEN", KR_EKLEYEN);
                com.Parameters.AddWithValue("@KR_NEDEN", KR_NEDEN);
                com.Parameters.AddWithValue("@KR_DURUM", KR_DURUM);
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
        public static void I_KARAKOL(string KRK_ISIM, string KRK_TELEFON1, string KRK_TELEFON2, string KRK_TELSIZKODU, string KRK_AMIRAD, string KRK_AMIRSOYAD, string KRK_AMIRTELEFON, string KRK_AMIRTELSIZ, string KRK_IL, string KRK_ILCE, string KRK_MAHALLE, string KRK_LAT, string KRK_LONG, string KRK_ADRES, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_KARAKOL(KRK_ISIM,KRK_TELEFON1,KRK_TELEFON2,KRK_TELSIZKODU,KRK_AMIRAD,KRK_AMIRSOYAD,KRK_AMIRTELEFON,KRK_AMIRTELSIZ,KRK_IL,KRK_ILCE,KRK_MAHALLE,KRK_LAT,KRK_LONG,KRK_ADRES,KRK_GEO) values(@KRK_ISIM,@KRK_TELEFON1,@KRK_TELEFON2,@KRK_TELSIZKODU,@KRK_AMIRAD,@KRK_AMIRSOYAD,@KRK_AMIRTELEFON,@KRK_AMIRTELSIZ,@KRK_IL,@KRK_ILCE,@KRK_MAHALLE,@KRK_LAT,@KRK_LONG,@KRK_ADRES,geography::STPointFromText('POINT(' + Convert(Varchar,@KRK_LONG) + ' ' + Convert(Varchar,@KRK_LAT) + ')', 4326));", con);
                com.Parameters.AddWithValue("@KRK_ISIM", KRK_ISIM);
                com.Parameters.AddWithValue("@KRK_TELEFON1", KRK_TELEFON1);
                com.Parameters.AddWithValue("@KRK_TELEFON2", KRK_TELEFON2);
                com.Parameters.AddWithValue("@KRK_TELSIZKODU", KRK_TELSIZKODU);
                com.Parameters.AddWithValue("@KRK_AMIRAD", KRK_AMIRAD);
                com.Parameters.AddWithValue("@KRK_AMIRSOYAD", KRK_AMIRSOYAD);
                com.Parameters.AddWithValue("@KRK_AMIRTELEFON", KRK_AMIRTELEFON);
                com.Parameters.AddWithValue("@KRK_AMIRTELSIZ", KRK_AMIRTELSIZ);
                com.Parameters.AddWithValue("@KRK_IL", KRK_IL);
                com.Parameters.AddWithValue("@KRK_ILCE", KRK_ILCE);
                com.Parameters.AddWithValue("@KRK_MAHALLE", KRK_MAHALLE);
                com.Parameters.AddWithValue("@KRK_LAT", KRK_LAT);
                com.Parameters.AddWithValue("@KRK_LONG", KRK_LONG);
                com.Parameters.AddWithValue("@KRK_ADRES", KRK_ADRES);
                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch(Exception C)
            {
                con.Close();
                durum = false;
                return;
            }
        }
        public static void I_ISLEMSONUC(string IS_ADI, string IS_TIP, bool IS_DURUM,string IS_KISAYOLTUS, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_ISLEMSONUC(IS_ADI,IS_TIP,IS_DURUM,IS_KISAYOLTUS) values(@IS_ADI,@IS_TIP,@IS_DURUM,@IS_KISAYOLTUS)", con);
                com.Parameters.AddWithValue("@IS_ADI", IS_ADI);
                com.Parameters.AddWithValue("@IS_TIP", IS_TIP);
                com.Parameters.AddWithValue("@IS_DURUM", IS_DURUM);
                com.Parameters.AddWithValue("@IS_KISAYOLTUS", IS_KISAYOLTUS);
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
        public static void I_KANALGRUP(string KG_GRUPKODU, string KG_GRUPADI, string KG_KANAL,bool KG_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_KANALGRUP(KG_GRUPKODU,KG_GRUPADI,KG_KANAL,KG_DURUM) values(@KG_GRUPKODU,@KG_GRUPADI,@KG_KANAL,@KG_DURUM)", con);
                com.Parameters.AddWithValue("@KG_GRUPKODU", KG_GRUPKODU);
                com.Parameters.AddWithValue("@KG_GRUPADI", KG_GRUPADI);
                com.Parameters.AddWithValue("@KG_KANAL", KG_KANAL);
                com.Parameters.AddWithValue("@KG_DURUM", KG_DURUM);
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

        public static void I_GUVENLIKSIRKET(string G_SIRKETADI, string G_ILCE, string G_MAHALLE, string G_ADRES, string G_KULLANICIADI, string G_SIFRE, string G_IRTIBATISMI, string G_IRTIBATTELEFON, string G_TELEFONDIGER, string G_TELEFONDIGER2, string G_GSM, string G_FAX, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_GUVENLIKSIRKET(G_SIRKETADI,G_ILCE,G_MAHALLE,G_ADRES,G_KULLANICIADI,G_SIFRE,G_IRTIBATISMI,G_IRTIBATTELEFON,G_TELEFONDIGER,G_TELEFONDIGER2,G_GSM,G_FAX) values(@G_SIRKETADI,@G_ILCE,@G_MAHALLE,@G_ADRES,@G_KULLANICIADI,@G_SIFRE,@G_IRTIBATISMI,@G_IRTIBATTELEFON,@G_TELEFONDIGER,@G_TELEFONDIGER2,@G_GSM,@G_FAX)", con);
                com.Parameters.AddWithValue("@G_SIRKETADI", G_SIRKETADI);
                com.Parameters.AddWithValue("@G_ILCE", G_ILCE);
                com.Parameters.AddWithValue("@G_MAHALLE", G_MAHALLE);
                com.Parameters.AddWithValue("@G_ADRES", G_ADRES);
                com.Parameters.AddWithValue("@G_KULLANICIADI", G_KULLANICIADI);
                com.Parameters.AddWithValue("@G_SIFRE", G_SIFRE);
                com.Parameters.AddWithValue("@G_IRTIBATISMI", G_IRTIBATISMI);
                com.Parameters.AddWithValue("@G_IRTIBATTELEFON", G_IRTIBATTELEFON);
                com.Parameters.AddWithValue("@G_TELEFONDIGER", G_TELEFONDIGER);
                com.Parameters.AddWithValue("@G_TELEFONDIGER2", G_TELEFONDIGER2);
                com.Parameters.AddWithValue("@G_GSM", G_GSM);
                com.Parameters.AddWithValue("@G_FAX", G_FAX);

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


        public static void I_GUVENLIKMUSTERI(string GM_GID, string GM_MUSTERIISIM, DateTime GM_GIRISTARIH, DateTime GM_CIKISTARIH, string GM_CALISMAGRUP, string GM_TELEFON, string GM_SAHIBI, string GM_GSM, string GM_ILCE, string GM_MAHALLE, string GM_SOKAK, string GM_SITE, string GM_BINA, string GM_BINANO, string GM_DAIRENO, string GM_ADRES, int GM_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();


            Connection.OpenConnection(ref con);
            SqlCommand com = new SqlCommand("insert I_GUVENLIKMUSTERI(GM_GID,GM_MUSTERIISIM,GM_GIRISTARIH,GM_CIKISTARIH,GM_CALISMAGRUP,GM_TELEFON,GM_SAHIBI,GM_GSM,GM_ILCE,GM_MAHALLE,GM_SOKAK,GM_SITE,GM_BINA,GM_BINANO,GM_DAIRENO,GM_ADRES,GM_DURUM) " +
                "values(@GM_GID, @GM_MUSTERIISIM,@GM_GIRISTARIH,@GM_CIKISTARIH,@GM_CALISMAGRUP,@GM_TELEFON,@GM_SAHIBI,@GM_GSM,@GM_ILCE,@GM_MAHALLE,@GM_SOKAK,@GM_SITE,@GM_BINA,@GM_BINANO,@GM_DAIRENO,@GM_ADRES,@GM_DURUM)", con);
            com.Parameters.AddWithValue("@GM_GID", GM_GID);
            com.Parameters.AddWithValue("@GM_MUSTERIISIM", GM_MUSTERIISIM);
            com.Parameters.AddWithValue("@GM_GIRISTARIH", GM_GIRISTARIH);
            com.Parameters.AddWithValue("@GM_CIKISTARIH", GM_CIKISTARIH);
            com.Parameters.AddWithValue("@GM_CALISMAGRUP", GM_CALISMAGRUP);
            com.Parameters.AddWithValue("@GM_TELEFON", GM_TELEFON);
            com.Parameters.AddWithValue("@GM_SAHIBI", GM_SAHIBI);
            com.Parameters.AddWithValue("@GM_GSM", GM_GSM);
            com.Parameters.AddWithValue("@GM_ILCE", GM_ILCE);
            com.Parameters.AddWithValue("@GM_MAHALLE", GM_MAHALLE);
            com.Parameters.AddWithValue("@GM_SOKAK", GM_SOKAK);
            com.Parameters.AddWithValue("@GM_SITE", GM_SITE);
            com.Parameters.AddWithValue("@GM_BINA", GM_BINA);
            com.Parameters.AddWithValue("@GM_BINANO", GM_BINANO);
            com.Parameters.AddWithValue("@GM_DAIRENO", GM_DAIRENO);
            com.Parameters.AddWithValue("@GM_ADRES", GM_ADRES);
            com.Parameters.AddWithValue("@GM_DURUM", GM_DURUM);


            int deger = com.ExecuteNonQuery();
            durum = true;
            con.Close();

        }




        public static void I_ARACTIPI(string AT_ADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_ARACTIPI (AT_ADI) values(@AT_ADI)", con);
                com.Parameters.AddWithValue("@AT_ADI", AT_ADI);
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

        public static void I_ALARM(string A_ADI, int A_ALTOLAYID, bool A_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_ALARM (A_ADI,A_ALTOLAYID,A_DURUM) values(@A_ADI,@A_ALTOLAYID,@A_DURUM)", con);
                com.Parameters.AddWithValue("@A_ADI", A_ADI);
                com.Parameters.AddWithValue("@A_ALTOLAYID", A_ALTOLAYID);
                com.Parameters.AddWithValue("@A_DURUM", A_DURUM);
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

        public static void I_MARKA(string O_MARKASI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_MARKA (O_MARKASI) values(@O_MARKASI)", con);
                com.Parameters.AddWithValue("@O_MARKASI", O_MARKASI);
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

