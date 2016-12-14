<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="viva2_client.About" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>


  
    <div>
        <label>eisagwgi posou:</label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="amount11" ControlToValidate="TextBox1" 
            runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+">
        </asp:RegularExpressionValidator>
        
        <button id="test" type="button">Click Me!</button>
        <div id ="viva_button"></div>
    </div>



    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {



            $("#test").click(function () {

                $('#viva_button').html('  \
                    <form id="myform" method="post"> \
                        <button type="button" \
                            data-vp-sourcecode="Default" \
                            data-vp-publickey="y8YeFmNbbS7X6Nk0iHcKXZjocRR++l1yfFzmrtsdUb8=" \
                            data-vp-baseurl="https://demo.vivapayments.com" \
                            data-vp-lang="el" \
                            data-vp-amount="' + $("#MainContent_TextBox1").val() * 100 + '" \
                            data-vp-customeremail="customer@vivawallet.com" \
                            data-vp-customerfirstname = "" \
                            data-vp-customersurname = "" \
                            data-vp-merchantref="test merchant ref   aalalalalallal" \
                            data-vp-expandcard="true" \
                            data-vp-description="My product"> \
                        </button> \
                    </form>');


                var script = document.createElement( 'script' );
                script.type = 'text/javascript';
                script.src = "https://demo.vivapayments.com/web/checkout/js";
                $("#viva_button").append(script);


            }
            );









        });
    </script>





</asp:Content>
