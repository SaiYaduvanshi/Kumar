using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EgmYKS.Ucntrl
{
    public partial class Ucntrl_KullaniciList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
               if (!Page.IsPostBack)
               {
                      YETKIKONTROL();
               }
            YUKLE();
            
        }
        void YETKIKONTROL()
        {

            try
            {
                   bool OKU = false; bool YAZ = false; bool SIL = false; string USERS = ""; bool EKSTRA = false;
                   HelperDataLib.Select.S_YETKI_GETVALUES("103", ref OKU, ref YAZ, ref SIL, ref EKSTRA, ref USERS);
                if (SIL == true)
                {

                    DevExpress.Web.MenuItem sil = this.ASPxMenu1.Items.FindByName("SIL");
                    sil.Visible = true;
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
        void YUKLE()
        {
            try
            {
                ASPxGridView1.DataSource = HelperDataLib.Select.S_USER_LISTESI();
                ASPxGridView1.DataBind();
            }
            catch (Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        protected void ASPxMenu1_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            MESAJKAPAT();
            if (e.Item.Name == "ISLEM")
            {
                Session["yetkiid"] = null;
                Session["kulmno"] = null;
                Session["kullanicisession"] = null;
                Response.Redirect("YeniKullanici.aspx?new=" + true);
            }
            if (e.Item.Name == "SIL")
            {
                bool durum = false;
                for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                {
                    if (ASPxGridView1.Selection.IsRowSelected(i))
                    {
                        try
                        {
                            string kullanicino = ASPxGridView1.GetRowValues(i, new string[] { "USR_ID" }).ToString();
                            HelperDataLib.Delete.D_KULLANICI(kullanicino, ref durum);
                            if (durum == true)
                            {
                                succes.Visible = true;
                            }
                            if (durum == false)
                            {
                                error.Visible = true;
                            }
                        }
                        catch (Exception c)
                        {
                            bool durum1 = false;
                            HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
                        }
                    }
                   

                }
                if (durum == true)
                {
                    YUKLE();
                }

            }
            if (e.Item.Name == "YENILE")
            {
                YUKLE();
            }
        }
        protected void ASPxButton1_Command(object sender, CommandEventArgs e)
        {
           //detay
            string doc = e.CommandArgument.ToString();
            Response.Redirect("YeniKullanici.aspx?id=" + HelperDataLib.Encrypt.UrlEncrypt(doc) + "&&" + "new=" + false);
        }
        void MESAJKAPAT()
        {
            succes.Visible = false;
            error.Visible = false;
            Warning.Visible = false;
        }
    }
}