using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EgmYKS.IHBAR
{
    public partial class KanalIhbarDetay : System.Web.UI.Page
    {
        
        string yon_durum = "0";
        public int rapor = 0;
        public int kanaldongu = 0;
        public int kapatma_kontrol = 0;
        
        public string ustolaykodu = "";
        string I_ALTOLAYKODU = "";
        string I_ALTOLAYADIFORNOTS = "";
        string enyakinkarakolid = "";
        public double lat = 0;
        public double lng = 0;
        
        public string ihbarType = string.Empty;
        public string telefon = "";
        public string StartDate = "";
        public string EndDate = "";
        public string adres = "";
        public string plaka = "";
        public string islemDurum = string.Empty;
        public bool ShowDetail { get; set; }

        private DataTable dtTowns = null;
        private DataTable dtDistricts = null;
        private DataTable dtSubevent = null;
        private DataTable dtTopevent = null;
        private string currentIhbarId
        {
            get
            {
                string _res = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["IhbarId"]))
                    _res = Request.QueryString["IhbarId"].ToString();

                return _res;
            }
        }
      private bool currentIhbarSon100
        {
            get
            {

                bool _durum = false;
                if (!string.IsNullOrEmpty(Request.QueryString["SON100"]))
                {
                    if (Request.QueryString["SON100"].ToString() == "1")
                        _durum = true;
                }
                return _durum;
            }
        }
        private  string kanal
        {
            get
            {
                string _res = string.Empty;
                if (!string.IsNullOrEmpty(Request.QueryString["IHBARKANAL"]))
                    _res = Request.QueryString["IHBARKANAL"].ToString();

                return _res; 
            }
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback | IsPostBack)
            {
                return;
            }

            if (!IsPostBack)
            {
                rDateBaslama.Date = DateTime.Now.AddDays(-1);
                rDateBitis.Date = DateTime.Now;
            }
            if (string.IsNullOrEmpty(currentIhbarId))
            {
                string script = " window.close()  ";
                ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script, true); 
            }
            PreparePageFields();
        }
        void FillRedirectEkip()
        {
            gridEkipList.DataSource = Helper.Helper.CreateKeyFieldName( MK_HelperDataLib.Select.S_YAKINEKIPLER_YUKLE() );
            gridEkipList.DataBind();
        }
        private void PreparePageFields()
        {
            ihbarType = MK_HelperDataLib.Select.S_GETIHBARTYPE(currentIhbarId);

            Filltowns(null);
            Fillsubeventload(null);
            Filltopeventload(null);
            FillSelectedKanalGrid();

            FillRedirectEkip();
            FillFormDetails();
            FillKanalLog();
            FillEkipLog();
           
            FillNots();
            VisibleMenuItems();
            CallList();
        }

        private void CallList()
        {
            IhbarRaporKriterleriYukle();

            string Tarih1 = rDateBaslama.Date.ToString("MM/dd/yyyy");
            string Tarih2 = rDateBitis.Date.ToString("MM/dd/yyyy");

            //[YahyaSonGuncelleme] = kanal gridlookup olarak değiştirildi.
            string kanal = "";
            if (lookKanal.Text != "")
            {
                string[] arg = new string[150];
                arg = lookKanal.Text.Split(';');
                for (int i = 0; i < arg.Length; i++)
                {
                    if (lookKanal.Text != "Kanal")
                    {
                        if (kanal == "")
                        {
                            kanal = "'" + arg[i] + "'";
                        }
                        else
                        {
                            kanal += ",'" + arg[i] + "'";
                        }
                    }
                }
            }

            string log = "";
            if (rChkLog.Value != null)
            {
                string[] arg2 = new string[150];
                arg2 = rChkLog.Value.ToString().Replace(" ", "").Split(';');
                for (int i = 0; i < arg2.Length; i++)
                {
                    if (rChkLog.Text != "Log")
                    {
                        if (log == "")
                        {
                            log = "'" + arg2[i] + "'";
                        }
                        else
                        {
                            log += ",'" + arg2[i] + "'";
                        }
                    }
                }
            }


            if (rtsk_cadde.Value != null)
            {
                string cadde_sokak = "";
                string[] arg3 = new string[150];
                arg3 = rtsk_cadde.Value.ToString().Replace(" ", "").Split(';');
                for (int i = 0; i < arg3.Length; i++)
                {
                    if (rtsk_cadde.Text != "Cadde-Sokak")
                    {
                        if (cadde_sokak == "")
                        {
                            cadde_sokak = "'" + arg3[i] + "'";
                        }
                        else
                        {
                            cadde_sokak += ",'" + arg3[i] + "'";
                        }
                    }
                }
            }


            string diger = "";
            if (rChkDiger.Text == "İtfaiye")
            {
                diger = "1";
            }
            if (rChkDiger.Text == "Ambulans")
            {
                diger = "2";
            }
            if (rChkDiger.Text == "Öncelikli")
            {
                diger = "True";
            }
            string altolay = "";
            string ilce = "";
            string mahalle = "";
            string cadde = "";
            string ihbarturu = "";
            string durum = "";
            string SiteAdi = "";
            string İcerik = "";

            if (rt_altolay.Value != null)
            {
                if (rt_altolay.Text != "Alt Olay")
                {
                    altolay = rt_altolay.Value.ToString();
                    altolay += "'";
                    altolay = altolay.Insert(0, "'");
                    altolay = altolay.Replace(",", "','");
                    altolay = altolay.Trim().Replace(" ", "");
                }
            }

            if (rt_ilce.Value != null)
            {
                if (rt_ilce.Text != "İlçe")
                {
                    ilce = rt_ilce.Value.ToString();
                    ilce += "'";
                    ilce = ilce.Insert(0, "'");
                    ilce = ilce.Replace(",", "','");
                    ilce = ilce.Trim().Replace(" ", "");
                }
            }

            if (rt_mahalle.Value != null)
            {
                if (rt_mahalle.Text != "Mahalle")
                {
                    mahalle = rt_mahalle.Value.ToString();
                    mahalle += "'";
                    mahalle = mahalle.Insert(0, "'");
                    mahalle = mahalle.Replace(",", "','");
                    mahalle = mahalle.Trim().Replace(" ", "");
                }
            }

            if (rtsk_cadde.Value != null)
            {
                if (rtsk_cadde.Text != "Cadde-Sokak")
                {
                    cadde = rtsk_cadde.Text.ToString().Trim();
                    cadde += "'";
                    cadde = cadde.Insert(0, "'");
                    cadde = cadde.Replace(",", "','");
                    //cadde = cadde.Trim().Replace(" ", "");
                }
            }

            if (rt_ustolay.Value != null)
            {
                if (rt_ustolay.Text != "İhbar Türü")
                {
                    ihbarturu = rt_ustolay.Value.ToString();
                    ihbarturu += "'";
                    ihbarturu = ihbarturu.Insert(0, "'");
                    ihbarturu = ihbarturu.Replace(",", "','");
                    ihbarturu = ihbarturu.Trim().Replace(" ", "");
                }
            }

            if (rChkDurum.Value != null)
            {
                if (rChkDurum.Text != "Durum")
                {
                    durum = rChkDurum.Value.ToString();
                    durum += "'";
                    durum = durum.Insert(0, "'");
                    durum = durum.Replace(",", "','");
                    durum = durum.Trim().Replace(" ", "");
                }
            }


            string saatsorgu = "";
            if (cmbSaat.SelectedIndex != 0)
            {
                switch (cmbSaat.SelectedIndex)
                {
                    case 1:
                        saatsorgu = " and I.I_TARIH between dateadd(hour,-3,getdate()) and getdate()";
                        break;
                    case 2:
                        saatsorgu = " and I.I_TARIH between dateadd(hour,-6,getdate()) and getdate()";
                        break;
                    case 3:
                        saatsorgu = " and I.I_TARIH between dateadd(hour,-12,getdate()) and getdate()";
                        break;
                    case 4:
                        saatsorgu = " and I.I_TARIH between dateadd(hour,-24,getdate()) and getdate()";
                        break;
                    case 5:
                        saatsorgu = " and I.I_TARIH between dateadd(hour,-48,getdate()) and getdate()";
                        break;
                    default:
                        saatsorgu = "";
                        break;
                }
            }


            // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
            if (textEdit1.Text != "Kullanıcı" && textEdit1.Text != "")
            {
                if (saatsorgu == "") // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
                {
                    saatsorgu += " and I.I_TARIH>='" + Tarih1 + " 00:00:00' and I.I_TARIH<='" + Tarih2 + " 23:59:59'";  // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
                }
                saatsorgu += " and I.I_KULLANICI = '" + textEdit1.Text + "'";
            }
            if (txt_SiteAdi.Text != "Site Adı" && txt_SiteAdi.Text != "")
            {
                if (saatsorgu == "") // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
                {
                    saatsorgu += " and I.I_TARIH>='" + Tarih1 + " 00:00:00' and I.I_TARIH<='" + Tarih2 + " 23:59:59'"; // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
                }
                saatsorgu += " and I.I_SITE LIKE '%" + txt_SiteAdi.Text.Trim() + "%'";
            }
            if (txtIcerikArama.Text != "İçerik Arama" && txtIcerikArama.Text != "")
            {
                if (saatsorgu == "") // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
                {
                    saatsorgu += " and I.I_TARIH>='" + Tarih1 + " 00:00:00' and I.I_TARIH<='" + Tarih2 + " 23:59:59'"; // [YahyaSonGuncelleme] = İlk maddedeki date kısımları
                }
                saatsorgu += " and (I.I_ADRES LIKE '%" + txtIcerikArama.Text.Trim() + "%' OR I.I_IHBARBILGISI LIKE '%" + txtIcerikArama.Text.Trim() + "%')";
            }

            gridControl1.DataSource = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPOR_ARAMALISTESI(Tarih1, Tarih2, rTxtIhbarcitel.Text != "İhbarcı Telefonu" ? rTxtIhbarcitel.Text : "", rTxtIhbarciAd.Text != "İhbarcı Adı" ? rTxtIhbarciAd.Text : "", ilce, mahalle, cadde, rTxtPlaka.Text != "Plaka" ? rTxtPlaka.Text : "", ihbarturu, altolay, kanal, log, durum, diger, saatsorgu);
            gridControl1.DataBind();


        }
        public void IhbarRaporKriterleriYukle()
        {
            /*Yahya : !IsPostBack'te olması gerekir.*/
            //rDateBaslama.Date = DateTime.Now.AddDays(-1) ;
            //rDateBitis.Date = DateTime.Now ;

            //rDateBaslama.Value = new DateTime(Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Year, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Month, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Day, 0, 0, 0);
            //rDateBitis.Value = new DateTime(Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Year, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Month, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Day, 23, 59, 59);

            rChkDurum.Items.Clear(); // [YahyaSonGuncelleme] = her postback'te tekrar doldurulduğu için önce içini temizlememiz lazım.
            rChkDurum.Items.Add("");
            rChkDurum.Items.Add("Kayıt");
            rChkDurum.Items.Add("İletilen");
            rChkDurum.Items.Add("Tümü İletilen");
            rChkDurum.Items.Add("A.Kapattı");
            rChkDurum.Items.Add("B.Talebi");
            rChkDurum.Items.Add("G.Arama");
            rChkDurum.Items.Add("EksikIhbar");

            rChkDiger.Items.Clear(); // [YahyaSonGuncelleme] = her postback'te tekrar doldurulduğu için önce içini temizlememiz lazım.
            rChkDiger.Items.Add("");
            rChkDiger.Items.Add("İtfaiye");
            rChkDiger.Items.Add("Ambulans");
            //rChkDiger.Items.Add("İtfaiye");
            rChkDiger.Items.Add("Öncelikli");
            //Filltowns();
            ChannelLoad();
            LOG();
            //rt_mahalle.Value = "";
            //rt_ilce.Value = "";
        }
        private void ChannelLoad()
        {

            // [YahyaSonGuncelleme] = kanal comboboxı gridlookup ile değiştirildi.
            DataTable dt = MK_HelperDataLib.Select.S_KANAL();
            lookKanal.DataSource = dt;
            //rt_kanal.ValueField = "KNL_KODU";
            //rt_kanal.TextField = "KN_ADI";
            lookKanal.DataBind();
        }
        void LOG()
        {
            rChkLog.DataSource = HelperDataLib.Select.S_GETLOG("0");
            rChkLog.ValueField = "ID";
            rChkLog.TextField = "LOGMESAJ";
            rChkLog.DataBind();
        }
        private void VisibleMenuItems()
        {
            if (currentIhbarSon100)
            {
                AltMenu.Items[3].Visible = false;
                AltMenu.Items[4].Visible = false;
            }
            else
            {
                AltMenu.Items[3].Visible = true;
                AltMenu.Items[4].Visible = true;
            }
            if (ihbarType == "GS")
            {
                if (islemDurum == "")
                {
                    AltMenu.Items[3].Visible = false;
                    AltMenu.Items[4].Visible = false;
                }
                else
                {
                    AltMenu.Items[4].Items[0].Visible = false;
                    AltMenu.Items[4].Items[1].Visible = false;
                    AltMenu.Items[4].Items[2].Visible = false;
                    AltMenu.Items[4].Items[3].Visible = false;
                    AltMenu.Items[4].Items[4].Visible = false;
                    AltMenu.Items[4].Items[5].Visible = false;
                    AltMenu.Items[4].Items[6].Visible = false;

                    AltMenu.Items[4].Items[7].Visible = true;
                    AltMenu.Items[4].Items[8].Visible = true;
                    AltMenu.Items[4].Items[9].Visible = true;
                    AltMenu.Items[4].Items[10].Visible = true;
                }
               
            }
            if (ihbarType == "CA")
            {
                AltMenu.Items[1].Visible = false;
                AltMenu.Items[2].Visible = false;
                AltMenu.Items[3].Visible = false;

                AltMenu.Items[4].Items[1].Visible = false;
                AltMenu.Items[4].Items[2].Visible = false;
                AltMenu.Items[4].Items[3].Visible = false;
                AltMenu.Items[4].Items[4].Visible = false;
                AltMenu.Items[4].Items[5].Visible = false;
                AltMenu.Items[4].Items[6].Visible = false;
            }
        }

        private void FillNots()
        {
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_MESAJ(currentIhbarId));
            DataColumn cm = new DataColumn("grouping");
            dt.Columns.Add(cm);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["grouping"] = dt.Rows[i]["IN_TARIHSAAT"].ToString() + " " + dt.Rows[i]["IN_KULLANICI"].ToString() + " " + dt.Rows[i]["IN_OLAYKODU"].ToString();
            }
            gridNots.DataSource = dt;  
            gridNots.GroupBy(gridNots.Columns["grouping"]); 
            gridNots.DataBind();

        }

        private void FillFormDetails()
        { 
            switch (ihbarType)
            {
                case "155":
                    pcDetay.TabPages[0].Enabled = true;
                    pcDetay.TabPages[1].Enabled = false;
                    pcDetay.TabPages[2].Enabled = false;
                    pcDetay.TabPages[3].Enabled = false;
                    FillDetail_155(currentIhbarId);
                    break;
                case "CA":
                    pcDetay.TabPages[0].Enabled = false;
                    pcDetay.TabPages[1].Enabled = true;
                    pcDetay.TabPages[2].Enabled = false;
                    pcDetay.TabPages[3].Enabled = false;
                    FillDetail_STOLEN(currentIhbarId);
                    break;
                case "GS":
                    pcDetay.TabPages[0].Enabled = false;
                    pcDetay.TabPages[1].Enabled = false;
                    pcDetay.TabPages[2].Enabled = true;
                    pcDetay.TabPages[3].Enabled = false;
                    FillDetail_SECURITY(currentIhbarId);
                    break;
                case "ELP":
                    pcDetay.TabPages[0].Enabled = false;
                    pcDetay.TabPages[1].Enabled = false;
                    pcDetay.TabPages[2].Enabled = false;
                    pcDetay.TabPages[3].Enabled = true;
                    FillDetail_ELP(currentIhbarId);
                    break; 
            }
          
           
          
            
        }

        private void FillSelectedKanalGrid()
        {
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_KANAL_TUM("")); 
            gridSelectKanal.DataSource = dt;
            if (txt155Ilcekodu.Text != "") 
                gridSelectKanal.SearchPanelFilter = txt155Ilcekodu.Text.Substring(0, 2) ;
            gridSelectKanal.DataBind();
            
        }


        private void Filltowns(string ihbarTip)
        {
            if (dtTowns == null)
            {
                dtTowns = MK_HelperDataLib.Select.S_ILCE("41");
            }

            switch (ihbarTip)
            {
                case "155":
                    cmb155Ilce.DataSource = dtTowns;
                    cmb155Ilce.ValueField = "ILCEID";
                    cmb155Ilce.TextField = "AD";
                    cmb155Ilce.DataBind();
                    break;
                case "ELP":
                    cmbELPilce.DataSource = dtTowns;
                    cmbELPilce.ValueField = "ILCEID";
                    cmbELPilce.TextField = "AD";
                    cmbELPilce.DataBind();
                    break;
                default:
                    rt_ilce.DataSource = dtTowns;
                    rt_ilce.ValueField = "ILCEID";
                    rt_ilce.TextField = "AD";
                    rt_ilce.DataBind();
                    break;
            }
        }

        private void Filldistricts(string townID, string ihbarTip)
        {
            try
            {
                if (dtDistricts == null)
                {
                    dtDistricts = MK_HelperDataLib.Select.S_Mahalle(townID);
                }

                if (ihbarTip == "155")
                {
                    cmb155Mahalle.DataSource = dtDistricts;
                    cmb155Mahalle.ValueField = "I_MAHID";
                    cmb155Mahalle.TextField = "I_ADI";
                    cmb155Mahalle.DataBind();
                    cmb155Mahalle.Items.Insert(0, new ListEditItem("", ""));
                    cmb155Mahalle.SelectedIndex = 0;
                }
                else if (ihbarTip == "ELP")
                {
                    cmbELPmahalle.DataSource = dtDistricts;
                    cmbELPmahalle.ValueField = "I_MAHID";
                    cmbELPmahalle.TextField = "I_ADI";
                    cmbELPmahalle.DataBind();
                    cmbELPmahalle.Items.Insert(0, new ListEditItem("", ""));
                    cmbELPmahalle.SelectedIndex = 0;

                }

                //rt_mahalle.DataSource = dt;
                //rt_mahalle.ValueField = "I_MAHID";
                //rt_mahalle.TextField = "I_ADI";
                //rt_mahalle.DataBind();
                //rt_mahalle.Items.Insert(0, new ListEditItem("", ""));
                //rt_mahalle.SelectedIndex = 0;
            }
            catch
            { return; }

        }
        private void Fillsubeventload(string ihbarTip)
        {
            if (dtSubevent== null)
            {
                dtSubevent = MK_HelperDataLib.Select.S_ALTOLAY_YUKLE();
            }
           
            switch (ihbarTip)
            {
                case "155":
                    cmb155AltOlayKodu.Items.Clear();
                    cmb155AltOlayKodu.DataSource = dtSubevent;
                    cmb155AltOlayKodu.TextField = "A_IHBAR";
                    cmb155AltOlayKodu.ValueField = "A_ID";
                    cmb155AltOlayKodu.DataBind();
                    break;
                case "ELP":
                    cmbELPaltolaykodu.Items.Clear();
                    cmbELPaltolaykodu.DataSource = dtSubevent;
                    cmbELPaltolaykodu.TextField = "A_IHBAR";
                    cmbELPaltolaykodu.ValueField = "A_ID";
                    cmbELPaltolaykodu.DataBind();
                    break;
                default:
                    rt_altolay.DataSource = dtSubevent;
                    rt_altolay.TextField = "A_IHBAR";
                    rt_altolay.ValueField = "A_ID";
                    rt_altolay.DataBind();
                    break;
            }
        }

        private void Filltopeventload(string ihbarTip)
        {
            if (dtTopevent == null)
            {
                dtTopevent = MK_HelperDataLib.Select.S_USTOLAY_YUKLE();
            }
           
            switch (ihbarTip)
            {
                case "155":
                    cmb155UstOlayKodu.Items.Clear();
                    cmb155UstOlayKodu.DataSource = dtTopevent;
                    cmb155UstOlayKodu.TextField = "U_IHBAR";
                    cmb155UstOlayKodu.ValueField = "U_ID";
                    cmb155UstOlayKodu.DataBind();
                    cmb155UstOlayKodu.Items.Insert(0, new ListEditItem("", ""));
                    break;
                case "ELP":
                    cmbELPustolaykodu.Items.Clear();
                    cmbELPustolaykodu.DataSource = dtTopevent;
                    cmbELPustolaykodu.TextField = "U_IHBAR";
                    cmbELPustolaykodu.ValueField = "U_ID";
                    cmbELPustolaykodu.DataBind();
                    cmbELPustolaykodu.Items.Insert(0, new ListEditItem("", ""));
                    break;
                default:
                    // [YahyaSonGuncelleme] = Ihbar türleri getiriliyor.
                    DataTable dtIhbarTuru = MK_HelperDataLib.Select.S_IHABARGRUP_LISTESI();
                    rt_ustolay.DataSource = dtIhbarTuru;
                    rt_ustolay.TextField = "IH_ADI";
                    rt_ustolay.ValueField = "IH_ID";
                    rt_ustolay.DataBind();
                    rt_ustolay.Items.Insert(0, new ListEditItem("", ""));
                    break;
            }
        }


        private void FillEkipLog()
        { 

            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_EKIPDURUMLISTE(currentIhbarId));
            DataColumn dc = new DataColumn("EG_ULASMATARIH_DURUM");
            DataColumn dc2 = new DataColumn("EG_SONTARIH_DURUM");
            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["EG_ULASMATARIH"].ToString() == "")
                {
                    dt.Rows[i]["EG_ULASMATARIH_DURUM"] = "1";
                    dt.Rows[i]["EG_SONTARIH_DURUM"] = "0";

                }
                else
                {
                    dt.Rows[i]["EG_ULASMATARIH_DURUM"] = "0";
                    dt.Rows[i]["EG_SONTARIH_DURUM"] = "1";
                    
                }
            }

            GridEkip.DataSource = dt;
            GridEkip.DataBind();

        }

       

        private void FillKanalLog()
        {
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LOG(currentIhbarId));
             
            GridKanal.DataSource = dt;
            GridKanal.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["L_ISLEM"].ToString() == "10")
                {
                    islemDurum = "EKIP";
                    break;
                }
            } 
        }

       

       

        protected void btnPlakaArti_Click(object sender, EventArgs e)
        {
            HelperDataLib.MessageBox.Show("kısayol deneme");
        }  
        protected void btnForwardAnotherKanal_Click(object sender, EventArgs e)
        {
            HelperDataLib.MessageBox.Show("Farklı bir kanala yönlendirildi.");
        }

        protected void btnForwardEkip_Click(object sender, EventArgs e)
        {
            HelperDataLib.MessageBox.Show("Ekip yönlendirilme tamamlandı.");
        }

        protected void AltMenu_ItemClick(object source, MenuItemEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "FarkliKanalaYonlendir":
                    RedirectChannel();
                    break;
            }
        }
         
        protected void gridSelectKanal_HtmlFooterCellPrepared(object sender, ASPxGridViewTableFooterCellEventArgs e)
        {
            e.Cell.ColumnSpan = 2;
        }

        protected void btnTamam_Click(object sender, EventArgs e)
        {
            RedirectChannel();
        }

        private void RedirectChannel()
        {
            bool durum = false;
            RedirectDifferentChannel(ref durum);
            if (durum)
            {
                Session["ORDERIHBAR"] = "CALL";
                string script = "CloseIhbar();";
                ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script, true);
            }
        }

        private void RedirectDifferentChannel(ref bool durum)
        {
            List<string> ArrayObjs = new List<string>();
            ArrayObjs.Add("KNL_KODU");
            List<object> ArrayValues = gridSelectKanal.GetSelectedFieldValues(ArrayObjs.ToArray());  
            string activech = "";
            string[] chcount = HttpContext.Current.Session["SS_KANAL"].ToString().Split(',');
            if (chcount.Length > 1)
            {
                activech = kanal;
            }
            else
            {
                activech = HttpContext.Current.Session["SS_KANAL"].ToString();
            }
            for (int i = 0; i < ArrayValues.Count; i++)
            {


                if (yon_durum == "0")
                {
                    MK_HelperDataLib.Insert.I_IHBAR_DETAY(currentIhbarId, ArrayValues[i].ToString(), chk155Ambulans.Checked, chk155Itfaiye.Checked, activech, ref durum);
                    MK_HelperDataLib.Update.U_ISIMSOYISIM_GOSTER_UPDATE(currentIhbarId, chisimGoster.Checked, ref durum);
                    MK_HelperDataLib.Update.U_IHBAR_KAPAT(currentIhbarId, activech, ref durum);
                    if (durum == true)
                    {
                        MK_HelperDataLib.Insert.I_LOG2(currentIhbarId, ArrayValues[i].ToString(), activech, "9", ref durum);
                    }
                }
                if (yon_durum == "1")
                {
                    string kontrol1 = MK_HelperDataLib.Select.S_GetIhbarKontrol(currentIhbarId, ArrayValues[i].ToString());
                    if (kontrol1 == "")
                    {
                        MK_HelperDataLib.Insert.I_IHBAR_DETAY(currentIhbarId, ArrayValues[i].ToString(), chk155Ambulans.Checked, chk155Itfaiye.Checked, activech, ref durum);
                        MK_HelperDataLib.Update.U_IHBAR_KAPAT(currentIhbarId, activech, ref durum);
                        if (durum == true)
                        {
                            string kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, activech, "2");
                            if (kontrol == "")
                            {

                                MK_HelperDataLib.Insert.I_LOG2(currentIhbarId, ArrayValues[i].ToString(), activech, "2", ref durum);

                            }
                        }
                    }
                }

            }
        }

        protected void GridKanal_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
        {
            if (currentIhbarSon100)
            { 
                e.Items.Add("İhbarı Farklı Kanala Yönlendir", "GridKanal_cm_ihbarFarklıKanal", @"images\context\DocumentMap_16x16.png");
                e.Items.Add("Ekip Yönlendir", "GridKanal_cm_ekipYon", @"images\context\Team_16x16.png");
                e.Items.Add("Telsiz Kaydı Dinle", "GridKanal_cm_telsizDinle", @"images\context\megaphone.png");
            }
            else
            {
                e.Items.Add("İhbara Not Ekle", "GridKanal_cm_ihbarNotEkle", @"images\context\note.png");
                e.Items.Add("Takibe Al", "GridKanal_cm_takipAl", @"images\context\follow.png");
                e.Items.Add("Takip Tamamlandı", "GridKanal_cm_takipTamam", @"images\context\followcomplate.png");
                e.Items.Add("Grup Amirinin Takibine", "GridKanal_cm_grupAmirTakip", @"images\context\unfollow.png");
                e.Items.Add("Takip Edilen İhbar İçin Gereği Yapıldı", "GridKanal_cm_takipGeregi", @"images\context\Apply_16x16.png");
                e.Items.Add("İhbarı Farklı Kanala Yönlendir", "GridKanal_cm_ihbarFarklıKanal", @"images\context\DocumentMap_16x16.png");
                e.Items.Add("Ekip Yönlendir", "GridKanal_cm_ekipYon", @"images\context\Team_16x16.png");
                e.Items.Add("Telsiz Kaydı Dinle", "GridKanal_cm_telsizDinle", @"images\context\megaphone.png");
            }
            

        }
        protected void GridKanal_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = GridKanal.GetRowValues(e.ElementIndex, "L_SICILNO").ToString();
            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "GridKanal_cm_ihbarNotEkle":
                    
                    break;
                case "GridKanal_cm_takipAl":
                    FollowIhbar();
                    break;
                case "GridKanal_cm_takipTamam":
                    UnFollowIhbar();
                    break;
                case "GridKanal_cm_grupAmirTakip":
                    
                    break;
                case "GridKanal_cm_takipGeregi":
                    
                    break;
                case "GridKanal_cm_ihbarFarklıKanal":
                    string script = "ShowSelectKanal();";
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script, true);
                    break;
                case "GridKanal_cm_ekipYon":
                    string script2 = "ShowEkipYonlendir();";
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script2, true);
                    break;
                case "GridKanal_cm_telsizDinle":
                    
                    break;
            }
        }
        private void UnFollowIhbar()
        {
            bool durum1 = false;

            MK_HelperDataLib.Delete.D_IHBARTAKIP(currentIhbarId);
            MK_HelperDataLib.Insert.I_IHBARTAKIP(currentIhbarId, 2, ref durum1);
            if (durum1 == true)
            {
                LOGYUKLE(currentIhbarId);
            }
        }

        private void FollowIhbar()
        {
            bool durum = false;

            MK_HelperDataLib.Delete.D_IHBARTAKIP(currentIhbarId);
            MK_HelperDataLib.Insert.I_IHBARTAKIP(currentIhbarId, 1, ref durum);
            if (durum == true)
            {
                LOGYUKLE(currentIhbarId);
            }
        }
        private void LOGYUKLE(string ID)
        {
            try
            {
                GridKanal.DataSource = MK_HelperDataLib.Select.S_GETIHBAR_LOG(ID);
            }
            catch
            {

            }


        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            bool msgdurum = false;
            if (txtmessage.Text != "" && currentIhbarId != "")
            {
                string _altolay = string.Empty;
                if (ihbarType == "155")
                    _altolay = cmb155AltOlayKodu.SelectedItem.Text.ToString();
                else if (ihbarType == "GS")
                     _altolay = I_ALTOLAYADIFORNOTS;
                else if (ihbarType == "CA")
                    _altolay = I_ALTOLAYADIFORNOTS;
                else if (ihbarType == "CA")
                    _altolay = cmbELPaltolaykodu.SelectedItem.Text.ToString();

                MK_HelperDataLib.Insert.I_MESAJ(currentIhbarId, _altolay, txtmessage.Text, ref msgdurum);
                if (msgdurum)
                {
                    FillNots();
                }

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            if (txtplakaguncelle.Text != "")
            {
                bool durum = MK_HelperDataLib.Update.U_PLAKA_GUNCELLE(currentIhbarId, txtplakaguncelle.Text);
            }
            else
            {
                return;
            }
        }
        protected void GridEkip_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e)
        {
            e.Items.Add("Ekip Detaylarını Göster", "GridEkip_cm_ekipDetayGoster", @"images\context\Driving_16x16.png");
            e.Items.Add("İhbar Sonuç Raporu", "GridEkip_cm_ihbarSonucRapor", @"images\context\AddItem_16x16.png");
            e.Items.Add("Ekip İhbar Yerine Ulaştı", "GridEkip_cm_ekipIhbaryerineUlas", @"images\context\Apply_16x16.png");
            e.Items.Add("Ekibi Takip Et", "GridEkip_cm_ekipTakipEt", @"images\context\Show_16x16.png");
            e.Items.Add("Ekibin Görev Rotası", "GridEkip_cm_ekipGorevRota", @"images\context\follow.png");

        }

        protected void GridEkip_ContextMenuItemVisibility(object sender, ASPxGridViewContextMenuItemVisibilityEventArgs e)
        {
            if (e.MenuType == GridViewContextMenuType.Rows)
            {
                GridViewContextMenuItem menuItemUlasmaTarihi = e.Items.Find(item => item.Name == "GridEkip_cm_ekipIhbaryerineUlas") as GridViewContextMenuItem;
                GridViewContextMenuItem menuItemSonucRaporu = e.Items.Find(item => item.Name == "GridEkip_cm_ihbarSonucRapor") as GridViewContextMenuItem;
                for (int i = 0; i < GridEkip.VisibleRowCount; i++)
                {
                    int ulasmadurum = Convert.ToInt32(GridEkip.GetRowValues(i, "EG_ULASMATARIH_DURUM"));
                    e.SetEnabled(menuItemUlasmaTarihi, i,  Convert.ToBoolean(ulasmadurum));

                    int sonucrapordurum = Convert.ToInt32(GridEkip.GetRowValues(i, "EG_SONTARIH_DURUM"));
                    e.SetEnabled(menuItemSonucRaporu, i, Convert.ToBoolean(sonucrapordurum));
                }
            }
        }
        protected void GridEkip_ContextMenuItemClick(object sender, ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = GridEkip.GetRowValues(e.ElementIndex, "EG_ID").ToString();
            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "GridEkip_cm_ekipDetayGoster":
                    
                    break;
                case "GridEkip_cm_ihbarSonucRapor":
                    
                    break;
                case "GridEkip_cm_ekipIhbaryerineUlas":
                    ReachedScene(id);
                    break;
                case "GridEkip_cm_ekipTakipEt":
                    
                    break;
                case "GridEkip_cm_ekipGorevRota":
                    
                    break;
            }
        }

        private void ReachedScene(string Id)
        {

            bool durum = false;
            MK_HelperDataLib.Update.U_IHBAR_EKIP_YONLENDIR_U(Id, ref durum);
            if (durum == true)
            {
                FillEkipLog();

            }
        }
        private void FillDetail_155(string ID)
        {
            try
            {
                bool durum = false;
                string I_ISIMSOYISIM = ""; string I_IL = ""; object I_ILCE = ""; object I_KANAL = ""; object I_MAHALLE = ""; object I_CADDE = ""; string I_SITE = ""; string I_BINA = ""; string I_PLAKA = ""; string I_ADRES = ""; string I_LATITUDE = ""; string I_LONGITUDE = ""; string I_IHBARBILGISI = ""; object I_USTOLAYKODU = ""; object I_ALTOLAYKODU = ""; string I_OPERATORNOT = ""; string I_CINSIYET = ""; string I_YAS = ""; string I_MAIL = ""; string I_DIGERBILGI = ""; string I_TARIH = ""; string I_TELEFON = ""; string I_DAIRE = ""; bool I_ONCELIK = false; string I_BINANO = "";
                string rGuniciArama = ""; string rToplamArama = "";
                MK_HelperDataLib.Select.S_IHBAR_GETDETAY(ID, ref I_TELEFON, ref I_ISIMSOYISIM, ref I_IL, ref I_ILCE, ref I_KANAL, ref I_MAHALLE, ref I_CADDE, ref I_SITE, ref I_BINA, ref I_BINANO, ref I_DAIRE, ref I_PLAKA, ref I_ADRES, ref I_LATITUDE, ref I_LONGITUDE, ref I_IHBARBILGISI, ref I_USTOLAYKODU, ref I_ALTOLAYKODU, ref I_OPERATORNOT, ref I_CINSIYET, ref I_YAS, ref I_MAIL, ref I_DIGERBILGI, ref I_TARIH, ref I_ONCELIK);
                memo155Adres.Text = I_ADRES;
                Filltowns("155");
                Fillsubeventload("155");
                Filltopeventload("155");
                cmb155AltOlayKodu.SelectedItem = cmb155AltOlayKodu.Items.FindByValue(I_ALTOLAYKODU.ToString());
                txt155Daire.Text = I_DAIRE;
                txt155CaddeSok.Text = I_CADDE.ToString();
                rb155_cinsiyet.Value = I_CINSIYET;
                memo155DigerBilg.Text = I_DIGERBILGI;
                memo155Ihbar.Text = I_IHBARBILGISI;
                cmb155Ilce.SelectedItem = cmb155Ilce.Items.FindByValue(I_ILCE.ToString());
                txt155isimSoyisim.Text = I_ISIMSOYISIM;
                txt155Ilcekodu.Text = I_ILCE.ToString();
                Filldistricts(I_ILCE.ToString(), "155");
                cmb155Mahalle.SelectedItem = cmb155Mahalle.Items.FindByValue(I_MAHALLE.ToString());
                txt155Email.Text = I_MAIL;
                memo155OprNotu.Text = I_OPERATORNOT;
                txt155Plaka.Text = I_PLAKA;
                txt155SiteAdi.Text = I_SITE;
                txt155ArayanNo.Text = I_TELEFON;
                cmb155UstOlayKodu.SelectedItem = cmb155UstOlayKodu.Items.FindByValue(I_USTOLAYKODU.ToString());
                t155_yas.Text = I_YAS;
                txt155BinaAdi.Text = I_BINA;
                txt155Bina.Text = I_BINANO;
                txt155_tarih.Date = Convert.ToDateTime(I_TARIH) ;
                chk155OncelikliIslem.Checked = I_ONCELIK;
                MK_HelperDataLib.Select.S_GETTOPLAMCAGRILAR(I_TELEFON, ref rGuniciArama, ref rToplamArama);
                //btn155GuniciArama.Text = MK_HelperDataLib.Select.S_GETTOPLAMCAGRI_GUNLUK(I_TELEFON);
                //btn155ToplamArama.Text = MK_HelperDataLib.Select.S_GETTOPLAMCAGRI(I_TELEFON);
               // rb155_cinsiyet.SelectedItem.Value = rb155_cinsiyet.Items.FindByValue(I_CINSIYET);
                DataTable d = MK_HelperDataLib.Select.S_IHBAR_GETDETAY_DETAY2(ID);
                for (int i = 0; i < d.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(d.Rows[i]["I_AMB"].ToString()))
                    {
                        chk155Ambulans.Checked = Convert.ToBoolean(d.Rows[i]["I_AMB"].ToString());
                    }
                    if (Convert.ToBoolean(d.Rows[i]["I_ITF"].ToString()))
                    {
                        chk155Itfaiye.Checked = Convert.ToBoolean(d.Rows[i]["I_ITF"].ToString());
                    }
                }
                 
                string activech = "";
                string[] chcount = HttpContext.Current.Session["SS_KANAL"].ToString().Split(',');
                if (chcount.Length > 1)
                {
                    activech = kanal;
                }
                else
                {
                    activech = HttpContext.Current.Session["SS_KANAL"].ToString();
                }
                string kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, activech, "1");
                if (kontrol == "")
                {
                    MK_HelperDataLib.Insert.I_LOG(currentIhbarId, activech, "1", ref durum);

                }
                     
               
                if (I_LATITUDE != "" && I_LONGITUDE != "")
                {
                    DataTable dt = MK_HelperDataLib.Select.S_ENYAKIN_KARAKOL_GETIR(Convert.ToDouble(I_LATITUDE), Convert.ToDouble(I_LONGITUDE));
                    if (dt != null)
                    {
                        if (dt.Rows.Count != 0)
                        {
                            enyakinkarakolid = dt.Rows[0][0].ToString();
                        }
                    }
                }


            }
            catch
            {

            }
        }
        private void FillDetail_STOLEN(string ID)
        {
            try
            {
                DataTable d = MK_HelperDataLib.Select.S_GET_CALINTIARAC_DETAY(ID);
                if (d.Rows.Count > 0)
                {
                    txtCalinti_plaka.Text = d.Rows[0]["I_PLAKA"].ToString();
                    txtCalinti_sadecePlaka.Checked = Convert.ToBoolean(d.Rows[0]["I_CALARAC_SADECEPLAKA"].ToString());
                    txtCalinti_rengi.Text = d.Rows[0]["I_CALARAC_RENK"].ToString();
                    txtCalinti_marka.Text = d.Rows[0]["I_CALARAC_MARKA"].ToString();
                    txtCalinti_model.Text = d.Rows[0]["I_CALARAC_MODEL"].ToString();
                    txtCalinti_turu.Text = d.Rows[0]["I_CALARAC_ARACTIP"].ToString();
                    txtCalinti_yil.Text = d.Rows[0]["I_CALARAC_ADET"].ToString();
                    txtCalinti_olayYeriIlce.Text = d.Rows[0]["AD"].ToString();
                    txtCalinti_polisKarakolu.Text = d.Rows[0]["KRK_ISIM"].ToString();
                    txtCalinti_adres.Text = d.Rows[0]["I_ADRES"].ToString();
                    txtCalinti_bilgi.Text = d.Rows[0]["I_IHBARBILGISI"].ToString();
                    txtCalinti_not.Text = d.Rows[0]["I_OPERATORNOT"].ToString();

                    txtCalinti_tarih.Date = Convert.ToDateTime(d.Rows[0]["I_TARIH"].ToString()) ;
                    I_ALTOLAYKODU = d.Rows[0]["I_ALTOLAYKODU"].ToString();
                    I_ALTOLAYADIFORNOTS = d.Rows[0]["I_OLAYADI"].ToString();
                    bool durum = false;
                    string kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, HttpContext.Current.Session["SS_KANAL"].ToString(), "1");
                    if (kontrol == "")
                    {
                        string activech = "";
                        string[] chcount = HttpContext.Current.Session["SS_KANAL"].ToString().Split(',');
                        if (chcount.Length > 1)
                        {
                            activech = kanal;
                        }
                        else
                        {
                            activech = HttpContext.Current.Session["SS_KANAL"].ToString();
                        }
                        MK_HelperDataLib.Insert.I_LOG(currentIhbarId, activech, "1", ref durum);

                    }
                    

                }
            }
            catch
            {

            }
        }
        private void FillDetail_SECURITY(string ID)
        {
            try
            {
                DataTable d = MK_HelperDataLib.Select.S_GETIHBAR_GUVENLIK_DETAY(ID);
                if (d.Rows.Count > 0)
                {
                    memoGuvenlikAboneAdresi.Text = d.Rows[0]["GM_ADRES"].ToString();
                    txtGuvenlikAboneTelefonu.Text = d.Rows[0]["GM_TELEFON"].ToString();
                    txtGuvenlikAlarmTuru.Text = d.Rows[0]["A_ADI"].ToString();
                    txtGuvenlikBinaAdi.Text = d.Rows[0]["I_BINA"].ToString();
                    txtGuvenlikBina.Text = d.Rows[0]["I_BINANO"].ToString();
                    txtGuvenlikDaire.Text = d.Rows[0]["I_DAIRE"].ToString();
                    txtGuvenlikSirketi.Text = d.Rows[0]["G_SIRKETADI"].ToString();
                    cmbGuvenlikGuvenlikIlce.Text = d.Rows[0]["AD"].ToString();
                    cmbGuvenlikGuvenlikMahalle.Text = d.Rows[0]["cmpt_mahalle"].ToString();
                    txtGuvenlikSirketAbonesi.Text = d.Rows[0]["GM_MUSTERIISIM"].ToString();
                    txtGuvenlikSirketGorevlisi.Text = d.Rows[0]["G_IRTIBATISMI"].ToString();
                    txtGuvenlikSirketTelefonu.Text = d.Rows[0]["G_IRTIBATTELEFON"].ToString();
                    txtGuvenlikSiteAdi.Text = d.Rows[0]["I_SITE"].ToString();
                    txtGuvenlikSokak.Text = d.Rows[0]["I_CADDE"].ToString();
                    txtGuvenlik_Tarih.Date = Convert.ToDateTime(d.Rows[0]["I_TARIH"].ToString()) ;
                    memoGuvenlikNot.Text = d.Rows[0]["I_OPERATORNOT"].ToString();
                    I_ALTOLAYKODU = d.Rows[0]["I_ALTOLAYKODU"].ToString();
                    I_ALTOLAYADIFORNOTS = d.Rows[0]["A_IHBAR"].ToString();
                    
                        bool durum = false;
                        string kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, HttpContext.Current.Session["SS_KANAL"].ToString(), "1");
                        if (kontrol == "")
                        {
                            string activech = "";
                            string[] chcount = HttpContext.Current.Session["SS_KANAL"].ToString().Split(',');
                            if (chcount.Length > 1)
                            {
                                activech = kanal;
                            }
                            else
                            {
                                activech = HttpContext.Current.Session["SS_KANAL"].ToString();
                            }
                            MK_HelperDataLib.Insert.I_LOG(currentIhbarId, activech, "1", ref durum);

                        }
                   


                }
            }
            catch
            {

            }

        }
        private void FillDetail_ELP(string ID)
        {
            try
            {
               
                bool durum = false;
                string I_ISIMSOYISIM = ""; string I_IL = ""; object I_ILCE = ""; object I_KANAL = ""; object I_MAHALLE = ""; object I_CADDE = ""; string I_SITE = ""; string I_BINA = ""; string I_PLAKA = ""; string I_ADRES = ""; string I_LATITUDE = ""; string I_LONGITUDE = ""; string I_IHBARBILGISI = ""; object I_USTOLAYKODU = ""; object I_ALTOLAYKODU = ""; string I_OPERATORNOT = ""; string I_CINSIYET = ""; string I_YAS = ""; string I_MAIL = ""; string I_DIGERBILGI = ""; string I_TARIH = ""; string I_TELEFON = ""; string I_DAIRE = ""; bool I_ONCELIK = false; string I_BINANO = "";
                MK_HelperDataLib.Select.S_IHBAR_GETDETAY(ID, ref I_TELEFON, ref I_ISIMSOYISIM, ref I_IL, ref I_ILCE, ref I_KANAL, ref I_MAHALLE, ref I_CADDE, ref I_SITE, ref I_BINA, ref I_BINANO, ref I_DAIRE, ref I_PLAKA, ref I_ADRES, ref I_LATITUDE, ref I_LONGITUDE, ref I_IHBARBILGISI, ref I_USTOLAYKODU, ref I_ALTOLAYKODU, ref I_OPERATORNOT, ref I_CINSIYET, ref I_YAS, ref I_MAIL, ref I_DIGERBILGI, ref I_TARIH, ref I_ONCELIK);
                memoELPadress.Text = I_ADRES; 
                cmbELPaltolaykodu.SelectedItem = cmbELPaltolaykodu.Items.FindByValue(I_ALTOLAYKODU.ToString());
                txtELPdaire.Text = I_DAIRE;
                txtELPcadde.Text = I_CADDE.ToString();
                t_ELP_cinsiyet.Value = I_CINSIYET;
                memoELPdigerbilgiler.Text = I_DIGERBILGI;
                memoELPihbarbilgisi.Text = I_IHBARBILGISI;
                Filltowns("ELP");
                Fillsubeventload("155");
                Filltopeventload("155");
                cmbELPilce.SelectedItem = cmbELPilce.Items.FindByValue(I_ILCE);
                txtELPisim.Text = I_ISIMSOYISIM;
                txtELPilcekod.Text = I_ILCE.ToString();
                Filldistricts(I_ILCE.ToString(), "ELP");
                //Filldistricts(I_ILCE.ToString());
                cmbELPmahalle.SelectedItem = cmbELPmahalle.Items.FindByValue(I_MAHALLE.ToString());
                txtELPmaill.Text = I_MAIL;
                memoELPoperator.Text = I_OPERATORNOT;
                txtELPplaka.Text = I_PLAKA;
                txtELPsiteadi.Text = I_SITE; 
                cmbELPustolaykodu.SelectedItem = cmbELPustolaykodu.Items.FindByValue(I_USTOLAYKODU.ToString());
                t_ELP_yas.Text = I_YAS;
                txtELP_binaadi.Text = I_BINA;
                txtELPbina.Text = I_BINANO;
                txtELPmail_tarih.Date = Convert.ToDateTime(I_TARIH) ;
                chcELPoncelikli.Checked = I_ONCELIK;
                DataTable d = MK_HelperDataLib.Select.S_IHBAR_GETDETAY_DETAY2(ID);
                for (int i = 0; i < d.Rows.Count; i++)
                {

                    chcELPambulans.Checked = Convert.ToBoolean(d.Rows[i]["I_AMB"].ToString());
                    chcELPitfaiye.Checked = Convert.ToBoolean(d.Rows[i]["I_ITF"].ToString());

                }
                
                    if (!ShowDetail)
                    {
                        string activech = "";
                        string[] chcount = HttpContext.Current.Session["SS_KANAL"].ToString().Split(',');
                        if (chcount.Length > 1)
                        {
                            activech = kanal;
                        }
                        else
                        {
                            activech = HttpContext.Current.Session["SS_KANAL"].ToString();
                        }
                        string kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, activech, "1");
                        if (kontrol == "")
                        {
                            MK_HelperDataLib.Insert.I_LOG(currentIhbarId, activech, "1", ref durum);

                        }
                    }
                
                if (I_LATITUDE != "" && I_LONGITUDE != "")
                {
                    DataTable dt = MK_HelperDataLib.Select.S_ENYAKIN_KARAKOL_GETIR(Convert.ToDouble(I_LATITUDE), Convert.ToDouble(I_LONGITUDE));
                    if (dt != null)
                    {
                        if (dt.Rows.Count != 0)
                        {
                            enyakinkarakolid = dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        protected void btn155GuniciArama_Click(object sender, EventArgs e)
        {
            try
            {
                // [YahyaSonGuncelleme] = İlk maddedeki date kısımları

                rDateBaslama.Date = Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).AddDays(-1);
                string Tarih1 = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");
                string Tarih2 = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");

                //string saatsorgu = " and I.I_TARIH>='" + Tarih1 + " 00:00:00' and I.I_TARIH<='" + Tarih2 + " 23:59:59'";

                rTxtIhbarcitel.Text = txt155ArayanNo.Text;

                gridControl1.DataSource = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPOR_ARAMALISTESI(Tarih1, Tarih2, txt155ArayanNo.Text, "", "", "", "", "", "", "", "", "", "", "", "");
                gridControl1.DataBind();

                pcarama_listesi.ShowOnPageLoad = true;


            }
            catch (Exception)
            {

            }
        }

        protected void btn155ToplamArama_Click(object sender, EventArgs e)
        {
            try
            {
                // [YahyaSonGuncelleme] = İlk maddedeki date kısımları

                rDateBaslama.Date = Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).AddYears(-10);
                string Tarih1 = DateTime.Now.AddYears(-10).ToString("MM/dd/yyyy");
                string Tarih2 = DateTime.Now.AddDays(0).ToString("MM/dd/yyyy");

                rTxtIhbarcitel.Text = txt155ArayanNo.Text;

                gridControl1.DataSource = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPOR_ARAMALISTESI(Tarih1, Tarih2, txt155ArayanNo.Text, "", "", "", "", "", "", "", "", "", "", "", "");
                gridControl1.DataBind();

                pcarama_listesi.ShowOnPageLoad = true;
            }
            catch (Exception)
            {

            }
        }

        protected void btn155PlakaCount_Click(object sender, EventArgs e)
        {

        }
 
        void ONAYLA()
        { 
            for (int i = 0; i < lbEkipList.Items.Count; i++)
            {

                if (ViewState["Ekip"] == null)
                {
                    ViewState["Ekip"] = lbEkipList.Items[i].ToString();
                }
                else
                {
                    ViewState["Ekip"] += ";" + lbEkipList.Items[i].ToString();
                }

            }
            if (ViewState["Ekip"] != null)
            {
                EKIPKAYDET();
            }
            else
            {
                return;
            }
        }
        void EKIPKAYDET()
        {
            try
            {

                string activech = "";
                string[] chcount = HttpContext.Current.Session["SS_KANAL"].ToString().Split(',');
                if (chcount.Length > 1)
                {
                    activech = kanal;
                }
                else
                {
                    activech = HttpContext.Current.Session["SS_KANAL"].ToString();
                }
                string[] arg = new string[1000];
                arg = ViewState["Ekip"].ToString().Split(';');
                bool durum = false;
                for (int i = 0; i < arg.Length; i++)
                {
                    string[] arg2 = new string[1000];
                    arg2 = arg[i].ToString().Split(',');

                    string kod = arg2[0];
                    string kontrol = MK_HelperDataLib.Select.S_EKIPKONTROL(arg2[0], currentIhbarId, activech);
                    if (kontrol == "")
                    {
                        MK_HelperDataLib.Insert.I_EKIP_YONLENDIR(arg2[0], currentIhbarId, true, activech, ref durum);
                    }

                    if (durum == true)
                    {

                        if (ihbarType != "GS")
                        {
                            MK_HelperDataLib.Update.U_IHBAR_KAPAT(currentIhbarId, activech, ref durum);
                        }
                        kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, activech, "10");
                        if (kontrol == "")
                        {

                            MK_HelperDataLib.Insert.I_LOG(currentIhbarId, activech, "10", ref durum);
                        }
                        MK_HelperDataLib.Update.U_IHBAR_EKIP_YONLENDIR(currentIhbarId, activech, ref durum);
                        FillEkipLog();
                    }
                }
            }
            catch
            {
                return;
            }
        }
      
        protected void btnOnayla_Click(object sender, EventArgs e)
        {
            ONAYLA();
            Session["ORDERIHBAR"] = "CALL";
            string script = "CloseIhbar();";
            ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script, true);
        }
        protected void ASPxCallback1_Callback(object sender, CallbackEventArgs e)
        {
            IhbarSituations(e.Parameter.ToString());
            Session["ORDERIHBAR"] = "CALL";
            string script = "CloseIhbar();";
            ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script, true);

        }

        void IhbarSituations(string key)
        {
            try
            {
                if (Session["SS_KANAL"] == null)
                    return;
                bool durum = false;
                string activech = "";
                string[] chcount = Session["SS_KANAL"].ToString().Split(',');
                if (chcount.Length > 1)
                {
                    activech = kanal;
                }
                else
                {
                    activech = Session["SS_KANAL"].ToString();
                }
                string kontrol = MK_HelperDataLib.Select.S_LOGKONTROL(currentIhbarId, activech, key);
                if (kontrol == "")
                {

                    MK_HelperDataLib.Update.U_IHBAR_KAPAT(currentIhbarId, activech, ref durum);

                    MK_HelperDataLib.Insert.I_LOG(currentIhbarId, activech, key, ref durum);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(MK_HelperDataLib.Log.InsertErrorLogAndShowErrorMessage("Kanal Ihbar Detay", "ihbarDurumları", ex.Message), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void gridEkipList_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }

        

        protected void gridEkipList_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("EK_KODU").ToString() == "")
            {
                e.Row.Visible = false;
            }
        }

        protected void gridSelectKanal_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("KNL_ID").ToString() == "")
            {
                e.Row.Visible = false;
            }
        }

        protected void GridKanal_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            if (e.DataColumn.FieldName == "LOGMESAJ")
            {
                if (e.CellValue != null)
                {
                    e.Cell.ToolTip = e.CellValue.ToString();
                    int len = e.CellValue.ToString().Length;
                    string text = e.CellValue.ToString();
                    e.Cell.Text = text.Substring(0, len > 30 ? 30 : len) + "..";
                }
            }
                  
        }

        protected void btnSonucRaporuTamam_Click(object sender, EventArgs e)
        {
            string ekkodu = GridEkip.GetRowValues(GridEkip.FocusedRowIndex, "EG_EKKODU").ToString();
            string ekid = GridEkip.GetRowValues(GridEkip.FocusedRowIndex, "EG_ID").ToString();
            
            bool durum = false;
            if (txtSonucRaporu.Text != "")
            {
                MK_HelperDataLib.Insert.I_IHBARKAPAT(txtSonucRaporu.Text, currentIhbarId, ekkodu, rbIhbarSonuc.SelectedItem.Text, Session["SS_KANAL"].ToString(), ref durum);
                if (durum == true)
                {
                    MK_HelperDataLib.Update.U_IHBAR_EKIP_YONLENDIR_U3(currentIhbarId, ref durum);
                    MK_HelperDataLib.Update.U_IHBAR_EKIP_YONLENDIR_S(ekid, ref durum);
                    if (durum == true)
                    {
                        MK_HelperDataLib.Update.U_IHBAR_EKIP_IHBARKAPAT(currentIhbarId, ekkodu, ref durum);
                    }
                    if (durum == true)
                    {
                        FillEkipLog();
                    }
                }
            }
        }

        protected void ASPxMenu1_ItemDataBound(object source, MenuItemEventArgs e)
        {

            bool Oku = false; bool Yaz = false; bool Sil = false;
            MK_HelperDataLib.Select.S_GetFormYetki(MK_HelperDataLib.StatikData.SS_YETKIID, "502", ref Oku, ref Yaz, ref Sil);
            if (Oku == true)
            {
                if (e.Item.Text == "Yukle")
                {
                    e.Item.Enabled = true;
                }
            }
            if (Yaz == true)
            {
                if (e.Item.Text == "ExceleAktar")
                {
                    e.Item.Enabled = true;
                }

                if (e.Item.Text == "Yazdir")
                {
                    e.Item.Enabled = true;
                }

            }
            if (Sil == true)
            {

            }


        }

        protected void ASPxMenu1_ItemClick1(object source, MenuItemEventArgs e)
        {
            if (e.Item.Name == "Yukle")
            {
                try
                {
                    CallList();
                }
                catch (Exception ex)
                {

                }
            }
            else if (e.Item.Name == "ExceleAktar")
            {
                ASPxGridViewExporter1.GridViewID = "gridControl1";
                ASPxGridViewExporter1.FileName = "Raporları" + "_" + DateTime.Now;
                ASPxGridViewExporter1.WriteXlsxToResponse();
            }
            else if (e.Item.Name == "Yazdir")
            {
                if (gridControl1.VisibleRowCount > 0)
                {
                    ASPxGridViewExporter gvExporter = new ASPxGridViewExporter();
                    gvExporter.ID = "gridControl1";
                    gvExporter.GridViewID = "ASPxGridViewExporter1";
                    gvExporter.DataBind();
                }
                else { return; }
            }
            else if (e.Item.Name == "Temizle")
            {
                rt_altolay.Value = 0;
                rt_ilce.Value = 0;
               // rt_kanal.Value = 0;
                rt_ustolay.Value = 0;
                rt_ustolay.Text = "İhbar Türü";
                rDateBaslama.Value = new DateTime(Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Year, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Month, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Day, 0, 0, 0);
                rDateBitis.Value = new DateTime(Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Year, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Month, Convert.ToDateTime(MK_HelperDataLib.GetTime.Time()).Day, 23, 59, 59);
                rChkDurum.Text = "Durum";
                rChkDiger.Text = "Diğer";
                rChkLog.Text = "Log";
                rTxtIhbarcitel.Text = "İhbarcı Telefonu";
                rTxtIhbarciAd.Text = "İhbarcı Adı";
                rtsk_cadde.Text = "Cadde-Sokak";
                rt_mahalle.Value = 0;
                rt_mahalle.Text = "Mahalle";
                rt_mahalle.Value = "";
                rt_mahalle.Text = "";
                rTxtPlaka.Text = "Plaka";
                gridControl1.DataSource = null;
                cmbSaat.SelectedIndex = 0;
                lookKanal.Text = "Kanal";
                rChkLog.Text = "Log";
                rt_ilce.Text = "İlçe";
                rt_altolay.Text = "Alt Olay";
                textEdit1.Text = "Kullanıcı";
            }
            else { return; }
        }


        protected void rt_mahalle_Callback(object sender, CallbackEventArgsBase e)
        {
            Mahalleler(e.Parameter);

            rtsk_cadde.DataSource = null;
            rtsk_cadde.DataBind();
        }

        protected void rtsk_cadde_Callback(object sender, CallbackEventArgsBase e)
        {
            string ilceId = e.Parameter.Split('|')[0];
            string mahalleId = e.Parameter.Split('|')[1];

            Caddeler(ilceId, mahalleId);
        }

        void Mahalleler(string ilceId)
        {
            try
            {
                DataTable dt = HelperDataLib.Select.S_Mahalle(ilceId);
                rt_mahalle.DataSource = dt;
                rt_mahalle.ValueField = "I_MAHID";
                rt_mahalle.TextField = "I_ADI";
                rt_mahalle.DataBind();
                rt_mahalle.Items.Insert(0, new ListEditItem("", ""));
                rt_mahalle.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }

        void Caddeler(string ilceId, string mahalleId)
        {
            try
            {
                DataTable dt = HelperDataLib.Select.S_CADDE(ilceId, mahalleId);
                rtsk_cadde.DataSource = dt;
                rtsk_cadde.ValueField = "I_ad";
                rtsk_cadde.TextField = "I_ad";
                rtsk_cadde.DataBind();
                rtsk_cadde.Items.Insert(0, new ListEditItem("", ""));
                rtsk_cadde.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                bool durum1 = false;
                HelperDataLib.Log.I_LOG("YKS YONETIM-" + System.Reflection.MethodBase.GetCurrentMethod().Name + " : " + ex.Message.ToString(), "I_ERRORLOG", ref durum1);
            }
        }
        

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            gridNots.Font.Size = 11;
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            gridNots.Font.Size = 13;
        }
    }
}