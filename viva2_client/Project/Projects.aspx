<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" 
    Inherits="viva2_client.Project.Projects" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/Projects.js"></script>
   
    <asp:Panel ID="ShowFilters" runat="server"></asp:Panel>
    
    <div class="row narrow">
        <asp:Panel ID="ShowProject" runat="server"></asp:Panel>
    </div>

    
</asp:Content>
