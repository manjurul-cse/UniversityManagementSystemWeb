using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Semester
    {
        public Semester()
        {
            
        }
        private int semesterId;
        private string semesterName;

 

        public int SemesterId
        {
            get { return semesterId; }
            set { semesterId = value; }
        }

        public string SemesterName
        {
            get { return semesterName; }
            set { semesterName = value; }
        }
    }
}