<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BioBookingV2.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            Username</div>
        <p>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
            Password</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:CheckBox ID="chkBoxRememberMe" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Remember me" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
