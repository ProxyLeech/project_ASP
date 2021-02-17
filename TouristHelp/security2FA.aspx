 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="security2FA.aspx.cs" Inherits="TouristHelp.settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:Label ID="Label1" Visible="false" runat="server" Text=""></asp:Label>
   
            <%--<script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
        <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>

      <link rel="stylesheet" type="text/css" href="/Styles/settings.css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="setting.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


    <script src="JavaScript/jquery-1.10.2.js" type="text/javascript"></script>

        <div class="container">
            <div id="menu">

            <%--    <asp:Label runat="server" ID="test"> </asp:Label>--%>
<%--                Use this to display value from database, using DAL and BLL--%>
                <div class="row">

                    <div class="col-md-3">
                        <ul class="nav nav-pills nav-stacked admin-menu">

<%-- <li class="setting"><a href="/securityInfo.aspx">Account Info</a></li>--%>

                            <li class="setting2"><a href="/security2FA.aspx">Security</a></li>


<%--                            <li class="deleteAccount"><a href="/accountDelete.aspx">Deactivate Account</a></li>--%>

                        </ul>
                    </div>






                    <div class="col-md-9  admin-content" id="profile">
                        <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title2">What is 2FA?</h3>
                            </div>
                            <div class="panel-body">
                                <h1 style="font-weight:bold; font-size:25px;"> 2FA is an authentication method setup for
                                    account restriction to verify and protect the user's credentials
                                    <br>
                                    <br>
                                    We will send you a verification code if u activate one of our following methods to
                                    verify the user logging into your account
                                </h1>
                            </div>
                        </div>

                        <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title">Phone Number</h3>
                            </div>
                            <div class="panel-body">

                            



                                 

                            

                                  <asp:TextBox ID="confirmedPhone"  style="width:100%;font-size:18pt;margin-bottom:10px;" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>


                                 <asp:TextBox ID="phoneTB"  style="width:100%;font-size:18pt;margin-bottom:10px;" runat="server"></asp:TextBox>

                               <%-- <button type="submit" formaction="confirmPhone.aspx"
                                    style="margin-left:85%;width:17%;height:120%;" class="btn btn-success"
                                    onclick="">Verify </button>--%>

                                <div>

                                    <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                                    <div>

                                                                            <asp:Label ID="invalidPhone" runat="server" Font-Bold="True" Text="Invalid phone number, please input the correct number" ForeColor="Red" Visible="False"></asp:Label>

                                    </div>
                                </div>
                                <div>

                                                           <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Phone number input cannot be empty" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                                 </div>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="phoneTB" runat="server" ErrorMessage="Only Numbers allowed"  ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>

                                <asp:Button runat="server" ID="confirmPhoneBtn" style="width:100%;padding-top:10px;" class="btn btn-success" Text="Verify" OnClick="confirmPhoneBtn_Click"  />

                                <style>
                                    confirmPhoneBtn{
                                    }
                                </style>
                            </div>

                        </div>
                        <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title">2FA (Method 1)</h3>
                            </div>
                            <div class="panel-body2">
                                <h1 style="font-size:30px;margin-left:20px;"> Email/SMS Shield Status:
                                   <asp:Label ID="status2FALbl" runat="server" Text=""></asp:Label> </h1>

                          

                            </div>
                            <div class="panel panel-info" style="margin: 1em;">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Option 1: Email code verification</h3>

                                </div>
                                <div class="panel-body">

                                    <div>


                                        Whenever someone logs in, verification code will be send to <asp:Label ID="email2FALbl" runat="server" style="font-weight:bold; " Text=""></asp:Label> for
                                        verification



                                        <label class="switch">

                                            <asp:Button ID="checkEmail2FABtn"  style="margin-left:10%;width:110%;height:120%;padding: 5px 10px;" class="btn btn-success" runat="server" Text="" OnClick="checkEmail2FABtn_Click" />

                                        </label>

                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-info" style="margin: 1em;">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Option 2: Phone code verification</h3>
                                </div>
                                <div class="panel-body">

                                    <small id="emailHelp" class="form-text"><i class="fa fa-warning"
                                            style="font-size:18px;color:red"></i>

                                        (Phone number required)
                                        <i class="fa fa-warning" style="font-size:18px;color:red"></i>
                                    </small>


                                    Whenever someone logs in, verification code will be send to your verified phone
                                    number
                                    <br>
                                    <br>
                                    <label class="switch">
                     <asp:Button ID="CheckPhone2FABtn"  style="margin-left:10%;width:110%;height:120%;padding: 5px 10px;"  class="btn btn-success" runat="server" Text="" OnClick="CheckPhone2FABtn_Click" />

                                    </label>


                                </div>
                            </div>
                        </div>


                         <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title">Backup authentication</h3>
                            </div>
                    <%--        <div class="panel-body2">
                                <h1 style="font-size:30px;margin-left:20px;"> Google Authenticator Shield

                          

                            </div>--%>
                            <div class="panel panel-info" style="margin: 1em;">
                                <div class="panel-heading">
                                    <h3 class="panel-title"> Google Authenticator</h3>

                                </div>
                                <div class="panel-body">

                                    <div>


                                     In addition to your password and 2FA, you can be make use of code generated by the Google Authenticator app on your phone to verify when you sign in.
                                        
                                    <small id="emailHelp" class="form-text"><i class="fa fa-warning"
                                            style="font-size:18px;color:red"></i>

                                        (Required to Activate 2FA Email/SMS to use)
                                        <i class="fa fa-warning" style="font-size:18px;color:red"></i>
                                    </small>



                                            <asp:Button ID="authGetCode" style="margin-top:10%;width:100%;height:120%;padding: 5px 10px;" class="btn btn-success" runat="server" Text="Get Code" OnClick="authGetCode_Click" />

                                    </div>
                                </div>
                            </div>

          
                        </div>



                        <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title">Secure Sign Out</h3>
                            </div>
                            <div class="panel-body">
                                Sign out of all sessions

                                <label class="switch">
                           <%--         <button type="submit" formaction="/log"
                                        style="margin-left:1%;width:110%;height:120%;padding: 10px"
                                        class="btn btn-success">Confirm </button>--%>

                                    <asp:Button ID="clearSession"  style="margin-left:1%;width:110%;height:120%;padding: 10px"
                                        class="btn btn-success"  runat="server" Text="Confirm" OnClick="clearSession_Click" />
                                </label>
                            </div>
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
