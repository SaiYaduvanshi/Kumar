<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucntrl_KullaniciList.ascx.cs" Inherits="EgmYKS.Ucntrl.Ucntrl_KullaniciList" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


  <link rel="Shortcut Icon" href="~/Logo/icon.png" type="image/x-icon"/>
    <link href="../css/themes/bootstrap.min.css" rel="stylesheet" />
   <link href="../css/theme.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
<script>
    $(document).ready(function () {
        $("#kullaniciislemleri>a").addClass("open");
        $("#kullaniciislemleri>ul").css("display", "block");
    });
</script>
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
<div style="width: 100%">
    <dx:ASPxMenu ID="ASPxMenu1" runat="server" AutoSeparators="RootOnly" 
        EnableTheming="True" HorizontalAlign="Left" ItemAutoWidth="False" 
        onitemclick="ASPxMenu1_ItemClick" Theme="Moderno" Width="100%">
        <Items>
            <dx:MenuItem Name="ISLEM" Text="Yeni Kullanıcı">
                <Image Height="16px" Url="~/images/Add_16x16.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Name="SIL" Text="Sil" Visible="False">
                <Image Height="16px" Url="~/images/DeleteList2_16x16.png">
                </Image>
            </dx:MenuItem>
            <dx:MenuItem Name="YENILE" Text="Yenile">
                <Image Height="16px" Url="~/images/Refresh_16x16.png">
                </Image>
            </dx:MenuItem>
        </Items>
    </dx:ASPxMenu>
</div>


<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
    EnableTheming="True" Theme="Moderno" Width="100%" KeyFieldName="USR_SICILNO">
    <Columns>
        <dx:GridViewCommandColumn Caption="Seç" ShowSelectCheckbox="True" 
            VisibleIndex="0" Width="2%">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn Caption="İsim" FieldName="USR_ADI" VisibleIndex="3" 
            Width="15%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption=" " FieldName="USR_ID" 
            VisibleIndex="21" Width="2%">
             <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" ShowInFilterControl="False" />
             <DataItemTemplate>
                 <dx:ASPxButton ID="ASPxButton1" runat="server" OnCommand="ASPxButton1_Command" CommandArgument="<%# Bind('USR_ID')%>" RenderMode="Link" ToolTip="Detay">
                     <Image Url="~/images/Forward_16x16.png">
                     </Image>
                 </dx:ASPxButton>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Yetki" FieldName="YT_YETKIADI" VisibleIndex="11" 
            Width="14%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataCheckColumn Caption="Durum" FieldName="USR_DURUM" VisibleIndex="18" 
            Width="3%">
            <PropertiesCheckEdit DisplayTextChecked="Aktif" DisplayTextUnchecked="Pasif">
            </PropertiesCheckEdit>
            <Settings AllowAutoFilter="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" />
        </dx:GridViewDataCheckColumn>
        <dx:GridViewDataTextColumn Caption="Grup" VisibleIndex="12" Width="14%" 
            FieldName="GRP_ADI">
            <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="d">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Sicil No" 
            VisibleIndex="2" Width="10%" FieldName="USR_SICILNO">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Soyisim" FieldName="USR_SOYADI" VisibleIndex="9" Width="15%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Son Giriş" FieldName="USR_SONGIRIS" VisibleIndex="13" Width="15%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Rütbe" FieldName="USR_GOREV" VisibleIndex="10" Width="10%">
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager>
        <Summary Text="Sayfa {0} / {1} ({2} veri)" />
    </SettingsPager>
    <Settings ShowFilterRow="True" />
    <SettingsText EmptyDataRow="Veri yok..." />
    <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
</dx:ASPxGridView>



