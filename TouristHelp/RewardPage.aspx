<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RewardPage.aspx.cs" Inherits="TouristHelp.RewardPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


   
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <asp:Label ID="Label1" Visible="false" runat="server" Text=""></asp:Label>
          <!-- breadcrumb start-->
    <section class="breadcrumb breadcrumb_bg align-items-center">
        <div class="container">
            <div class="row align-items-center justify-content-between">
                <div class="col-sm-6">
                    <div class="breadcrumb_tittle text-left">
                        <h2>Reward</h2>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="breadcrumb_content text-right">
                        <p><span>  </span></p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- breadcrumb start-->


            <form id="frm" runat="server">
                <div>
                <div class="row">
                <asp:Label ID="creditBalanceTB" CssClass="col-2" runat="server" Text="Your Credit Balance:"></asp:Label>
                <asp:TextBox id="creditBalance" CssClass="col-2" runat="server" Enabled="False" ></asp:TextBox>


                    
               <asp:Label ID="loginCountTB" CssClass="col-2" runat="server" Text="Total Days Login:"></asp:Label>

               <asp:TextBox id="loginCount" CssClass="col-2" runat="server" Enabled="False"></asp:TextBox>

                    </div>



                                    <div class="row">
                                        <asp:Label ID="membershipTierTB" CssClass="col-2" runat="server" Text="Membership Type:"></asp:Label>
                                        <asp:TextBox ID="membershipTier" CssClass="col-2" runat="server" Enabled="False">Membership: </asp:TextBox>


                                        <asp:Label ID="loginStreakTB" CssClass="col-2" runat="server" Text="Login Streak:"></asp:Label>

                                        <asp:TextBox ID="loginStreak" CssClass="col-2" runat="server" Enabled="False"></asp:TextBox>
              
                                                            </div>

              
                                                    <div class="row">
                                                        <asp:Label ID="totalDiscountTB" CssClass="col-2" runat="server" Text="Total Discount:  "></asp:Label>

                                                        <asp:TextBox ID="totalDiscount" runat="server" CssClass="col-2" Enabled="False"></asp:TextBox>





                                                        <asp:Label ID="remainBonusDaysTB" CssClass="col-2" runat="server" Text="Days before Credit Bonus:"></asp:Label>

                                                        <asp:TextBox ID="remainBonusDays" CssClass="col-2" runat="server" Enabled="False" Width="100"></asp:TextBox>

                                                        
                                                       <asp:Label ID="bonusCreditsTB" CssClass="col-1" runat="server" Text="Bonus Credits:"></asp:Label>

                                                        <asp:TextBox ID="bonusCredits" CssClass="col-2" runat="server" Enabled="False"></asp:TextBox>






                                                      

                                                                                        </div>



                  


                    </div>







            </form>


     <section>



            <span class="menu">
                <ul>
                    <li class="active"><a href="RewardPage.aspx">How It Works</a></li>
                    <li class="style1"><a href="Shop.aspx">Shop</a></li>
                    <li class="style2"><a href="TransactionPage.aspx">My Transaction</a></li>
                </ul>




            </span>
        </section>
               

        

    





<table>
               <section class="ftco-section services-section bg-light">
      <div class="container">
        <div class="row d-flex">
          <div class="col-md-3 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services d-block">
              <div class="icon"><span class="flaticon-yatch"></span></div>
              <div class="media-body">
                <h3 class="heading mb-3">Be Active!</h3>
                <p>Credits can be earned via daily logins, booking hotels and joining activities and attractions</p>
              </div>
            </div>      
          </div>
          <div class="col-md-3 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services d-block">
              <div class="icon"><span class="flaticon-around"></span></div>
              <div class="media-body">
                <h3 class="heading mb-3">Get rewarded</h3>
                <p>Credits can be used to purchase vouchers and membership to get special offers and discounts</p>
              </div>
            </div>    
          </div>
          <div class="col-md-3 d-flex align-self-stretch ftco-animate">
            <div class="media block-6 services d-block">
              <div class="icon"><span class="flaticon-compass"></span></div>
              <div class="media-body">
                <h3 class="heading mb-3">Loyalty pays!</h3>
                <p>Get PERMANANT discount by simply logging in everyday to reach higher loyalty tier</p>
              </div>
            </div>      
          </div>
          <div class="col-md-3 d-flex align-self-stretch ftco-animate">
                
          </div>
        </div>
      </div>


    </section>
                  


    </table>

   <style>
     span.menu ul li  {
            display: inline-block;
            height: 100%;
            padding: 0 1rem;
            text-align: center;
            font-size:25px;
            padding-left:100px;
            margin-top: 200px;
        }

        li.active {
            margin-left:100px;
        }

div.menu a {
  text-decoration: none;
  position: relative;
  top: 50%;
  margin-top:100px;
  transform: translateY(-50%);
  display: inline-block;
  vertical-align: middle;
  line-height: normal;

}




div.position{

    width:200px;
    text-align:right;
}

.form-group{
   display: inline-block;
   margin-right: 10px;
   float:left;
}

.form-group label{
   display: block;
}


div.row {

    margin-top:30px;
}


       </style>


</asp:Content>
