using BioBookingV2.DAL;
using BioBookingV2.DTO;
using BioBookingV2.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            ValidateEmployee val = new ValidateEmployee();
            if (!val.IsEmployee(Context.User.Identity.Name))
            {
                Response.Redirect("default.aspx");
            }

            //Create Dynamic drop down lists for Movie and Screening
            SQLConnector con = new SQLConnector();

            if (!Page.IsPostBack)
            {
                List<MovieDTO> lisMovies = new List<MovieDTO>();
                lisMovies = con.GetAll("Movie").Cast<MovieDTO>().ToList();

                MovieDropDownList.DataTextField = "Title";
                MovieDropDownList.DataValueField = "Id";
                MovieDropDownList.DataSource = lisMovies;
                MovieDropDownList.DataBind();

                List<TheaterDTO> lisTheaters = new List<TheaterDTO>();
                lisTheaters = con.GetAll("Theater").Cast<TheaterDTO>().ToList();

                TheaterDropDownList.DataTextField = "Name";
                TheaterDropDownList.DataValueField = "Id";
                TheaterDropDownList.DataSource = lisTheaters;
                TheaterDropDownList.DataBind();

                //Give Number Of Seats textbox value from DB matching the Theater selected in drop down.
                string SeatsTemp = string.Empty;
                SQLConnector sqlCon = new SQLConnector();
                object obj = sqlCon.Get("Theater", Convert.ToInt32(MovieDropDownList.Text));
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    if (pi.Name == "NumberOfSeats")
                    {
                        SeatsTemp = Convert.ToString(pi.GetValue(obj));
                        InputSeats.Value = SeatsTemp;
                    }
                }
            }
        }

        protected void SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update Number of Seats when value is selected in drop down
            string SeatsTemp = string.Empty;
            SQLConnector con = new SQLConnector();
            object obj = con.Get("Theater", Convert.ToInt32(TheaterDropDownList.Text));
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                if (pi.Name == "NumberOfSeats")
                {
                    SeatsTemp = Convert.ToString(pi.GetValue(obj));
                    InputSeats.Value = SeatsTemp;
                }
            }
        }

        protected void ScreeningCreate_Click(object sender, EventArgs e)
        {

            //Create Screening in DB
            SQLConnector con = new SQLConnector();
            ScreeningDTO newScreening = new ScreeningDTO
            {
                MovieId = Convert.ToInt32(MovieDropDownList.Text),
                TheaterId = Convert.ToInt32(TheaterDropDownList.Text),
                StartDate = Convert.ToDateTime(InputStartDate.Value.ToString()),
                EndDate = Convert.ToDateTime(InputEndDate.Value.ToString()),
                AvailableSeats = Convert.ToInt32(InputSeats.Value)
            };
            newScreening = (ScreeningDTO)(con.CreateObject(newScreening));

            //Show the Created Screening on site.
            string strTemp = string.Empty;
            object obj = newScreening;
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                strTemp += pi.Name + ": " + pi.GetValue(obj) + "<br />";
            }
            VisVisningLabel.Text = strTemp;
        }
    }
}