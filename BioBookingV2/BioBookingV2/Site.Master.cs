using BioBookingV2.DAL;
using BioBookingV2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BioBookingV2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
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
                if (resourceSingle.Employee)
                {
                    //CreateMovie
                    HtmlGenericControl liCreateMovie = new HtmlGenericControl("LI");
                    navLogin.Controls.Add(liCreateMovie);
                    HtmlGenericControl aCreateMovie = new HtmlGenericControl("A");
                    aCreateMovie.Attributes["href"] = "createmovie";
                    aCreateMovie.InnerText = "Opret film";
                    liCreateMovie.Controls.Add(aCreateMovie);

                    //CreateScreening
                    HtmlGenericControl liCreateScreening = new HtmlGenericControl("LI");
                    navLogin.Controls.Add(liCreateScreening);
                    HtmlGenericControl aCreateScreening = new HtmlGenericControl("A");
                    aCreateScreening.Attributes["href"] = "createscreening";
                    aCreateScreening.InnerText = "Opret filmvisning";
                    liCreateScreening.Controls.Add(aCreateScreening);

                    //ViewScreening
                    HtmlGenericControl liViewScreening = new HtmlGenericControl("LI");
                    navLogin.Controls.Add(liViewScreening);
                    HtmlGenericControl aViewScreening = new HtmlGenericControl("A");
                    aCreateScreening.Attributes["href"] = "ViewReservations";
                    aCreateScreening.InnerText = "Se reservationer";
                    liViewScreening.Controls.Add(aViewScreening);

                }
            }
        }


    }
}