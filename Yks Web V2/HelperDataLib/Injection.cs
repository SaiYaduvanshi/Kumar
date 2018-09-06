using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HelperDataLib
{
    public class Injection : IHttpModule
    {
        public static string[] blackList = 
        {
 "'",";--","@@","char","nchar","varchar","nvarchar","alter","begin","cast","create","declare","delete","drop","exec","execute","fetch","insert","kill","open","select", "sys","sysobjects","syscolumns","update"
                                       };
        public void Init(HttpApplication app)
        {

            app.BeginRequest += new EventHandler(RequestKontrol);

        }
        void RequestKontrol(object sender, EventArgs e)
        {

            HttpRequest Request = (sender as HttpApplication).Context.Request;
            foreach (string key in Request.QueryString)

                kontrol(Request.QueryString[key]);

            //foreach (string key in Request.Form)

            //    kontrol(Request.Form[key]);

            foreach (string key in Request.Cookies)

                kontrol(Request.Cookies[key].Value);

        }
        private void kontrol(string parameter)
        {
            for (int i = 0; i < blackList.Length; i++)
            {

                if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    HttpContext.Current.Response.Redirect("~/Error.aspx");

                }

            }
        }
        public void Dispose()
        {

        }
    }
}
