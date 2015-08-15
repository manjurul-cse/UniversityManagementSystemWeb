using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class StudentResult
    {
        public string RegistationNo { get;  set; }
        public int DepartmentId { get;  set; }
        public int CourseId { get; set; }
        public string GradeLetter { get;  set; }
        public int Status { get;  set; }

      
    }
}