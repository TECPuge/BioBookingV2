using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioBookingV2.DTO
{
    public class ResourceDTO
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Employee { get; }
    }
}