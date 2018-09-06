<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="KanalGrup.aspx.cs" Inherits="EgmYKS.KanalGrup" %>
<%@ Register src="Ucntrl/Ucntrl_KanalGrup.ascx" tagname="Ucntrl_KanalGrup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Ucntrl_KanalGrup ID="Ucntrl_KanalGrup1" runat="server" />
</asp:Content>
