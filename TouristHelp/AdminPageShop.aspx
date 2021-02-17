<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPageShop.aspx.cs" Inherits="TouristHelp.AdminPageShop" %>
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
                        <asp:Label ID="LblMsgQty" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                    <p>
                        <asp:Label ID="LblMsgVoucherType" runat="server" Text=""></asp:Label>
                    </p>

                        <p>
                        <asp:Label ID="LblMsgVoucherCategory" runat="server" Text=""></asp:Label>
                    </p>



                    <div>
                          Hotel Image:
                 <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnUplaod" Text="Upload" runat="server" OnClick="UploadFile" />
                          <asp:Label ID="LbImage" runat="server" Visible="false" Text=''></asp:Label>

                        <asp:Image ID="Image1" Height="100" Width="100" runat="server" />

                        </div>
                    <div>
                        Shop Voucher Name: 
                            <asp:TextBox ID="TbName" runat="server" ></asp:TextBox>
                    </div>

                       <div>
                        Shop Voucher Price:
                            <asp:TextBox ID="TbPrice" Text="0" runat="server"></asp:TextBox>
                    &nbsp;
                    </div>

                    <div>
                        Shop Voucher Type:
                            <asp:TextBox ID="TbVoucherType"  runat="server"></asp:TextBox>
               </div>


                    <div>Shop Voucher Stock:
                            <asp:TextBox ID="TbVoucherStock"  runat="server"></asp:TextBox>

                    </div>
                        

                    <div>
                          Shop Voucher Description::

                        <asp:TextBox ID="TbVoucherDesc" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                 
                  <div>
                                                Shop Voucher Category:


                        <asp:CheckBoxList ID="CBVoucherCategory" RepeatDirection="Horizontal" runat="server" >
                            <asp:ListItem Selected="True">Membership</asp:ListItem>
                            <asp:ListItem>Food</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>

                        </asp:CheckBoxList>

                                               </div>

                  
                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-default" Style="float: right" Text="Add Shop Voucher" OnClick="BtnAdd_Click" />
                    <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-default" Style="float: right; margin-right:20px" Text="Go back" OnClick="BtnBack_Click" />
                </td>
            </tr>
        </table>
    </form>


</asp:Content>
