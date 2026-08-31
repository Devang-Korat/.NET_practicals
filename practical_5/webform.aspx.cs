using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practical5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectDt = Calendar1.SelectedDate;
            select_date.Text = "You have selected" + selectDt.ToString("dd-MM-yyyy");

            Session["leaveDate"] = selectDt;
        }

        protected void apply_leave(object sender, EventArgs e)
        {
            Response.Redirect("leave_app.aspx");
        }
    }
}
