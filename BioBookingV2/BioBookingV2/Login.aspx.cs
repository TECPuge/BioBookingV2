using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using BioBookingV2.DTO;
using BioBookingV2.DAL;
using System.Configuration;
 

namespace BioBookingV2
{
    public partial class Login1 : System.Web.UI.Page
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            
        }
        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
            }
            else
            {
                lblMessage.Text = "Invalid User Name and/or Password";
            }
        }


        private bool AuthenticateUser(string username, string password)
        {
            string CS = ConfigurationManager.ConnectionStrings["BioBookingDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // FormsAuthentication is in System.Web.Security
                string EncryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                // SqlParameter is in System.Data namespace
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", EncryptedPassword);
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);                
                con.Open();
                int ReturnCode = (int)cmd.ExecuteScalar();
                return ReturnCode == 1;
            }
        }
    }
}