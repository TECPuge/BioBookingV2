using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioBookingV2.DTO
{
    public class ResourceScreeningDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MovieTitle { get; set; }
        public string TheaterName { get; set; }
        public int SeatNumber { get; set; }
        public int SeatRow { get; set; }
        public DateTime ScreeningStartDate { get; set; }
        public DateTime ScreeningEndDate { get; set; }
        public decimal TicketPrice { get; set; }
    }
}