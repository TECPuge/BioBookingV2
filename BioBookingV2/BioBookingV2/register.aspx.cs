using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using BioBookingV2.DAL;
using BioBookingV2.DTO;
using System.Data;
using System.Web.Security;

namespace BioBookingV2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Open SQL connection
            SQLConnector con = new SQLConnector();


            string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
            // Create Movie object to insert

            ResourceDTO NewResource = new ResourceDTO

            {

                LoginName = txtUserName.Text,
                LoginPassword = EncryptedPassword,
                FirstName = Firstname.Text,
                LastName = Lastname.Text,
            };
            // Insert new movie into table
            NewResource = (ResourceDTO)(con.CreateObject(NewResource));
            Response.Redirect("default.aspx");
        
        }
    }
}