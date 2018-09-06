<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="KanalIhbarDetay.aspx.cs" Inherits="EgmYKS.IHBAR.KanalIhbarDetay" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
          
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="height: 550px;">
        <dx:ASPxSplitter ID="ASPxSplitter1" runat="server" Height="100%" Width="100%">
            <Panes>
                <dx:SplitterPane Size="55%">
                    <Panes>
                        <dx:SplitterPane ScrollBars="Auto">
                            <ContentCollection>
                                <dx:SplitterContentControl>
                                    <dx:ASPxPageControl ID="pcDetay" runat="server" Height="100%" Width="100%" ActiveTabIndex="2">
                                        <TabPages>

                                            <dx:TabPage Text="155">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:ASPxFormLayout ID="box1" runat="server" ColCount="4" Width="98%">
                                                            <Items>
                                                                <dx:LayoutItem Caption="Arayan No" Width="30%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155ArayanNo" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem ShowCaption="False" Width="5%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxButton ID="btn155GuniciArama" OnClick="btn155GuniciArama_Click" runat="server" Text="0" Width="15px">
                                                                                              <%-- <ClientSideEvents Click="function(s, e) { ppsearch(s, e); }" />--%>
                                                                                        </dx:ASPxButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxButton ID="btn155ToplamArama" OnClick="btn155ToplamArama_Click" runat="server" Text="0" Width="15px">
                                                                                            <%--  <ClientSideEvents Click="function(s, e) { ppsearch(s, e); }" />--%>
                                                                                        </dx:ASPxButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="İsim" Width="30%" ColSpan="2">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155isimSoyisim" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="İlçe" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox  ID="cmb155Ilce" runat="server" ReadOnly="true" Width="100%" AutoPostBack="true" AccessKey="C"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155Ilcekodu" runat="server" Enabled="false"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>


                                                                <%-- 3.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Mahalle" ColSpan="4" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmb155Mahalle" ReadOnly="true" AutoPostBack="true" runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 3.satır bitişi --%>
                                                                <%-- 4.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Cadde Sok:" ColSpan="4" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155CaddeSok" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 4.satır bitişi --%>
                                                                <%-- 5.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Site Adı:" Width="50%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155SiteAdi" ReadOnly="true" runat="server"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Bina No/Daire" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxTextBox ID="txt155Bina" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxTextBox ID="txt155Daire" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 5.satır bitişi --%>
                                                                <%-- 6.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Bina Adı:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155BinaAdi" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 6.satır bitişi --%>
                                                                <%-- 7.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Plaka" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155Plaka" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxButton ID="btn155PlakaCount" OnClick="btn155PlakaCount_Click" runat="server" Width="100%" Height="100%"></dx:ASPxButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxButton ID="btn155PlakaArti" runat="server" Width="100%" Height="100%" Image-Url="~/images/add_green.png" AccessKey="P" OnClick="btnPlakaArti_Click">
                                                                                            <Image Url="~/images/add_green.png"></Image>
                                                                                        </dx:ASPxButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 7.satır bitişi --%>
                                                                <%-- 8.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Adres:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memo155Adres" ReadOnly="true" runat="server" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 8.satır bitişi --%>
                                                                <%-- 9.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="İhbar Bilgisi" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memo155Ihbar" ReadOnly="true" runat="server" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 9.satır bitişi --%>
                                                                <%-- 10.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Alt Olay Kodu" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmb155AltOlayKodu" ReadOnly="true" AutoPostBack="true" runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 10.satır bitişi --%>
                                                                <%-- 11.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Üst Olay Kodu" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmb155UstOlayKodu" ReadOnly="true" AutoPostBack="true" runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 11.satır bitişi --%>
                                                                <%-- 12.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Operatör Notu" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memo155OprNotu" ReadOnly="true" runat="server" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 12.satır bitişi --%>
                                                                <%-- 13.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="İşlemler" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox ID="chk155OncelikliIslem" ReadOnly="true" Text="Öncelikli İşlem" runat="server" Width="100%"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox ID="chk155Itfaiye" ReadOnly="true" Text="İtfaiye" runat="server" Width="100%"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox ID="chk155Ambulans" ReadOnly="true" Text="Ambulans" runat="server" Width="100%"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 13.satır bitişi --%>
                                                                <%-- 14.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Diğer Bilgiler" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memo155DigerBilg" ReadOnly="true" runat="server" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 14.satır bitişi --%>
                                                                <%-- 15.satır başlangıcı --%>

                                                                <%-- 15.satır bitişi --%>
                                                                <%-- 16.satır başlangıcı --%>

                                                                <dx:LayoutItem Caption="Cinsiyet/Yaş" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxRadioButtonList ID="rb155_cinsiyet" ReadOnly="true" RepeatDirection="Vertical"  RepeatColumns="2" 
                                                                                            runat="server" ValueType="System.String">
                                                                                            <Items>
                                                                                                <dx:ListEditItem Value="Erkek" Text="Erkek"/>
                                                                                                <dx:ListEditItem Value="Kadın" Text="Kadın"/>
                                                                                            </Items>
                                                                                        </dx:ASPxRadioButtonList>
                                                                                    </td>

                                                                                    <td>
                                                                                        <dx:ASPxSpinEdit ID="t155_yas" ReadOnly="true" runat="server" Width="50%" Height="25"></dx:ASPxSpinEdit>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Email:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txt155Email" ReadOnly="true" runat="server" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 16.satır bitişi --%>
                                                                <%-- 17.satır başlangıcı --%>
                                                                <dx:LayoutItem Caption="Tarih:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxDateEdit ID="txt155_tarih" ReadOnly="true" runat="server" DisplayFormatString="dd.MM.yyyy hh:mm:ss"></dx:ASPxDateEdit>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <%-- 17.satır bitişi --%>
                                                            </Items>
                                                        </dx:ASPxFormLayout>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>



                                            <dx:TabPage Text="Çalıntı" Enabled="true">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:ASPxFormLayout ID="ASPxFormLayout_calinti" runat="server" ColCount="4" Width="98%">
                                                            <Items>

                                                                <dx:LayoutItem Caption="Plaka " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table style="width: 100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxTextBox ID="txtCalinti_plaka" ReadOnly="true" Width="100%" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox Text="Sadece Plaka" ReadOnly="true" ID="txtCalinti_sadecePlaka" Width="100%" runat="server"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Rengi " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_rengi" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Marka " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_marka" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Model " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_model" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Türü " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_turu" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Yıl " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_yil" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Olay Yeri İlçe " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_olayYeriIlce" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Polis Karakolu " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_polisKarakolu" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Adres " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="txtCalinti_adres" runat="server" ReadOnly="true" Height="71px" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Bilgi " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <dx:ASPxTextBox ID="txtCalinti_bilgi" Width="100%" ReadOnly="true" runat="server" Theme="Office2003Blue"></dx:ASPxTextBox>

                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Not " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="txtCalinti_not" runat="server" ReadOnly="true" Height="71px" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Tarih " Width="100%" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxDateEdit ID="txtCalinti_tarih" ReadOnly="true" runat="server" Width="100%"  DisplayFormatString="dd.MM.yyyy hh:mm:ss"></dx:ASPxDateEdit>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="bosluk " Width="100%" ColSpan="4" ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Resimler " Width="40%" ColSpan="2" ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <div style="float: left; width: 25%; border: 1px solid #ffcccc; text-align: center">
                                                                                <dx:ASPxImage ID="txtCalinti_resim1" runat="server" ShowLoadingImage="true" ImageUrl="images/Add_16x16.png"></dx:ASPxImage>
                                                                            </div>
                                                                            <div style="float: left; width: 25%; border: 1px solid #ffcccc; text-align: center">
                                                                                <dx:ASPxImage ID="txtCalinti_resim2" runat="server" ShowLoadingImage="true" ImageUrl="images/Apply_16x16.png"></dx:ASPxImage>
                                                                            </div>
                                                                            <div style="float: left; width: 25%; border: 1px solid #ffcccc; text-align: center">
                                                                                <dx:ASPxImage ID="txtCalinti_resim3" runat="server" ShowLoadingImage="true" ImageUrl="images/Add_16x16.png"></dx:ASPxImage>
                                                                            </div>
                                                                            <div style="float: left; width: 25%; border: 1px solid #ffcccc; text-align: center">
                                                                                <dx:ASPxImage ID="txtCalinti_resim4" runat="server" ShowLoadingImage="true" ImageUrl="images/Apply_16x16.png"></dx:ASPxImage>
                                                                            </div>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                            </Items>
                                                        </dx:ASPxFormLayout>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>



                                            <dx:TabPage Text="Güvenlik">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:ASPxFormLayout ID="ASPxFormLayout3" runat="server" ColCount="6" Width="98%">
                                                            <Items>
                                                                <dx:LayoutItem Caption="Güvenlik Şirketi" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtGuvenlikSirketi" ReadOnly="true" runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Şirket Telefonu" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtGuvenlikSirketTelefonu"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Şirket Görevlisi" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtGuvenlikSirketGorevlisi"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Şirket Abonesi" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtGuvenlikSirketAbonesi"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Abone Telefonu" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtGuvenlikAboneTelefonu"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Abone Adresi:" ColSpan="6">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memoGuvenlikAboneAdresi"  ReadOnly="true"   runat="server" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="İlçe:" ColSpan="6">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmbGuvenlikGuvenlikIlce"  ReadOnly="true"  AutoPostBack="true" runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Alarm Türü:" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtGuvenlikAlarmTuru"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Mahalle:" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmbGuvenlikGuvenlikMahalle"  ReadOnly="true"  AutoPostBack="true" runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Sokak/Bina-Daire:" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td style="width: 56%;">
                                                                                        <dx:ASPxTextBox ID="txtGuvenlikSokak"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                    <td style="width: 2%;"></td>
                                                                                    <td style="width: 20%;">
                                                                                        <dx:ASPxTextBox ID="txtGuvenlikBina"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                    <td style="width: 2%;"></td>
                                                                                    <td style="width: 20%;">
                                                                                        <dx:ASPxTextBox ID="txtGuvenlikDaire"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Site Adı/Bina Adı:" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>

                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td style="width: 49%;">
                                                                                        <dx:ASPxTextBox ID="txtGuvenlikSiteAdi"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                    <td style="width: 2%;"></td>
                                                                                    <td style="width: 49%;">
                                                                                        <dx:ASPxTextBox ID="txtGuvenlikBinaAdi"  ReadOnly="true"  runat="server" Theme="Office2003Blue" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Not:" ColSpan="6">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memoGuvenlikNot" runat="server"  ReadOnly="true"  Width="100%" Rows="5"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Tarih:" ColSpan="6" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxDateEdit ID="txtGuvenlik_Tarih"  ReadOnly="true"  runat="server" DisplayFormatString="dd.MM.yyyy hh:mm:ss"></dx:ASPxDateEdit>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>
                                                        </dx:ASPxFormLayout>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>



                                            <dx:TabPage Text="Mail">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                        <dx:ASPxFormLayout ID="elp1" runat="server" ColCount="4" Width="100%">

                                                            <Items>
                                                                <dx:LayoutItem ColSpan="3" Caption="İsim" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELPisim" runat="server"  ReadOnly="true"  Width="100%" Theme="Office2003Blue"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="İlçe" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmbELPilce" AutoPostBack="true"  ReadOnly="true"  runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELPilcekod" runat="server" Enabled="false"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Mahalle" ColSpan="3" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmbELPmahalle" runat="server"  ReadOnly="true"  AutoPostBack="true" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Cadde Sok:" ColSpan="4" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELPcadde" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Site Adı:" Width="100%">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELPsiteadi" Width="100%"  ReadOnly="true"  runat="server"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Bina/Daire" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxTextBox ID="txtELPbina"  ReadOnly="true"  runat="server" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                    <td>&nbsp;&nbsp;&nbsp;</td>
                                                                                    <td>
                                                                                        <dx:ASPxTextBox ID="txtELPdaire"  ReadOnly="true"  runat="server" Width="100%"></dx:ASPxTextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Bina Adı:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELP_binaadi" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Plaka" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELPplaka" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem ShowCaption="False">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxButton ID="btnELPplaka" Text="0" runat="server" Width="100%" Height="100%"></dx:ASPxButton>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxButton ID="ASPxButton10" runat="server" Width="100%" Height="100%" Image-Url="~/images/add_green.png">
                                                                                            <Image Url="~/images/add_green.png"></Image>
                                                                                        </dx:ASPxButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Adres:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memoELPadress" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="İhbar Bilgisi" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memoELPihbarbilgisi" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Alt Olay Kodu" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmbELPaltolaykodu" AutoPostBack="true"  ReadOnly="true"  runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Üst Olay Kodu" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxComboBox ID="cmbELPustolaykodu" AutoPostBack="true"  ReadOnly="true"  runat="server" Width="100%"></dx:ASPxComboBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Operatör Notu" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memoELPoperator" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="İşlemler" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox ID="chcELPoncelikli"  ReadOnly="true"  Text="Öncelikli İşlem" runat="server" Width="100%"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox ID="chcELPitfaiye"  ReadOnly="true"  Text="İtfaiye" runat="server" Width="100%"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <dx:ASPxCheckBox ID="chcELPambulans"  ReadOnly="true"  Text="Ambulans" runat="server" Width="100%"></dx:ASPxCheckBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Diğer Bilgiler" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxMemo ID="memoELPdigerbilgiler"  ReadOnly="true"  runat="server" Width="100%"></dx:ASPxMemo>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                                <dx:LayoutItem Caption="Cinsiyet/Yaş" ColSpan="3">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <table style="width: 100%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <dx:ASPxRadioButtonList ID="t_ELP_cinsiyet"  ReadOnly="true"  runat="server"  Height="25"
                                                                                            RepeatDirection="Vertical" RepeatColumns="2"  ValueType="System.String">
                                                                                             <Items>
                                                                                                <dx:ListEditItem Value="Erkek" Text="Erkek"/>
                                                                                                <dx:ListEditItem Value="Kadın" Text="Kadın"/>
                                                                                            </Items>
                                                                                        </dx:ASPxRadioButtonList>
                                                                                    </td>

                                                                                    <td>
                                                                                        <dx:ASPxSpinEdit ID="t_ELP_yas"  ReadOnly="true"  runat="server" Width="50%" Height="25"></dx:ASPxSpinEdit>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>


                                                                <dx:LayoutItem Caption="Email:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxTextBox ID="txtELPmaill" runat="server"  ReadOnly="true"  Width="100%"></dx:ASPxTextBox>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>

                                                                <dx:LayoutItem Caption="Tarih:" ColSpan="4">
                                                                    <LayoutItemNestedControlCollection>
                                                                        <dx:LayoutItemNestedControlContainer>
                                                                            <dx:ASPxDateEdit ID="txtELPmail_tarih"  ReadOnly="true"  runat="server" DisplayFormatString="dd.MM.yyyy hh:mm:ss"></dx:ASPxDateEdit>
                                                                        </dx:LayoutItemNestedControlContainer>
                                                                    </LayoutItemNestedControlCollection>
                                                                </dx:LayoutItem>
                                                            </Items>

                                                        </dx:ASPxFormLayout>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Text="SMS" Enabled="false">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>
                                            <dx:TabPage Text="Web" Enabled="false">
                                                <ContentCollection>
                                                    <dx:ContentControl>
                                                    </dx:ContentControl>
                                                </ContentCollection>
                                            </dx:TabPage>

                                        </TabPages>
                                    </dx:ASPxPageControl>
                                </dx:SplitterContentControl>
                            </ContentCollection>
                        </dx:SplitterPane>
                    </Panes>
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server"></dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>
                <dx:SplitterPane Size="45%" ScrollBars="Auto">
                    <ContentCollection>
                        <dx:SplitterContentControl runat="server">
                            <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" Width="100%">
                                <TabPages>
                                    <dx:TabPage Text="Kanallar">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <dx:ASPxGridView ID="GridKanal" runat="server" Width="100%" KeyFieldName="KEYFIELDID" Font-Size="X-Small" 
                                                    OnHtmlDataCellPrepared="GridKanal_HtmlDataCellPrepared"
                                                    OnFillContextMenuItems="GridKanal_FillContextMenuItems"
                                                    OnContextMenuItemClick="GridKanal_ContextMenuItemClick">
                                                    <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick(s, e);}" />
                                                    <SettingsContextMenu Enabled="True">
                                                        <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                        </RowMenuItemVisibility>
                                                    </SettingsContextMenu>
                                                    <SettingsPager Position="TopAndBottom">
                                                        <PageSizeItemSettings Items="20, 50" />
                                                    </SettingsPager>
                                                    <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" />
                                                    <Settings ShowFilterRow="true" ShowVerticalScrollBar="true" VerticalScrollableHeight="150"></Settings>
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="cmpt_ihbardurum" Caption=" " ShowInCustomizationForm="True" VisibleIndex="2" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="L_ASILKANAL" Width="15%" Caption="Kanallar" ShowInCustomizationForm="True" VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn> 
                                                        <dx:GridViewDataTextColumn FieldName="L_TARIHSAAT" Width="40%" Caption="Okuma Zamanı"   ShowInCustomizationForm="True" UnboundType="DateTime" PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm:ss" VisibleIndex="4"> 
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="L_SICILNO" Width="15%" Caption="Kullanıcı" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="5">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="LOGMESAJ" Width="45%" Caption="İşlem Sonucu" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn Caption="D" Name="gridIcon2" ShowInCustomizationForm="True" UnboundType="Object" VisibleIndex="1" Width="16px">
                                                            <DataItemTemplate>
                                                                <asp:Image ID="Image1" runat="server" 
                                                                    ImageUrl='<%# Eval("L_ISLEM").ToString() == "11" ? "../Gridicon/4.png" : Eval("L_ISLEM").ToString() == "1" | (Request.QueryString["SON100"].ToString() == "0" & Eval("L_ISLEM").ToString() == "10") ? "../Gridicon/5.png" : "../Gridicon/3.png" %>' 
                                                                    
                                                                    Width="16px" />
                                                            </DataItemTemplate>
                                                            <CellStyle>
                                                                <Paddings Padding="0px" />
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn Caption="B" Name="gridIcon" ShowInCustomizationForm="True" VisibleIndex="0" Width="16px">
                                                            <DataItemTemplate>
                                                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("cmpt_ihbardurum").ToString()=="1"?"../Gridicon/0.png":Eval("cmpt_ihbardurum").ToString() == "2" ? "../Gridicon/1.png" : Eval("cmpt_ihbardurum").ToString() == "3" ? "../Gridicon/2.png"  : ""%>' Width="16px" />
                                                            </DataItemTemplate>
                                                            <CellStyle>
                                                                <Paddings Padding="0px" />
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataTextColumn FieldName="L_KANAL" ShowInCustomizationForm="True" Visible="False" VisibleIndex="7">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="L_ISLEM" ShowInCustomizationForm="True" Visible="False" VisibleIndex="8">
                                                        </dx:GridViewDataTextColumn>

                                                    </Columns>
                                                </dx:ASPxGridView>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Text="Dosyalar">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                            </dx:ASPxPageControl>
                            <dx:ASPxRoundPanel ID="rpNots" runat="server" Width="100%" HeaderText="İhbar Notları"
                                AllowCollapsingByHeaderClick="true" ShowCollapseButton="true" ShowHeader="true" Collapsed="false">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <div>
                                            <div style="float: left; width: 20px;">
                                                <dx:ASPxButton ID="ASPxButton1" runat="server" Width="16px" BackColor="White" HorizontalAlign="Left">
                                                    <ClientSideEvents Click="function(s, e) { pmessageSEND(s,e); }" />
                                                    <Image Url="~/images/add_green.png">
                                                    </Image>

                                                </dx:ASPxButton>
                                            </div>
                                            <div style="float: right; width: 40px;">
                                                <dx:ASPxButton ID="ASPxButton2" runat="server" Width="16px" BackColor="White"  
                                                      HorizontalAlign="Right" ImagePosition="Right" OnClick="ASPxButton2_Click">
                                                     <Image IconID="format_fontsizedecrease_16x16">
                                                    </Image> 
                                                    <Paddings PaddingRight="0px" /> 
                                                </dx:ASPxButton>
                                            </div>
                                            <div style="float: right; width: 40px;">
                                                <dx:ASPxButton ID="ASPxButton3" runat="server" Width="16px" BackColor="White"   HorizontalAlign="Right"  
                                                      ImagePosition="Right" OnClick="ASPxButton3_Click"> 
                                                    <Image IconID="format_fontsizeincrease_16x16">
                                                    </Image>
                                                    
                                                    <Paddings PaddingRight="0px" /> 
                                                </dx:ASPxButton>
                                            </div>
                                        </div>
                                        
                                          <dx:ASPxGridView ID="gridNots" ClientInstanceName="gridNots" runat="server" Width="100%"
                                               AutoGenerateColumns="False" Font-Size="XX-Small"
                                            KeyFieldName="KEYFIELDID"  > 
                                              <SettingsPager Mode="ShowAllRecords" ></SettingsPager> 
                                              <SettingsBehavior AutoExpandAllGroups="true" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="IN_MESAJ" Caption="NOT" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="0">
                                                </dx:GridViewDataTextColumn> 
                                                <dx:GridViewDataTextColumn FieldName="grouping" SortOrder="Descending" SortIndex="0" Caption=" " ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="0">
                                                </dx:GridViewDataTextColumn> 
                                               
                                            </Columns>
                                        </dx:ASPxGridView> 
                                    </dx:PanelContent>
                                </PanelCollection>

                            </dx:ASPxRoundPanel>
                            <dx:ASPxRoundPanel ID="rpEkip" runat="server" HeaderText="Ekip İşlemleri" ShowHeader="true" Width="100%">
                                <PanelCollection>
                                    <dx:PanelContent>
                                        <dx:ASPxGridView ID="GridEkip" runat="server" Width="100%" AutoGenerateColumns="False" Font-Size="XX-Small"
                                            OnFillContextMenuItems="GridEkip_FillContextMenuItems" KeyFieldName="KEYFIELDID" 
                                            OnContextMenuItemClick="GridEkip_ContextMenuItemClick"  OnContextMenuItemVisibility="GridEkip_ContextMenuItemVisibility">
                                           <ClientSideEvents ContextMenuItemClick="function(s, e){OnContextMenuItemClick_Ekip(s, e);}"
                                                             RowDblClick="function(s,e){ s.GetRowValues(s.GetFocusedRowIndex(), 'IK_NOT;IK_TIP', SetSelectedEkipPanel);}" />
                                            <SettingsContextMenu Enabled="True">
                                                <RowMenuItemVisibility DeleteRow="False" EditRow="False" NewRow="False" Refresh="False">
                                                </RowMenuItemVisibility>
                                            </SettingsContextMenu>
                                            <SettingsPager Position="TopAndBottom">
                                                <PageSizeItemSettings Items="20, 50" />
                                            </SettingsPager>
                                            <SettingsBehavior AllowFocusedRow="true" AllowAutoFilter="true" />
                                            <Settings VerticalScrollableHeight="150"></Settings>
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="EG_ID" Caption=" " Visible="false" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="0">
                                                </dx:GridViewDataTextColumn> 
                                                <dx:GridViewDataTextColumn FieldName="EG_EKKODU" Caption="Ekip" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="0">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EG_KANAL"  Caption="Kanal" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="1">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EG_TARIH" Caption="Yön.Zamanı"  ShowInCustomizationForm="True" UnboundType="DateTime" PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm:ss" VisibleIndex="2">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EG_ULASMATARIH" Caption="Ulaş.Zamanı"  ShowInCustomizationForm="True" UnboundType="DateTime" PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm:ss" VisibleIndex="3">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="EG_SONTARIH"  Caption="Son.Zamanı" ShowInCustomizationForm="True" UnboundType="DateTime"  PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm:ss" VisibleIndex="4">
                                                </dx:GridViewDataTextColumn> 
                                                  <dx:GridViewDataTextColumn FieldName="EG_ULASMATARIH_DURUM"  Caption="Ulaşma" Visible="false" ShowInCustomizationForm="True" UnboundType="DateTime"   PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm:ss" VisibleIndex="5">
                                                </dx:GridViewDataTextColumn> 
                                                  <dx:GridViewDataTextColumn FieldName="EG_SONTARIH_DURUM"  Caption="Son" Visible="false" ShowInCustomizationForm="True" UnboundType="DateTime"   PropertiesTextEdit-DisplayFormatString="dd.MM.yyyy hh:mm:ss" VisibleIndex="6">
                                                </dx:GridViewDataTextColumn> 
                                                  <dx:GridViewDataTextColumn FieldName="IK_NOT"  Caption="Son" Visible="false" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="7">
                                                </dx:GridViewDataTextColumn> 
                                                  <dx:GridViewDataTextColumn FieldName="IK_TIP"  Caption="Son" Visible="false" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="8">
                                                </dx:GridViewDataTextColumn> 
                                            </Columns>
                                        </dx:ASPxGridView>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxRoundPanel>
                            <dx:ASPxPanel ID="ASPxPanel6" runat="server" Width="100%">
                                <PanelCollection>
                                    <dx:PanelContent runat="server">

                                        <dx:ASPxMenu ID="AltMenu" runat="server" ShowAsToolbar="true" OnItemClick="AltMenu_ItemClick"
                                            AutoPostBack="false">

                                            <ClientSideEvents ItemClick="function(s, e) { MenuItemClick(e);  e.processOnServer = false;  }" />
                                            <Items>
                                                <dx:MenuItem Name="HaritaGoster" Text="Har. Göster"></dx:MenuItem>
                                                <dx:MenuItem Name="FarkliKanalaYonlendir" Text="F.Kanala Yönl.">
                                                </dx:MenuItem>
                                                <dx:MenuItem Name="EkipYonlendir" Text="Ekip Yönl."></dx:MenuItem>
                                                <dx:MenuItem Name="PolisSorumlulukDisi" Text="Polis Sor.Böl.D" BeginGroup="true" DropDownMode="true">
                                                    <Items>
                                                        <dx:MenuItem Name="110112" Text="110-112"></dx:MenuItem>
                                                        <dx:MenuItem Name="Belediye153" Text="Belediye 153"></dx:MenuItem>
                                                        <dx:MenuItem Name="DigerKurumlar" Text="Diğer Kurumlar"></dx:MenuItem>
                                                        <dx:MenuItem Name="Igdas187" Text="İgdaş 187"></dx:MenuItem>
                                                        <dx:MenuItem Name="Iski185" Text="İski 185"></dx:MenuItem>
                                                        <dx:MenuItem Name="Jandarma156" Text="Jandarma 156"></dx:MenuItem>
                                                        <dx:MenuItem Name="Tedas186" Text="Tedaş 186"></dx:MenuItem>
                                                    </Items>
                                                </dx:MenuItem>
                                                <dx:MenuItem Name="DigerIslemler" Text="Diğer" BeginGroup="true" DropDownMode="true">
                                                    <Items>
                                                        <dx:MenuItem Name="AnonsEdildi" Text="Anons Edildi"></dx:MenuItem>
                                                        <dx:MenuItem Name="EksikIhbar" Text="Eksik İhbar"></dx:MenuItem>
                                                        <dx:MenuItem Name="GorusDisi" Text="Görüş Dışı"></dx:MenuItem>
                                                        <dx:MenuItem Name="KameraArizali" Text="Kamera Arızalı"></dx:MenuItem>
                                                        <dx:MenuItem Name="KayitIndirildi" Text="Kayıt İndirildi"></dx:MenuItem>
                                                        <dx:MenuItem Name="TekrarIhbar" Text="Tekrar İhbar"></dx:MenuItem>
                                                        <dx:MenuItem Name="YerindeKayit" Text="Yerinde Kayıt"></dx:MenuItem>
                                                        
                                                        <dx:MenuItem Name="AsilliIhbar" Text="Asıllı İhbar" Visible="false"></dx:MenuItem>
                                                        <dx:MenuItem Name="AsilsiziIhbar" Text="Asılsız İhbar" Visible="false"></dx:MenuItem>
                                                        <dx:MenuItem Name="Gorusici" Text="Görüş Alanı İçinde" Visible="false"></dx:MenuItem>
                                                        <dx:MenuItem Name="GorusDisi" Text="Görüş Dışı" Visible="false"></dx:MenuItem>
                                                    </Items>
                                                </dx:MenuItem>
                                            </Items>
                                        </dx:ASPxMenu>
                                    </dx:PanelContent>
                                </PanelCollection>
                            </dx:ASPxPanel>
                        </dx:SplitterContentControl>
                    </ContentCollection>
                </dx:SplitterPane>

            </Panes>
        </dx:ASPxSplitter>
      
    </div>

     <div style="display:none">  
        <asp:Label ID="lblsonucRaporu" runat="server"></asp:Label>
        <asp:Label ID="lblsonucraporuindex" runat="server"></asp:Label>
         
     </div>

    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="callback1"
        OnCallback="ASPxCallback1_Callback">
        <ClientSideEvents CallbackComplete="function(s,e) {OnCallbackComplete(s,e)}" />
    </dx:ASPxCallback>
     

    <dx:ASPxPopupControl ID="pcSelectKanal" runat="server" Width="400" CloseAction="CloseButton" CloseOnEscape="true" AutoPostBack="False"
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
                                OnHtmlFooterCellPrepared="gridSelectKanal_HtmlFooterCellPrepared" >
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
                            </dx:ASPxButton>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="Ekip Yönlendir" Height="400px" CloseAction="CloseButton" CloseOnEscape="true" AutoPostBack="False"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popekip"
        AllowDragging="True" Modal="True" PopupAnimationType="Fade" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="true" Width="500px">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxSplitter ID="ASPxSplitter2" runat="server" Height="400px">
                    <Panes>
                        <dx:SplitterPane>
                            <ContentCollection>
                                <dx:SplitterContentControl runat="server">

                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <dx:ASPxTextBox ID="txtEkipEkle" ClientInstanceName="txtEkipEkle" runat="server" Width="100px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnEkle" runat="server" Width="100%">
                                                    <ClientSideEvents Click="function(s,e) {btnEkle_Click(s,e)}" />
                                                    <Image Url="~/images/add_green.png">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnOnayla" ClientInstanceName="btnOnayla" runat="server" Width="100%" OnClick="btnOnayla_Click">
                                                    <Image Url="~/images/Apply_16x16.png">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnIptal" runat="server" Width="100%">
                                                    <ClientSideEvents Click="function(s,e){ popekip.Hide(); }" />
                                                    <Image Url="~/images/Cancel_16x16.png">
                                                        
                                                    </Image>
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="nav-justified">
                                        <tr>
                                            <td>
                                                <dx:ASPxListBox ID="lbEkipinsert" ClientInstanceName="lbEkipinsert" SelectionMode="CheckColumn" runat="server" Width="100%">
                                                    <ClientSideEvents SelectedIndexChanged="function(s,e) {gridEkipList_SelectionChanged(s,e)}" />
                                                </dx:ASPxListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxGridView ID="gridEkipList" ClientInstanceName="gridEkipList" runat="server" 
                                                     KeyFieldName="KEYFIELDID" Width="100%"  OnHtmlRowCreated="gridEkipList_HtmlRowCreated"  >
                                                    <SettingsBehavior AllowSelectSingleRowOnly="false"  />
                                                    <SettingsPager Visible="true" Mode="ShowAllRecords"></SettingsPager>
                                                    <Settings  ShowFilterRow="false" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                                    <SettingsSearchPanel Visible="true" /> 
                                                    <Columns>
                                                        <dx:GridViewCommandColumn  ShowSelectCheckbox="true" 
                                                            SelectAllCheckboxMode="AllPages" Width="20%" VisibleIndex="0" >
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn Caption="Araç Plakası" FieldName="ARC_PLAKA" ShowInCustomizationForm="True" VisibleIndex="2" Width="40%">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Ekip Kodu" FieldName="EK_KODU" ShowInCustomizationForm="True" VisibleIndex="1" Width="40%">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <ClientSideEvents SelectionChanged="function(s,e) {gridEkipList_SelectionChanged(s,e)}" />
                                                </dx:ASPxGridView>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:SplitterContentControl>
                            </ContentCollection>
                        </dx:SplitterPane>
                        <dx:SplitterPane>
                            <ContentCollection>
                                <dx:SplitterContentControl runat="server">
                                    <dx:ASPxPanel ID="pnlRigth" runat="server">
                                        <PanelCollection>
                                            <dx:PanelContent>
                                                <dx:ASPxListBox ID="lbEkipList" ClientInstanceName="lbEkipList" runat="server" Height="370" 
                                                    ViewStateMode="Enabled" Width="100%" > 
                                                </dx:ASPxListBox>
                                            </dx:PanelContent>
                                        </PanelCollection>

                                    </dx:ASPxPanel>
                                </dx:SplitterContentControl>
                            </ContentCollection>
                        </dx:SplitterPane>
                    </Panes>
                </dx:ASPxSplitter>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <%--message send popup--%>

    <dx:ASPxPopupControl ID="pcmessage_send" runat="server" Width="400" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcmessage_send"
        HeaderText="MESAJ GÖNDER" AllowDragging="True" Modal="True" PopupAnimationType="fade"
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




    <%--plaka popup--%>

    <dx:ASPxPopupControl ID="pcplaka_send" runat="server" Width="400" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcplaka_send"
        HeaderText="PLAKA GÜNCELLE" AllowDragging="True" Modal="True" PopupAnimationType="fade"
        EnableViewState="False" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="True">
        <SizeGripImage Width="11px" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <dx:ASPxTextBox ID="txtplakaguncelle" runat="server" Height="25px" Width="100%"></dx:ASPxTextBox>
                            <br />
                            <dx:ASPxButton ID="btnupdate" Text="Güncelle" runat="server" Height="25px" Width="100%" OnClick="btnupdate_Click">
                                <ClientSideEvents Click="function(s,e){pcplaka_send.Hide();}" />
                            </dx:ASPxButton>

                            <dx:ASPxButton ID="btncancel" Text="İptal" runat="server" Height="25px" Width="100%">
                                <ClientSideEvents Click="function(s,e){pcplaka_send.Hide();}" />
                            </dx:ASPxButton>

                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>


    <%--plaka popup--%>
    
    


    
    <dx:ASPxPopupControl ID="pcSonucRaporu" runat="server" Width="400" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcSonucRaporu"
        HeaderText="İhbar Sonuç Raporu" AllowDragging="True" Modal="True" PopupAnimationType="fade"
        EnableViewState="False" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="True" >
        <SizeGripImage Width="11px" /> 
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="ASPxPanel3" runat="server">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                           <dx:ASPxMemo ID="txtSonucRaporu" ClientInstanceName="txtSonucRaporu" runat="server" Width="100%" Height="150"></dx:ASPxMemo>
                            <dx:ASPxRadioButtonList ID="rbIhbarSonuc" ClientInstanceName="rbIhbarSonuc" runat="server" RepeatDirection="Vertical" RepeatColumns="2" Width="100%" >
                                <Items>
                                    <dx:ListEditItem Value="0" Text="Asıllı" Selected="False"/>
                                    <dx:ListEditItem Value="1" Text="Asılsız" Selected="True"/>
                                </Items>
                            </dx:ASPxRadioButtonList> 
                            <dx:ASPxButton ID="btnSonucRaporuTamam" ClientInstanceName="btnSonucRaporuTamam" runat="server" Width="100%" Text="İhbarı Kapat" OnClick="btnSonucRaporuTamam_Click">
                                <ClientSideEvents Click="function(s,e) { pcSonucRaporu.Hide() }"/>
                            </dx:ASPxButton>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="pcarama_listesi" runat="server" Width="200" CloseAction="CloseButton" CloseOnEscape="true"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcarama_listesi"
        HeaderText="ARAMA LİSTESİ" AllowDragging="True" Modal="True" PopupAnimationType="Fade"
        EnableViewState="False" PopupHorizontalOffset="40" PopupVerticalOffset="40" AutoUpdatePosition="true">
        <SizeGripImage Width="11px" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">

                <dx:ASPxPanel ID="ASPxPanel4" runat="server">
                    <PanelCollection>
                        <dx:PanelContent runat="server">

                            <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" ColCount="4" Width="80%">
                                <Items>
                                    <%--1.row--%>
                                    <dx:LayoutItem Caption="Saat Filtre:" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmbSaat" runat="server" Width="171px" AccessKey="C">
                                                    <Items>
                                                        <dx:ListEditItem Value="3 Saat" Text="3 Saat"/>
                                                        <dx:ListEditItem Value="6 Saat" Text="6 Saat"/>
                                                        <dx:ListEditItem Value="9 Saat" Text="9 Saat"/>
                                                        <dx:ListEditItem Value="12 Saat" Text="12 Saat"/>
                                                        <dx:ListEditItem Value="24 Saat" Text="24 Saat"/>
                                                        <dx:ListEditItem Value="48 Saat" Text="48 Saat"/>
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Başlama Tarihi:"   Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxDateEdit ID="rDateBaslama" runat="server" Width="171px"></dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Bitiş Tarihi:"   Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxDateEdit ID="rDateBitis" runat="server" Width="171px"></dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="Tümü"  Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="comboBoxEdit1" runat="server" Theme="Office2003Blue" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Durum"  Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rChkDurum" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <%--2.row--%>
                                    <dx:LayoutItem Caption="Tel"   Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="t_tel" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İhbarcı Telefonu"   Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="rTxtIhbarcitel" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İhbarcı Adı" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="rTxtIhbarciAd" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="İlçe" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rt_ilce" runat="server" ClientInstanceName="rt_ilce" ValueType="System.String" Width="171px" AccessKey="C">
                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { OnIlceChanged(s); }" />
                                                </dx:ASPxComboBox>
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
                                    <%--3.row--%>
                                    <dx:LayoutItem Caption="Kullanıcı" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="textEdit1" runat="server" Theme="Office2003Blue" Width="171px"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="simpleButton5" runat="server" Height="10px" Width="20px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Alt Olay" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rt_altolay" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Mahalle"  Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rt_mahalle" ClientInstanceName="rt_mahalle" ValueType="System.String" OnCallback="rt_mahalle_Callback" EnableCallbackMode="true" runat="server" Width="171px" AccessKey="C">
                                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { OnMahalleChanged(s); }" />
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="Log"  Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rChkLog" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
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


                                    <%--4.row--%>

                                    <dx:LayoutItem Caption="Kanal"  Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--<dx:ASPxComboBox ID="rt_kanal" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>--%>
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
                                    <dx:LayoutItem Caption="Cadde-Sokak" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                 <dx:ASPxComboBox ID="rtsk_cadde" ClientInstanceName="rtsk_cadde" OnCallback="rtsk_cadde_Callback" EnableCallbackMode="true" ValueType="System.String" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                                 </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    

                                    <dx:LayoutItem Caption="Plaka" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="rTxtPlaka" runat="server" Width="171px"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İhbar Türü" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="rt_ustolay" runat="server" Width="171px" AccessKey="C"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="İçerik Arama"  Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtIcerikArama" runat="server" Width="171px"></dx:ASPxTextBox>
                                                        </td>
                                                        <td>  
                                                            <dx:ASPxButton ID="simpleButton2" runat="server" BackgroundImage-Repeat="NoRepeat" Height="10px" Width="20px">
                                                                <BackgroundImage ImageUrl="~/images/search.png" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="simpleButton4" runat="server" BackgroundImage-Repeat="NoRepeat" Height="10px" Width="20px">
                                                                <BackgroundImage ImageUrl="~/images/delete.png" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                           <%--5.row--%>
                                    <dx:LayoutItem Caption="İşlemler" ColSpan="3" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxMenu ID="ASPxMenu1" OnItemClick="ASPxMenu1_ItemClick1" 
                                                    OnItemDataBound="ASPxMenu1_ItemDataBound" Width="300px" runat="server" ShowAsToolbar="true" AutoPostBack="false">
                                                    <Items>
                                                        <dx:MenuItem Name="Yukle" Text="Yükle"></dx:MenuItem>
                                                        <dx:MenuItem Name="ExceleAktar" Text="Excel'e Aktar">
                                                        </dx:MenuItem>
                                                        <dx:MenuItem Name="Yazdir" Text="Yazdır"></dx:MenuItem>
                                                       <dx:MenuItem Name="Temizle" Text="Temizle"></dx:MenuItem>
                                                    </Items>
                                                </dx:ASPxMenu>
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
                            <dx:ASPxGridView ID="gridControl1" runat="server" KeyFieldName="KEYFIELDID" Width="100%"
                                OnHtmlFooterCellPrepared="gridSelectKanal_HtmlFooterCellPrepared">
                                <SettingsBehavior AllowSelectSingleRowOnly="false" />
                                <SettingsPager Visible="true" Mode="ShowAllRecords"></SettingsPager>
                                <Settings ShowFilterRow="True" VerticalScrollableHeight="320" ShowVerticalScrollBar="true" />
                                <SettingsSearchPanel Visible="true" />
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="true" Width="10" SelectAllCheckboxMode="Page" ShowClearFilterButton="True" VisibleIndex="5" />
                                    <dx:GridViewDataTextColumn FieldName="I_KAYNAK" Caption="Kaynak" Width="65" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_DURUM" Caption="Sonuç" Width="65" VisibleIndex="7"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_TARIH" Caption="Tarih" Width="65" VisibleIndex="8"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="SAAT" Visible="false" Caption="Saat" Width="65"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="U_IHBAR" Caption="Ust Olay Adı" Visible="false" Width="65" VisibleIndex="0"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_OLAYADI" Caption="Alt Olay Adı" Width="65" VisibleIndex="9"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_TELEFON" Caption="İhbarcı Telefonu" Width="65" VisibleIndex="10"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ISIMSOYISIM" Caption="İhbarcı Adı" Width="65" VisibleIndex="11"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_CADDE" Caption="Cadde Sokak" Width="65" VisibleIndex="14"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ADI" Caption="Mahalle" Width="65" VisibleIndex="13"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="AD" Caption="İlçe" Width="65" VisibleIndex="12"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_KULLANICI" Caption="Kullanıcı" Width="65" VisibleIndex="15"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ID" Caption="gridColumn14" Width="65" Visible="false" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tel" Width="65" VisibleIndex="16"></dx:GridViewDataTextColumn>
                                    <%--<dx:GridViewDataTextColumn FieldName="gridicon" Width="65"></dx:GridViewDataTextColumn>--%>
                                    <dx:GridViewDataTextColumn FieldName="cmpt_islemdurum" Visible="false" Caption="gridColumn1" Width="65" VisibleIndex="2"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_ID" Caption="gridColumn2" Visible="false" Width="65" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="I_IHBARTUR" Caption="gridColumn3" Visible="false" Width="65" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                             <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter> 
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <script type="text/javascript">
        function OnCallbackComplete(s, e) {
            CloseIhbar();
        }


        function MenuItemClick(e) {
            
            var i = e.item.name;
            
            if (i == "FarkliKanalaYonlendir") {
                ShowSelectKanal();
            }
            else if (i == "EkipYonlendir") {
                ShowEkipYonlendir();
            }
            else if (i == "AnonsEdildi") {
                callback1.PerformCallback(2);
            }
            else if (i == "EksikIhbar") {
                callback1.PerformCallback(3);
            }
            else if (i == "GorusDisi") {
                callback1.PerformCallback(4);
            }
            else if (i == "KameraArizali") {
                callback1.PerformCallback(5);
            }
            else if (i == "KayitIndirildi") {
                callback1.PerformCallback(6);
            }
            else if (i == "TekrarIhbar") {
                callback1.PerformCallback(7);
            }
            else if (i == "YerindeKayit") {
                callback1.PerformCallback(8);
            }
            else if (i == "110112") {
                callback1.PerformCallback(18);
            }
            else if (i == "Belediye153") {
                callback1.PerformCallback(19);
            }
            else if (i == "DigerKurumlar") {
                callback1.PerformCallback(20);
            }
            else if (i == "Igdas187") {
                callback1.PerformCallback(21);
            }
            else if (i == "Iski185") {
                callback1.PerformCallback(24);
            }
            else if (i == "Jandarma156") {
                callback1.PerformCallback(22);
            }
            else if (i == "Tedas186") {
                callback1.PerformCallback(23);
            }
            else if (i == "AsilliIhbar") {
                callback1.PerformCallback(25);
            }
            else if (i == "AsilsiziIhbar") {
                callback1.PerformCallback(26);
            }
            else if (i == "Gorusici") {
                callback1.PerformCallback(27);
            }
            else if (i == "GorusDisi") {
                callback1.PerformCallback(28);
            } 

        }

        function OnContextMenuItemClick(s, e) {
            if (e.item.name == "GridKanal_cm_ihbarFarklıKanal") {
                ShowSelectKanal();
                e.processOnServer = false;
            } 
            else if (e.item.name == "GridKanal_cm_ekipYon") {
                ShowEkipYonlendir();
                e.processOnServer = false;

            }
            else if (e.item.name == "GridKanal_cm_ihbarNotEkle") {
                pcmessage_send.Show();
                e.processOnServer = true;
            }
            else {

                e.processOnServer = true;
            }
        }

        function OnContextMenuItemClick_Ekip(s, e) {
            if (e.item.name == "GridEkip_cm_ekipIhbaryerineUlas") {
                e.processOnServer = true;
            }
            else if (e.item.name == "GridEkip_cm_ihbarSonucRapor") { 
                s.GetRowValues(s.GetFocusedRowIndex(), "IK_NOT;IK_TIP", SetSelectedEkipPanel);
              
            }
        }

        function SetSelectedEkipPanel(values) { 
            txtSonucRaporu.SetText(values[0]);
            var inx = 0;
            if (values[1] == 'Asıllı') {
                inx = 0;
            }
            else {
                inx = 1;
            } 
            rbIhbarSonuc.SetSelectedIndex(inx); 
            if (values[0] != null) {
                rbIhbarSonuc.SetEnabled(false);
                txtSonucRaporu.SetEnabled(false);
                btnSonucRaporuTamam.SetEnabled(false);
            }



            pcSonucRaporu.Show();
            e.processOnServer = false;
        }


        function ShowSelectKanal() {
            pcSelectKanal.Show();
        }
        
        function CloseIhbar() {
            window.opener.location.href = window.opener.location.href;
            window.close();
        }

        function pmessageSEND(s, e) {

            pcmessage_send.Show();
            e.processOnServer = false;

        }
        function ShowEkipYonlendir() {
            popekip.Show();
        }

        function pplakaUPDATE(s, e) {

            pcplaka_send.Show();
        }


        function gridEkipList_SelectionChanged(s, e) {
            gridEkipList.GetSelectedFieldValues("EK_KODU", GetSelectedFieldValuesCallback);
        }

        function GetSelectedFieldValuesCallback(values) {
           
            lbEkipList.ClearItems();
            lbEkipList.BeginUpdate();

            var items = lbEkipinsert.GetSelectedItems();
            for (var i = 0; i < items.length ; i++) {
                lbEkipList.AddItem(items[i].value);
            }
              
          
            try { 
                for (var i = 0; i < values.length; i++) { 
                    lbEkipList.AddItem(values[i]);
                } 
            } finally {
                lbEkipList.EndUpdate();
            }

        }

        function btnEkle_Click(s, e) {
            var link = txtEkipEkle.GetValue();

            lbEkipinsert.BeginUpdate();
            try {
                lbEkipinsert.AddItem(link);
                txtEkipEkle.SetText('');
            } catch (e) {

            } finally {
                lbEkipinsert.EndUpdate();
                e.processOnServer = false;
            }

        }

        function newEkipInsert(s, e) {

            try {
                var link = s.GetSelectedItem().value;
                lbEkipList.AddItem(link);
            } catch (e) {

            } finally {
                lbEkipList.EndUpdate();
                e.processOnServer = false;
            }
        }

        //function ppsearch(s, e) { 
        //    pcarama_listesi.Show();
        //    e.processOnServer = false;
        //}
        function OnIlceChanged(rt_ilce) {
            rt_mahalle.PerformCallback(rt_ilce.GetValue().toString());
        }

        function OnMahalleChanged(rt_mahalle) {
            var ilceAndMahalle = rt_ilce.GetValue().toString() + "|" + rt_mahalle.GetValue().toString();
            rtsk_cadde.PerformCallback(ilceAndMahalle);
        }
    </script>
</asp:Content>
