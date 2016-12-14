<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="viva2_client.User.Profile" MasterPageFile="~/Site.Master" Async="true" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/Projects.js"></script>
    <h2><%: Title %>My Profile</h2>
    <asp:Panel ID="UserDisplay" runat="server"></asp:Panel>
    <li><a runat="server" href="~/Account/UpdateUserProfile">Edit Profile</a></li>
    <br />
    <h2><%: Title %>My Projects</h2>
    <div class="row narrow">
        <asp:Panel ID="ShowProjects" runat="server"></asp:Panel>
    </div>
</asp:Content>
