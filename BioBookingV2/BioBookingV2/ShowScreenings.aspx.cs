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

            string MovieId = Request.QueryString["Id"];

            if (!string.IsNullOrEmpty(MovieId))
            {
                SQLConnector con = new SQLConnector();

                List<MovieDTO> listMovies = new List<MovieDTO>();
                listMovies = con.GetAll("Movie").Cast<MovieDTO>().ToList();

                List<ScreeningDTO> listScreening = new List<ScreeningDTO>();
                listScreening = con.GetAll("Screening", "MovieId", MovieId, typeof(int)).Cast<ScreeningDTO>().ToList();

                if (listMovies.Count > 0)
                {
                    foreach (MovieDTO Movie in listMovies)
                    {
                        if (Movie.Id == Convert.ToInt32(MovieId))
                        {
                            //wrapper div for movie
                            HtmlGenericControl MovieWrapperDiv = new HtmlGenericControl("DIV");
                            MovieWrapperDiv.Attributes["class"] = "row";
                            ScreeningBody.Controls.Add(MovieWrapperDiv);

                            //adding div for movie
                            HtmlGenericControl MovieDiv = new HtmlGenericControl("DIV");
                            MovieDiv.Attributes["class"] = "col-md-12";
                            string StringDivId = "div-mov-" + Movie.Id;
                            MovieDiv.Attributes["Id"] = StringDivId;
                            MovieWrapperDiv.Controls.Add(MovieDiv);

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
                            HtmlGenericControl MovieH1Title = new HtmlGenericControl("H1");
                            MovieH1Title.InnerHtml = Movie.Title;
                            DetailDiv.Controls.Add(MovieH1Title);

                            //Adding description for movie in movie detail div
                            HtmlGenericControl Description = new HtmlGenericControl("P");
                            Description.InnerText = Movie.Description;
                            DetailDiv.Controls.Add(Description);

                            HtmlGenericControl LineBreak = new HtmlGenericControl("BR");
                            ScreeningBody.Controls.Add(LineBreak);
                        }
                    }
                }

                //Wrapper div for Screenings
                HtmlGenericControl ScreeningWrapperDiv = new HtmlGenericControl("DIV");
                ScreeningWrapperDiv.Attributes["class"] = "row";
                ScreeningBody.Controls.Add(ScreeningWrapperDiv);

                if (listScreening.Count > 0)
                {
                    //adding div for screenings
                    HtmlGenericControl ScreeningDiv = new HtmlGenericControl("DIV");
                    ScreeningDiv.Attributes["class"] = "col-md-12";
                    string StringDivSId = "div-scr-" + 0;
                    ScreeningDiv.Attributes["Id"] = StringDivSId;
                    ScreeningWrapperDiv.Controls.Add(ScreeningDiv);

                    //Adding div for column 1
                    HtmlGenericControl ScreeningColumn1 = new HtmlGenericControl("DIV");
                    ScreeningColumn1.Attributes["class"] = "col-md-4 class";
                    string StringScreeningsDivId1 = "div-scr-" + 1;
                    ScreeningColumn1.Attributes["Id"] = StringScreeningsDivId1;
                    ScreeningDiv.Controls.Add(ScreeningColumn1);

                    //Adding div for column 2
                    HtmlGenericControl ScreeningColumn2 = new HtmlGenericControl("DIV");
                    ScreeningColumn2.Attributes["class"] = "col-md-4 class";
                    string StringScreeningsDivId2 = "div-scr-" + 2;
                    ScreeningColumn2.Attributes["Id"] = StringScreeningsDivId2;
                    ScreeningDiv.Controls.Add(ScreeningColumn2);

                    //Adding div for column 3
                    HtmlGenericControl ScreeningColumn3 = new HtmlGenericControl("DIV");
                    ScreeningColumn3.Attributes["class"] = "col-md-4 class";
                    string StringScreeningsDivId3 = "div-scr-" + 3;
                    ScreeningColumn3.Attributes["Id"] = StringScreeningsDivId3;
                    ScreeningDiv.Controls.Add(ScreeningColumn3);

                    int intCount = -1;
                    foreach (ScreeningDTO Screening in listScreening)
                    {
                        //Adding start date to columns
                        HtmlGenericControl ScreeningStart = new HtmlGenericControl("A");
                        ScreeningStart.Attributes["href"] = "/moviereservation.aspx?Id=" + Screening.Id;
                        ScreeningStart.InnerHtml = Convert.ToString(Screening.StartDate);

                        HtmlGenericControl LineBreak = new HtmlGenericControl("BR");

                        if (intCount < listScreening.Count / 3)
                        {
                            ScreeningColumn1.Controls.Add(ScreeningStart);
                            ScreeningColumn1.Controls.Add(LineBreak);
                        }
                        else if (intCount < (2 * listScreening.Count) / 3)
                        {
                            ScreeningColumn2.Controls.Add(ScreeningStart);
                            ScreeningColumn2.Controls.Add(LineBreak);
                        }
                        else
                        {
                            ScreeningColumn3.Controls.Add(ScreeningStart);
                            ScreeningColumn3.Controls.Add(LineBreak);
                        }
                        intCount++;
                    }
                }
                else
                {
                    HtmlGenericControl ParagraphForNoScreenings = new HtmlGenericControl("P");
                    ParagraphForNoScreenings.InnerText = "No screenings found.";
                    ScreeningBody.Controls.Add(ParagraphForNoScreenings);
                } 
            }
        }
    }
}

