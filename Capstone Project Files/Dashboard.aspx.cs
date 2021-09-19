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
	public partial class About : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//Grab Student from Session
			Student student = Session["Student"] as Student;
			if (student == null) student = new Student();

			//if student is not a root
			//make the Registration Queue button invisible
			if (student.getAuthLvl() != 2)
            {
				registrationQueue.Visible = false;
            }

		}

		protected void importBtn_Click(object sender, EventArgs e)
		{
			Classes.Catalog catalog = new Classes.Catalog();
			catalog.import("C:/Brad School/Spring 2021/Capstone Project/TLDR Capstone/WU_CourseScheduleTrim.csv");
		}
	}
}