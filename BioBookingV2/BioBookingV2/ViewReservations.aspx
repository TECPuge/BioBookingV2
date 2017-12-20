<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReservations.aspx.cs" Inherits="BioBookingV2.ViewReservations" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="BodyDiv" runat="server" style="padding-top: 20px">
        <asp:Table runat="server" ID="Reservation" class="table table-hover"></asp:Table>
    </div>
</asp:Content>

