<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowScreenings.aspx.cs" Inherits="BioBookingV2.ShowScreenings" %>

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
                <asp:Label ID="staticLabel" Text="Select Movie:" runat="server"></asp:Label>
                    <asp:DropDownList ID="inputDropDownList" runat="server">
                    </asp:DropDownList>
                <asp:Button ID="VisningerButton" runat="server" Text="Vis Visninger" OnClick="VisningerButton_Click" />
            </p>
            <p>************ Visninger ************</p>
            <p><asp:Label ID="VisVisningerLabel" runat="server" /></p>
        </div>  
    </form>
</body>
</html>
