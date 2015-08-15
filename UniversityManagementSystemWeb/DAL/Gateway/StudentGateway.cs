using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class StudentGateway : DBGateway
    {
        public int GetStudentRegistationNO(Student aStudent)
        {
            try
            {
                connection.Open();
                int id = 1;
                string queryString = "select registationDate from t_StudentInfo where departmentId=@id";
                command.CommandText = queryString;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", aStudent.DepartmentId);

                SqlDataReader dateReader = command.ExecuteReader();
                while (dateReader.Read())
                {
                    if (Convert.ToDateTime(aStudent.RegistationDate.ToString()).ToString("yyyy") == Convert.ToDateTime(dateReader[0].ToString()).ToString("yyyy"))
                        id++;
                }
                return id;

            }
            finally
            {
                connection.Close();
            }



        }



        public string SaveStudent(Student aStudent)
        {

            try
            {
                connection.Open();
                string addStudentQuery = "insert into t_StudentInfo values(@regNo,@name,@email,@contactNo,@address,@registationDate,@deptId)";
                command.CommandText = addStudentQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", aStudent.RegistationNo);
                command.Parameters.AddWithValue("@name", aStudent.Name);
                command.Parameters.AddWithValue("@email", aStudent.Email);
                command.Parameters.AddWithValue("@contactNo", aStudent.ContactNo);
                command.Parameters.AddWithValue("@address", aStudent.Address);
                command.Parameters.AddWithValue("@registationDate", aStudent.RegistationDate);
                command.Parameters.AddWithValue("@deptId", aStudent.DepartmentId);
                command.ExecuteNonQuery();
                return "Saved";
            }

            finally
            {
                connection.Close();
                saveCertificates(aStudent);
            }
        }

        private void saveCertificates(Student aStudent)
        {
            foreach (Certificate aCertificate in aStudent.Certificates)
            {

                string id = GetExamId(aCertificate.ExaminationType);
                if (id != null)
                {

                    try
                    {
                        connection.Open();
                        string queryString = "insert into t_Certificate values(@grade,@cgpa,@certificateLocation,@examinationId,@registationNO)";
                        command.CommandText = queryString;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@grade", aCertificate.GradeLetter);
                        command.Parameters.AddWithValue("@cgpa", aCertificate.Cgpa);
                        command.Parameters.AddWithValue("@certificateLocation", aCertificate.CertificateLocation);
                        command.Parameters.AddWithValue("@examinationId", id);
                        command.Parameters.AddWithValue("@registationNo", aStudent.RegistationNo);
                        command.ExecuteNonQuery();
                    }

                    finally
                    {
                        connection.Close();
                    }




                }


            }
        }

        private string GetExamId(string examinationType)
        {
            List<Examination> examinations = new List<Examination>();
            ExaminationGateway anExaminationGateway = new ExaminationGateway();
            examinations = anExaminationGateway.GetAllExaminations();
            foreach (Examination aExamination in examinations)
            {
                if (aExamination.ExaminationType == examinationType)
                {
                    return aExamination.ExaminationId;
                }
            }
            return null;
        }

        public Student GetStudentInformation(string regNo, int depeartmentId)
        {
            try
            {
                Student aStudent = new Student();
                connection.Open();
                string departmentQuery = "select * from t_studentInfo where registationNo=@regNo and departmentId=@depeartmentId";
                command.CommandText = departmentQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", regNo);
                command.Parameters.AddWithValue("@depeartmentId", depeartmentId);
                SqlDataReader studentReader = command.ExecuteReader();
                while (studentReader.Read())
                {
                    aStudent.RegistationNo = studentReader[0].ToString();
                    aStudent.Name = studentReader[1].ToString();
                    aStudent.Email = studentReader[2].ToString();
                    aStudent.ContactNo = studentReader[3].ToString();
                    aStudent.Address = studentReader[4].ToString();
                    aStudent.DepartmentId = studentReader[6].ToString();
                }
                return aStudent;
            }
            finally
            {
                connection.Close();
            }
        }

        public ViewStudentInformation GetStudentInfo(string regNo)
        {

            try
            {
                connection.Open();
                string queryString = "select s.name,s.eamil,d.departmentName,s.departmentId from t_StudentInfo s join t_Department d on(s.departmentId=d.departmentId) where s.registationNo=@regNo";
                command.CommandText = queryString;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", regNo);
                ViewStudentInformation aViewStudentInformation = new ViewStudentInformation();
                SqlDataReader studentReader = command.ExecuteReader();
                while (studentReader.Read())
                {
                    aViewStudentInformation.Name = studentReader[0].ToString();
                    aViewStudentInformation.Email = studentReader[1].ToString();
                    aViewStudentInformation.DepartmentName = studentReader[2].ToString();
                    aViewStudentInformation.RegistationNo = regNo;
                    aViewStudentInformation.DepartmentId = Convert.ToInt16(studentReader[3]);
                }

                return aViewStudentInformation;
            }
            finally
            {
                connection.Close();
            }


        }

        public List<Course> GetStudentCourses(string regNo)
        {
            try
            {
                int serialNo = 1;
                connection.Open();
                string query =
                    "SELECT c.courseCode,c.courseTitle  FROM t_Course c join t_StudentCourseEnroll e on(c.courseId=e.courseId) where e.registationNo=@regNo";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", regNo);
                List<Course> aStudentCourses = new List<Course>();
                SqlDataReader studentCourseReader = command.ExecuteReader();
                while (studentCourseReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseCode = studentCourseReader[0].ToString();
                    aCourse.CourseName = studentCourseReader[1].ToString();
                    aCourse.CourseId = serialNo;
                    serialNo++;
                    aStudentCourses.Add(aCourse);

                }

                return aStudentCourses;

            }
            finally
            {
                connection.Close();
            }


        }

        public string SaveStudentCourse(StudentCourse aStudentCourse)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO t_StudentCourseEnroll VALUES(@regNo,@date,@courseId,@status)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@regNo", aStudentCourse.RegistrationNo);
                command.Parameters.AddWithValue("@date", aStudentCourse.EnrollDate);
                command.Parameters.AddWithValue("@courseId", aStudentCourse.CourseId);
                command.Parameters.AddWithValue("@status", aStudentCourse.Status);
                command.ExecuteNonQuery();
                return "Saved";
            }

            finally
            {
                connection.Close();
            }


        }



        public List<string> GetStudentEmails()
        {
            try
            {
                connection.Open();
                List<string> emails = new List<string>();
                string query = "SELECT eamil from t_StudentInfo";
                command.CommandText = query;
                SqlDataReader emailReader = command.ExecuteReader();
                while (emailReader.Read())
                {
                    emails.Add(emailReader[0].ToString());
                }

                return emails;
            }
            finally
            {
                connection.Close();
            }


        }
    }
}