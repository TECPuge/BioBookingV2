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
        public List<object> GetAll(string TableName, string ColumnToCheckName = null, string ValueToMatch = null, Type Type = null)
        {
            List<object> LisReturn = new List<object>();
            string FilterString = string.Empty;
            if (ColumnToCheckName != null && ValueToMatch != null && Type != null)
            {
                if (Type == typeof(decimal))
                {
                    FilterString = (" WHERE " + ColumnToCheckName + " = " + ValueToMatch.Replace(",", "."));
                }
                else if (Type == typeof(string))
                {
                    FilterString = (" WHERE " + ColumnToCheckName + " = '" + ValueToMatch + "'");
                }
                else if (Type == typeof(bool))
                {
                    FilterString = (" WHERE " + ColumnToCheckName + " = " + (Convert.ToBoolean(ValueToMatch) ? 1 : 0));
                }
                else if (Type == typeof(DateTime))
                {
                    FilterString = (" WHERE " + ColumnToCheckName + " = '" + Convert.ToDateTime(ValueToMatch).ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "'");
                }
                else if (Type == typeof(int))
                {
                    FilterString = (" WHERE " + ColumnToCheckName + " = " + ValueToMatch);
                }
            }
            try
            {
                using (SqlConnection Con = new SqlConnection(ConfigConnectionString))
                {
                    Con.Open();
                    string CommandString = "SELECT * FROM " + TableName + FilterString;
                    using (SqlCommand Com = new SqlCommand(CommandString, Con))
                    {
                        using (SqlDataReader reader = Com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bool Skip = false;
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
                                    case "MovieScreening":
                                        MovieScreeningDTO MovieScreening = new MovieScreeningDTO();
                                        ObjReturn = MovieScreening;
                                        break;
                                    default:
                                        ObjReturn = null;
                                        Skip = true;
                                        break;
                                }
                                if (!Skip)
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
                case "MovieScreening":
                    MovieScreeningDTO MovieScreening = new MovieScreeningDTO();
                    ObjReturn = MovieScreening;
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

        public object UpdateObject(object ObjReturn)
        {
            //Find table navn fra objecttype
            string TableName = string.Empty;
            Type ObjectType = ObjReturn.GetType();
            if (ObjectType == typeof(MovieDTO))
            {
                TableName = "Movie";
            }
            else if (ObjectType == typeof(ReservationDTO))
            {
                TableName = "Reservation";

            }
            else if (ObjectType == typeof(ResourceDTO))
            {
                TableName = "Resource";
            }
            else if (ObjectType == typeof(ScreeningDTO))
            {

                TableName = "Screening";
            }
            else if (ObjectType == typeof(SeatDTO))
            {
                TableName = "Seat";
            }
            else if (ObjectType == typeof(TheaterDTO))
            {
                TableName = "Theater";
            }
            //Genererer kolonnenavne og values baseret på DTO's property types
            string InsertString = "UPDATE " + TableName + " SET ";
            foreach (PropertyInfo pi in ObjReturn.GetType().GetProperties())
            {
                if (pi.GetValue(ObjReturn) != null && pi.Name != "Id")
                {
                    InsertString += pi.Name + " = ";
                    if (pi.PropertyType == typeof(decimal))
                    {
                        InsertString += Convert.ToString(pi.GetValue(ObjReturn)).Replace(",", ".") + ", ";
                    }
                    else if (pi.PropertyType == typeof(string))
                    {
                        InsertString += "'" + Convert.ToString(pi.GetValue(ObjReturn)) + "', ";
                    }
                    else if (pi.PropertyType == typeof(bool))
                    {
                        InsertString += Convert.ToString(((bool)pi.GetValue(ObjReturn) ? 1 : 0)) + ", ";
                    }
                    else if (pi.PropertyType == typeof(DateTime))
                    {
                        InsertString += "'" + ((DateTime)pi.GetValue(ObjReturn)).ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "', ";
                    }
                    else
                    {
                        InsertString += Convert.ToString(pi.GetValue(ObjReturn)) + ", ";
                    }
                }
            }
            InsertString = InsertString.Substring(0, InsertString.Length - 2);
            InsertString += " WHERE Id = " + ObjReturn.GetType().GetProperties().ToList().FirstOrDefault(p => p.Name == "Id").GetValue(ObjReturn);
            //Updater række i databasen
            try
            {
                Insert(InsertString);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ObjReturn;
        }

        public object CreateObject(object ObjReturn)
        {
            //Find table navn fra objecttype
            string TableName = string.Empty;
            Type ObjectType = ObjReturn.GetType();
            if (ObjectType == typeof(MovieDTO))
            {
                TableName = "Movie";
            }
            else if (ObjectType == typeof(ReservationDTO))
            {
                TableName = "Reservation";

            }
            else if (ObjectType == typeof(ResourceDTO))
            {
                TableName = "Resource";
            }
            else if (ObjectType == typeof(ScreeningDTO))
            {

                TableName = "Screening";
            }
            else if (ObjectType == typeof(SeatDTO))
            {
                TableName = "Seat";
            }
            else if (ObjectType == typeof(TheaterDTO))
            {
                TableName = "Theater";
            }
            //Genererer kolonnenavne og values baseret på DTO's property types
            string InsertString = "INSERT INTO " + TableName + "(";
            foreach (PropertyInfo pi in ObjReturn.GetType().GetProperties())
            {
                if (pi.GetValue(ObjReturn) != null && pi.Name != "Id")
                {
                    InsertString += pi.Name + ", ";
                }
            }
            InsertString = InsertString.Substring(0, InsertString.Length - 2);
            InsertString += ") VALUES (";
            foreach (PropertyInfo pi in ObjReturn.GetType().GetProperties())
            {
                if (pi.GetValue(ObjReturn) != null && pi.Name != "Id")
                {
                    if (pi.PropertyType == typeof(decimal))
                    {
                        InsertString += Convert.ToString(pi.GetValue(ObjReturn)).Replace(",", ".") + ", ";
                    }
                    else if (pi.PropertyType == typeof(string))
                    {
                        InsertString += "'" + Convert.ToString(pi.GetValue(ObjReturn)) + "', ";
                    }
                    else if (pi.PropertyType == typeof(bool))
                    {
                        InsertString += Convert.ToString(((bool)pi.GetValue(ObjReturn) ? 1 : 0)) + ", ";
                    }
                    else if (pi.PropertyType == typeof(DateTime))
                    {
                        InsertString += "'" + ((DateTime)pi.GetValue(ObjReturn)).ToString("yyyy-MM-dd HH:mm:ss.fffffff") + "', ";
                    }
                    else
                    {
                        InsertString += Convert.ToString(pi.GetValue(ObjReturn)) + ", ";
                    }
                }
            }
            InsertString = InsertString.Substring(0, InsertString.Length - 2);
            InsertString += "); SELECT CAST(scope_identity() AS int)";
            //Sætter Id værdi på objectet ved at indsætte i DB
            try
            {
                ObjReturn.GetType().GetProperties().ToList().FirstOrDefault(p => p.Name == "Id").SetValue(ObjReturn, Insert(InsertString));
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ObjReturn;
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
                using (SqlCommand com = new SqlCommand(CommandText, con))
                {
                    return Convert.ToInt32(com.ExecuteScalar());
                }
            }
        }
    }
}