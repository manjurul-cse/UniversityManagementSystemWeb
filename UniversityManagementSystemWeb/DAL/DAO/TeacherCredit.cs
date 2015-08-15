using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class TeacherCredit
    {
        public string TeacherId { get;  set; }
        public float AssignCredit { get; set; }
        public float RemaningCredit { get; set; }
        public int status { get; set; }

    }
}