<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterestSelect.aspx.cs" Inherits="TouristHelp.InterestSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap js-fullheight" style="background-image: url('images/bg_1.jpg');">
      <div class="overlay"></div>
      <div class="container">
        <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center" data-scrollax-parent="true">
          <div class="col-md-9 text-center ftco-animate" data-scrollax=" properties: { translateY: '70%' }">
            <p class="breadcrumbs" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }"><span class="mr-2"><a href="Index.aspx">Home</a></span> <span>Interests</span></p>
            <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }">Your Interests</h1>
          </div>
        </div>
      </div>
    </div>
	
    <form runat="server">
    <section class="ftco-section">
      <div class="container">
        <div class="row">
          <div class="col-lg-12">
          	<div class="row">

          		<div class="col-sm col-md-6 col-lg-4 ftco-animate">
		    				<div class="destination">
                                <img class="img img-2 d-flex justify-content-center align-items-center" style="height:300px; width:350px;" src="Images/iconicFood.jpg"/>
		    					<div class="text p-3">
		    						<div class="d-flex">
		    							<div class="one">
				    						<asp:Label ID="IntFood" Text="Food" ForeColor="Black" runat="server"></asp:Label>
			    						</div>
		    						</div>
		    						<p>Find out what local cuisines are left to be discovered, waiting to be savoured.</p>
		    						<hr>
		    						<p class="bottom-area d-flex">
<%--		    							<asp:Button ID="BtnAddFood" runat="server" class="ml-auto" Text="Select" OnClick="Btn_AddInt" BackColor="Green" ForeColor="White" />--%>
<%--                                        <asp:Button ID="BtnRemFood" runat="server" class="ml-auto" Text="Remove" OnClick="Btn_RemoveInt" BackColor="Red" Visible="False" ForeColor="White" />--%>
		    						</p>
		    					</div>
		    				</div>
		    			</div>

		    			<div class="col-sm col-md-6 col-lg-4 ftco-animate">
		    				<div class="destination">
                                <img class="img img-2 d-flex justify-content-center align-items-center" style="height:300px; width:350px;" src="Images/gbtb.jpg" />
		    					<div class="text p-3">
		    						<div class="d-flex">
		    							<div class="one">
				    						<asp:Label ID="IntNature" Text="Nature" ForeColor="Black" runat="server"></asp:Label>
			    						</div>
		    						</div>
		    						<p>Experience the greenery and have a refreshing take on Singapore.</p>
		    						<hr>
		    						<p class="bottom-area d-flex">
<%--		    							<asp:Button ID="BtnAddNature" runat="server" class="ml-auto" Text="Select" OnClick="Btn_AddInt" BackColor="Green" ForeColor="White" />--%>
<%--                                        <asp:Button ID="BtnRemNature" runat="server" class="ml-auto" Text="Remove" OnClick="Btn_RemoveInt" BackColor="Red" Visible="False" ForeColor="White" />--%>
		    						</p>
		    					</div>
		    				</div>
		    			</div>
                        
                        <div class="col-sm col-md-6 col-lg-4 ftco-animate">
		    				<div class="destination">
                                <img class="img img-2 d-flex justify-content-center align-items-center" style="height:300px; width:350px;" src="Images/chinatown.jpg"/>
		    					<div class="text p-3">
		    						<div class="d-flex">
		    							<div class="one">
				    						<asp:Label ID="Label1" Text="Culture" ForeColor="Black" runat="server"></asp:Label>
			    						</div>
		    						</div>
		    						<p>Experience Singaporean's rich multicultural landscape.</p>
		    						<hr>
		    						<p class="bottom-area d-flex">
<%--		    							<asp:Button ID="BtnAddCulture" runat="server" class="ml-auto" Text="Select" OnClick="Btn_AddInt" BackColor="Green" ForeColor="White" />--%>
<%--                                        <asp:Button ID="BtnRemCulture" runat="server" class="ml-auto" Text="Remove" OnClick="Btn_RemoveInt" BackColor="Red" Visible="False" ForeColor="White" />--%>
		    						</p>
		    					</div>
		    				</div>
		    			</div>

		    			<div class="col-sm col-md-6 col-lg-4 ftco-animate">
		    				<div class="destination">
		    					<img class="img img-2 d-flex justify-content-center align-items-center" style="height:300px; width:350px;" src="Images/uss.jpg" />
		    					<div class="text p-3">
		    						<div class="d-flex">
		    							<div class="one">
				    						<asp:Label ID="IntAmusementPark" Text="Amusement Parks" ForeColor="Black" runat="server"></asp:Label>
			    						</div>
		    						</div>
		    						<p>Rediscover the definition of fun and thrill in our iconic amusement parks.</p>
		    						<hr>
		    						<p class="bottom-area d-flex">
<%--		    							<asp:Button ID="BtnAddAP" runat="server" class="ml-auto" Text="Select" OnClick="Btn_AddInt" BackColor="Green" ForeColor="White" />--%>
<%--                                        <asp:Button ID="BtnRemAP" runat="server" class="ml-auto" Text="Remove" OnClick="Btn_RemoveInt" BackColor="Red" Visible="False" ForeColor="White" />--%>
		    						    `</p>
		    					</div>
		    				</div>
		    			</div>

                        <div class="col-sm col-md-6 col-lg-4 ftco-animate">
		    				<div class="destination">
		    					<img class="img img-2 d-flex justify-content-center align-items-center" style="height:300px; width:350px;" src="Images/Orchard_Road.jpg" />
		    					<div class="text p-3">
		    						<div class="d-flex">
		    							<div class="one">
				    						<asp:Label ID="Label2" Text="Shopping" ForeColor="Black" runat="server"></asp:Label>
			    						</div>
		    						</div>
		    						<p>Discover Singapore's shopping.</p>
		    						<hr>
		    						<p class="bottom-area d-flex">
<%--		    							<asp:Button ID="BtnAddShopping" runat="server" class="ml-auto" Text="Select" OnClick="Btn_AddInt" BackColor="Green" ForeColor="White" />--%>
<%--                                        <asp:Button ID="BtnRemShopping" runat="server" class="ml-auto" Text="Remove" OnClick="Btn_RemoveInt" BackColor="Red" Visible="False" ForeColor="White" />--%>
		    						    `</p>
		    					</div>
		    				</div>
		    			</div>
          	</div>
          </div> <!-- .col-md-8 -->
        </div>
      </div>
    </section> <!-- .section -->
        </form>
</asp:Content>
