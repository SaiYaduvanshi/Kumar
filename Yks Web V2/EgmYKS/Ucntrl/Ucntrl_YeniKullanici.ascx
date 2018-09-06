<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucntrl_YeniKullanici.ascx.cs" Inherits="EgmYKS.Ucntrl.Ucntrl_YeniKullanici" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>




  <link rel="Shortcut Icon" href="~/Logo/icon.png" type="image/x-icon"/>
    <link href="../css/themes/bootstrap.min.css" rel="stylesheet" />
   <link href="../css/theme.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
<style type="text/css">
    .style5
    {
        width: 1px;
    }
    .style7
    {
        width: 90px;
    }
    .style8
    {
        width: 50%;
    }
    .style10
    {
        width: 93px;
    }
    .style13
    {
    }
     .style15
    {
        width: 33%;
    }
</style>
<script type="text/javascript">
    function popup() {
        personelpop.Show();
    }
    function yetki() {
        personelyetki.Show();
    }
    function grup() {
        popgrup.Show();
    }
    </script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
         <h3>
                                <i class="fa fa-users"></i>Kullanıcı İşlemi
                            </h3>
          <asp:Panel ID="succes" runat="server" Visible="false" Width="100%">
                            <div class="alert alert-success alert-dismissable" style="width: 100%">
                                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Başarılı!</strong>
                                İşleminiz başarı ile gerçekleşti.
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="error" runat="server" Visible="false" Width="100%">
                            <div class="alert alert-danger" style="width: 100%">
                                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Hata!</strong> İşleminiz
                                hata aldı!
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="Warning" runat="server" Visible="false" Width="100%">
                            <div class="alert alert-warning" style="width: 100%">
                                <a class="close" data-dismiss="alert" href="#">×</a> <strong>Uyarı!</strong> (*)
                                alanları yazınız!
                            </div>
                        </asp:Panel>
       
        <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" 
            ClientInstanceName="personelyetki" CloseAction="CloseButton" 
            HeaderText="Yetkiler" Modal="True" PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter" Theme="MetropolisBlue" Width="500px">
            <ContentStyle>
                <Paddings Padding="2px" />
            </ContentStyle>
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                    <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" 
                        EnableTheming="True" KeyFieldName="YT_ID" Theme="Moderno" Width="100%">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Yetki Adı" FieldName="YT_YETKIADI" 
                                ShowInCustomizationForm="True" VisibleIndex="2" Width="95%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Seç" ShowInCustomizationForm="True" 
                                VisibleIndex="5" Width="5%">
                                <DataItemTemplate>
                                   
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Apply_16x16.png"  
                                        CommandArgument='<%# Eval("YT_YETKIID")+";"+Eval("YT_YETKIADI")%>' OnCommand="ImageButton1_Command" />
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" />
                        <SettingsPager>
                            <Summary Text="Sayfa {0} / {1} ({2} veri)" />
                        </SettingsPager>
                        <Settings VerticalScrollableHeight="300" />
                        <SettingsText EmptyDataRow="Veri yok..." />
                        <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                    </dx:ASPxGridView>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
          <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" ClientInstanceName="popgrup" CloseAction="CloseButton" HeaderText="Gruplar" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Theme="MetropolisBlue" Width="500px">
              <ContentStyle>
                  <Paddings Padding="2px" />
              </ContentStyle>
              <ContentCollection>
                  <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                      <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="GRP_ID" Theme="Moderno" Width="100%">
                          <Columns>
                              <dx:GridViewDataTextColumn Caption="Grup Adı" FieldName="GRP_ADI" ShowInCustomizationForm="True" VisibleIndex="2" Width="95%">
                              </dx:GridViewDataTextColumn>
                              <dx:GridViewDataTextColumn Caption="Seç" ShowInCustomizationForm="True" VisibleIndex="5" Width="5%">
                                  <DataItemTemplate>
                                      <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("GRP_KODU")+";"+Eval("GRP_ADI")%>' ImageUrl="~/images/Apply_16x16.png" OnCommand="ImageButton2_Command" />
                                  </DataItemTemplate>
                              </dx:GridViewDataTextColumn>
                          </Columns>
                          <SettingsBehavior AllowFocusedRow="True" />
                          <SettingsPager>
                              <Summary Text="Sayfa {0} / {1} ({2} veri)" />
                          </SettingsPager>
                          <Settings VerticalScrollableHeight="300" />
                          <SettingsText EmptyDataRow="Veri yok..." />
                          <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
                      </dx:ASPxGridView>
                  </dx:PopupControlContentControl>
              </ContentCollection>
          </dx:ASPxPopupControl>
        <table style="width:100%;">
            <tr>
                <td class="style8" valign="top">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label33" runat="server" Text="Sicil No"></asp:Label>
                                *</td>
                            <td class="style5">
                                :</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_sicil" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label4" runat="server" Text="İsim"></asp:Label>
                                *</td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_isim" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label32" runat="server" Text="Soyisim"></asp:Label>
                                *</td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_soyisim" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label34" runat="server" Text="Kullanıcı Adı"></asp:Label>
                                *</td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_kullanici" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label27" runat="server" Text="Ev Telefonu"></asp:Label>
                            </td>
                            <td class="style5">
                                :</td>
                            <td>
                                <dx:ASPxTextBox ID="t_evtelefon" runat="server" Theme="Moderno" Width="100%" NullText="Zorunlu alan...">
                           <MaskSettings IncludeLiterals="None" Mask="(000) 000-0000" ErrorText="Eksik rakam."/>
                        <ClientSideEvents  Validation="function(s,e)  { if (e.value == null || e.value =='') e.isValid = true; }"/>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label8" runat="server" Text="İş Telefonu"></asp:Label>
                                </td>
                            <td class="style5">
                                :</td>
                            <td>
                                <dx:ASPxTextBox ID="t_istelefon" runat="server" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                     <MaskSettings IncludeLiterals="None" Mask="(000) 000-0000" ErrorText="Eksik rakam."/>
                        <ClientSideEvents  Validation="function(s,e)  { if (e.value == null || e.value =='') e.isValid = true; }"/>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label35" runat="server" Text="Cep Telefonu"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxTextBox ID="t_ceptelefon" runat="server" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                              <MaskSettings IncludeLiterals="None" Mask="(000) 000-0000" ErrorText="Eksik rakam."/>
                        <ClientSideEvents  Validation="function(s,e)  { if (e.value == null || e.value =='') e.isValid = true; }"/>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label36" runat="server" Text="Rütbesi"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_rutbe" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label37" runat="server" Text="Görevi"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_gorev" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label38" runat="server" Text="Telsiz Kanalı"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxButtonEdit ID="t_telsizkanal" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td class="style7">
                                <asp:Label ID="Label39" runat="server" Text="Vardiya"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td>
                                <dx:ASPxSpinEdit ID="t_vardiya" runat="server" Number="0" Theme="Moderno" Width="100%" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style8" valign="top" align="right">
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label40" runat="server" Text="Dahili"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxButtonEdit ID="t_dahili" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	popup();
}" />
                                    <Buttons>
                                        <dx:EditButton Visible="False">
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label41" runat="server" Text="İl"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxComboBox ID="t_il" runat="server" Theme="Moderno" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="t_il_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label42" runat="server" Text="İlçe"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxComboBox ID="t_ilce" runat="server" Theme="Moderno" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="t_ilce_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label43" runat="server" Text="Şube"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxComboBox ID="t_sube" runat="server" Theme="Moderno" ValueType="System.String" Width="100%" AutoPostBack="true">
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label15" runat="server" Text="Yetki"></asp:Label>
                                *</td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxButtonEdit ID="t_yetki" runat="server" NullText="Zorunlu alan..." ReadOnly="True" Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	yetki();
}" />
                                    <Buttons>
                                        <dx:EditButton>
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label44" runat="server" Text="Grup"></asp:Label>
                                *</td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxButtonEdit ID="t_grup" runat="server" NullText="Zorunlu alan..." ReadOnly="True" Theme="Moderno" Width="100%">
                                    <ClientSideEvents ButtonClick="function(s, e) {
	grup();
}" />
                                    <Buttons>
                                        <dx:EditButton>
                                        </dx:EditButton>
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label31" runat="server" Text="Kanal Yetkisi"></asp:Label>
                                </td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">

                                <dx:ASPxGridLookup ID="t_kanalyetki" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="KNL_KODU" SelectionMode="Multiple"
                                    TextFormatString="{1}" Theme="Moderno" Width="100%" IncrementalFilteringMode="StartsWith">
                                    <gridviewproperties>
                                                    <SettingsBehavior AllowFocusedRow="True" allowselectbyrowclick="True" />
                                                    <SettingsPager Mode="ShowAllRecords">
                                                    </SettingsPager>
                                             <Settings ColumnMinWidth="50" VerticalScrollBarMode="Auto" />
                                                </gridviewproperties>
                                    <columns>
                                                    <dx:GridViewDataTextColumn Caption="Kanal Kodu" FieldName="KNL_KODU" MinWidth="100" VisibleIndex="1" Width="100px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Kanal Adı" FieldName="KN_ADI" MinWidth="150" VisibleIndex="2" Width="150px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewCommandColumn Caption="Seç" ShowSelectCheckbox="True" VisibleIndex="0">
                                                    </dx:GridViewCommandColumn>
                                                </columns>
                                </dx:ASPxGridLookup>


                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style10">
                                <asp:Label ID="Label29" runat="server" Text="Şifre"></asp:Label>
                                *</td>
                            <td class="style5">:</td>
                            <td align="left" colspan="2">
                                <dx:ASPxTextBox ID="t_sifre" runat="server" MaxLength="25" NullText="Zorunlu alan..." Theme="Moderno" Width="100%">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10" align="left">
                                <asp:Label ID="Label24" runat="server" Text="Aktif/Pasif"></asp:Label>
                            </td>
                            <td class="style5">
                                :</td>
                            <td align="left">
                                <dx:ASPxCheckBox ID="aktifpasif" runat="server" Theme="MetropolisBlue">
                                </dx:ASPxCheckBox>
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10" align="left">
                                <asp:Label ID="Label1" runat="server" Text="Kanal Seçim"></asp:Label>
                            </td>
                            <td class="style5">:</td>
                            <td align="left">
                                <dx:ASPxCheckBox ID="chckkanalsecim" runat="server" Theme="MetropolisBlue">
                                </dx:ASPxCheckBox>
                            </td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style10" align="left">
                                &nbsp;</td>
                            <td class="style5">
                                &nbsp;</td>
                            <td align="left" colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td align="center" class="style15">
                                <dx:ASPxButton ID="ASPxButton4" runat="server" onclick="ASPxButton4_Click" 
                                    Text="Yeni" Theme="Moderno" Width="100%" Enabled="False">
                                </dx:ASPxButton>
                            </td>
                            <td align="center" class="style15">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" 
                                    Text="Kaydet" Theme="Moderno" Width="100%" Enabled="False">
                                </dx:ASPxButton>
                            </td>
                            
                            <td align="center" class="style15">
                                <dx:ASPxButton ID="ASPxButton3" runat="server" onclick="ASPxButton3_Click" 
                                    Text="Vazgeç" Theme="Moderno" Width="100%" Enabled="False">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>







