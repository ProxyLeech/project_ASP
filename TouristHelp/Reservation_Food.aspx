<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Reservation_Food.aspx.cs" Inherits="TouristHelp.Reservation_Food" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" Visible="false" runat="server" Text=""></asp:Label>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <table class="table">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LbImg" runat="server" Visible="false" Text=''></asp:Label>
                    <p>
                        Make Reservation: 
                        <asp:Label runat="server" ID="lbName"></asp:Label>
                    </p>
                    <p>
                        <asp:Label runat="server" ID="lbDesc"></asp:Label>
                    </p>
                    <div class="one-half img" style="background-image: url(images/about.jpg);"></div>
                    <div>
                        <div>At:
                            <asp:Label runat="server" ID="lbPlace"></asp:Label></div>
                        <div>
                            Timing:
                            <asp:TextBox ID="tbDate" runat="server"></asp:TextBox>

                            <ajaxToolkit:PopupControlExtender ID="tbDate_PopupControlExtender" runat="server" BehaviorID="tbDate_PopupControlExtender" DynamicServicePath="" ExtenderControlID="" PopupControlID="Panel1" Position="Bottom" TargetControlID="tbDate">
                            </ajaxToolkit:PopupControlExtender>

                            &nbsp; :&nbsp;
                            <asp:TextBox ID="TbTime" runat="server" TextMode="Time" Width="120px"></asp:TextBox>

                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RfvDate" runat="server" ControlToValidate="tbDate" ForeColor="Red">*Please Input a Date*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RfvTime" runat="server" ControlToValidate="TbTime" ForeColor="Red">*Please Input a Time*</asp:RequiredFieldValidator>

                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged2" Style="background-color:white"></asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                        <div>
                            Pax:
                            <asp:TextBox ID="TbPax" runat="server"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RfvPax" runat="server" ControlToValidate="TbPax" ForeColor="Red">*Please Input a the number of people coming</asp:RequiredFieldValidator>
                        </div>
                        <asp:Button ID="BtnConfirm" runat="server" CssClass="btn btn-default" Style="float: right" Text="Confirm Reservation" OnClick="BtnConfirm_Click" />
                    </div>
                </td>
                <td>
                    <asp:Label ID="LblCustId" runat="server"></asp:Label>
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
            </tr>
        </table>

    </form>
</asp:Content>
