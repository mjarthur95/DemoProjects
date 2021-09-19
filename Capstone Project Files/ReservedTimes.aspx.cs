using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TLDR_Capstone
{
    public partial class ReservedTimes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Student student = Session["Student"] as Student;

			if (student == null) student = new Student();

			foreach (ReservedTime reserved in student.getReservedTimes())
			{
				selected.Text += reserved.getDay() + " " + reserved.getBeginTime().ToString() +
					"-" + reserved.getEndTime().ToString() + "<br/>";
			}
		}

		protected void selectBtn_Click(object sender, EventArgs e)
		{
			List<ReservedTime> reservedTimes = new List<ReservedTime>();
			//Grab Student from Session
			Student student = Session["Student"] as Student;

			if (student == null) student = new Student();

			
			student.reservedTimes.Clear();
			selected.Text = "";

			//get the times from the table
			foreach (GridViewRow row in reservedTimeView.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						reservedTimes.Add(new ReservedTime(row.Cells[1].Text, Int32.Parse(row.Cells[2].Text), Int32.Parse(row.Cells[3].Text)));
					}
				}
			}

			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);

			//Empty the table in SQL at the username
			SqlCommand command = new SqlCommand("DELETE FROM Reserved WHERE username = @username", conn);
			command.Parameters.AddWithValue("@username", student.getUsername());

			conn.Open();
			command.ExecuteNonQuery();
			conn.Close();


			//add the values into table that user selected
			foreach (ReservedTime reserved in reservedTimes)
			{
				command = new SqlCommand("INSERT INTO Reserved (username, reservedDay, reservedStartTime, reservedEndTime) " +
						"VALUES(@username, @reservedDay, @reservedStartTime, @reservedEndTime)", conn);

				command.Parameters.AddWithValue("@username", student.getUsername());
				command.Parameters.AddWithValue("@reservedDay", reserved.getDay());
				command.Parameters.AddWithValue("@reservedStartTime", reserved.getBeginTime());
				command.Parameters.AddWithValue("@reservedEndTime", reserved.getEndTime());

				conn.Open();
				command.ExecuteNonQuery();
				conn.Close();

				student.addReservedTime(reserved);

			}

			//test to see if it worked
			foreach (ReservedTime reserved in student.getReservedTimes())
            {
				selected.Text += reserved.getDay() + " " + reserved.getBeginTime().ToString() + 
					"-" + reserved.getEndTime().ToString() +  "<br/>";
			}

			Session["Student"] = student;

			return;
		}
	}
}