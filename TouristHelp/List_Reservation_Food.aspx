<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List_Reservation_Food.aspx.cs" Inherits="TouristHelp.List_Reservation_Food" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

    <div style="background-color: lightcyan">
        <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }" style="text-align: center; margin-bottom:0px; transform: translateZ(0px) translateY(10.929%);">Your Food Reservations</h1>
    </div>
    <asp:Label ID="Label1" Visible="false" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="RepeaterReserves" runat="server" OnItemCommand="DetailsRes">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12" style="border-style: solid; border-width: 1px; margin-bottom: 10px">
                    <div class="text p-3">
                        <asp:Label ID="LbId" runat="server" Visible="false" Text='<%#Eval("Id") %>'></asp:Label> 
                        <asp:Image ID="ReservationImage" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 300px; width: 350px;" ImageUrl='<%# Eval("Image")%>' runat="server" />
                        <div class="one">
                            <h3 id="Name"><%#Eval("Name") %></h3>
                        </div>
                        <div class="two">
                            <span class="price" id="time">Timing: <%#Eval("Date") %> : <%#Eval("Time") %></span></div>
                        <div><span><%#Eval("Pax") %> People</span></div>
                        <hr>
                            <asp:Button ID="ButtonSelect" runat="server" CssClass="btn btn-default" Text="More Details" Style="float: right" />
                        <br />
                        <br />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </form>
</asp:Content>
