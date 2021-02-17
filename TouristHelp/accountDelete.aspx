<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="accountDelete.aspx.cs" Inherits="TouristHelp.accountDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>

    <link rel="stylesheet" type="text/css" href="/Styles/settings.css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:Label ID="Label1" Visible="false" runat="server" Text=""></asp:Label>
   
    
 
        <div class="container"/>
            <div id="menu"/>

                <div class="row"/>

                    <div class="col-md-3">
                        <ul class="nav nav-pills nav-stacked admin-menu">

 <li class="setting"><a href="/securityInfo.aspx">Account Info</a></li>

                            <li class="setting2"><a href="/security2FA.aspx">Security</a></li>


                            <li class="deleteAccount"><a href="/accountDelete.aspx">Deactivate Account</a></li>

                        </ul>
                    </div>



                    <div class="col-md-9  admin-content" id="profile">
                        <div class="panel panel-info" style="margin: 1em;">
                            <div class="panel-heading">
                                <h3 class="panel-title">Delete Your Account</h3>

                            </div>
                            <div class="panel-body" style="margin-left:0;">


                                <div class="col-md-9  admin-content" style="margin-left:5%;" id="profile">
                                    <div class="panel panel-info"
                                        style="margin: 1%;margin-left:2%;margin-right:1%;width:110%;">
                                        <div class="panel-heading">

                                            <h3 class="panel-title">Email Address</h3>
                                            <div class="panel-body">
                                                <input type="email" name="email" class="form-control"
                                                    value="{{user.email}}" placeholder={{user.email}} readonly />
                                            </div>
                                        </div>

                                    </div>


                                    <div class="panel panel-info"  style="margin-left: 2%;width:110%;">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Enter current Password*</h3>

                                        </div>
                                        <input type="password" name="password" class="form-control" required
                                            value="{{password}}" placeholder="Enter current password before deletion">



                                    </div>

                                    <div class="panel panel-info" style="margin-left: 2%;width:110%;">
                                        <div class="panel-heading">
                                            <h3 class="panel-title">Confirm current Password*</h3>

                                        </div>
                                        <input type="password" name="password2" class="form-control" required
                                            value="{{password2}}"
                                            placeholder="Confirm current password before deletion">



                                    </div>

                                </div>
                                <button type="submit" onMouseOver="this.style.color='#fff34f'"
                                    onMouseOut="this.style.color='#ffffff'"
                                    style="margin-left:8%; background-color:red;" class="btn btn-success"
                                    onclick="">Delete Account</a>
                            </div>
   

</asp:Content>
