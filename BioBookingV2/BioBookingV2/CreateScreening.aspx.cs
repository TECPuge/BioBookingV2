using BioBookingV2.DAL;
using BioBookingV2.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioBookingV2
{
    public partial class CreateScreening : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SQLConnector con = new SQLConnector();

            if (!Page.IsPostBack)
            {
                List<MovieDTO> lisMovies = new List<MovieDTO>();
                lisMovies = con.GetAll("Movie").Cast<MovieDTO>().ToList();
                foreach (MovieDTO item in lisMovies)
                {
                    MovieDropDownList.DataTextField = item.Title;
                    MovieDropDownList.DataValueField = Convert.ToString(item.Id);
                }

                List<TheaterDTO> lisTheaters = new List<TheaterDTO>();
                lisTheaters = con.GetAll("Theater").Cast<TheaterDTO>().ToList();
                foreach (TheaterDTO item in lisTheaters)
                {
                    TheaterDropDownList.DataTextField = item.Name;
                    TheaterDropDownList.DataValueField = Convert.ToString(item.Id);
                }

            }

                string SeatsTemp = string.Empty;
                SQLConnector sqlCon = new SQLConnector();
                object obj = sqlCon.Get("Theater", Convert.ToInt32(MovieDropDownList.Text));
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    if (pi.Name == "NumberOfSeats")
                    {
                        SeatsTemp = Convert.ToString(pi.GetValue(obj));
                        Seats.Text = SeatsTemp;
                    }
                }
        }

        protected void ScreeningCreate_Click(object sender, EventArgs e)
        {

            SQLConnector con = new SQLConnector();
            ScreeningDTO newScreening = new ScreeningDTO
            {
                MovieId = Convert.ToInt32(MovieDropDownList.Text),
                TheaterId = Convert.ToInt32(TheaterDropDownList.Text),
                AvailableSeats = Convert.ToInt32(Seats.Text)
            };
            newScreening = (ScreeningDTO)(con.CreateObject(newScreening));

        }
    }
}