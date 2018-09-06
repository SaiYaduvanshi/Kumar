using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace EgmYKS.Ucntrl
{
    public partial class Ucntrl_YeniKullanici : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               try
               {
                      if (!Page.IsPostBack)
                      {

                             if (!Page.IsPostBack)
                             {
                                    if (Request.QueryString["id"] != null && Request.QueryString["new"] == "False")
                                    {
                                           Session["kullanicisession"] = HelperDataLib.Encrypt.UrlDecrypt(Request.QueryString["id"].ToString());
                                           DETAY(HelperDataLib.Encrypt.UrlDecrypt(Request.QueryString["id"].ToString()));
                                    }
                                    if (Request.QueryString["new"] == "True")
                                    {
                                           Session["kullanicisession"] = null;
                                    }
                                    YETKIKONTROL();
                                    HttpContext.Current.Cache["CacheDataTableYetki"] = HelperDataLib.Select.S_YETKI_YUKLE();
                                    HttpContext.Current.Cache["CacheDataTableGrup"] = HelperDataLib.Select.S_GRUP_LISTESI();
                                    ILYUKLE();
                                    KANAL();
                             }
                      }
                      YETKIYUKLE();
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void KANAL()
        {

            try
            {
                t_kanalyetki.DataSource = HelperDataLib.Select.S_KANAL_TUM();
                t_kanalyetki.DataBind();
            }
            catch (Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void ILYUKLE()
        {
               try
               {
                      t_il.DataSource = HelperDataLib.Select.S_IL();
                      t_il.TextField = "AD";
                      t_il.ValueField = "ILID";
                      t_il.DataBind();
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void ILCEYUKLE()
        {
               try
               {
                      t_ilce.DataSource = HelperDataLib.Select.S_ILCE(t_il.Value.ToString());
                      t_ilce.TextField = "AD";
                      t_ilce.ValueField = "ILCEID";
                      t_ilce.DataBind();
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void SUBEYUKLE()
        {
               try
               {
                      t_sube.DataSource = HelperDataLib.Select.S_SUBE(t_il.Value.ToString(), t_ilce.Value.ToString());
                      t_sube.TextField = "SB_ADI";
                      t_sube.ValueField = "SB_KODU";
                      t_sube.DataBind();
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void DETAY(string id)
        {
               try
               {
                      string USR_SICILNO = ""; string USR_ADI = ""; string USR_SOYADI = ""; string USR_KULLANICIADI = ""; string USR_SIFRE = ""; string USR_YETKIKODU = ""; string USR_GRUPKODU = ""; string USR_KANALYETKI = ""; string USR_ONAYYETKI = ""; string USR_TELEFON_EV = ""; string USR_TELEFON_IS = ""; string USR_TELEFON_GSM = ""; string USR_RUTBE = ""; string USR_GOREV = ""; string USR_TELSIZKANAL = ""; string USR_VARDIYA = ""; string USR_DAHILI = ""; string USR_IL = ""; string USR_ILCE = ""; string USR_SUBE = ""; bool USR_DURUM = false; string YETKIADI = ""; string GRUPADI = ""; bool KNL_SECIM = false;
                      HelperDataLib.Select.S_USERS_GETDETAY(id, ref USR_SICILNO, ref USR_ADI, ref USR_SOYADI, ref USR_KULLANICIADI, ref USR_SIFRE, ref USR_YETKIKODU, ref USR_GRUPKODU, ref USR_KANALYETKI, ref USR_ONAYYETKI, ref USR_TELEFON_EV, ref USR_TELEFON_IS, ref USR_TELEFON_GSM, ref USR_RUTBE, ref USR_GOREV, ref USR_TELSIZKANAL, ref USR_VARDIYA, ref USR_DAHILI, ref USR_IL, ref USR_ILCE, ref USR_SUBE, ref USR_DURUM, ref YETKIADI, ref GRUPADI,ref KNL_SECIM);

                      t_sicil.Text = USR_SICILNO;
                      t_ceptelefon.Text = USR_TELEFON_GSM;
                      t_dahili.Text = USR_DAHILI;
                      t_evtelefon.Text = USR_TELEFON_EV;
                      t_gorev.Text = USR_GOREV;
                     
                      t_il.Text = USR_IL;
                      t_ilce.Value = USR_ILCE;
                      t_isim.Text = USR_ADI;
                      t_istelefon.Text = USR_TELEFON_IS;
                      t_kanalyetki.Text = USR_KANALYETKI;
                      t_kullanici.Text = USR_KULLANICIADI;
                      t_rutbe.Text = USR_RUTBE;
                      t_sifre.Text = USR_SIFRE;
                      t_soyisim.Text = USR_SOYADI;
                      t_sube.Value = USR_SUBE;
                      t_telsizkanal.Text = USR_TELSIZKANAL;
                      t_vardiya.Text = USR_VARDIYA;
                      t_yetki.Text = YETKIADI;
                      t_grup.Text = GRUPADI;
                      Session["yetkiid"] = USR_YETKIKODU;
                      Session["grupid"] = USR_GRUPKODU;
                      aktifpasif.Checked = USR_DURUM;
                      chckkanalsecim.Checked = KNL_SECIM;
                      ILYUKLE();
                      ILCEYUKLE();
                      SUBEYUKLE();
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void MESAJKAPAT()
        {
            succes.Visible = false;
            error.Visible = false;
            Warning.Visible = false;
        }
        void YETKIKONTROL()
        {
               try
               {
                      bool OKU = false; bool YAZ = false; bool SIL = false; string USERS = ""; bool EKSTRA = false;
                      HelperDataLib.Select.S_YETKI_GETVALUES("103", ref OKU, ref YAZ, ref SIL, ref EKSTRA, ref USERS);
                      if (YAZ == true)
                      {

                             ASPxButton1.Enabled = true;
                             ASPxButton3.Enabled = true;
                             ASPxButton4.Enabled = true;
                      }
                      if (OKU == false)
                      {
                             Response.Redirect("~/Default.aspx");
                      }
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }

        }
     
        void YETKIYUKLE()
        {
               try
               {
                      ASPxGridView2.DataSource = HttpContext.Current.Cache["CacheDataTableYetki"];
                      ASPxGridView2.DataBind();
                      ASPxGridView3.DataSource = HttpContext.Current.Cache["CacheDataTableGrup"];
                      ASPxGridView3.DataBind();
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void TEMIZLE()
        {
            Session["yetkiid"] = null;
            Session["grupid"] = null;
            aktifpasif.Checked = false;
            chckkanalsecim.Checked = false;
            Session["kullanicisession"] = null;
            t_sicil.Text = "";
            t_ceptelefon.Text = "";
            t_dahili.Text = "";
            t_evtelefon.Text = "";
            t_gorev.Text = "";
            t_il.Text = "";
            t_ilce.Text = "";
            t_isim.Text = "";
            t_istelefon.Text = "";
            t_kullanici.Text = "";
            t_rutbe.Text = "";
            t_sicil.Text = "";
            t_sifre.Text = "";
            t_soyisim.Text = "";
            t_sube.Text = "";
            t_telsizkanal.Text = "";
            t_vardiya.Text = "";
            t_yetki.Text = "";
            t_grup.Text = "";
        }
        void KAYIT(ref bool durum)
        {
            try
            {
                MESAJKAPAT();
                //kayıt
                if (Session["kullanicisession"] == null)
                {
                    if (t_sicil.Text != "" && t_isim.Text != "" && t_soyisim.Text != "" && t_kullanici.Text != "" && t_sifre.Text != "" && t_yetki.Text != "")
                    {

                        durum = HelperDataLib.Insert.I_KULLANICI(t_sicil.Text, t_isim.Text, t_soyisim.Text, t_kullanici.Text, t_sifre.Text, Session["yetkiid"].ToString(), Session["grupid"].ToString(), t_kanalyetki.Text, "0", HelperDataLib.Select.convertphoneformat(t_evtelefon.Text), HelperDataLib.Select.convertphoneformat(t_istelefon.Text), HelperDataLib.Select.convertphoneformat(t_ceptelefon.Text), t_rutbe.Text, t_gorev.Text, t_telsizkanal.Text, t_vardiya.Text, t_dahili.Text, t_il.SelectedItem.Value.ToString(), t_ilce.SelectedItem.Value.ToString(), t_sube.SelectedItem.Value.ToString(), aktifpasif.Checked,"",chckkanalsecim.Checked);
                        if (durum == false)
                        {

                            error.Visible = true;


                        }
                    }
                    else
                    {
                        Warning.Visible = true;
                    }
                }
                else
                {
                    if (t_sicil.Text != "" && t_isim.Text != "" && t_soyisim.Text != "" && t_kullanici.Text != "" && t_sifre.Text != "" && t_yetki.Text != "")
                    {

                        durum = HelperDataLib.Update.U_KULLANICI(Session["kullanicisession"].ToString(), t_sicil.Text, t_isim.Text, t_soyisim.Text, t_kullanici.Text, t_sifre.Text, Session["yetkiid"].ToString(), Session["grupid"].ToString(), t_kanalyetki.Text, "0", t_evtelefon.Text, t_istelefon.Text, t_ceptelefon.Text, t_rutbe.Text, t_gorev.Text, t_telsizkanal.Text, t_vardiya.Text, t_dahili.Text, t_il.SelectedItem.Value.ToString(), t_ilce.SelectedItem.Value.ToString(), t_sube.SelectedItem.Value.ToString(), aktifpasif.Checked,"",chckkanalsecim.Checked);
                        if (durum == false)
                        {

                            error.Visible = true;


                        }
                    }
                    else
                    {
                        Warning.Visible = true;
                    }
                }
            }
            catch (Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }

    }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            //yeni
            TEMIZLE();
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            //kaydet
            bool durum = false;
            KAYIT(ref durum);
            if (durum == true)
            {
                TEMIZLE();
                succes.Visible = true;
            }
        }
        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            //vazgeç
            TEMIZLE();
            Response.Redirect("~/KullaniciListesi.aspx");
        }
        protected void ImageButton2_Command(object sender, CommandEventArgs e)
        {
               try
               {
                      string doc = e.CommandArgument.ToString();
                      string[] arg = new string[2];
                      arg = doc.ToString().Split(';');
                      Session["grupid"] = arg[0];
                      t_grup.Text = arg[1];
                      ASPxPopupControl3.ShowOnPageLoad = false;
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
               try
               {
                      string doc = e.CommandArgument.ToString();
                      string[] arg = new string[2];
                      arg = doc.ToString().Split(';');
                      Session["yetkiid"] = arg[0];
                      t_yetki.Text = arg[1];
                      ASPxPopupControl2.ShowOnPageLoad = false;
               }
               catch(Exception c)
               {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }

        protected void t_il_SelectedIndexChanged(object sender, EventArgs e)
        {
               ILCEYUKLE();
        }

        protected void t_ilce_SelectedIndexChanged(object sender, EventArgs e)
        {
               SUBEYUKLE();
        }
     
    }
}