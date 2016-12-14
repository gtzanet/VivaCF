<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ProjectDetails.aspx.cs" Inherits="viva2_client.Project.ProjectDetails" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/Projects.js"></script>
    <asp:Panel ID="ShowProject" runat="server"></asp:Panel>
   
    <asp:TextBox  ID="BAmount" runat="server"></asp:TextBox>
    <asp:TextBox ID="PrID" runat="server"></asp:TextBox>


    <div class="fb-share-button" data-href="http://localhost:63590/project/ProjectDetails?project_id=" data-layout="button_count" data-size="large" data-mobile-iframe="true"><a class="fb-xfbml-parse-ignore" target="_blank" href="https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fdevelopers.facebook.com%2Fdocs%2Fplugins%2F&amp;src=sdkpreparse">Share</a></div>
</asp:Content>

