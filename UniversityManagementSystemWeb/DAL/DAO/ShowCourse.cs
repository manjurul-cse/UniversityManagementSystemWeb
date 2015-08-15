using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class ShowCourse
    {
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public double credit { get; set; }
        public string semesterName { get; set; }
        public string teacherName { get; set; }
        public string schedule { get; set; }
        


    }
}