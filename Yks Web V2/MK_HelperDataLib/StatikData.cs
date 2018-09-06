using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MK_HelperDataLib
{
    public class StatikData
    {
        public static string USR_SICILNO = HttpContext.Current.Session["USR_SICILNO"].ToString();
        public static string SS_ID = HttpContext.Current.Session["SS_ID"].ToString();
        public static string SS_ISIM = HttpContext.Current.Session["SS_ISIM"].ToString();
        public static string SS_SOYADI = HttpContext.Current.Session["SS_SOYADI"].ToString();
        public static string SS_GRUPUSERS = HttpContext.Current.Session["SS_GRUPUSERS"].ToString();
        public static string SS_GRUPADI = HttpContext.Current.Session["SS_GRUPADI"].ToString();
        public static string SS_YETKIID = HttpContext.Current.Session["SS_YETKIID"].ToString();
        public static string SS_YETKIADI = HttpContext.Current.Session["SS_YETKIADI"].ToString();
        public static string SS_USR_SONGIRIS = HttpContext.Current.Session["SS_USR_SONGIRIS"].ToString();
        public static string SS_KANAL = HttpContext.Current.Session["SS_KANAL"].ToString();
        public static string SS_GRUP = HttpContext.Current.Session["SS_GRUP"].ToString();
        public static string SS_KANAL_ADI = HttpContext.Current.Session["SS_KANAL_ADI"].ToString();
        public static string SS_KNL_YETKI = HttpContext.Current.Session["SS_KNL_YETKI"].ToString();
        public static string SS_ILCE = HttpContext.Current.Session["SS_ILCE"].ToString();
        public static string SS_EKIPKODU = HttpContext.Current.Session["SS_EKIPKODU"].ToString();
        public static string SS_MODULID = HttpContext.Current.Session["SS_MODULID"].ToString();
        public static string SS_SUBMODULID = HttpContext.Current.Session["SS_SUBMODULID"].ToString();

        public static string SS_DATEMODE = "yyyy-MM-dd";
        public static string SS_VERSIYON = "v9.5.0.0 R24";
        public static string SS_IP = HttpContext.Current.Session["SS_IP"].ToString();
        public static string SS_SIFRE = HttpContext.Current.Session["SS_SIFRE"].ToString();
        public static string SS_MACADDRESS = HttpContext.Current.Session["SS_MACADDRESS"].ToString();
        public static string SS_KULLANICIADI = HttpContext.Current.Session["SS_KULLANICIADI"].ToString();
        public static string SS_DIGERKANAL = HttpContext.Current.Session["SS_DIGERKANAL"].ToString();
        public static string SS_GIRISTARIH = HttpContext.Current.Session["SS_GIRISTARIH"].ToString();
        public static bool SS_KNLSEC = Convert.ToBoolean(HttpContext.Current.Session["SS_KNLSEC"]);
        public static string SS_IHBARLISTESI_COUNT = HttpContext.Current.Session["SS_IHBARLISTESI_COUNT"].ToString();
        public static string SS_KAPALIIHBARLISTESI_COUNT = HttpContext.Current.Session["SS_KAPALIIHBARLISTESI_COUNT"].ToString();
        public static string KANALISLEM(string KANAL)
        {
            string SONUC = "";
            string[] arg = KANAL.Split(',');
            if (arg.Length > 1)
            {
                for (int i = 0; i < arg.Length; i++)
                {
                    if (SONUC == "")
                    {
                        SONUC = "'" + arg[i].ToString() + "'";
                    }
                    else
                    {
                        SONUC += ",'" + arg[i].ToString() + "'";
                    }
                }
            }
            else
            {
                SONUC = "'" + arg[0].ToString() + "'";
            }

            return SONUC;
        }

    }

}
