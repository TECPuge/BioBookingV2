<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KKTest.aspx.cs" Inherits="BioBookingV2.KKTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>Control value: "<asp:Label ID="ControlLabel" runat="server" />"</p>
            <p>
                <asp:Label ID="staticLabel1" Text="Select:" runat="server"></asp:Label>
                <asp:DropDownList ID="inputDropDownList" runat="server">
                    <asp:ListItem Value="Movie">Movie</asp:ListItem>
                    <asp:ListItem Value="Reservation">Reservation</asp:ListItem>
                    <asp:ListItem Value="Resource">Resource</asp:ListItem>
                    <asp:ListItem Value="Screening">Screening</asp:ListItem>
                    <asp:ListItem Value="Seat">Seat</asp:ListItem>
                    <asp:ListItem Value="Theater">Theater</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="staticLable2" Text="Id:" runat="server"></asp:Label>
                <asp:TextBox ID="inputTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="SubmitButton" runat="server" Text="Test" OnClick="SubmitButton_Click" />
            </p>
            <p>
                <asp:Button ID="SeedButton" runat="server" Text="Seed Database" OnClick="SeedButton_Click" />
            </p>
            <p>
                <asp:Button ID="MailButton" runat="server" Text="MailTest" OnClick="MailButton_Click" />
            </p>
            <p>********* TESTING AREA BELOW: *********</p>
            <p>
                <asp:Label ID="TestLabel" runat="server" />
            </p>
        </div>
    </form>
</body>
</html>
