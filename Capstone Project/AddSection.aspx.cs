using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace TLDR_Capstone
{
	public partial class AddSection : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Save_Click(object sender, EventArgs e)
		{
			if (deptIDTB.Text != string.Empty
				&& courseNumTB.Text != string.Empty
				&& courseTitleTB.Text != string.Empty
				&& sectionIDTB.Text != string.Empty
				&& instructorTB.Text != string.Empty
				&& daysTB.Text != string.Empty
				&& startTB.Text != string.Empty
				&& endTB.Text != string.Empty)
			{
				string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;

				SqlConnection conn = new SqlConnection(constr);
				SqlCommand command = new SqlCommand("INSERT INTO Schedule(scheduleColumnID, deptID, courseNumber, courseTitle, sectionID, instructor, days, startTime, endTime)" +
					"VALUES(NULL, '" + deptIDTB.Text + "','" + courseNumTB.Text + "','" + courseTitleTB.Text + "','" +
					sectionIDTB.Text + "','" + instructorTB.Text + "','" + daysTB.Text + "','" +
					startTB.Text + "','" + endTB.Text + "')");

				command.Connection = conn;

				conn.Open();
				command.ExecuteNonQuery();
				conn.Close();


			}
		}
	}
}