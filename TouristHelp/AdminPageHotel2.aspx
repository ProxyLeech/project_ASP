<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPageHotel2.aspx.cs" Inherits="TouristHelp.AdminPageHotel2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <table class="table">
            <tr>
                <td class="auto-style1">

                    <p>
                        <asp:Label ID="LblMsgName" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="LblMsgPrice" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="LblMsgRegion" runat="server" Text=""></asp:Label>
                    </p>


                    <p>
                        Hotel Image:
                 <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnUplaod" Text="Upload" runat="server" OnClick="UploadFile" />
                          <asp:Label ID="LbImage" runat="server" Visible="false" Text=''></asp:Label>

                        <asp:Image ID="Image1" Height="100" Width="100" runat="server" />
                    </p>


                    <p>
                        Hotel Name: 
                            <asp:TextBox ID="TbName" runat="server"></asp:TextBox>
                    </p>

                    <p>
                        Hotel Price:
                            <asp:TextBox ID="TbPrice" Text="0" runat="server"></asp:TextBox>
                        &nbsp;
                    </p>



                    <p>
                        Hotel Region:

                                 <asp:DropDownList ID="regionSelect" class="form-control" placeholder="Region" runat="server" AutoPostBack="False">
                                     <asp:ListItem Selected="False" Value="Region"></asp:ListItem>
                                     <asp:ListItem>Central</asp:ListItem>
                                     <asp:ListItem>North</asp:ListItem>
                                     <asp:ListItem>South</asp:ListItem>
                                     <asp:ListItem>West</asp:ListItem>
                                     <asp:ListItem>East</asp:ListItem>

                                 </asp:DropDownList>
                    </p>



                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-default" Style="float: right" Text="Add Hotel" OnClick="BtnAdd_Click" />
                    <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-default" Style="float: right; margin-right: 20px" Text="Go back" OnClick="BtnBack_Click" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
