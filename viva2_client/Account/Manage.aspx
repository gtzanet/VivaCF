<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Manage.aspx.cs" Inherits="viva2_client.Account.Manage" Async="true" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Panel ID="UserDisplay" runat="server"></asp:Panel>
</asp:Content>