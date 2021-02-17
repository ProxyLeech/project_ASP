<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="ForgotPasswordPage.aspx.cs" Inherits="TouristHelp.ForgotPasswordPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
        <style>
.button {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
}
.button1 {padding: 10px 24px;}

hr.solid {
  border-top: 3px solid #bbb;
}
</style>    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section class="sign-in">
             <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">
                        <figure>
                            <img src="Images/forgotpasswordimage.jpg" alt="sing up image">
                        </figure>
                        <a href="RegisterTourist.aspx" class="signup-image-link"><u>Create an account</u></a>
                        <a href="Login.aspx" class="signup-image-link"><u>Login</u></a>
                    </div>

                    <div class="signin-form">
                        <h2 class="form-title">Reset Password</h2>
                        <form id="FormSignIn" class="register-form" runat="server">
                            <div class="form-group form-button">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="*" ControlToValidate="tbEmailUser" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="tbEmailUser" runat="server" placeholder="Your Email" TextMode="Email"></asp:TextBox>  

                                <br />


                            </div>
                                                                                    <asp:Label ID="lblMessage" runat="server"></asp:Label>

                            <br />
                                         <asp:Label runat="server" ID="illegalCharLabel" ForeColor="Red"></asp:Label>
                            <br />
                                <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                            <div>

                            <asp:Button ID="btnResetPassword" runat="server" Text="Submit" CssClass="form-submit" OnClick="btnResetPassword_Click" />

                                </div>
                        </form>
                            <script>
                                console.log("test");
                                grecaptcha.ready(function () {
                                    grecaptcha.execute('6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR', { action: 'homepage' }).then(function (token) {
                                        document.getElementById("g-recaptcha-response").value = token;
                                        console.log(token);
                                    });
                                });

                            </script>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>