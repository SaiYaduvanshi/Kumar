using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace MK_HelperDataLib
{
   public class Insert
    {
        public static void I_YETKI(string YETKIADI, string YETKIID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_YETKI(YT_YETKIID,YT_YETKIADI) values(@YT_YETKIID,@YT_YETKIADI);select IDENT_CURRENT('I_YETKI');", con);
                com.Parameters.AddWithValue("@YT_YETKIID", YETKIID);
                com.Parameters.AddWithValue("@YT_YETKIADI", YETKIADI);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_YETKI tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_YETKILOG", ref durum);
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

        public static void I_YETKI_DETAY(string MODULID, bool OKU, bool YAZ, bool SIL, bool EKSTRA, string YETKIID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_YETKIDETAY(YTD_MODULID,YTD_OKU,YTD_YAZ,YTD_SIL,YTD_EKSTRA,YTD_YETKIID) values(@MODULID,@OKU,@YAZ,@SIL,@EKSTRA,@YETKIID);select IDENT_CURRENT('I_YETKI');", con);
                com.Parameters.AddWithValue("@MODULID", MODULID);
                com.Parameters.AddWithValue("@OKU", OKU);
                com.Parameters.AddWithValue("@YAZ", YAZ);
                com.Parameters.AddWithValue("@SIL", SIL);
                com.Parameters.AddWithValue("@YETKIID", YETKIID);
                com.Parameters.AddWithValue("@EKSTRA", EKSTRA);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_YETKIDETAY tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_YETKILOG", ref durum);
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

        public static bool I_KULLANICI(string USR_SICILNO, string USR_ADI, string USR_SOYADI, string USR_KULLANICIADI, string USR_SIFRE, string USR_YETKIKODU, string USR_GRUPKODU, string USR_KANALYETKI, string USR_ONAYYETKI, string USR_TELEFON_EV, string USR_TELEFON_IS, string USR_TELEFON_GSM, string USR_RUTBE, string USR_GOREV, string USR_TELSIZKANAL, string USR_VARDIYA, string USR_DAHILI, string USR_IL, string USR_ILCE, string USR_SUBE, bool USR_DURUM, string USR_EKIPKODU, bool USR_KNLSEC)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_USERS(USR_SICILNO,USR_ADI,USR_SOYADI,USR_KULLANICIADI,USR_SIFRE,USR_YETKIKODU,USR_GRUPKODU,USR_KANALYETKI,USR_ONAYYETKI,USR_TELEFON_EV,USR_TELEFON_IS,USR_TELEFON_GSM,USR_RUTBE,USR_GOREV,USR_TELSIZKANAL,USR_VARDIYA,USR_DAHILI,USR_IL,USR_ILCE,USR_SUBE,USR_DURUM,USR_KAYITTARIH,USR_SONGIRIS,USR_EKIPKODU,USR_KNLSEC ) values(@USR_SICILNO,@USR_ADI,@USR_SOYADI,@USR_KULLANICIADI,@USR_SIFRE,@USR_YETKIKODU,@USR_GRUPKODU,@USR_KANALYETKI,@USR_ONAYYETKI,@USR_TELEFON_EV,@USR_TELEFON_IS,@USR_TELEFON_GSM,@USR_RUTBE,@USR_GOREV,@USR_TELSIZKANAL,@USR_VARDIYA,@USR_DAHILI,@USR_IL,@USR_ILCE,@USR_SUBE,@USR_DURUM,@USR_KAYITTARIH,@USR_SONGIRIS,@USR_EKIPKODU,@USR_KNLSEC );select IDENT_CURRENT('I_YETKI');", con);
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
                com.Parameters.AddWithValue("@USR_KAYITTARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@USR_SONGIRIS", DBNull.Value);
                com.Parameters.AddWithValue("@USR_EKIPKODU", USR_EKIPKODU);
                com.Parameters.AddWithValue("@USR_KNLSEC", USR_KNLSEC);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_USERS tablosuna "+ x.ToString() + " numaralı satır eklendi.", "I_KULLANICILOG", ref durum);
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
                SqlCommand com = new SqlCommand("insert I_GRUP(GRP_KODU,GRP_ADI,GRP_USRKODU) values(@GRP_KODU,@GRP_ADI,@GRP_USRKODU);select IDENT_CURRENT('I_IHBAR') ;", con);
                com.Parameters.AddWithValue("@GRP_KODU", GRP_KODU);
                com.Parameters.AddWithValue("@GRP_ADI", GRP_ADI);
                com.Parameters.AddWithValue("@GRP_USRKODU", GRP_USRKODU);
                int deger = com.ExecuteNonQuery();
                string id = "xx";
                Log.I_LOG("I_GRUP tablosuna " + id + " numaralı satır eklendi.", "I_KULLANICILOG", ref durum);
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
        public static bool I_IHBAR(string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string MAHALLE, string CADDE, string SITE, string BINA,string BINANNO, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool ONCELIK, string KANAL, string I_KAYNAK, string TUR, ref int id)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBAR(I_TELEFON,I_ISIMSOYISIM,I_IL,I_ILCE,I_MAHALLE,I_CADDE,I_SITE,I_BINA,I_BINANO,I_DAIRE,I_PLAKA,I_ADRES,I_LATITUDE,I_LONGITUDE,I_IHBARBILGISI,I_USTOLAYKODU,I_ALTOLAYKODU,I_OPERATORNOT,I_CINSIYET,I_YAS,I_MAIL,I_DIGERBILGI,I_TARIH,I_KULLANICI,I_DURUM,I_IHBARDURUM,I_ONCELIKLI,I_KANAL,I_KAYNAK,I_IHBARTUR,I_EKIPIHBAR) values(@I_TELEFON,@I_ISIMSOYISIM,@I_IL,@I_ILCE,@I_MAHALLE,@I_CADDE,@I_SITE,@I_BINA,@I_BINANO,@I_DAIRE,@I_PLAKA,@I_ADRES,@I_LATITUDE,@I_LONGITUDE,@I_IHBARBILGISI,@I_USTOLAYKODU,@I_ALTOLAYKODU,@I_OPERATORNOT,@I_CINSIYET,@I_YAS,@I_MAIL,@I_DIGERBILGI,@I_TARIH,@I_KULLANICI,@I_DURUM,@I_IHBARDURUM,@I_ONCELIKLI,@I_KANAL,@I_KAYNAK,@I_IHBARTUR,@I_EKIPIHBAR);select IDENT_CURRENT('I_IHBAR') ;", con);
                com.Parameters.AddWithValue("@I_TELEFON", TELEFON);
                com.Parameters.AddWithValue("@I_ISIMSOYISIM", ISIMSOYISIM);
                com.Parameters.AddWithValue("@I_IL", IL);
                com.Parameters.AddWithValue("@I_ILCE", ILCE);
                com.Parameters.AddWithValue("@I_MAHALLE", MAHALLE);
                com.Parameters.AddWithValue("@I_CADDE", CADDE);
                com.Parameters.AddWithValue("@I_SITE", SITE);
                com.Parameters.AddWithValue("@I_BINA", BINA);
                com.Parameters.AddWithValue("@I_BINANO", BINANNO);
                com.Parameters.AddWithValue("@I_DAIRE", DAIRE);
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
                com.Parameters.AddWithValue("@I_TARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@I_KULLANICI", StatikData.USR_SICILNO);
                com.Parameters.AddWithValue("@I_DURUM", DURUM);
                com.Parameters.AddWithValue("@I_IHBARDURUM", true);
                com.Parameters.AddWithValue("@I_ONCELIKLI", ONCELIK);
                com.Parameters.AddWithValue("@I_KANAL", KANAL);
                com.Parameters.AddWithValue("@I_KAYNAK", I_KAYNAK);
                com.Parameters.AddWithValue("@I_IHBARTUR", TUR);
                com.Parameters.AddWithValue("@I_EKIPIHBAR", false);
                object x = com.ExecuteScalar(); 
                Log.I_LOG("I_IHBAR tablosuna "+x.ToString()+" numaralı satır eklendi.", "I_IHBARLOG", ref durum);
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
        public static bool I_IHBAR_GUVENLIK(string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string MAHALLE, string CADDE, string SITE, string BINA, string BINANNO, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool ONCELIK, string KANAL, string I_KAYNAK, string TUR, string I_GUVENLIKSIRKETI, string I_GUVENLIKSIRKETIADI, string I_GUVENLIKSIR_ABONESI, string I_GUVENLIKSIR_ABONESIADI, string I_GUVENLIK_ALARMTURU, ref int id)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBAR(I_TELEFON,I_ISIMSOYISIM,I_IL,I_ILCE,I_MAHALLE,I_CADDE,I_SITE,I_BINA,I_BINANO,I_DAIRE,I_PLAKA,I_ADRES,I_LATITUDE,I_LONGITUDE,I_IHBARBILGISI,I_USTOLAYKODU,I_ALTOLAYKODU,I_OPERATORNOT,I_CINSIYET,I_YAS,I_MAIL,I_DIGERBILGI,I_TARIH,I_KULLANICI,I_DURUM,I_IHBARDURUM,I_ONCELIKLI,I_KANAL,I_KAYNAK,I_IHBARTUR,I_EKIPIHBAR,I_GUVENLIKSIRKETI,I_GUVENLIKSIRKETIADI,I_GUVENLIKSIR_ABONESI,I_GUVENLIKSIR_ABONESIADI,I_GUVENLIK_ALARMTURU) values(@I_TELEFON,@I_ISIMSOYISIM,@I_IL,@I_ILCE,@I_MAHALLE,@I_CADDE,@I_SITE,@I_BINA,@I_BINANO,@I_DAIRE,@I_PLAKA,@I_ADRES,@I_LATITUDE,@I_LONGITUDE,@I_IHBARBILGISI,@I_USTOLAYKODU,@I_ALTOLAYKODU,@I_OPERATORNOT,@I_CINSIYET,@I_YAS,@I_MAIL,@I_DIGERBILGI,@I_TARIH,@I_KULLANICI,@I_DURUM,@I_IHBARDURUM,@I_ONCELIKLI,@I_KANAL,@I_KAYNAK,@I_IHBARTUR,@I_EKIPIHBAR,@I_GUVENLIKSIRKETI,@I_GUVENLIKSIRKETIADI,@I_GUVENLIKSIR_ABONESI,@I_GUVENLIKSIR_ABONESIADI,@I_GUVENLIK_ALARMTURU);select IDENT_CURRENT('I_IHBAR') ;", con);
                com.Parameters.AddWithValue("@I_TELEFON", TELEFON);
                com.Parameters.AddWithValue("@I_ISIMSOYISIM", ISIMSOYISIM);
                com.Parameters.AddWithValue("@I_IL", IL);
                com.Parameters.AddWithValue("@I_ILCE", ILCE);
                com.Parameters.AddWithValue("@I_MAHALLE", MAHALLE);
                com.Parameters.AddWithValue("@I_CADDE", CADDE);
                com.Parameters.AddWithValue("@I_SITE", SITE);
                com.Parameters.AddWithValue("@I_BINA", BINA);
                com.Parameters.AddWithValue("@I_BINANO", BINANNO);
                com.Parameters.AddWithValue("@I_DAIRE", DAIRE);
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
                com.Parameters.AddWithValue("@I_TARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@I_KULLANICI", StatikData.USR_SICILNO);
                com.Parameters.AddWithValue("@I_DURUM", DURUM);
                com.Parameters.AddWithValue("@I_IHBARDURUM", true);
                com.Parameters.AddWithValue("@I_ONCELIKLI", ONCELIK);
                com.Parameters.AddWithValue("@I_KANAL", KANAL);
                com.Parameters.AddWithValue("@I_KAYNAK", I_KAYNAK);
                com.Parameters.AddWithValue("@I_IHBARTUR", TUR);
                com.Parameters.AddWithValue("@I_EKIPIHBAR", false);
                com.Parameters.AddWithValue("@I_GUVENLIKSIRKETI", I_GUVENLIKSIRKETI);
                com.Parameters.AddWithValue("@I_GUVENLIKSIRKETIADI", I_GUVENLIKSIRKETIADI);
                com.Parameters.AddWithValue("@I_GUVENLIKSIR_ABONESI", I_GUVENLIKSIR_ABONESI);
                com.Parameters.AddWithValue("@I_GUVENLIKSIR_ABONESIADI", I_GUVENLIKSIR_ABONESIADI);
                com.Parameters.AddWithValue("@I_GUVENLIK_ALARMTURU", I_GUVENLIK_ALARMTURU);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBAR tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);
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
        public static bool I_IHBAR_CALINTI(string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string MAHALLE, string CADDE, string SITE, string BINA, string BINANNO, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool ONCELIK, string KANAL, string I_KAYNAK, string TUR, string I_CALARAC_ADET, string I_CALARAC_RENK, string I_CALARAC_MARKA, string I_CALARAC_MODEL, string I_CALARAC_ARACTIP, string I_CALARAC_KARAKOL, bool I_CALARAC_SADECEPLAKA, ref int id)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBAR(I_TELEFON,I_ISIMSOYISIM,I_IL,I_ILCE,I_MAHALLE,I_CADDE,I_SITE,I_BINA,I_BINANO,I_DAIRE,I_PLAKA,I_ADRES,I_LATITUDE,I_LONGITUDE,I_IHBARBILGISI,I_USTOLAYKODU,I_ALTOLAYKODU,I_OPERATORNOT,I_CINSIYET,I_YAS,I_MAIL,I_DIGERBILGI,I_TARIH,I_KULLANICI,I_DURUM,I_IHBARDURUM,I_ONCELIKLI,I_KANAL,I_KAYNAK,I_IHBARTUR,I_EKIPIHBAR,I_CALARAC_ADET,I_CALARAC_RENK,I_CALARAC_MARKA,I_CALARAC_MODEL,I_CALARAC_ARACTIP,I_CALARAC_KARAKOL,I_CALARAC_SADECEPLAKA) values(@I_TELEFON,@I_ISIMSOYISIM,@I_IL,@I_ILCE,@I_MAHALLE,@I_CADDE,@I_SITE,@I_BINA,@I_BINANO,@I_DAIRE,@I_PLAKA,@I_ADRES,@I_LATITUDE,@I_LONGITUDE,@I_IHBARBILGISI,@I_USTOLAYKODU,@I_ALTOLAYKODU,@I_OPERATORNOT,@I_CINSIYET,@I_YAS,@I_MAIL,@I_DIGERBILGI,@I_TARIH,@I_KULLANICI,@I_DURUM,@I_IHBARDURUM,@I_ONCELIKLI,@I_KANAL,@I_KAYNAK,@I_IHBARTUR,@I_EKIPIHBAR,@I_CALARAC_ADET,@I_CALARAC_RENK,@I_CALARAC_MARKA,@I_CALARAC_MODEL,@I_CALARAC_ARACTIP,@I_CALARAC_KARAKOL,@I_CALARAC_SADECEPLAKA);select IDENT_CURRENT('I_IHBAR') ;", con);
                com.Parameters.AddWithValue("@I_TELEFON", TELEFON);
                com.Parameters.AddWithValue("@I_ISIMSOYISIM", ISIMSOYISIM);
                com.Parameters.AddWithValue("@I_IL", IL);
                com.Parameters.AddWithValue("@I_ILCE", ILCE);
                com.Parameters.AddWithValue("@I_MAHALLE", MAHALLE);
                com.Parameters.AddWithValue("@I_CADDE", CADDE);
                com.Parameters.AddWithValue("@I_SITE", SITE);
                com.Parameters.AddWithValue("@I_BINA", BINA);
                com.Parameters.AddWithValue("@I_BINANO", BINANNO);
                com.Parameters.AddWithValue("@I_DAIRE", DAIRE);
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
                com.Parameters.AddWithValue("@I_TARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@I_KULLANICI", StatikData.USR_SICILNO);
                com.Parameters.AddWithValue("@I_DURUM", DURUM);
                com.Parameters.AddWithValue("@I_IHBARDURUM", true);
                com.Parameters.AddWithValue("@I_ONCELIKLI", ONCELIK);
                com.Parameters.AddWithValue("@I_KANAL", KANAL);
                com.Parameters.AddWithValue("@I_KAYNAK", I_KAYNAK);
                com.Parameters.AddWithValue("@I_IHBARTUR", TUR);
                com.Parameters.AddWithValue("@I_EKIPIHBAR", false);
                com.Parameters.AddWithValue("@I_CALARAC_ADET", I_CALARAC_ADET);
                com.Parameters.AddWithValue("@I_CALARAC_RENK", I_CALARAC_RENK);
                com.Parameters.AddWithValue("@I_CALARAC_MARKA", I_CALARAC_MARKA);
                com.Parameters.AddWithValue("@I_CALARAC_MODEL", I_CALARAC_MODEL);
                com.Parameters.AddWithValue("@I_CALARAC_ARACTIP", I_CALARAC_ARACTIP);
                com.Parameters.AddWithValue("@I_CALARAC_KARAKOL", I_CALARAC_KARAKOL);
                com.Parameters.AddWithValue("@I_CALARAC_SADECEPLAKA", I_CALARAC_SADECEPLAKA);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBAR tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);
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
        public static void I_IHBAR_DETAY(string IH_ID, string IH_KANAL, bool IH_AMB, bool IH_ITF,string kanal, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBARDETAY(ID_IHID,I_KANAL,I_TARIHSAAT,I_KULLANICI,I_OKUMA,I_AKTIF,I_DURUM,I_AMB,I_ITF,I_ASILKANAL) values(@ID_IHID,@I_KANAL,@I_TARIHSAAT,@I_KULLANICI,@I_OKUMA,@I_AKTIF,@I_DURUM,@I_AMB,@I_ITF,@I_ASILKANAL);select IDENT_CURRENT('I_IHBARDETAY') ;", con);
                com.Parameters.AddWithValue("@ID_IHID", IH_ID);
                com.Parameters.AddWithValue("@I_KANAL", IH_KANAL);
                com.Parameters.AddWithValue("@I_TARIHSAAT", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"]);
                com.Parameters.AddWithValue("@I_OKUMA", false);
                com.Parameters.AddWithValue("@I_AKTIF", true);
                com.Parameters.AddWithValue("@I_DURUM", true);
                com.Parameters.AddWithValue("@I_AMB", IH_AMB);
                com.Parameters.AddWithValue("@I_ITF", IH_ITF);
                com.Parameters.AddWithValue("@I_ASILKANAL", kanal);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBARDETAY tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);
                
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
        public static void I_MESAJ(string IN_IHID, string IN_OLAYKODU, string IN_MESAJ, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBAR_MESAJ(IN_IHID,IN_OLAYKODU,IN_MESAJ,IN_TARIHSAAT,IN_KULLANICI) values(@IN_IHID,@IN_OLAYKODU,@IN_MESAJ,@IN_TARIHSAAT,@IN_KULLANICI);select IDENT_CURRENT('I_IHBAR_MESAJ')  ;", con);
                com.Parameters.AddWithValue("@IN_IHID", IN_IHID);
                com.Parameters.AddWithValue("@IN_OLAYKODU", IN_OLAYKODU);
                com.Parameters.AddWithValue("@IN_MESAJ", IN_MESAJ);
                com.Parameters.AddWithValue("@IN_TARIHSAAT", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@IN_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString()); 
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBAR_MESAJ tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);

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
        public static void I_LOG(string L_IHBARID, string L_KANAL, string L_ISLEM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_LOG(L_IHBARID,L_SICILNO,L_KANAL,L_TARIHSAAT,L_ISLEM,L_ASILKANAL) values(@L_IHBARID,@L_SICILNO,@L_KANAL,@L_TARIHSAAT,@L_ISLEM,@L_ASILKANAL)", con);
                com.Parameters.AddWithValue("@L_IHBARID", L_IHBARID);
                com.Parameters.AddWithValue("@L_ISLEM", L_ISLEM);
                com.Parameters.AddWithValue("@L_KANAL", L_KANAL.Replace("'", ""));
                com.Parameters.AddWithValue("@L_TARIHSAAT", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@L_SICILNO", HttpContext.Current.Session["USR_SICILNO"].ToString());
                com.Parameters.AddWithValue("@L_ASILKANAL", L_KANAL.Replace("'", ""));
                int deger = com.ExecuteNonQuery();
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
        public static void I_LOG2(string L_IHBARID, string L_KANAL,string ASILKANAL, string L_ISLEM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_LOG(L_IHBARID,L_SICILNO,L_KANAL,L_TARIHSAAT,L_ISLEM,L_ASILKANAL) values(@L_IHBARID,@L_SICILNO,@L_KANAL,@L_TARIHSAAT,@L_ISLEM,@L_ASILKANAL)", con);
                com.Parameters.AddWithValue("@L_IHBARID", L_IHBARID);
                com.Parameters.AddWithValue("@L_ISLEM", L_ISLEM);
                com.Parameters.AddWithValue("@L_KANAL", L_KANAL.Replace("'", ""));
                com.Parameters.AddWithValue("@L_TARIHSAAT", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@L_SICILNO", HttpContext.Current.Session["USR_SICILNO"].ToString());
                com.Parameters.AddWithValue("@L_ASILKANAL", ASILKANAL.Replace("'", ""));
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

        public static void I_EKIP_YONLENDIR(string EG_EKKODU, string EG_IHKODU, bool EG_EKDURUM,string KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBAREKIP(EG_KANAL,EG_EKKODU,EG_IHKODU,EG_EKDURUM,EG_ILCEDURUM,EG_TARIH) values(@EG_KANAL,@EG_EKKODU,@EG_IHKODU,@EG_EKDURUM,@EG_ILCEDURUM,@EG_TARIH);select IDENT_CURRENT('I_IHBAREKIP');", con);
                com.Parameters.AddWithValue("@EG_KANAL",KANAL);
                com.Parameters.AddWithValue("@EG_EKKODU", EG_EKKODU);
                com.Parameters.AddWithValue("@EG_IHKODU", EG_IHKODU);
                com.Parameters.AddWithValue("@EG_EKDURUM", EG_EKDURUM);
                com.Parameters.AddWithValue("@EG_ILCEDURUM", false);
                com.Parameters.AddWithValue("@EG_TARIH", Convert.ToDateTime(GetTime.Time()));
                object x = com.ExecuteScalar();
                Log.I_LOG("I_KANALLOG tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_KANALLOG", ref durum);

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
                SqlCommand com = new SqlCommand("insert I_EKIPTELEFON(E_KODU,E_TELEFON,E_ISIMSOYISIM,E_GOREVI,E_GOREVYERI) values(@E_KODU,@E_TELEFON,@E_ISIMSOYISIM,@E_GOREVI,@E_GOREVYERI);select IDENT_CURRENT('I_EKIPTELEFON');", con);
                com.Parameters.AddWithValue("@E_KODU", E_KODU);
                com.Parameters.AddWithValue("@E_TELEFON", E_TELEFON);
                com.Parameters.AddWithValue("@E_ISIMSOYISIM", E_ISIMSOYISIM);
                com.Parameters.AddWithValue("@E_GOREVI", E_GOREVI);
                com.Parameters.AddWithValue("@E_GOREVYERI", E_GOREVYERI);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_EKIPTELEFON tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_KANALLOG", ref durum);

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
        public static void I_TUTANAK(string T_IHBARCIADI, string T_IHBARBOLGESI, string T_ADRES, string T_CINSIYET, string T_KONU, string T_IHBARBILGI,string T_IHBARID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBARTUTANAK(T_IHBARCIADI,T_IHBARBOLGESI,T_ADRES,T_CINSIYET,T_KONU,T_IHBARBILGI,T_IHBARID,T_TARIH) values(@T_IHBARCIADI,@T_IHBARBOLGESI,@T_ADRES,@T_CINSIYET,@T_KONU,@T_IHBARBILGI,@T_IHBARID,@T_TARIH);select IDENT_CURRENT('I_IHBARTUTANAK'); ", con);
                com.Parameters.AddWithValue("@T_IHBARCIADI", T_IHBARCIADI);
                com.Parameters.AddWithValue("@T_IHBARBOLGESI", T_IHBARBOLGESI);
                com.Parameters.AddWithValue("@T_ADRES", T_ADRES);
                com.Parameters.AddWithValue("@T_CINSIYET", T_CINSIYET);
                com.Parameters.AddWithValue("@T_KONU", T_KONU);
                com.Parameters.AddWithValue("@T_IHBARBILGI", T_IHBARBILGI);
                com.Parameters.AddWithValue("@T_IHBARID", T_IHBARID);
                com.Parameters.AddWithValue("@T_TARIH", Convert.ToDateTime(GetTime.Time()));
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBARTUTANAK tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);

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

        public static void I_IHBARKAPAT(string IK_NOT, string IK_IHBARID, string IK_EKIP, string IK_TIP,string IK_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBARKAPANIS(IK_KANAL,IK_NOT,IK_IHBARID,IK_TARIH,IK_EKIP,IK_TIP) values(@IK_KANAL,@IK_NOT,@IK_IHBARID,@IK_TARIH,@IK_EKIP,@IK_TIP);select IDENT_CURRENT('I_IHBARKAPANIS');", con);
                com.Parameters.AddWithValue("@IK_KANAL", IK_KANAL);
                com.Parameters.AddWithValue("@IK_NOT", IK_NOT);
                com.Parameters.AddWithValue("@IK_IHBARID", IK_IHBARID);
                com.Parameters.AddWithValue("@IK_TARIH", Convert.ToDateTime(GetTime.Time()));
                com.Parameters.AddWithValue("@IK_EKIP", IK_EKIP);
                com.Parameters.AddWithValue("@IK_TIP", IK_TIP);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBARKAPANIS tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);

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
        public static Boolean I_TEMPTELEFON(string TELEFON, string AGENT)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand(@"INSERT INTO [dbo].[I_TEMP_TELEFON]
           ([TMP_TELEFON]
           ,[TMP_TARIH]
           ,[TMP_AGENT])
     VALUES
           (@telefon
           ,getdate()
           ,@agent)", con);
                com.Parameters.AddWithValue("@telefon", TELEFON);
                com.Parameters.AddWithValue("@agent", AGENT);
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

        public static Boolean I_INSERTSCRIPT(string SCRIPT)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand(SCRIPT, con);
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
        public static void I_IHBARTAKIP(string I_IHBARID,int tip, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_IHBARTAKIP(I_IHBARID,I_KULLANICI,I_TIP,I_KANAL) values(@I_IHBARID,@I_KULLANICI,@I_TIP,@I_KANAL);select IDENT_CURRENT('I_IHBARTAKIP');", con);
                com.Parameters.AddWithValue("@I_IHBARID", I_IHBARID);
                com.Parameters.AddWithValue("@I_TIP", tip);
                com.Parameters.AddWithValue("@I_KULLANICI", HttpContext.Current.Session["USR_SICILNO"].ToString());
                com.Parameters.AddWithValue("@I_KANAL", HttpContext.Current.Session["SS_KANAL"].ToString());
                object x = com.ExecuteScalar();
                Log.I_LOG("I_IHBARTAKIP tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);

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
        public static void I_EKIPTAKIP(string I_EKIPKODU, int tip, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_EKIPTAKIP(EK_KODU,EK_KULLANICI,EK_TIP) values(@EK_KODU,@EK_KULLANICI,@EK_TIP);select IDENT_CURRENT('I_EKIPTAKIP');", con);
                com.Parameters.AddWithValue("@EK_KODU", I_EKIPKODU);
                com.Parameters.AddWithValue("@EK_TIP", tip);
                com.Parameters.AddWithValue("@EK_KULLANICI", StatikData.USR_SICILNO);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_EKIPTAKIP tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_KANALLOG", ref durum);

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
        public static void I_DUYURU(string DuyuruMetni, string Kullanici, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_DUYURU (D_ACIKLAMA,D_KULLANICI,D_TARIH) values(@ACIKLAMA,@KULLANICI,GETDATE());select IDENT_CURRENT('I_DUYURU');", con);
                com.Parameters.AddWithValue("@ACIKLAMA", DuyuruMetni);
                com.Parameters.AddWithValue("@KULLANICI", Kullanici); 
                object x = com.ExecuteScalar();
                Log.I_LOG("I_DUYURU tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_KULLANICILOG", ref durum);

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

        public static void I_TARIHTEBUGUN(int GUN, string AY, int YIL, string GRUP, string OLAY, string YAPILACAKLAR, string KULLANICI, string TARIH, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_TARIHTE_NEOLMUS ([TB_GUN],[TB_AY],[TB_YIL],[TB_GRUP],[TB_OLAY],[TB_YAPILACAKLAR],[TB_KULLANICI],[TB_TARIH]) values (@GUN,@AY,@YIL,@GRUP,@OLAY,@YAPILACAKLAR,@KULLANICI,@TARIH);select IDENT_CURRENT('I_TARIHTE_NEOLMUS');", con);
                com.Parameters.AddWithValue("@GUN", GUN);
                com.Parameters.AddWithValue("@AY", AY);
                com.Parameters.AddWithValue("@YIL", YIL);
                com.Parameters.AddWithValue("@GRUP", GRUP);
                com.Parameters.AddWithValue("@OLAY", OLAY);
                com.Parameters.AddWithValue("@YAPILACAKLAR", YAPILACAKLAR);
                com.Parameters.AddWithValue("@KULLANICI", KULLANICI);
                com.Parameters.AddWithValue("@TARIH", Convert.ToDateTime(TARIH));
                object x = com.ExecuteScalar();
                Log.I_LOG("I_TARIHTE_NEOLMUS tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_IHBARLOG", ref durum);

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
        public static void I_KISISEL_BILGI(string SS_ID, string AD, string SOYAD, string EV_TELEFONU, string IS_TELEFONU, string CEP_TELEFONU, string RUTBE, string GOREVI, string TELSIZ_ADI, int VARDIYA, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_USERS (USR_ADI,USR_SOYADI,USR_TELEFON_EV,USR_TELEFON_IS,USR_TELEFON_GSM,USR_RUTBE,USR_GOREV,USR_TELSIZKANAL,USR_VARDIYA) values(@USR_ADI,@USR_SOYADI,@USR_TELEFON_EV,@USR_TELEFON_IS,@USR_TELEFON_GSM,@USR_RUTBE,@USR_GOREV,@USR_TELSIZKANAL,@USR_VARDIYA);select IDENT_CURRENT('I_KISISEL_BILGILER') ;", con);
                com.Parameters.AddWithValue("@USR_ADI", AD);
                com.Parameters.AddWithValue("@USR_SOYADI", SOYAD);
                com.Parameters.AddWithValue("@USR_TELEFON_EV", EV_TELEFONU);
                com.Parameters.AddWithValue("@USR_TELEFON_IS", IS_TELEFONU);
                com.Parameters.AddWithValue("@USR_TELEFON_GSM", CEP_TELEFONU);
                com.Parameters.AddWithValue("@USR_RUTBE", RUTBE);
                com.Parameters.AddWithValue("@USR_GOREV", GOREVI);
                com.Parameters.AddWithValue("@USR_TELSIZKANAL", TELSIZ_ADI);
                com.Parameters.AddWithValue("@USR_VARDIYA", VARDIYA);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_KISISEL_BILGILER tablosuna " + x.ToString() + " numaralı satır eklendi.", "I_KULLANICILOG", ref durum);

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
     
       //////////14.03.2018////////////////////
        public static void I_MARKER_KISAYOL(string MRK_ADI, double MRK_LAT, double MRK_LONG, string MRK_ICON, string MAR_GRUP, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_MARKER_KISAYOL(MRK_ADI,MRK_LAT,MRK_LONG,MRK_ICON,MAR_GRUP) values(@MRK_ADI,@MRK_LAT,@MRK_LONG,@MRK_ICON,@MAR_GRUP)", con);
                com.Parameters.AddWithValue("@MRK_ADI", MRK_ADI);
                com.Parameters.AddWithValue("@MRK_LAT", MRK_LAT);
                com.Parameters.AddWithValue("@MRK_LONG", MRK_LONG);
                com.Parameters.AddWithValue("@MRK_ICON", MRK_ICON);
                com.Parameters.AddWithValue("@MAR_GRUP", MAR_GRUP);
                object x = com.ExecuteScalar();
                Log.I_LOG("I_MARKER_KISAYOL tablosuna " + MRK_ADI + " isimli marker eklendi eklendi.", "I_MARKER_KISAYOL", ref durum);
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
        public static void I_KAMERA_KAYDET(string KMRADI, double LAT, double LON, string KMRTIP, int ILID, string ILCEID, int MAHID, int CADDEID, string ADRES, string NOT,string KMRSOKAK, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_KAMERA_LOKASYON(KMRADI,KMRLAT,KMRLON,KMRTIPI,KMRILID,KMRILCEID,KMRMAHID,KMRCADDEID,KMRADRES,KMRNOT,KMREKLENMETARIH,KMRGEO,KMRSOKAK) values (@KMRADI,@KMRLAT,@KMRLON,@KMRTIPI,@KMRILID,@KMRILCEID,@KMRMAHID,@KMRCADDEID,@KMRADRES,@KMRNOT,@KMREKLENMETARIH,geography::STPointFromText('POINT(' + Convert(Varchar,@KMRLON) + ' ' + Convert(Varchar,@KMRLAT) + ')', 4326),@KMRSOKAK);", con);
                com.Parameters.AddWithValue("@KMRADI", KMRADI);
                com.Parameters.AddWithValue("@KMRLAT", LAT);
                com.Parameters.AddWithValue("@KMRLON", LON);
                com.Parameters.AddWithValue("@KMRTIPI", KMRTIP);
                com.Parameters.AddWithValue("@KMRILID", ILID);
                com.Parameters.AddWithValue("@KMRILCEID", ILCEID);
                com.Parameters.AddWithValue("@KMRMAHID", MAHID);
                com.Parameters.AddWithValue("@KMRCADDEID", CADDEID);
                com.Parameters.AddWithValue("@KMRADRES", ADRES);
                com.Parameters.AddWithValue("@KMRNOT", NOT);
                com.Parameters.AddWithValue("@KMRSOKAK", KMRSOKAK);
                com.Parameters.AddWithValue("@KMREKLENMETARIH", DateTime.Now);
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
        public static void I_KISAYOLGRUP(string MKYG_ADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("insert I_KISAYOLGRUP(MKYG_ADI,MKYG_KULLANICI) values (@MKYG_ADI,@MKYG_KULLANICI);", con);
                com.Parameters.AddWithValue("@MKYG_ADI", MKYG_ADI);
                com.Parameters.AddWithValue("@MKYG_KULLANICI", MK_HelperDataLib.StatikData.USR_SICILNO);
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
    }
}
