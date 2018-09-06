<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucntrl_Kanal.ascx.cs" Inherits="EgmYKS.Ucntrl.Ucntrl_Kanal" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



  <link rel="Shortcut Icon" href="~/Logo/icon.png" type="image/x-icon"/>
    <link href="../css/themes/bootstrap.min.css" rel="stylesheet" />
   <link href="../css/theme.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
<script>
    $(document).ready(function () {
        $("#menuislemleri>a").addClass("open");
        $("#menuislemleri>ul").css("display", "block");
    });
</script>
<h3>
                                <i class="fa fa-users"></i>Kanal İşlemi
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

<asp:Panel ID="Warning2" runat="server" Visible="false" Width="100%">
    <div class="alert alert-warning" style="width: 100%">
        <a class="close" data-dismiss="alert" href="#">×</a> <strong>Uyarı!</strong>
       <strong><span class="repeated"> Bu kanal kodu mevcut!</span></strong>
    </div>
</asp:Panel>


<asp:Panel ID="Warning_error" runat="server" Visible="false" Width="100%">
    <div class="alert alert-warning" style="width: 100%">
        <a class="close" data-dismiss="alert" href="#">×</a> <strong>Uyarı: 
        <asp:Label ID="lblerrormesaj" runat="server"></asp:Label>
        </strong>
    </div>
</asp:Panel>
    <div style="width: 100%">
    <asp:Label ID="Label1" runat="server" Text="Kanal Kodu*"></asp:Label>
    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Theme="Moderno" Width="100%" NullText="Zorunlu alan...">
    </dx:ASPxTextBox>
    <asp:Label ID="Label2" runat="server" Text="Kanal Adı*"></asp:Label>
    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Theme="Moderno" Width="100%" NullText="Zorunlu alan...">
    </dx:ASPxTextBox>
    <asp:Label ID="Label3" runat="server" Text="Kanal Tipi*"></asp:Label>
    <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" Theme="Moderno" Width="100%" SelectedIndex="0">
        <Items>
            <dx:ListEditItem Text="Seçiniz" Selected="true" />
            <dx:ListEditItem Text="İLÇE" Value="I"/>
            <dx:ListEditItem Text="KANAL" Value="K"/>
        </Items>
    </dx:ASPxComboBox>


    <asp:Label ID="Label4" runat="server" Text="İlçe"></asp:Label>
    <dx:ASPxGridLookup ID="_ilce" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="ILCEID" SelectionMode="Multiple" TextFormatString="{1}" Theme="Moderno" Width="100%" IncrementalFilteringMode="StartsWith">
                                                <GridViewProperties>
                                                    <SettingsBehavior AllowFocusedRow="True" allowselectbyrowclick="True" />
                                                    <SettingsPager Mode="ShowAllRecords">
                                                    </SettingsPager>
                                                    <Settings ColumnMinWidth="50" VerticalScrollBarMode="Auto" />
                                                </GridViewProperties>
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="İlçe Kodu" FieldName="ILCEID" MinWidth="100" VisibleIndex="1" Width="100px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="İlçe Adı" FieldName="AD" MinWidth="150" VisibleIndex="2" Width="150px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewCommandColumn Caption="Seç" ShowSelectCheckbox="True" VisibleIndex="0">
                                                    </dx:GridViewCommandColumn>
                                                </Columns>
                                            </dx:ASPxGridLookup>

    <asp:Label ID="Label6" runat="server" Text="Diğer Kanal"></asp:Label>
    <dx:ASPxGridLookup ID="_DigerKanal" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="KNL_KODU" SelectionMode="Multiple" 
        TextFormatString="{1}" Theme="Moderno" Width="100%" IncrementalFilteringMode="StartsWith">
                                                <GridViewProperties>
                                                    <SettingsBehavior AllowFocusedRow="True" allowselectbyrowclick="True" />
                                                    <SettingsPager Mode="ShowAllRecords">
                                                    </SettingsPager>
                                             <Settings ColumnMinWidth="50" VerticalScrollBarMode="Auto" />
                                                </GridViewProperties>
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Kanal Kodu" FieldName="KNL_KODU" MinWidth="100" VisibleIndex="1" Width="100px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Kanal Adı" FieldName="KN_ADI" MinWidth="150" VisibleIndex="2" Width="150px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewCommandColumn Caption="Seç" ShowSelectCheckbox="True" VisibleIndex="0">
                                                    </dx:GridViewCommandColumn>
                                                </Columns>
                                            </dx:ASPxGridLookup> 
 
    <asp:Label ID="Label5" runat="server" Text="Tip*"></asp:Label>
    <dx:ASPxGridLookup ID="_tip" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="T_ID" TextFormatString="{1}" Theme="Moderno" Width="100%" IncrementalFilteringMode="StartsWith" NullText="Zorunlu alan...">
                                                <GridViewProperties>
                                                    <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" />
                                                    <SettingsPager Mode="ShowAllRecords">
                                                    </SettingsPager>
                                                    <Settings ColumnMinWidth="50" VerticalScrollBarMode="Auto" />
                                                </GridViewProperties>
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Tip Kodu" FieldName="T_ID" MinWidth="100" VisibleIndex="1" Width="100px">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Tip Adı                      " FieldName="T_ADI" MinWidth="150" VisibleIndex="2" Width="150px">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridLookup>
    <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Text="Kanal Durum" Theme="MetropolisBlue">
    </dx:ASPxCheckBox>
    <table style="width:100%;">
        <tr>
            <td>
                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Kaydet" Theme="Moderno" OnClick="ASPxButton1_Click">
                </dx:ASPxButton>
            </td>
            <td>&nbsp;</td>
            <td align="right">
                <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Yeni" Theme="Moderno" OnClick="ASPxButton2_Click">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
</div>


<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
    EnableTheming="True" Theme="Moderno" Width="100%" KeyFieldName="KNL_ID">
    <Columns>
        <dx:GridViewDataTextColumn Caption="Kanal Kodu" FieldName="KNL_KODU" 
            VisibleIndex="2" Width="20%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Seç" VisibleIndex="7" Width="2%">
            <DataItemTemplate>
                <dx:ASPxButton ID="ASPxButton3" runat="server" OnCommand="ASPxButton3_Command"  CommandArgument="<%# Bind('KNL_ID')%>" RenderMode="Link">
                    <Image Url="~/images/Show_16x16.png">
                    </Image>
                </dx:ASPxButton>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Sil" VisibleIndex="8" Width="2%" Visible="False">
            <DataItemTemplate>
                <dx:ASPxButton ID="ASPxButton4" runat="server" OnCommand="ASPxButton4_Command"  CommandArgument="<%# Bind('KNL_ID') %>" RenderMode="Link">
                    <ClientSideEvents Click="function(s, e) {
	e.processOnServer = confirm('Silmek istiyor musunuz?');
}" />
                    <Image Url="~/images/DeleteList2_16x16.png">
                    </Image>
                </dx:ASPxButton>
            </DataItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Kanal Adı" FieldName="KN_ADI" VisibleIndex="3" Width="60%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Kanal Yetki" FieldName="KNL_YETKI" VisibleIndex="4" Width="10%">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Diğer Kanal" FieldName="KNL_DIGERKANAL" VisibleIndex="3" Width="60%">
        </dx:GridViewDataTextColumn> 
         <dx:GridViewDataTextColumn Caption="KANAL_ILÇE" FieldName="KNL_ILCE" VisibleIndex="3" Width="60%">
        </dx:GridViewDataTextColumn> 
        <dx:GridViewDataCheckColumn Caption="Durum" FieldName="KNL_DURUM" VisibleIndex="6" Width="6%">
        </dx:GridViewDataCheckColumn>
    </Columns>
    <SettingsBehavior AllowFocusedRow="True" />
    <SettingsPager>
        <Summary Text="Sayfa {0} / {1} ({2} veri)" />
    </SettingsPager>
    <Settings ShowFilterRow="True"  />
    <SettingsText EmptyDataRow="Veri yok..." />
    <SettingsLoadingPanel Text="Yükleniyor&amp;hellip;" />
</dx:ASPxGridView>



