using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioBookingV2.DAL;
using System.Reflection;
namespace BioBookingV2
{
    public partial class KKTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLConnector con = new SQLConnector();
            ControlLabel.Text = "Control";
            TestLabel.Text = con.test();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string strTemp = string.Empty;
            SQLConnector con = new SQLConnector();
            object obj = con.Get(inputDropDownList.Text, Convert.ToInt32(inputTextBox.Text));
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                strTemp += pi.Name + ": " + pi.GetValue(obj) + "<br />";
            }
            TestLabel.Text = strTemp;
        }
    }
}