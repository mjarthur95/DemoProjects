using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLDR_Capstone.Classes;

namespace TLDR_Capstone
{
    public class Student
    {
        //Constructor
        public Student()
        {
            potentialCourses = new List<Course>();
            selectedCourses = new List<Course>();
            validSchedule = new List<Course>();
            allValidSchedules = new List<List<Section>>();
            savedSchedules = new List<List<Section>>();
            reservedTimes = new List<ReservedTime>();
            username = "default";
            authLvl = 0;
        }

        //Members
        public List<Course> potentialCourses, selectedCourses, validSchedule;
        public List<List<Section>> allValidSchedules, savedSchedules;
        public List<ReservedTime> reservedTimes;
        public string username;
        public int authLvl;

        public void setUsername(string pUser)
        {
            username = pUser;
        }

        public string getUsername()
        {
            return username;
        }

        public void setAuthLvl(int pLvl)
        {
            authLvl = pLvl;
        }

        public int getAuthLvl()
        {
            return authLvl;
        }
        //Add a single course to the list of potential courses
        public void addPotentialCourse(Course pCourse)
        {
            potentialCourses.Add(pCourse);
        }

        //Add a single course to the list of selected courses that a schedule will be generated from
        public void addSelectedCourse(Course pCourse)
        {
            selectedCourses.Add(pCourse);
        }

        public Course getSelectedCourse(int i)
        {
            return selectedCourses[i];
        }

        public List<ReservedTime> getReservedTimes()
        {
            return reservedTimes;
        }

        public void addReservedTime(ReservedTime reserved)
        {
            reservedTimes.Add(reserved);
        }

        //Function to determine if a combination of course sections has any scheduling overlaps
        public Boolean hasOverlap(List<Section> pSections)
        {
            Boolean hasOverlap = false;

            //Here we compare start and end times of all the sections in the provided potential schedule
            //We use nested loops to iterate through all the sections

            //Check all but last section because it has already been checked against the proceeding sections
            for (int i = 0; i < pSections.Count() - 1; i++)
            {
                //j = i + 1 because no need to recheck first section or itself
                for (int j = i + 1; j < pSections.Count(); j++)
                {

                    //Checking for overlap. If the begin or end time of section i falls within
                    //begin and end time of section j, there is overlap



                    //First check to see if course is same day
                    if ((pSections[i].getBMeetDays()[0] && pSections[j].getBMeetDays()[0])    //Monday
                    || (pSections[i].getBMeetDays()[1] && pSections[j].getBMeetDays()[1])     //Tuesday
                    || (pSections[i].getBMeetDays()[2] && pSections[j].getBMeetDays()[2])     //Wednesday
                    || (pSections[i].getBMeetDays()[3] && pSections[j].getBMeetDays()[3])     //Thursday
                    || (pSections[i].getBMeetDays()[4] && pSections[j].getBMeetDays()[4]))
                    {  //Friday
                        if (((pSections[i].getBeginTime() >= pSections[j].getBeginTime()) &&
                            (pSections[i].getBeginTime() <= pSections[j].getEndTime())) ||
                            ((pSections[i].getEndTime() >= pSections[j].getBeginTime()) &&
                                (pSections[i].getEndTime() <= pSections[j].getEndTime())))
                        {
                            hasOverlap = true;
                        }
                    }
                }
            }
            return hasOverlap;
        }

        public void generateValidSchedules()
        {
            //Temporary variable to store schedule being evaluated
            List<Section> beingEvaluated = null;

            //Here we switch on the number of courses selected
            switch (selectedCourses.Count())
            {
                //2 Courses
                case 2:
                    Course course0 = getSelectedCourse(0);
                    Course course1 = getSelectedCourse(1);
                    for (int i = 0; i < course0.getSections().Count(); i++)
                    {
                        for (int j = 0; j < course1.getSections().Count(); j++)
                        {
                            beingEvaluated = new List<Section>();
                            beingEvaluated.Add(course0.sections[i]);
                            beingEvaluated.Add(course1.sections[j]);
                            if (!hasOverlap(beingEvaluated))
                            {
                                allValidSchedules.Add(beingEvaluated);
                            }
                            
                        }
                    }
                    break;
                //3 Courses
                case 3:
                    course0 = getSelectedCourse(0);
                    course1 = getSelectedCourse(1);
                    Course course2 = getSelectedCourse(2);
                    for (int i = 0; i < course0.getSections().Count(); i++)
                    {
                        for (int j = 0; j < course1.getSections().Count(); j++)
                        {
                            for (int k = 0; k < course2.getSections().Count(); k++)
                                {
                                beingEvaluated = new List<Section>();
                                beingEvaluated.Add(course0.sections[i]);
                                beingEvaluated.Add(course1.sections[j]);
                                beingEvaluated.Add(course2.sections[k]);
                                if (!hasOverlap(beingEvaluated))
                                {
                                    allValidSchedules.Add(beingEvaluated);
                                }
                            }
                        }
                    }
                    break;
                //4 Courses
                case 4:
                    course0 = getSelectedCourse(0);
                    course1 = getSelectedCourse(1);
                    course2 = getSelectedCourse(2);
                    Course course3 = getSelectedCourse(3);
                    for (int i = 0; i < course0.getSections().Count(); i++)
                    {
                        for (int j = 0; j < course1.getSections().Count(); j++)
                        {
                            for (int k = 0; k < course2.getSections().Count(); k++)
                                {
                                for (int l = 0; l < course3.getSections().Count(); l++)
                                {
                                    beingEvaluated = new List<Section>();
                                    beingEvaluated.Add(course0.sections[i]);
                                    beingEvaluated.Add(course1.sections[j]);
                                    beingEvaluated.Add(course2.sections[k]);
                                    beingEvaluated.Add(course3.sections[l]);
                                    if (!hasOverlap(beingEvaluated))
                                    {
                                        allValidSchedules.Add(beingEvaluated);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 5:
                    course0 = getSelectedCourse(0);
                    course1 = getSelectedCourse(1);
                    course2 = getSelectedCourse(2);
                    course3 = getSelectedCourse(3);
                    Course course4 = getSelectedCourse(4);
                    for (int i = 0; i < course0.getSections().Count(); i++)
                    {
                        for (int j = 0; j < course1.getSections().Count(); j++)
                        {
                            for (int k = 0; k < course2.getSections().Count(); k++)
                            {
                                for (int l = 0; l < course3.getSections().Count(); l++)
                                {
                                    for (int m = 0; m < course4.getSections().Count(); m++)
                                    {
                                        beingEvaluated = new List<Section>();
                                        beingEvaluated.Add(course0.sections[i]);
                                        beingEvaluated.Add(course1.sections[j]);
                                        beingEvaluated.Add(course2.sections[k]);
                                        beingEvaluated.Add(course3.sections[l]);
                                        beingEvaluated.Add(course4.sections[m]);
                                        if (!hasOverlap(beingEvaluated))
                                        {
                                            allValidSchedules.Add(beingEvaluated);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 6:
                    course0 = getSelectedCourse(0);
                    course1 = getSelectedCourse(1);
                    course2 = getSelectedCourse(2);
                    course3 = getSelectedCourse(3);
                    course4 = getSelectedCourse(4);
                    Course course5 = getSelectedCourse(5);
                    for (int i = 0; i < course0.getSections().Count(); i++)
                    {
                        for (int j = 0; j < course1.getSections().Count(); j++)
                        {
                            for (int k = 0; k < course2.getSections().Count(); k++)
                            {
                                for (int l = 0; l < course3.getSections().Count(); l++)
                                {
                                    for (int m = 0; m < course4.getSections().Count(); m++)
                                    {
                                        for (int n = 0; n < course5.getSections().Count(); n++)
                                        {
                                            beingEvaluated = new List<Section>();
                                            beingEvaluated.Add(course0.sections[i]);
                                            beingEvaluated.Add(course1.sections[j]);
                                            beingEvaluated.Add(course2.sections[k]);
                                            beingEvaluated.Add(course3.sections[l]);
                                            beingEvaluated.Add(course4.sections[m]);
                                            beingEvaluated.Add(course5.sections[n]);
                                            if (!hasOverlap(beingEvaluated))
                                            {
                                                allValidSchedules.Add(beingEvaluated);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                default:
           
                    break;
            }
        }
        /*public List<Boolean> convDays2Bool(String pDays)
        {
            //create a boolean list for Monday to Friday, with Monday as 0 and all days as false
            List<Boolean> MeetDays = new List<Boolean> { false, false, false, false, false };

            //if the days are in the string, set the day true in the list
            if (pDays.Contains("M"))
            {
                MeetDays[0] = true;
            }
            if (pDays.Contains("T"))
            {
                MeetDays[1] = true;
            }
            if (pDays.Contains("W"))
            {
                MeetDays[2] = true;
            }
            if (pDays.Contains("R"))
            {
                MeetDays[3] = true;
            }
            if (pDays.Contains("F"))
            {
                MeetDays[4] = true;
            }

            return MeetDays;
        }*/
    }

    public struct ReservedTime
    {
        private String day;
        private int beginTime, endTime;

        public ReservedTime(String pDay, int pBeginTime, int pEndTime)
        {
            day = pDay;
            beginTime = pBeginTime;
            endTime = pEndTime;
        }

        public String getDay()
        {
            return day;
        }

        public void setDay(String pDay)
        {
            day = pDay;
        }

        public int getBeginTime()
        {
            return beginTime;
        }

        public void setBeginTime(int pBeginTime)
        {
            beginTime = pBeginTime;
        }

        public int getEndTime()
        {
            return endTime;
        }

        public void setEndTime(int pEndTime)
        {
            endTime = pEndTime;
        }
    }
}