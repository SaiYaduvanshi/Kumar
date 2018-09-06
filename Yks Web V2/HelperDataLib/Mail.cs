using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace HelperDataLib
{
   public class Mail
    {
        public static string mailx = "";
        public static string password = "";
        public static string smtpx = "";
        public static string port = "";
        public static bool ssl =false;
        public static string baslik = "";
        public static string altmesaj = "";
        public static void ayar()
        {
            try
            {
                string key = ConfigurationManager.AppSettings["ConfigPass"].ToString();
                //Select.S_MAILAYAR(ref mailx, ref password, ref smtpx, ref port,ref ssl,ref baslik,ref altmesaj);
                if (password != "")
                {
                    password = Encrypt.Config_Decrypt(password, key);
                }
              
            }
            catch
            {
                return;
            }

        }
        public static void MailParametre(string kime, string body,string body2, string display, string subject, string resim, ref bool durum, ref string hata)
        {
               try
               {
                      string mailmode = ConfigurationManager.AppSettings["MailMode"].ToString();
                      if (mailmode == "1")
                      {
                             ayar();
                             MailMessage mesaj = new MailMessage();
                             mesaj.IsBodyHtml = true;
                             mesaj.From = new MailAddress(mailx, "İnfo Yatırım", System.Text.Encoding.UTF8);
                             string image1 = "";
                             string image2 = "";
                             string[] arg = new string[9999];
                             arg = body.Split('<');
                             for (int i = 0; i < arg.Length; i++)
                             {
                                    if (arg[i].ToString().Contains("img src=\"/imza/") == true)
                                    {
                                           string c = arg[i].ToString();
                                           string[] arg2 = new string[9999];
                                           arg2 = c.Split('"');
                                           for (int x = 0; x < arg2.Length; x++)
                                           {
                                                  if (arg2[x].ToString().Contains("/imza/") == true)
                                                  {
                                                         image1 = arg2[x].ToString();
                                                         //image = image.Replace(ConfigurationManager.AppSettings["TempLink"].ToString(), "");
                                                  }
                                           }
                                    }
                                    if (arg[i].ToString().Contains("img src=\"http://") == true)
                                    {
                                           string c = arg[i].ToString();
                                           string[] arg2 = new string[9999];
                                           arg2 = c.Split('"');
                                           for (int x = 0; x < arg2.Length; x++)
                                           {
                                                  if (arg2[x].ToString().Contains("http://") == true)
                                                  {
                                                         image2 = arg2[x].ToString();
                                                         image2 = image2.Replace(ConfigurationManager.AppSettings["TempLink"].ToString(), "");
                                                  }
                                           }

                                    }
                             
                             }
                           
                             mesaj.Body = body;
                             //AlternateView htmlView = AlternateView.CreateAlternateViewFromString("<img src=cid:companylogo1>", System.Text.Encoding.UTF8, "text/html");
                             //AlternateView htmlView1 = AlternateView.CreateAlternateViewFromString("<img src=cid:companylogo2>", System.Text.Encoding.UTF8, "text/html");
                             //if (image1 != "")
                             //{
                             //       //mesaj.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~/" + image1), MediaTypeNames.Application.Octet));
                             //       LinkedResource logo1 = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/" + image1));
                             //       logo1.ContentId = "companylogo1";
                             //       htmlView.LinkedResources.Add(logo1);
                             //       //mesaj.AlternateViews.Add(htmlView);
                             //}
                             //if (image2 != "")
                             //{
                             //       //mesaj.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~/" + image2), MediaTypeNames.Application.Octet));
                             //       LinkedResource logo2 = new LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/" + image2));
                             //       logo2.ContentId = "companylogo2";
                             //       htmlView1.LinkedResources.Add(logo2);
                             //       mesaj.AlternateViews.Add(htmlView1);
                             //}

                           
                           
                            
                        
                             SmtpClient smtp = new SmtpClient();
                             mesaj.To.Add(kime);
                             mesaj.Subject = subject;
                             mesaj.BodyEncoding = System.Text.Encoding.UTF8;
                             
                             mesaj.Priority = MailPriority.High;
                             smtp.Host = smtpx;
                             smtp.Port = Convert.ToInt32(port);
                             smtp.UseDefaultCredentials = true;
                             if (ssl == true)
                             {
                                    smtp.EnableSsl = true;
                             }
                             else
                             {

                                    smtp.EnableSsl = false;
                             }
                             smtp.Credentials = new System.Net.NetworkCredential(mailx, password);
                             smtp.Send(mesaj);
                             durum = true;
                      }
               }
               catch (Exception c)
               {
                      hata = c.Message;
                      return;
               }

        }
      
        public static void SIFREMAIL(string kime,string İsimSoyisim, string sifre,string resim, ref bool durum,ref string hata)
        {
            try
            {
                string display = ConfigurationManager.AppSettings["SifreMailDisplay"].ToString();
                string body = "";
                body = "<html>";
                body += "<table style='width:750px;'>";
                body += "<tr style='width:80%; border-style: none; background-color:#6699FF;'>";
                body += "<td colspan='2'>";
                body += "<div align='center' style='width: 500px; background-color:#6699FF; color: #FFFFFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #6699FF;'>" + display + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "</table>";
                body += "<table style='width:750px;  color:#000000;'>";
                body += "<tr>";
                body += "<td style='width:200px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>Mail Adresi</a>";
                body += "</div>";
                body += "</td>";
                body += "<td style='width:500px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>" + kime + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "<tr>";
                body += "<td style='width:200px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>İsim Soyisim</a>";
                body += "</div>";
                body += "</td>";
                body += "<td style='width:500px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>" + İsimSoyisim + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "<tr>";
                body += "<td style='width:200px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>Şifreniz</a>";
                body += "</div>";
                body += "</td>";
                body += "<td style='width:500px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>" + sifre + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "</table>" + "<br/>";
                body += "</html>";
                MailParametre(kime, body,"",display, display,resim, ref durum,ref hata);
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static void SIFREMAIL_UNUTTUM(string kime,string sifreurl,string resim, ref bool durum,ref string hata)
        {
            try
            {
                string display = ConfigurationManager.AppSettings["SifreMailDisplay"].ToString();
                string body = "";
              
                body = "<html>";
                body += "<table style='width:750px;'>";
                body += "<tr style='width:80%; border-style: none; background-color:#6699FF;'>";
                body += "<td colspan='2'>";
                body += "<div align='center' style='width: 500px; background-color:#6699FF; color: #FFFFFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #6699FF;'>" + display + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "</table>";
                body += "<table style='width:750px;  color:#000000;'>";
                body += "<tr>";
                body += "<td style='width:200px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>Mail Adresi</a>";
                body += "</div>";
                body += "</td>";
                body += "<td style='width:500px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>" + kime + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "<tr>";
                body += "<td style='width:200px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>Şifreniz</a>";
                body += "</div>";
                body += "</td>";
                body += "<td style='width:500px; border-style: none; background-color:#6699FF;'>";
                body += "<div align='left' style='width:100%; color: #99CCFF;>";
                body += "<a style='font-size: large; font-weight:bold color: #99CCFF;'>" + sifreurl + "</a>";
                body += "</div>";
                body += "</td>";
                body += "</tr>";
                body += "</table>" + "<br/>";
                body += "</html>";
                body += "Şifrenizi sıfırlamak için yukarıdaki linke tıklayınız!";
                MailParametre(kime, body,"", display, display, resim, ref durum, ref hata);
            }
            catch
            {
                durum = false;
                return;
            }
        }
        public static void MAIL_GONDER(string kime, string baslik,string mesaj,string mesaj2,string resim, ref bool durum, ref string hata)
        {
               try
               {
                     
                      string body = "";

           
                      body += mesaj;

                      MailParametre(kime, body, mesaj2, baslik, baslik, resim, ref durum, ref hata);
               }
               catch
               {
                      durum = false;
                      return;
               }
        }
      
    }
}
