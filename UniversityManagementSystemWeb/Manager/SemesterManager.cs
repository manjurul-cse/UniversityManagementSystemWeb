using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class SemesterManager
    {

        public List<Semester> GetAllSemesters()
        {
       SemesterGateway aSemesterGateway=new SemesterGateway();
       return aSemesterGateway.GetAllSemesters();
        }

        public  Semester GetSemester(int id)
        {
            List<Semester>semesters=new List<Semester>();
            semesters = GetAllSemesters();
            Semester aSemester = new Semester();
            foreach (Semester semester in semesters)
            {
                if(semester.SemesterId==id)
                {
                    aSemester.SemesterId = semester.SemesterId;
                    aSemester.SemesterName = semester.SemesterName;
                    return aSemester;
                }
               

            }
            return aSemester;
        }

      
    }
}