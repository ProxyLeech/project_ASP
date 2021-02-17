<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourGuideDetails.aspx.cs" Inherits="TouristHelp.TourGuideDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap js-fullheight" style="background-image: url('images/bg_1.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center" data-scrollax-parent="true">
                <div class="col-md-9 text-center ftco-animate" data-scrollax=" properties: { translateY: '70%' }">
                    <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '80%', opacity: 1.6 }">Tour Guide Details</h1>
                </div>
            </div>
        </div>
    </div>

    <hr>



    <form id="form" runat="server">
        <div class="col-lg-12 ftco-animate">

            <div class="row">
                <asp:Label ID="tourguidenameLabel" CssClass="col-2" runat="server" Font-Size="15" Text="Name:"></asp:Label>
                <asp:Label ID="tourguidenameLabel2" CssClass="col-2" runat="server" Font-Size="15"></asp:Label>
            </div>

            <div class="row">

                <asp:Label ID="tourguideidLabel" CssClass="col-2" runat="server" Font-Size="15" Text="Tour Guide Id:"></asp:Label>
                <asp:Label ID="tourguideidLabel2" CssClass="col-5" runat="server" Font-Size="15"></asp:Label>


            </div>



            <div class="row">

                <asp:Label ID="tourguidedescriptionLabel" CssClass="col-2" runat="server" Font-Size="15" Text="Description:"></asp:Label>
                <asp:Label ID="tourguidedescriptionLabel2" CssClass="col-5" runat="server" Font-Size="15"></asp:Label>
            </div>
            <div class="row">

                <asp:Label ID="tourguidelanguagesLabel" CssClass="col-2" runat="server" Font-Size="15" Text="Languages:"></asp:Label>
                <asp:Label ID="tourguidelanguagesLabel2" CssClass="col-5" runat="server" Font-Size="15"></asp:Label>


            </div>

            <div class="row">

                <asp:Label ID="tourguidecredentialsLabel" CssClass="col-2" runat="server" Font-Size="15" Text="Credentials:"></asp:Label>
                <asp:Label ID="tourguidecredentialsLabel2" CssClass="col-5" runat="server" Font-Size="15"></asp:Label>

                <asp:Label ID="tourguideuserid" Visible="false" CssClass="col-2" runat="server" Font-Size="15" Text="Credentials:"></asp:Label>

            </div>


            <div class="row"  Style="float: right" >
                <asp:Button ID="ButtonRedirect"
                    Text="View Tours"
                    Font-Size="15"
                    OnClick="RedirectBtn_Click"
                    runat="server" />


                <asp:Button ID="ContactButton" margin-left="20px" Text="Contact Tour Guide" Font-Size="15" OnClick="ContactButton_Click" runat="server" />
            </div>
        </div>
    </form>





    <style>
        div.menu ul li {
            display: inline-block;
            height: 100%;
            padding: 0 1rem;
            text-align: center;
        }

        div.menu a {
            text-decoration: none;
            position: relative;
            top: 50%;
            margin-top: 100px;
            transform: translateY(-50%);
            display: inline-block;
            vertical-align: middle;
            line-height: normal;
        }




        div.position {
            width: 200px;
            text-align: right;
        }

        .form-group {
            display: inline-block;
            margin-right: 10px;
            float: left;
        }

            .form-group label {
                display: block;
            }


        div.row {
            margin-top: 30px;
        }
    </style>


</asp:Content>
