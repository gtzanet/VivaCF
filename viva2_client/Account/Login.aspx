<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="Login.aspx.cs" Inherits="viva2_client.Account.Login" Async="true" enableEventValidation="false" %>

<%--@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" --%>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %>.</h2>

    <div class="row">


        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal" id ="LoginForm">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID ="Login_Button"  Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                </p>
            </section>
        </div>

    </div>
    <div id ="response"></div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
     <script>
         function validateEmail(email) {
             var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
             return re.test(email);
         }

         $(document).ready(function () {
             $("#ctl01").submit(function (e) {

                 e.preventDefault();

                 var email = $('#MainContent_Email').val();
                 var password = $('#MainContent_Password').val();

                 if (validateEmail(email) && password) {

                     $.ajax({
                         url: 'http://localhost:60264/api/viva2',
                         type: 'Post',
                         contenttype: 'jsonp',
                         dataType: 'text',
                         beforeSend: function (xhr) {
                             $('#response').html("<img src='/images/loading.gif' />");
                             xhr.setRequestHeader("Authorization", "Basic " + btoa(email + ":" + password));
                         },
                        success: function (data) {
                            $('#response').html("");
                            $('#title_username').html(email);
                            document.cookie = "token=" + btoa(email + ":" + password) + ";path=/";
                            alert("Your login was successful");

                             window.location.href = "http://localhost:63590/project/projects";
                         },
                         
                         error: function (xhr, textStatus, errorThrown) {
                             alert(errorThrown);
                             $('#response').html("");
                         }

                     });
                 }
                 else {
                     alert("Incorrect Credentials");
                 }


             });
         });


    </script>







</asp:Content>
