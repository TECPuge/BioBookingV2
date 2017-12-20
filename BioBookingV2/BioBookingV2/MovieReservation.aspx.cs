﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioBookingV2.DAL;
using BioBookingV2.DTO;
namespace BioBookingV2
{
    public partial class MovieReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ScreeningId = Convert.ToInt32(Request.QueryString["Id"]);
            SQLConnector con = new SQLConnector();
            List<MovieScreeningDTO> MovieScreening = new List<MovieScreeningDTO>();
            MovieScreening = con.GetAll("MovieScreening", "ScreeningId", ScreeningId.ToString(), typeof(int)).Cast<MovieScreeningDTO>().ToList();
            MovieScreeningDTO MovieScreeningSingle = new MovieScreeningDTO();
            try
            {
                MovieScreeningSingle = MovieScreening[1];
            }
            catch (Exception)
            {
                RaiseAlert("Filmen kunne ikke findes - prøv igen");
                return;
            }

            // Initialize page with content from requested movie
            InitPageContent(MovieScreeningSingle);
            //// Initialize drop down here as we have the list of moviescreenings
            //for (int i = 0; i <= MovieScreening.Count(x => x.AvailableStatusId == 0); i++)
            //{
            //    inputDropDownList.Items.Insert(i, (i + 1).ToString());
            //}
            // Draw dynamic html for reservation 
            foreach (var SeatRow in MovieScreening.Select(x => x.SeatRow).Distinct())
            {
                TableRow tr = new TableRow();
                tr.ID = "TableRow" + SeatRow.ToString();
                foreach (var item in MovieScreening.Where(x => x.SeatRow == SeatRow))
                {
                    // Afhængig af item.AvailableStatusID Indsæt <td> som read-only med en klasse der farver elementet rødt
                    TableCell td = new TableCell() { };
                    td.ID = item.SeatId.ToString();
                    if (true)
                    {

                    }
                    td.Text = String.Format("<a href=\"#\"><span Id=" + "SeatMainContent_" + item.SeatId.ToString() + " class=\"glyphicon glyphicon-print TableSeat " + ((item.AvailableStatusId != 0) ? "BookedSeat" : "") +"\"></span></a>");
                    
                    tr.Cells.Add(td);
                }

                Reservation.Rows.Add(tr);
            }
        }
        private void InitPageContent(MovieScreeningDTO MovieScreening)
        {


            MoviePoster.ImageUrl = "/Content/Images/" + MovieScreening.PosterFileName;
            MovieTitle.Text = MovieScreening.MovieTitle;
            MovieStartDate.Text = MovieScreening.StartDate.ToLongDateString();
            MovieEndDate.Text = MovieScreening.EndDate.ToLongDateString();
            MovieAvailableSeat.Text = MovieScreening.AvailableSeats.ToString();

        }

        protected void ReservationConfirm_Click(object sender, EventArgs e)
        {
            // Input checks
            if (String.IsNullOrEmpty(ChosenSeatString.Value))
            {
                RaiseAlert("Minimum et sæde skal vælges.");
                return;
            }
            // Initialize variables
            int ScreeningId = Convert.ToInt32(Request.QueryString["Id"]);
            int UserId = 0;
            List<ResourceDTO> Resource = new List<ResourceDTO>();
            ResourceDTO resourceSingle = new ResourceDTO();
            SQLConnector con = new SQLConnector();
            Resource = con.GetAll("Resource", "LoginName", Context.User.Identity.Name, typeof(string)).Cast<ResourceDTO>().ToList();

            try
            {
                resourceSingle = Resource[0];
            }
            catch (Exception)
            {

                throw;
            }
            UserId = resourceSingle.Id;

            MovieScreeningDTO MovieScreeningSingle = new MovieScreeningDTO();

            List<MovieScreeningDTO> MovieScreening = new List<MovieScreeningDTO>();
            MovieScreening = con.GetAll("MovieScreening", "ScreeningId", ScreeningId.ToString(), typeof(int)).Cast<MovieScreeningDTO>().ToList();
            try
            {
                MovieScreeningSingle = MovieScreening[0];
            }
            catch (Exception)
            {

                return;
            }

            List<String> ConfirmedSeats;
            ConfirmedSeats = ChosenSeatString.Value.Split(',').ToList();

            ReservationDTO Reservation = new ReservationDTO()
            {
                ResourceId = UserId,
                ScreeningId = ScreeningId
            };
            
            // Ensure that other users haven't reserved we're about to insert.
            // Get existing reservations
            List<ReservationDTO> ExistingReservation = new List<ReservationDTO>();
            ExistingReservation = con.GetAll("Reservation", "ScreeningId", ScreeningId.ToString(), typeof(int)).Cast<ReservationDTO>().ToList();
            
            // Only check against ConfirmedSeats if there are existing reservations
            if(ExistingReservation.Count() > 0)
            foreach (var item in ConfirmedSeats)
            {
                if (ExistingReservation.Where(x=> x.SeatId == Convert.ToInt32(item.Substring(12))).Count() > 0)
                {
                        Response.Redirect("~/MovieReservation?ScreeningId=" + ScreeningId.ToString() + "\"");
                        RaiseAlert("Sæderne er ikke længere ledige - prøv igen");
                    return;
                }
            }
            // Opret nye reservationer
            foreach (var item in ConfirmedSeats)
            {
                Reservation.SeatId = Convert.ToInt32(item.Substring(12));
                // Create screening
                con.CreateObject(Reservation);
            }
        }
        public void RaiseAlert(string Message)
        {
            Response.Write("<script>alert('" + Message + "')</script>");
        }
    }
}