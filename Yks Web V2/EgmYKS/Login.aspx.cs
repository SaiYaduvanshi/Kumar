using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EgmYKS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session.Clear();
                    getCookie();

                }
            }
            catch
            { return; }
        }

        private void getCookie()
        {
            HttpCookie oKCookie = Request.Cookies["girismail"];
            HttpCookie oKCookiesifre = Request.Cookies["girissifre"];

            if (!string.IsNullOrEmpty(oKCookie.Value))
            {

                TextBox1.Text = oKCookie.Value;

                string password = oKCookiesifre.Value;

                TextBox2.Text = password;


                CheckBox1.Checked = true;
                CheckBox2.Checked = false;
            }
            if (!string.IsNullOrEmpty(oKCookiesifre.Value))
            {
                string password = oKCookiesifre.Value;

                //TextBox2.Text = password;

                TextBox2.Attributes.Add("value", password);
                //if (TextBox2.Text != "")
                //{
                //       TextBox2.Text = "******";
                //}
                CheckBox2.Checked = true;

            }

            if (string.IsNullOrEmpty(oKCookie.Value) && string.IsNullOrEmpty(oKCookiesifre.Value))
                CheckBox1.Checked = false;
        }

        void MesajKapat()
        {
            Errorpassword.Visible = false;
            Errorpassword2.Visible = false;
            Erroreposta.Visible = false;
            ErrorPasif.Visible = false;
            chapta.Visible = false;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MesajKapat();
                bool durum = false;
                if (TextBox1.Text != "")
                {
                    if (TextBox2.Text != "")
                    {
                        HelperDataLib.Select.S_KULLANICIGIRIS(TextBox1.Text, TextBox2.Text, CheckBox1.Checked, ref durum);
                        if (durum == false)
                        {
                            HelperDataLib.MessageBox.Show("Sicil No veya şifre yalnış.Kontrol ederek tekrar deneyiniz!");
                        }


                    }
                    else
                    {
                        HelperDataLib.MessageBox.Show("Şifrenizi yazınız!");
                    }
                }
                else
                {
                    HelperDataLib.MessageBox.Show("Sicil No bilginizi yazınız!");
                }
            }
            catch
            { return; }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                HttpCookie girismail = new HttpCookie("girismail", TextBox1.Text);
                girismail.Expires = DateTime.Now.AddYears(1); // Süre(1 yıl)
                Response.Cookies.Add(girismail);
                Response.Redirect("Login.aspx");
            }
            else
            {
                HttpCookie girismail = new HttpCookie("girismail", "");
                girismail.Expires = DateTime.Now.AddYears(1); // Süre(1 yıl)
                Response.Cookies.Add(girismail);

                HttpCookie girissifre = new HttpCookie("girissifre", "");
                girissifre.Expires = DateTime.Now.AddYears(1); // Süre(1 yıl)
                Response.Cookies.Add(girissifre);

                Response.Redirect("Login.aspx");
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            {
                HttpCookie girismail = new HttpCookie("girismail", TextBox1.Text);
                girismail.Expires = DateTime.Now.AddYears(1); // Süre(1 yıl)
                Response.Cookies.Add(girismail);

                HttpCookie girissifre = new HttpCookie("girissifre", TextBox2.Text);
                girissifre.Expires = DateTime.Now.AddYears(1); // Süre(1 yıl)
                Response.Cookies.Add(girissifre);
                Response.Redirect("Login.aspx");
            }
            else
            {

                HttpCookie girissifre = new HttpCookie("girissifre", "");
                girissifre.Expires = DateTime.Now.AddYears(1); // Süre(1 yıl)
                Response.Cookies.Add(girissifre);
                
                Response.Redirect("Login.aspx");
            }
        }
    }
}