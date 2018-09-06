﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ucntrl_KanalGrup.ascx.cs" Inherits="EgmYKS.Ucntrl.Ucntrl_KanalGrup" %>
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
    </script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
          <h3>
                                <i class="gi gi-parents"></i>Kanal Grup İşlemi
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
       <strong><span class="repeated"> Bu kanal grup adı mevcut!</span></strong>
    </div>
</asp:Panel>


<asp:Panel ID="Warning_error" runat="server" Visible="false" Width="100%">
    <div class="alert alert-warning" style="width: 100%">
        <a class="close" data-dismiss="alert" href="#">×</a> <strong>Uyarı: 
        <asp:Label ID="lblerrormesaj" runat="server"></asp:Label>
        </strong>
    </div>
</asp:Panel>
      
        <table style="width:100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Grup Adı"></asp:Label>
                    <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Theme="Moderno" Width="100%">
                    </dx:ASPxTextBox>
                    <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Text="Durum" Theme="MetropolisBlue">
                    </dx:ASPxCheckBox>
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
                <dx:TabPage Text="Gruplar">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Moderno" Width="100%">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Grup Adı" FieldName="KG_GRUPADI" ShowInCustomizationForm="True" VisibleIndex="3" Width="60%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Seç" ShowInCustomizationForm="True" VisibleIndex="4" Width="5%">
                                        <DataItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("KG_ID")+"-"+Eval("KG_GRUPKODU")+"-"+Eval("KG_GRUPADI")+"-"+Eval("KG_KANAL")%>' ImageUrl="~/images/Forward_16x16.png" onclick="ImageButton1_Click1" ToolTip="Seç" />
                                        </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Sil" ShowInCustomizationForm="True" VisibleIndex="5" Width="5%">
                                        <DataItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("KG_ID")%>' ImageUrl="~/images/DeleteList2_16x16.png" onclick="ImageButton2_Click" OnClientClick="return confirm('Silmek istiyor musunuz?');" ToolTip="Sil" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Grup Kodu" FieldName="KG_GRUPKODU" ShowInCustomizationForm="True" VisibleIndex="1" Width="30%">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager Mode="ShowAllRecords">
                                </SettingsPager>
                                <Settings UseFixedTableLayout="True" VerticalScrollableHeight="300" VerticalScrollBarMode="Auto" />
                            </dx:ASPxGridView>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Grup Detay">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableTheming="True" KeyFieldName="KNL_KODU" Theme="Moderno" Width="100%">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="Kanal Kodu" FieldName="KNL_KODU" ShowInCustomizationForm="True" VisibleIndex="5" Width="30%">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn Caption="Seç" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="3" Width="5%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="Kanal Adı" FieldName="KN_ADI" ShowInCustomizationForm="True" VisibleIndex="6" Width="65%">
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







