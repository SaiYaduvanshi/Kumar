using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelperDataLib
{
    public  class Methods
    {
        public static string ObjectnullorEmpty(object value)
        {
            string _res = string.Empty;
            try
            {
                _res = value.ToString();
            }
            catch
            {
                 _res = string.Empty;
            }
            return _res;
        }
        public static int ObjectStringtoint(object value)
        {
            int _res = 0;
            try
            {
                _res = Convert.ToInt32(value);
            }
            catch
            {
                _res = 0;
            }
            return _res;
        }
        public static DateTime ObjectMinDatetime(object value)
        {
            DateTime _res = Convert.ToDateTime("1753-01-01");
            try
            {
                _res = Convert.ToDateTime(value.ToString());
            }
            catch
            {
                _res = Convert.ToDateTime("1753-01-01");
            }
            return _res;
        }
        public static DateTime ObjectMaxDatetime(object value)
        {
            DateTime _res = Convert.ToDateTime("9999-01-01");
            try
            {
                _res = Convert.ToDateTime(value.ToString());
            }
            catch
            {
                _res = Convert.ToDateTime("9999-01-01");
            }
            return _res;
        }
    }
}
