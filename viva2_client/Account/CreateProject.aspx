<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="viva2_client.Account.CreateProject" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new Project</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
         <label for="sel1">Category</label>
         <select runat ="server" class="form-control" id="Category">
           <option>1</option>
           <option>2</option>
           <option>3</option>
           <option>4</option>
           <option>5</option>
         </select>
       </div>
        <div class="form-group">
         <label for="sel1">Sub Category</label>
         <select runat ="server" class="form-control" id="SubCategory">
           <option>1</option>
           <option>2</option>
           <option>3</option>
           <option>4</option>
           <option>5</option>
         </select>
       </div>
        <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="ProjectTitle" CssClass="col-md-2 control-label">Project Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ProjectTitle" CssClass="form-control"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectTitle"
                    CssClass="text-danger" ErrorMessage="The Project Title field is required." />
            </div>
        </div>
         <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="The Description field is required." />
            </div>
        </div>
          <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="Video" CssClass="col-md-2 control-label">Video</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Video" CssClass="form-control"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Video"
                    CssClass="text-danger" ErrorMessage="The Video field is required." />
            </div>
        </div>
         <div class="form-group">
            
            <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-2 control-label">Image</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Image" CssClass="form-control"/>                
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Image"
                    CssClass="text-danger" ErrorMessage="The Image field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FundingGoal" CssClass="col-md-2 control-label">Funding Goal</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FundingGoal" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FundingGoal"
                    CssClass="text-danger" ErrorMessage="The Ammount Name field is required." />
            </div>
        </div>
          <div class="form-group">
         <label for="sel1">Currency</label>
         <select runat ="server" class="form-control" id="Currency">
           <option>1</option>
           <option>2</option>
           <option>3</option>
           <option>4</option>
           <option>5</option>
         </select>
       </div>
        <div class="form-group">
         <label for="sel1">Country</label>
         <select runat ="server" class="form-control" id="Country">
           <option>Greece</option>
           <option>Brazil</option>
           <option>France</option>
           <option>England</option>
           <option>USA</option>
         </select>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateProject_Click" Text="Create Project" CssClass="btn btn-default" />
            </div>
        </div>
       
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                
            </div>
        </div>
    </div>
</asp:Content>
