using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils.Extensions;
using DevExpress.Web;
using DevExpress.Web.Internal;
using EgmYKS.Helper;
using Newtonsoft.Json;

namespace EgmYKS
{
    public partial class SecurityCompany : System.Web.UI.Page
    {
        string ihbarid = "";
        double la = 0;
        double lo = 0;

        void getSecurityCompanies()
        {
            cmbCompany.DataSource = MK_HelperDataLib.Select.S_GUVENLIKSIRKETI();
            cmbCompany.TextField = "G_SIRKETADI";
            cmbCompany.ValueField = "G_ID";
            cmbCompany.DataBind();
        }
        void getSecurityCompaniesSubscriber(string SIRKET)
        {
            cmbCompanySubscriber.DataSource = MK_HelperDataLib.Select.S_GUVENLIKSIRKET_ABONESI(SIRKET);
            cmbCompanySubscriber.ValueField = "GM_ID";
            cmbCompanySubscriber.TextField = "GM_MUSTERIISIM";
            cmbCompanySubscriber.DataBind();
        }
        void getChannel()
        {
            GridLookup.DataSource = MK_HelperDataLib.Select.S_KANAL();
            GridLookup.KeyFieldName = "KNL_KODU";
            //GridLookup.TextField = "KN_ADI";
            GridLookup.DataBind();
        }
        void getTown()
        {
            cmbCompanyTown.DataSource = MK_HelperDataLib.Select.S_ILCE("41");
            cmbCompanyTown.ValueField = "ILCEID";
            cmbCompanyTown.TextField = "AD";
            cmbCompanyTown.DataBind();
        }
        void getNeighborhood(string ilceid)
        {

            cmbNeighborhood.DataSource = MK_HelperDataLib.Select.S_Mahalle(ilceid);
            cmbNeighborhood.ValueField = "I_MAHID";
            cmbNeighborhood.TextField = "I_ADI";
            cmbNeighborhood.DataBind();
        }
        void getStreet(string ilceid, string mahalleid)
        {

            cmbStreet.DataSource = MK_HelperDataLib.Select.S_CADDE(ilceid, mahalleid);
            cmbStreet.TextField = "I_AD";
            cmbStreet.DataBind();
        }void getAlarmType()
        {
            cmbAlarmType.DataSource = MK_HelperDataLib.Select.S_ALARM_YUKLE();
            cmbAlarmType.ValueField = "A_ID";
            cmbAlarmType.TextField = "A_ADI";
            cmbAlarmType.DataBind();
        }

        //TODO: Winform R34 ile uyumlu hale getirilecek
        bool saveData(string status)
        {
        //    if (GridLookup.Text != "")
        //    {
        //        if (cmbAlarmType.Text != "")
        //        {
        //            if (cmbCompany.Text != "" && cmbCompanySubscriber.Text != "")
        //            {

        //                string mahhalle = "";
        //                string ilce = "";
        //                string cadde = "";
        //                if (cmbNeighborhood.Text != "")
        //                {
        //                    mahhalle = cmbNeighborhood.Value.ToString();
        //                }
        //                if (cmbCompanyTown.Text != "")
        //                {
        //                    ilce = cmbCompanyTown.Value.ToString();
        //                }
        //                if (cmbStreet.Text != "")
        //                {
        //                    cadde = cmbStreet.Text;
        //                }
        //                int refid = 0;
        //                if (ihbarid == "")
        //                {
        //                    //TODO: Winform R34 ile uyumlu hale getirilecek
        //                    string altolayid = MK_HelperDataLib.Select.S_GETALARM_ALTOLAY(cmbAlarmType.Value.ToString());
        //                    //bool durum = MK_HelperDataLib.Insert.I_IHBAR_GUVENLIK("", "", "", ilce, mahhalle, cadde,
        //                    //    txtSiteName.Text, txtBuildingName.Text, txtBuilding.Text, txtApartment.Text, "",
        //                    //    memoSubscriberAddress.Text, la.ToString(), lo.ToString(), "", "149", altolayid,
        //                    //    memoSecurityDesc.Text, "", 0, "", "", status, false, GridLookup.Text, "GÜV.FRM", "GS",
        //                    //    cmbCompany.Value.ToString(), cmbCompanySubscriber.Value.ToString(), cmbAlarmType.Value.ToString(), ref refid);
        //                    //if (durum == true)
        //                    //{
        //                    //    if (status == "İletilen")
        //                    //    {
        //                    //        string[] arg = new string[150];
        //                    //        arg = GridLookup.Text.Replace(" ", "").Split(',');
        //                    //        for (int i = 0; i < arg.Length; i++)
        //                    //        {
        //                    //            MK_HelperDataLib.Insert.I_IHBAR_DETAY(refid.ToString(), arg[i].ToString(),
        //                    //                false, false, arg[i], ref durum);
        //                    //            MK_HelperDataLib.Insert.I_LOG(refid.ToString(), arg[i].ToString(), "11",
        //                    //                ref durum);
        //                    //        }


        //                    //    }
        //                    //    return true;

        //                    //}
        //                    //else
        //                    //{
        //                    //    return false;
        //                    //}
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
                return false;
        //    }
        }

        protected void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable d = MK_HelperDataLib.Select.S_GUVENLIKSIRKETI_WHERE(cmbCompany.SelectedItem.Value.ToString());
                if (d.Rows.Count > 0)
                {
                    txtCompanyPhone.Text = d.Rows[0]["G_IRTIBATTELEFON"].ToString();
                }
            }
            catch
            { return; }
        }
        protected void ArrivalDateEdit_Validation(object sender, ValidationEventArgs e)
        {
            if (!(e.Value is DateTime))
                return;
            DateTime selectedDate = (DateTime)e.Value;
            DateTime currentDate = DateTime.Now;
            if (selectedDate.Year != currentDate.Year || selectedDate.Month != currentDate.Month)
                e.IsValid = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GridLookup.GridView.CustomCallback += GridView_CustomCallback;
                string Tarih1 = "2018-01-01 00:00:00";
                string Tarih2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string guvenliksirketi = "";
                string guvenlikmusteri = "";
                string alarmtur = "";
                string ilce = "";
                string sonuctur = "";

                //TODO: Winform R34 ile uyumlu hale getirilecek
                //ASPxGridView1.DataSource = MK_HelperDataLib.Select.S_GET_GUVENLIK_LISTESI(Tarih1, Tarih2,
                //    guvenliksirketi, guvenlikmusteri, alarmtur, ilce, sonuctur, "");
                ASPxGridView1.DataBind();
                getSecurityCompanies();
                getChannel();
                getTown();
                getAlarmType();
            }
        }
        protected void ASPxSave_Callback(object source, CallbackEventArgs e)
        {
            // Kaydet buton geri dönüşü
            try
            {
                saveData(e.Parameter);
                e.Result = "ok";
            }
            catch
            { return; }

        }
        protected void ASPxCallback1_Callback(object sender, CallbackEventArgs e)
        {
            // Güvenlik şirketi seçimi sonrası telefon ve görevli bilgisinin doldurulması
            try
            {
                getSecurityCompaniesSubscriber(e.Parameter);
                DataTable d = MK_HelperDataLib.Select.S_GUVENLIKSIRKETI_WHERE(e.Parameter);
                if (d.Rows.Count > 0)
                {
                    var datas = new
                    {
                        SirketTelefon = d.Rows[0]["G_IRTIBATTELEFON"].ToString(),
                        SirketGorevli = d.Rows[0]["G_IRTIBATISMI"].ToString()
                    };
                    var json = JsonConvert.SerializeObject(datas, Newtonsoft.Json.Formatting.Indented);
                    e.Result = json;
                }
            }
            catch
            { return; }
        }
        protected void ASPxSubscribe_Callback(object sender, CallbackEventArgs e)
        {
            // Şirket abonesi seçimi sonrası telefon ve adres bilgisinin döndürülmesi
            try
            {
                DataTable d = MK_HelperDataLib.Select.S_GUVENLIKSIRKET_ABONESI_WHERE(e.Parameter);
                if (d.Rows.Count > 0)
                {
                    var datas = new
                    {
                        SirketTelefon = d.Rows[0]["GM_TELEFON"].ToString(),
                        SirketGorevli = d.Rows[0]["GM_ADRES"].ToString()
                    };
                    var json = JsonConvert.SerializeObject(datas, Newtonsoft.Json.Formatting.Indented);
                    e.Result = json;
                }
            }
            catch
            { return; }

        }
        protected void CmbNeighborhood_Callback(object source, CallbackEventArgsBase e)
        {
            try
            {
                getNeighborhood(e.Parameter);
            }
            catch
            { return; }


        }
        protected void CmbStreet_Callback(object source, CallbackEventArgsBase e)
        {

            try
            {
                var snc = e.Parameter.Split(',');
                getStreet(snc[0].ToString(), snc[1].ToString());
            }
            catch
            { return; }

        }
        protected void CmbSubscriber_Callback(object source, CallbackEventArgsBase e)
        {
            try
            {
                getSecurityCompaniesSubscriber(e.Parameter);
            }
            catch
            { return; }
        }
    }
}