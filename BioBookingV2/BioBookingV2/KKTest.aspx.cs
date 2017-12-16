using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioBookingV2.DAL;
using BioBookingV2.DTO;
using System.Reflection;
namespace BioBookingV2
{
    public partial class KKTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlLabel.Text = "Control";
            //SQLConnector con = new SQLConnector();
            //MovieDTO movie1 = new MovieDTO();
            //con.CreateMovie(movie1);
            //MovieDTO movie3 = new MovieDTO()
            //{
            //    Description = "Description Only"
            //};
            //con.CreateMovie(movie3);
            //MovieDTO movie4 = new MovieDTO()
            //{
            //    PosterFileName = "PosterFileName Only"
            //};
            //con.CreateMovie(movie4);
            //MovieDTO movie5 = new MovieDTO()
            //{
            //    Price = 13.37M
            //};
            //con.CreateMovie(movie5);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string strTemp = string.Empty;
            SQLConnector con = new SQLConnector();
            object obj = con.Get(inputDropDownList.Text, Convert.ToInt32(inputTextBox.Text));
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                strTemp += pi.Name + ": " + pi.GetValue(obj) + "<br />";
            }
            TestLabel.Text = strTemp;
        }

        protected void SeedButton_Click(object sender, EventArgs e)
        {
            SQLConnector con = new SQLConnector();
            MovieDTO movie2 = new MovieDTO()
            {
                Title = "Title Only",
                Description = "Description Only",
                PosterFileName = "PosterFileName Only",
                Price = 13.37M
            };
            ResourceDTO resource = new ResourceDTO()
            {
                LoginName = "BoNi",
                LoginPassword = "Kodeord123",
                FirstName = "Bo",
                LastName = "Nielsen",
                Employee = false
            };
            TheaterDTO theater = new TheaterDTO()
            {
                Name = "Sal 1",
                NumberOfSeats = 40
            };
            ScreeningDTO screening = new ScreeningDTO()
            {
                MovieId = 2,
                TheaterId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddHours(3),
                AvailableSeats = 40
            };
            List<MovieDTO> lisMovies = new List<MovieDTO>();
            lisMovies = con.GetAll("Movie").Cast<MovieDTO>().ToList();
            List<ResourceDTO> lisResource = new List<ResourceDTO>();
            lisResource = con.GetAll("Resource").Cast<ResourceDTO>().ToList();
            List<TheaterDTO> lisTheater = new List<TheaterDTO>();
            lisTheater = con.GetAll("Theater").Cast<TheaterDTO>().ToList();
            List<ScreeningDTO> lisScreening = new List<ScreeningDTO>();
            lisScreening = con.GetAll("Screening").Cast<ScreeningDTO>().ToList();
            movie2 = (MovieDTO)con.CreateObject(movie2);
            resource = (ResourceDTO)con.CreateObject(resource);
            theater = (TheaterDTO)con.CreateObject(theater);
            screening = (ScreeningDTO)con.CreateObject(screening);
            MovieDTO movie3 = new MovieDTO()
            {
                Id = 5,
                Title = "UPDATED Title Only",
                Description = "UPDATED Description Only",
                PosterFileName = "UPDATED PosterFileName Only",
                Price = 1113.37M
            };
            con.UpdateObject(movie3);
            TestLabel.Text = "ID for seeded movie: " + movie2.Id.ToString();
        }
    }
}