using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class StudentCourse
    {
        private string registrationNo;
        private string enrollDate;
        private int courseId;
        private int status;

        public string RegistrationNo
        {
            get { return registrationNo; }
            set { registrationNo = value; }
        }

        public string EnrollDate
        {
            get { return enrollDate; }
            set { enrollDate = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}