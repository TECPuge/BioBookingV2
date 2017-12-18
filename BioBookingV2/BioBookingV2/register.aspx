<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BioBookingV2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div style="font-family:Arial">
<table style="border: 1px solid black">
    <tr>
        <td colspan="2">
            <b>User Registration</b>
        </td>
    </tr>
    <tr>
        <td>
            Login name</td>    
        <td>
            :<asp:TextBox ID="txtUserName" runat="server" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername0" 
            runat="server" ErrorMessage="User Name required" Text="*"
            ControlToValidate="txtUserName" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </td>    
    </tr>
    <tr>
        <td class="auto-style1">
            First name</td>    
        <td class="auto-style1">
            :<asp:TextBox ID="Firstname" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername1" 
            runat="server" ErrorMessage="User Name required" Text="*"
            ControlToValidate="txtUserName" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </td>    
    </tr>
    <tr>
        <td>
            Last name</td>    
        <td>
            :<asp:TextBox ID="Lastname" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername" 
            runat="server" ErrorMessage="User Name required" Text="*"
            ControlToValidate="txtUserName" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </td>    
    </tr>
    <tr>
        <td>
            Password
        </td>    
        <td>
            :<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" OnTextChanged="txtPassword_TextChanged">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" 
            runat="server" ErrorMessage="Password required" Text="*"
            ControlToValidate="txtPassword" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </td>    
    </tr>
    <tr>
        <td>
            Confirm Password
        </td>    
        <td>
            :<asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" OnTextChanged="txtConfirmPassword_TextChanged">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" 
            runat="server" ErrorMessage="Confirm Password required" Text="*"
            ControlToValidate="txtConfirmPassword" ForeColor="Red" 
            Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidatorPassword" runat="server" 
            ErrorMessage="Password and Confirm Password must match"
            ControlToValidate="txtConfirmPassword" ForeColor="Red" 
            ControlToCompare="txtPassword" Display="Dynamic"
            Type="String" Operator="Equal" Text="*">
            </asp:CompareValidator>
        </td>    
    </tr>
    <tr>
        <td>
            &nbsp;</td>    
        <td>
            &nbsp;</td>    
    </tr>
    <tr>
        <td>
                   
        </td>    
        <td>
            <asp:Button ID="btnRegister" runat="server" Text="Register" 
            onclick="btnRegister_Click"/>
        </td>    
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red">
            </asp:Label>
        </td>    
    </tr>
    <tr>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
        </td>    
    </tr>
</table>
</div>
        </div>
    </form>
</body>
</html>
