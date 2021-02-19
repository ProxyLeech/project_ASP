<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TouristHelp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <%--<script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
        <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>
    

        <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">
                        <figure>
                            <img src="Images/signin-image.jpg" alt="sing up image">
                        </figure>
                        <a href="RegisterTourist.aspx" class="signup-image-link"><u>Create an account</u></a>
                        <a href="ForgotPasswordPage.aspx" class="signup-image-link"><u>Forgot Password</u></a>

                    </div>

                    <div class="signin-form">
                        <h2 class="form-title">Sign in</h2>
                        <form id="FormSignIn" class="register-form" runat="server">
                            <div class="form-group">
                                <asp:TextBox ID="tbEmail" runat="server" TextMode="Email" placeholder="Email Address"></asp:TextBox>
                            </div>


                            <div class="form-group">
                                <asp:TextBox ID="tbPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>

                            <div>  <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />

                            </div>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Email or password is wrong!" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                            <asp:Label ID="labelAccountLocked" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <div>

                    

                            </div>
                            <div class="form-group form-button">
                                
                                <asp:Button ID="btnLogin" runat="server" Text="Log In" CssClass="form-submit" OnClick="btnLogin_Click" />
                            </div>
                        </form>
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
        </section>
</asp:Content>