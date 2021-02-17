<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Guidebook.aspx.cs" Inherits="TouristHelp.Guidebook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

    <div style="background-color: lightcyan;">
        <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }" style="text-align: center; transform: translateZ(0px) translateY(10.929%); ">Guidebook</h1>
        
        <span style="margin-left:20px">Show: </span>
        <asp:DropDownList ID="DdlType" runat="server" > 
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem Value="Place">Place</asp:ListItem>
            <asp:ListItem Value="Event">Event</asp:ListItem>
            <asp:ListItem Value="Deal">Deal</asp:ListItem>
        </asp:DropDownList>

        <span style="margin-left:20px">|&nbsp;&nbsp;&nbsp; Sort by: </span>
        <asp:DropDownList ID="DdlInterest" runat="server" > 
            <asp:ListItem>Popular</asp:ListItem>
            <asp:ListItem>Personalised</asp:ListItem>
        </asp:DropDownList>

        <span>  &nbsp;&nbsp;&nbsp;  |&nbsp;&nbsp;&nbsp;   </span>
        
        <asp:Button ID="ButtonFilter" runat="server" Text="Apply Filters" OnClick="ButtonFilter_Click" />
        <br />
        <br />
    </div>
        <asp:Repeater ID="RepeaterAttraction" runat="server" OnItemCommand="GoNextPage">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12" style="border-style: solid; border-width: 1px; margin-bottom: 10px">
                    <div class="text p-3">
                        <asp:Label ID="LbId" runat="server" Visible="false" Text='<%#Eval("Id") %>'></asp:Label> <%--to put id for db retrieval--%>
                        <asp:Label ID="LbType" runat="server" Visible="false" Text='<%#Eval("Type") %>'></asp:Label> 
                        <asp:Label ID="LbInterest" runat="server" Visible="false" Text='<%#Eval("Interest") %>'></asp:Label> 
                        <asp:Label ID="LbTran" runat="server" Visible="false" Text='<%#Eval("Transaction") %>'></asp:Label>
                        <%--<div class="col-6">--%>
                        <asp:Image ID="AttractionImage" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 300px; width: 350px;" ImageUrl='<%# Eval("Image")%>' runat="server" />
                        <%--</div>--%>
                        <%--<div class="col-6">--%>
                        <div class="one">
                            <h3 id="Name"><%#Eval("Name") %>
                            </h3>
                        </div>
                        <div class="two">
                            <span class="price" id="price">$<%#Eval("Price") %></span>
                        </div>
                        <div class="days">
                            <span><%#Eval("DateTime") %></span>

                        </div>
                        <%--</div>--%>
                        <h4 id="desc"><%#Eval("Description") %></h4>
                        <hr>
                        <p class="bottom-area d-flex">
                            <span><%#Eval("Location") %></span>
                        </p>

                        
                        <asp:Button ID="ButtonSelect" runat="server" Text="Make Reservation" Style="float: right; border-style:solid; border-width:1px; background-color:white" />
                        <br />
                        <br />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </form>
</asp:Content>
