<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="firstLoginPage.aspx.cs" Inherits="TouristHelp.firstLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
	<form id="form1" runat="server">

    
	<!--Bootsrap 4 CDN-->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"
		integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

	<!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css"
		integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

	<!--Custom styles-->
	<link rel="stylesheet" type="text/css" href="styles.css">

	<!--Custom social media icon-->

	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


        <style>
        #welcomeBanner {
            height: 100vh;
            width:100%;

            background-image: url('Images/splash.jpg');
            background-repeat: no-repeat;
            background-size: 100%;
            background-position: center;
        }
        #welcomeText {
            color: black;
        }
        .image {
            display: block;
            width: 100%;
            height: 100%;
        }
        .overlay {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            height: auto;
            width: auto;
            opacity: 0;
            transition: .5s ease;
            background-color: #666666;
        }
        .overlay:hover {
            opacity: 0.8;
        }
        .text {
            color: white;
            font-size: 28px;
            position: absolute;
            top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            text-align: center;
        }
    </style>



    <div id="welcomeBanner" class="my-3">
        <p id="welcomeText" class="text-center pt-5 display-2">
            Welcome
            <asp:Label ID="LblName" runat="server" Text=""></asp:Label>
        </p>
   


        <div class="container">
            <div class="d-flex justify-content-center h-100">
                <div class="card">
                    <div class="card-header">
                        <br>
                        <h3 class="text-center">Lets enhance your account security first!</h3>


                    </div>

                    <div class="card-body">
                            <div class="form-group">

                                <div class="form-group">

                                   
                                    <div class="input-group form-group" style="padding-left:15%">
                                        <div class="input-group-prepend">

                                             <div id="wrapper">

                                                 <asp:Label runat="server"> <b style="padding-right:50%;"> Head to main page  </b> </asp:Label>

                                                 
                                   <asp:Button runat="server" ID="mainPageNav" Text="Not Now" OnClick="mainPageNav_Click" />
                                    
                                        


                                        </div>


                                             <div id="wrapper2">

                                                                                                  <asp:Label runat="server"> <b> Head to 2FA security  </b> </asp:Label>

                                                                                         <asp:Button runat="server" ID="SecurityNav" Text="Enhance account security" OnClick="SecurityNav_Click" />


                                                 </div>

                                        </div>

                                        <style>

       
#first {
    
    padding-top:30%;
   
    padding-left:50%;

}
#second {

    float: right; /* if you don't want #second to wrap below #first */
 
}
                                        </style>

                                       
                                        
                                    </div>



                                </div>
                               

                            </div>

                    </div>

                </div>


            </div>
            </div>

         </div>



    </form>
</asp:Content>
