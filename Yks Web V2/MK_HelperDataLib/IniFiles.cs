using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MK_HelperDataLib
{
   public  class IniFiles : IDisposable
    {
         string mvarstrIniFile = "";

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
                string key, string val, string filePath);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
                string key, string def, StringBuilder retVal,
                int size, string filePath);

            public IniFiles()
            {
            }
            public string ReadIni(string Section, string Key)
            {
                StringBuilder stbINI = new StringBuilder(255);
                GetPrivateProfileString(Section, Key, "", stbINI, 255, mvarstrIniFile);
                return stbINI.ToString();
            }
            public void WriteIni(string Section, string Key, string Value)
            {
                WritePrivateProfileString(Section, Key, Value, mvarstrIniFile);
            }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

        }

        public string IniFile
            {
                get { return mvarstrIniFile; }
                set { mvarstrIniFile = value; }
            }
    }
}
