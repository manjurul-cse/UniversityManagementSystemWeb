using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class CourseManager
    {
        private CourseGateway aCourseGateway;

        public string SaveCourse(Course aCourse)
        {
            aCourseGateway = new CourseGateway();
            if (!DoesThisCourseNameExist(aCourse))
                if (!DoesThisCourseCodeExist(aCourse))
                    return aCourseGateway.SaveCourse(aCourse);
                else
                    return "This Course Code already Exist";
            else
                return "This Course Name already Exist";
        }

        private bool DoesThisCourseCodeExist(Course aCourse)
        {
            List<Course> courses = new List<Course>();
            courses = GetAllCourses();
            foreach (Course course in courses)
            {
                if (course.CourseCode == aCourse.CourseCode)
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoesThisCourseNameExist(Course aCourse)
        {
            List<Course> courses = new List<Course>();
            courses = GetAllCourses();
            foreach (Course course in courses)
            {
                if (course.CourseName == aCourse.CourseName)
                {
                    return true;
                }
            }
            return false;
        }



        public List<Course> GetAllCourses()
        {
            aCourseGateway = new CourseGateway();
            return aCourseGateway.GetAllCourses();

        }

        public Course GetCourse(int courseId)
        {
            Course aCourse = new Course();
            List<Course> courses = new List<Course>();
            courses = GetAllCourses();
            foreach (Course course in courses)
            {
                if (course.CourseId == courseId)
                {
                    aCourse = course;
                }

            }
            return aCourse;
        }

        public List<Course> GetAllCoursesByDepartment(int departmentId, int semesteId)
        {
            aCourseGateway = new CourseGateway();
            return aCourseGateway.GetAllCoursesByDepartment(departmentId, semesteId);
        }



        public List<Course> GetAllUnassignedCourses(Course aCourse)
        {
            aCourseGateway = new CourseGateway();
            return aCourseGateway.GetAllUnassignedCourses(aCourse);
        }

        public List<Course> GetAllUnscheduledCourses(Course aCourse)
        {
            List<Course> unscheduleCourseList = new List<Course>();
            aCourseGateway = new CourseGateway();
            List<Course> courseList = new List<Course>();
            courseList = aCourseGateway.GetAllCoursesByDepartment(aCourse.ADepartment.DepartmentId,
                                                                  aCourse.ASemester.SemesterId);
            List<int> coursesId = new List<int>();
            int status;
            coursesId = aCourseGateway.GetScheduleCoursesId(aCourse);
            foreach (Course course in courseList)
            {
                status = 0;
                foreach (int courseId in coursesId)
                {
                    if (courseId == course.CourseId)
                    {
                        status = 1;
                    }

                }
                if (status == 0)
                {
                    unscheduleCourseList.Add(course);
                }
            }
            return unscheduleCourseList;
        }

        public List<ShowCourse> GetScheduleCoursesByDepartmentId(int departmentId)
        {

            aCourseGateway = new CourseGateway();
            return aCourseGateway.GetScheduleCoursesByDepartmentId(departmentId);

        }

        public string ResetCourseScheduleAndUnassignedAllCourse()
        {
            aCourseGateway = new CourseGateway();
            return aCourseGateway.ResetCourseScheduleAndUnassignedAllCourse();
        }

        public List<ShowCourse> GetScheduleCoursesByDepartmentIdAndSemester(int departmentId, int semesterId)
        {
            aCourseGateway = new CourseGateway();
            return aCourseGateway.GetScheduleCoursesByDepartmentIdAndSemester(departmentId, semesterId);

        }
    }
}