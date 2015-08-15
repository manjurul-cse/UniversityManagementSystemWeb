using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class StudentManager
    {
        private StudentGateway aStudentGateway;
        public string GetStudentRegistationNO(Student aStudent)
        {
            string regNo = "";
            int id;
            aStudentGateway = new StudentGateway();
            id = aStudentGateway.GetStudentRegistationNO(aStudent);
            if (id < 10)
                regNo = "000" + id;
            if (id >= 10 && id < 100)
                regNo = "00" + id;
            if (id >= 100 && id < 1000)
                regNo = "0" + id;
            if (id >= 1000)
                regNo = id.ToString();

            return regNo;
        }

        public string SaveStudent(Student aStudent)
        {
            aStudentGateway = new StudentGateway();
            if (!DoesThisEmailExist(aStudent))
                return aStudentGateway.SaveStudent(aStudent);
            else
                return "This Email Already Exist";

        }

        private bool DoesThisEmailExist(Student aStudent)
        {
            aStudentGateway = new StudentGateway();
            List<string> emails = new List<string>();
            emails = aStudentGateway.GetStudentEmails();
            foreach (string email in emails)
            {
                if (email == aStudent.Email)
                    return true;
            }
            return false;
        }



        public Student GetStudentInformation(string regNo, int depeartmentId)
        {
            aStudentGateway = new StudentGateway();
            return aStudentGateway.GetStudentInformation(regNo, depeartmentId);

        }

        public string GetYear(string date)
        {
            string year = "";
            for (int i = 0; i < 4; i++)
            {
                year += date[i];
            }
            return year;
        }

        public ViewStudentInformation GetStudentInfo(string regNo)
        {
            aStudentGateway = new StudentGateway();
            return aStudentGateway.GetStudentInfo(regNo);
        }

        public List<Course> GetStudentCourses(string regNo)
        {
            aStudentGateway = new StudentGateway();
            return aStudentGateway.GetStudentCourses(regNo);
        }

        public List<Course> GetAllcourses(ViewStudentInformation aViewStudentInformation)
        {
            int flag;
            CourseGateway aCourseGateway = new CourseGateway();
            List<Course> courseList = new List<Course>();
            List<Course> courses = new List<Course>();
            List<Course> newCourses = new List<Course>();
            courses = GetStudentCourses(aViewStudentInformation.RegistationNo);
            courseList = aCourseGateway.GetCoursesByDepartment(aViewStudentInformation);
            foreach (Course deptCourse in courseList)
            {
                flag = 0;
                foreach (Course course in courses)
                {
                    if (deptCourse.CourseCode == course.CourseCode)
                        flag = 1;

                }
                if (flag == 0)
                    newCourses.Add(deptCourse);

            }
            return newCourses;
        }

        public string SaveStudentCourse(StudentCourse aStudentCourse)
        {
            aStudentGateway = new StudentGateway();
            return aStudentGateway.SaveStudentCourse(aStudentCourse);
        }
        public List<Course> GetStudentMinorCourses(string departmentCode, string regNo)
        {
            int flag;
            CourseGateway aCourseGateway = new CourseGateway();
            List<Course> courseList = new List<Course>();
            List<Course> courses = new List<Course>();
            List<Course> newCourses = new List<Course>();
            courses = GetStudentCourses(regNo);
            courseList = aCourseGateway.GetCoursesByDepartment();
            foreach (Course deptCourse in courseList)
            {
                flag = 0;
                foreach (Course course in courses)
                {
                    if (deptCourse.CourseCode == course.CourseCode)
                        flag = 1;

                }
                if (flag == 0)
                    newCourses.Add(deptCourse);

            }
            return newCourses;
        }



        public ViewStudentInformation GetStudentInformation(string regNo)
        {
            aStudentGateway = new StudentGateway();

            return aStudentGateway.GetStudentInfo(regNo);
        }
    }
}