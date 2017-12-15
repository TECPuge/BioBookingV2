using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using BioBookingV2.DTO;
using System.Data.SqlClient;
using System.Reflection;

namespace BioBookingV2.DAL
{
    public class SQLConnector
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BioBookingDB"].ConnectionString;

        //Henter alt fra et tablenavn
        public List<object> GetAll(string tableName)
        {
            List<object> lisReturn = new List<object>();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("SELECT * FROM " + tableName, con))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            object objReturn = new object();
                            switch (tableName)
                            {
                                case "Movie":
                                    MovieDTO movie = new MovieDTO();
                                    objReturn = movie;
                                    break;
                                case "Reservation":
                                    ReservationDTO reservation = new ReservationDTO();
                                    objReturn = reservation;
                                    break;
                                case "Resource":
                                    ResourceDTO resource = new ResourceDTO();
                                    objReturn = resource;
                                    break;
                                case "Screening":
                                    ScreeningDTO screening = new ScreeningDTO();
                                    objReturn = screening;
                                    break;
                                case "Seat":
                                    SeatDTO seat = new SeatDTO();
                                    objReturn = seat;
                                    break;
                                case "Theater":
                                    TheaterDTO theater = new TheaterDTO();
                                    objReturn = theater;
                                    break;
                                default:
                                    objReturn = null;
                                    break;
                            }
                            while (reader.Read())
                            {
                                
                                //Løber igennem properties og sætter property til værdien den finder i rækkens felt med samme kolonnenavn som propertyname
                                foreach (PropertyInfo pi in objReturn.GetType().GetProperties())
                                {
                                    pi.SetValue(objReturn, reader.GetValue(reader.GetOrdinal(pi.Name)));
                                }
                                lisReturn.Add(objReturn);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                lisReturn.Add(Ex);
            }
            return lisReturn;
        }
        //Henter en række fra et tablenavn hvor id findes
        public object Get(string tableName, int id)
        {
            object objReturn = new object();
            switch (tableName)
            {
                case "Movie":
                    MovieDTO movie = new MovieDTO();
                    objReturn = movie;
                    break;
                case "Reservation":
                    ReservationDTO reservation = new ReservationDTO();
                    objReturn = reservation;
                    break;
                case "Resource":
                    ResourceDTO resource = new ResourceDTO();
                    objReturn = resource;
                    break;
                case "Screening":
                    ScreeningDTO screening = new ScreeningDTO();
                    objReturn = screening;
                    break;
                case "Seat":
                    SeatDTO seat = new SeatDTO();
                    objReturn = seat;
                    break;
                case "Theater":
                    TheaterDTO theater = new TheaterDTO();
                    objReturn = theater;
                    break;
                default:
                    objReturn = null;
                    break;
            }
            if (objReturn != null)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand com = new SqlCommand("SELECT * FROM "+ tableName + " where id = " + id.ToString(), con))
                        {
                            using (SqlDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    //Løber igennem properties og sætter property til værdien den finder i rækkens felt med samme kolonnenavn som propertyname
                                    foreach (PropertyInfo pi in objReturn.GetType().GetProperties())
                                    {
                                        pi.SetValue(objReturn, reader.GetValue(reader.GetOrdinal(pi.Name)));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    return Ex;
                }
            }
            return objReturn;
        }

        public object Create(object ObjCreate)
        {
            string Insert = "INSERT INTO ";
            Insert += ObjCreate
            string Values = " VALUES (";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand())
                    {

                    }
                }
            }
            catch (Exception Ex)
            {
                return Ex;
            }
            return ObjCreate;
        }
    }
}