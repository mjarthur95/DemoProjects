using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TLDR_Capstone.Classes
{
	public class Section
	{
        //Constructor
        public Section(String pDeptID, int pCourseNumber, String pCourseTitle, String pSection, String pInstructor, int pBeginTime, int pEndTime, string pMeetDays)
        {
            deptID = pDeptID;
            courseNumber = pCourseNumber;
            courseTitle = pCourseTitle;
            section = pSection;
            instructor = pInstructor;
            beginTime = pBeginTime;
            endTime = pEndTime;
            meetDays = pMeetDays;
            bMeetDays = null;
        }

        //Members
        public String deptID, courseTitle, section, instructor, meetDays;
		public int courseNumber, beginTime, endTime;
        List<Boolean> bMeetDays;

        //Getters and Setters
        public String getCourseTitle()
        {
            return courseTitle;
        }

        public void setCourseTitle(String pCourseTitle)
        {
            courseTitle = pCourseTitle;
            return;
        }
        public String getDeptID()
        {
            return deptID;
        }

        public void setDeptID(String pDeptID)
        {
            deptID = pDeptID;
            return;
        }
        public int getCourseNum()
        {
            return courseNumber;
        }

        public void setCourseNum(int courseNum)
        {
            this.courseNumber = courseNum;
        }

        public String getSection()
        {
            return section;
        }

        public void setSection(String section)
        {
            this.section = section;
        }

        public String getInstructor()
        {
            return instructor;
        }

        public void setInstructor(String instructor)
        {
            this.instructor = instructor;
        }

        public string getMeetDays()
        {
            return meetDays;
        }

        public void setMeetDays(string meetDays)
        {
            this.meetDays = meetDays;
        }

        public List<Boolean> getBMeetDays()
        {
            //create a boolean list for Monday to Friday, with Monday as 0 and all days as false
            List<Boolean> MeetDays = new List<Boolean> { false, false, false, false, false };

            //if the days are in the string, set the day true in the list
            if (meetDays.Contains("M"))
            {
                MeetDays[0] = true;
            }
            if (meetDays.Contains("T"))
            {
                MeetDays[1] = true;
            }
            if (meetDays.Contains("W"))
            {
                MeetDays[2] = true;
            }
            if (meetDays.Contains("R"))
            {
                MeetDays[3] = true;
            }
            if (meetDays.Contains("F"))
            {
                MeetDays[4] = true;
            }

            return MeetDays;
        }

        public int getBeginTime()
        {
            return beginTime;
        }

        public void setBeginTime(int beginTime)
        {
            this.beginTime = beginTime;
        }

        public int getEndTime()
        {
            return endTime;
        }

        public void setEndTime(int endTime)
        {
            this.endTime = endTime;
        }

        public void insertSections()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            string query = "INSERT INTO Schedule(Username, DeptID, CourseNumber, CourseTitle, Instructor, Days, StartTime, EndTime) " +
                "VALUES(@Username, @DeptID, @CourseNumber, @CourseTitle, @Instructor, @Days, @StartTime, @EndTime)";

            SqlCommand cmd = new SqlCommand(query, con);


            cmd.Parameters.AddWithValue("@Username", "testuser");
            cmd.Parameters.AddWithValue("@DeptID", getDeptID());
            cmd.Parameters.AddWithValue("@CourseNumber", getCourseNum());
            cmd.Parameters.AddWithValue("@CourseTitle", getCourseTitle());
            cmd.Parameters.AddWithValue("@Instructor", getInstructor());
            cmd.Parameters.AddWithValue("@Days", getMeetDays());
            cmd.Parameters.AddWithValue("@StartTime", getBeginTime());
            cmd.Parameters.AddWithValue("@EndTime", getEndTime());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Boolean reservedOverlap(List<ReservedTime> reservedTimes)
        {
            foreach (ReservedTime reserve in reservedTimes)
            {
                //if the section has meeting on the day of the reserved time, and
                //if the meeting occurs during the reserved time, return true
                if (getMeetDays().Contains(reserve.getDay())
                    && ((reserve.getBeginTime() < getBeginTime() && reserve.getEndTime() > getBeginTime())
                    || (reserve.getBeginTime() < getEndTime() && reserve.getEndTime() > getEndTime())))
                {
                    return true;
                }
            }

            //else, no overlap
            return false;
        }
    }
}