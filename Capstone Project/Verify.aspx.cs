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
	public partial class Contact : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void verBtn_Click1(object sender, EventArgs e)
        {
			string inputEmail = emailVerTB.Text;

			//connection string
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);

			//select the requested authlevel for the specified email
			SqlCommand command = new SqlCommand("SELECT authlevel FROM Users WHERE email = @inputEmail", conn);
			command.Parameters.AddWithValue("@inputEmail", inputEmail);

			conn.Open();
			//if the user exists
			if (!(command.ExecuteScalar() == null))
			{

				int userAuthLevel = (int) command.ExecuteScalar();
				conn.Close();

				//update verified value to true
				command = new SqlCommand("UPDATE Users SET verified = @Verified WHERE email = @inputEmail", conn);
				command.Parameters.AddWithValue("@inputEmail", inputEmail);
				command.Parameters.AddWithValue("@Verified", 1);

				conn.Open();
				command.ExecuteNonQuery();
				
				//set the authorized value to true if not already set
				if (userAuthLevel == 0)
                {
					conn.Close();

					command = new SqlCommand("UPDATE Users SET authorized = @authorized WHERE email = @inputEmail", conn);
					command.Parameters.AddWithValue("@inputEmail", inputEmail);
					command.Parameters.AddWithValue("@authorized", 1);

					conn.Open();
					command.ExecuteNonQuery();
					conn.Close();
				}

				string to = inputEmail; //To address    
				string from = "scheduleplannerdonotreply@gmail.com"; //From address   
				MailMessage message = new MailMessage(from, to);

				string mailbody;
				//student
				if (userAuthLevel == 0) {
					mailbody = "Your email has now been verified. You may now login to the Schedule Planner.";
				}
				//root or admin
				else {
					mailbody = "Your email has now been verified. A root user must review your request for credentials " +
						"before you are able to login.";
				}

				//send email with message set above
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
			else
			{
				debug.Text = "No username with that email address exists.";
			}
			conn.Close();

			//return to the login page
			Response.Redirect("~/Default");

			return;
		}
	}
}