<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieReservation.aspx.cs" Inherits="BioBookingV2.MovieReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Empty_Space"></div>
    <div class="Empty_Space"></div>
    <div class="well well-lg">
        <div class="row">
            <div class="col-sm-4">
                <asp:Image ID="MoviePoster" runat="server" />
            </div>
            <div class="col-sm-8">
                <h2>
                    <asp:Label ID="MovieTitle" runat="server"></asp:Label>
                </h2>
                <p>
                    Start tidspunkt:
                    <asp:Label ID="MovieStartDate" runat="server"></asp:Label>
                </p>
                <p>
                    Slut tidspunkt:
                    <asp:Label ID="MovieEndDate" runat="server"></asp:Label>
                </p>
                <p>
                    Ledige sæder:
                    <asp:Label ID="MovieAvailableSeat" runat="server"></asp:Label>
                </p>
                <p>
                    Vælg antal ønskede Billetter:
                    <asp:DropDownList ID="inputDropDownList" runat="server">
                    </asp:DropDownList><asp:Button ID="ReservationConfirm" runat="server" Text="Bestil" OnClick="ReservationConfirm_Click" />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
