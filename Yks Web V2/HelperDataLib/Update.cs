﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web;

namespace HelperDataLib
{
    public class Update
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



        public static bool U_KULLANICI(string USR_ID, string USR_SICILNO, string USR_ADI, string USR_SOYADI, string USR_KULLANICIADI, string USR_SIFRE, string USR_YETKIKODU, string USR_GRUPKODU, string USR_KANALYETKI, string USR_ONAYYETKI, string USR_TELEFON_EV, string USR_TELEFON_IS, string USR_TELEFON_GSM, string USR_RUTBE, string USR_GOREV, string USR_TELSIZKANAL, string USR_VARDIYA, string USR_DAHILI, string USR_IL, string USR_ILCE, string USR_SUBE, bool USR_DURUM,string USR_EKIPKODU,bool USR_KNLSEC)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_USERS  set USR_SICILNO=@USR_SICILNO,USR_ADI=@USR_ADI,USR_SOYADI=@USR_SOYADI,USR_KULLANICIADI=@USR_KULLANICIADI,USR_SIFRE=@USR_SIFRE,USR_YETKIKODU=@USR_YETKIKODU,USR_GRUPKODU=@USR_GRUPKODU,USR_KANALYETKI=@USR_KANALYETKI,USR_ONAYYETKI=@USR_ONAYYETKI,USR_TELEFON_EV=@USR_TELEFON_EV,USR_TELEFON_IS=@USR_TELEFON_IS,USR_TELEFON_GSM=@USR_TELEFON_GSM,USR_RUTBE=@USR_RUTBE,USR_GOREV=@USR_GOREV,USR_TELSIZKANAL=@USR_TELSIZKANAL,USR_VARDIYA=@USR_VARDIYA,USR_DAHILI=@USR_DAHILI,USR_IL=@USR_IL,USR_ILCE=@USR_ILCE,USR_SUBE=@USR_SUBE,USR_DURUM=@USR_DURUM,USR_EKIPKODU=@USR_EKIPKODU,USR_KNLSEC=@USR_KNLSEC where USR_ID=@USR_ID", con);
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
                com.Parameters.AddWithValue("@USR_EKIPKODU",USR_EKIPKODU);
                com.Parameters.AddWithValue("@USR_DURUM",USR_KNLSEC);
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
                com.Parameters.AddWithValue("@USR_SONGIRIS", DateTime.Now);
                com.Parameters.AddWithValue("@USR_ID", USR_ID);
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
        public static bool U_IHBAR(string ID, string TELEFON, string ISIMSOYISIM, string IL, string ILCE, string KANAL, string MAHALLE, string CADDE, string SITE, string BINA, string DAIRE, string PLAKA, string ADRES, string LAT, string LONG, string IHBARBILGI, string USTOLAYKODU, string ALTOLAYKODU, string OPERATORNOT, string CINSIYET, int YAS, string MAIL, string DIGERBILGI, string DURUM, bool I_ONCELIKLI)
        {
            bool durum = false;
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_TELEFON=@I_TELEFON,I_ISIMSOYISIM=@I_ISIMSOYISIM,I_IL=@I_IL,I_ILCE=@I_ILCE,I_KANAL=@I_KANAL,I_MAHALLE=@I_MAHALLE,I_CADDE=@I_CADDE,I_SITE=@I_SITE,I_BINA=@I_BINA,I_DAIRE=@I_DAIRE,I_PLAKA=@I_PLAKA,I_ADRES=@I_ADRES,I_LATITUDE=@I_LATITUDE,I_LONGITUDE=@I_LONGITUDE,I_IHBARBILGISI=@I_IHBARBILGISI,I_USTOLAYKODU=@I_USTOLAYKODU,I_ALTOLAYKODU=@I_ALTOLAYKODU,I_OPERATORNOT=@I_OPERATORNOT,I_CINSIYET=@I_CINSIYET,I_YAS=@I_YAS,I_MAIL=@I_MAIL,I_DIGERBILGI=@I_DIGERBILGI,I_DURUM=@I_DURUM,I_ONCELIKLI=@I_ONCELIKLI WHERE  I_ID=@I_ID", con);
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
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_KANAL=@I_KANAL,I_AKTIF=@I_AKTIF WHERE ID_IHID=@ID and I_KANAL=@I_KANAL", con);
                com.Parameters.AddWithValue("@ID", IH_ID);
                com.Parameters.AddWithValue("@I_KANAL", IH_KANAL);
                com.Parameters.AddWithValue("@I_AKTIF", I_AKTIF);
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
        public static void U_KANAL_GUNCELLE(string ID, string I_KANAL2, string I_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_KANAL=@I_KANAL WHERE ID_IHID=@I_ID and I_KANAL=@I_KANAL2", con);
                com.Parameters.AddWithValue("@I_KANAL", I_KANAL);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_KANAL2", I_KANAL2);
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
        public static void U_KANAL_GUNCELLE_ILCE(string ID, string I_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_ILCEKANAL=@I_ILCEKANAL WHERE I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_ILCEKANAL", I_KANAL);
                com.Parameters.AddWithValue("@I_ID", ID);
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
        public static void U_EKIP_YONLENDIR(string ID, string ILCEKANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAR SET I_IHBARDURUM=@I_IHBARDURUM,I_ILCEKANAL=@I_ILCEKANAL WHERE I_ID=@I_ID", con);
                com.Parameters.AddWithValue("@I_IHBARDURUM", false);
                com.Parameters.AddWithValue("@I_ID", ID);
                com.Parameters.AddWithValue("@I_ILCEKANAL", ILCEKANAL);
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
        public static void U_IHBAR_KAPAT(string ID, string Kanal, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_DURUM=@I_DURUM WHERE ID_IHID=@ID_IHID AND I_KANAL=@I_KANAL", con);
                com.Parameters.AddWithValue("@ID_IHID", ID);
                com.Parameters.AddWithValue("@I_KANAL", Kanal);
                com.Parameters.AddWithValue("@I_DURUM", false);
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
        public static void U_IHBAR_EKIP_YONLENDIR(string ID, string Kanal, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBARDETAY SET I_EKIP=@I_EKIP WHERE ID_IHID=@ID_IHID AND I_KANAL=@I_KANAL", con);
                com.Parameters.AddWithValue("@ID_IHID", ID);
                com.Parameters.AddWithValue("@I_KANAL", Kanal);
                com.Parameters.AddWithValue("@I_EKIP", true);
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
        public static void U_IHBAR_EKIP_YONLENDIR_U(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_ULASMATARIH=@EG_ULASMATARIH WHERE EG_ID=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_ULASMATARIH", DateTime.Now);
                com.Parameters.AddWithValue("@EG_ID", ID);
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
        public static void U_IHBAR_EKIP_YONLENDIR_S(string ID, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_IHBAREKIP SET EG_SONTARIH=@EG_SONTARIH WHERE EG_ID=@EG_ID", con);
                com.Parameters.AddWithValue("@EG_SONTARIH", DateTime.Now);
                com.Parameters.AddWithValue("@EG_ID", ID);
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
                com.Parameters.AddWithValue("@I_TARIH", DateTime.Now);
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
        public static void U_USTOLAY(string ID, string U_IHBAR, bool U_DURUM, bool U_ONCELIK, bool U_MAIL,string U_KANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_USTOLAY set U_IHBAR=@U_IHBAR,U_DURUM=@U_DURUM,U_ONCELIK=@U_ONCELIK,U_MAIL=@U_MAIL,U_KANAL=@U_KANAL where U_ID=@U_ID", con);
                com.Parameters.AddWithValue("@U_ID", ID);
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
        public static void U_ILCE(string ILCEID, string ILID, string AD,string LONG, string LAT, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_ILCE set ILCEID=@ILCEID,ILID=@ILID,AD=@AD,LONG=@LONG,LAT=@LAT where ILCEID=@ILCEID", con);
                com.Parameters.AddWithValue("@ILCEID", ILCEID);
                com.Parameters.AddWithValue("@ILID", ILID);
                com.Parameters.AddWithValue("@AD", AD);
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
        public static void U_MAHALLE(string I_MAHID, string I_ILCEID, string I_AD,string I_LAT,string I_LONG, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update U_MAHALLE set I_AD=@I_AD,I_ILCEID=@I_ILCEID,I_LAT=@I_LAT,I_LONG=@I_LONG where I_MAHID=@I_MAHID", con);
                com.Parameters.AddWithValue("@I_AD", I_AD);
                com.Parameters.AddWithValue("@I_ILCEID", I_ILCEID);
                com.Parameters.AddWithValue("@I_MAHID", I_MAHID);
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
        public static void U_CADDE(string I_MAHID,string EskiMahID, string I_ILCEID, string CADDEAD, string eskiCADDEAD, string I_LAT, string I_LONG, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_CADDE set I_SID=@I_SID,I_ILCEID=@I_ILCEID,I_AD=@I_AD,I_LAT=@I_LAT,I_LONG=@I_LONG where I_SID=@I_ESID AND I_AD=@I_EAD", con);
                com.Parameters.AddWithValue("@I_SID", I_MAHID);
                com.Parameters.AddWithValue("@I_ILCEID", I_ILCEID);
                com.Parameters.AddWithValue("@I_AD", CADDEAD);
                com.Parameters.AddWithValue("@I_ESID", EskiMahID);
                com.Parameters.AddWithValue("@I_EAD", eskiCADDEAD);
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
      
        public static void U_ALTOLAY(string A_ID, string A_UID,string A_KANAL,string A_IHBAR, bool A_ONCELIK, bool A_ACIL, bool A_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_ALTOLAY set A_UID=@A_UID,A_IHBAR=@A_IHBAR,A_ONCELIK=@A_ONCELIK,A_ACIL=@A_ACIL,A_DURUM=@A_DURUM,A_KANAL=@A_KANAL where A_ID=@A_ID", con);
                com.Parameters.AddWithValue("@A_ID", A_ID);
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

        public static void U_LOGMESAJ(string ID, string LOGMESAJ, int LOGTIP, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_LOGMESAJ set LOGMESAJ=@LOGMESAJ,LOGTIP=@LOGTIP where ID=@ID", con);
                com.Parameters.AddWithValue("@ID", ID);
                com.Parameters.AddWithValue("@LOGMESAJ", LOGMESAJ);
                com.Parameters.AddWithValue("@LOGTIP", LOGTIP);
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
        public static void U_KANAL(string ID, string KANAL_KODU, bool KANALDURUM, string KANALADI, int KANALTRAFIK, string KANALYETKI, string KNL_ILCE, string KNL_DIGERKANAL, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_KANAL set KNL_DURUM=@KNL_DURUM,KNL_KODU=@KNL_KODU,KN_ADI=@KN_ADI,KNL_TRAFIK=@KNL_TRAFIK,KNL_YETKI=@KNL_YETKI,KNL_ILCE=@KNL_ILCE,KNL_DIGERKANAL=@KNL_DIGERKANAL where KNL_ID=@KNL_ID", con);
                com.Parameters.AddWithValue("@KNL_DURUM", KANALDURUM);
                com.Parameters.AddWithValue("@KNL_KODU", KANAL_KODU);
                com.Parameters.AddWithValue("@KN_ADI", KANALADI);
                com.Parameters.AddWithValue("@KNL_TRAFIK", KANALTRAFIK);
                com.Parameters.AddWithValue("@KNL_YETKI", KANALYETKI);
                com.Parameters.AddWithValue("@KNL_ILCE", KNL_ILCE);
                com.Parameters.AddWithValue("@KNL_ID", ID);
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
        public static void U_ISLEMSONUC(string ID, string IS_ADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_ISLEMSONUC set IS_ADI=@IS_ADI where IS_ID=@ID", con);
                com.Parameters.AddWithValue("@IS_ADI", IS_ADI);
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
        public static void U_SUBE(string SB_ID, string SB_KODU, string SB_ADI, string SB_IL, string SB_ILCE, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE  I_SUBE SET  SB_KODU=@SB_KODU,SB_ADI=@SB_ADI,SB_IL=@SB_IL,SB_ILCE=@SB_ILCE WHERE SB_ID=@SB_ID", con);
                com.Parameters.AddWithValue("@SB_KODU", SB_KODU);
                com.Parameters.AddWithValue("@SB_ADI", SB_ADI);
                com.Parameters.AddWithValue("@SB_IL", SB_IL);
                com.Parameters.AddWithValue("@SB_ILCE", SB_ILCE);
                com.Parameters.AddWithValue("@SB_ID", SB_ID);
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
        public static void U_EKIP(string EK_ID, string EK_KODU, string EK_ILCE, string EK_LAT, string EK_LONG, bool EK_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update  I_EKIP set EK_KODU=@EK_KODU,EK_ILCE=@EK_ILCE,EK_LAT=@EK_LAT,EK_LONG=@EK_LONG,EK_DURUM=@EK_DURUM  where EK_ID=@EK_ID", con);
                com.Parameters.AddWithValue("@EK_KODU", EK_KODU);
                com.Parameters.AddWithValue("@EK_ILCE", EK_ILCE);
                com.Parameters.AddWithValue("@EK_LAT", EK_LAT);
                com.Parameters.AddWithValue("@EK_LONG", EK_LONG);
                com.Parameters.AddWithValue("@EK_DURUM", EK_DURUM);
                com.Parameters.AddWithValue("@EK_ID", EK_ID);
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
        public static void U_KARALISTE(string KR_ID, string KR_TELEFON, DateTime KR_BASLAMA, DateTime KR_BITIS, string KR_EKLEYEN, string KR_NEDEN, bool KR_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_KARALISTE SET  KR_TELEFON=@KR_TELEFON,KR_BASLAMA=@KR_BASLAMA,KR_BITIS=@KR_BITIS,KR_EKLEYEN=@KR_EKLEYEN,KR_NEDEN=@KR_NEDEN,KR_DURUM=@KR_DURUM WHERE KR_ID=@KR_ID", con);
                com.Parameters.AddWithValue("@KR_TELEFON", KR_TELEFON);
                com.Parameters.AddWithValue("@KR_BASLAMA", KR_BASLAMA);
                com.Parameters.AddWithValue("@KR_BITIS", KR_BITIS);
                com.Parameters.AddWithValue("@KR_EKLEYEN", KR_EKLEYEN);
                com.Parameters.AddWithValue("@KR_NEDEN", KR_NEDEN);
                com.Parameters.AddWithValue("@KR_DURUM", KR_DURUM);
                com.Parameters.AddWithValue("@KR_ID", KR_ID);
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
        public static void U_KARAKOL(string KRK_ID, string KRK_ISIM, string KRK_TELEFON1, string KRK_TELEFON2, string KRK_TELSIZKODU, string KRK_AMIRAD, string KRK_AMIRSOYAD, string KRK_AMIRTELEFON, string KRK_AMIRTELSIZ, string KRK_IL, string KRK_ILCE, string KRK_MAHALLE, string KRK_LAT, string KRK_LONG, string KRK_ADRES, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_KARAKOL set KRK_ISIM=@KRK_ISIM,KRK_TELEFON1=@KRK_TELEFON1,KRK_TELEFON2=@KRK_TELEFON2,KRK_TELSIZKODU=@KRK_TELSIZKODU,KRK_AMIRAD=@KRK_AMIRAD,KRK_AMIRSOYAD=@KRK_AMIRSOYAD,KRK_AMIRTELEFON=@KRK_AMIRTELEFON,KRK_AMIRTELSIZ=@KRK_AMIRTELSIZ,KRK_IL=@KRK_IL,KRK_ILCE=@KRK_ILCE,KRK_MAHALLE=@KRK_MAHALLE,KRK_LAT=@KRK_LAT,KRK_LONG=@KRK_LONG,KRK_ADRES=@KRK_ADRES where KRK_ID=@KRK_ID", con);
                com.Parameters.AddWithValue("@KRK_ID", KRK_ID);
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
            catch
            {
                con.Close();
                durum = false;
                return;
            }

        }
        public static void U_ISLEMSONUC(string IS_ID,string IS_ADI, string IS_TIP,string IS_KISAYOLTUS, bool IS_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("UPDATE I_ISLEMSONUC SET IS_ADI=@IS_ADI,IS_TIP=@IS_TIP,IS_KISAYOLTUS=@IS_KISAYOLTUS,IS_DURUM=@IS_DURUM WHERE IS_ID=@IS_ID", con);
                com.Parameters.AddWithValue("@IS_ADI", IS_ADI);
                com.Parameters.AddWithValue("@IS_TIP", IS_TIP);
                com.Parameters.AddWithValue("@IS_KISAYOLTUS", IS_KISAYOLTUS);
                com.Parameters.AddWithValue("@IS_DURUM", IS_DURUM);
                com.Parameters.AddWithValue("@IS_ID", IS_ID);
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
        public static void U_KANALGRUP(string KG_ID, string KG_GRUPADI, string KG_KANAL, bool KG_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_KANALGRUP set KG_GRUPADI=@KG_GRUPADI,KG_KANAL=@KG_KANAL,KG_DURUM=@KG_DURUM where KG_ID=@KG_ID", con);
                com.Parameters.AddWithValue("@KG_GRUPADI", KG_GRUPADI);
                com.Parameters.AddWithValue("@KG_KANAL", KG_KANAL);
                com.Parameters.AddWithValue("@KG_DURUM", KG_DURUM);
                com.Parameters.AddWithValue("@KG_ID", KG_ID);
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

        public static void U_GUVENLIKSIRKET(int G_ID, string G_SIRKETADI, string G_ILCE, string G_MAHALLE, string G_ADRES, string G_KULLANICIADI, string G_SIFRE, string G_IRTIBATISMI, string G_IRTIBATTELEFON, string G_TELEFONDIGER, string G_TELEFONDIGER2, string G_GSM, string G_FAX, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_GUVENLIKSIRKET set G_SIRKETADI=@G_SIRKETADI,G_ILCE=@G_ILCE,G_MAHALLE=@G_MAHALLE,G_ADRES=@G_ADRES,G_KULLANICIADI=@G_KULLANICIADI,G_SIFRE=@G_SIFRE,G_IRTIBATISMI=@G_IRTIBATISMI,G_IRTIBATTELEFON=@G_IRTIBATTELEFON,G_TELEFONDIGER=@G_TELEFONDIGER,G_TELEFONDIGER2=@G_TELEFONDIGER2,G_GSM=@G_GSM,G_FAX=@G_FAX where G_ID=@G_ID", con);
                com.Parameters.AddWithValue("@G_ID", G_ID);
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

        public static void U_GUVENLIKMUSTERI(int GM_ID, string GM_GID, string GM_MUSTERIISIM, DateTime GM_GIRISTARIH, DateTime GM_CIKISTARIH, string GM_CALISMAGRUP, string GM_TELEFON, string GM_SAHIBI, string GM_GSM, string GM_ILCE, string GM_MAHALLE, string GM_SOKAK, string GM_SITE, string GM_BINA, string GM_BINANO, string GM_DAIRENO, string GM_ADRES, int GM_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_GUVENLIKMUSTERI set GM_GID=@GM_GID,GM_MUSTERIISIM=@GM_MUSTERIISIM,GM_GIRISTARIH=@GM_GIRISTARIH,GM_CIKISTARIH=@GM_CIKISTARIH,GM_CALISMAGRUP=@GM_CALISMAGRUP,GM_TELEFON=@GM_TELEFON,GM_SAHIBI=@GM_SAHIBI,GM_GSM=@GM_GSM,GM_ILCE=@GM_ILCE,GM_MAHALLE=@GM_MAHALLE,GM_SOKAK=@GM_SOKAK,GM_SITE=@GM_SITE,GM_BINA=@GM_BINA,GM_BINANO=@GM_BINANO,GM_DAIRENO=@GM_DAIRENO,GM_ADRES=@GM_ADRES, GM_DURUM=@DURUM where GM_ID=@GM_ID ", con);
                com.Parameters.AddWithValue("@GM_ID", GM_ID);
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
                com.Parameters.AddWithValue("@DURUM", GM_DURUM);
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


        public static void U_ARACTIPI(int AT_ID, string AT_ADI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_ARACTIPI set AT_ADI = @AT_ADI where AT_ID = @AT_ID", con);
                com.Parameters.AddWithValue("@AT_ID", AT_ID);
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

        public static void U_ALARM(int A_ID, string A_ADI, int A_ALTOLAYID, bool A_DURUM, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_ALARM set A_ADI = @A_ADI,A_ALTOLAYID = @A_ALTOLAYID,A_DURUM = @A_DURUM where A_ID = @A_ID ", con);
                com.Parameters.AddWithValue("@A_ID", A_ID);
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

        public static void U_MARKA(int O_ID, string O_MARKASI, ref bool durum)
        {
            SqlConnection con = new SqlConnection();
            try
            {

                Connection.OpenConnection(ref con);
                SqlCommand com = new SqlCommand("update I_MARKA set O_MARKASI = @O_MARKASI where O_ID = @O_ID", con);
                com.Parameters.AddWithValue("@O_ID", O_ID);
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
      
    

