﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace EgmYKS.Ucntrl
{
       public partial class Ucntrl_Grup : System.Web.UI.UserControl
    {
           protected void Page_Load(object sender, EventArgs e)
           {
                  if (!Page.IsPostBack)
                  {
                         Session["d_agents"] = null; Session["d_id"] = null;
                         GRUPLISTE();
                         USERYUKLE();
                  }
                  YETKIKONTROL();
           }
           void MESAJKAPAT()
           {
                  succes.Visible = false;
                  error.Visible = false;
                  Warning.Visible = false;
                  Warning2.Visible = false;
           }
           void YETKIKONTROL()
           {
                  try
                  {
                         bool OKU = false; bool YAZ = false; bool SIL = false; string USERS = ""; bool EKSTRA = false; 
                         HelperDataLib.Select.S_YETKI_GETVALUES("102", ref OKU, ref YAZ, ref SIL, ref EKSTRA, ref USERS);
                         if (YAZ == true)
                         {
                                ASPxButton1.Enabled = true;
                                ASPxButton2.Enabled = true;
                         }
                         if (SIL == true)
                         {
                                ASPxGridView2.Columns["Sil"].Visible = true;
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
           void GRUPLISTE()
           {
            try
            {
                ASPxGridView2.DataSource = HelperDataLib.Select.S_GRUP_LISTESI();
                ASPxGridView2.DataBind();
            }
            catch (Exception c)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
           }
           void USERYUKLE()
           {
                  try
                  {
                         ASPxGridView1.Selection.UnselectAll();
                         ASPxGridView1.DataSource = HelperDataLib.Select.S_USER_LISTESI();
                         ASPxGridView1.DataBind();
                         if (Session["d_agents"] != null)
                         {
                                string[] arg = new string[100];
                                arg = Session["d_agents"].ToString().Split(';');
                                for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                                {
                                       object kod = ASPxGridView1.GetRowValues(i, "USR_SICILNO");
                                       foreach (string t in arg)
                                       {
                                              if (t.ToString() == kod.ToString())
                                              {
                                                     ASPxGridView1.Selection.SelectRow(i);
                                              }
                                       }
                                }
                         }
                  }
                  catch(Exception c)
                  {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
           }
           protected void ASPxButton1_Click(object sender, EventArgs e)
           {
                  MESAJKAPAT();
                  if (ASPxTextBox2.Text != "")
                  {
                         if (Session["d_id"] == null)
                         {
                                KAYDET();
                         }
                         else
                         {
                                GUNCELLE();
                         }
                  }
                  else
                  {
                         Warning.Visible = true;
                  }
           }
           void GUNCELLE()
           {

                  bool durum1 = false; object AGENT = "";
                  for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                  {
                         if (ASPxGridView1.Selection.IsRowSelected(i) == true)
                         {
                                if (AGENT.ToString() == "")
                                {
                                       AGENT = ASPxGridView1.GetRowValues(i, "USR_SICILNO");
                                }
                                else
                                {
                                       AGENT += ";" + ASPxGridView1.GetRowValues(i, "USR_SICILNO");
                                }
                         }
                  }
            try
            {
                HelperDataLib.Update.U_GRUP(Session["d_id"].ToString(), ASPxTextBox2.Text, AGENT.ToString(), ref durum1);
            }
            catch (Exception c)
            {
                bool durum2 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum2);
            }
                  if (durum1 == true)
                  {
                         TEMIZLE();
                         USERYUKLE();
                         GRUPLISTE();
                         succes.Visible = true;
                  }

                  else
                  {
                         error.Visible = false;
                  }
           }
           void KAYDET()
           {
                  bool durum1 = false; object AGENT = "";
                  for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                  {
                         if (ASPxGridView1.Selection.IsRowSelected(i) == true)
                         {
                                if (AGENT.ToString() == "")
                                {
                                       AGENT = ASPxGridView1.GetRowValues(i, "USR_SICILNO");
                                }
                                else
                                {
                                       AGENT += ";" + ASPxGridView1.GetRowValues(i, "USR_SICILNO");
                                }
                         }
                  }

            try
            {
                HelperDataLib.Insert.I_GRUP(HelperDataLib.Select.S_GETMAXGRUP().ToString(), ASPxTextBox2.Text, AGENT.ToString(), ref durum1);
            }
            catch (Exception c)
            {
                bool durum3 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum3);
            }
                  if (durum1 == true)
                  {
                         TEMIZLE();
                         USERYUKLE();
                         GRUPLISTE();
                         succes.Visible = true;
                  }

                  else
                  {
                         error.Visible = false;
                  }
           }
           void TEMIZLE()
           {

                  ASPxTextBox2.Text = "";
                  Session["d_id"] = null;
                  Session["d_agents"] = null;

           }


           protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
           {
                  try
                  {
                         //sil
                         MESAJKAPAT();
                         bool durum = false;
                         ImageButton img = (ImageButton)sender;
                         string doc = img.CommandArgument;
                try
                {
                    HelperDataLib.Delete.D_GRUP(doc, ref durum);
                }
                catch (Exception c)
                {
                    bool durum1 = false;
                    HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
                }
                         if (durum == true)
                         {
                                TEMIZLE();
                                GRUPLISTE();
                                succes.Visible = true;
                         }

                         else
                         {
                                error.Visible = false;
                         }
                  }
                  catch
                  { return; }
           }

           protected void ASPxButton2_Click(object sender, EventArgs e)
           {
                  TEMIZLE();
                  MESAJKAPAT();
           }

           protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
           {
                  try
                  {
                         MESAJKAPAT();
                         ImageButton img = (ImageButton)sender;
                         string doc = img.CommandArgument;
                         string[] arg = new string[999];
                         arg = doc.ToString().Split('-');
                         Session["d_id"] = arg[0];

                         ASPxTextBox2.Text = arg[2];
                         Session["d_agents"] = arg[3];

                         USERYUKLE();
                         ASPxPageControl1.ActiveTabIndex = 1;
                  }
                  catch(Exception c)
                  {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + c.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
           }
    }
}