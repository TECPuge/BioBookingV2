using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Reflection;
using BioBookingV2.DAL;
using BioBookingV2.DTO;

namespace BioBookingV2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLConnector Connector = new SQLConnector();
            List<MovieDTO> ListMovies = new List<MovieDTO>();
            ListMovies = Connector.GetAll("Movie").Cast<MovieDTO>().ToList();
            if (ListMovies.Count > 0)
            {
                foreach (MovieDTO movie in ListMovies)
                {
                    //Wrapper div
                    HtmlGenericControl tempWrapperDiv = new HtmlGenericControl("DIV");
                    tempWrapperDiv.Attributes["class"] = "row";
                    BodyDiv.Controls.Add(tempWrapperDiv);

                    //Adding div for movie
                    HtmlGenericControl tempMovieDiv = new HtmlGenericControl("DIV");
                    tempMovieDiv.Attributes["class"] = "col-md-12";
                    string tempStringDivId = "div-mov-" + movie.Id;
                    tempMovieDiv.Attributes["Id"] = tempStringDivId;
                    tempWrapperDiv.Controls.Add(tempMovieDiv);

                    //Adding div for poster
                    HtmlGenericControl tempPosterDiv = new HtmlGenericControl("DIV");
                    tempPosterDiv.Attributes["class"] = "col-md-4 class";
                    string tempStringPosterDivId = "div-poster-" + movie.Id;
                    tempPosterDiv.Attributes["Id"] = tempStringPosterDivId;
                    tempMovieDiv.Controls.Add(tempPosterDiv);

                    //Adding poster img to poster div
                    HtmlGenericControl tempMoviePosterImg = new HtmlGenericControl("IMG");
                    tempMoviePosterImg.Attributes["src"] = "/content/images/" + movie.PosterFileName;
                    tempMoviePosterImg.Attributes["height"] = "450px";
                    tempMoviePosterImg.Attributes["width"] = "300px";
                    string tempStringPosterImgId = "img-poster-" + movie.Id;
                    tempMoviePosterImg.Attributes["Id"] = tempStringPosterImgId;
                    tempPosterDiv.Controls.Add(tempMoviePosterImg);

                    //Adding div for movie details
                    HtmlGenericControl tempDetailDiv = new HtmlGenericControl("DIV");
                    tempDetailDiv.Attributes["class"] = "col-md-8";
                    string tempStringDetailDivId = "div-detail-" + movie.Id;
                    tempDetailDiv.Attributes["Id"] = tempStringDetailDivId;
                    tempMovieDiv.Controls.Add(tempDetailDiv);


                    //Adding label for movie in movie detail div
                    HtmlGenericControl tempH1Title = new HtmlGenericControl("H1");
                    tempH1Title.InnerHtml = movie.Title;
                    tempDetailDiv.Controls.Add(tempH1Title);

                    //Adding description for movie in movie detail div
                    HtmlGenericControl tempDescription = new HtmlGenericControl("P");
                    tempDescription.InnerText = movie.Description;
                    tempDetailDiv.Controls.Add(tempDescription);

                    //Adding link to screenings for movie
                    HtmlGenericControl tempLink = new HtmlGenericControl("A");
                    tempLink.Attributes["href"] = "/showscreenings.aspx?Id=" + movie.Id;
                    tempLink.InnerHtml = "Visninger.";
                    tempDetailDiv.Controls.Add(tempLink);

                    HtmlGenericControl tempLineBreak = new HtmlGenericControl("BR");
                    BodyDiv.Controls.Add(tempLineBreak);
                }
            }

            //string strTemp = "";
            //foreach (PropertyInfo pi in Context.User.Identity.GetType().GetProperties())
            //{
            //    strTemp += pi.Name + ": " + pi.PropertyType + ": " + pi.GetValue(Context.User.Identity) + "<br/>";
            //}
            //testLabel.Text = strTemp;
        }
    }
}