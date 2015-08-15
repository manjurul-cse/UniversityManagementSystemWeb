using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class ResultGateway : DBGateway
    {
        public string SaveASubjectGrade(StudentResult aStudentResult)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO t_Result VALUES(@regNo,@deptId,@courseId,@gradeLetter,@status)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", aStudentResult.RegistationNo);
                command.Parameters.AddWithValue("@deptId", aStudentResult.DepartmentId);
                command.Parameters.AddWithValue("@courseId", aStudentResult.CourseId);
                command.Parameters.AddWithValue("@gradeLetter", aStudentResult.GradeLetter);
                command.Parameters.AddWithValue("@status", aStudentResult.Status);
                command.ExecuteNonQuery();
                return "Saved";
            }

            finally
            {
                connection.Close();
            }

        }

        public List<StudentResult> GetStudentAllResult(StudentResult aStudentResult)
        {
            try
            {
                connection.Open();
                List<StudentResult> aStudentResults = new List<StudentResult>();
                string query = "SELECT * FROM t_Result WHERE RegistationNo=@regNo";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", aStudentResult.RegistationNo);
                SqlDataReader ResultReader = command.ExecuteReader();
                while (ResultReader.Read())
                {
                    StudentResult studentResult = new StudentResult();
                    studentResult.RegistationNo = ResultReader[0].ToString();
                    studentResult.DepartmentId = Convert.ToInt16(ResultReader[1].ToString());
                    studentResult.CourseId = Convert.ToInt16(ResultReader[2].ToString());
                    studentResult.GradeLetter = ResultReader[3].ToString();
                    studentResult.Status = Convert.ToInt16(ResultReader[4].ToString());
                    aStudentResults.Add(studentResult);
                }
               
                return aStudentResults;
            }
       finally
            {
                connection.Close();  
            }

           
        }

        public List<StudentResult> GetSubjectResult(StudentResult aStudentResult)
        {
            try
            {
                connection.Open();
                List<StudentResult> aStudentResults = new List<StudentResult>();
                string query = "SELECT * FROM t_Result WHERE RegistationNo=@regNo And CourseId=@CourseId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", aStudentResult.RegistationNo);
                command.Parameters.AddWithValue("@CourseId", aStudentResult.CourseId);
                SqlDataReader ResultReader = command.ExecuteReader();
                while (ResultReader.Read())
                {
                    StudentResult studentResult = new StudentResult();
                    studentResult.RegistationNo = ResultReader[0].ToString();
                    studentResult.DepartmentId = Convert.ToInt16(ResultReader[1].ToString());
                    studentResult.CourseId = Convert.ToInt16(ResultReader[2].ToString());
                    studentResult.GradeLetter = ResultReader[3].ToString();
                    studentResult.Status = Convert.ToInt16(ResultReader[4].ToString());
                    aStudentResults.Add(studentResult);
                }
                return aStudentResults;
               
            }
       
            finally
            {
                connection.Close(); 
            }

           
           
        }

        public bool DeletePreviousReselt(StudentResult aStudentResult)
        {
            try
            {
                connection.Open();
                string query = "delete from t_Result Where RegistationNo=@regNo And CourseId=@CourseId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", aStudentResult.RegistationNo);
                command.Parameters.AddWithValue("@CourseId", aStudentResult.CourseId);
                command.ExecuteNonQuery();
                
                return true;
            }

            finally
            {
                connection.Close();
            }
          

        }

        public List<ViewCourseGradeAndCredit> GetCourseResult(string regNo)
        {
            try
            {
                int serialNo = 1;
                List<ViewCourseGradeAndCredit> viewCourseGradeAndCreditList = new List<ViewCourseGradeAndCredit>();
                connection.Open();
                string query = "select e.registationNo,c.courseTitle,c.credit,r.gradeLetter from t_course c join t_StudentCourseEnroll e  on(c.courseId=e.courseId) left outer join t_result r on(e.courseId=r.courseId) WHERE e.RegistationNo=@regNo";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", regNo);

                SqlDataReader resultReader = command.ExecuteReader();
                while (resultReader.Read())
                {
                    ViewCourseGradeAndCredit aViewCourseGradeAndCredit = new ViewCourseGradeAndCredit();
                    aViewCourseGradeAndCredit.CourseId = serialNo;
                    aViewCourseGradeAndCredit.CourseName = resultReader[1].ToString();
                    aViewCourseGradeAndCredit.Credit = float.Parse(resultReader[2].ToString());
                    if (resultReader[3].ToString() == "")
                        aViewCourseGradeAndCredit.GradeLetter = "On Going..";
                    else
                        aViewCourseGradeAndCredit.GradeLetter = resultReader[3].ToString();
                    viewCourseGradeAndCreditList.Add(aViewCourseGradeAndCredit);
                    serialNo++;
                }
               
                return viewCourseGradeAndCreditList;
            }
           
            finally
            {
                connection.Close(); 
            }

           
        }
    }
}