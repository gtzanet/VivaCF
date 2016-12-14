<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="viva2_client.Account.ChangePassword" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Change your password</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Current Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CurrentPassword" CssClass="form-control" type="Password"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword"
                    CssClass="text-danger" ErrorMessage="The Current Password field is required." />
            </div>
        </div>
        <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">New Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="NewPassword" CssClass="form-control" type="Password"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword"
                    CssClass="text-danger" ErrorMessage="The New Password field is required." />
            </div>
        </div>
        <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="RetypePassword" CssClass="col-md-2 control-label">Retype Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="RetypePassword" CssClass="form-control" type="Password"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="RetypePassword"
                    CssClass="text-danger" ErrorMessage="The RetypePassword field is required." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="ChangePassword_Click" Text="Change Password" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>