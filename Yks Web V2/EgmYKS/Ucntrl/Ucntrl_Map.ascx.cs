using DevExpress.Web;
using EgmYKS.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EgmYKS.Ucntrl
{
    public partial class Ucntrl_Map : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private List<clsKisayolMarker> Kisayollistegetir()
        {
            List<clsKisayolMarker> kisayollar = new List<clsKisayolMarker>();
            DataTable kısayolmarker = MK_HelperDataLib.Select.S_KISAYOLMARKER_YUKLE();

            if (kısayolmarker.Rows.Count > 0)
            {
                for (int i = 0; i < kısayolmarker.Rows.Count; i++)
                {
                    try
                    {
                        clsKisayolMarker mymrk = new clsKisayolMarker()
                        {
                            markerTitle = kısayolmarker.Rows[i]["MRK_ADI"].ToString(),
                            markerIcon = kısayolmarker.Rows[i]["MRK_ICON"].ToString() != "" ? kısayolmarker.Rows[i]["MRK_ICON"].ToString() : "/images/context/155.png",
                            markerLong = kısayolmarker.Rows[i]["MRK_LONG"].ToString(),
                            markerLat = kısayolmarker.Rows[i]["MRK_LAT"].ToString()
                        };
                        kisayollar.Add(mymrk);

                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
                DataTable kısayolmarker_arac = MK_HelperDataLib.Select.S_KISAYOLMARKER_YUKLE_ARAC(41.0628408, 28.9869915, 10000);
                if (kısayolmarker_arac.Rows.Count > 0)
                {
                    for (int i = 0; i < kısayolmarker_arac.Rows.Count; i++)
                    {
                        clsKisayolMarker mymrk2 = new clsKisayolMarker()
                        {
                            markerTitle = kısayolmarker_arac.Rows[i]["MRK_ADI"].ToString() + " " + kısayolmarker_arac.Rows[i]["Distance1"].ToString(),
                            markerIcon = kısayolmarker_arac.Rows[i]["MRK_ICON"].ToString() != "" ? kısayolmarker_arac.Rows[i]["MRK_ICON"].ToString() : "/images/context/155.png",
                            markerLong = kısayolmarker_arac.Rows[i]["MRK_LONG"].ToString(),
                            markerLat = kısayolmarker_arac.Rows[i]["MRK_LAT"].ToString()
                        };
                        kisayollar.Add(mymrk2);
                    }
                }
            }
            return kisayollar;
        }
        protected void Callbackkisayollistegetir(object sender, CallbackEventArgs e)
        {
            // callback server side script
            var datas = Kisayollistegetir();
            var json = JsonConvert.SerializeObject(datas, Newtonsoft.Json.Formatting.Indented);
            e.Result = json;
            //e.Result = "JSON Sonuc Gonderilecek";d
        }

    }
}