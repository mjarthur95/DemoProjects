using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using TLDR_Capstone.Classes;

namespace TLDR_Capstone
{
	public partial class ShowSections : System.Web.UI.Page
	{

		protected void Page_Init()
		{
			scheduleGridview.DataBind();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			//Invisible buttons
			AdminDirections.Text = "<b>Admin and Root Users:</b> Please use the 'Add Section' button to add sections to the section view. <br/>" +
				"Once you have clicked the button in the popup window, please click 'Refresh' to view your additions. <br/>" +
				"To delete a section, simply check the checkbox and click 'Delete'.";

			if (student.getAuthLvl() == 0)
			{
				AddSection.Visible = false;
				deleteBtn.Visible = false;
				refresh.Visible = false;
				AdminDirections.Visible = false;
			}
			else if ((student.getAuthLvl() == 1) || (student.getAuthLvl() == 2))
			{
				AddSection.Visible = true;
				deleteBtn.Visible = true;
				refresh.Visible = true;
				AdminDirections.Visible = true;
			}

			foreach (GridViewRow row in scheduleGridview.Rows)
			{
				Section section = new Section(row.Cells[1].Text.ToString(), Int32.Parse(row.Cells[2].Text.ToString())
							, HttpUtility.HtmlDecode(row.Cells[3].Text.ToString()), row.Cells[4].Text
							, row.Cells[5].Text, Int32.Parse(row.Cells[7].Text.ToString())
							, Int32.Parse(row.Cells[8].Text.ToString()), row.Cells[6].Text);

				if (section.reservedOverlap(student.getReservedTimes())) {
					row.Visible = false;
				}
            }
		}

		protected void deleteBtn_Click(object sender, EventArgs e)
		{
			string constr = ConfigurationManager.ConnectionStrings["capstoneDatabase"].ConnectionString;
			SqlConnection conn = new SqlConnection(constr);
			SqlCommand command = new SqlCommand();


			foreach (GridViewRow row in scheduleGridview.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkbox = (row.Cells[0].FindControl("chkbox") as CheckBox);
					if (chkbox.Checked)
					{
						command = new SqlCommand("DELETE FROM Schedule WHERE " +
							"deptID = '" + row.Cells[1].Text.ToString()
							+ "' AND courseNumber = '" + row.Cells[2].Text.ToString()
							+ "' AND courseTitle = '" + HttpUtility.HtmlDecode(row.Cells[3].Text.ToString())
							+ "' AND sectionID = '" + row.Cells[4].Text
							+ "' AND instructor = '" + row.Cells[5].Text
							+ "' AND days = '" + row.Cells[6].Text
							+ "' AND startTime = '" + row.Cells[7].Text
							+ "' AND endTime = '" + row.Cells[8].Text + "'");

						command.Connection = conn;

						conn.Open();
						command.ExecuteNonQuery();
						conn.Close();
					}
				}
			}
			scheduleGridview.DataBind();
		}

		protected void refresh_Click(object sender, EventArgs e)
		{
			scheduleGridview.DataBind();
		}
	}
}