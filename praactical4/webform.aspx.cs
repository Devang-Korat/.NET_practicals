using System;
using System.Web.UI;

namespace practical4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string events = "";

                if (chkQuiz.Checked)
                    events += "Technical Quiz, ";

                if (chkHackathon.Checked)
                    events += "Hackathon, ";

                if (chkCultural.Checked)
                    events += "Cultural Event, ";

                if (chkSports.Checked)
                    events += "Sports Event";

                lblResult.Text =
                    "Student Name: " + txtName.Text + "<br/>" +
                    "Enrollment No: " + txtEnrollment.Text + "<br/>" +
                    "Class: " + txtClass.Text + "<br/>" +
                    "Email: " + txtEmail.Text + "<br/>" +
                    "Mobile No: " + txtMobile.Text + "<br/>" +
                    "Gender: " + rblGender.SelectedValue + "<br/>" +
                    "Selected Events: " + events;

                pnlResult.Visible = true;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtEnrollment.Text = "";
            txtClass.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";

            rblGender.ClearSelection();

            chkQuiz.Checked = false;
            chkHackathon.Checked = false;
            chkCultural.Checked = false;
            chkSports.Checked = false;

            pnlResult.Visible = false;
        }
        protected void cvEvents_ServerValidate(
            object source,
            System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (chkQuiz.Checked ||
                chkHackathon.Checked ||
                chkCultural.Checked ||
                chkSports.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}
