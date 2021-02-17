<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPageAddAttraction_2.aspx.cs" Inherits="TouristHelp.AdminPageAddAttraction_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <table class="table">
            <tr>
                <td class="auto-style1">
                     <p>
                        Attraction Image:
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnUplaod" Text="Upload" runat="server" OnClick="UploadFile" CausesValidation="False" />&nbsp;&nbsp;
                        <asp:Label ID="LbImage" runat="server" Visible="false" Text=''></asp:Label>
                        <asp:Image ID="Image1" Height="100" Width="100" runat="server" />
                    </p>
                    <p>
                        Attraction Name: 
                            <asp:TextBox ID="TbName" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvName" runat="server" ControlToValidate="TbName" ForeColor="Red">*Please Enter a Name</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        Attraction Description:
                            <asp:TextBox ID="TbDesc" runat="server" Height="64px" TextMode="MultiLine" Width="207px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvDesc" runat="server" ControlToValidate="TbDesc" ForeColor="Red">*Please Enter a Description</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        Attraction Price:
                            <asp:TextBox ID="TbPrice" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvPrice" runat="server" ControlToValidate="TbPrice" ForeColor="Red">*Please Enter a Price</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        Attraction Location:
                        <asp:TextBox ID="TbLocation" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvLocation" runat="server" ControlToValidate="TbLocation" ForeColor="Red">*Please Enter a Location</asp:RequiredFieldValidator>
                    </p>
                    <p>
                       Attraction Date:
                            <asp:TextBox ID="TbDate" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvDate" runat="server" ControlToValidate="TbDate" ForeColor="Red">*Please Enter a Date</asp:RequiredFieldValidator>
                    </p>
                    <p>
                       Attraction Latitude:
                            <asp:TextBox ID="TbLat" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvLat" runat="server" ControlToValidate="TbLat" ForeColor="Red">*Please Fill in this Field</asp:RequiredFieldValidator>
                    </p>
                    <p>
                       Attraction Longitude:
                            <asp:TextBox ID="TbLong" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RfvLong" runat="server" ControlToValidate="TbLong" ForeColor="Red">*Please Fill in this Field</asp:RequiredFieldValidator>
                    </p>
                    <p>
                       Attraction Interest:
                            <asp:DropDownList ID="DdlInterest" runat="server">
                                <asp:ListItem>Food</asp:ListItem>
                                <asp:ListItem>Nature</asp:ListItem>
                                <asp:ListItem>Culture</asp:ListItem>
                                <asp:ListItem>Amusement</asp:ListItem>
                                <asp:ListItem>Shopping</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                       Attraction Type:
                            <asp:DropDownList ID="DdlType" runat="server">
                                <asp:ListItem>Place</asp:ListItem>
                                <asp:ListItem>Deal</asp:ListItem>
                                <asp:ListItem>Event</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p>
                       Attraction Transaction:
                            <asp:DropDownList ID="DdlTran" runat="server">
                                <asp:ListItem>Food Reservation</asp:ListItem>
                                <asp:ListItem>Ticket</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <asp:Button ID="BtnAdd" runat="server" CssClass="btn btn-default" Style="float: right" Text="Add Attraction" OnClick="BtnAdd_Click" />
                    <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-default" Style="float: right; margin-right:20px" Text="Go back" OnClick="BtnBack_Click" CausesValidation="False" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
