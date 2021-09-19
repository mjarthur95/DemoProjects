using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLDR_Capstone
{
    public partial class RegistrationQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			///change the values of the Registration requested from int
			///to Root or Admin
			foreach (GridViewRow row in registrationGridView.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					if (row.Cells[3].Text.Equals("1"))
                    {
						row.Cells[3].Text = "Administrator";
                    }
					else if (row.Cells[3].Text.Equals("2"))
                    {
						row.Cells[3].Text = "Root";
                    }
				}
			}
		}

        protected void regisQueueBtn_Click(object sender, EventArgs e)
        {
			//List of strings to store selected usernames
			List<String> registrationQueue = new List<String>();

			//Grab Student from Session
			Student student = Session["Student"] as Student;

			if (student == null) student = new Student();

			//Add usernames to the list
			foreach (GridViewRow row in registrationGridView.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						registrationQueue.Add(row.Cells[1].Text);
					}
				}
			}

			//connect to database
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);

			//loop over the strings in the List
			foreach (String username in registrationQueue)
			{
				//set the value of authorized in Users to true
				SqlCommand command = new SqlCommand("UPDATE Users SET authorized = @authorized WHERE username = @username", conn);

				command.Parameters.AddWithValue("@username", username);
				command.Parameters.AddWithValue("@authorized", 1);

				conn.Open();
				command.ExecuteNonQuery();
				conn.Close();

				//get the user's email
				command = new SqlCommand("SELECT email FROM Users WHERE username = @username", conn);
				command.Parameters.AddWithValue("@username", username);

				conn.Open();
				string to = (string) command.ExecuteScalar(); //To address  
				conn.Close();

				//send the user an email telling them they can log in
				string from = "scheduleplannerdonotreply@gmail.com"; //From address   
				MailMessage message = new MailMessage(from, to);
				String mailbody = "Your account has now been verified. You may now login to the Schedule Planner.";

				message.Subject = "Registration Verification";
				message.Body = mailbody;
				message.BodyEncoding = Encoding.UTF8;
				message.IsBodyHtml = true;
				SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
				System.Net.NetworkCredential basicCredential1 = new
				System.Net.NetworkCredential("scheduleplannerdonotreply@gmail.com", "TLDRCapstone0=");
				client.EnableSsl = true;
				client.UseDefaultCredentials = false;
				client.Credentials = basicCredential1;
				try
				{
					client.Send(message);
				}

				catch (Exception ex)
				{
					throw ex;
				};

			}

			//test to see if it worked
			foreach (String username in registrationQueue)
			{
				selected.Text += username + " authorized" + "<br/>";
			}

			Session["Student"] = student;

			return;

		}
    }
}