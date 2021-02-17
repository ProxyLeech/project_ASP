<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="confirmPhone.aspx.cs" Inherits="TouristHelp.confirmPhone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="/Styles/settings.css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="setting.js"></script>



    <script src="JavaScript/jquery-1.10.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

                <%--<script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
        <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>
    

        <div class="container">
            <div id="menu">

                <div class="row">

                    <div class="col-md-3">
                        <ul class="nav nav-pills nav-stacked admin-menu">


                            <%--                            <li class="setting"><a href="/securityInfo.aspx">Account Info</a></li>--%>

                            <li class="setting2"><a href="/security2FA.aspx">Security</a></li>


                            <%--                            <li class="deleteAccount"><a href="/accountDelete.aspx">Delete Account</a></li>--%>
                        </ul>
                    </div>






                    <div class="col-md-9  admin-content" id="profile">
                        <div class="panel panel-info" style="margin: 1em;">
                        </div>

                        <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title">Verify Phone Number
                                    <div>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                        <asp:HiddenField ID="HiddenField2" runat="server" Value="" />

                                    </div>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <asp:TextBox ID="twofaphoneTB" class="form-control" runat="server"></asp:TextBox>

                                <%--  <input type="number"
                                    onkeydown="javascript: return event.keyCode === 8 || event.keyCode === 46 ? true : !isNaN(Number(event.key))"
                                    name="code" class="form-control" value="{{code}}" placeholder='Enter your verification code' />
                                <button type="submit" style="margin-left:70%;width:30%;" class="btn btn-success"
                                    onclick="">Verify phone</a>


                                --%>
                                <div>

                                     <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                                </div>
                                     <div>
                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="twofaphoneTB" runat="server" ErrorMessage="Unacceptable syntax, please enter only numbers and letters"  ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red"></asp:RegularExpressionValidator>


                                </div>
                                <div>

                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="incorrect input, please try again" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>

                                    <div>
                                        <asp:Panel ID="pnlThankYouMessage" runat="server" Enabled="False" Font-Bold="True" Font-Italic="False" Font-Size="Large" ForeColor="#009933" Visible="False">
                                            Phone number successfully updated... directing you to 2FA Settings page
                                        </asp:Panel>
                                    </div>

                                </div>

                                <asp:Button ID="phone2FA_Btn" runat="server" Text="Confirm" OnClick="verifyPhone" Style="margin-left: 70%; width: 30%;" class="btn btn-success" />
                            </div>

                        </div>







                    </div>




                </div>
            </div>
        </div>
         <script>
        console.log("test");
        grecaptcha.ready(function () {
            grecaptcha.execute('6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR', { action: 'homepage' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
                console.log(token);
            });
        });
    </script>
    </form>

</asp:Content>
