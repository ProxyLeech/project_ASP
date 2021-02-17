<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourGuideListPage.aspx.cs" Inherits="TouristHelp.TourGuideListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <form id="form1" runat="server">
        <div style="background-color: lightblue; /*border-style: solid*/">
            <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }" style="text-align: center; transform: translateZ(0px) translateY(10.929%);">Local Guides In Singapore</h1>

            <span style="margin-left: 20px">Language Filter: </span>
            <asp:DropDownList ID="DropDownListLanguage" runat="server" Style="margin-left: 20px">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>English</asp:ListItem>
                <asp:ListItem>Chinese</asp:ListItem>
                <asp:ListItem>Malay</asp:ListItem>
                <asp:ListItem>Tamil</asp:ListItem>
            </asp:DropDownList>



            <asp:Button ID="FilterButton" runat="server" Text="Search" OnClick="FilterButton_Click" Style="margin-left: 20px" />
            <br />
            <br />
        </div>

        <br />
        <br />

        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12 ftco-animate fadeInUp ftco-animated">
                    <div class="destination">
                        <a>
                            <asp:Image ID="tourguideImage" Style="height: 300px; width: 350px;"
                                ImageUrl='<%#Eval("TourGuideImage") %>' runat="server" />
                        </a>
                        &nbsp;&nbsp;&nbsp;<div class="text p-3">
                            <div class="d-flex">
                                <div class="one">
                                    <td>
                                        <label></label>
                                        <asp:Label runat="server" Font-Size="15">Name:</asp:Label>
                                        <asp:Label ID="LbName" runat="server" Font-Size="15" Text='<%#Eval("Name") %>'></asp:Label></td>
                                    <asp:Label ID="LbEmail" runat="server" Visible="false" Text='<%#Eval("Email") %>'></asp:Label></td>
                                           <asp:Label ID="LbuserId" runat="server" Visible="false" Text='<%#Eval("UserId") %>'></asp:Label></td>
                                         <asp:Label ID="LbtourguideId" runat="server" Visible="false" Text='<%#Eval("TourGuideId") %>'></asp:Label></td>

                                </div>
                                <td>
                                    <asp:Label ID="LbCredentials" runat="server" Font-Size="15" Visible="false" Text='<%#Eval("Credentials") %>'></asp:Label></td>




                            </div>
                            <td>
                                <asp:Label ID="LbPassword" runat="server" Visible="false" Text='<%#Eval("Password") %>'></asp:Label></td>
                            <asp:Label runat="server" Font-Size="15">Description:</asp:Label>

                            <asp:Label ID="LbDescription" runat="server" Font-Size="15" Text='<%#Eval("Description") %>'></asp:Label></td>
                                                        <p class="bottom-area d-flex">
                                                            <asp:Label runat="server" Font-Size="15">Languages:</asp:Label>

                                                            <td>


                                                                <asp:Label ID="LbLanguages" runat="server" Font-Size="15" Text='<%#Eval("Languages") %>'></asp:Label></td>

                                                        </p>

                            <td>
                                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="15">Learn More</asp:LinkButton>
                            </td>
                            <hr>

                            <td></td>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</asp:Content>

