<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="RegisterEmailConfirm.aspx.cs" Inherits="TouristHelp.RegisterEmailConfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="signup-content">
                <div class="auto-style1">
                    <asp:Label ID="lblMessageHeader" runat="server" Font-Bold="True" Text="Thank you for joining us!"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" Text="Your Account has been successfully verified, you may now start using our services!"></asp:Label>
                    <br />
                    <div class="form-group form-button">
                                <asp:Button ID="btnRedirLogin" runat="server" Text="Return to Login" CssClass="form-submit" OnClick="btnRedirLogin_Click" />
                            </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
