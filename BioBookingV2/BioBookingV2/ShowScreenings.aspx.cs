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

namespace BioBookingV2
{
    public partial class ShowScreenings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VisningerLabel.Text = "Select Movie";
            SQLConnector con = new SQLConnector();
            if (!Page.IsPostBack)
            {
                //string constr = ConfigurationManager.ConnectionStrings["BioBookingDB"].ConnectionString;
                //SqlConnection con = new SqlConnection(constr);
                //con.Open();

                //SqlCommand com = new SqlCommand("Select Id, Title from Movie", con);
                //SqlDataAdapter da = new SqlDataAdapter(com);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //inputDropDownList.DataTextField = ds.Tables[0].Columns["Title"].ToString();
                //inputDropDownList.DataValueField = ds.Tables[0].Columns["Id"].ToString();
                //inputDropDownList.DataSource = ds.Tables[0];
                //inputDropDownList.DataBind();

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

            List<ScreeningDTO> lisScreening = new List<ScreeningDTO>();
            lisScreening = con.GetAll("Screening", "MovieId", inputDropDownList.Text, typeof(int)).Cast<ScreeningDTO>().ToList();

            foreach (var item in lisScreening)
            {
                 
            }
        }
    }
}