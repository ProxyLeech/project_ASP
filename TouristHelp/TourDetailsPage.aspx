<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourDetailsPage.aspx.cs" Inherits="TouristHelp.TourDetailsPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <style>
            .button {
                background-color: #4CAF50; /* Green */
                border: none;
                color: white;
                padding: 15px 32px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                font-size: 16px;
            }
        </style>
    </header>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>


        <div class="col-lg-12">
            <h2>Tour Title</h2>
            <hr />
            <asp:Label Font-Size="15" ID="tourguidetitleLabel" CssClass="col-2" runat="server" Text="Title:"></asp:Label>
            <asp:Label ID="tourguideidLabel" Visible="false" CssClass="col-2" runat="server" Text="Tour Guide Id:"></asp:Label>
            <asp:Label ID="useridLabel" Visible="false" CssClass="col-2" runat="server" Text="User Id:"></asp:Label>
            <br />
            <br />
            <br />
            <h2>Tour Description</h2>
            <hr />
            <asp:Label Font-Size="15" ID="tourdescriptionLabel" CssClass="col-2" runat="server" Text=""></asp:Label>

        </div>
        <br />
        <br />
        <br />

        <div class="col-lg-12">
            <h2>Tour Details</h2>
            <hr />
            <asp:Label Font-Size="15" ID="tourdetailsLabel" CssClass="col-2" runat="server" Text=""></asp:Label>

        </div>

        <br />
        <br />
        <br />
        <div class="col-lg-12">

            <h2>Book this tour</h2>
            <hr />
            <b>Payment Will Be Made On The Day Itself</b>
        </div>

        <div class="col-lg-12">

            <b>Tour Price (SGD):</b>

            <asp:Label Font-Size="15" ID="tourpriceLabel" CssClass="col-2" runat="server" Text=""></asp:Label>
            <br />

            <asp:DropDownList ID="DropDownListCurrency" runat="server" OnSelectedIndexChanged="DropDownListCurrency_SelectedIndexChanged">
                <asp:ListItem>-</asp:ListItem>
                <asp:ListItem>USD</asp:ListItem>
                <asp:ListItem>AUS</asp:ListItem>
                <asp:ListItem>CAD</asp:ListItem>
                <asp:ListItem>EUR</asp:ListItem>
                <asp:ListItem>JPY</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="ConvertCurrency" runat="server" Text="Convert Currency" OnClick="ConvertCurrency_Click" />

            <br />
            <br />

            <b>Converted Tour Price:</b>
            <asp:Label Font-Size="15" ID="convertedtourpriceLabel" CssClass="col-2" runat="server" Text="-"></asp:Label>



            <br />

            <b>Please Select A Date For The Tour:</b>


            <asp:TextBox ID="TourDate" runat="server">Click to pick a date</asp:TextBox>

            <ajaxToolkit:PopupControlExtender ID="TourDate_PopupControlExtender" runat="server" BehaviorID="TourDate_PopupControlExtender" DynamicServicePath="" ExtenderControlID="" PopupControlID="Panel1" Position="Bottom" TargetControlID="TourDate">
            </ajaxToolkit:PopupControlExtender>

            <asp:TextBox ID="TourTime" runat="server" TextMode="Time"></asp:TextBox>

            <br />
            <asp:Panel ID="Panel1" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged2"></asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>

        </div>
        <asp:Button ID="BtnConfirm" runat="server" Style="float: right" Text="Confirm Booking" OnClick="BtnConfirm_Click" />




        <asp:Label ID="gettouristid" Visible="false" CssClass="col-2" runat="server" Text="Tour Guide Id:"></asp:Label>
        <asp:Label ID="gettourguidename" Visible="false" CssClass="col-2" runat="server" Text="Tour Guide Id:"></asp:Label>
        <asp:Label ID="gettourguideid" Visible="false" CssClass="col-2" runat="server" Text="Tour Guide Id:"></asp:Label>

    </form>

</asp:Content>
