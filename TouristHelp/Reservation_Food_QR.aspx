<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Reservation_Food_QR.aspx.cs" Inherits="TouristHelp.Reservation_Food_QR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <table class="table">
            <tr>
                <td class="auto-style1">
                    <p>
                        &nbsp;Reservation: 
                        <asp:Label runat="server" ID="lbName"></asp:Label>
                    </p>
                    <div class="one-half img" style="background-image: url(images/about.jpg);"></div>
                    <div>
                        <div>At:
                            <asp:Label runat="server" ID="lbPlace"></asp:Label></div>
                        <div>
                            Timing:
                            <asp:Label runat="server" ID="lbTiming"></asp:Label>

                            <br />
                        </div>
                        <div>
                            Pax:
                            &nbsp;<asp:Label runat="server" ID="lbPax"></asp:Label>
                        </div>
                        <asp:Button ID="BtnConfirm" runat="server" CssClass="btn btn-default" Style="float: right" Text="Cancel Reservation" OnClick="BtnConfirm_Click" />
                    </div>
                </td>
                <td>
                    <asp:Label ID="LblCustId" runat="server">test</asp:Label>
                    <p style="font-size: 20px; font-weight: bold">How to use:</p>
                    <p>- A QR Code will be assigned to your account </p>
                    <p>- Present the QR Code to the restraunt staff to be seated</p>
                </td>
            </tr>
            <tr style="border-top-style: solid">
                <td>
                    <p style="font-size: 20px; font-weight: bold">Terms and conditions:</p>
                    <p>- Restraunt reserves the right to revoke reservations</p>
                    <p>- Reservation availability may vary</p>
                </td>
                <td>
                    <p style="font-size: 20px; font-weight: bold">Scan the QR Code to claim ticket</p>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>

    </form>
</asp:Content>
