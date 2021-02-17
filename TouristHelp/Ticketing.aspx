<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticketing.aspx.cs" Inherits="TouristHelp.Ticketing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap js-fullheight" style="background-image: url('images/bg_1.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center" data-scrollax-parent="true">
                <div class="col-md-9 text-center ftco-animate" data-scrollax=" properties: { translateY: '70%' }">
                    <p class="breadcrumbs" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }"><span class="mr-2"><a href="Main.aspx">Home</a></span> <span>Tickets</span></p>
                    <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }">Tickets</h1>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="Label1" Visible="false" runat="server" Text=""></asp:Label>
    <form runat="server">
        <section class="ftco-section">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 ftco-animate">

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:Image ID="AttractionImage" class="img img-2 d-flex justify-content-center align-items-center" runat="server" Width="192px" />
                        <br />
                        <asp:Label ID="lbTicketName" runat="server" Font-Size="XX-Large"></asp:Label>
                        <br />
                        <asp:Label ID="lbTicketDesc" runat="server" Font-Size="Large"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Date:"></asp:Label>
                        <br />
                        <asp:TextBox ID="tbDate" runat="server"></asp:TextBox>

                        <ajaxToolkit:PopupControlExtender ID="tbDate_PopupControlExtender" runat="server" BehaviorID="tbDate_PopupControlExtender" DynamicServicePath="" ExtenderControlID="" PopupControlID="Panel1" Position="Bottom" TargetControlID="tbDate">
                        </ajaxToolkit:PopupControlExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDate" ErrorMessage="Please pick a date" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <br />
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged2" BackColor="White"></asp:Calendar>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                        <br />
                        <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="Quantity"></asp:Label>
                        <br />
                        <div class="row">
                            <span class="col-lg-6">
                                <asp:Label ID="lblCategory" runat="server" Font-Size="Medium" Text="Person"></asp:Label>
                            </span>
                            <span class="col-lg-3">
                                <asp:Label ID="dollar" runat="server" Font-Size="Medium" Text="$"></asp:Label>
                                <asp:Label ID="lblPrice" runat="server" Font-Size="Medium" Text="14.99"></asp:Label>
                            </span>
                            <span class="col-lg-3">
                                <asp:Button ID="BtnMinQ" runat="server" class="ml-auto" Text="-" OnClick="Btn_MinQ" />
                                <asp:TextBox ID="tbQuantity" runat="server" Width="18px">0</asp:TextBox>
                                <asp:Button ID="BtnAddQ" runat="server" class="ml-auto" Text="+" OnClick="Btn_AddQ" />
                            </span>
                        </div>
                        <br />
                        <br />
                        <asp:Button ID="BtnBuy" runat="server" Text="Add to Shopping Cart" Style="float: right" OnClick="BtnBuy_Click" />
                        <br />
                        <%--place repeater past here--%>
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
