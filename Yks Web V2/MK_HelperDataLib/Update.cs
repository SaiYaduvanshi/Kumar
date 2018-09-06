using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MK_HelperDataLib
{
   public class Update : IDisposable
    {
        public static void U_YETKI(string YETKIADI, string YETKIID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_YETKI SET YT_YETKIADI=@YT_YETKIADI WHERE YT_YETKIID=@YT_YETKIID", con);
                com.Parameters.AddWithValue("@YT_YETKIID", YETKIID);
                com.Parameters.AddWithValue("@YT_YETKIADI", YETKIADI);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_YETKI tablosunda "+ YETKIID + " numaralı yetki güncellendi ", "I_YETKILOG", ref durum);
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

        public static void U_YETKI_DETAY(string MODULID, bool OKU, bool YAZ, bool SIL, bool EKSTRA, string YETKIID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_YETKIDETAY SET YTD_OKU=@OKU,YTD_YAZ=@YAZ,YTD_SIL=@SIL,YTD_EKSTRA=@EKSTRA WHERE YTD_MODULID=@MODULID AND YTD_YETKIID=@YETKIID", con);
                com.Parameters.AddWithValue("@MODULID", MODULID);
                com.Parameters.AddWithValue("@OKU", OKU);
                com.Parameters.AddWithValue("@YAZ", YAZ);
                com.Parameters.AddWithValue("@SIL", SIL);
                com.Parameters.AddWithValue("@EKSTRA", EKSTRA);
                com.Parameters.AddWithValue("@YETKIID", YETKIID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_YETKIDETAY tablosunda " + YETKIID + " numaralı yetki detay güncellendi ", "I_YETKILOG", ref durum);
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



        public static bool U_KULLANICI(string USR_ID, string USR_SICILNO, string USR_ADI, string USR_SOYADI, string USR_KULLANICIADI, string USR_SIFRE, string USR_YETKIKODU, string USR_GRUPKODU, string USR_KANALYETKI, string USR_ONAYYETKI, string USR_TELEFON_EV, string USR_TELEFON_IS, string USR_TELEFON_GSM, string USR_RUTBE, string USR_GOREV, string USR_TELSIZKANAL, string USR_VARDIYA, string USR_DAHILI, string USR_IL, string USR_ILCE, string USR_SUBE, bool USR_DURUM, string USR_EKIPKODU, bool USR_KNLSEC)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_USERS  set USR_SICILNO=@USR_SICILNO,USR_ADI=@USR_ADI,USR_SOYADI=@USR_SOYADI,USR_KULLANICIADI=@USR_KULLANICIADI,USR_SIFRE=@USR_SIFRE,USR_YETKIKODU=@USR_YETKIKODU,USR_GRUPKODU=@USR_GRUPKODU,USR_KANALYETKI=@USR_KANALYETKI,USR_ONAYYETKI=@USR_ONAYYETKI,USR_TELEFON_EV=@USR_TELEFON_EV,USR_TELEFON_IS=@USR_TELEFON_IS,USR_TELEFON_GSM=@USR_TELEFON_GSM,USR_RUTBE=@USR_RUTBE,USR_GOREV=@USR_GOREV,USR_TELSIZKANAL=@USR_TELSIZKANAL,USR_VARDIYA=@USR_VARDIYA,USR_DAHILI=@USR_DAHILI,USR_IL=@USR_IL,USR_ILCE=@USR_ILCE,USR_SUBE=@USR_SUBE,USR_DURUM=@USR_DURUM,USR_EKIPKODU=@USR_EKIPKODU,USR_KNLSEC = @USR_KNLSEC where USR_ID=@USR_ID", con);
                com.Parameters.AddWithValue("@USR_ID", USR_ID);
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
                com.Parameters.AddWithValue("@USR_EKIPKODU", USR_EKIPKODU);
                com.Parameters.AddWithValue("@USR_KNLSEC ", USR_KNLSEC);

                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_USERS tablosunda " + USR_ID + " numaralı kullanıc güncelendi ", "I_KULLANICILOG", ref durum);
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
        public static void U_GRUP(string ID, string GRP_ADI, string GRP_USRKODU, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_GRUP SET GRP_ADI=@GRP_ADI,GRP_USRKODU=@GRP_USRKODU where GRP_ID=@ID", con);
                com.Parameters.AddWithValue("@ID", ID);
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

        public static void U_SONGIRIS_TARIHGUNCELLE(string USR_ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_USERS SET USR_SONGIRIS=@USR_SONGIRIS WHERE USR_ID=@USR_ID", con);
                com.Parameters.AddWithValue("@USR_SONGIRIS", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@USR_ID", USR_ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_USERS tablosunda " + USR_ID + " numaralı satır editlendi. ", "I_KULLANICILOG", ref durum);
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
        public static bool U_IHBAR(string ID, string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string KANAL, string MAHALLE, string CADDE, string SITE, string BINA,string BINANNO, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool I_ONCELIKLI)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_TELEFON=@I_TELEFON,I_ISIMSOYISIM=@I_ISIMSOYISIM,I_IL=@I_IL,I_ILCE=@I_ILCE,I_KANAL=@I_KANAL,I_MAHALLE=@I_MAHALLE,I_CADDE=@I_CADDE,I_SITE=@I_SITE,I_BINA=@I_BINA,I_BINANO=@I_BINANO,I_DAIRE=@I_DAIRE,I_PLAKA=@I_PLAKA,I_ADRES=@I_ADRES,I_LATITUDE=@I_LATITUDE,I_LONGITUDE=@I_LONGITUDE,I_IHBARBILGISI=@I_IHBARBILGISI,I_USTOLAYKODU=@I_USTOLAYKODU,I_ALTOLAYKODU=@I_ALTOLAYKODU,I_OPERATORNOT=@I_OPERATORNOT,I_CINSIYET=@I_CINSIYET,I_YAS=@I_YAS,I_MAIL=@I_MAIL,I_DIGERBILGI=@I_DIGERBILGI,I_DURUM=@I_DURUM,I_ONCELIKLI=@I_ONCELIKLI,I_UPDATEDATE = GETDATE() WHERE  I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_TELEFON", TELEFON);
                com.Parameters.AddWithValue("@I_ISIMSOYISIM", ISIMSOYISIM);
                com.Parameters.AddWithValue("@I_IL", IL);
                com.Parameters.AddWithValue("@I_ILCE", ILCE);
                com.Parameters.AddWithValue("@I_KANAL", KANAL);
                com.Parameters.AddWithValue("@I_MAHALLE", MAHALLE);
                com.Parameters.AddWithValue("@I_CADDE", CADDE);
                com.Parameters.AddWithValue("@I_SITE", SITE);
                com.Parameters.AddWithValue("@I_BINA", BINA);
                com.Parameters.AddWithValue("@I_BINANO", BINANNO);
                com.Parameters.AddWithValue("@I_PLAKA", PLAKA);
                com.Parameters.AddWithValue("@I_ADRES", ADRES);
                com.Parameters.AddWithValue("@I_LATITUDE", LAT);
                com.Parameters.AddWithValue("@I_LONGITUDE", LONG);
                com.Parameters.AddWithValue("@I_IHBARBILGISI", IHBARBILGI);
                com.Parameters.AddWithValue("@I_USTOLAYKODU", USTOLAYKODU);
                com.Parameters.AddWithValue("@I_ALTOLAYKODU", ALTOLAYKODU);
                com.Parameters.AddWithValue("@I_OPERATORNOT", OPERATORNOT);
                com.Parameters.AddWithValue("@I_CINSIYET", CINSIYET);
                com.Parameters.AddWithValue("@I_YAS", YAS);
                com.Parameters.AddWithValue("@I_MAIL", MAIL);
                com.Parameters.AddWithValue("@I_DIGERBILGI", DIGERBILGI);
                com.Parameters.AddWithValue("@I_DURUM", DURUM);
                com.Parameters.AddWithValue("@I_DAIRE", DAIRE);
                com.Parameters.AddWithValue("@I_ONCELIKLI", I_ONCELIKLI);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + ID + " numaralı satır editlendi. ", "I_IHBARLOG", ref durum);
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
        public static bool U_IHBAR_GUVNELIK(string ID, string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string KANAL, string MAHALLE, string CADDE, string SITE, string BINA, string BINANNO, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool I_ONCELIKLI)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_TELEFON=@I_TELEFON,I_ISIMSOYISIM=@I_ISIMSOYISIM,I_IL=@I_IL,I_ILCE=@I_ILCE,I_KANAL=@I_KANAL,I_MAHALLE=@I_MAHALLE,I_CADDE=@I_CADDE,I_SITE=@I_SITE,I_BINA=@I_BINA,I_BINANO=@I_BINANO,I_DAIRE=@I_DAIRE,I_PLAKA=@I_PLAKA,I_ADRES=@I_ADRES,I_LATITUDE=@I_LATITUDE,I_LONGITUDE=@I_LONGITUDE,I_IHBARBILGISI=@I_IHBARBILGISI,I_USTOLAYKODU=@I_USTOLAYKODU,I_ALTOLAYKODU=@I_ALTOLAYKODU,I_OPERATORNOT=@I_OPERATORNOT,I_CINSIYET=@I_CINSIYET,I_YAS=@I_YAS,I_MAIL=@I_MAIL,I_DIGERBILGI=@I_DIGERBILGI,I_DURUM=@I_DURUM,I_ONCELIKLI=@I_ONCELIKLI,I_UPDATEDATE = GETDATE() WHERE  I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_TELEFON", TELEFON);
                com.Parameters.AddWithValue("@I_ISIMSOYISIM", ISIMSOYISIM);
                com.Parameters.AddWithValue("@I_IL", IL);
                com.Parameters.AddWithValue("@I_ILCE", ILCE);
                com.Parameters.AddWithValue("@I_KANAL", KANAL);
                com.Parameters.AddWithValue("@I_MAHALLE", MAHALLE);
                com.Parameters.AddWithValue("@I_CADDE", CADDE);
                com.Parameters.AddWithValue("@I_SITE", SITE);
                com.Parameters.AddWithValue("@I_BINA", BINA);
                com.Parameters.AddWithValue("@I_BINANO", BINANNO);
                com.Parameters.AddWithValue("@I_PLAKA", PLAKA);
                com.Parameters.AddWithValue("@I_ADRES", ADRES);
                com.Parameters.AddWithValue("@I_LATITUDE", LAT);
                com.Parameters.AddWithValue("@I_LONGITUDE", LONG);
                com.Parameters.AddWithValue("@I_IHBARBILGISI", IHBARBILGI);
                com.Parameters.AddWithValue("@I_USTOLAYKODU", USTOLAYKODU);
                com.Parameters.AddWithValue("@I_ALTOLAYKODU", ALTOLAYKODU);
                com.Parameters.AddWithValue("@I_OPERATORNOT", OPERATORNOT);
                com.Parameters.AddWithValue("@I_CINSIYET", CINSIYET);
                com.Parameters.AddWithValue("@I_YAS", YAS);
                com.Parameters.AddWithValue("@I_MAIL", MAIL);
                com.Parameters.AddWithValue("@I_DIGERBILGI", DIGERBILGI);
                com.Parameters.AddWithValue("@I_DURUM", DURUM);
                com.Parameters.AddWithValue("@I_DAIRE", DAIRE);
                com.Parameters.AddWithValue("@I_ONCELIKLI", I_ONCELIKLI);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + ID + " numaralı satır editlendi. ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_DETAY(string IH_ID, string IH_KANAL, bool I_AKTIF, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_KANAL=@I_KANAL,I_AKTIF=@I_AKTIF,I_UPDATEDATE = GETDATE() WHERE ID_IHID=@ID and I_KANAL=@I_KANAL", con);
                com.Parameters.AddWithValue("@ID", IH_ID);
                com.Parameters.AddWithValue("@I_KANAL", IH_KANAL);
                com.Parameters.AddWithValue("@I_AKTIF", I_AKTIF);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBARDETAY tablosunda " + IH_ID + " numaralı satır editlendi. ", "I_IHBARLOG", ref durum);
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
        public static void U_KANAL_GUNCELLE(string ID, string I_KANAL2, string I_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_KANAL=@I_KANAL,I_UPDATEDATE= GETDATE() WHERE ID_IHID=@I_ID and I_KANAL=@I_KANAL2", con);
                com.Parameters.AddWithValue("@I_KANAL", I_KANAL);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_KANAL2", I_KANAL2);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBARDETAY tablosunda " + ID + " numaralı satır editlendi. ", "I_IHBARLOG", ref durum);
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
        public static void U_KANAL_GUNCELLE_ILCE(string ID, string I_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_ILCEKANAL=@I_ILCEKANAL,I_UPDATEDATE=GETDATE() WHERE I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ILCEKANAL", I_KANAL);
                com.Parameters.AddWithValue("@I_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + ID + " numaralı satır editlendi. ", "I_KANALLOG", ref durum);
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
        public static void U_EKIP_YONLENDIR(string ID, string ILCEKANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_IHBARDURUM=@I_IHBARDURUM,I_ILCEKANAL=@I_ILCEKANAL,I_UPDATEDATE=GETDATE() WHERE I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_IHBARDURUM", false);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_ILCEKANAL", ILCEKANAL);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + ID + " numaralı satır editlendi. ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_KAPAT(string ID, string Kanal, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_DURUM=@I_DURUM,I_UPDATEDATE=GETDATE() WHERE ID_IHID=@ID_IHID AND I_KANAL=@I_KANAL", con);
                com.Parameters.AddWithValue("@ID_IHID", ID);
                com.Parameters.AddWithValue("@I_KANAL", Kanal.Replace("'",""));
                com.Parameters.AddWithValue("@I_DURUM", "0");
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBARDETAY tablosunda " + ID + " numaralı ihbar kapatıldı. ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_KAPAT2(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_IHBARDURUM=@I_IHBARDURUM,I_UPDATEDATE=GETDATE() WHERE I_ID=@I_ID ", con);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_IHBARDURUM", false);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + ID + " numaralı ihbar kapatıldı. ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_EKIP_YONLENDIR(string ID, string Kanal, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_EKIP=@I_EKIP,I_UPDATEDATE=GETDATE() WHERE ID_IHID=@ID_IHID AND I_KANAL=@I_KANAL", con);
                com.Parameters.AddWithValue("@ID_IHID", ID);
                com.Parameters.AddWithValue("@I_KANAL", Kanal);
                com.Parameters.AddWithValue("@I_EKIP", true);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBARDETAY tablosunda " + ID + " numaralı ekip yönelendirildi ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_EKIP_YONLENDIR_U(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_ULASMATARIH=@EG_ULASMATARIH WHERE EG_ID=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_ULASMATARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@EG_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAREKIP tablosunda " + ID + " numaralı ekip yönlendirme ulaşım tarihi girildi. ", "I_IHBARLOG", ref durum);
                durum = true;
                con.Close();
            }
            catch(Exception ex)
            {
                con.Close();
                durum = false;
                return;
            }
        }
        public static void U_IHBAR_EKIP_YONLENDIR_U2(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_ULASMATARIH=@EG_ULASMATARIH WHERE EG_IHKODU=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_ULASMATARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@EG_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAREKIP tablosunda " + ID + " numaralı ekip yönlendirme ulaşım tarihi girildi ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_EKIP_YONLENDIR_U3(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_KABULTARIH=@EG_KABULTARIH WHERE EG_IHKODU=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_KABULTARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@EG_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAREKIP tablosunda " + ID + " numaralı ekip yönlendirme kabul tarihi girildi ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_EKIP_YONLENDIR_S2(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_SONTARIH=@EG_SONTARIH WHERE EG_IHKODU=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_SONTARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@EG_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAREKIP tablosunda " + ID + " numaralı ekip yönlendirme son tarihi girildi ", "I_IHBARLOG", ref durum);
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

        public static void U_IHBAR_EKIP_YONLENDIR_S(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_SONTARIH=@EG_SONTARIH WHERE EG_ID=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_SONTARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@EG_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAREKIP tablosunda " + ID + " numaralı ekip yönlendirme son tarihi girildi", "I_IHBARLOG", ref durum);
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
        public static void U_IHBAR_EKIP_IHBARKAPAT(string ID,string EKIPKODU, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_IHBAREKIP set EG_EKDURUM=@EG_EKDURUM where EG_IHKODU=@EG_ID AND EG_EKKODU=@EG_EKKODU", con);

                com.Parameters.AddWithValue("@EG_EKDURUM", false);
                com.Parameters.AddWithValue("@EG_ID", ID);
                com.Parameters.AddWithValue("@EG_EKKODU", EKIPKODU);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAREKIP tablosunda " + ID + " numaralı ekip yönlendirme ihbar sonuç raporu girildi", "I_IHBARLOG", ref durum);
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
        public static void U_EKIPTELEFON(string ID, string E_KODU, string E_TELEFON, string E_ISIMSOYISIM, string E_GOREVI, string E_GOREVYERI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_EKIPTELEFON set E_KODU=@E_KODU,E_TELEFON=@E_TELEFON,E_ISIMSOYISIM=@E_ISIMSOYISIM,E_GOREVI=@E_GOREVI,E_GOREVYERI=@E_GOREVYERI where E_ID=@E_ID", con);
                com.Parameters.AddWithValue("@E_KODU", E_KODU);
                com.Parameters.AddWithValue("@E_TELEFON", E_TELEFON);
                com.Parameters.AddWithValue("@E_ISIMSOYISIM", E_ISIMSOYISIM);
                com.Parameters.AddWithValue("@E_GOREVI", E_GOREVI);
                com.Parameters.AddWithValue("@E_GOREVYERI", E_GOREVYERI);
                com.Parameters.AddWithValue("@E_ID", ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_EKIPTELEFON tablosunda " + ID + " numaralı ekip telefon güncellendi ", "I_KANALLOG", ref durum);
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
        public static void U_TARIHGUNCELLE(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_IHBAR set I_TARIH=@I_TARIH where I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_TARIH", Convert.ToDateTime(GetTime.Time()));
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + ID + " numaralı ihbar tarihi güncellendi ", "I_IHBARLOG", ref durum);
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
        public static void U_IHBARDURUMGUNCELLE(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_IHBAR set I_EKIPIHBAR=@I_EKIPIHBAR where I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_EKIPIHBAR", true);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_EKIPIHBAR tablosunda " + ID + " numaralı ekip yönlendirildi", "I_KANALLOG", ref durum);
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
        public static void U_SIFRE_DEGISTIR(string USR_SIFRE, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_USERS SET USR_SIFRE=@USR_SIFRE WHERE USR_ID=@USR_ID", con);
                com.Parameters.AddWithValue("@USR_ID",StatikData.SS_ID);
                com.Parameters.AddWithValue("@USR_SIFRE", USR_SIFRE);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_USERS tablosunda " + StatikData.SS_ID + " numaralı şifre değiştirildi ", "I_KULLANICILOG", ref durum);
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

        public static Boolean U_PLAKA_GUNCELLE(string Id,string I_PLAKA)  
        {
            SqlConnection con = new SqlConnection();
            try
            {
                bool durum = false;
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_IHBAR set I_PLAKA=@I_PLAKA where I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ID", Id);
                com.Parameters.AddWithValue("@I_PLAKA", I_PLAKA);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_IHBAR tablosunda " + Id + " numaralı plaka güncellendi ", "I_IHBARLOG", ref durum);
                con.Close();
                return true;
            }
            catch
            {
                con.Close();
                return false;

            }
        }
        public static void U_TARIHTEBUGUN(string TBNO, int GUN, string AY, int YIL, string GRUP, string OLAY, string YAPILACAKLAR, string KULLANICI, string TARIH, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_TARIHTE_NEOLMUS [TB_GUN]=@GUN,[TB_AY]=@AY,[TB_YIL]=@YIL,[TB_GRUP]=@GRUP,[TB_OLAY]=@OLAY,[TB_YAPILACAKLAR]=@YAPILACAKLAR,[TB_KULLANICI]=@KULLANICI,[TB_TARIH]=@TARIH WHERE TB_ID=@TBNO", con);
                com.Parameters.AddWithValue("@GUN", GUN);
                com.Parameters.AddWithValue("@AY", AY);
                com.Parameters.AddWithValue("@YIL", YIL);
                com.Parameters.AddWithValue("@GRUP", GRUP);
                com.Parameters.AddWithValue("@OLAY", OLAY);
                com.Parameters.AddWithValue("@YAPILACAKLAR", YAPILACAKLAR);
                com.Parameters.AddWithValue("@KULLANICI", KULLANICI);
                com.Parameters.AddWithValue("@TARIH", TARIH);
                com.Parameters.AddWithValue("@TBNO", TBNO);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("I_TARIHTE_NEOLMUS tablosunda " + TBNO + " numaralı satır editlendi. ", "I_IHBARLOG", ref durum);
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
        public static void U_KISISEL_BILGI(string USR_ID, string AD, string SOYAD, string EV_TELEFONU, string IS_TELEFONU, string CEP_TELEFONU, string RUTBE, string GOREVI, string TELSIZ_ADI, int VARDIYA, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_USERS SET USR_ADI=@USR_ADI,USR_SOYADI=@USR_SOYADI,USR_TELEFON_EV=@USR_TELEFON_EV,USR_TELEFON_IS=@USR_TELEFON_IS,USR_TELEFON_GSM=@USR_TELEFON_GSM,USR_RUTBE=@USR_RUTBE,USR_GOREV=@USR_GOREV,USR_TELSIZKANAL=@USR_TELSIZKANAL,USR_VARDIYA=@USR_VARDIYA WHERE USR_ID=@USR_ID", con);
                com.Parameters.AddWithValue("@USR_ADI", AD);
                com.Parameters.AddWithValue("@USR_SOYADI", SOYAD);
                com.Parameters.AddWithValue("@USR_TELEFON_EV", EV_TELEFONU);
                com.Parameters.AddWithValue("@USR_TELEFON_IS", IS_TELEFONU);
                com.Parameters.AddWithValue("@USR_TELEFON_GSM", CEP_TELEFONU);
                com.Parameters.AddWithValue("@USR_RUTBE", RUTBE);
                com.Parameters.AddWithValue("@USR_GOREV", GOREVI);
                com.Parameters.AddWithValue("@USR_TELSIZKANAL", TELSIZ_ADI);
                com.Parameters.AddWithValue("@USR_VARDIYA", VARDIYA);
                com.Parameters.AddWithValue("@USR_ID", USR_ID);
                int deger = com.ExecuteNonQuery();
                Log.I_LOG("KISISEL_BILGILER tablosunda " + USR_ID + " numaralı satır editlendi. ", "I_KULLANICILOG", ref durum);
                durum = true;
                con.Close();
            }
            catch(Exception c)
            {
                con.Close();
                durum = false;
                return;
            }
        }
        public static void U_KISAYOLGRUP(string MKYG_ID, string MKYG_ADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_KISAYOLGRUP SET MKYG_ADI=@MKYG_ADI WHERE MKYG_ID=@MKYG_ID;", con);
                com.Parameters.AddWithValue("@MKYG_ADI", MKYG_ADI);
                com.Parameters.AddWithValue("@MKYG_ID", MKYG_ID);
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
        public static void U_ISIMSOYISIM_GOSTER_UPDATE(string I_ID, bool I_ARAYANNOISIMGOSTER,ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_ARAYANNOISIMGOSTER=@I_ARAYANNOISIMGOSTER WHERE I_ID=@I_ID;", con);
                com.Parameters.AddWithValue("@I_ARAYANNOISIMGOSTER", I_ARAYANNOISIMGOSTER);
                com.Parameters.AddWithValue("@I_ID", I_ID);
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

        public static void U_KAMERA(int KMR_ID,string KMRADI, double LAT, double LON, string KMRTIP, int ILID, string ILCEID, int MAHID, string ADRES, string NOT, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_KAMERA_LOKASYON SET KMRADI=@KMRADI,KMRTIPI=@KMRTIPI,KMRILID=@KMRILID,KMRILCEID=@KMRILCEID,KMRMAHID=@KMRMAHID,KMRADRES=@KMRADRES,KMRNOT=@KMRNOT WHERE KMR_ID=@KMR_ID;", con);
                com.Parameters.AddWithValue("@KMR_ID", KMR_ID);
                com.Parameters.AddWithValue("@KMRADI", KMRADI);
                //com.Parameters.AddWithValue("@KMRLAT", LAT);
                //com.Parameters.AddWithValue("@KMRLON", LON);
                com.Parameters.AddWithValue("@KMRTIPI", KMRTIP);
                com.Parameters.AddWithValue("@KMRILID", ILID);
                com.Parameters.AddWithValue("@KMRILCEID", ILCEID);
                com.Parameters.AddWithValue("@KMRMAHID", MAHID);
                com.Parameters.AddWithValue("@KMRADRES", ADRES);
                com.Parameters.AddWithValue("@KMRNOT", NOT);

                int deger = com.ExecuteNonQuery();
                durum = true;
                con.Close();
            }
            catch(Exception exp)
            {
                con.Close();
                durum = false;
                return;
            }
        }

        public static void I_KAMERA_LOKASYON(string kameraId, double positionLat, double positionLang, ref bool durum)
        {
            //Lokasyon güncelleme işlemi yapılıyor.
            SqlConnection cnn = new SqlConnection();
            try
            {
                Connection.OpenConnection(ref cnn);

                string commandText = @"
UPDATE [I_KAMERA_LOKASYON]
SET
KMRLAT = @kmrLat,
KMRLON = @kmrLon
WHERE KMR_ID = @id
";
                SqlCommand cmd = new SqlCommand(commandText, cnn);
                cmd.Parameters.AddWithValue("@id", kameraId);
                cmd.Parameters.AddWithValue("@kmrLat", positionLat);
                cmd.Parameters.AddWithValue("@kmrLon", positionLang);
                int result = cmd.ExecuteNonQuery();
             
                durum = true;
                cnn.Close();
            }
            catch (Exception ex)
            {
                cnn.Close();
                durum = false;
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

        }
    }
}
