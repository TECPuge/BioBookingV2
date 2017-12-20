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
using BioBookingV2.Utility;

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
            ResourceDTO NewResource = new ResourceDTO
            {

                LoginName = txtUserName.Text,
                LoginPassword = EncryptedPassword,
                FirstName = Firstname.Text,
                LastName = Lastname.Text,
                Email = Email.Text
            };
            // Insert new movie into table

            List<ResourceDTO> ExistingUser = new List<ResourceDTO>();
            ExistingUser = con.GetAll("Resource", "LoginName", NewResource.LoginName, typeof(string)).Cast<ResourceDTO>().ToList();
            if (ExistingUser.Count == 0)
            {
                NewResource = (ResourceDTO)(con.CreateObject(NewResource));
                string strMessage = string.Format("Hej {0},\r\n\r\nDin bruger \"{1}\" er hermed oprettet i vores system! Vi håber du får set mange film hos os!\r\n\r\nMvh.\r\nTEC BioBooking!", NewResource.FirstName, NewResource.LoginName);
                string strSubject = string.Format("Bruger {0} oprettet!", NewResource.LoginName);
                Mailor mailor = new Mailor();
                mailor.SendMail(NewResource.Email, strSubject, strMessage);
                Response.Redirect("default.aspx"); 
            }
            else
            {
                lblMessage.Text = "Login name eksisterer allerede.";
            }
        }
    }
}