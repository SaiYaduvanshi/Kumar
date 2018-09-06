<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Yetki.aspx.cs" Inherits="EgmYKS.Yetki" %>

<%@ Register src="Ucntrl/Ucntrl_Yetki.ascx" tagname="Ucntrl_Yetki" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Ucntrl_Yetki ID="Ucntrl_Yetki1" runat="server" />

</asp:Content>
