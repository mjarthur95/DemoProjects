using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TLDR_Capstone.Classes;

namespace TLDR_Capstone
{
	public partial class AvailableCourses : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			if (!Page.IsPostBack)
			{


				string authlevel = null;

				if (student == null) student.username = "Unknown user";
				else if (student.getAuthLvl() == 0) authlevel = "Student";
				else if (student.getAuthLvl() == 1) authlevel = "Administrator";
				else if (student.getAuthLvl() == 2) authlevel = "Root User";
				else authlevel = "Unknown";

				if (student != null) userandlvl.Text = "User: " + student.getUsername() + "<br/> Status: " + authlevel;


				DataTable dt = new DataTable();
				dt.Columns.Add("chkbox", typeof(bool));

				DataColumn dc = new DataColumn("Course");
				dt.Columns.Add(dc);

				if (student.potentialCourses.Count != 0)
				{
					foreach (Course course in student.potentialCourses)
					{
						DataRow dr = dt.NewRow();
						dr["Course"] = course.getName();
						dt.Rows.Add(dr);
					}

					availableCoursesGV.DataSource = dt;
					availableCoursesGV.DataBind();
				}
			}
			Directions.Text = "Please check at least two and up to six courses. <br/>" +
				"These courses will be used to generate possible schedules. <br/>" +
				"Click the 'Select' button below this list to confirm your selection.";

			if (student.selectedCourses != null)
			{
				selectedcourses.Text = "<b>Selected Courses:</b> <br/>";

				foreach (var course in student.selectedCourses)
				{
					selectedcourses.Text += course.getName() + "<br/>";
				}
			}
		}

		protected void select_Click(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();
			
			student.selectedCourses.Clear();

			foreach (GridViewRow row in availableCoursesGV.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						student.addSelectedCourse(student.potentialCourses[row.RowIndex]);
					}
				}
			}

			Session["Student"] = student;

			//this last bit is deletable
			selectedcourses.Text = "<b>Selected Courses:</b> <br/>";

			foreach (var course in student.selectedCourses)
			{
				selectedcourses.Text += course.getName() + "<br/>";
			}
		}
	}
}