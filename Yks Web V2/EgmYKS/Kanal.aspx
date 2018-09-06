<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" Debug="true" AutoEventWireup="true" CodeBehind="Kanal.aspx.cs" Inherits="EgmYKS.IHBAR.Kanal" %>
<%@ Register src="~/Ucntrl/Ucntrl_Map.ascx" tagname="Ucntrl_Map" tagprefix="uc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script type="text/javascript"> var auto_refresh = setInterval(function () { Callbackpanel.PerformCallback(); }, 15000);
  </script>
    
    <div style="height: 550px;">
        <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Height="100%" Width="100%" EnableHierarchyRecreation="false">
            <Panes>
                <dx:SplitterPane Size="20%">
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server">

                            <dx:ASPxGridView ID="gridTerminals" ClientInstanceName="gridTerminals" runat="server" KeyFieldName="LONG_NAME" Font-Size="X-Small"
                                AutoGenerateColumns="False" Width="100%" OnCustomCallback="gridTerminals_CustomCallback">
                                <ClientSideEvents FocusedRowChanged="function(s,e){s.GetRowValues(s.GetFocusedRowIndex(), 'LONGITUDE;LATITUDE', OnGetSelectedFieldValues);}" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Terminaller" FieldName="SHORT_NAME" ShowInCustomizationForm="True" VisibleIndex="0" Width="35%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Plaka" FieldName="LONG_NAME" CellStyle-Font-Size="XX-Small" ShowInCustomizationForm="True" VisibleIndex="1" Width="40%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TERMINAL1" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ISACTIVE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="LATITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="LONGITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Uzaklık" FieldName="Distance1" ShowInCustomizationForm="True" VisibleIndex="6" Width="25%">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
                <dx:SplitterPane Size="40%">
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server">  
                            <asp:UpdatePanel ID="upMap" runat="server" UpdateMode="Conditional"> 
                                <ContentTemplate> 
                                     <uc1:Ucntrl_Map ID="Ucntrl_Map" runat="server" /> 
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
                <dx:SplitterPane Size="40%" ScrollBars="Vertical">
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server">
                            <dx:ASPxPageControl ID="pageControlYksIslemler" runat="server" TabPosition="Top" ActiveTabIndex="3" Height="500">
                                <TabPages>
                                    <dx:TabPage Name="adresAra" Text="Adres Ara">
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <dx:ASPxButtonEdit ID="adresAratxt" runat="server" Width="100%" AutoPostBack="false">
                                                    <ClientSideEvents ButtonClick="function(s,e){gridAdresAra.PerformCallback('');}" />
                                                    <Buttons>
                                                        <dx:EditButton ImagePosition="Right">
                                                            <Image Url="~/images/Zoom_16x16.png">
                                                            </Image>
                                                        </dx:EditButton>
                                                    </Buttons>
                                                </dx:ASPxButtonEdit>
                                                <dx:ASPxGridView ID="gridAdresAra" ClientInstanceName="gridAdresAra" runat="server" Width="100%" KeyFieldName="KEYFIELDID"
                                                    AutoGenerateColumns="False" Font-Size="XX-Small" OnCustomCallback="gridAdresAra_CustomCallback">
                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="ILCEADI" Caption="İlçe Adı" ShowInCustomizationForm="True" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MAHALLEADI" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CADDEADI" ShowInCustomizationForm="True" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ILCELAT" ShowInCustomizationForm="True" VisibleIndex="3" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="ILCELONG" ShowInCustomizationForm="True" VisibleIndex="4" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MAHLAT" ShowInCustomizationForm="True" VisibleIndex="5" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MAHLONG" ShowInCustomizationForm="True" VisibleIndex="6" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CADLAT" ShowInCustomizationForm="True" VisibleIndex="7" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="CADLONG" ShowInCustomizationForm="True" VisibleIndex="8" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <ClientSideEvents RowClick="function(s,e){s.GetRowValues(s.GetFocusedRowIndex(), 'CADLONG;CADLAT', OnGetSelectedFieldValues);}" />
                                                </dx:ASPxGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Name="hrtKsyl" Text="Hrt Ksyol">
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <dx:ASPxGridView ID="gridHrtKsyl" runat="server" Width="100%" KeyFieldName="KEYFIELDID" AutoGenerateColumns="False" Font-Size="XX-Small"
                                                    OnContextMenuItemClick="gridHrtKsyl_ContextMenuItemClick"
                                                    OnFillContextMenuItems="gridHrtKsyl_FillContextMenuItems">
                                                    <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}"
                                                        FocusedRowChanged="function(s,e){s.GetRowValues(s.GetFocusedRowIndex(), 'MRK_LONG;MRK_LAT', OnGetSelectedFieldValues);}"></ClientSideEvents>
                                                    <SettingsContextMenu Enabled="True">
                                                        <RowMenuItemVisibility NewRow="False" EditRow="False" DeleteRow="False" Refresh="False"></RowMenuItemVisibility>
                                                    </SettingsContextMenu>

                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="MRK_ID" ShowInCustomizationForm="True" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MKYG_ADI" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MRK_ADI" ShowInCustomizationForm="True" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MRK_LAT" ShowInCustomizationForm="True" VisibleIndex="3" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="MRK_LONG" ShowInCustomizationForm="True" VisibleIndex="4" Visible="false">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Name="kmrListe" Text="Kmr Liste">
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButtonEdit ID="btnKmrAra" NullText="Tüm kameralarda ara..." AutoPostBack="false" runat="server">
                                                                <ClientSideEvents ButtonClick="function(s,e){gridKmrListe.PerformCallback(s.GetValue());}" />
                                                                <Buttons>
                                                                    <dx:EditButton ImagePosition="Right">
                                                                        <Image Url="~/images/Zoom_16x16.png">
                                                                        </Image>
                                                                    </dx:EditButton>
                                                                </Buttons>
                                                            </dx:ASPxButtonEdit>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxComboBox ID="gridCombo" runat="server" ClientInstanceName="gridCombo" NullText="Seçinz..."
                                                                ValueField="ILCEID" TextField="AD" TextFormatString="{1}"
                                                                DropDownStyle="DropDownList" IncrementalFilteringMode="StartsWith" Width="100%"
                                                                EnableSynchronization="False">
                                                                <Columns>
                                                                    <dx:ListBoxColumn FieldName="ILCEID" Visible="false"></dx:ListBoxColumn>
                                                                    <dx:ListBoxColumn FieldName="LONG" Visible="false"></dx:ListBoxColumn>
                                                                    <dx:ListBoxColumn FieldName="LAT" Visible="false"></dx:ListBoxColumn>
                                                                    <dx:ListBoxColumn FieldName="AD"></dx:ListBoxColumn>
                                                                </Columns>
                                                                <ClientSideEvents
                                                                    SelectedIndexChanged="function(s,e){s.GetRowValues(s.GetFocusedRowIndex(), 'ILCEID;LAT;LONG', OnGetRowValues);}" />
                                                            </dx:ASPxComboBox>
                                                            <%-- <dx:ASPxGridLookup ID="gridLookUp" ClientInstanceName="gridLookUp" NullText="Seçiniz.." runat="server"
                                                                KeyFieldName="ILCEID" TextFormatString="{1}">
                                                                <GridViewProperties>
                                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
                                                                </GridViewProperties>
                                                                <GridViewClientSideEvents FocusedRowChanged="function(s,e){s.GetRowValues(s.GetFocusedRowIndex(), 'ILCEID;LAT;LONG', OnGetRowValues);}" />
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn FieldName="ILCEID" Visible="false"></dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="AD"></dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="LONG" Visible="false"></dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn FieldName="LAT" Visible="false"></dx:GridViewDataTextColumn>
                                                                </Columns>
                                                            </dx:ASPxGridLookup>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <dx:ASPxGridView ID="gridKmrListe" ClientInstanceName="gridKmrListe" runat="server" Width="100%" KeyFieldName="KEYFIELDID"
                                                    OnCustomCallback="gridKmrListe_CustomCallback" SettingsBehavior-AllowFocusedRow="true"
                                                    AutoGenerateColumns="False" Font-Size="XX-Small">
                                                    <ClientSideEvents
                                                        FocusedRowChanged="function(s,e){s.GetRowValues(s.GetFocusedRowIndex(), 'KMRLON;KMRLAT', OnGetSelectedFieldValues);}"></ClientSideEvents>
                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                    <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="KMRADI" Caption="Kamera Adı" ShowInCustomizationForm="True" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="parseadres" Caption="Adres" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="KMRLAT" Caption=" " Visible="false" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="KMRLON" Caption=" " Visible="false" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Name="ihbarListe" Text="İhbar Liste">
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <asp:Panel runat="server" ScrollBars="Auto">
                                                    <asp:Label ID="lblAktifKanallar" runat="server" Width="250px"></asp:Label>
                                                </asp:Panel>
                                                <dx:ASPxCallbackPanel ID="Callbackpanel" ClientInstanceName="Callbackpanel" runat="server" OnCallback="Callbackpanel_Callback" SettingsLoadingPanel-Enabled="false">
                                                    <PanelCollection>
                                                        <dx:PanelContent>
                                                            <dx:ASPxPageControl ID="pageControlIc" ClientInstanceName="pageControlIc" runat="server" TabPosition="Bottom" Width="100%" ActiveTabIndex="0">
                                                                <TabPages>
                                                                    <dx:TabPage Name="tab155" Text="155 Gelen İhbarlar">
                                                                        <ContentCollection>
                                                                            <dx:ContentControl>
                                                                                <dx:ASPxGridView ID="grid155" runat="server" Width="100%" AutoGenerateColumns="false"
                                                                                    Theme="Glass" EnableTheming="false"
                                                                                    KeyFieldName="KEYFIELDID" Font-Size="XX-Small" ClientInstanceName="grid155"
                                                                                    EnableCallBacks="false"
                                                                                    OnContextMenuItemClick="grid155_ContextMenuItemClick"
                                                                                    OnFillContextMenuItems="grid155_FillContextMenuItems"
                                                                                    OnHtmlRowPrepared="grid155_HtmlRowPrepared"
                                                                                    OnCustomCallback="grid155_CustomCallback"
                                                                                    OnCustomJSProperties="grid155_CustomJSProperties">
                                                                                    <ClientSideEvents
                                                                                        ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}"
                                                                                        RowDblClick="function(s,e) {OpenDetay(s, e);}"
                                                                                        EndCallback="function(s,e) { var param ='155 Gelen İhbarlar('+s.cpRowCount+')'; pageControlIc.GetTabByName('tab155').SetText(param)}" />
                                                                                    <SettingsContextMenu Enabled="True">
                                                                                        <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                                                        </RowMenuItemVisibility>
                                                                                    </SettingsContextMenu>
                                                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_TAKIPDURUM" Caption=" " Width="32" ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ID" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_KANAL" Caption="Kanal" ShowInCustomizationForm="True" VisibleIndex="5">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="A_IHBAR" Caption="Olay Kodu" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" ShowInCustomizationForm="True" VisibleIndex="7">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn FieldName="I_TARIH" Caption="Tarih" ShowInCustomizationForm="True" VisibleIndex="8" PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy hh:mm:ss"></PropertiesDateEdit>
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_DURUM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ONCELIKLI" ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LATITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LONGITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon2" ShowInCustomizationForm="True" UnboundType="Object" VisibleIndex="3" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("I_DURUM").ToString()=="False"?"../Gridicon/3.png":Eval("cmpt_islemdurum").ToString() == "1" ? "../Gridicon/5.png" : "../Gridicon/4.png" %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon" ShowInCustomizationForm="True" VisibleIndex="2" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("I_TAKIPDURUM").ToString()=="1"?"../Gridicon/0.png":Eval("I_TAKIPDURUM").ToString() == "2" ? "../Gridicon/1.png" : Eval("I_TAKIPDURUM").ToString() == "3" ? "../Gridicon/2.png" : ""   %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " FieldName="cmpt_islemdurum" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="16px">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_TELEFON" ShowInCustomizationForm="True" Visible="False" VisibleIndex="16">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ISIMSOYISIM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="17">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                </dx:ASPxGridView>
                                                                                <dx:ASPxGridViewExporter ID="grd_155" runat="server"></dx:ASPxGridViewExporter>
                                                                            </dx:ContentControl>
                                                                        </ContentCollection>
                                                                    </dx:TabPage>
                                                                    <dx:TabPage Name="tabCar" Text="ÇAR">
                                                                        <ContentCollection>
                                                                            <dx:ContentControl>
                                                                                <dx:ASPxGridView ID="gridCar" runat="server" Width="100%" Font-Size="XX-Small" KeyFieldName="KEYFIELDID"
                                                                                    OnContextMenuItemClick="gridCar_ContextMenuItemClick" ClientInstanceName="gridCar"
                                                                                    OnFillContextMenuItems="gridCar_FillContextMenuItems"
                                                                                    OnHtmlRowPrepared="gridCar_HtmlRowPrepared"
                                                                                    OnCustomCallback="gridCar_CustomCallback"
                                                                                    OnCustomJSProperties="gridCar_CustomJSProperties">
                                                                                    <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}"
                                                                                        RowDblClick="function(s,e) {OpenDetay(s, e);}" />
                                                                                    <SettingsContextMenu Enabled="True">
                                                                                        <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                                                        </RowMenuItemVisibility>
                                                                                    </SettingsContextMenu>
                                                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_TAKIPDURUM" Caption=" " Width="32" ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ID" Visible="false" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_KANAL" Caption="Kanal" ShowInCustomizationForm="True" VisibleIndex="5">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="A_IHBAR" Caption="Olay Kodu" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" ShowInCustomizationForm="True" VisibleIndex="7">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn FieldName="I_TARIH" Caption="Tarih" ShowInCustomizationForm="True" VisibleIndex="8" PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy hh:mm:ss"></PropertiesDateEdit>
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_DURUM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ONCELIKLI" ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LATITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LONGITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon2" ShowInCustomizationForm="True" UnboundType="Object" VisibleIndex="3" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("I_DURUM").ToString()=="False"?"../Gridicon/3.png":Eval("cmpt_islemdurum").ToString() == "1" ? "../Gridicon/5.png" : "../Gridicon/4.png" %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon" ShowInCustomizationForm="True" VisibleIndex="2" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image4" runat="server" ImageUrl='<%# Eval("I_TAKIPDURUM").ToString()=="1"?"../Gridicon/0.png":Eval("I_TAKIPDURUM").ToString() == "2" ? "../Gridicon/1.png" : Eval("I_TAKIPDURUM").ToString() == "3" ? "../Gridicon/2.png" : ""   %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " FieldName="cmpt_islemdurum" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="16px">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                </dx:ASPxGridView>
                                                                                <dx:ASPxGridViewExporter ID="grid_car" runat="server"></dx:ASPxGridViewExporter>
                                                                            </dx:ContentControl>
                                                                        </ContentCollection>
                                                                    </dx:TabPage>
                                                                    <dx:TabPage Name="tabGsa" Text="GŞA">
                                                                        <ContentCollection>
                                                                            <dx:ContentControl>
                                                                                <dx:ASPxGridView ID="gridGsa" runat="server" Width="100%" Font-Size="XX-Small" KeyFieldName="KEYFIELDID"
                                                                                    OnContextMenuItemClick="gridGsa_ContextMenuItemClick" ClientInstanceName="gridGsa"
                                                                                    OnFillContextMenuItems="gridGsa_FillContextMenuItems"
                                                                                    OnHtmlRowPrepared="gridGsa_HtmlRowPrepared"
                                                                                    OnCustomCallback="gridGsa_CustomCallback"
                                                                                    OnCustomJSProperties="gridGsa_CustomJSProperties">
                                                                                    <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}"
                                                                                        RowDblClick="function(s,e) {OpenDetay(s, e);}" />
                                                                                    <SettingsContextMenu Enabled="True">
                                                                                        <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                                                        </RowMenuItemVisibility>
                                                                                    </SettingsContextMenu>
                                                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_TAKIPDURUM" Caption=" " Width="32" ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ID" Visible="false" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_KANAL" Caption="Kanal" ShowInCustomizationForm="True" VisibleIndex="5">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="A_IHBAR" Caption="Olay Kodu" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" ShowInCustomizationForm="True" VisibleIndex="7">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn FieldName="I_TARIH" Caption="Tarih" ShowInCustomizationForm="True" VisibleIndex="8" PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy hh:mm:ss"></PropertiesDateEdit>
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_DURUM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ONCELIKLI" ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LATITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LONGITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon2" ShowInCustomizationForm="True" UnboundType="Object" VisibleIndex="3" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image5" runat="server" ImageUrl='<%# Eval("I_DURUM").ToString()=="False"?"../Gridicon/3.png":Eval("cmpt_islemdurum").ToString() == "1" | Eval("cmpt_islemdurum").ToString() == "10" ? "../Gridicon/5.png" : "../Gridicon/4.png" %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon" ShowInCustomizationForm="True" VisibleIndex="2" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image6" runat="server" ImageUrl='<%# Eval("I_TAKIPDURUM").ToString()=="1"?"../Gridicon/0.png":Eval("I_TAKIPDURUM").ToString() == "2" ? "../Gridicon/1.png" : Eval("I_TAKIPDURUM").ToString() == "3" ? "../Gridicon/2.png" : ""   %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " FieldName="cmpt_islemdurum" ShowInCustomizationForm="True" Visible="false" VisibleIndex="1" Width="16px">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                </dx:ASPxGridView>
                                                                                <dx:ASPxGridViewExporter ID="grid_gsa" runat="server"></dx:ASPxGridViewExporter>
                                                                            </dx:ContentControl>
                                                                        </ContentCollection>
                                                                    </dx:TabPage>
                                                                    <dx:TabPage Name="tabElp" Text="ELP">
                                                                        <ContentCollection>
                                                                            <dx:ContentControl>
                                                                                <dx:ASPxGridView ID="gridElp" runat="server" Width="100%" Font-Size="XX-Small" KeyFieldName="KEYFIELDID"
                                                                                    OnContextMenuItemClick="gridElp_ContextMenuItemClick" ClientInstanceName="gridElp"
                                                                                    OnFillContextMenuItems="gridElp_FillContextMenuItems"
                                                                                    OnHtmlRowPrepared="gridElp_HtmlRowPrepared"
                                                                                    OnCustomCallback="gridElp_CustomCallback"
                                                                                    OnCustomJSProperties="gridElp_CustomJSProperties">
                                                                                    <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}"
                                                                                        RowDblClick="function(s,e) {OpenDetay(s, e);}" />
                                                                                    <SettingsContextMenu Enabled="True">
                                                                                        <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                                                        </RowMenuItemVisibility>
                                                                                    </SettingsContextMenu>
                                                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_TAKIPDURUM" Caption=" " Width="32" ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ID" Visible="false" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_KANAL" Caption="Kanal" ShowInCustomizationForm="True" VisibleIndex="5">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="A_IHBAR" Caption="Olay Kodu" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" ShowInCustomizationForm="True" VisibleIndex="7">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn FieldName="I_TARIH" Caption="Tarih" ShowInCustomizationForm="True" VisibleIndex="8" PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy hh:mm:ss"></PropertiesDateEdit>
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_DURUM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ONCELIKLI" ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LATITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LONGITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon2" ShowInCustomizationForm="True" UnboundType="Object" VisibleIndex="3" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image7" runat="server" ImageUrl='<%# Eval("I_DURUM").ToString()=="False"?"../Gridicon/3.png":Eval("cmpt_islemdurum").ToString() == "1" ? "../Gridicon/5.png" : "../Gridicon/4.png" %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon" ShowInCustomizationForm="True" VisibleIndex="2" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image8" runat="server" ImageUrl='<%# Eval("I_TAKIPDURUM").ToString()=="1"?"../Gridicon/0.png":Eval("I_TAKIPDURUM").ToString() == "2" ? "../Gridicon/1.png" : Eval("I_TAKIPDURUM").ToString() == "3" ? "../Gridicon/2.png" : ""   %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " FieldName="cmpt_islemdurum" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="16px">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                </dx:ASPxGridView>
                                                                                <dx:ASPxGridViewExporter ID="grid_elp" runat="server"></dx:ASPxGridViewExporter>
                                                                            </dx:ContentControl>
                                                                        </ContentCollection>
                                                                    </dx:TabPage>
                                                                    <dx:TabPage Name="son50" Text="SON 100">
                                                                        <ContentCollection>
                                                                            <dx:ContentControl>
                                                                                <dx:ASPxGridView ID="gridSon50" ClientInstanceName="gridSon50" runat="server" Width="100%" Font-Size="XX-Small"
                                                                                    KeyFieldName="KEYFIELDID"
                                                                                    OnContextMenuItemClick="gridSon50_ContextMenuItemClick"
                                                                                    OnFillContextMenuItems="gridSon50_FillContextMenuItems"
                                                                                    OnCustomCallback="gridSon50_CustomCallback"
                                                                                    OnCustomJSProperties="gridSon50_CustomJSProperties"
                                                                                    OnHtmlRowPrepared="gridSon50_HtmlRowPrepared">

                                                                                    <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}"
                                                                                        RowDblClick="function(s,e) {OpenDetaySon100(s, e);}" />
                                                                                    <SettingsContextMenu Enabled="True">
                                                                                        <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                                                        </RowMenuItemVisibility>
                                                                                    </SettingsContextMenu>
                                                                                    <SettingsPager Visible="true" Mode="ShowAllRecords" PageSize="200"></SettingsPager>
                                                                                    <Settings ShowFilterRow="true" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                                                    <SettingsBehavior AllowFocusedRow="true" />
                                                                                    <Columns>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_TAKIPDURUM" Caption=" " Width="32" ShowInCustomizationForm="True" VisibleIndex="0" Visible="False">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ID" Visible="false" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_KANAL" Caption="Kanal" ShowInCustomizationForm="True" VisibleIndex="5">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="A_IHBAR" Caption="Olay Kodu" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" ShowInCustomizationForm="True" VisibleIndex="7">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn FieldName="I_TARIH" Caption="Tarih" ShowInCustomizationForm="True" VisibleIndex="8" PropertiesDateEdit-DisplayFormatString="dd.MM.yyyy">
                                                                                            <PropertiesDateEdit DisplayFormatString="dd.MM.yyyy hh:mm:ss"></PropertiesDateEdit>
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count2" ShowInCustomizationForm="True" Visible="False" VisibleIndex="9">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" ShowInCustomizationForm="True" Visible="False" VisibleIndex="10">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="cmpt_count" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_DURUM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_ONCELIKLI" ShowInCustomizationForm="True" Visible="False" VisibleIndex="13">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LATITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="14">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="I_LONGITUDE" ShowInCustomizationForm="True" Visible="False" VisibleIndex="15">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon2" ShowInCustomizationForm="True" UnboundType="Object" VisibleIndex="3" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image9" runat="server" ImageUrl='<%# Eval("I_DURUM").ToString()=="False"?"../Gridicon/3.png":Eval("cmpt_islemdurum").ToString() == "1" ? "../Gridicon/5.png" : "../Gridicon/4.png" %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " Name="gridIcon" ShowInCustomizationForm="True" VisibleIndex="2" Width="16px">
                                                                                            <DataItemTemplate>
                                                                                                <asp:Image ID="Image10" runat="server" ImageUrl='<%# Eval("I_TAKIPDURUM").ToString()=="1"?"../Gridicon/0.png":Eval("I_TAKIPDURUM").ToString() == "2" ? "../Gridicon/1.png" : Eval("I_TAKIPDURUM").ToString() == "3" ? "../Gridicon/2.png" : ""   %>' Width="16px" />
                                                                                            </DataItemTemplate>
                                                                                            <CellStyle>
                                                                                                <Paddings Padding="0px" />
                                                                                            </CellStyle>
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption=" " FieldName="cmpt_islemdurum" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1" Width="16px">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                    </Columns>
                                                                                </dx:ASPxGridView>
                                                                                <dx:ASPxGridViewExporter ID="grid_son50" runat="server"></dx:ASPxGridViewExporter>
                                                                            </dx:ContentControl>
                                                                        </ContentCollection>
                                                                    </dx:TabPage>
                                                                </TabPages>
                                                            </dx:ASPxPageControl>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>



                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                            </dx:ASPxPageControl>
                            <dx:ASPxButton ID="btnBildirim" ClientInstanceName="btnBildirim" runat="server" Visible="false" AutoPostBack="false"></dx:ASPxButton>
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
            </Panes>
        </dx:ASPxSplitter>

        <%--message send popup--%>

        <dx:ASPxPopupControl ID="pcmessage_send" runat="server" Width="400" CloseAction="CloseButton" CloseOnEscape="true"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcmessage_send"
            HeaderText="NOT EKLE" AllowDragging="True" Modal="True" PopupAnimationType="fade"
            EnableViewState="False" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="True">
            <SizeGripImage Width="11px" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxPanel ID="ASPxPanel1" runat="server">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxMemo ID="txtmessage" runat="server" Height="100px" Width="100%"></dx:ASPxMemo>
                                <br />
                                <dx:ASPxButton ID="btnsend" Text="Gönder" runat="server" Height="25px" Width="100%" OnClick="btnsend_Click">
                                    <ClientSideEvents Click="function(s,e){pcmessage_send.Hide();}" />
                                </dx:ASPxButton>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

        <%--message send popup--%>

        <dx:ASPxPopupControl ID="pcBildirim" runat="server" CloseAction="OuterMouseClick" LoadContentViaCallback="OnFirstShow"
            PopupElementID="btnBildirim" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
            ShowFooter="True" Width="310px" Height="160px" HeaderText="Updatable content" ClientInstanceName="pcBildirim">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
                    <div style="vertical-align: middle">
                        The content of this popup control was updated at<br />
                        <b><%= DateTime.Now.ToLongTimeString() %></b>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <FooterTemplate>
                <div style="display: table; margin: 6px 6px 6px auto;">
                    <dx:ASPxButton ID="UpdateButton" runat="server" Text="Update Content" AutoPostBack="False"
                        ClientSideEvents-Click="function(s, e) { ClientPopupControl.PerformCallback(); }" />
                </div>
            </FooterTemplate>
        </dx:ASPxPopupControl>
        <dx:ASPxPopupControl ID="pcSelectKanal" runat="server" Width="400" CloseAction="CloseButton" CloseOnEscape="true"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcSelectKanal"
            HeaderText="Kanal Seç" AllowDragging="True" Modal="True" PopupAnimationType="Fade"
            EnableViewState="False" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="true">
            <SizeGripImage Width="11px" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxPanel ID="Panel2" runat="server">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxGridView ID="gridSelectKanal" runat="server" KeyFieldName="KEYFIELDID" Width="100%"
                                    OnHtmlFooterCellPrepared="gridSelectKanal_HtmlFooterCellPrepared"
                                    OnHtmlRowCreated="gridSelectKanal_HtmlRowCreated">
                                    <SettingsBehavior AllowSelectSingleRowOnly="false" />
                                    <SettingsPager Visible="true" Mode="ShowAllRecords"></SettingsPager>
                                    <Settings ShowFilterRow="false" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                    <SettingsSearchPanel Visible="true" />
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="10" SelectAllCheckboxMode="Page" />
                                        <dx:GridViewDataTextColumn FieldName="KNL_KODU" Caption="Kanal Kodu" Width="65"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="KN_ADI" Caption="Kanal Adı" Width="65"></dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:ASPxGridView>
                                <br />
                                <dx:ASPxCheckBox ID="chisimGoster" runat="server" Text="Yönlendirilen Kanalda İsim / Arayan No Gösterilsin" Width="100%"></dx:ASPxCheckBox>
                                <br />
                                <dx:ASPxButton ID="btnTamam" Text="Tamam" runat="server" OnClick="btnTamam_Click">
                                    <ClientSideEvents Click="function(s,e){pcSelectKanal.Hide();}" />
                                </dx:ASPxButton>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxPanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <dx:ASPxGlobalEvents ID="ASPxGlobalEvents1" runat="server" Enabled="False">
            <ClientSideEvents ControlsInitialized="function(s,e){ pcSelectKanal.Show();}" />
        </dx:ASPxGlobalEvents>
    </div>
     
    <div>
    </div>
    <%--<dx:ASPxTimer ID="tmrGridLoad" runat="server" Interval="15000">
        <ClientSideEvents Tick="function(s,e){ grid155.PerformCallback('');
            gridCar.PerformCallback('');
            gridGsa.PerformCallback('');
            gridElp.PerformCallback('');
            gridSon50.PerformCallback('');}" />
    </dx:ASPxTimer>--%>
    <dx:ASPxPopupControl ID="popupBenimIhbarlarim" runat="server" Width="200" CloseAction="CloseButton" CloseOnEscape="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        ClientInstanceName="popupBenimIhbarlarim" HeaderText="Benim İhbarlarım(48 saat)" AllowDragging="True" Modal="True" PopupAnimationType="Fade"
        EnableViewState="False" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="true">
        <SizeGripImage Width="11px" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="pnlBenimIhbarlarim" runat="server">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="4" Width="80%">
                                <Items>
                                    <%-- 1.row --%>
                                    <dx:LayoutItem Caption="İşlemler" ColSpan="4" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <!--OnItemClick="ASPxMenu1_ItemClick1" OnItemDataBound="ASPxMenu1_ItemDataBound" -->
                                                <dx:ASPxMenu ID="ASPxMenu1"
                                                    Width="200px" runat="server" ShowAsToolbar="true" AutoPostBack="True" OnItemClick="ASPxMenu1_ItemClick">
                                                    <Items>
                                                        <dx:MenuItem Name="Yukle" Text="Yükle"></dx:MenuItem>
                                                        <dx:MenuItem Name="Temizle" Text="Temizle"></dx:MenuItem>
                                                    </Items>
                                                </dx:ASPxMenu>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <%--2.row--%>
                                    <dx:LayoutItem Caption="Saat Filtre:" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmbSaat" runat="server" Width="171px" AccessKey="C">
                                                    <Items>
                                                        <dx:ListEditItem Value="" Text="Tümü" />
                                                        <dx:ListEditItem Value="3" Text="Son 3 saat" />
                                                        <dx:ListEditItem Value="6" Text="Son 6 saat" />
                                                        <dx:ListEditItem Value="12" Text="Son 12 saat" />
                                                        <dx:ListEditItem Value="24" Text="Son 24 saat" />
                                                        <dx:ListEditItem Value="48" Text="Son 48 saat" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Başlama Tarihi:" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxDateEdit ID="rDateBaslama" runat="server" Width="171px"></dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Bitiş Tarihi:" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxDateEdit ID="rDateBitis" runat="server" Width="171px"></dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Tip" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rChkTip" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Durum" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rChkDurum" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <%--3.row--%>
                                    <dx:LayoutItem Caption="Tel" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="t_tel" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İhbarcı Telefonu" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="rTxtIhbarcitel" ClientInstanceName="rTxtIhbarcitel" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İhbarcı Adı" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="rTxtIhbarciAd" ClientInstanceName="rTxtIhbarciAd" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Alt Olay" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxGridLookup ID="lookAltOlay" runat="server" KeyFieldName="A_ID" SelectionMode="Multiple" ClientInstanceName="lookAltOlay" Width="171px" TextFormatString="{1}" MultiTextSeparator=",">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataColumn FieldName="A_IHBAR" />
                                                        <dx:GridViewDataColumn FieldName="A_ID" Visible="false" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>

                                                        <SettingsPager PageSize="7" EnableAdaptivity="true" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Diğer" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rChkDiger" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <%--4.row--%>
                                    <dx:LayoutItem Caption="Kullanıcı" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtKullanici" ClientInstanceName="txtKullanici" runat="server" Theme="Office2003Blue" Width="171px"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnGetUser" runat="server" Height="10px" Width="20px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İlçe" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxGridLookup ID="lookIlce" runat="server" KeyFieldName="ILCEID" SelectionMode="Multiple" ClientInstanceName="lookIlce" Width="171px" TextFormatString="{1}" MultiTextSeparator=",">
                                                    <GridViewClientSideEvents SelectionChanged="function(s, e) {
	OnIlceChanged(lookIlce);
}" />
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataColumn FieldName="AD" />
                                                        <dx:GridViewDataColumn FieldName="ILCEID" Visible="false" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>

                                                        <SettingsPager PageSize="7" EnableAdaptivity="true" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Mahalle" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxGridLookup ID="lookMahalle" runat="server" KeyFieldName="ILCEID" SelectionMode="Multiple" ClientInstanceName="lookMahalle" Width="171px" TextFormatString="{1}" MultiTextSeparator=",">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataColumn FieldName="AD" />
                                                        <dx:GridViewDataColumn FieldName="ILCEID" Visible="false" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>

                                                        <SettingsPager PageSize="7" EnableAdaptivity="true" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Cadde-Sokak" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txtCadde" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Site Adı" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_SiteAdi" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <%--5.row--%>
                                    <dx:LayoutItem Caption="Kanal" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxGridLookup ID="lookKanal" runat="server" KeyFieldName="KNL_KODU" SelectionMode="Multiple" ClientInstanceName="lookKanal" Width="171px" TextFormatString="{1}" MultiTextSeparator=";">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataColumn FieldName="KN_ADI" />
                                                        <dx:GridViewDataColumn FieldName="KNL_KODU" Visible="false" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>

                                                        <SettingsPager PageSize="7" EnableAdaptivity="true" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="Log" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxGridLookup ID="lookLog" runat="server" KeyFieldName="ID" SelectionMode="Multiple" ClientInstanceName="lookLog" Width="171px" TextFormatString="{1}" MultiTextSeparator=";">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataColumn FieldName="LOGMESAJ" />
                                                        <dx:GridViewDataColumn FieldName="ID" Visible="false" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>

                                                        <SettingsPager PageSize="7" EnableAdaptivity="true" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="Plaka" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txtPlaka" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="İhbar Türü" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxGridLookup ID="lookUstOlay" runat="server" KeyFieldName="IH_ADI" SelectionMode="Multiple" ClientInstanceName="lookUstOlay" Width="171px" TextFormatString="{1}" MultiTextSeparator=",">
                                                    <Columns>
                                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                                        <dx:GridViewDataColumn FieldName="IH_ADI" />
                                                        <dx:GridViewDataColumn FieldName="IH_ADI" Visible="false" />
                                                    </Columns>
                                                    <GridViewProperties>
                                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>

                                                        <SettingsPager PageSize="7" EnableAdaptivity="true" />
                                                    </GridViewProperties>
                                                </dx:ASPxGridLookup>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İçerik Arama" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txtIcerikArama" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                </Items>
                            </dx:ASPxFormLayout>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>



                <dx:ASPxPanel ID="ASPxPanel5" runat="server">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxGridView ID="gridBenimIhbarlarim" runat="server" KeyFieldName="" Width="100%" ClientInstanceName="gridBenimIhbarlarim" OnCustomCallback="gridBenimIhbarlarim_CustomCallback">
                                <SettingsBehavior AllowSelectSingleRowOnly="false" />
                                <SettingsPager Visible="true" Mode="ShowAllRecords"></SettingsPager>
                                <Settings ShowFilterRow="True" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                <SettingsSearchPanel Visible="true" />
                                <Columns>

                                    <%--<dx:GridViewDataTextColumn FieldName="I_ONCELIKLI" Caption="Öncelikli" VisibleIndex="1"></dx:GridViewDataTextColumn>--%>
                                    <dx:GridViewDataTextColumn FieldName="I_KAYNAK" Caption="Kaynak" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_DURUM" Caption="Sonuç" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="SAAT" Caption="Tarih" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="U_IHBAR" Caption="Üst Olay Adı" Visible="false" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_OLAYADI" Caption="Alt Olay Adı" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_TELEFON" Caption="İhbarcı Telefonu" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ISIMSOYISIM" Caption="İhbarcı Adı" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_CADDE" Caption="Cadde Sokak" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ADI" Caption="Mahalle" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_KULLANICI" Caption="Kullanıcı" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ID" Visible="false" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="cmpt_islemdurum" Visible="false" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" Visible="false" VisibleIndex="2"></dx:GridViewDataTextColumn>

                                </Columns>
                            </dx:ASPxGridView>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>

            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <script type="text/javascript">
        function OnContextMenuItemClick(s, e) {
            var kanal;
            if (e.item.name == "grid155_cm_ihbarAc") {
                OpenDetay(s, e);
            }
            else if (e.item.name == "grid155_cm_ihbarDetay") {
                OpenDetay(s, e);
            }
            else if (e.item.name == "grid155_cm_takipAl") {
                e.processOnServer = true;
            }
            else if (e.item.name == "grid155_cm_takipTamam") {
                e.processOnServer = true;
            }
            else if (e.item.name == "grid155_cm_grupAmirTakip") {

                e.processOnServer = true;
            }
            else if (e.item.name == "grid155_cm_ihbarNot") {
                pcmessage_send.Show();
                e.processOnServer = true;
            }
            else if (e.item.name == "grid155_cm_excelAktar") {

                e.processOnServer = true;
            }
            else if (e.item.name == "gridCar_cm_excelAktar") {

                e.processOnServer = true;
            }
            else if (e.item.name == "gridGsa_cm_excelAktar") {

                e.processOnServer = true;
            }
            else if (e.item.name == "gridElp_cm_excelAktar") {

                e.processOnServer = true;
            }
            else if (e.item.name == "gridSon50_cm_excelAktar") {

                e.processOnServer = true;
            }
            else if (e.item.name == "grid155_cm_ihbarAc") {
                OpenDetay(s, e);
            }
            else if (e.item.name == "grid155_cm_haritaGoster") {
                s.GetRowValues(s.GetFocusedRowIndex(), 'I_LONGITUDE;I_LATITUDE', OnGetSelectedFieldValues);

            }
            else if (e.item.name == "grid155_cm_listeGuncelle") {
                //grid155.PerformCallback('');
                //gridCar.PerformCallback('');
                //gridGsa.PerformCallback('');
                //gridElp.PerformCallback('');
                //gridSon50.PerformCallback('');

            }
            else if (e.item.name == "gridHrtKsyl_cm_kisayolSil") {
                e.processOnServer = true;
            }
            else if (e.item.name == "grid155_cm_benimIhbar") {
                benimIhbarlarimFiltreTemizle();
                txtKullanici.SetValue("<%= HttpContext.Current.Session["USR_SICILNO"].ToString()%>");
                var gridBilgileri = e.elementIndex + "|" + e.item.name;
                gridBenimIhbarlarim.PerformCallback(gridBilgileri);

                popupBenimIhbarlarim.SetVisible(true);
                popupBenimIhbarlarim.SetHeaderText("Benim İhbarlarım(48 Saat)");
            }
            else if (e.item.name == "grid155_cm_telGelenIhbar") {
                benimIhbarlarimFiltreTemizle();
                s.GetRowValues(e.elementIndex, 'I_TELEFON', telefonFiltresiDoldur);

                var gridBilgileri = e.elementIndex + "|" + e.item.name;
                gridBenimIhbarlarim.PerformCallback(gridBilgileri);
                popupBenimIhbarlarim.SetHeaderText("Telefondan Gelen İhbarlar");
                popupBenimIhbarlarim.SetVisible(true);
            } else if (e.item.name == "grid155_cm_IhbarciGelenIhbar") {
                benimIhbarlarimFiltreTemizle();

                s.GetRowValues(e.elementIndex, 'I_ISIMSOYISIM', ihbarciAdiFiltresiDoldur);

                var gridBilgileri = e.elementIndex + "|" + e.item.name;
                gridBenimIhbarlarim.PerformCallback(gridBilgileri);
                popupBenimIhbarlarim.SetHeaderText("İhbarcıdan Gelen İhbarlar");
                popupBenimIhbarlarim.SetVisible(true);
            } else if (e.item.name == "grid155_cm_kanalIhbar") {
                var gridBilgileri = e.elementIndex + "|" + e.item.name;
                gridBenimIhbarlarim.PerformCallback(gridBilgileri);
                popupBenimIhbarlarim.SetHeaderText("Kanalın İhbarları(24 Saat)");
                popupBenimIhbarlarim.SetVisible(true);

                benimIhbarlarimFiltreTemizle();
                <%--kanal = "";
                kanal = '<%= HttpContext.Current.Session["SS_KANAL"].ToString()%>';
                var lstKanal = kanal.split(',');
                for (i = 0; i < lstKanal.length; i++)
                {
                    lookKanal.SetValue(lstKanal[i]);
                }--%>

                lookKanal.SetValue("KNL5");
                lookKanal.SetValue("KNL9");


            } else if (e.item.name == "grid155_cm_ihbarSorgu") {
                benimIhbarlarimFiltreTemizle();
                kanal = "";
                kanal = '<%= HttpContext.Current.Session["SS_KANAL"].ToString()%>';
                var lstKanal = kanal.split(',');
                for (i = 0; i < lstKanal.length; i++) {
                    lookKanal.SetValue(lstKanal[i]);
                }

                var gridBilgileri = e.elementIndex + "|" + e.item.name;
                gridBenimIhbarlarim.PerformCallback(gridBilgileri);
                popupBenimIhbarlarim.SetHeaderText("İhbar Sorgu");
                popupBenimIhbarlarim.SetVisible(true);
            } else if (e.item.name == "grid155_cm_takipIhbar") {
                benimIhbarlarimFiltreTemizle();

                txtKullanici.SetText("<%= HttpContext.Current.Session["USR_SICILNO"].ToString()%>");

                kanal = "";
                kanal = '<%= HttpContext.Current.Session["SS_KANAL"].ToString()%>';
                var lstKanal = kanal.split(',');
                for (i = 0; i < lstKanal.length; i++) {
                    lookKanal.SetValue(lstKanal[i]);
                }

                var gridBilgileri = e.elementIndex + "|" + e.item.name;
                gridBenimIhbarlarim.PerformCallback(gridBilgileri);
                popupBenimIhbarlarim.SetHeaderText("Takibe Alınmış İhbarlarım");
                popupBenimIhbarlarim.SetVisible(true);
            }
}

function OpenDetaySon100(s, e) {
    s.GetRowValues(s.GetFocusedRowIndex(), 'I_ID;I_KANAL', OpenDetayFormSon100);
}

function OpenDetayFormSon100(values) {

    if (values != '') {
        window.name = "myMainWindow";
        window.open('KanalIhbarDetay.aspx?IhbarId=' + values[0] + '&SON100=1' + '&IHBARKANAL=' + values[1]);
        handle.check_auth_status();
    }

}

function OpenDetay(s, e) {

    s.GetRowValues(s.GetFocusedRowIndex(), 'I_ID;I_KANAL', OpenDetayForm);
}

function OpenDetayForm(values) {
    if (values != '') {
        window.name = "myMainWindow";
        window.open('KanalIhbarDetay.aspx?IhbarId=' + values[0] + '&SON100=0' + '&IHBARKANAL=' + values[1]);
        handle.check_auth_status();
    }

}

function OnGetRowValues(Values) {
    gridKmrListe.PerformCallback(Values);
}


    </script>
    
</asp:Content>
