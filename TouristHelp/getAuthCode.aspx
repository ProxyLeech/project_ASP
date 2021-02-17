<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="getAuthCode.aspx.cs" Inherits="TouristHelp.getAuthCode" %>
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

		<div class="container">
			<div class="d-flex justify-content-center h-100">
				<div class="card">
					<div class="card-header">
						<br>
						<h3 class="text-center"> Google Authenticator QR Code</h3>


					</div>

					<div class="card-body">
							<div class="form-group">
							
								<div class="form-group">
									<label for="password" class="labels">Scan QR code with your phone to save the 2FA into google authenticator</label>
                                  <br />
                                    <label for="password" class="labels">Do <b>NOT</b> share the code with anyone, this is your new code authentication please save it</label>

									<div class="input-group form-group">
										<div class="input-group-prepend">

<%--											<span class="input-group-text"><i class="fas fa-key"></i></span>--%>
										</div>
                                       <%-- <asp:TextBox ID="twofaemailTB"  class="form-control"  runat="server"></asp:TextBox>
									    <asp:TextBox ID="authTestTB" runat="server"></asp:TextBox>--%>
									<%--	<input type="text"  name="twofaemailTB" id="twofaemailTB"  class="form-control" required
											value="">--%>
									</div>



								</div>      
<%--								<button type="submit" formaction="/user/indexVerified"  style="margin-top:20%; background-color:lightgreen" onclick="" class="btn float-right login_btn">Confirm</button>--%>
<%--		    <asp:Button ID="email2FA_Btn" runat="server" Text="Confirm" OnClick="verifyEmail" style="left:100%;" class="btn float-right login_btn"  BackColor="#66FF33" />--%>

                            </div>

                        <div>
<%--                       <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="incorrect input, please try again" OnServerValidate="CustomValidator1_ServerValidate" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>--%>

                            <asp:Image ID="imgQRCode" style="margin-left:30%;" runat="server" />

                        </div>

					</div>

				</div>

			

	
                </form>
</asp:Content>
