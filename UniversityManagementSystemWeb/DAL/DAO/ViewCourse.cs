using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class ViewCourse
    {
        public string courseCode { get; set;}
        public string courseName { get; set; }
        public double credit { get; set; }
        public int semesterId { get; set; }
        public string semesterName { get; set; }
        public string teacherName { get; set; }
        public double startTime { get; set; }
        public double endingTime { get; set; }
        public string day { get; set; }
        public string roomName { get; set; }
        public string buildingName { get; set; }
        public int departmentId { get; set; }

    }
}