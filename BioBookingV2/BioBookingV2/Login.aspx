<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BioBookingV2.Login1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:TextBox ID="txtUserName" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            Username</div>
        <p>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
            Password</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server"></asp:Label>
        </p>
        <p>
            <asp:CheckBox ID="chkBoxRememberMe" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" Text="Remember me" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
