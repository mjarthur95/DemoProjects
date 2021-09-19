using System;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace TLDR_Capstone
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void regBtn_Click1(object sender, EventArgs e)
		{
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;

			SqlConnection conn = new SqlConnection(constr);


			if (passTB.Text.Equals(passConfTB.Text))
			{

				SqlCommand command = new SqlCommand("select username from Users where " +
					"exists (select username from Users where username = '" + userTB.Text + "')");
				command.Connection = conn;

				conn.Open();
				if (command.ExecuteScalar() == null)
				{
					conn.Close();
					//create the user in database
					command = new SqlCommand("INSERT INTO Users (username, password, authlevel, email, verified, authorized) " +
						"VALUES(@username, @password, @authlevel, @email, @verified, @authorized)", conn);

					command.Parameters.AddWithValue("@username", userTB.Text);
					command.Parameters.AddWithValue("@password", passTB.Text);
					command.Parameters.AddWithValue("@authlevel", accessLvlDD.SelectedIndex);
					command.Parameters.AddWithValue("@email", emailTB.Text);
					command.Parameters.AddWithValue("@verified", 0);
					command.Parameters.AddWithValue("@authorized", 0);

					debug.Text = userTB.Text + passTB.Text + accessLvlDD.SelectedIndex + emailTB.Text;

					conn.Open();
					command.ExecuteNonQuery();
					debug.Text = "User successfully added.";
					conn.Close();

					//sending the email
					string to = emailTB.Text; //To address    
					string from = "scheduleplannerdonotreply@gmail.com"; //From address   
					MailMessage message = new MailMessage(from, to);

					//Body of message
					String mailbody = "Please enter your email at https://tldrcapstonestudentplanner.azurewebsites.net/Verify to verify your account.";

					//Subject of message
					message.Subject = "Registration Verification";
					message.Body = mailbody;
					message.BodyEncoding = Encoding.UTF8;
					message.IsBodyHtml = true;
					SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
					System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("scheduleplannerdonotreply@gmail.com", "TLDRCapstone0=");
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
					debug.Text = "Username already exists.";
				}
				conn.Close();
			}
			else
			{
				debug.Text = "Passwords do not match.";
			}

			Response.Redirect("~/Verify");
		}
	}
}