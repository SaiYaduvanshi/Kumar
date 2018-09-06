using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MK_HelperDataLib
{
   public   class Helper
    {

        public static string SS_IHBARLISTESI_COUNT = "100";
        public static string SS_KAPALIIHBARLISTESI_COUNT = "100"; 
             
          
         
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
