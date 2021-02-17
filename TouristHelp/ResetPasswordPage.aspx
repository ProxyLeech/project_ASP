<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="ResetPasswordPage.aspx.cs" Inherits="TouristHelp.ResetPasswordPage" %>
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
    <section>
                <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>

        <div class="container">
            <div class="signup-content">
                <div class="signup-form">
                    <h2 class="form-title">Change Your Password</h2>
                    <form class="register-form" id="FormRegisterTG" runat="server">
                        <div class="form-group">
                            <label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tbNameTG"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbNameTG" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                        </div>
                                      <asp:Label ID="pwStr" runat="server" Text="Password Requirements: "><span id="result" runat="server"> </span></asp:Label>

                        <ul class="list-unstyled" runat="server">
                                        <li class=""><span class="low-upper-case"><i class="fa fa-file-text" aria-hidden="true"></i></span>&nbsp;1 Lowercase &amp; 1 Uppercase</li>
                                        <li class=""><span class="one-number"><i class="fa fa-file-text" aria-hidden="true"></i></span> &nbsp;1 number (0-9)</li>
                                        <li class=""><span class="one-special-char"><i class="fa fa-file-text" aria-hidden="true"></i></span> &nbsp;1 Special Character (!@#$%^&*).</li>
                                        <li class=""><span class="eight-character"><i class="fa fa-file-text" aria-hidden="true"></i></span>&nbsp; At Least 8 Characters</li>
                                    </ul>


                        <div class="form-group">
                            <label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tbEmailTG"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbEmailTG" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                        </div>
                          <asp:Label ID="lblMessage" runat="server"></asp:Label>



                   <asp:CompareValidator ID="CompareValidatorPasswords" runat="server" ErrorMessage="Passwords must match!" ControlToValidate="tbNameTG" ControlToCompare="tbEmailTG" Operator="Equal" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                         <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordLength" runat="server" Display="Dynamic" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidatorPasswordLength_ServerValidate">Password must be between 8 to 24 characters!</asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordUpper" runat="server" Display="Dynamic" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidatorPasswordUpper_ServerValidate">Password must start with an upper case letter!</asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordHistory" runat="server" ControlToValidate="tbNameTG" Display="Dynamic" ErrorMessage="Password must contain one numerical character" ForeColor="Red" OnServerValidate="CustomValidatorPasswordHistory_ServerValidate"></asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordSpecial" runat="server" Display="Dynamic" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidatorPasswordSpecial_ServerValidate">Password must contain one special character</asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorCheckHistory" runat="server" ControlToValidate="tbNameTG" Display="Dynamic" ErrorMessage="This Password cannot be used again!" ForeColor="Red" OnServerValidate="CustomValidatorCheckHistory_ServerValidate"></asp:CustomValidator>


                        <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />





                            <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="form-submit" OnClick="btnResetPassword_Click"/>
                                   
                    </form>
                    <a href="Login.aspx" class="signup-image-link"><u>Back To Login Page</u></a>

                </div>

            </div>
        </div>
    </section>
        <script>
        console.log("test");
        grecaptcha.ready(function () {
            grecaptcha.execute('6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR', { action: 'homepage' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
                console.log(token);
            });
        });
    </script>
</asp:Content>