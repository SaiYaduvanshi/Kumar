<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="SecurityCompany.aspx.cs" Inherits="EgmYKS.SecurityCompany" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function CloseGridLookup() {

            //gridLookup.ConfirmCurrentSelection();
            gridLookup.HideDropDown();
            //gridLookup.Focus();
        }
        function OnCompanyChanged(cmbCompany) {
            cmbCompanySubscriber.PerformCallback(cmbCompany.GetValue().toString());
            txtcompanyphone.SetText("");
            txtcompanyauthorized.SetText("");
            txtsubscriberphone.SetText("");
            memosubscriberaddress.SetText("");
            callback1.PerformCallback(cmbCompany.GetValue().toString());
        }
        function OnEndCallback(s, e) {
        }
        function OnEndCallback2(s, e) {
        }
        function OnEndCallback3(s, e) {
        }
        function OnCallbackComplete(s, e) {
            var snc = JSON.parse(e.result);
            txtcompanyphone.SetText(snc.SirketTelefon);
            txtcompanyauthorized.SetText(snc.SirketGorevli);
        }
        function OnSubscriberChanged(sbsc) {
            callback2.PerformCallback(sbsc.GetValue().toString());
        }
        function OnCallbackSubscribeComplete(s, e) {
            var snc = JSON.parse(e.result);
            txtsubscriberphone.SetText(snc.SirketTelefon);
            memosubscriberaddress.SetText(snc.SirketGorevli);
        }
        function OnCompanyTownChanged(town) {
            cmbneighborhood.PerformCallback(town.GetValue().toString());
        }
        function OnNeighborhoodChanged(neighbor) {
            var snc = [cmbcompanytown.GetValue().toString(), cmbneighborhood.GetValue().toString()];
            cmbstreet.PerformCallback(snc);
        }
        function onClearButtonClick(s, e) {
            var container = document.getElementsByClassName("mainContainer")[0];
            ASPxClientEdit.ClearEditorsInContainer(container);
        }
        function onCancelButtonClick(s, e) {
            onClearButtonClick(s, e);
            popAddNew.Hide();
        }
        function onSaveButtonClick(s, e) {
            if (ASPxClientEdit.AreEditorsValid("ASPxFormLayout3")) {
                callback3.PerformCallback("Kayıt");
            }
        }
        function OnCallbackSaveComplete(s, e) {
            alert("Kayıt Eklendi.");
        }
        function onSaveButtonIletClick(s, e) {
            if (ASPxClientEdit.AreEditorsValid("ASPxFormLayout3")) {
                callback3.PerformCallback("İletilen");
            }
            
        }
    </script>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="I_ID">
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0">
                <HeaderCaptionTemplate>
                    <dx:ASPxButton runat="server" Text="" ID="btnNew" ClientInstanceName="btnNew" AutoPostBack="False">
                        <HoverStyle CssClass="icqHovered"></HoverStyle>
                        <PressedStyle CssClass="icqPressed"></PressedStyle>
                        <Image Url="images/Add_16x16.png" Width="16px" Height="16px"></Image>
                        <Border BorderStyle="Solid"></Border>
                        <ClientSideEvents Click="function ShowLoginWindow() { popAddNew.Show(); }"></ClientSideEvents>
                    </dx:ASPxButton>
                </HeaderCaptionTemplate>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Caption="Alarm Tarihi" FieldName="I_TARIH" Name="gridColumn1" VisibleIndex="1">
                <EditFormSettings VisibleIndex="1" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn Caption="Güvenlik Şirketi" FieldName="G_SIRKETADI" VisibleIndex="2">
                <EditFormSettings VisibleIndex="2" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Şirket Görevlisi" FieldName="G_IRTIBATISMI" VisibleIndex="3">
                <EditFormSettings VisibleIndex="3" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Şirket Abonesi" FieldName="GM_MUSTERIISIM" VisibleIndex="4">
                <EditFormSettings VisibleIndex="4" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Telefon" FieldName="G_IRTIBATTELEFON" VisibleIndex="5">
                <EditFormSettings VisibleIndex="5" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataMemoColumn Caption="Abone Adresi" FieldName="GM_ADRES" VisibleIndex="6">
                <EditFormSettings VisibleIndex="6" />
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataColumn Caption="Kullanıcı" FieldName="I_KULLANICI" VisibleIndex="7">
                <EditFormSettings VisibleIndex="7" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="İlçe" FieldName="AD" VisibleIndex="8">
                <EditFormSettings VisibleIndex="8" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Alarm Türü" FieldName="A_ADI" VisibleIndex="9">
                <EditFormSettings VisibleIndex="9" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Not" FieldName="I_OPERATORNOT" VisibleIndex="10">
                <EditFormSettings VisibleIndex="10" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn FieldName="cmpt_islemdurum" Visible="False" VisibleIndex="11">
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn FieldName="I_ID" Visible="False" VisibleIndex="12">
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn FieldName="DURUM2" Visible="False" VisibleIndex="13">
            </dx:GridViewDataColumn>
        </Columns>
        <SettingsEditing EditFormColumnCount="1" Mode="PopupEditForm" />
        <SettingsPopup>
            <EditForm Modal="True" />
        </SettingsPopup>
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="768" />
        </EditFormLayoutProperties>
    </dx:ASPxGridView>

    <dx:ASPxPopupControl ID="popAddNew" runat="server" Width="768" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popAddNew"
        HeaderText="Yeni İhbar" AllowDragging="True" PopupAnimationType="None" EnableViewState="False" AutoUpdatePosition="true" ShowFooter="True">

        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ColCount="6" Width="98%" CssClass="mainContainer">
                    <Items>
                        <dx:LayoutItem Caption="Alarm Tarihi" ColSpan="6" Width="100%" CssClass="container">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="dateAlarm" runat="server" EditFormat="Custom" EditFormatString="dd.MM.yyyy" Width="100%" Caption="" EncodeHtml="false">
                                        <CalendarProperties>
                                            
                                        </CalendarProperties>
                                        <ValidationSettings SetFocusOnError="True" ErrorText=""  ErrorTextPosition="Bottom" Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Alarm tarihi giriniz" />
                                        </ValidationSettings>
                                        
                                        <InvalidStyle BackColor="LightPink" />
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Güvenlik Şirketi" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>

                                    <dx:ASPxComboBox runat="server" ID="cmbCompany" DropDownStyle="DropDownList" IncrementalFilteringMode="StartsWith"
                                        Width="100%" EnableSynchronization="False">
                                        <ClearButton DisplayMode="Always"></ClearButton>
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCompanyChanged(s); }" />
                                        <ValidationSettings SetFocusOnError="True" ErrorText="" ErrorTextPosition="Bottom" Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Güvenlik şirketi seçiniz" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>

                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Şirket Telefonu" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtCompanyPhone" runat="server" Theme="Office2003Blue" Width="100%"
                                        ClientInstanceName="txtcompanyphone" AutoPostBack="False" AutoCompleteType="Disabled">
                                        
                                    </dx:ASPxTextBox>


                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Şirket Görevlisi" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtCompanyAuthorized" ClientInstanceName="txtcompanyauthorized" runat="server" Theme="Office2003Blue" Width="100%" AutoCompleteType="Disabled"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Şirket Abonesi" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="cmbCompanySubscriber" ClientInstanceName="cmbCompanySubscriber" OnCallback="CmbSubscriber_Callback"
                                        DropDownStyle="DropDown" Width="100%"
                                        IncrementalFilteringMode="StartsWith" EnableSynchronization="False">
                                        <ClientSideEvents EndCallback="OnEndCallback" SelectedIndexChanged="function(s, e) { OnSubscriberChanged(s); }"></ClientSideEvents>
                                        <ValidationSettings SetFocusOnError="True" ErrorText="" ErrorTextPosition="Bottom" Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Şirket abonesi seçiniz" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Abone Telefonu" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txtSubscriberPhone" ClientInstanceName="txtsubscriberphone" runat="server" Theme="Office2003Blue" Width="100%" AutoCompleteType="Disabled"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Abone Adresi:" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="memoSubscriberAddress" ClientInstanceName="memosubscriberaddress" runat="server" Width="100%"></dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="İlçe:" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbCompanyTown" runat="server" DropDownStyle="DropDownList" ClientInstanceName="cmbcompanytown"
                                        ValueField="CategoryID" ValueType="System.String" TextFormatString="{0} ({1})" Width="100%">
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCompanyTownChanged(s); }"></ClientSideEvents>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="İlgilenecek Kanal:" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxGridLookup ID="GridLookup" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup"
                                        Width="100%" TextFormatString="{0}" MultiTextSeparator=", " Caption="" KeyFieldName="KNL_KODU">
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                            <dx:GridViewDataColumn FieldName="KN_ADI" Caption="Kanal Seçiniz" />
                                        </Columns>
                                        <GridViewProperties>
                                            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True"></SettingsBehavior>
                                        </GridViewProperties>
                                        <ValidationSettings SetFocusOnError="True" ErrorText="" ErrorTextPosition="Bottom" Display="Dynamic" causesvalidation="True">
                                            <RequiredField IsRequired="True" ErrorText="En az bir kanal seçiniz" />
                                        </ValidationSettings>
                                    </dx:ASPxGridLookup>
                                   
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Mahalle:" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox runat="server" ID="cmbNeighborhood" ClientInstanceName="cmbneighborhood" OnCallback="CmbNeighborhood_Callback"
                                        DropDownStyle="DropDown" Width="100%"
                                        IncrementalFilteringMode="StartsWith" EnableSynchronization="False">
                                        <ClientSideEvents EndCallback=" OnEndCallback2" SelectedIndexChanged="function(s, e) { OnNeighborhoodChanged(s); }" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Blv.Cad.Sokak:" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>

                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 56%;">
                                                <dx:ASPxComboBox runat="server" ID="cmbStreet" ClientInstanceName="cmbstreet" OnCallback="CmbStreet_Callback"
                                                    DropDownStyle="DropDown" Width="100%"
                                                    IncrementalFilteringMode="StartsWith" EnableSynchronization="False">
                                                    <ClientSideEvents EndCallback=" OnEndCallback3" />
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td style="width: 20%;">
                                                <dx:ASPxTextBox ID="txtBuilding" runat="server" Theme="Office2003Blue" Width="100%" NullText="Bina No"></dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td style="width: 20%;">
                                                <dx:ASPxTextBox ID="txtApartment" runat="server" Theme="Office2003Blue" Width="100%" NullText="Daire"></dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Site/Bina:" ColSpan="6" Width="100%">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>

                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 49%;">
                                                <dx:ASPxTextBox NullText="Site Adı" ID="txtSiteName" runat="server" Theme="Office2003Blue" Width="100%" AutoCompleteType="Disabled"></dx:ASPxTextBox>
                                            </td>
                                            <td style="width: 2%;"></td>
                                            <td style="width: 49%;">
                                                <dx:ASPxTextBox NullText="Bina Adı" ID="txtBuildingName" runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Alarm Türü:" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="cmbAlarmType" runat="server" DropDownStyle="DropDownList"
                                        ValueField="CategoryID" ValueType="System.String" TextFormatString="{0} ({1})" Width="100%">
                                        <ValidationSettings SetFocusOnError="True" ErrorText="" ErrorTextPosition="Bottom" Display="Dynamic">
                                            <RequiredField IsRequired="True" ErrorText="Alarm türü seçiniz" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Not:" ColSpan="6">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="memoSecurityDesc" runat="server" Width="100%" Rows="5"></dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>

                    </Items>

                </dx:ASPxFormLayout>
                <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="callback1"
                    OnCallback="ASPxCallback1_Callback">
                    <ClientSideEvents CallbackComplete="OnCallbackComplete" />
                </dx:ASPxCallback>
                <dx:ASPxCallback ID="ASPxCallback2" runat="server" ClientInstanceName="callback2"
                    OnCallback="ASPxSubscribe_Callback">
                    <ClientSideEvents CallbackComplete="OnCallbackSubscribeComplete" />
                </dx:ASPxCallback>
            <dx:ASPxCallback ID="ASPxCallback3" runat="server" ClientInstanceName="callback3"
                             OnCallback="ASPxSave_Callback">
                <ClientSideEvents CallbackComplete="OnCallbackSaveComplete" />
            </dx:ASPxCallback>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
        <FooterTemplate>
            <div style="padding: 10px;">
                <dx:ASPxButton runat="server" Text="Yeni İhbar" AutoPostBack="False">
                    <HoverStyle CssClass="icqHovered"></HoverStyle>
                    <PressedStyle CssClass="icqPressed"></PressedStyle>
                    <Image Url="images/Add_16x16.png" Width="16px" Height="16px"></Image>
                    <Border BorderStyle="None"></Border>
                    <ClientSideEvents Click="onClearButtonClick" />
                </dx:ASPxButton>
                <dx:ASPxButton runat="server" Text="Kaydet" AutoPostBack="False"  >
                    <HoverStyle CssClass="icqHovered"></HoverStyle>
                    <PressedStyle CssClass="icqPressed"></PressedStyle>
                    <Image Url="images/Save_16x16.png" Width="16px" Height="16px"></Image>
                    <Border BorderStyle="None"></Border>
                    <ClientSideEvents Click="onSaveButtonClick"  />
                </dx:ASPxButton>
                <dx:ASPxButton runat="server" Text="Kaydet-İlet" AutoPostBack="False">
                    <HoverStyle CssClass="icqHovered"></HoverStyle>
                    <PressedStyle CssClass="icqPressed"></PressedStyle>
                    <Image Url="images/SaveAndNew_16x16.png" Width="16px" Height="16px"></Image>
                    <Border BorderStyle="None"></Border>
                    <ClientSideEvents Click="onSaveButtonIletClick"  />
                </dx:ASPxButton>
                <dx:ASPxButton runat="server" Text="İptal" AutoPostBack="False" ValidationGroup="GroupA">
                    <HoverStyle CssClass="icqHovered"></HoverStyle>
                    <PressedStyle CssClass="icqPressed"></PressedStyle>
                    <Image Url="images/Cancel_16x16.png" Width="16px" Height="16px"></Image>
                    <Border BorderStyle="None"></Border>
                    <ClientSideEvents Click="onCancelButtonClick"></ClientSideEvents>
                    
                </dx:ASPxButton>
            </div>
        </FooterTemplate>
    </dx:ASPxPopupControl>

</asp:Content>
