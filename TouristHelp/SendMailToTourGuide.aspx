<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SendMailToTourGuide.aspx.cs" Inherits="TouristHelp.SendMailToTourGuide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="hero-wrap js-fullheight" style="background-image: url('images/bg_1.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center" data-scrollax-parent="true">
                <div class="col-md-9 text-center ftco-animate" data-scrollax=" properties: { translateY: '50%' }">

                    <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }">Contact Tour Guide</h1>
                </div>
            </div>
        </div>
    </div>
    <form id="form" runat="server">
        <div class="row">
            <asp:Label CssClass="col-1" runat="server" Text="Send To:"></asp:Label>
            <asp:TextBox ID="txtTo" CssClass="col-2" runat="server" ReadOnly="true"></asp:TextBox>

            <asp:Label CssClass="col-1" runat="server" Text="Subject:"></asp:Label>
            <asp:TextBox ID="txtSub" CssClass="col-2" runat="server"></asp:TextBox>


            <asp:Label CssClass="col-1" runat="server" Text="Body:"></asp:Label>
            <asp:TextBox ID="txtBody" CssClass="col-2" TextMode="MultiLine" runat="server"></asp:TextBox>

            <asp:Button ID="Sendbtn" runat="server" OnClick="Sendbtn_Click" Text="Send Mail" Width="80px" />

        </div>
    </form>
</asp:Content>

