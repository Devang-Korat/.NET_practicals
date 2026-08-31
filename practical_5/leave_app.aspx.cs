using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace practical5
{
    public partial class leave_app : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["EmpName"] != null)
                {
                    TextBox1.Text = Request.Cookies["EmpName"].Value;
                }

                if (Session["leaveDate"] != null)
                {
                    DateTime lvDate = (DateTime)Session["leaveDate"];
                    lblleaveDate.Text = lvDate.ToString("dd-MM-yyyy");
                }
                else
                {
                    lblleaveDate.Text = "No Date Selected.........";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string empnm = TextBox1.Text;
            string leavetype = DropDownList2.SelectedValue;
            string reason = TextBox2.Text;

            Session["empnm"] = empnm;
            Session["leavetype"] = leavetype;
            Session["reason"] = reason;

            if (CheckBox1.Checked)
            {
                Response.Cookies["EmpName"].Value = empnm;
                Response.Cookies["EmpName"].Expires = DateTime.Now.AddDays(7);
            }

            lblmsg.Text = "Leave application submitted successfully.";
            lblmsg.Text += "<br/><br/>" +
                           "<b>Leave Application Details</b><br/>" +
                           "Employee Name: " + empnm + "<br/>" +
                           "Leave Type: " + leavetype + "<br/>" +
                           "Reason: " + reason;
        }
    }
}
