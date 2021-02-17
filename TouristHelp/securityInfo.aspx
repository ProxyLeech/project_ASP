<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="securityInfo.aspx.cs" Inherits="TouristHelp.securityInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
      <script src="https://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>

    <link rel="stylesheet" type="text/css" href="/Styles/settings.css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>



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



                    <div class="col-md-9  admin-content" id="profile1"/>
                        <div class="panel panel-info" style="margin: 0.5em;"/>
                            <div class="panel-heading">
                                <h3 class="panel-title">Account Info</h3>

                            </div>
                            <div class="panel-body">


                                <div class="col-md-9  admin-content" style="margin-left:4%;" id="profile">
                                    <div class="panel panel-info" style="margin: 0.5em;">

                                        <div class="panel panel-info" style="margin: 1em;">
                                            <div class="panel-heading">

                                                <small id="emailHelp" class="form-text">
                                                   Keep your email up to date so we can recover your account in the
                                                    future!
                                                    <i class="fa fa-warning" style="font-size:18px;color:red"></i>
                                                </small>
                                                <h3 class="panel-title">Email Address</h3>
                                            </div>
                                            <div class="panel-body">
                                                <input type="email" name="email" class="form-control"
                                                    value="{{user.email}}" placeholder={{user.email}} />


                                                <button type="submit" formaction="/verifyEmail"
                                                    style="margin-left:70%;width:30%" class="btn btn-success"
                                                    onclick="">Update
                                                    </a>











                                            </div>
                                        </div>

                                        <div class="panel panel-info" style="margin: 1em;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">New password</h3>


                                            </div>

                                            <div class="panel-body">
                                                <input type="password" name="password2" class="form-control"
                                                    value="{{password2}}" placeholder="New Password">


                                            </div>
                                        </div>

                                        <div class="panel panel-info" style="margin: 1em;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Confirm new password</h3>


                                            </div>

                                            <div class="panel-body">
                                                <input type="password" name="password3" class="form-control"
                                                    value="{{password3}}" placeholder="Confirm your new Password">


                                            </div>
                                        </div>

                                        <div class="panel panel-info" style="margin: 1em;">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">Enter current Password*</h3>

                                            </div>
                                            <input type="password" name="password" class="form-control" required
                                                value="{{password}}"
                                                placeholder="Enter current password for any changes made">



                                        </div>

                                    </div>
                                    <button type="submit" formaction="/user/info" style="margin-left:10%;    "
                                        class="btn btn-success" onclick="">Save
                                        changes</a>
                                </div>
                            </div>
  
</asp:Content>
