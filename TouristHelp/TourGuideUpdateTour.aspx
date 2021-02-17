<%@ Page Title="" Language="C#" MasterPageFile="~/TourGuideLoggedIn.Master" AutoEventWireup="true" CodeBehind="TourGuideUpdateTour.aspx.cs" Inherits="TouristHelp.TourGuideUpdateTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <div class="row">
            <asp:Label ID="tourstitleLabel" CssClass="col-1" runat="server" Text="Tour Title:"></asp:Label>
            <asp:TextBox ID="tourstitleTextBox" CssClass="col-1" runat="server"></asp:TextBox>

            <asp:Label ID="tourdescriptionLabel" CssClass="col-1" runat="server" Text="Tour Description:"></asp:Label>
            <asp:TextBox ID="tourdescriptionTextBox" CssClass="col-1" runat="server"></asp:TextBox>

            <asp:Label ID="tourdetailsLabel" CssClass="col-1" runat="server" Text="Tour Details:"></asp:Label>
            <asp:TextBox ID="tourdetailsTextBox" CssClass="col-1" runat="server"></asp:TextBox>

            <asp:Label ID="tourpriceLabel" CssClass="col-1" runat="server" Text="Tour Price:"></asp:Label>
            <asp:TextBox ID="tourpriceTextBox" CssClass="col-1" runat="server"></asp:TextBox>

            <asp:Label ID="tourguideidLabel" CssClass="col-1" runat="server" Visible="false" Text="Credentials:"></asp:Label>
            <asp:Label ID="tourguideuseridLabel" CssClass="col-1" runat="server" Visible="false" Text="Credentials:"></asp:Label>



            <asp:Button ID="Button1" runat="server" OnClick="BtnSubmit1_Click" Text="Add Tour" Width="80px" />

        </div>
    </form>
</asp:Content>
