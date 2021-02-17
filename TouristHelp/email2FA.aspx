<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="email2FA.aspx.cs" Inherits="TouristHelp.email2FA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<form id="form1" runat="server">

               <%--<script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
        <script src="https://www.google.com/recaptcha/api.js?render=6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR"></script>

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

		<div class="container">
			<div class="d-flex justify-content-center h-100">
				<div class="card">
					<div class="card-header">
						<br>
						<h3 class="text-center"> Email Verification 2FA Shield</h3>


					</div>

					<div class="card-body">
							<div class="form-group">
							
								<div class="form-group">
									<label for="password" class="labels">Verification code:</label>
									<div class="input-group form-group">
										<div class="input-group-prepend">

											<span class="input-group-text"><i class="fas fa-key"></i></span>
										</div>
                                        <asp:TextBox ID="twofaemailTB"  class="form-control"  runat="server"></asp:TextBox>
									   <%-- <asp:TextBox ID="authTestTB" runat="server"></asp:TextBox>--%>
									<%--	<input type="text"  name="twofaemailTB" id="twofaemailTB"  class="form-control" required
											value="">--%>
									</div>

                                    <asp:LinkButton ID="directAuth" 
    runat="server" 
    CssClass="myclass" 
    OnClick="authRedirect">
Verify using google authenticator
</asp:LinkButton>

								</div>      
<%--								<button type="submit" formaction="/user/indexVerified"  style="margin-top:20%; background-color:lightgreen" onclick="" class="btn float-right login_btn">Confirm</button>--%>
		    <asp:Button ID="email2FA_Btn" runat="server" Text="Confirm" OnClick="verifyEmail" style="left:100%;" class="btn float-right login_btn"  BackColor="#66FF33" />
                                <div>
                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="twofaemailTB" runat="server" ErrorMessage="Unacceptable syntax, please enter only numbers and letters"  ValidationExpression="^[a-zA-Z0-9]*$" ForeColor="Red"></asp:RegularExpressionValidator>


                                </div>
                                                                 <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />

                            </div>

                        <div>
                       <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="incorrect input, please try again" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>

                            <asp:Image ID="imgQRCode" runat="server" />

                        </div>

					</div>

				</div>

			    <script>
        console.log("test");
        grecaptcha.ready(function () {
            grecaptcha.execute('6LeCmFcaAAAAAN5ssnmNAR_cfeLjHvErNqYRlpYR', { action: 'homepage' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
                console.log(token);
            });
        });
    </script>

	
                </form>

    


</asp:Content>
