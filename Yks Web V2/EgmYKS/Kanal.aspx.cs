using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using DevExpress.Web;
using MK_HelperDataLib;
using Newtonsoft.Json;
using EgmYKS.Helper;
using System.Web.UI.HtmlControls;

namespace EgmYKS.IHBAR
{
    public partial class Kanal : System.Web.UI.Page
    {
        public int _155Count = 0, GSCount = 0, CARCount = 0, ELPCount = 0, SON50=0;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsCallback | IsPostBack)
            {
                return;
            }
             
            if (Session["SS_KANAL"] == null)
            {
                FillSelectedKanalGrid();
                ASPxGlobalEvents1.Enabled = true;
            }
            else if (Session["SS_KANAL"].ToString() == "")
            {
                FillSelectedKanalGrid();
                ASPxGlobalEvents1.Enabled = true;
            }
            else
            {
                ASPxGlobalEvents1.Enabled = false;
                PreparePage();
            }
            if (Session["ORDERIHBAR"].ToString() == "CALL")
            {
                CallOrderIhbar();
            }

            if (!IsPostBack)
            {
                rDateBaslama.Date = DateTime.Now.AddDays(0);
                rDateBitis.Date = DateTime.Now.AddDays(0);
            }

            /* Yahya - Benim ihbarlarım popupındaki filtrelerin default değerleri dolduruluyor. [Yahya=benim_ihbarlarim]*/
            benimIhbarlarimFiltreDoldur();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void CallOrderIhbar()
        {
            string p1 = string.Empty, p2 = string.Empty;
            Session["ORDERIHBAR"] = "UNCALL";
            if (GSCount > 0 )
            {
                for (int i = 0; i < GSCount; i++)
                {
                    string Deger =  gridGsa.GetRowValues(i, "cmpt_islemdurum").ToString() ; 
                    if (Deger != "1" & Deger != "10")
                    {
                        p1 = gridGsa.GetRowValues(i, "I_ID").ToString();
                        p2 = gridGsa.GetRowValues(i, "I_KANAL").ToString();
                        break;
                    } 
                }
            
            }
            if (p1 == string.Empty & p2 == string.Empty)
            {
                if (ELPCount > 0)
                {
                    p1 = gridElp.GetRowValues(0, "I_ID").ToString();
                    p2 = gridElp.GetRowValues(0, "I_KANAL").ToString();
                }
                else if (CARCount > 0)
                {
                    p1 = gridCar.GetRowValues(0, "I_ID").ToString();
                    p2 = gridCar.GetRowValues(0, "I_KANAL").ToString();
                }
                else if (_155Count > 0)
                {
                    p1 = grid155.GetRowValues(0, "I_ID").ToString();
                    p2 = grid155.GetRowValues(0, "I_KANAL").ToString();
                }
            }
           
            string script = "window.open('KanalIhbarDetay.aspx?IhbarId=" + p1 + "&SON100=0&IHBARKANAL=" + p2 + "')";
            ClientScript.RegisterStartupScript(this.Page.GetType(), "fnct", script, true);
        }

        private void PreparePage()
        {
            lblAktifKanallar.Text = Session["SS_KANAL_ADI"].ToString();
            FillGrids(); 
            LOAD_FUNC();
            ARACTAKIP_LISTE();
            
        }

      
        /*void ARACTAKIP_LISTE()
        {
            try
            {
                gridTerminals.DataSource = MK_HelperDataLib.Select.getTerminals(41.0628408, 28.9869915, 10000);
                gridTerminals.DataBind();
            }
            catch (Exception c)
            {
                return;
            }
        }*/

        void ARACTAKIP_LISTE(double LON = 28.9869915, double LAT= 41.0628408, int KM= 10000)
        {
            LON = LON == null ? 28.9869915 : LON;
            LAT = LAT == null ? 41.0628408 : LAT;
            KM = KM == null ? 10000 : KM;
            try
            {
                gridTerminals.DataSource = MK_HelperDataLib.Select.getTerminals(LAT, LON, KM);
                gridTerminals.DataBind();
            }
            catch (Exception c)
            {
                return;
            }
        }


        private void FillGrids()
        {
            FillIhbar155Grid();
            FillIhbarCARGrid();
            FillIhbarGSGrid();
            FillIhbarELPGrid();
            FillIhbarLast50();
        }

        private void FillIhbarLast50()
        {
            if (pageControlIc.ActiveTabIndex == 4)
            {
                DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL_KAPALI());
                pageControlIc.TabPages[4].Text = "SON100 (" + dt.Rows.Count.ToString() + ")";
                if (SON50 != dt.Rows.Count)
                {
                    SON50 = dt.Rows.Count;
                    gridSon50.DataSource = dt;
                    gridSon50.DataBind();
                }
            }
        }

        private void FillIhbarELPGrid()
        {
            if (pageControlIc.ActiveTabIndex == 3)
            {
                DataTable dt = GridDoldur("ELP");
                pageControlIc.TabPages[3].Text = "ELP(" + dt.Rows.Count.ToString() + ")";
                if (ELPCount != dt.Rows.Count)
                {
                    ELPCount = dt.Rows.Count;
                    gridElp.DataSource = dt;
                    gridElp.DataBind();
                }
            }
        }

        private void FillIhbarGSGrid()
        {
            if (pageControlIc.ActiveTabIndex == 2)
            {
                DataTable dt = GridDoldur("GS");
                pageControlIc.TabPages[2].Text = "GŞA(" + dt.Rows.Count.ToString() + ")";

                if (GSCount != dt.Rows.Count)
                {
                    GSCount = dt.Rows.Count;
                    gridGsa.DataSource = dt;
                    gridGsa.DataBind();
                }
            }
        }

        private void FillIhbarCARGrid()
        {
            if (pageControlIc.ActiveTabIndex == 1)
            {
                DataTable dt = GridDoldur("CA");
                pageControlIc.TabPages[1].Text = "ÇAR(" + dt.Rows.Count.ToString() + ")";

                if (CARCount != dt.Rows.Count)
                {
                    CARCount = dt.Rows.Count;
                    gridCar.DataSource = dt;
                    gridCar.DataBind();
                }
            }
        }

        private void FillIhbar155Grid()
        {
            if (pageControlIc.ActiveTabIndex == 0)
            {
                DataTable dt = GridDoldur("155");
                pageControlIc.TabPages[0].Text = "155 Gelen İhbarlar(" + dt.Rows.Count.ToString() + ")";
                //if (_155Count != dt.Rows.Count)
                //{
                   // _155Count = dt.Rows.Count;
                    grid155.DataSource = dt;
                    grid155.DataBind();
                //}
            }
        }

        private DataTable GridDoldur(string tip)
        {
            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " +
                            "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL(Tarih1, Tarih2, tip));
            return dt;
        }

        private void LOAD_FUNC()
        {

            FillMapShortCutTab();
            TOWN_LOAD();
        }

        void FillAdressTab()
        {
            try
            {
                gridAdresAra.DataSource = null;
                gridAdresAra.DataSource = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_ADRESARAMA(adresAratxt.Text));
                gridAdresAra.Columns["ILCEADI"].VisibleIndex = 0;
                gridAdresAra.DataBind();
            }
            catch
            {

            }
        }

        void FillMapShortCutTab()
        {
            try
            {
                gridHrtKsyl.DataSource = null;
                gridHrtKsyl.DataSource = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_KISAYOL_GETIR());
                gridHrtKsyl.Columns["MKYG_ADI"].VisibleIndex = 0;
                gridHrtKsyl.DataBind();
            }
            catch
            {

            }
        }


        void TOWN_LOAD()
        {
            try
            {
                gridCombo.DataSource = MK_HelperDataLib.Select.S_ILCE("41"); 
                gridCombo.DataBind();
            }
            catch
            {}
        }

        void FillCameraTab()
        {

            try
            {

                DataTable Cam = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_KAMERALISTES_GETIR_KAMERAADI(btnKmrAra.Text));
                gridKmrListe.DataSource = Cam;
                gridKmrListe.DataBind();
            }
            catch
            {}
        }

        protected void adresAratxt_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
        {
            
        }

        protected void btnKmrAra_ButtonClick(object source, DevExpress.Web.ButtonEditClickEventArgs e)
        {
            FillCameraTab();
        }


        #region CONTEXTMENU

        

        protected void grid155_ContextMenuItemClick(object sender, DevExpress.Web.ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = grid155.GetRowValues(e.ElementIndex, "I_ID").ToString(); 

            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "grid155_cm_ihbarAc":
                    
                    break;
                case "grid155_cm_ihbarDetay":
                    
                    break;
                case "grid155_cm_haritaGoster":
                    
                    break;
                case "grid155_cm_ihbarNot":
                    
                    break;
                case "grid155_cm_telGelenIhbar":
                    
                    break;
                case "grid155_cm_IhbarciGelenIhbar":
                    
                    break;
                case "grid155_cm_benimIhbar":
                    scriptYazdir("<script type='text/javascript'>txtKullanici.SetValue('text');</script>");

                    break;
                case "grid155_cm_kanalIhbar":
                    
                    break;
                case "grid155_cm_ihbarSorgu":
                    
                    break;
                case "grid155_cm_takipIhbar":
                    
                    break;
                case "grid155_cm_takipAl":
                    FollowIhbar(id);
                    break;
                case "grid155_cm_takipTamam":
                    UnFollowIhbar(id);
                    break;
                case "grid155_cm_grupAmirTakip":
                    GroupFollowIhbar(id);
                    break;
                case "grid155_cm_listeGuncelle":
                    
                    break;
                case "grid155_cm_excelAktar":

                   
                        grd_155.GridViewID = "grid155";
                        grd_155.FileName = "155_İhbar Liste " + "_" + DateTime.Now;
                        grd_155.WriteXlsxToResponse();

                    break;
            }

        }
        private void GroupFollowIhbar(string currentIhbarId)
        {
            bool durum1 = false;
            MK_HelperDataLib.Delete.D_IHBARTAKIP(currentIhbarId);
            MK_HelperDataLib.Insert.I_IHBARTAKIP(currentIhbarId, 3, ref durum1);

        }
        private void UnFollowIhbar(string currentIhbarId)
        {
            bool durum1 = false;

            MK_HelperDataLib.Delete.D_IHBARTAKIP(currentIhbarId);
            MK_HelperDataLib.Insert.I_IHBARTAKIP(currentIhbarId, 2, ref durum1);
            
        }

        private void FollowIhbar(string currentIhbarId)
        {
            bool durum = false;

            MK_HelperDataLib.Delete.D_IHBARTAKIP(currentIhbarId);
            MK_HelperDataLib.Insert.I_IHBARTAKIP(currentIhbarId, 1, ref durum);
            if (durum)
            {
                grid155_CustomCallback(grid155, new ASPxGridViewCustomCallbackEventArgs(""));
            }
             
        }
        protected void gridHrtKsyl_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridViewContextMenuEventArgs e)
        {
            e.Items.Add("Kısayolu Sil", "gridHrtKsyl_cm_kisayolSil", @"images\Apply_16x16.png");
        }

        protected void gridHrtKsyl_ContextMenuItemClick(object sender, DevExpress.Web.ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = gridHrtKsyl.GetRowValues(e.ElementIndex, "MRK_ID").ToString();

            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "gridHrtKsyl_cm_kisayolSil":
                    Shortcut_DEL(id);
                    break;
            }
        }
        protected void Shortcut_DEL(string MRKID)
        {
            try
            {
                bool durum = false;
                MK_HelperDataLib.Delete.D_MARKER_KISAYOL(MRKID, ref durum);
                if (durum == true)
                {
                    Kisayollistegetir();
                    FillMapShortCutTab();
                }
                else
                {

                }
            }
            catch
            {
                return;
            }
        }
        protected void gridCar_ContextMenuItemClick(object sender, DevExpress.Web.ASPxGridViewContextMenuItemClickEventArgs e)
        {

            string id = gridCar.GetRowValues(e.ElementIndex, "I_ID").ToString();

            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "gridCar_cm_ihbarAc":
                    
                    break;
                case "gridCar_cm_ihbarDetay":
                    
                    break;
                case "gridCar_cm_haritaGoster":
                    
                    break;
                case "gridCar_cm_ihbarNot":
                    
                    break;
                case "gridCar_cm_telGelenIhbar":
                    
                    break;
                case "gridCar_cm_IhbarciGelenIhbar":
                    
                    break;
                case "gridCar_cm_benimIhbar":
                    
                    break;
                case "gridCar_cm_kanalIhbar":
                    
                    break;
                case "gridCar_cm_ihbarSorgu":
                    
                    break;
                case "gridCar_cm_takipIhbar":
                    
                    break;
                case "gridCar_cm_takipAl":
                    
                    break;
                case "gridCar_cm_takipTamam":
                    
                    break;
                case "gridCar_cm_grupAmirTakip":
                    
                    break;
                case "gridCar_cm_listeGuncelle":
                    
                    break;
                case "gridCar_cm_excelAktar":
                    grid_car.GridViewID = "gridCar";
                    grid_car.FileName = "Car_İhbar Liste " + "_" + DateTime.Now;
                    grid_car.WriteXlsxToResponse();
                    break;
            }
        }

        private static void FillContextMenuDoldur(ASPxGridViewContextMenuEventArgs e, string menuName)
        {
            e.Items.Add("İhbarı Aç", menuName + "_cm_ihbarAc", @"images\context\EmailTemplate_16x16.png");
            e.Items.Add("İhbar Detayları", menuName + "_cm_ihbarDetay", @"images\context\detail.png");
            e.Items.Add("Haritada Göster", menuName + "_cm_haritaGoster", @"images\context\map.png");
            e.Items.Add("İhbara Not Ekle", menuName + "_cm_ihbarNot", @"images\context\note.png");
            e.Items.Add("Telefondan Gelen Notlar", menuName + "_cm_telGelenIhbar", @"images\context\phone.png");
            e.Items.Add("İhbarcıdan Gelen İhbarlar", menuName + "_cm_IhbarciGelenIhbar", @"images\context\person.png");
            e.Items.Add("Benim İhbarlarım(48 Saat)", menuName + "_cm_benimIhbar", @"images\context\annocument.png");
            e.Items.Add("Kanalın İhbarları(24 Saat)", menuName + "_cm_kanalIhbar", @"images\context\channel.png");
            e.Items.Add("İhbar Sorgu", menuName + "_cm_ihbarSorgu", @"images\context\question.png");
            e.Items.Add("Takibe Alınmış İhbarlarım", menuName + "_cm_takipIhbar", @"images\context\gps.png");
            e.Items.Add("Takibe Al", menuName + "_cm_takipAl", @"images\context\follow.png");
            e.Items.Add("Takip Tamamlandı", menuName + "_cm_takipTamam", @"images\context\followcomplate.png");
            e.Items.Add("Grup Amirinin Takibine", menuName + "_cm_grupAmirTakip", @"images\context\unfollow.png");
            e.Items.Add("Listeyi Güncelle", menuName + "_cm_listeGuncelle", @"images\context\Refresh_16x16.png");
            e.Items.Add("Excele Aktar", menuName + "_cm_excelAktar", @"images\context\exportexcell.png");
        }

        protected void grid155_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridViewContextMenuEventArgs e)
        {
            FillContextMenuDoldur(e, "grid155");
        }
        protected void gridCar_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridViewContextMenuEventArgs e)
        {
            FillContextMenuDoldur(e, "gridCar");
        }
        protected void gridGsa_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridViewContextMenuEventArgs e)
        {
            FillContextMenuDoldur(e, "gridGsa");
        }
        protected void gridGsa_ContextMenuItemClick(object sender, DevExpress.Web.ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = gridGsa.GetRowValues(e.ElementIndex, "I_ID").ToString();

            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "gridGsa_cm_ihbarAc":
                    
                    break;
                case "gridGsa_cm_ihbarDetay":
                    
                    break;
                case "gridGsa_cm_haritaGoster":
                    
                    break;
                case "gridGsa_cm_ihbarNot":
                    
                    break;
                case "gridGsa_cm_telGelenIhbar":
                    
                    break;
                case "gridGsa_cm_IhbarciGelenIhbar":
                    
                    break;
                case "gridGsa_cm_benimIhbar":
                    
                    break;
                case "gridGsa_cm_kanalIhbar":
                    
                    break;
                case "gridGsa_cm_ihbarSorgu":
                    
                    break;
                case "gridGsa_cm_takipIhbar":
                    
                    break;
                case "gridGsa_cm_takipAl":
                    
                    break;
                case "gridGsa_cm_takipTamam":
                    
                    break;
                case "gridGsa_cm_grupAmirTakip":
                    
                    break;
                case "gridGsa_cm_listeGuncelle":
                    
                    break;
                case "gridGsa_cm_excelAktar":

                    grid_gsa.GridViewID = "gridGsa";
                    grid_gsa.FileName = "Gsa_İhbar Liste " + "_" + DateTime.Now;
                    grid_gsa.WriteXlsxToResponse();
                    break;
            }
        }
        protected void gridElp_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridViewContextMenuEventArgs e)
        {
            FillContextMenuDoldur(e, "gridElp");
        }
        protected void gridElp_ContextMenuItemClick(object sender, DevExpress.Web.ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = gridElp.GetRowValues(e.ElementIndex, "I_ID").ToString();

            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "gridElp_cm_ihbarAc":
                    
                    break;
                case "gridElp_cm_ihbarDetay":
                    
                    break;
                case "gridElp_cm_haritaGoster":
                    
                    break;
                case "gridElp_cm_ihbarNot":
                    
                    break;
                case "gridElp_cm_telGelenIhbar":
                    
                    break;
                case "gridElp_cm_IhbarciGelenIhbar":
                    
                    break;
                case "gridElp_cm_benimIhbar":
                    
                    break;
                case "gridElp_cm_kanalIhbar":
                    
                    break;
                case "gridElp_cm_ihbarSorgu":
                    
                    break;
                case "gridElp_cm_takipIhbar":
                    
                    break;
                case "gridElp_cm_takipAl":
                    
                    break;
                case "gridElp_cm_takipTamam":
                    
                    break;
                case "gridElp_cm_grupAmirTakip":
                    
                    break;
                case "gridElp_cm_listeGuncelle":
                    
                    break;
                case "gridElp_cm_excelAktar":

                    grid_elp.GridViewID = "gridElp";
                    grid_elp.FileName = "Elp_İhbar Liste " + "_" + DateTime.Now;
                    grid_elp.WriteXlsxToResponse();
                    break;
            }
        }      
        protected void gridSon50_FillContextMenuItems(object sender, DevExpress.Web.ASPxGridViewContextMenuEventArgs e)
        {
            FillContextMenuDoldur(e, "gridSon50");
        }
        protected void gridSon50_ContextMenuItemClick(object sender, DevExpress.Web.ASPxGridViewContextMenuItemClickEventArgs e)
        {
            string id = gridSon50.GetRowValues(e.ElementIndex, "I_ID").ToString();

            switch (e.Item.Name) // NewRow EditRow DeleteRow Refresh
            {
                case "gridSon50_cm_ihbarAc":
                    
                    break;
                case "gridSon50_cm_ihbarDetay":
                    
                    break;
                case "gridSon50_cm_haritaGoster":
                    
                    break;
                case "gridSon50_cm_ihbarNot":
                    
                    break;
                case "gridSon50_cm_telGelenIhbar":
                    
                    break;
                case "gridSon50_cm_IhbarciGelenIhbar":
                    
                    break;
                case "gridSon50_cm_benimIhbar":
                    
                    break;
                case "gridSon50_cm_kanalIhbar":
                    
                    break;
                case "gridSon50_cm_ihbarSorgu":
                    
                    break;
                case "gridSon50_cm_takipIhbar":
                    
                    break;
                case "gridSon50_cm_takipAl":
                    
                    break;
                case "gridSon50_cm_takipTamam":
                    
                    break;
                case "gridSon50_cm_grupAmirTakip":
                    
                    break;
                case "gridSon50_cm_listeGuncelle":
                    
                    break;
                case "gridSon50_cm_excelAktar":

                    grid_son50.GridViewID = "gridSon50";
                    grid_son50.FileName = "SON50_İhbar Liste " + "_" + DateTime.Now;
                    grid_son50.WriteXlsxToResponse();
                    break;
            }
        }
        #endregion

        protected void gridTerminals_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] _params = e.Parameters.ToString().Split(',');
            if (_params.Length != 0)
            {
               
                Double Lon = double.Parse(_params[0], System.Globalization.CultureInfo.InvariantCulture);
                Double Lat = double.Parse(_params[1], System.Globalization.CultureInfo.InvariantCulture);
                int Km = int.Parse(_params[2]);
                ARACTAKIP_LISTE(Lon, Lat, Km);
            }
        }

        /*protected void Callbackpanel_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(FillGrids));
            //thread.IsBackground = true;
            //thread.Start();
            //FillGrids();

            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " + "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL(Tarih1, Tarih2, "155"));
            if (grid155.VisibleRowCount != dt.Rows.Count)
            {
                grid155_CustomCallback(grid155, new ASPxGridViewCustomCallbackEventArgs(""));
            }
        }*/

        protected void Callbackpanel_Callback(object sender, CallbackEventArgsBase e)
        {
            /*if (e == null)
           {
               return;
           }*/

            string tipList = "'155', 'CA', 'GS', 'ELP'";

            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " + "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL_KONTROL(Tarih1, Tarih2, tipList));

            if (dt.Rows.Count > 0)
            {
                //_155Count = 0, GSCount = 0, CARCount = 0, ELPCount = 0, SON50
                DataRow[] dr155 = dt.Select("I_IHBARTUR = '155'");
                DataRow[] drCA = dt.Select("I_IHBARTUR = 'CA'");
                DataRow[] drGS = dt.Select("I_IHBARTUR = 'GS'");
                DataRow[] drELP = dt.Select("I_IHBARTUR = 'ELP'");

                if (dr155.Length > 0)
                {
                    _155Count = (int)dr155[0]["IHBARSAYISI"];
                }
                if (drCA.Length > 0)
                {
                    CARCount = (int)drCA[0]["IHBARSAYISI"];
                }
                if (drGS.Length > 0)
                {
                    GSCount = (int)drGS[0]["IHBARSAYISI"];
                }
                if (drELP.Length > 0)
                {
                    ELPCount = (int)drELP[0]["IHBARSAYISI"];
                }

                int _155CountSession = (int?)Session["_155Count"] ?? 0;
                int CARCountSession = (int?)Session["CARCount"] ?? 0;
                int GSCountSession = (int?)Session["GSCount"] ?? 0;
                int ELPCountSession = (int?)Session["ELPCount"] ?? 0;

                pageControlIc.TabPages[0].Text = "155 Gelen İhbarlar(" + _155Count.ToString() + ")";
                pageControlIc.TabPages[1].Text = "ÇAR(" + CARCount.ToString() + ")";
                pageControlIc.TabPages[2].Text = "GS(" + GSCount.ToString() + ")";
                pageControlIc.TabPages[3].Text = "ELP(" + ELPCount.ToString() + ")";

                if (_155CountSession != _155Count && pageControlIc.ActiveTabIndex == 0)
                {
                    Session["_155Count"] = _155Count;
                    FillIhbar155Grid();
                }
                else if (CARCountSession != CARCount && pageControlIc.ActiveTabIndex == 1)
                {
                    Session["CARCount"] = CARCount;
                    FillIhbarCARGrid();
                }
                else if (GSCountSession != GSCount && pageControlIc.ActiveTabIndex == 2)
                {
                    Session["GSCount"] = GSCount;
                    FillIhbarGSGrid();
                }
                else if (ELPCountSession != ELPCount && pageControlIc.ActiveTabIndex == 3)
                {
                    Session["ELPCount"] = ELPCount;
                    FillIhbarELPGrid();
                }
            }
        }
       


        protected void grid155_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.VisibleIndex >= 0)
            {
                string category = grid155.GetRowValues(e.VisibleIndex, "I_ONCELIKLI").ToString();
                if (category == "Checked")
                {
                    e.Row.BackColor = Color.DarkRed;
                }
                string category2 = grid155.GetRowValues(e.VisibleIndex, "cmpt_count").ToString();
                category2 = category2 == "" ? "0" : category2;
                if (Convert.ToInt32(category2) > 1)
                {
                    string category3 = grid155.GetRowValues(e.VisibleIndex, "cmpt_count2").ToString();
                    string category4 = grid155.GetRowValues(e.VisibleIndex, "I_ID").ToString();
                    if (category3 == category4)
                    {
                        e.Row.BackColor = Color.PaleGreen;
                    }
                }
            }
        }

        protected void gridCar_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.VisibleIndex >= 0)
            {
                string category = gridCar.GetRowValues(e.VisibleIndex, "I_ONCELIKLI").ToString();
                if (category == "Checked")
                {
                    e.Row.BackColor = Color.DarkRed;
                }
                string category2 = gridCar.GetRowValues(e.VisibleIndex, "cmpt_count").ToString();
                category2 = category2 == "" ? "0" : category2;
                if (Convert.ToInt32(category2) > 1)
                {
                    string category3 = gridCar.GetRowValues(e.VisibleIndex, "cmpt_count2").ToString();
                    string category4 = gridCar.GetRowValues(e.VisibleIndex, "I_ID").ToString();
                    if (category3 == category4)
                    {
                        e.Row.BackColor = Color.PaleGreen;
                    }
                }
            }
        }

        protected void gridGsa_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.VisibleIndex >= 0)
            //{
            //    string category = gridGsa.GetRowValues(e.VisibleIndex, "I_ONCELIKLI").ToString();
            //    if (category == "Checked")
            //    {
            //        e.Row.BackColor = Color.DarkRed;
            //    }
            //    string category2 = gridGsa.GetRowValues(e.VisibleIndex, "cmpt_count").ToString();
            //    category2 = category2 == "" ? "0" : category2;
            //    if (Convert.ToInt32(category2) > 1)
            //    {
            //        string category3 = gridGsa.GetRowValues(e.VisibleIndex, "cmpt_count2").ToString();
            //        string category4 = gridGsa.GetRowValues(e.VisibleIndex, "I_ID").ToString();
            //        if (category3 == category4)
            //        {
            //            e.Row.BackColor = Color.PaleGreen;
            //        }
            //    }
            //}
        }
        protected void gridElp_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.VisibleIndex >= 0)
            {
                string category = gridElp.GetRowValues(e.VisibleIndex, "I_ONCELIKLI").ToString();
                if (category == "Checked")
                {
                    e.Row.BackColor = Color.DarkRed;
                }
                string category2 = gridElp.GetRowValues(e.VisibleIndex, "cmpt_count").ToString();
                category2 = category2 == "" ? "0" : category2;
                if (Convert.ToInt32(category2) > 1)
                {
                    string category3 = gridElp.GetRowValues(e.VisibleIndex, "cmpt_count2").ToString();
                    string category4 = gridElp.GetRowValues(e.VisibleIndex, "I_ID").ToString();
                    if (category3 == category4)
                    {
                        e.Row.BackColor = Color.PaleGreen;
                    }
                }
            }
        }
        protected void gridSon50_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.VisibleIndex >= 0)
            {
                string category = gridSon50.GetRowValues(e.VisibleIndex, "I_ONCELIKLI").ToString();
                if (category == "Checked")
                {
                    e.Row.BackColor = Color.DarkRed;
                }
                string category2 = gridSon50.GetRowValues(e.VisibleIndex, "cmpt_count").ToString();
                category2 = category2 == "" ? "0" : category2;
                if (Convert.ToInt32(category2) > 1)
                {
                    string category3 = gridSon50.GetRowValues(e.VisibleIndex, "cmpt_count2").ToString();
                    string category4 = gridSon50.GetRowValues(e.VisibleIndex, "I_ID").ToString();
                    if (category3 == category4)
                    {
                        e.Row.BackColor = Color.PaleGreen;
                    }
                }
            }

        }


        private void FillSelectedKanalGrid()
        {
            
            gridSelectKanal.DataSource = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_KANAL_TUM("")); 
            gridSelectKanal.DataBind();

        }
        protected void btnTamam_Click(object sender, EventArgs e)
        {
            string kanal = ""; string kanal2 = ""; string kanal3 = "";
            List<object> keys1 = gridSelectKanal.GetSelectedFieldValues(gridSelectKanal.KeyFieldName);
            List<object> keys2 = gridSelectKanal.GetSelectedFieldValues("KNL_KODU");
            List<object> keys3 = gridSelectKanal.GetSelectedFieldValues("KN_ADI");
            kanal = String.Join(",", keys1.ToArray());
            kanal2 = String.Join(",", keys2.ToArray());
            kanal3 = string.Join(",", keys3.ToArray());
            Session["SS_KANAL"] = kanal2;
            Session["SS_KANAL_ADI"] = kanal3;
            ASPxGlobalEvents1.Enabled = false;
            PreparePage();
        }

        protected void gridSelectKanal_HtmlFooterCellPrepared(object sender, ASPxGridViewTableFooterCellEventArgs e)
        {
            e.Cell.ColumnSpan = 2;
        }
        protected void gridSelectKanal_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("KN_ADI") != null)
            {
                if (e.GetValue("KN_ADI").ToString() == "")
                {
                    e.Row.Visible = false;
                }
            }

        }
        protected void grid155_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        { 
            ASPxGridView xgrid = sender as ASPxGridView;
            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " + "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL(Tarih1, Tarih2, "155"));
            pageControlIc.TabPages[0].Text = "155 Gelen İhbarlar(" + dt.Rows.Count.ToString() + ")"; 
            _155Count = dt.Rows.Count; 
            xgrid.DataSource = dt;
            xgrid.DataBind();
            
        } 
       
        protected void grid155_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpRowCount"] = ((ASPxGridView)sender).VisibleRowCount;
        }

        protected void gridCar_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView xgrid = sender as ASPxGridView;
            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " + "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL(Tarih1, Tarih2, "CA"));
            pageControlIc.TabPages[1].Text = "ÇAR(" + dt.Rows.Count.ToString() + ")";
            CARCount = dt.Rows.Count;
            xgrid.DataSource = dt;
            xgrid.DataBind();
        }

        protected void gridCar_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpRowCount"] = ((ASPxGridView)sender).VisibleRowCount;
        }
        protected void gridGsa_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView xgrid = sender as ASPxGridView;
            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " + "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL(Tarih1, Tarih2, "GS"));
            pageControlIc.TabPages[2].Text = "GS(" + dt.Rows.Count.ToString() + ")";
            GSCount = dt.Rows.Count;
            xgrid.DataSource = dt;
            xgrid.DataBind();
        }

        protected void gridGsa_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpRowCount"] = ((ASPxGridView)sender).VisibleRowCount;
        }

        protected void gridElp_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView xgrid = sender as ASPxGridView;
            string Tarih1 = Convert.ToDateTime(DateTime.Now).AddDays(-4).ToString(Session["SS_DATEMODE"].ToString()) + " " + "00:00";
            string Tarih2 = Convert.ToDateTime(DateTime.Now).ToString(Session["SS_DATEMODE"].ToString()) + " " + "23:59";
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL(Tarih1, Tarih2, "ELP"));
            pageControlIc.TabPages[3].Text = "ELP(" + dt.Rows.Count.ToString() + ")";
            ELPCount = dt.Rows.Count;
            xgrid.DataSource = dt;
            xgrid.DataBind();
        }

        protected void gridElp_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpRowCount"] = ((ASPxGridView)sender).VisibleRowCount;
        }

        protected void gridSon50_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView xgrid = sender as ASPxGridView;
            DataTable dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_GETIHBAR_LISTE_KANAL_KAPALI());
            pageControlIc.TabPages[4].Text = "SON100 (" + dt.Rows.Count.ToString() + ")"; 
            SON50 = dt.Rows.Count;
            xgrid.DataSource = dt;
            xgrid.DataBind();
            
        }

        protected void gridSon50_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            e.Properties["cpRowCount"] = ((ASPxGridView)sender).VisibleRowCount;
        }
        protected void gridAdresAra_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            FillAdressTab();
        }

     

        protected void gridKmrListe_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] _params = e.Parameters.ToString().Split(',');
            DataTable dt;
            if (_params.Length > 1)
            {
                dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_KAMERALISTES_GETIR(_params[0].ToString()));
                btnKmrAra.Text = "";
            } 
            else
            {
                dt = Helper.Helper.CreateKeyFieldName(MK_HelperDataLib.Select.S_KAMERALISTES_GETIR_KAMERAADI(_params[0].ToString()));
                gridCombo.Value = null;

            }
                
            gridKmrListe.DataSource = dt;
            gridKmrListe.DataBind(); 
          
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
                            markerTitle = kısayolmarker_arac.Rows[i]["MRK_ADI"].ToString()+" " + kısayolmarker_arac.Rows[i]["Distance1"].ToString(),
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

        //yusuf degisiklikler
        protected void gridKmrListe_OnAfterPerformCallback(object sender, ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            string[] _params = e.Args;
            DataTable dt = MK_HelperDataLib.Select.S_KAMERALISTES_GETIR(_params[0].ToString());
            gridKmrListe.DataSource = dt;
            gridKmrListe.DataBind();
            btnKmrAra.Text = "";
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            string currentIhbarId = grid155.GetRowValues(grid155.FocusedRowIndex, "I_ID").ToString();
            string Ustolay = grid155.GetRowValues(grid155.FocusedRowIndex, "A_IHBAR").ToString();
            bool durum = false;
            if (txtmessage.Text != "" && currentIhbarId != "")
            {
                MK_HelperDataLib.Insert.I_MESAJ(currentIhbarId, Ustolay, txtmessage.Text, ref durum);
            }
        }

        

        void benimIhbarlarimFiltreDoldur()
        {
            /*Sayfa ilk açıldığında, veriler veritabanından çekilmesi için sessionları boşaltıyoruz.*/
            if (!IsPostBack)
            {
                Session["lstAltOlay"] = null;
                Session["rt_ilce"] = null;
                Session["rt_kanal"] = null;
                Session["rt_log"] = null;
                Session["rt_ustOlay"] = null;
                Session["rt_ustOlay"] = null;
            }

            rChkTip.Items.Add("");
            rChkTip.Items.Add("155");
            rChkTip.Items.Add("Oto Çalıntı");
            rChkTip.Items.Add("Güvenlik Şirketi");

            rChkDurum.Items.Add("");
            rChkDurum.Items.Add("Kayıt");
            rChkDurum.Items.Add("İletilen");
            rChkDurum.Items.Add("Tümü İletilen");
            rChkDurum.Items.Add("A.Kapattı");
            rChkDurum.Items.Add("B.Talebi");
            rChkDurum.Items.Add("G.Arama");
            rChkDurum.Items.Add("EksikIhbar");
            rChkDurum.Items.Add("İptal");

            rChkDiger.Items.Add("");
            rChkDiger.Items.Add("İtfaiye");
            rChkDiger.Items.Add("Ambulans");
            rChkDiger.Items.Add("Öncelikli");


            /*Alt olay combobox ı dolduruluyor.*/
            if (Session["lstAltOlay"] == null)
            {
                Session["lstAltOlay"] = MK_HelperDataLib.Select.S_ALTOLAY_YUKLE();
            }

            lookAltOlay.DataSource = (DataTable)Session["lstAltOlay"];
            lookAltOlay.DataBind();


            /*İlçe combobox ı dolduruluyor.*/
            if (Session["lookIlce"] == null)
            {
                Session["lookIlce"] = MK_HelperDataLib.Select.S_ILCE("41");
            }

            lookIlce.DataSource = (DataTable)Session["lookIlce"];
            lookIlce.DataBind();


            /*Kanal combobox ı dolduruluyor.*/
            if (Session["SS_KANAL"] != "")
            {
                if (Session["lookKanal"] == null)
                {
                    Session["lookKanal"] = MK_HelperDataLib.Select.S_KANAL_WHERE("'" + Session["SS_KANAL"].ToString() + "'");
                }
                lookKanal.DataSource = (DataTable)Session["lookKanal"];
                lookKanal.DataBind();
            }


            /*Log combobox ı dolduruluyor.*/
            if (Session["lookLog"] == null)
            {
                Session["lookLog"] = MK_HelperDataLib.Select.S_GETLOG("0");
            }
            lookLog.DataSource = (DataTable)Session["lookLog"];
            lookLog.DataBind();


            /*İhbar Türü combobox ı dolduruluyor.*/
            if (Session["lookUstOlay"] == null)
            {
                Session["lookUstOlay"] = MK_HelperDataLib.Select.S_IHABARGRUP_LISTESI();
            }
            lookUstOlay.DataSource = (DataTable)Session["lookUstOlay"];
            lookUstOlay.DataBind();


            if (Session["dtgridBenimIhbarlarim"] == null)
            {
                string Tarih = DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy");
                Session["dtgridBenimIhbarlarim"] = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPORWHERE(" WHERE I_TARIH >= '" + Tarih + " 00:00:00' AND D.I_KULLANICI = '" + Session["USR_SICILNO"].ToString() + "'");
            }
            gridBenimIhbarlarim.DataSource = (DataTable)Session["dtgridBenimIhbarlarim"];
            gridBenimIhbarlarim.DataBind();
        }

        /* Yahya - Benim İhbarlarım (48 saat) menüsünde yükle buttonuna tıklandığı zaman filtrelere göre gridin yüklenmesi. [Yahya=benim_ihbarlarim]*/
        protected void ASPxMenu1_ItemClick(object source, MenuItemEventArgs e)
        {
            try
            {
                if (e.Item.Name == "Yukle")
                {
                    string Tarih1 = rDateBaslama.Date.ToString("MM/dd/yyyy");
                    string Tarih2 = rDateBitis.Date.ToString("MM/dd/yyyy");

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
                    if (lookLog.Text != "")
                    {
                        string[] arg2 = new string[150];
                        arg2 = lookLog.Text.Replace(" ", "").Split(';');
                        for (int i = 0; i < arg2.Length; i++)
                        {
                            if (lookLog.Text != "Log")
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
                    string Tip = "";


                    if (lookAltOlay.Text != "")
                    {
                        if (lookAltOlay.Text != "Alt Olay")
                        {
                            altolay = lookAltOlay.Text;
                            altolay += "'";
                            altolay = altolay.Insert(0, "'");
                            altolay = altolay.Replace(",", "','");
                            altolay = altolay.Trim().Replace(" ", "");
                        }
                    }

                    if (lookIlce.Text != "")
                    {
                        if (lookIlce.Text != "İlçe")
                        {
                            ilce = lookIlce.Text.ToString();
                            ilce += "'";
                            ilce = ilce.Insert(0, "'");
                            ilce = ilce.Replace(",", "','");
                            ilce = ilce.Trim().Replace(" ", "");
                        }
                    }

                    if (lookMahalle.Text != "")
                    {
                        if (lookMahalle.Text != "Mahalle")
                        {
                            mahalle = lookMahalle.Text.ToString();
                            mahalle += "'";
                            mahalle = mahalle.Insert(0, "'");
                            mahalle = mahalle.Replace(",", "','");
                            mahalle = mahalle.Trim().Replace(" ", "");
                        }
                    }

                    if (txtCadde.Text != "")
                    {
                        if (txtCadde.Text != "Cadde-Sokak")
                        {
                            cadde = txtCadde.Text.ToString().Trim();
                        }
                    }

                    if (lookUstOlay.Text != "")
                    {
                        if (lookUstOlay.Text != "İhbar Türü")
                        {
                            ihbarturu = lookUstOlay.Text;
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

                    if (rChkTip.Value != null)
                    {
                        if (rChkTip.Text != "Tip")
                        {
                            switch (rChkTip.SelectedIndex)
                            {
                                case 1:
                                    Tip = "155";
                                    break;
                                case 2:
                                    Tip = "CA";
                                    break;
                                case 3:
                                    Tip = "GS";
                                    break;
                            }
                        }
                    }

                    string saatsorgu = "";
                    if (cmbSaat.Value != null)
                    {
                        if (cmbSaat.SelectedIndex != 0)
                        {
                            switch (cmbSaat.SelectedIndex)
                            {
                                case 1:
                                    saatsorgu = " and i.I_TARIH between dateadd(hour,-3,getdate()) and getdate()";
                                    break;
                                case 2:
                                    saatsorgu = " and i.I_TARIH between dateadd(hour,-6,getdate()) and getdate()";
                                    break;
                                case 3:
                                    saatsorgu = " and i.I_TARIH between dateadd(hour,-12,getdate()) and getdate()";
                                    break;
                                case 4:
                                    saatsorgu = " and i.I_TARIH between dateadd(hour,-24,getdate()) and getdate()";
                                    break;
                                case 5:
                                    saatsorgu = " and i.I_TARIH between dateadd(hour,-48,getdate()) and getdate()";
                                    break;
                                default:
                                    saatsorgu = "";
                                    break;
                            }
                        }
                    }

                    if (txtKullanici.Text != "Kullanıcı" && txtKullanici.Text != "")
                    {
                        if (saatsorgu == "")
                        {
                            saatsorgu += " and i.I_TARIH>='" + Tarih1 + " 00:00:00' and i.I_TARIH<='" + Tarih2 + " 23:59:59'";
                        }
                        saatsorgu += " and i.I_KULLANICI = '" + txtKullanici.Text + "'";
                    }

                    if (txt_SiteAdi.Text != "Site Adı" && txt_SiteAdi.Text != "")
                    {
                        if (saatsorgu == "")
                        {
                            saatsorgu += " and i.I_TARIH>='" + Tarih1 + " 00:00:00' and i.I_TARIH<='" + Tarih2 + " 23:59:59'";
                        }
                        saatsorgu += " and i.I_SITE LIKE '%" + txt_SiteAdi.Text.Trim() + "%'";
                    }

                    if (txtIcerikArama.Text != "İçerik Arama" && txtIcerikArama.Text != "")
                    {
                        if (saatsorgu == "")
                        {
                            saatsorgu += " and i.I_TARIH>='" + Tarih1 + " 00:00:00' and i.I_TARIH<='" + Tarih2 + " 23:59:59'";
                        }
                        saatsorgu += " and (i.I_ADRES LIKE '%" + txtIcerikArama.Text.Trim() + "%' OR i.I_IHBARBILGISI LIKE '%" + txtIcerikArama.Text.Trim() + "%')";
                    }

                    if (Tip != "")
                    {
                        if (saatsorgu == "")
                        {
                            saatsorgu += " and i.I_TARIH>='" + Tarih1 + " 00:00:00' and i.I_TARIH<='" + Tarih2 + " 23:59:59'";
                        }
                        saatsorgu += " and i.I_IHBARTUR = '" + Tip + "'";
                    }

                    //saatsorgu += " " + WHERE;

                    gridBenimIhbarlarim.DataSource = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPOR2(Tarih1, Tarih2, rTxtIhbarcitel.Text != "İhbarcı Telefonu" ? rTxtIhbarcitel.Text : "", rTxtIhbarciAd.Text != "İhbarcı Adı" ? rTxtIhbarciAd.Text : "", ilce, mahalle, cadde, txtPlaka.Text != "Plaka" ? txtPlaka.Text : "", ihbarturu, altolay, kanal, log, durum, diger, saatsorgu);
                    gridBenimIhbarlarim.DataBind();



                }
                else if (e.Item.Name == "Temizle") // [YahyaSonGuncelleme] = Temizle buttonu eklendi.
                {
                    Session["dtgridBenimIhbarlarim"] = null;
                    gridBenimIhbarlarim.DataSource = null;
                    gridBenimIhbarlarim.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridBenimIhbarlarim_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            string elementIndex = e.Parameters.Split('|')[0];
            string parameter = e.Parameters.Split('|')[1];

            if (parameter == "grid155_cm_benimIhbar")
            {
                string Tarih = DateTime.Now.AddDays(-2).ToString("MM/dd/yyyy");
                Session["dtgridBenimIhbarlarim"] = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPORWHERE(" WHERE I_TARIH >= '" + Tarih + " 00:00:00' AND D.I_KULLANICI = '" + Session["USR_SICILNO"].ToString() + "'");
                gridBenimIhbarlarim.DataSource = (DataTable)Session["dtgridBenimIhbarlarim"];
                gridBenimIhbarlarim.DataBind();
            }
            else if (parameter == "grid155_cm_kanalIhbar" || parameter == "grid155_cm_ihbarSorgu")
            {
                string kanal = "";
                if (Session["SS_KANAL"] != null && Session["SS_KANAL"] != "")
                {
                    kanal = Session["SS_KANAL"].ToString();
                    kanal += "'";
                    kanal = kanal.Insert(0, "'");
                    kanal = kanal.Replace(",", "','");
                    kanal = kanal.Trim().Replace(" ", "");
                }

                string Tarih = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");

                string tarihWhere = "";
                if (parameter == "grid155_cm_kanalIhbar")
                {
                    tarihWhere = " AND I_TARIH >= '" + Tarih + " 00:00:00'";
                }

                Session["dtgridBenimIhbarlarim"] = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPORWHERE(" WHERE I.I_KANAL in (" + kanal + ")" + tarihWhere);
                gridBenimIhbarlarim.DataSource = (DataTable)Session["dtgridBenimIhbarlarim"];
                gridBenimIhbarlarim.DataBind();
            }
            else if (parameter == "grid155_cm_telGelenIhbar")
            {
                string telefon = grid155.GetRowValues(Convert.ToInt32(elementIndex), "I_TELEFON").ToString();
                Session["dtgridBenimIhbarlarim"] = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPORWHERE(" WHERE I_TELEFON = '" + telefon + "'");
                gridBenimIhbarlarim.DataSource = (DataTable)Session["dtgridBenimIhbarlarim"];
                gridBenimIhbarlarim.DataBind();
            }
            else if (parameter == "grid155_cm_IhbarciGelenIhbar")
            {
                string isimSoyisim = grid155.GetRowValues(Convert.ToInt32(elementIndex), "I_ISIMSOYISIM").ToString();
                Session["dtgridBenimIhbarlarim"] = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPORWHERE(" WHERE I_ISIMSOYISIM = '" + isimSoyisim + "'");
                gridBenimIhbarlarim.DataSource = (DataTable)Session["dtgridBenimIhbarlarim"];
                gridBenimIhbarlarim.DataBind();
            }
            else if (parameter == "grid155_cm_takipIhbar")
            {
                string kanal = "";
                if (Session["SS_KANAL"] != null && Session["SS_KANAL"] != "")
                {
                    kanal = Session["SS_KANAL"].ToString();
                    kanal += "'";
                    kanal = kanal.Insert(0, "'");
                    kanal = kanal.Replace(",", "','");
                    kanal = kanal.Trim().Replace(" ", "");
                }

                Session["dtgridBenimIhbarlarim"] = MK_HelperDataLib.RaporSelect.S_GETIHBAR_RAPORWHERE(" where T.I_KULLANICI = '" + Session["USR_SICILNO"].ToString() + "' and  T.I_TIP = 1 AND  D.I_KANAL IN(" + kanal + ")");
                gridBenimIhbarlarim.DataSource = (DataTable)Session["dtgridBenimIhbarlarim"];
                gridBenimIhbarlarim.DataBind();


            }
        }
        public void scriptYazdir(string scriptSorgu)
        {
            Page thisPage = (Page)System.Web.HttpContext.Current.Handler;
            HtmlHead head = thisPage.Header;
            LiteralControl lctl = new LiteralControl(scriptSorgu);
            head.Controls.Add(lctl);
        }
    }
}