<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="KullaniciListesi.aspx.cs" Inherits="EgmYKS.KullaniciListesi" %>
<%@ Register src="Ucntrl/Ucntrl_KullaniciList.ascx" tagname="Ucntrl_KullaniciList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Ucntrl_KullaniciList ID="Ucntrl_KullaniciList1" runat="server" />
</asp:Content>
