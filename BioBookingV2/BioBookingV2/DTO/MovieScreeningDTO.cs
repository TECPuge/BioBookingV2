using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioBookingV2.DTO
{
    public class MovieScreeningDTO
    {
        public int MovieId { get; set; }
        public int ScreeningId { get; set; }
        public int SeatId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public string MovieTitle { get; set; }
        public string MovieDescription { get; set; }
        public string PosterFileName { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? AvailableStatusId { get; set; }
        public string AvailableStatusDescription { get; set; }
    }
}