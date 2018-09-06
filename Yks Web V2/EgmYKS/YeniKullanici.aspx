<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="YeniKullanici.aspx.cs" Inherits="EgmYKS.YeniKullanici" %>
<%@ Register src="Ucntrl/Ucntrl_YeniKullanici.ascx" tagname="Ucntrl_YeniKullanici" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Ucntrl_YeniKullanici ID="Ucntrl_YeniKullanici1" runat="server" />
</asp:Content>
