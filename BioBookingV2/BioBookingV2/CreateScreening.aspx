<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateScreening.aspx.cs" Inherits="BioBookingV2.CreateScreening" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="staticLabel" Text="Select Movie:" runat="server"></asp:Label>
                <asp:DropDownList ID="MovieDropDownList" runat="server">
                </asp:DropDownList>
            <br />
            <asp:Label ID="Label1" Text="Select Theater:" runat="server"></asp:Label>
                <asp:DropDownList ID="TheaterDropDownList" runat="server" AutoPostBack="true"
                    onselectedindexchanged="SelectedIndexChanged">
                </asp:DropDownList>
            <br />
            <asp:Label ID="LabelStartDate" runat="server" Text="Start Time:"></asp:Label>
                <input id="InputStartDate" type="datetime-local" runat="server" />
                <asp:RequiredFieldValidator ID="CheckStartDate" runat="server" ControlToValidate="InputStartDate"
                    ForeColor="Red" ErrorMessage="Start date and time are required!"></asp:RequiredFieldValidator>
            <br/>
            <asp:Label ID="LabelEndDate" runat="server" Text="End Time:"></asp:Label>
                <input id="InputEndDate" type="datetime-local" runat="server" />
                <asp:RequiredFieldValidator ID="CheckEndDate" runat="server" ControlToValidate="InputEndDate"
                    ForeColor="Red" ErrorMessage="End date and time are required!"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Seats" runat="server" Text="Number of Seats:"></asp:Label>
                <input id="InputSeats" type="text" runat="server" />
                <asp:RequiredFieldValidator ID="CheckSeats" runat="server" ControlToValidate="InputSeats"
                    ForeColor="Red" ErrorMessage="Number of Seats in the theater are required!"></asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="ScreeningCreate" runat="server" OnClick="ScreeningCreate_Click" Text="Create Screening" />

            <p>↓ Created Screening ↓</p>
            <p><asp:Label ID="VisVisningLabel" runat="server" /></p>
            
        </div>
    </form>
</body>
</html>
