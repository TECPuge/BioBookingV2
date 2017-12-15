using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioBookingV2.DTO
{
    public class SeatDTO
    {
        public int Id { get; set; }
        public int TheaterId { get; set; }
        public int SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public bool Blocked { get; set; }
    }
}