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
        private string ConfigConnectionString = ConfigurationManager.ConnectionStrings["BioBookingDB"].ConnectionString;

        //Henter alt fra et tablenavn
        public List<object> GetAll(string TableName)
        {
            List<object> LisReturn = new List<object>();
            try
            {
                using (SqlConnection Con = new SqlConnection(ConfigConnectionString))
                {
                    Con.Open();
                    using (SqlCommand Com = new SqlCommand("SELECT * FROM " + TableName, Con))
                    {
                        using (SqlDataReader reader = Com.ExecuteReader())
                        {
                            object ObjReturn = new object();
                            switch (TableName)
                            {
                                case "Movie":
                                    MovieDTO Movie = new MovieDTO();
                                    ObjReturn = Movie;
                                    break;
                                case "Reservation":
                                    ReservationDTO Reservation = new ReservationDTO();
                                    ObjReturn = Reservation;
                                    break;
                                case "Resource":
                                    ResourceDTO Resource = new ResourceDTO();
                                    ObjReturn = Resource;
                                    break;
                                case "Screening":
                                    ScreeningDTO Screening = new ScreeningDTO();
                                    ObjReturn = Screening;
                                    break;
                                case "Seat":
                                    SeatDTO Seat = new SeatDTO();
                                    ObjReturn = Seat;
                                    break;
                                case "Theater":
                                    TheaterDTO Theater = new TheaterDTO();
                                    ObjReturn = Theater;
                                    break;
                                default:
                                    ObjReturn = null;
                                    break;
                            }
                            while (reader.Read())
                            {

                                //Løber igennem properties og sætter property til værdien den finder i rækkens felt med samme kolonnenavn som propertyname
                                foreach (PropertyInfo pi in ObjReturn.GetType().GetProperties())
                                {
                                    pi.SetValue(ObjReturn, reader.GetValue(reader.GetOrdinal(pi.Name)));
                                }
                                LisReturn.Add(ObjReturn);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                LisReturn.Add(Ex);
            }
            return LisReturn;
        }
        //Henter en række fra et tablenavn hvor id findes
        public object Get(string TableName, int Id)
        {
            object ObjReturn = new object();
            switch (TableName)
            {
                case "Movie":
                    MovieDTO Movie = new MovieDTO();
                    ObjReturn = Movie;
                    break;
                case "Reservation":
                    ReservationDTO Reservation = new ReservationDTO();
                    ObjReturn = Reservation;
                    break;
                case "Resource":
                    ResourceDTO Resource = new ResourceDTO();
                    ObjReturn = Resource;
                    break;
                case "Screening":
                    ScreeningDTO Screening = new ScreeningDTO();
                    ObjReturn = Screening;
                    break;
                case "Seat":
                    SeatDTO Seat = new SeatDTO();
                    ObjReturn = Seat;
                    break;
                case "Theater":
                    TheaterDTO Theater = new TheaterDTO();
                    ObjReturn = Theater;
                    break;
                default:
                    ObjReturn = null;
                    break;
            }
            if (ObjReturn != null)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigConnectionString))
                    {
                        con.Open();
                        using (SqlCommand com = new SqlCommand("SELECT * FROM " + TableName + " where id = " + Id.ToString(), con))
                        {
                            using (SqlDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    //Løber igennem properties og sætter property til værdien den finder i rækkens felt med samme kolonnenavn som propertyname
                                    foreach (PropertyInfo pi in ObjReturn.GetType().GetProperties())
                                    {
                                        pi.SetValue(ObjReturn, reader.GetValue(reader.GetOrdinal(pi.Name)));
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
            return ObjReturn;
        }

        public MovieDTO CreateMovie(MovieDTO MovCreate)
        {
            string InsertString = "INSERT INTO Movie (";
            foreach (PropertyInfo pi in MovCreate.GetType().GetProperties())
            {
                if (pi.GetValue(MovCreate) != null && pi.Name != "Id")
                {
                    InsertString += pi.Name + ", ";
                }
            }
            InsertString = InsertString.Substring(0, InsertString.Length - 2);
            InsertString += ") VALUES (";
            foreach (PropertyInfo pi in MovCreate.GetType().GetProperties())
            {
                if (pi.GetValue(MovCreate) != null && pi.Name != "Id")
                {
                    if (pi.PropertyType != "".GetType())
                    {
                        if (pi.PropertyType == typeof(decimal))
                        {
                            InsertString += Convert.ToString(pi.GetValue(MovCreate)).Replace(",",".") + ", "; 
                        }
                        else
                        {
                            InsertString += Convert.ToString(pi.GetValue(MovCreate)) + ", ";
                        }
                    }
                    else
                    {
                        InsertString += "'" + Convert.ToString(pi.GetValue(MovCreate)) + "', "; 
                    }
                }
            }
            InsertString = InsertString.Substring(0, InsertString.Length - 2);
            InsertString += "); SELECT CAST(scope_identity() AS int)";
            try
            {
                MovCreate.Id = Insert(InsertString);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return MovCreate;
        }

        public int GetTableNextId(string TableName)
        {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConfigConnectionString))
                    {
                        con.Open();
                        using (SqlCommand com = new SqlCommand("SELECT CAST(IDENT_CURRENT('" + TableName + "') + 1 AS INT) as NextId", con))
                        {
                            return (Int32)com.ExecuteScalar();
                        }
                    }
                }
                catch (Exception Ex)
                {
                    return 0;
                }
        }

        private int Insert(string CommandText)
        {
            using (SqlConnection con = new SqlConnection(ConfigConnectionString))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(CommandText,con))
                {
                    return (Int32)com.ExecuteScalar();
                }
            }
        }
    }
}