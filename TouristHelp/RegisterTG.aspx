<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="RegisterTG.aspx.cs" Inherits="TouristHelp.RegisterTG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="signup-content">
                <div class="signup-form">
                    <h2 class="form-title">Sign up as a Tour Guide</h2>
                    <form class="register-form" id="FormRegisterTG" runat="server">
                        <div class="form-group">
                            <label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="tbNameTG" ForeColor="Red"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbNameTG" runat="server" placeholder="Your Name"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="tbEmailTG" ForeColor="Red"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbEmailTG" runat="server" placeholder="Your Email" TextMode="Email"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tbPasswordTG"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbPasswordTG" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="tbRepeatPassTG"></asp:RequiredFieldValidator></label>
                            <asp:TextBox ID="tbRepeatPassTG" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="tbLang" runat="server" placeholder="What languages can you speak?"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="tbDesc" runat="server" TextMode="MultiLine" MaxLength="144" placeholder="Describe yourself for us and potential clients..."></asp:TextBox>
                        </div>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Email has been used for another account!" ForeColor="Red" ControlToValidate="tbEmailTG" OnServerValidate="CustomValidator1_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Passwords must match!" ControlToValidate="tbPasswordTG" ControlToCompare="tbRepeatPassTG" Operator="Equal" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                        <div class="form-group form-button">
                            <asp:Button ID="btnSignupTG" runat="server" Text="Register" CssClass="form-submit" OnClick="btnSignupTG_Click" />
                        </div>
                    </form>
                </div>
                <div class="signup-image">
                    <figure>
                        <img src="Images/signup-image.jpg" alt="sign up image">
                    </figure>
                    <a class="signup-image-link" href="Login.aspx"><u>I have already signed up</u></a>
                    <a class="signup-image-link" href="RegisterTourist.aspx"><u>I want to sign up as a Tourist</u></a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>