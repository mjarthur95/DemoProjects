using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;


namespace TLDR_Capstone.Classes
{
	public class Course
	{
        //Constructor
        public Course(String pDeptID, int pCourseID, String pName, List<Section> pSections)
        {
            deptID = pDeptID;
            name = pName;
            courseID = pCourseID;
            sections = new List<Section>();
        }

        //Members
        public String deptID, name, instructor;
        public int courseID;
        public List<Section> sections;

        //Add a section to the course sections
        public void addSection(Section pSection)
        {
            sections.Add(pSection);
        }

        public void removeSection(Section pSection)
        {
            sections.Remove(pSection);
        }

        //Getters and Setters
        public String getDeptID()
        {
            return deptID;
        }

        public void setDeptID(String pDeptID)
        {
            deptID = pDeptID;
            return;
        }
        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public int getCourseID()
        {
            return courseID;
        }

        public void setCourseID(int courseID)
        {
            this.courseID = courseID;
        }

        public List<Section> getSections()
        {
            return sections;
        }

        public Section getSection(int i)
        {
            return sections[i];
        }

        public void setSections(List<Section> sections)
        {
            this.sections = sections;
        }

        public void insertCourses()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            string query = "INSERT INTO Catalog(DeptID,CourseNumber,CourseTitle) VALUES(@DeptID,@CourseNumber,@CourseTitle)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@deptID", getDeptID());
            cmd.Parameters.AddWithValue("@CourseNumber", getCourseID());
            cmd.Parameters.AddWithValue("@courseTitle", getName());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}