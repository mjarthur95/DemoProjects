using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using TLDR_Capstone.Classes;
using System.Configuration;
using System.Data.SqlClient;


namespace TLDR_Capstone
{
	public partial class ShowCatalog : System.Web.UI.Page
	{
		protected void Page_Init()
		{
			catalogGridview.DataBind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			string authlevel = null;

			if (student == null) userandlvl.Text = "Unknown user";
			else if (student.getAuthLvl() == 0) authlevel = "Student";
			else if (student.getAuthLvl() == 1) authlevel = "Administrator";
			else if (student.getAuthLvl() == 2) authlevel = "Root User";
			else authlevel = "Unknown";

			if (student != null) userandlvl.Text = "User: " + student.getUsername() + "<br/> Status: " + authlevel;

			AdminDirections.Text = "<b>Admin and Root Users:</b> Please use the 'Add Course' button to add courses to the catalog. <br/>" +
				"Once you have clicked the button in the popup window, please click 'Refresh' to view your additions. <br/>" +
				"To delete a course, simply check the checkbox and click 'Delete'.";

			if (student.getAuthLvl() == 0)
			{
				AddCourse.Visible = false;
				deleteBtn.Visible = false;
				refresh.Visible = false;
				AdminDirections.Visible = false;
			}
			else if ((student.getAuthLvl() == 1) || (student.getAuthLvl() == 2))
			{
				AddCourse.Visible = true;
				deleteBtn.Visible = true;
				refresh.Visible = true;
				AdminDirections.Visible = true;
			}

			if (student.potentialCourses != null)
			{
				selected.Text = "<b>Selected Courses:</b> <br/>";

				for (int i = 0; i < student.potentialCourses.Count(); i++)
				{
					selected.Text += student.potentialCourses[i].getName() + "<br/>";
				}
			}
		}

		protected void selectBtn_Click(object sender, EventArgs e)
		{
			List<string> coursesList = new List<string>();
			//Grab Student from Session
			Student student = Session["Student"] as Student;

			if (student == null) student = new Student();

			student.potentialCourses.Clear();
			selected.Text = "";
			//int i = 0;

			foreach (GridViewRow row in catalogGridview.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						coursesList.Add(row.Cells[3].Text);
					}
				}
			}

			Course myCourse = null;
			Section mySection = null;


			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;

			SqlConnection conn = new SqlConnection(constr);

			foreach (string course in coursesList)
			{
				myCourse = null;
				SqlCommand command = new SqlCommand("SELECT * FROM Schedule WHERE courseTitle = '" + HttpUtility.HtmlDecode(course) + "'");
				command.Connection = conn;

				DataTable dataTable = new DataTable();

				using (SqlDataAdapter da = new SqlDataAdapter(command))
				{
					da.Fill(dataTable);
				}

				myCourse = new Course(dataTable.Rows[0][1].ToString(), 
					int.Parse(dataTable.Rows[0][2].ToString()),
					dataTable.Rows[0][3].ToString(), null); 
				
				//da now has all sections
				foreach (DataRow dataRow in dataTable.Rows)
				{
					mySection = null;
					mySection = new Section(dataRow[1].ToString(), int.Parse(dataRow[2].ToString()), dataRow[3].ToString(),
						dataRow[4].ToString(), dataRow[5].ToString(),
						int.Parse(dataRow[7].ToString()), int.Parse(dataRow[8].ToString()), dataRow[6].ToString());
					//String pDeptID, int pCourseNumber, String pCourseTitle, String pSection, String pInstructor, int pBeginTime, int pEndTime, string pMeetDays
					if (!(mySection.reservedOverlap(student.getReservedTimes())))
					{
						myCourse.addSection(mySection);
					}
				}
				student.addPotentialCourse(myCourse);
			}

			//test to see if it worked

			selected.Text = "<b>Selected Courses:</b> <br/>";

			for (int i = 0; i < student.potentialCourses.Count(); i++)
			{
				selected.Text += student.potentialCourses[i].getName() + "<br/>";
			}

			Session["Student"] = student;
		}

		protected void deleteBtn_Click(object sender, EventArgs e)
		{
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);
			SqlCommand command = new SqlCommand();


			foreach (GridViewRow row in catalogGridview.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						command = new SqlCommand("DELETE FROM Catalog WHERE " +
							"deptID = '" + row.Cells[1].Text.ToString()
							+ "' AND courseNumber = '" + row.Cells[2].Text.ToString()
							+ "' AND courseTitle = '" + HttpUtility.HtmlDecode(row.Cells[3].Text.ToString()) + "'");

						command.Connection = conn;

						conn.Open();
						command.ExecuteNonQuery();
						conn.Close();
					}
				}
			}
			catalogGridview.DataBind();
		}

		protected void refresh_Click(object sender, EventArgs e)
		{
			catalogGridview.DataBind();
		}
	}
}