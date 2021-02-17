<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="TouristHelp.Shop" %>

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
                        <h2>Shop</h2>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="breadcrumb_content text-right">
                        <p>Reward<span>/</span>Shop</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- breadcrumb start-->






    <form id="frm" runat="server">
           <asp:Label ID="notifyLabel" runat="server" visible="false" Text="Label"></asp:Label>

            <style>               

                #spanContentPlaceHolder1_notifyLabel{
                    font-size:30px;
                }
            </style>
        <div>
                 

            <div class="row">
                <asp:Label ID="creditBalanceTB" CssClass="col-2" runat="server" Text="Your Credit Balance:"></asp:Label>
                <asp:TextBox ID="creditBalance" CssClass="col-2" runat="server" Enabled="False"></asp:TextBox>



                <asp:Label ID="loginCountTB" CssClass="col-2" runat="server" Text="Total Days Login:"></asp:Label>

                <asp:TextBox ID="loginCount" CssClass="col-2" runat="server" Enabled="False"></asp:TextBox>

<%--                <asp:Button ID="addCreditBtn" CssClass="buttonPosition" runat="server" Text="Add Credits" OnClick="addCreditBtn_Click" />--%>

                
<%--                   <asp:Button ID="dailyReward"  runat="server" Text="Daily Reward" OnClick="dailyReward_Click" />--%>
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



            <div class="row">
                <asp:Label ID="loyaltyTierLabel" CssClass="col-2" runat="server" Text="Loyalty Tier: "></asp:Label>

                <asp:TextBox ID="loyaltyTier" runat="server" CssClass="col-2" Enabled="False"></asp:TextBox>





            </div>







        </div>









        <section>



            <span class="menu">
                <ul>
                    <li class="active"><a href="RewardPage.aspx">How It Works</a></li>
                    <li class="style1"><a href="Shop.aspx">Shop</a></li>
                    <li class="style2"><a href="TransactionPage.aspx">My Transaction</a></li>
                </ul>




            </span>
        </section>











        <%--        <table>
            <tr>
                <td>
                    <asp:GridView ID="GvEmployee" ShowHeader="true"
                        GridLines="None" AutoGenerateColumns="false"
                        runat="server" OnSelectedIndexChanged="GvEmployee_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>

                                          <td style="width: 1000px">
                                        <table>
                                            <section class="ftco-section">
                                                <div class="container">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="row">
                                                                <div class="col-sm col-md-6 col-lg-4 ftco-animate">
                                                                    <div class="destination">


                                                                        <asp:Image ID="shopImage" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 300px; width: 350px;"
                                                                            ImageUrl='<%# Eval("shopImage")%>'
                                                                            runat="server" />



                                                                        <div class="text p-3">
                                                                            <div class="d-flex">
                                                                                <div class="one">
                                                                                    <h3>
                                                                                        <asp:Label ID="voucherName" runat="server"></asp:Label>
                                                                                    </h3>

                                                                                    <asp:Label ID="voucherCost" runat="server" Style="margin-left: 10px;" ForeColor="BlueViolet" Text='<%#Eval("voucherCost") %>'></asp:Label>
                                                                                    <asp:Label ID="creditLabel" runat="server" Text="Credits"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                            <asp:Label ID="shopDesc" runat="server" Style="margin-left: 10px;" ForeColor="Black" Text='<%#Eval("shopDesc") %>'></asp:Label>
                                                                            <hr>
                                                                            <p class="bottom-area d-flex">


                                                                                <asp:DropDownList ID="voucher_Qty"  runat="server" AutoPostBack="True">
                                                                                    <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem>2</asp:ListItem>
                                                                                    <asp:ListItem>3</asp:ListItem>
                                                                                    <asp:ListItem>4</asp:ListItem>
                                                                                    <asp:ListItem>5</asp:ListItem>
                                                                                    <asp:ListItem>6</asp:ListItem>
                                                                                    <asp:ListItem>7</asp:ListItem>
                                                                                    <asp:ListItem>8</asp:ListItem>
                                                                                    <asp:ListItem>9</asp:ListItem>
                                                                                    <asp:ListItem>10</asp:ListItem>

                                                                                </asp:DropDownList>


                                                                                <asp:Button ID="Button1" runat="server" class="ml-auto" Text="Buy" OnClick="BtnSubmit_Click" />

                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </div>
                                                        <!-- .col-md-8 -->
                                                    </div>
                                                </div>
                                            </section>
                                            <!-- .section -->

                                        </table>
                                    </td>
                              
                                </ItemTemplate>

                                <HeaderTemplate>






                                    <section class="ftco-section">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg-3 sidebar order-md-last ftco-animate">
                                                    <div class="sidebar-wrap ftco-animate">
                                                        <h3 class="heading mb-4">Filter</h3>
                                                        <form action="#">

                                                            <div class="fields">
                                                                <div class="form-group">
                                                                    <input type="text" class="form-control" placeholder="Search for specific item">
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="select-wrap one-third">
                                                                        <div class="icon"><span class="ion-ios-arrow-down"></span></div>
                                                                        <select name="" id="" class="form-control">
                                                                            <option value="">Search By Category</option>
                                                                            <option value="">Popular</option>
                                                                            <option value="">Newest</option>
                                                                            <option value="">Low Price</option>
                                                                            <option value="">High Price</option>
                                                                        </select>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group">
                                                                    <input type="submit" value="Search" class="btn btn-primary py-3 px-5">
                                                                </div>
                                                            </div>
                                                        </form>
                                                    </div>
                                                    <div class="sidebar-wrap ftco-animate">
                                                        <form method="post" class="star-rating">
                                                        </form>
                                                    </div>
                                                </div>
                                                <!-- END-->
                                </HeaderTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>


                <td>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>


                        </ItemTemplate>
                        <SeparatorTemplate>
                        </SeparatorTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>--%>








        <td style="width: 1000px">

            <table>
                <section class="ftco-section">
                    <div class="container">


                        <div class="col-lg-12">
                            <%--start the repeater here--%>

                            <style>

                                 .size1of3 { float: left; width: 30%; }
                                </style>

                            <div>


                                       <div class="form-group">
                                                                         
                                 <asp:DropDownList ID="filterSearch"  class="form-control"  placeholder="Search By Category"   runat="server" AutoPostBack="True">
                                                            <asp:ListItem Selected="False" Value="Search By Category"></asp:ListItem>
                                                            <asp:ListItem>Popular</asp:ListItem>
                                                            <asp:ListItem>Newest</asp:ListItem>
                                                            <asp:ListItem>Low Price</asp:ListItem>
                                                            <asp:ListItem>High Price</asp:ListItem>
  
                                                        </asp:DropDownList>


                                                                      

                                                                        </div>

<%--                                <asp:Repeater ID="Repeat1" runat="server" EnableViewState="false" OnItemCommand="Repeat1_ItemCommand">--%>

                                    <ItemTemplate>

                                        <div class="size1of3">

                                            <span class="col-sm col-md-6 col-lg-4 ftco-animate">


                                                <asp:Image ID="shopImage" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 300px; width: 350px;"
                                                    ImageUrl='<%# Eval("shopImage")%>'
                                                    runat="server" />

                                                <asp:HiddenField runat="server" ID="voucher_id" Value='<%#Eval("voucher_id") %>' />


                                                <div class="text p-3">
                                                    <div class="d-flex">
                                                        <div class="one">
                                                            <h3>
                                                                <asp:Label ID="voucherName" runat="server" Text='<%#Eval("voucherName") %>'></asp:Label>
                                                            </h3>

                                                            <asp:Label ID="voucherCost" runat="server" Style="margin-left: 10px;" ForeColor="BlueViolet" Text='<%#Eval("voucherCost") %>'></asp:Label>
                                                            <asp:Label ID="creditLabel" runat="server" Text="Credits"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <span>

                                                        <asp:Label ID="shopDesc" runat="server" Style="margin-left: 10px;" ForeColor="Black" Text='<%#Eval("shopDesc") %>'></asp:Label>
                                                        <asp:Label ID="voucherStatus" runat="server" Style="margin-left: 10px;" ForeColor="Green" Text='<%#Eval("voucherStatus") %>'></asp:Label>
                                                        <asp:Label ID="voucherQty" runat="server" Text='<%#Eval("voucherQty") %>'></asp:Label>
                                                    </span>
                                                    <hr>
                                                    <p class="bottom-area d-flex">


                                                          <asp:HiddenField runat="server" ID="voucherPopularity" Value='<%#Eval("voucherPopularity") %>' />
                                                              <asp:HiddenField runat="server" ID="membershipCategory" Value='<%#Eval("membershipCategory") %>' />
                                                             <asp:HiddenField runat="server" ID="foodCategory" Value='<%#Eval("foodCategory") %>' />


                                                        <asp:DropDownList ID="voucherQuantity" runat="server" AutoPostBack="False">
                                                            <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>

                                                        </asp:DropDownList>


                                                        <asp:Button ID="Button1" runat="server" class="ml-auto" Text="Buy" OnClick="BtnSubmit_Click" />
                                                </div></p>
                                        </div>



                                    </ItemTemplate>
                                    <HeaderTemplate>


                                        <div class="searchPosition">

                                            <style>
                                                .searchPosition {
                                                    float: right;
                                                    width: 10%;

                                                
                                                }
                                                .form-control{
                                                    width:unset;
                                                }
                                            </style>
                                            <section class="ftco-section">
                                                <div class="container">
                                                    <div class="row">

                                                        <div class="col-lg-6">
                                                            <div class="sidebar-wrap ftco-animate">
                                                                <form action="#">

                                                                    <div class="fields">
                                                                   <%--     <div class="form-group">
                                                                            <input type="text" class="form-control" placeholder="Search for specific item">
                                                                        </div>--%>
                                                                 <%--       <div class="form-group">
                                                                         
                                 <asp:DropDownList ID="filterSearch"  class="form-control"  placeholder="Search By Category"   runat="server" AutoPostBack="True">
                                                            <asp:ListItem Selected="False" Value="Search By Category"></asp:ListItem>
                                                            <asp:ListItem>Popular</asp:ListItem>
                                                            <asp:ListItem>Newest</asp:ListItem>
                                                            <asp:ListItem>Low Price</asp:ListItem>
                                                            <asp:ListItem>High Price</asp:ListItem>
  
                                                        </asp:DropDownList>


                                                                      

                                                                        </div>--%>

                                                                        <style>
                                                                            .form-control {

                                                                            }
                                                                        </style>

                                                                      <%--  <div class="form-group">
                                                                            <input type="submit" value="Search" class="btn btn-primary py-3 px-5">
                                                                        </div>--%>
                                                                    </div>
                                                                </form>
                                                            </div>
                                                            <div class="sidebar-wrap ftco-animate">
                                                                <form method="post" class="star-rating">
                                                                </form>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                        </div>
                                    </HeaderTemplate>
                                   <SeparatorTemplate>    </SeparatorTemplate>

                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>

                                <br style="clear: left;" />
                            </div>


                        </div>
                        <!-- .col-md-8 -->
                    </div>
                </section>
                <!-- .section -->

            </table>
        </td>





        <%--  <td class="style2">
                 <asp:DropDownList ID="GeneralDDL"  AppendDataBoundItems="true"  DataTextField="DiagnosisCode" 
                  DataValueField="DiagnosisCode" runat="server" AutoPostBack="True" />
               </td>--%>















        <%--

    <section class="ftco-section">
      <div class="container">
        <div class="row">
        	<div class="col-lg-3 sidebar order-md-last ftco-animate">
        		<div class="sidebar-wrap ftco-animate">
        			<h3 class="heading mb-4">Filter</h3>
        			<form action="#">

        				<div class="fields">
		              <div class="form-group">
		                <input type="text" class="form-control" placeholder="Search for specific item">
		              </div>
		              <div class="form-group">
		                <div class="select-wrap one-third">
	                    <div class="icon"><span class="ion-ios-arrow-down"></span></div>
	                    <select name="" id="" class="form-control" >
	                      <option value="">Search By Category</option>
	                      <option value="">Popular</option>
	                      <option value="">Newest</option>
	                      <option value="">Low Price</option>
	                      <option value="">High Price</option>
	                    </select>
	                  </div>
		              </div>
		             
		              <div class="form-group">
		                <input type="submit" value="Search" class="btn btn-primary py-3 px-5">
		              </div>
		            </div>
	            </form>
        		</div>
        		<div class="sidebar-wrap ftco-animate">
        			<form method="post" class="star-rating">

							</form>
        		</div>
          </div><!-- END-->--%>














































        <%--
          <div class="col-lg-9">
          	<div class="row">
          		<div class="col-sm col-md-6 col-lg-4 ftco-animate">
		    				<div class="destination">
		    					<a href="#" class="img img-2 d-flex justify-content-center align-items-center" style="background-image: url(../Images/silverMember.png);">



                                    
		    						<div class="icon d-flex justify-content-center align-items-center">
		    							<span class="icon-link"></span>
		    						</div>
		    					</a>
		    					<div class="text p-3">
		    						<div class="d-flex">
		    							<div class="one">
				    					
				    				<h3> <asp:Label ID="voucherName" runat="server"></asp:Label> </h3>
			    						</div>
			    						<div class="two">
			    							<asp:Label class="price" runat="server" ID="voucherCost"></asp:Label>
                                            <asp:Label ID="creditLabel" runat="server" Text="Credits"></asp:Label>
		    							</div>
		    						</div>
                                  <asp:Label ID="voucherDesc" runat="server"></asp:Label> 
		    						<p class="days" id="voucherWarning"><span></span></p>
		    						<hr>
		    						
                                    	<p class="bottom-area d-flex">

                                              <asp:DropDownList ID="voucherQty" runat="server" AutoPostBack="True">
                                                <asp:ListItem Selected="True" Value="1"></asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                            </asp:DropDownList>





                                            <asp:Button ID="BtnSubmit"  CssClass="ml-auto" runat="server" Text="Purchase" OnClick="BtnSubmit_Click" />

		    						</p>
		    					</div>
		    				</div>
		    			</div>
		    	

		    			</div>
		    		



		    	
		    		
          	</div>--%>
        



        </div>
    </section> 

	

    </form>





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

          ul {
            text-align:center;
        }
        li.active {
            margin-left:150px;
        }
        span.menu a {
            text-decoration: none;
            position: relative;
            top: 50%;
            text-align: center;
            transform: translateY(-50%);
            display: inline-block;
            vertical-align: middle;
            line-height: normal;
        }

        div.row {
            margin-left: 100px;
            margin-top: 30px;
        }

        #creditLabel {
            margin-left: 40px;
        }

        .lblMsgCss {
            font-size: 20px;
            text-align: center;
        }

        .buttonPosition {
            margin-left: 100px;
        }
    </style>
</asp:Content>
