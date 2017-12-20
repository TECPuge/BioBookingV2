<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieReservation.aspx.cs" Inherits="BioBookingV2.MovieReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- change color of seats and remove click event -->
    <script type="text/javascript">

</script>
    <!-- Bootstrap reference direkte fra deres hjemmeside-->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!-- Ready script med jQuery-->
    <script src="https://code.jquery.com/jquery-1.9.1.min.js"></script>

    <div class="Empty_Space"></div>
    <div class="Empty_Space"></div>
    <div class="well well-lg">
        <div class="row">
            <div class="col-sm-4">
                <asp:Image ID="MoviePoster" runat="server" Height="450" Width="300" />
            </div>
            <div class="col-sm-2">
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
            </div>
            <div class="col-sm-6 pull-right">
                <div class="well well-lg black">
                    <asp:Table  class="" runat="server" ID="Reservation"></asp:Table>
                    <div class="TheaterScreen">
                        <div class="screen">
                        </div>
                        <p>Lærred</p>
                    </div>
                </div>
                <asp:Button runat="server" type="submit" class="btn btn-primary btn-lg pull-right" OnClick="ReservationConfirm_Click" Text="Bestil"></asp:Button>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="ChosenSeatString" runat="server" />
    <asp:Label ID="ReservationConfirmed" runat="server"></asp:Label>
    <!-- Script til at vælge sæder-->
    <script type="text/javascript">
        var ChosenSeats = [];
        var table = document.getElementById("MainContent_Reservation");
        if (table != null) {
            for (var i = 0; i < table.rows.length; i++) {
                for (var j = 0; j < table.rows[i].cells.length; j++)
                    table.rows[i].cells[j].onclick = function () {
                        if (!document.getElementById("Seat" + this.id).hasClass("BookedSeat")) {
                            $(document.getElementById("Seat" + this.id)).toggleClass("highlight");
                            if (document.getElementById("Seat" + this.id).hasClass("highlight")) {
                                var cid = $(this).attr('id');
                                ChosenSeats.push(cid);
                            } else {
                                var a = ChosenSeats.indexOf($(this).attr('id'));
                                ChosenSeats.splice(a, 1);
                            }
                        }
                        $(document.getElementById("MainContent_ChosenSeatString")).val(ChosenSeats.join(','));
                    };
            }
        }
        Element.prototype.hasClass = function (className) {
            return this.className && new RegExp("(^|\\s)" + className + "(\\s|$)").test(this.className);
        };
    </script>
</asp:Content>
