<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="LoginNotVerified.aspx.cs" Inherits="TouristHelp.LoginNotVerified" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="signup-content">
                <div class="auto-style1">
                    <asp:Label ID="lblMessageHeader" runat="server" Font-Bold="True" Text="Email Verification"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Text="Click the button below to resend a verification email."></asp:Label>
                    <br />
                    <div class="form-group form-button">
                                <asp:Button ID="btnResendEmail" runat="server" Text="Resend Email" CssClass="form-submit" OnClick="btnResendEmail_Click" />
                            </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
