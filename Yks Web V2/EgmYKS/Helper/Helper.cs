using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EgmYKS.Helper
{
    public class Helper
    {
    
        public static DataTable CreateKeyFieldName(DataTable dt)
        {
            DataColumn dr = new DataColumn("KEYFIELDID");
            dt.Columns.Add(dr);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["KEYFIELDID"] = i.ToString();
            }
            return dt;
        }

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