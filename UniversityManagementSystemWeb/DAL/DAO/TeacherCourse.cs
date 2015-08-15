using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class TeacherCourse
    {
        private int departmentId;
        private string teacherId;
        private int courseId;
        private DateTime assignDate;
        private int status;

        public int DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        public string TeacherId
        {
            get { return teacherId; }
            set { teacherId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public DateTime AssignDate
        {
            get { return assignDate; }
            set { assignDate = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}