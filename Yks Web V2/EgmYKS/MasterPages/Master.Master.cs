using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EgmYKS.MasterPages
{
       public partial class Master : System.Web.UI.MasterPage
       {
              protected void Page_Load(object sender, EventArgs e)
              {
                     if (!Page.IsPostBack)
                     {
                            if (HttpContext.Current.Session["SS_ID"] != null && HttpContext.Current.Session["SS_YETKIID"] != null && HttpContext.Current.Session["USR_SICILNO"] != null)
                            {
                                   Label1.Text = HttpContext.Current.Session["SS_USR_SONGIRIS"].ToString();
                                   Label8.Text = HttpContext.Current.Session["SS_ISIM"] + " " + HttpContext.Current.Session["SS_SOYADI"];
                            }
                            else
                            {
                               Response.Redirect("~/Login.aspx");
                            }
                            MODULYETKIKONTROL();
                     }
              }
              void MODULYETKIKONTROL()
              {
                     try
                     {
                            DataTable  d = HelperDataLib.Select.S_YETKI_MODUL_LISTESI();
                            string[] arg = new string[999999];
                            arg = HttpContext.Current.Session["SS_MODULID"].ToString().Split(',');
                            foreach (string item in arg)
                            {
                                   if (item.Length > 0)
                                   {
                                      
                                          try
                                          {
                                                 for (int i = 0; i < d.Rows.Count; i++)
                                                 {
                                                        bool OKU = false; bool YAZ = false; bool SIL = false; bool DINLE = false; string USERS = ""; bool EKSTRA = false;
                                                        HelperDataLib.Select.S_YETKI_GETVALUES(d.Rows[i]["MDL_MODULID"].ToString(), ref OKU, ref YAZ, ref SIL,ref  EKSTRA, ref USERS);
                                                        if (OKU == true)
                                                        {
                                                               string id = d.Rows[i]["MDL_MODULID"].ToString();
                                                               Control myControl1 = FindControl("_" + id);
                                                               if (myControl1 != null)
                                                               {
                                                                   myControl1.Visible = true;
                                                               }


                                                        }
                                                 }
                                          }
                                          catch
                                          {
                                                 continue;
                                          }
                                         
                                   }
                            }
                     }
                     catch
                     {
                            return;
                     }
              }

       }
}