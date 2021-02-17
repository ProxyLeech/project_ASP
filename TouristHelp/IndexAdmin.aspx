<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="TouristHelp.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #welcomeBanner {
            height: 60vh;
            background-image: url('Images/splash.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center;
        }

        #welcomeText{
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="welcomeBanner" class="my-3">
        <p id="welcomeText" class="text-center pt-5 display-2">Welcome back Admin
    </div>

    <div class="container">
        
    </div>
</asp:Content>
