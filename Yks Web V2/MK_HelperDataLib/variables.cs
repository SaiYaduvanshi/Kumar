using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MK_HelperDataLib
{
   public class variables
    {
       public static void replace(string filename, string la, string lo, string country, string city, string marker, string image, string path)
       {
           if (File.Exists(filename))
           {
               StreamReader reader = new StreamReader(filename);
               string readFile = reader.ReadToEnd();
               string sb = "";
               sb = readFile;
               sb = sb.Replace("[la]", la);
               sb = sb.Replace("[lo]", lo);
               sb = sb.Replace("[country]", country);
               sb = sb.Replace("[city]", city);
               sb = sb.Replace("[image]", image);
               sb = sb.Replace("[marker]", marker);

               readFile = sb.ToString();
               reader.Close();
               StreamWriter writer = new StreamWriter(path);
               writer.Write(readFile);
               writer.Close();

               writer = null;
               reader = null;
           }
           
       }
    }
}
