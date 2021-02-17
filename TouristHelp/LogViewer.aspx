<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LogViewer.aspx.cs" Inherits="TouristHelp.LogViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <!--Buttons-->
        <br />
        <asp:Button ID="ButtonFilterExpand" runat="server" OnClick="ButtonFilterExpand_Click" Text="Expand Filter" />
        <br />
        <!--Filter Panel-->
        <asp:Panel ID="PanelFilter" runat="server" Visible="False">
            <p>Sort by</p>
            <asp:RadioButtonList ID="RadioButtonListOrder" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">Newest First</asp:ListItem>
                <asp:ListItem Value="1">Oldest First</asp:ListItem>
            </asp:RadioButtonList>
            <p>From User:</p>
            <asp:TextBox ID="TextBoxTarget" runat="server"></asp:TextBox>
            <p>Type:</p>
            <asp:DropDownList ID="DropDownListType" runat="server">
                <asp:ListItem Value="Any">Any</asp:ListItem>
                <asp:ListItem>Login</asp:ListItem>
                <asp:ListItem>Error</asp:ListItem>
                <asp:ListItem>Maintenance</asp:ListItem>
                <asp:ListItem>Others</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<p>Timeframe:</p>
            <asp:TextBox ID="TextBoxDateTime1" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            &nbsp;to&nbsp;<asp:TextBox ID="TextBoxDateTime2" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            &nbsp;<p>
                Keywords:</p>
            <asp:TextBox ID="TextBoxKeyword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonFilterSend" runat="server" OnClick="ButtonFilterSend_Click" Text="Apply Filters" />
            &nbsp;<asp:Button ID="ButtonFilterClear" runat="server" OnClick="ButtonFilterClear_Click" Text="Clear Filters" />
        </asp:Panel>

        <!--Repeater-->
        <asp:Repeater ID="RepeaterLog" runat="server">
            <ItemTemplate>
                <div class="col-sm col-md-6 col-lg-12" style="border-style: solid; border-width: 1px; margin-bottom: 10px">
                    <div class="text p-3">
                        <div class="one">
                            <h3 id="Name">Log No: <%#Eval("Id") %></h3>
                        </div>
                        <h4 id="desc"><%#Eval("Content") %></h4>
                        <hr>
                        <p class="bottom-area d-flex">
                            <span>Type: <%#Eval("Type") %> | </span>&nbsp;<span>User: <%#Eval("Target") %> | </span>&nbsp;<span>Created: <%#Eval("DateTime") %> | </span>
                        </p>
                        
                        <br />
                        <br />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </form>
</asp:Content>