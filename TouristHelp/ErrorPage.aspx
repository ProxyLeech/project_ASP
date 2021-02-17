<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="TouristHelp.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 345px;
            height: 110px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" style="text-align:center" runat="server">
    <h1>ERROR FOUND</h1>
    <p><img class="auto-style1" src="Images/errorPlug.jpg" /></p>
    <h3>You have run into an error and the page has stopped working.</h3>
    <h3>We apologise for any inconvenience caused, please contact our staff if you need help.</h3>

    <asp:Button ID="ButtonHome" runat="server" Text="Return to home page" OnClick="ButtonHome_Click" style="border-style:solid; border-width:1px; background-color:white" Height="35px" Width="150px"/>
    </form>
    
</asp:Content>
