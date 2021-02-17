<%@ Page Title="" Language="C#" MasterPageFile="~/LoginRegister.Master" AutoEventWireup="true" CodeBehind="AdminModule.aspx.cs" Inherits="TouristHelp.AdminModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
                <style>
.button {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
}
hr.solid {
  border-top: 3px solid #bbb;
}



.divider{
    width:5px;
    height:auto;
    display:inline-block;
}
</style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="signup-content">
                <div class="signup-form">
                    <h2 class="form-title">Admin Controls</h2>
                    <form class="register-form" id="FormRegisterTG" runat="server">
                          <div class="form-group">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="*" ControlToValidate="tbEmail" ForeColor="Red"></asp:RequiredFieldValidator>

                                <asp:TextBox ID="tbEmail" runat="server" placeholder="User Email" TextMode="Email"></asp:TextBox>

                                 <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="form-submit" OnClick="btnSearch_Click" />

                            </div>
                                <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>


                        <div class="form-group">
                          <asp:TextBox ID="TextBoxName" runat="server" placeholder="User Name" ReadOnly="True"></asp:TextBox>
                        </div>
                
                            <div class="form-group">
                            <asp:TextBox ID="TextBoxEmail" runat="server" placeholder="User Email" ReadOnly="True"></asp:TextBox>
                        </div>
            
                           <div class="form-group">
                            <asp:TextBox ID="TextBoxlastloggedin" runat="server" placeholder="User Last Logged In" ReadOnly="True"></asp:TextBox>
                        </div>

                         <div class="form-group">
                            <asp:TextBox ID="TextBoxUserId" runat="server" placeholder="User Id" ReadOnly="True" Visible="False"></asp:TextBox>
                        </div>


                        <asp:Button ID="Button3" runat="server" Text="Notify Inactivity To User" style="width:220px;"  CssClass="form-submit" OnClick="Button3_Click"/>

                               <div>

                            <asp:Button ID="Button1" runat="server" Text="Activate User Account" style="width:195px;"  CssClass="form-submit" OnClick="Button1_Click"/>
                                <div class="divider"/>

                           <asp:Button ID="Button2" runat="server" Text="Deactivate User Account" style="width:195px;"  CssClass="form-submit" OnClick="Button2_Click"/>

                            </div>
                        
                        <div>
                                                <a href="Login.aspx" class="signup-image-link"><u>Back To Login Page</u></a>

                        </div>
                        

                    </form>
                </div>
   
            </div>
        </div>
    </section>
</asp:Content>



