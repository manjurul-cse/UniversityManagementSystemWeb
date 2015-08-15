using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class SemesterGateway : DBGateway
    {

        public List<Semester> GetAllSemesters()
        {
            try
            {
                List<Semester> semester = new List<Semester>();
                connection.Open();
                string semesterQuery = "select * from t_Semester";
                command.CommandText = semesterQuery;
                SqlDataReader semesterReader = command.ExecuteReader();
                while (semesterReader.Read())
                {
                    Semester aSemester = new Semester();
                    aSemester.SemesterId = Convert.ToInt16(semesterReader[0].ToString());
                    aSemester.SemesterName = semesterReader[1].ToString();
                    semester.Add(aSemester);
                }

                return semester;

            }
            finally
            {
                connection.Close();
            }
        }
    }
}