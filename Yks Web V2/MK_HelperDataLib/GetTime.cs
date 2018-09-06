using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MK_HelperDataLib
{
   public class GetTime
    {
       public static SqlConnection con = new SqlConnection();
       public static string Time()
       {
           string time = "";
           try
           {
               Connection.OpenConnection(ref con);
               SqlCommand com = new SqlCommand(@"SELECT GETDATE() AS TIME", con);
               SqlDataReader SDR = com.ExecuteReader();
               if (SDR.Read())
               {
                   time = SDR["TIME"].ToString();
               }
               con.Close();
           }
           catch
           {
               con.Close();
           }
           return time;
       }
    }
}
