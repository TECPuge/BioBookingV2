

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BioBookingV2.DTO;
using BioBookingV2.DAL;
namespace BioBookingV2
{
    public partial class CreateMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            decimal Price = 0;
            // Todo error handling on decimal (Raise friendly error dialog)
            if (Decimal.TryParse(InputPrice.Value, out Price))
            {
                MovieDTO NewMovie = new MovieDTO
                {
                    Title = InputTitle.Value,
                    Description = InputDescription.Value,
                    PosterFileName = "/NotMadeYet.png",
                    Price = Price
                };

                SQLConnector con = new SQLConnector();

                NewMovie = con.CreateMovie(NewMovie);
            }

        }
    }
}