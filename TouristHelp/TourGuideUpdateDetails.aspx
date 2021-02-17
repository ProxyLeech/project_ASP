<%@ Page Title="" Language="C#" MasterPageFile="~/TourGuideLoggedIn.Master" AutoEventWireup="true" CodeBehind="TourGuideUpdateDetails.aspx.cs" Inherits="TouristHelp.TourGuideUpdateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero-wrap js-fullheight" style="background-image: url('images/bg_1.jpg');">
        <div class="overlay"></div>
        <div class="container">
            <div class="row no-gutters slider-text js-fullheight align-items-center justify-content-center" data-scrollax-parent="true">
                <div class="col-md-9 text-center ftco-animate" data-scrollax=" properties: { translateY: '50%' }">

                    <h1 class="mb-3 bread" data-scrollax="properties: { translateY: '30%', opacity: 1.6 }">Your Information</h1>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <form id="form" runat="server">
        <table class="table">
            <tr>
                <td class="auto-style1">

                    <p>
                        <asp:Label ID="tourguidenameLabel" CssClass="col-1" runat="server" Text="Name:"></asp:Label>
                        <asp:TextBox ID="tourguidenameTextBox" CssClass="col-2" runat="server"></asp:TextBox>

                    </p>

                    <p>
                        <asp:Label ID="tourguidedescriptionLabel" CssClass="col-1" runat="server" Text="Description:"></asp:Label>
                        <asp:TextBox ID="tourguidedescriptionTextBox" CssClass="col-2" runat="server"></asp:TextBox>
                    </p>

                    <p>
                        <asp:Label ID="tourguidelanguagesLabel" CssClass="col-1" runat="server" Text="Languages:"></asp:Label>
                        <asp:TextBox ID="tourguidelanguagesTextBox" CssClass="col-2" runat="server"></asp:TextBox>
                    </p>

                    <p>
                        <asp:Label ID="tourguidecredentialsLabel" CssClass="col-1" runat="server" Text="Credentials:"></asp:Label>
                        <asp:TextBox ID="tourguidecredentialsTextBox" CssClass="col-2" runat="server"></asp:TextBox>

                    </p>



                    <asp:Label ID="tourguideemailLabel" CssClass="col-1" runat="server" Visible="false" Text="Credentials:"></asp:Label>
                    <asp:Label ID="tourguidepasswordLabel" CssClass="col-1" runat="server" Visible="false" Text=""></asp:Label>

                    <asp:Label ID="tourguideidLabel" CssClass="col-1" runat="server" Visible="false" Text="Credentials:"></asp:Label>
                    <asp:Label ID="tourguideuseridLabel" CssClass="col-1" runat="server" Visible="false" Text="Credentials:"></asp:Label>
                    <p>
                        Attraction Image:
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnUplaod" Text="Upload" runat="server" OnClick="UploadFile" CausesValidation="False" />&nbsp;&nbsp;
                        <asp:Label ID="LbImage" runat="server" Visible="false" Text=''></asp:Label>
                        <asp:Image ID="Image1" Height="100" Width="100" runat="server" />
                    </p>
                    <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Update" Width="100px" />
                </td>
            </tr>
        </table>
    </form>



    <style>
        div.menu ul li {
            display: inline-block;
            height: 100%;
            padding: 0 1rem;
            text-align: center;
        }

        div.menu a {
            text-decoration: none;
            position: relative;
            top: 50%;
            margin-top: 100px;
            transform: translateY(-50%);
            display: inline-block;
            vertical-align: middle;
            line-height: normal;
        }




        div.position {
            width: 200px;
            text-align: right;
        }

        .form-group {
            display: inline-block;
            margin-right: 10px;
            float: left;
        }

            .form-group label {
                display: block;
            }


        div.row {
            margin-top: 30px;
        }
    </style>

</asp:Content>
