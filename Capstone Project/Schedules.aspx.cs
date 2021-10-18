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
	public partial class Schedules : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn("Schedule");
			dt.Columns.Add(dc);

			if (student.savedSchedules.Count != 0)
			{
				foreach (var schedule in student.savedSchedules)
				{
					Label schedules = new Label();
					schedules.Text = "";
					DataRow dr = dt.NewRow();

					foreach (var section in schedule)
					{
						schedules.Text += section.getCourseTitle() + ": "
							+ section.getMeetDays() +
							" Begin:" + section.getBeginTime() +
							", End:" + section.getEndTime() + "\n";
					}

					dr["Schedule"] = schedules.Text;
					dt.Rows.Add(dr);
				}

				savedSchedulesGV.DataSource = dt;
				savedSchedulesGV.DataBind();
			}
		}

		protected void GenerateSchedules_Click(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			student.allValidSchedules.Clear();

			if (student.selectedCourses.Count() >= 2 && student.selectedCourses.Count() <= 6)
			{
				student.generateValidSchedules();
			}
			schedulesGV.DataSource = null;
			schedulesGV.DataBind();

			DataTable dt = new DataTable();
			dt.Columns.Add("chkbox", typeof(bool));

			DataColumn dc = new DataColumn("Schedule");
			dt.Columns.Add(dc);

			if (student.allValidSchedules.Count != 0)
			{
				foreach (var schedule in student.allValidSchedules)
				{
					Label schedules = new Label();
					schedules.Text = "";
					DataRow dr = dt.NewRow();

					foreach (var section in schedule)
					{
						schedules.Text += section.getCourseTitle() + ": "
							+ section.getMeetDays() +
							" Begin:" + section.getBeginTime() +
							", End:" + section.getEndTime() + "\n";
					}

					dr["Schedule"] = schedules.Text;
					dt.Rows.Add(dr);
				}

				schedulesGV.DataSource = dt;
				schedulesGV.DataBind();
			}

			numSchedules.Text = "Number of generated schedules: " + student.allValidSchedules.Count();

			saveSchedules.Visible = true;

			/*
			schedules.Text = "";

			foreach (var schedule in student.allValidSchedules)
			{
				foreach (var section in schedule)
				{
					schedules.Text += section.getCourseTitle() + ": " 
						+ section.getMeetDays() +
						" Begin:" + section.getBeginTime() + 
						", End:" + section.getEndTime() + "<br/>";
				}
				schedules.Text += "<br/>";
			}*/
		}

		protected void saveSchedules_Click(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			student.savedSchedules.Clear();

			foreach (GridViewRow row in schedulesGV.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						student.savedSchedules.Add(student.allValidSchedules[row.RowIndex]);
					}
				}
			}

			Session["Student"] = student;

			savedSchedulesGV.DataSource = null;
			savedSchedulesGV.DataBind();

			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn("Schedule");
			dt.Columns.Add(dc);

			if (student.savedSchedules.Count != 0)
			{
				foreach (var schedule in student.savedSchedules)
				{
					Label schedules = new Label();
					schedules.Text = "";
					DataRow dr = dt.NewRow();

					foreach (var section in schedule)
					{
						schedules.Text += section.getCourseTitle() + ": "
							+ section.getMeetDays() +
							" Begin:" + section.getBeginTime() +
							", End:" + section.getEndTime() + "\n";
					}

					dr["Schedule"] = schedules.Text;
					dt.Rows.Add(dr);
				}

				savedSchedulesGV.DataSource = dt;
				savedSchedulesGV.DataBind();
			}
		}
	}
}