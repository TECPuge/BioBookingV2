using BioBookingV2.DAL;
using BioBookingV2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioBookingV2.Utility
{
    public class ValidateEmployee
    {
        public bool IsEmployee(string LoginName)
        {
            bool Employee = false;
            List<ResourceDTO> Resource = new List<ResourceDTO>();
            ResourceDTO resourceSingle = new ResourceDTO();
            SQLConnector con = new SQLConnector();
            Resource = con.GetAll("Resource", "LoginName", LoginName, typeof(string)).Cast<ResourceDTO>().ToList();
            try
            {
                resourceSingle = Resource[0];
            }
            catch (Exception)
            {
                throw;
            }
            Employee = resourceSingle.Employee;
            return Employee;
        }
    }
}