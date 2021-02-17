<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservation_Food_Confirmed.aspx.cs" Inherits="TouristHelp.Reservation_Food_Confirmed1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: 'Poppins', Arial, sans-serif;">
    <!-- fix font maybe -->
    <form id="form1" runat="server">
        <div style="text-align: center">
            <header>
            <asp:Button ID="ButtonBack" runat="server" Text="Go Back" Style="float:left" OnClick="ButtonBack_Click"/>
            </header>
            <br />
            <br />
            <br />
            <br />
            <br />
            <h1 style="color: green;">Reservation Confirmed</h1>
            <br />
            <asp:Label runat="server" ID="lbName"></asp:Label>
            <p>
                At:
            <asp:Label runat="server" ID="lbPlace"></asp:Label>
            </p>
            <asp:Label runat="server" ID="lbDateTime"></asp:Label>
            <br />
            <p><asp:Label runat="server" ID="lbPax"></asp:Label> Pax</p>
            
        </div>
    </form>
</body>
</html>
