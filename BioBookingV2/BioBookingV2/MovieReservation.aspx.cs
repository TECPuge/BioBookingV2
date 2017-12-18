using System;
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
            int ScreeningId = Convert.ToInt32(Request.QueryString["ScreeningId"]);
            SQLConnector con = new SQLConnector();
            List<MovieScreeningDTO> MovieScreening = new List<MovieScreeningDTO>();
            MovieScreening = con.GetAll("MovieScreening", "ScreeningId", ScreeningId.ToString(), typeof(int)).Cast<MovieScreeningDTO>().ToList();
            MovieScreeningDTO MovieScreeningSingle = new MovieScreeningDTO();
            // Todo
            try
            {
                MovieScreeningSingle = MovieScreening[1];
            }
            catch (Exception)
            {
                return;
            }

            // Initialize page with content from requested movie
            InitPageContent(MovieScreeningSingle);
            // Initialize drop down here as we have the list of moviescreenings
            for (int i = 0; i <= MovieScreening.Count(x => x.AvailableStatusId == 0); i++)
            {
                inputDropDownList.Items.Insert(i, (i + 1).ToString());
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
            int RequestedSeats;
            MovieScreeningDTO MovieScreeningSingle;
            RequestedSeats = Convert.ToInt32(inputDropDownList.SelectedValue);
            SQLConnector con = new SQLConnector();
            List<MovieScreeningDTO> MovieScreening = new List<MovieScreeningDTO>();
            MovieScreening = con.GetAll("MovieScreening", "ScreeningId", Request.QueryString["ScreeningId"], typeof(int)).Cast<MovieScreeningDTO>().ToList();
            try
            {
                MovieScreeningSingle = MovieScreening[0];
            }
            catch (Exception)
            {

                return;
            }
            
            // Insert reservations
            ReservationDTO NewReservation = new ReservationDTO() { ScreeningId = MovieScreeningSingle.ScreeningId, SeatId = null, ResourceId = 1 }; // Todo, få nuværende bruger oprettet
            for (int i = 1; i <= RequestedSeats; i++)
            {
                NewReservation = (ReservationDTO)con.CreateObject(NewReservation);
            }
            // Update Available seats for this screening
            ScreeningDTO Screening = new ScreeningDTO();
            Screening = (ScreeningDTO)con.Get("Screening", MovieScreeningSingle.ScreeningId);
            Screening.AvailableSeats = Screening.AvailableSeats - RequestedSeats;
            Screening = (ScreeningDTO)con.UpdateObject(Screening);

            // TODO 
            // Login - resource Id
            // SeatId - Hent de første ledige sæder og indsæt dem
            // Send Mail til brugeren der har oprettet
        }
    }
}