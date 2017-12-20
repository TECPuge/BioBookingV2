using BioBookingV2.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BioBookingV2.DTO;
using BioBookingV2.DAL;
using System.Web.UI.HtmlControls;
using System.Reflection;

namespace BioBookingV2
{
    public partial class ViewReservations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateEmployee val = new ValidateEmployee();
            if (!val.IsEmployee(Context.User.Identity.Name))
            {
                Response.Redirect("default.aspx");
            }
            SQLConnector con = new SQLConnector();
            List<ResourceScreeningDTO> lisResScre = new List<ResourceScreeningDTO>();
            lisResScre = con.GetAll("ResourceScreening").Cast<ResourceScreeningDTO>().ToList();
            //Lav table
            HtmlGenericControl table = new HtmlGenericControl("TABLE");
            table.Attributes["class"] = "table table-hover";
            BodyDiv.Controls.Add(table);

            //Lav header
            ResourceScreeningDTO dummy = new ResourceScreeningDTO();
            TableRow HeaderRow = new TableRow();
            foreach (PropertyInfo pi in dummy.GetType().GetProperties())
            {
                TableCell HeaderCell = new TableCell
                {
                    Text = pi.Name
                };
                HeaderRow.Cells.Add(HeaderCell);
            }
            Reservation.Rows.Add(HeaderRow);

            foreach (ResourceScreeningDTO lisRow in lisResScre)
            {
                TableRow CurrentRow = new TableRow();
                TableCell FirstCell = new TableCell
                {
                    Text = lisRow.FirstName
                };
                CurrentRow.Cells.Add(FirstCell);
                foreach (PropertyInfo pi in lisRow.GetType().GetProperties())
                {
                    if (pi.Name != "FirstName")
                    {
                        TableCell CurrentCell = new TableCell
                        {
                            Text = Convert.ToString(pi.GetValue(lisRow))
                        };
                        CurrentRow.Cells.Add(CurrentCell);
                    }
                }
                Reservation.Rows.Add(CurrentRow);
            }
        }
    }
}