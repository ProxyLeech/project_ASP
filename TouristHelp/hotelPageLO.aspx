<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="HotelPageLO.aspx.cs" Inherits="TouristHelp.hotelPageLO" %>
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
                        <h2>Hotel</h2>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="breadcrumb_content text-right">
                        <p>Hotel</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- breadcrumb start-->





        <form id="frm" runat="server">







            <br />

            
<div class="wrapper">

            <section class="ftco-section">
      <div class="container">
        <div class="row">
        	<div class="col-lg-12 sidebar order-md-last ftco-animate">
        		<div class="sidebar-wrap ftco-animate">
        			<h3 class="heading mb-4">Find Hotels</h3>
        				<div class="fields">
		                   <div class="form-group">
		                <div class="select-wrap one-third">
	                    <div class="icon"><span class="ion-ios-arrow-down"></span></div>
	         

                                 <asp:DropDownList ID="region"  class="form-control" style="width:20%;margin-left:41%;" placeholder="Region"   runat="server" AutoPostBack="True">
                                                            <asp:ListItem Selected="False" Value="Region"></asp:ListItem>
                                                            <asp:ListItem>Central</asp:ListItem>
                                                            <asp:ListItem>North</asp:ListItem>
                                                            <asp:ListItem>South</asp:ListItem>
                                                            <asp:ListItem>West</asp:ListItem>
                                                            <asp:ListItem>East</asp:ListItem>
  
                                                        </asp:DropDownList>
	                  </div>
		              </div>
		    











		          
		        <%--      <div class="form-group">
		              	<div class="range-slider">
		              		<span>
										    <input type="number" value="300" min="0" id="minPrice" max="120000"/>	-
										    <input type="number" value="300" min="0" id="maxPrice" max="120000"/>
										  </span>
										  <input value="1000" min="0" max="120000" step="500" type="range"/>
										  <input value="50000" min="0" max="120000" step="500" type="range"/>
										</div>
		              </div>--%>


<%--                            <asp:Label ID="minPriceLbl"  runat="server" Text="Minimum Price"></asp:Label>

                                                    <div class="slidecontainer">
                          <input type="range" runat="server" min="100"  max="10000" value="100" class="slider" id="minPrice">
                          <p>Price: <span id="minPriceIndicator"></span></p>
                        </div>








                        <script>
                        var minSlider = document.getElementById("minPrice");
                            var minOutput = document.getElementById("minPriceIndicator");
                            minOutput.innerHTML = minSlider.value;

                            minSlider.oninput = function () {
                                minOutput.innerHTML = this.value;
                        }
                        </script>



                            
                            <asp:Label ID="maximumPriceLbl" runat="server" Text="Maximum Price"></asp:Label>

                                                    <div class="slidecontainer">
                          <input type="range" min="100" max="10000"  value="100" class="slider" id="maxPrice">
                          <p>Price:  <span id="maxPriceIndicator" ></span></p>
                        </div>








                        <script>
                        var maxSlider = document.getElementById("maxPrice");
                            var maxOutput = document.getElementById("maxPriceIndicator");
                            maxOutput.innerHTML = maxSlider.value;

                            maxSlider.oninput = function () {
                          maxOutput.innerHTML = this.value;
                        }
                        </script>--%>

                            <asp:Label ID="minPriceLbl" runat="server" Text="Min Price:"></asp:Label>

                            <asp:TextBox ID="minpriceTB" runat="server"></asp:TextBox>

                             <asp:Label ID="maxPriceLbl" runat="server" Text="Max Price:"></asp:Label>

                            <asp:TextBox ID="maxPriceTB" runat="server"></asp:TextBox>

		              <div class="form-group">
    <asp:Button ID="filterSearch" runat="server"  Text="Search"  OnClick="filterSearch_Btn"/>		              </div>
		            </div>















                                                    <script>
                                var slider = document.getElementById("myRange");
                                var output = document.getElementById("demo");
                                output.innerHTML = slider.value;

                                slider.oninput = function() {
                                  output.innerHTML = this.value;
                                }
                                </script>


                        <style>

                            span#ContentPlaceHolder1_minPriceLbl {
                               
                            }
                            

                              button, input, optgroup, select, textarea {
    font-family: unset;



               f {
                      margin-left:40%;
                  }





    .slidecontainer {
  width: 100%;
}

.slider {
  -webkit-appearance: none;
  width: 100%;
  height: 10px;
  border-radius: 5px;
  background: #d3d3d3;
  outline: none;
  opacity: 0.7;
  -webkit-transition: .2s;
  transition: opacity .2s;
}

.slider:hover {
  opacity: 1;
}

.slider::-webkit-slider-thumb {
  -webkit-appearance: none;
  appearance: none;
  width: 23px;
  height: 24px;
  border: 0;
  background: url('contrasticon.png');
  cursor: pointer;
}

.slider::-moz-range-thumb {
  width: 23px;
  height: 24px;
  border: 0;
  background: url('contrasticon.png');
  cursor: pointer;
}

              
}
                          </style>

                       
        		</div>


          </div><!-- END-->

          
          </div> <!-- .col-md-8 -->
        </div>
    </section> <!-- .section -->


    </div>

            <style>
                div.fields{
                    border-style: solid;
                    text-align:center;
                    width:89%;
                }


            </style>












          <asp:Label ID="hotelAddedLbl" runat="server" visible="false" Text="Label"></asp:Label>







            
   



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

                                <asp:Repeater ID="RepeatHotel" runat="server" EnableViewState="false"  OnItemCommand="RepeatHotel_ItemCommand" >







                                      <HeaderTemplate>

               

		
                          
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <div class="size1of3">

                                            <span class="col-sm col-md-6 col-lg-4 ftco-animate">
                                                





                                                <asp:Image ID="hotelImage" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 300px; width: 350px;"
                                                    ImageUrl='<%# Eval("hotelImage")%>'
                                                    runat="server" />

                                                <asp:HiddenField runat="server" ID="hotelId" Value='<%#Eval("hotelId") %>' />


                                                <div class="text p-3">
                                                    <div class="d-flex">
                                                        <div class="one">
                                                            <h3>
                                                                <asp:Label ID="hotelName" runat="server" Text='<%#Eval("hotelName") %>'></asp:Label>
                                                            </h3>
                                                            <asp:Label ID="priceLabel" runat="server" Text="$"></asp:Label>
                                                            <asp:Label ID="hotelPrice" runat="server" Style="margin-left: 10px;" ForeColor="BlueViolet" Text='<%#Eval("hotelPrice") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                  
                                                    <hr>
                                                    <p class="bottom-area d-flex">


                                                        <div class="row">

                                                              <div class="col-5">

                                                        <asp:Label ID="roomQtyLbl" runat="server" Text="Rooms"></asp:Label>

                                                        <asp:DropDownList ID="roomQty" runat="server" OnSelectedIndexChanged="myListDropDown_Change" AutoPostBack="False">
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
                                                                                                                                     
                                                                                                                              </div>



   
                                                                                                                                <div class="col-6">


                                                                   <asp:Label ID="durationLbl" runat="server" Text="Days"></asp:Label>

                                                        <asp:DropDownList ID="durationQty" runat="server" AutoPostBack="False">
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
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                            <asp:ListItem>21</asp:ListItem>
                                                            <asp:ListItem>22</asp:ListItem>
                                                            <asp:ListItem>23</asp:ListItem>
                                                            <asp:ListItem>24</asp:ListItem>
                                                            <asp:ListItem>25</asp:ListItem>
                                                            <asp:ListItem>26</asp:ListItem>
                                                            <asp:ListItem>27</asp:ListItem>
                                                            <asp:ListItem>28</asp:ListItem>
                                                            <asp:ListItem>29</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                          
                                                        </asp:DropDownList>

                                                                                                                                    </div>
                                                        
                                                            </div>



                                                        <div>

                                                            <br />
                                                         <asp:Button ID="BtnBuy" runat="server"  Text="Add to Shopping Cart" style="float:left;height:100%;width:100%;" OnClick="BtnBuy_Click"/>

                                                            
                                                        </div>
                                                </div></p>
                                        </div>



                                    </ItemTemplate>
                                                  
                                    <SeparatorTemplate>   </SeparatorTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>

                <asp:Label ID="Label2" Visible="false"  runat="server" Text="No records found"></asp:Label>

                                <style>

                                    #ContentPlaceHolder1_Label2 {
                                        text-align:center;
                                    }
                                </style>



















                                <br style="clear: left;" />
                            </div>


                        </div>
                        <!-- .col-md-8 -->
                    </div>
                </section>
                <!-- .section -->

            </table>
        </td>

        


            </form>
    

</asp:Content>
