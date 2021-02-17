<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPageRewardSystem.aspx.cs" Inherits="TouristHelp.AdminPageRewardSystem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


              <form id="form1" runat="server">




                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                      <ContentTemplate>

                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

                                            <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>

                          <style>
                              #Label1 {
                                  text-align:center;

                              }
                              #Timer1{
                                  text-align:center;
                              }
                          </style>

                      </ContentTemplate>
                  </asp:UpdatePanel>


    <div style="background-color: lightcyan">
        <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }" style="text-align: center; transform: translateZ(0px) translateY(10.929%);">Reward System</h1>
    </div>






 <div class="row" style="text-align:center;">



        <asp:Label ID="shopSystemLbl" CssClass="col-12" runat="server" Text="Shop GUI"></asp:Label>

      


      


                    </div>



                  <div class="row">

                      
                     <asp:Button ID="addShop" runat="server" CssClass="col-12" Text="Add shopVoucher" Width="124px" OnClick="ButtonAdd_Click" />






                  </div>       




                     <div class="row">



        <asp:Repeater ID="repeatShop" runat="server">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12" style="border-style: solid; border-width: 1px; margin-bottom: 10px">
                    <%-- Proto Box --%>

                    <a href="#" class="img img-2 d-flex justify-content-center align-items-center" style="background-image: url(images/destination-3.jpg);">
                        <div class="icon d-flex justify-content-center align-items-center">
                            <span class="icon-link"></span>
                        </div>
                    </a>

                    <div>
                     <asp:Label ID="hotelLbl" runat="server" Text="Voucher Id: "></asp:Label>

                            <asp:Label ID="voucherIdLbl" runat="server" Visible="true" Text='<%#Eval("voucher_id") %>'></asp:Label>

                    </div>

                    <div class="text p-3">
                        
                        <div class="one">
                            <h3 id="voucherNameLbl"><%#Eval("voucherName") %></h3>
                        </div>

                        <span>
                            <asp:Label ID="priceLbl" runat="server" Text="Credit Price:"></asp:Label>
                            <asp:Label ID="voucherPriceLbl" runat="server" Visible="true" Text='<%#Eval("voucherCost") %>'></asp:Label>
                        </span>
                    
                             <asp:Image ID="voucherImages" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 300px; width: 350px;"
                                                    ImageUrl='<%# Eval("shopimage")%>'
                                                    runat="server" />
                        <hr>


                         <div>
                            <asp:Label ID="voucherDescLbl" runat="server" Text="Voucher Description:"></asp:Label>
                            <asp:Label ID="voucherDesc" runat="server" Visible="true" Text='<%#Eval("shopDesc") %>'></asp:Label>
                        </div>

                             <div>
                            <asp:Label ID="voucherStatusLbl" runat="server" Text="Voucher Status:"></asp:Label>
                            <asp:Label ID="voucherStatus" runat="server" Visible="true" Text='<%#Eval("voucherStatus") %>'></asp:Label>
                        </div>


                                   

                       
                        <asp:Button ID="ButtonSelect" runat="server"  CssClass="btn btn-default" Text="More info" Style="float:right;" />
                        <br />
                        <br />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>




                        </div>





    </form>

</asp:Content>
