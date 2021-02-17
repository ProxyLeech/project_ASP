<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TouristHelp.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #welcomeBanner {
            height: 60vh;
            background-image: url('Images/splash.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center;
        }
        #welcomeText {
            color: black;
        }
        .image {
            display: block;
            width: 360px;
            height: auto;
        }
        .overlay {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            height: auto;
            width: auto;
            opacity: 0;
            transition: .5s ease;
            background-color: #666666;
        }
        .overlay:hover {
            opacity: 0.8;
        }
        .text {
            color: white;
            font-size: 28px;
            position: absolute;
            top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="welcomeBanner" class="my-3">
        <p id="welcomeText" class="text-center pt-5 display-2">
            Welcome back,
            <asp:Label ID="LblName" runat="server" Text=""></asp:Label>
        </p>
    </div>

    <div class="container">
        <div class="row my-2 d-flex justify-content-center">
            <div class="col-3 mx-1">
                <!-- Hotel -->
                <img src="Images/index/hotel.jpg" alt="hotel" class="image">
                <a href="HotelPage.aspx">
                    <div class="overlay">
                        <div class="text">Hotels</div>
                    </div>
                </a>
            </div>
            <div class="col-3 mx-1">
                <!-- Rewards System -->
                <img src="Images/index/rewards.jpg" alt="rewards" class="image">
                <a href="RewardPage.aspx">
                    <div class="overlay">
                        <div class="text">Rewards</div>
                    </div>
                </a>
            </div>
            <div class="col-3 mx-1">
                <!-- Guideboook -->
                <a href="Guidebook.aspx">
                    <img src="Images/index/guidebook.jpg" alt="guidebook" class="image">
                    <div class="overlay">
                        <div class="text">Guidebook</div>
                    </div>
                </a>
            </div>
        </div>
        <div class="row my-2 d-flex justify-content-center">
            <div class="col-3 mx-1">
                <!-- Tour Guides -->
                <img src="Images/index/tourguide.jpg" alt="tour guide" class="image">
                <a href="TourGuideListPage.aspx">
                    <div class="overlay">
                        <div class="text">Tour Guide</div>
                    </div>
                </a>
            </div>
            <div class="col-3 mx-1">
                <!-- Ticketing -->
                <img src="Images/index/tickets.jpg" alt="tickets" class="image">
                <a href="Ticketing.aspx">
                    <div class="overlay">
                        <div class="text">Tickets</div>
                    </div>
                </a>
            </div>
            <div class="col-3 mx-1">
                <!-- Journey Planner -->
                <img src="Images/index/planner.jpg" alt="map" class="image">
                <a href="Planner.aspx">
                    <div class="overlay">
                        <div class="text">Journey Planner</div>
                    </div>
                </a>
            </div>
        </div>
    </div>
</asp:Content>