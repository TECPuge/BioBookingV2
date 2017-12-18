using BioBookingV2.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioBookingV2
{
    public partial class CreateScreening : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["BioBookingDB"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand comMovie = new SqlCommand("Select Id, Title from Movie", con);
                SqlDataAdapter daMovie = new SqlDataAdapter(comMovie);
                DataSet dsMovie = new DataSet();
                daMovie.Fill(dsMovie);
                MovieDropDownList.DataTextField = dsMovie.Tables[0].Columns["Title"].ToString();
                MovieDropDownList.DataValueField = dsMovie.Tables[0].Columns["Id"].ToString();
                MovieDropDownList.DataSource = dsMovie.Tables[0];
                MovieDropDownList.DataBind();

                SqlCommand comTheater = new SqlCommand("Select Id, Name from Theater", con);
                SqlDataAdapter daTheater = new SqlDataAdapter(comTheater);
                DataSet dsTheater = new DataSet();
                daTheater.Fill(dsTheater);
                TheaterDropDownList.DataTextField = dsTheater.Tables[0].Columns["Name"].ToString();
                TheaterDropDownList.DataValueField = dsTheater.Tables[0].Columns["Id"].ToString();
                TheaterDropDownList.DataSource = dsTheater.Tables[0];
                TheaterDropDownList.DataBind();

            }

        }

        protected void ScreeningCreate_Click(object sender, EventArgs e)
        {


        }
    }
}