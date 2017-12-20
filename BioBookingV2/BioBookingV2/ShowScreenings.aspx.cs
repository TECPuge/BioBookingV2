using BioBookingV2.DAL;
using BioBookingV2.DTO;
using System;

using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace BioBookingV2
{
    public partial class ShowScreenings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisningerLabel.Text = "Vælg Film";
            SQLConnector con = new SQLConnector();
            if (!Page.IsPostBack)
            {

                List<MovieDTO> lisMovies = new List<MovieDTO>();
                lisMovies = con.GetAll("Movie").Cast<MovieDTO>().ToList();

                inputDropDownList.DataTextField = "Title";
                inputDropDownList.DataValueField = "Id";
                inputDropDownList.DataSource = lisMovies;
                inputDropDownList.DataBind();

            }
        }

        protected void VisningerButton_Click(object sender, EventArgs e)
        {
            SQLConnector con = new SQLConnector();

            List<MovieDTO> listMovies = new List<MovieDTO>();
            listMovies = con.GetAll("Movie").Cast<MovieDTO>().ToList();

            List<ScreeningDTO> listScreening = new List<ScreeningDTO>();
            listScreening = con.GetAll("Screening", "MovieId", inputDropDownList.Text, typeof(int)).Cast<ScreeningDTO>().ToList();

            if (listMovies.Count > 0)
            {
                foreach (MovieDTO Movie in listMovies)
                {
                    if (Movie.Id == Convert.ToInt32(inputDropDownList.Text))
                    {
                        //wrapper div
                        HtmlGenericControl WrapperDiv = new HtmlGenericControl("DIV");
                        WrapperDiv.Attributes["class"] = "row";
                        MovieBody.Controls.Add(WrapperDiv);

                        //adding div for movie
                        HtmlGenericControl MovieDiv = new HtmlGenericControl("DIV");
                        MovieDiv.Attributes["class"] = "col-md-12";
                        string StringDivId = "div-mov-" + Movie.Id;
                        MovieDiv.Attributes["Id"] = StringDivId;
                        WrapperDiv.Controls.Add(MovieDiv);

                        //Adding div for poster
                        HtmlGenericControl PosterDiv = new HtmlGenericControl("DIV");
                        PosterDiv.Attributes["class"] = "col-md-4 class";
                        string StringPosterDivId = "div-poster-" + Movie.Id;
                        PosterDiv.Attributes["Id"] = StringPosterDivId;
                        MovieDiv.Controls.Add(PosterDiv);

                        //Adding poster img to poster div
                        HtmlGenericControl MoviePosterImg = new HtmlGenericControl("IMG");
                        MoviePosterImg.Attributes["src"] = "/content/images/" + Movie.PosterFileName;
                        MoviePosterImg.Attributes["height"] = "450px";
                        MoviePosterImg.Attributes["width"] = "300px";
                        string StringPosterImgId = "img-poster-" + Movie.Id;
                        MoviePosterImg.Attributes["Id"] = StringPosterImgId;
                        PosterDiv.Controls.Add(MoviePosterImg);

                        //Adding div for movie details
                        HtmlGenericControl DetailDiv = new HtmlGenericControl("DIV");
                        DetailDiv.Attributes["class"] = "col-md-8";
                        string StringDetailDivId = "div-detail-" + Movie.Id;
                        DetailDiv.Attributes["Id"] = StringDetailDivId;
                        MovieDiv.Controls.Add(DetailDiv);

                        //Adding Label for movie in movie detail div
                        HtmlGenericControl H1Title = new HtmlGenericControl("H1");
                        H1Title.InnerHtml = Movie.Title;
                        DetailDiv.Controls.Add(H1Title);

                        //Adding description for movie in movie detail div
                        HtmlGenericControl Description = new HtmlGenericControl("P");
                        Description.InnerText = Movie.Description;
                        DetailDiv.Controls.Add(Description);

                        HtmlGenericControl LineBreak = new HtmlGenericControl("BR");
                        MovieBody.Controls.Add(LineBreak);

                    }
                }
            }

            if (listScreening.Count > 0)
            {
                foreach (ScreeningDTO Screening in listScreening)
                {



                }
            }

        }
    }
}

        