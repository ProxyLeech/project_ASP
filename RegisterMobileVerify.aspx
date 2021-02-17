<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="RegisterMobileVerify.aspx.cs" Inherits="TouristHelp.RegisterMobileVerify" %>
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
                    <asp:Label ID="Label2" runat="server" Text="A text message has been sent to you, input the correct code to verify your account."></asp:Label>
                    <br />
                    <br />
                    <div class="form-group form-button">
                        <asp:TextBox ID="tbVerificationCode" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button ID="btnRedirLogin" runat="server" Text="Verify Account" CssClass="form-submit" OnClick="btnRedirLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
