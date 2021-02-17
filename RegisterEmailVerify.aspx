<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="RegisterEmailVerify.aspx.cs" Inherits="TouristHelp.RegisterEmailVerify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="signup-content">
                <div class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Thank you for joining us!"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="An email has been sent to you for verification of your account."></asp:Label>
&nbsp;Click the link in the email to verify your email, you can login after your email has been verified.<br />
                    <br />
                    <div class="form-group form-button">
                                <asp:Button ID="btnRedirLogin" runat="server" Text="Return to Login" CssClass="form-submit" OnClick="btnRedirLogin_Click" />
                            </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
