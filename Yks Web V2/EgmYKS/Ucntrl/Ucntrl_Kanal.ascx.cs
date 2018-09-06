using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EgmYKS.Ucntrl
{
    public partial class Ucntrl_Kanal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                YETKIKONTROL();
              
            }
            Ilceler();
            DigerKanal();
            YUKLE();

        }
        void DigerKanal()
        {

            try
            {
                _DigerKanal.DataSource = HelperDataLib.Select.S_TERMINAL();
                _DigerKanal.DataBind();
            }
            catch(Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void Ilceler()
        {
            try
            {
                _ilce.DataSource = HelperDataLib.Select.S_ILCE("41");
                _ilce.DataBind();
                _tip.DataSource = HelperDataLib.Select.S_TIP();
                _tip.DataBind();
            }
            catch(Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        void YETKIKONTROL()
        {

            try
            {
                bool OKU = false; bool YAZ = false; bool SIL = false; string USERS = ""; bool EKSTRA = false;
                HelperDataLib.Select.S_YETKI_GETVALUES("304", ref OKU, ref YAZ, ref SIL, ref EKSTRA, ref USERS);
                if (SIL == true)
                {
                    ASPxGridView1.Columns["Sil"].Visible = true;

                }
                if (YAZ == true)
                {
                    ASPxButton1.Visible = true;
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
                ASPxGridView1.DataSource = HelperDataLib.Select.S_KANAL_TUM2();
                ASPxGridView1.DataBind();
            }
            catch (Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }

        }

        void MESAJKAPAT()
        {
            succes.Visible = false;
            error.Visible = false;
            Warning2.Visible = false;
            Warning.Visible = false;
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            MESAJKAPAT();
            bool durum = false;
            if (ASPxTextBox1.Text != "" && ASPxTextBox2.Text != "" && ASPxComboBox1.SelectedItem.Value.ToString() != "" && _tip.Text != "")
            {
                string tip = ""; string ilce = "";
                if (_ilce.Text != "")
                {

                    ilce = _ilce.Text;
                }
                if (_tip.Text != "")
                {
                    tip = _tip.Value.ToString();
                }
                if (Session["knl_id"] == null)
                {
                    try
                    {
                        string KANALK = HelperDataLib.Select.S_KANAL_KONTROL(ASPxTextBox1.Text.Trim().ToUpper());
                        if (KANALK == "")
                        {

                            HelperDataLib.Insert.I_KANAL(ASPxTextBox1.Text.Trim().ToUpper(), ASPxCheckBox1.Checked, ASPxTextBox2.Text, Convert.ToInt32(tip), ASPxComboBox1.SelectedItem.Value.ToString(), ilce.ToString(), _DigerKanal.Text, ref durum);
                            if (durum == true)
                            {
                                succes.Visible = true;
                                TEMIZLE();
                                YUKLE();
                            }
                            else
                            {
                                error.Visible = true;
                            }
                        }
                        else { Warning2.Visible = true;  }
                    }
                    catch (Exception c)
                    {
                        lblerrormesaj.Text = "YONETIM PROJESİ " + this.Page.ToString() + " sayfası " + System.Reflection.MethodBase.GetCurrentMethod().Name + " metodu hatası : " + c.Message;
                        //LOGKOMUTSATIRI
                        bool durum1 = false;
                        HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
                        Warning_error.Visible = true;
                    }
                }
                else
                {

                    if (_ilce.Text != "")
                    {

                        ilce = _ilce.Text;
                    }
                    if (_tip.Text != "")
                    {
                        tip = _tip.Value.ToString();
                    }
                    try
                    {
                        string KANALUK = HelperDataLib.Select.S_KANAL_KONTROL(ASPxTextBox1.Text.Trim().ToUpper());
                        if (KANALUK == "")
                        {
                            HelperDataLib.Update.U_KANAL(Session["knl_id"].ToString(), ASPxTextBox1.Text.Trim().ToUpper(), ASPxCheckBox1.Checked, ASPxTextBox2.Text, Convert.ToInt32(tip), ASPxComboBox1.SelectedItem.Value.ToString(), ilce.ToString(), _DigerKanal.Text, ref durum);
                            if (durum == true)
                            {
                                succes.Visible = true;
                                TEMIZLE();
                                YUKLE();
                            }
                            else
                            {
                                error.Visible = true;
                            }
                        }
                        else { Warning2.Visible = true;  }
                    }
                    catch (Exception c)
                    {
                        lblerrormesaj.Text = "YONETIM PROJESİ " + this.Page.ToString() + " sayfası " + System.Reflection.MethodBase.GetCurrentMethod().Name + " metodu hatası : " + c.Message;
                        //LOGKOMUTSATIRI
                        bool durum1 = false;
                        HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
                        Warning_error.Visible = true;
                    }
                }
            }
            else
            {
                Warning.Visible = true;

            }
        }
        void TEMIZLE()
        {
            Session["knl_id"] = null;
            ASPxTextBox1.Text = "";
            ASPxTextBox2.Text = "";
            ASPxComboBox1.Text="";
            _tip.Text = "";
            _ilce.Text = "";
            _DigerKanal.Text = "";
            ASPxCheckBox1.Checked = false;
            MESAJKAPAT();
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            TEMIZLE();
        }

        protected void ASPxButton3_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string doc = e.CommandArgument.ToString();
                Session["knl_id"] = doc;
                DataTable d = HelperDataLib.Select.S_KANAL_WHERE(doc);
                ASPxTextBox1.Text = d.Rows[0]["KNL_KODU"].ToString();
                ASPxTextBox2.Text = d.Rows[0]["KN_ADI"].ToString();
                ASPxComboBox1.Text = d.Rows[0]["KNL_YETKI"].ToString();
                ASPxCheckBox1.Checked = Convert.ToBoolean(d.Rows[0]["KNL_DURUM"].ToString());
                _tip.Value = d.Rows[0]["KNL_TRAFIK"];
                Ilceler();
                _ilce.Text = d.Rows[0]["KNL_ILCE"].ToString();
                DigerKanal();

                _DigerKanal.Text = d.Rows[0]["KNL_DIGERKANAL"].ToString();
            }
            catch (Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }

        }

        protected void ASPxButton4_Command(object sender, CommandEventArgs e)
        {
            try
            {
                bool durum = false;
                string doc = e.CommandArgument.ToString();
                HelperDataLib.Delete.D_KANAL(doc, ref durum);
                if (durum == true)
                {
                    succes.Visible = true;
                    TEMIZLE();
                    YUKLE();
                }
                else
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
}