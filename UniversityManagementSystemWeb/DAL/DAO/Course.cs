using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    [Serializable]
    public class Course
    {
        private int courseId;
        private string courseCode;
        private string courseName;
        private double credit;
        private string description;
        private int courseStatus;
        private Semester aSemester;
        private Department aDepartment;
        

        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public double Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

   

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public int CourseStatus
        {
            get { return courseStatus; }
            set { courseStatus = value; }
        }

        public Semester ASemester
        {
            get { return aSemester; }
            set { aSemester = value; }
        }

        public Department ADepartment
        {
            get { return aDepartment; }
            set { aDepartment = value; }
        }
    }
}