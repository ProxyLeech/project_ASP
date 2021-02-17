<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="RegisterTourist.aspx.cs" Inherits="TouristHelp.RegisterTourist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 68%;
            overflow: hidden;
            margin-left: 0px;
            margin-right: 0px;
            padding: 0 30px;
        }
        .auto-style2 {
            position: relative;
            overflow: hidden;
            left: 0px;
            top: 0px;
            margin-bottom: 25px;
        }
    </style>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <%--<script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
        <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>
    
        
        <div class="container" runat ="server">
            <div class="signup-content" runat ="server">
                <div class="auto-style1" runat ="server">
                    <form class="register-form" id="FormRegister" runat="server">
                        <h2 class="form-title">
                            <asp:HyperLink ID="backLink" runat="server" Font-Size="Small" NavigateUrl="~/IndexLO.aspx">&lt; Back to Home</asp:HyperLink>
                        </h2>
                        <h2 class="form-title">Sign up as a Tourist</h2>
                        <div class="form-group">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="*" ControlToValidate="tbNameTourist" ForeColor="Red"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbNameTourist" runat="server" placeholder="Your Name"></asp:TextBox>
                        </div>
                        <div class="form-group">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="*" ControlToValidate="tbEmailTourist" ForeColor="Red"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbEmailTourist" runat="server" placeholder="Your Email" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="auto-style2">
                            <asp:Label ID="lblNation" runat="server" Text="Nationality: "></asp:Label>
                            <asp:DropDownList ID="ddlNation" runat="server">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidatorNationality" runat="server" ErrorMessage="*" ValueToCompare='-- Select --' Operator="NotEqual" ControlToValidate="ddlNation" ForeColor="Red"></asp:CompareValidator>
                        </div>
                        <div class="form-group" runat="server">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tbPasswordTourist"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbPasswordTourist" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
<%--                        <asp:Label ID="pwStr" runat="server" Text="Password Strength: "><span id="result" runat="server"> </span></asp:Label>
                                    <div class="progress">
                                        <div id="passwordStrength" runat="server" class="progress-bar" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:0%">
                                        </div>
                                    </div>--%>
                        <%--<ul class="list-unstyled" runat="server">
                                        <li class=""><span class="low-upper-case"><i class="fa fa-file-text" aria-hidden="true"></i></span>&nbsp; 1 lowercase &amp; 1 uppercase</li>
                                        <li class=""><span class="one-number"><i class="fa fa-file-text" aria-hidden="true"></i></span> &nbsp;1 number (0-9)</li>
                                        <li class=""><span class="one-special-char"><i class="fa fa-file-text" aria-hidden="true"></i></span> &nbsp;1 Special Character (!@#$%^&*).</li>
                                        <li class=""><span class="eight-character"><i class="fa fa-file-text" aria-hidden="true"></i></span>&nbsp; Atleast 8 Character</li>
                                    </ul>--%>
                        <div class="form-group">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPswd" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tbRepeatPassTourist"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbRepeatPassTourist" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>
                        </div>
                        
                            <asp:CustomValidator ID="CustomValidatorEmailExists" runat="server" ErrorMessage="Email has been used for another account!" ForeColor="Red" ControlToValidate="tbEmailTourist" OnServerValidate="CustomValidatorEmailExists_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidatorPasswords" runat="server" ErrorMessage="Passwords must match!" ControlToValidate="tbPasswordTourist" ControlToCompare="tbRepeatPassTourist" Operator="Equal" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordLength" runat="server" Display="Dynamic" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidatorPasswordLength_ServerValidate">Password must be between 8 and 24 characters</asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordHistory" runat="server" ControlToValidate="tbPasswordTourist" Display="Dynamic" ErrorMessage="Password must contain one numerical character" ForeColor="Red" OnServerValidate="CustomValidatorPasswordHistory_ServerValidate"></asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordUpper" runat="server" Display="Dynamic" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidatorPasswordUpper_ServerValidate">Password must contain one upper case character</asp:CustomValidator>
                        <br />
                        <asp:CustomValidator ID="CustomValidatorPasswordSpecial" runat="server" Display="Dynamic" ErrorMessage="CustomValidator" ForeColor="Red" OnServerValidate="CustomValidatorPasswordSpecial_ServerValidate">Password must contain one special character</asp:CustomValidator>
                        <br />
                        <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                        <div class="form-group form-button">
                            <asp:Button ID="btnSignupTourist" runat="server" Text="Register" CssClass="form-submit" OnClick="btnSignupTourist_Click" />
                        </div>
                    </form>
                </div>
                <div class="signup-image">
                    <figure>
                        <img src="Images/signup-image.jpg" alt="sign up image">
                    </figure>
                    <a class="signup-image-link" href="Login.aspx"><u>I have already signed up</u></a>
                    <a class="signup-image-link" href="RegisterTG.aspx"><u>I want to sign up as a Tour Guide</u></a>
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
   <%-- <script>
            
            $(document).ready(function () {
                $(function(){ // this will be called when the DOM is ready
              $('#tbPasswordTourist').keyup(function() {
                alert('Handler for .keyup() called.');
              });
            });
                passwordStrength();
                console.log("test");
            });

            function passwordStrength() {
                $('#tbPasswordTourist').keyup(function () {
                    console.log("test");
				    var passwordEntered = $('#tbPasswordTourist').val();
				    checkStrength(passwordEntered);
				    if (checkStrength(passwordEntered) == false) {
					    $('#btnSignupTourist').attr('disabled', true);
				    } else {
					    $('#btnSignupTourist').attr('disabled', false);
                    }
                })

                function checkStrength(passwordEntered) {
                    var strength = 0;

                    //If password contains both lower and uppercase characters, increase strength value.
                    if (passwordEntered.match(/([a-z].*[A-Z])|([A-Z].*[a-z])/)) {
                        strength += 1;
                        $('.low-upper-case').addClass('text-success');
                        $('.low-upper-case i').removeClass('fa-file-text').addClass('fa-check');
                        $('#popover-password-top').addClass('hide');


                    } else {
                        $('.low-upper-case').removeClass('text-success');
                        $('.low-upper-case i').addClass('fa-file-text').removeClass('fa-check');
                        $('#popover-password-top').removeClass('hide');
                    }

                    //If it has numbers and characters, increase strength value.
                    if (passwordEntered.match(/([a-zA-Z])/) && passwordEntered.match(/([0-9])/)) {
                        strength += 1;
                        $('.one-number').addClass('text-success');
                        $('.one-number i').removeClass('fa-file-text').addClass('fa-check');
                        $('#popover-password-top').addClass('hide');

                    } else {
                        $('.one-number').removeClass('text-success');
                        $('.one-number i').addClass('fa-file-text').removeClass('fa-check');
                        $('#popover-password-top').removeClass('hide');
                    }

                    //If it has one special character, increase strength value.
                    if (passwordEntered.match(/([!,%,&,@,#,$,^,*,?,_,~])/)) {
                        strength += 1;
                        $('.one-special-char').addClass('text-success');
                        $('.one-special-char i').removeClass('fa-file-text').addClass('fa-check');
                        $('#popover-password-top').addClass('hide');

                    } else {
                        $('.one-special-char').removeClass('text-success');
                        $('.one-special-char i').addClass('fa-file-text').removeClass('fa-check');
                        $('#popover-password-top').removeClass('hide');
                    }

                    if (passwordEntered.length > 7) {
                        strength += 1;
                        $('.eight-character').addClass('text-success');
                        $('.eight-character i').removeClass('fa-file-text').addClass('fa-check');
                        $('#popover-password-top').addClass('hide');

                    } else {
                        $('.eight-character').removeClass('text-success');
                        $('.eight-character i').addClass('fa-file-text').removeClass('fa-check');
                        $('#popover-password-top').removeClass('hide');
                    }

                    // If value is less than 2

                    if (strength < 2) {
                        $('#result').removeClass()
                        $('#passwordStrength').addClass('progress-bar-danger');

                        $('#result').addClass('text-danger').text('Very Week');
                        $('#passwordStrength').css('width', '10%');
                    } else if (strength == 2) {
                        $('#result').addClass('good');
                        $('#passwordStrength').removeClass('progress-bar-danger');
                        $('#passwordStrength').addClass('progress-bar-warning');
                        $('#result').addClass('text-warning').text('Week')
                        $('#passwordStrength').css('width', '60%');
                        return 'Week'
                    } else if (strength == 4) {
                        $('#result').removeClass()
                        $('#result').addClass('strong');
                        $('#passwordStrength').removeClass('progress-bar-warning');
                        $('#passwordStrength').addClass('progress-bar-success');
                        $('#result').addClass('text-success').text('Strength');
                        $('#passwordStrength').css('width', '100%');

                        return 'Strong'
                    }

                }
            }

        </script>--%>
</asp:Content>