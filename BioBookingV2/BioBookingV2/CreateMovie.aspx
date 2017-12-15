<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMovie.aspx.cs" Inherits="BioBookingV2.CreateMovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="LabelTitle" runat="server" Text="Indtast film titel:"></asp:Label>
        <input id="InputTitle" type="text" runat="server"/>
        <asp:RequiredFieldValidator ID="CheckTitle" runat="server" ControlToValidate="InputTitle" ForeColor="Red" ErrorMessage="Film titel skal udfyldes!"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="LabelDescription" runat="server" Text="Indtast filmbeskrivelse:"></asp:Label>
        <input id="InputDescription" type="text" runat="server"/>
        <asp:RequiredFieldValidator ID="CheckDescription" runat="server" ControlToValidate="InputDescription" ForeColor="Red" ErrorMessage="Film beskrivelse skal udfyldes!"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="LabelPrice" runat="server" Text="Indtast billetpris:"></asp:Label>
        <input id="InputPrice" type="text" runat="server"/>
        <asp:RequiredFieldValidator ID="CheckPrice" runat="server" ControlToValidate="InputPrice" ForeColor="Red" ErrorMessage="Billetpris skal udfyldes!"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="LabelPoster" runat="server" Text="Upload billede:"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br/>
        
        <asp:Button ID="ButtonCreate" runat="server" OnClick="ButtonCreate_Click" Text="Opret film" />
        
        <br />
    </form>
    </body>
</html>
