using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class TeacherManager
    {
        private TeacherGateway aTeacherGateway;

        public string SaveTeacher(Teacher aTeacher)
        {
            aTeacherGateway = new TeacherGateway();
            if (!DoesThisEmailExist(aTeacher))
                return aTeacherGateway.SaveTeacher(aTeacher);
            else
                return "This Email Already Exist";
        }

        private bool DoesThisEmailExist(Teacher aTeacher)
        {
            List<string> emails = new List<string>();
            aTeacherGateway = new TeacherGateway();
            emails = aTeacherGateway.GetAllEmails();
            foreach (string email in emails)
            {
                if (email == aTeacher.Email)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetTeacherId(int departmentId)
        {
            string teacherId = "";
            aTeacherGateway = new TeacherGateway();
            int id = aTeacherGateway.GetTeacherId(departmentId);
            if (id < 10)
                teacherId = "0" + id;
            else

                teacherId = id.ToString();

            return teacherId;
        }

        public List<Teacher> GetAllTeachers(int departmentId)
        {
            aTeacherGateway = new TeacherGateway();
            return aTeacherGateway.GetAllTeachers(departmentId);
        }

        public Teacher GetTeacher(Teacher aTeacher)
        {
            aTeacherGateway = new TeacherGateway();
            return aTeacherGateway.GetTeacher(aTeacher);
        }

        public Teacher GetTeacherCreditInfo(Teacher aTeacher)
        {
            aTeacherGateway = new TeacherGateway();
            return aTeacherGateway.GetTeacherCreditInfo(aTeacher);
        }


        public string SaveTeacerCourse(TeacherCourse aTeacherCourse, float credit)
        {

            aTeacherGateway = new TeacherGateway();
            if (!CheckTeacherTime(aTeacherCourse))
               if (!DoesThisCourseExist(aTeacherCourse))
             return aTeacherGateway.SaveTeacerCourse(aTeacherCourse, credit);
                else
                   return "This Course Already Assigned";
            else
                return "This Time Teacher Handel Another Course";
        }

        private bool CheckTeacherTime(TeacherCourse aTeacherCourse)
        {
            aTeacherGateway = new TeacherGateway();
            ScheduleGateway aScheduleGateway = new ScheduleGateway();
            List<int> coursesId = new List<int>();
            coursesId = aTeacherGateway.GetTeacherAssignCoursesId(aTeacherCourse);
            List<Schedule> schedules = new List<Schedule>();
            schedules = aScheduleGateway.GetTeacherAllSchedules(coursesId);
            List<Schedule> currentScheduleList = new List<Schedule>();
            currentScheduleList = aScheduleGateway.GetCurrentCourseSchedules(aTeacherCourse);
            foreach (Schedule schedule in currentScheduleList)
            {
                foreach (Schedule aSchedule in schedules)
                {
                    if (schedule.DayId == aSchedule.DayId && ((schedule.StartTime <= aSchedule.StartTime && schedule.EndingTime >= aSchedule.StartTime) || (schedule.StartTime <= aSchedule.EndingTime & schedule.EndingTime >= aSchedule.EndingTime)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool DoesThisCourseExist(TeacherCourse aTeacherCourse)
        {
            int status = 0;
            List<Course> courses = new List<Course>();
            CourseManager aCourseManager = new CourseManager();
            courses = aCourseManager.GetAllCourses();
            foreach (Course course in courses)
            {
                if (aTeacherCourse.CourseId == course.CourseId && course.CourseStatus == 1)
                {
                    status = 1;
                }
            }

            if (status == 1)
                return true;
            else
            {
                return false;
            }


        }
    }
}