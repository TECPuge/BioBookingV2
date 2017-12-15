using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioBookingV2.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? SeatId { get; set; }
        public int ScreeningId { get; set; }
    }
}