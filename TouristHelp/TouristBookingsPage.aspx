<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TouristBookingsPage.aspx.cs" Inherits="TouristHelp.TouristBookingsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

        <div>
            <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }" style="text-align: center; transform: translateZ(0px) translateY(10.929%);">Your Tour Guide Bookings</h1>
        </div>
        <br />
        <br />

        <asp:Repeater ID="RepeaterBookings" runat="server">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12" style="border-style: solid; border-width: 1px; margin-bottom: 10px">
                    <%-- Proto Box --%>

                    <a href="#" class="img img-2 d-flex justify-content-center align-items-center" style="background-image: url(images/destination-3.jpg);">
                        <div class="icon d-flex justify-content-center align-items-center">
                            <span class="icon-link"></span>
                        </div>
                    </a>
                    <div class="seven">
                        <asp:Label runat="server" Font-Size="15">Tour Id:</asp:Label>

                        <asp:Label ID="LbName" runat="server" Font-Size="15" Text='<%#Eval("TourId") %>'></asp:Label></td>
                    </div>

                    <div class="one">
                        <asp:Label runat="server" Font-Size="15">Tour Guide Id:</asp:Label>

                        <asp:Label ID="Label1" runat="server" Font-Size="15" Text='<%#Eval("TourGuideId") %>'></asp:Label></td>
                    </div>
                    <div class="two">
                        <asp:Label runat="server" Font-Size="15">Tour Guide Name:</asp:Label>

                        <asp:Label ID="Label2" runat="server" Font-Size="15" Text='<%#Eval("Name") %>'></asp:Label></td>
                    </div>
                    <div class="three">
                        <asp:Label runat="server" Font-Size="15">Tour Title:</asp:Label>

                        <asp:Label ID="Label3" runat="server" Font-Size="15" Text='<%#Eval("TourTitle") %>'></asp:Label></td>
                    </div>

                    <div class="four">
                        <asp:Label runat="server" Font-Size="15">Tour Date And Time:</asp:Label>

                        <asp:Label ID="Label4" runat="server" Font-Size="15" Text='<%#Eval("Timing") %>'></asp:Label></td>
                    </div>

                    <div class="five">
                        <asp:Label runat="server" Font-Size="15">Tour Status:</asp:Label>

                        <asp:Label ID="Label5" runat="server" Font-Size="15" Text='<%#Eval("Status") %>'></asp:Label></td>
                    </div>
                    

                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <hr>
    </form>
</asp:Content>
