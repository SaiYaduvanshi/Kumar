using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.Security;
using System.Configuration;

namespace HelperDataLib
{
    public class Encrypt
    {
      
        public static string Config_Encrypt(string originalString,string key)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(key);
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new System.IO.MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string Config_Decrypt(string cryptedString,string key)
        {
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(key);
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException
                   ("");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        public static string Md5Encrypt(string pass)
        {
            try
            {
                string repass="";
               string passmd5 = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "md5");
                repass = FormsAuthentication.HashPasswordForStoringInConfigFile(passmd5, "sha1");
                return repass;
            }
            catch
            {
                return "";
            }
        }
        public static string UrlEncrypt(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                encodedData = encodedData.Replace("=", "");
                return encodedData;
            }
            catch
            {
                return null;
            }
        }


        public static string UrlDecrypt(string data)
        {
            try
            {
                int modSifre = data.Length % 4;
                if (modSifre != 0)
                {
                    modSifre = 4 - modSifre;
                }

                string strEsittir = new string('=', modSifre);
                data = data + strEsittir;

                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch
            {
                return null;
            }

        }
    }
}
