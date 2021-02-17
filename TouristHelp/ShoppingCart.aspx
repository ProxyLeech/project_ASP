<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="TouristHelp.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }

        .auto-style2 {
            width: 816px;
        }

        .auto-style4 {
            width: 194px;
        }

        .auto-style6 {
            width: 119px;
        }

        .auto-style12 {
            height: 23px;
        }

        .header {
            text-align: center;
        }

        .auto-style13 {
            height: 23px;
            width: 119px;
        }

        .auto-style14 {
            width: 195px;
        }

        .auto-style15 {
            height: 23px;
            width: 116px;
        }

        .auto-style16 {
            height: 23px;
            width: 309px;
        }

        .auto-style17 {
            width: 196px;
        }

        .auto-style18 {
            width: 31%
        }

        .borderline {
            border-bottom: 1px solid #ddd;
        }

        .auto-style19 {
            width: 196px;
            height: 24px;
        }

        .auto-style20 {
            height: 24px;
        }

        .remove-product {
            border: 0;
            padding: 4px 8px;
            background-color: #c66;
            color: #fff;
            font-family: $font-bold;
            font-size: 12px;
            border-radius: 3px;
        }

            .remove-product:hover {
                background-color: #a44;
            }

        .checkout {
            float: right;
            border: 0;
            margin-top: 20px;
            padding: 6px 25px;
            background-color: #6b6;
            color: #fff;
            font-size: 25px;
            border-radius: 3px;
        }

        .checkout:hover {
            background-color: #494;
        }

        .edit {
            float: right;
            border: 0;
            margin-top: 20px;
            padding: 6px 25px;
            background-color: #ff9436;
            color: #000000;
            font-size: 25px;
            border-radius: 3px;
        }

        .edit {
            background-color: #d17524;
        }
        .auto-style23 {
            width: 331px;
        }
        .auto-style24 {
            height: 23px;
            width: 816px;
        }
        .auto-style25 {
            height: 23px;
            width: 331px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <section class="ftco-section">
            <div class="container">
                <div class="container" style="background-color:burlywood">

                <table class="w-100" style="margin-top: 15px;">
                    <tr>
                        <td class="auto-style25"></td>
                        <td class="auto-style24" style="">Product</td>
                        <td class="auto-style16">Item Price</td>
                        <td class="auto-style15">Quantity</td>
                        <td class="auto-style13">Total Price</td>
                        <td class="auto-style12">&nbsp;</td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="auto-style1 borderline">
                                    <asp:Image ID="cartImage" class="img img-2 d-flex justify-content-center align-items-center" Style="height: 200px; width: 250px;"
                                                    ImageUrl='<%# Eval("productImage")%>'
                                                    runat="server" />
                                </td>
                                <td class="auto-style2 borderline">
                                    <div>
                                        <asp:Label ID="lbProdName" runat="server" Font-Bold="True" Text='<%#Eval("productName") %>'></asp:Label>
                                        <asp:Label ID="lbProdId" runat="server" Visible="false" Text='<%#Eval("productId") %>'></asp:Label>
                                    </div>
                                    <div>

                                        <asp:Label ID="lbProdDesc" runat="server" Text='<%#Eval("productDesc") %>'></asp:Label>

                                    </div>
                                </td>
                                <td class="auto-style6 borderline">
                                    <asp:Label ID="lbPrice" runat="server" Text='<%#Eval("productPrice") %>'></asp:Label>
                                </td>
                                <td class="auto-style4 borderline">
                                    <asp:TextBox ID="tbQuantity" runat="server" Height="22px" Width="57px" Text='<%#Eval("productQuantity") %>'></asp:TextBox>
                                </td>
                                <td class="auto-style14 borderline">
                                    <asp:Label ID="lbTotalPrice" runat="server" Text='<%#Eval("productTotalPrice") %>'></asp:Label>
                                </td>
                                <td class="borderline">
                                    <asp:Button ID="btnDel" runat="server" Text="Remove" CssClass="remove-product" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                    </div>
                <br />
                <br />
                <div>
                    <table class="auto-style18" style="float: right;">
                        <tr>
                            <td class="auto-style19">
                                <asp:Label ID="Label1" runat="server" Text="Sub Total:"></asp:Label>
                            </td>
                            <td class="auto-style20">
                                <asp:Label ID="Label4" runat="server" Text="$"></asp:Label>
                                <asp:Label ID="lbSubTotal" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">
                                <asp:Label ID="Label2" runat="server" Text="GST:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="$"></asp:Label>
                                <asp:Label ID="lbGst" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td class="auto-style17">
                                <asp:Label ID="Label7" runat="server" Text="Member Discount:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="$"></asp:Label>
                                <asp:Label ID="discountLbl" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style17">
                                <asp:Label ID="Label3" runat="server" Text="Grand Total:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="$"></asp:Label>
                                <asp:Label ID="lbGrandTotal" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnEdit" runat="server" CssClass="edit" Text="Edit" Style="float: right;" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnPurchase" runat="server" CssClass="checkout" Text="Checkout" Style="float: right; margin-right:20px;" OnClick="btnPurchase_Click" />
                </div>
            </div>
        </section>
    </form>
</asp:Content>
