using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace BioBookingV2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strTemp = "";
            foreach (PropertyInfo pi in Context.User.Identity.GetType().GetProperties())
            {
                strTemp += pi.Name + ": " + pi.PropertyType + ": " + pi.GetValue(Context.User.Identity) + "<br/>";
            }
            testLabel.Text = strTemp;
        }
    }
}