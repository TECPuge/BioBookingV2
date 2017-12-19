﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowScreenings.aspx.cs" Inherits="BioBookingV2.ShowScreenings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Lister over film visninger "<asp:Label ID="VisningerLabel" runat="Server" /></p>
            <p>
                <asp:Label ID="staticLabel" Text="Vælg Film" runat="server"></asp:Label>
                <asp:DropDownList ID="inputDropDownList" runat="server">
                </asp:DropDownList>
                <asp:Button ID="VisningerButton" runat="server" Text="Vis Visninger" OnClick="VisningerButton_Click" />
            </p>
        </div>
    </form>
    <div id="MovieBody" runat="server" style="padding-top:20px"></div>
    <div id="ScreeningBody" runat="server"></div>
</body>
</html>
