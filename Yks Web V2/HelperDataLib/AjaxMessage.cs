using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace HelperDataLib
{
   public class AjaxMessage
    {
         public static void Show(System.Web.UI.Page sayfa, string mesaj)
        {
            try
            {
                ScriptManager.RegisterClientScriptBlock(sayfa, sayfa.GetType(), "MessageBox", "alert('" + mesaj + "')", true);
            }
            catch
            {
                return;
            }
        }
    }
    
}
