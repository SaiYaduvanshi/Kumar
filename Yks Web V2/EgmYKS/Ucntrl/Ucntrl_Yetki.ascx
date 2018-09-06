<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucntrl_Yetki.ascx.cs" Inherits="EgmYKS.Ucntrl.Ucntrl_Yetki" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>




    

    <link rel="Shortcut Icon" href="~/Logo/icon.png" type="image/x-icon"/>
    <link href="../css/themes/bootstrap.min.css" rel="stylesheet" />
   <link href="../css/theme.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
<style type="text/css">
   
    .style16
    {
        width: 20%;
    }
     .style17
    {
        width: 80%;
    }
    .auto-style4 {
         width:10%;
    }
     .auto-style5 {
        
        width: 90%;
    }
    </style>
<script type="text/javascript">
    function popup() {
        personelpop.Show();
    }
    function yetki() {
        personelyetki.Show();
    }
    $(document).ready(function () {
        $("#kullaniciislemleri>a").addClass("open");
        $("#kullaniciislemleri>ul").css("display", "block");
    });
    </script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
          <h3>
                                <i class="fa fa-bolt"></i>Yetki İşlemi
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
                              <strong><span class="repeated">  Bu yetki adı mevcut!</span></strong>
                            </div>
                        </asp:Panel>
      
        <table style="width:100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Yetki Adı"></asp:Label>
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Theme="Moderno" Width="100%" OnTextChanged="ASPxTextBox1_TextChanged">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" align="right">
                    <dx:ASPxButton ID="ASPxButton2" runat="server" onclick="ASPxButton2_Click" Text="Yeni" Theme="Moderno" Width="120px">
                    </dx:ASPxButton>
                </td>
                <td align="right" class="auto-style4">
                    <dx:ASPxButton ID="ASPxButton1" runat="server" onclick="ASPxButton1_Click" Text="Kaydet" Theme="Moderno" Width="120px">
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTheming="True" Theme="MetropolisBlue" Width="100%">
            <TabPages>
                <dx:TabPage Text="Yetkiler">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" Width="100%">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Yetki Adı" FieldName="YT_YETKIADI" ShowInCustomizationForm="True" VisibleIndex="0" Width="90%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Seç" ShowInCustomizationForm="True" VisibleIndex="1" Width="5%">
                                        <DataItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("YT_YETKIID")+";"+Eval("YT_YETKIADI")%>' ImageUrl="~/images/Forward_16x16.png" onclick="ImageButton1_Click" ToolTip="Seç" />
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Sil" ShowInCustomizationForm="True" VisibleIndex="2" Width="5%" Visible="False">
                                        <DataItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("YT_YETKIID")%>' ImageUrl="~/images/DeleteList2_16x16.png" onclick="ImageButton2_Click" OnClientClick="return confirm('Silmek istiyor musunuz?');" ToolTip="Sil" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <Settings UseFixedTableLayout="True" VerticalScrollableHeight="300" VerticalScrollBarMode="Auto" />
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Yetki Detay">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="MDL_MODULID" Theme="Moderno" Width="100%">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Modul Adı" FieldName="MDL_MODULADI" ShowInCustomizationForm="True" VisibleIndex="0" Width="60%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Okuma" ShowInCustomizationForm="True" VisibleIndex="1" Width="10%">
                                        <DataItemTemplate>
                                            <dx:ASPxCheckBox ID="chkoku" runat="server" Theme="MetropolisBlue">
                                            </dx:ASPxCheckBox>
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Yazma" ShowInCustomizationForm="True" VisibleIndex="2" Width="10%">
                                        <DataItemTemplate>
                                            <dx:ASPxCheckBox ID="chkyaz" runat="server" Theme="Youthful">
                                            </dx:ASPxCheckBox>
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Silme" ShowInCustomizationForm="True" VisibleIndex="3" Width="10%">
                                        <DataItemTemplate>
                                            <dx:ASPxCheckBox ID="chksil" runat="server" Theme="RedWine">
                                            </dx:ASPxCheckBox>
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ekstra" ShowInCustomizationForm="True" VisibleIndex="5" Width="10%">
                                        <DataItemTemplate>
                                            <dx:ASPxCheckBox ID="ekstra" runat="server" Theme="SoftOrange">
                                            </dx:ASPxCheckBox>
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager Mode="ShowAllRecords">
                                </SettingsPager>
                                <Settings VerticalScrollableHeight="300" VerticalScrollBarMode="Auto" />
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
            <ContentStyle>
                <Paddings Padding="1px" />
            </ContentStyle>
        </dx:ASPxPageControl>
         
     
    </ContentTemplate>
</asp:UpdatePanel>







