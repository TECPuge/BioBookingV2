<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateScreening.aspx.cs" Inherits="BioBookingV2.CreateScreening" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div id="CScreeningBody" runat="server" style="padding-top: 20px">
            <asp:Label ID="staticLabel" Text="Vælg Film:" runat="server"></asp:Label>
                <asp:DropDownList ID="MovieDropDownList" runat="server">
                </asp:DropDownList>
            <br />
            <asp:Label ID="Label1" Text="Vælg Sal:" runat="server"></asp:Label>
                <asp:DropDownList ID="TheaterDropDownList" runat="server" AutoPostBack="true"
                    onselectedindexchanged="SelectedIndexChanged">
                </asp:DropDownList>
            <br />
            <asp:Label ID="LabelStartDate" runat="server" Text="Start tidspunkt:"></asp:Label>
                <input id="InputStartDate" type="datetime-local" runat="server" />
                <asp:RequiredFieldValidator ID="CheckStartDate" runat="server" ControlToValidate="InputStartDate"
                    ForeColor="Red" ErrorMessage="Start tidspunkt er påkrævet!"></asp:RequiredFieldValidator>
            <br/>
            <asp:Label ID="LabelEndDate" runat="server" Text="Slut tidspunkt:"></asp:Label>
                <input id="InputEndDate" type="datetime-local" runat="server" />
                <asp:RequiredFieldValidator ID="CheckEndDate" runat="server" ControlToValidate="InputEndDate"
                    ForeColor="Red" ErrorMessage="Slut tidspunkt er påkrævet!"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Seats" runat="server" Text="Antal Sæder:"></asp:Label>
                <input id="InputSeats" type="text" runat="server" />
                <asp:RequiredFieldValidator ID="CheckSeats" runat="server" ControlToValidate="InputSeats"
                    ForeColor="Red" ErrorMessage="Antal sæder er påkrævet"></asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="ScreeningCreate" runat="server" OnClick="ScreeningCreate_Click" Text="Opret filmvisning" />

            <p><asp:Label ID="VisVisningLabel" runat="server" /></p>
            
        </div>
</asp:Content>
