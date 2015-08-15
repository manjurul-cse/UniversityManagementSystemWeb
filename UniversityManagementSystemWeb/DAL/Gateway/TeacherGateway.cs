using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class TeacherGateway : DBGateway
    {


        public string SaveTeacher(Teacher aTeacher)
        {
            try
            {
                connection.Open();
                string addTeacherQuery =
                    "INSERT INTO t_Teacher VALUES(@id,@name,@address,@email,@contactNo,@designation,@assignCredit,@deptCode)";
                command.CommandText = addTeacherQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", aTeacher.TeacherId);
                command.Parameters.AddWithValue("@name", aTeacher.Name);
                command.Parameters.AddWithValue("@address", aTeacher.Address);
                command.Parameters.AddWithValue("@email", aTeacher.Email);
                command.Parameters.AddWithValue("@contactNo", aTeacher.ContactNo);
                command.Parameters.AddWithValue("@designation", aTeacher.ADesignation.Id);
                command.Parameters.AddWithValue("@assignCredit", aTeacher.AssignCredit);
                command.Parameters.AddWithValue("@deptCode", aTeacher.ADepartment.DepartmentId);
                command.ExecuteNonQuery();

                return aTeacher.TeacherId;
            }


            finally
            {
                connection.Close();
                SaveTeacherCredit(aTeacher);
            }




        }

        private void SaveTeacherCredit(Teacher aTeacher)
        {
            try
            {
                connection.Open();
                float assignCredit = 0;
                int status = 0;
                string addTeacherQuery = "INSERT INTO t_TeacherCredit VALUES(@id,@assignCredit,@remaningCredit,@status)";
                command.CommandText = addTeacherQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", aTeacher.TeacherId);
                command.Parameters.AddWithValue("@assignCredit", assignCredit);
                command.Parameters.AddWithValue("@remaningCredit", aTeacher.AssignCredit);
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public int GetTeacherId(int departmentId)
        {
            try
            {
                connection.Open();
                int id = 1;
                string departmentQuery = "SELECT COUNT(*) FROM t_Teacher WHERE departmentId= @id ";
                command.CommandText = departmentQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", departmentId);
                SqlDataReader departmentReader = command.ExecuteReader();
                while (departmentReader.Read())
                {
                    id = id + Convert.ToInt16(departmentReader[0].ToString());

                }

                return id;
            }
            finally
            {
                connection.Close();
            }



        }

        public List<Teacher> GetAllTeachers(int departmentId)
        {
            try
            {
                connection.Open();
                List<Teacher> teachers = new List<Teacher>();
                string query = "SELECT * FROM t_Teacher where departmentId=@id ";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", departmentId);
                SqlDataReader teacherReader = command.ExecuteReader();
                while (teacherReader.Read())
                {
                    Teacher aTeacher = new Teacher();
                    aTeacher.TeacherId = teacherReader[0].ToString();
                    aTeacher.Name = teacherReader[1].ToString();
                    aTeacher.Address = teacherReader[2].ToString();
                    aTeacher.Email = teacherReader[3].ToString();
                    aTeacher.ContactNo = teacherReader[4].ToString();
                    aTeacher.ADesignation = new Designation();
                    aTeacher.ADepartment = new Department();
                    aTeacher.ADesignation.Id = Convert.ToInt16(teacherReader[5].ToString());
                    aTeacher.AssignCredit = float.Parse(teacherReader[6].ToString());
                    aTeacher.ADepartment.DepartmentId = Convert.ToInt16(teacherReader[7].ToString());
                    teachers.Add(aTeacher);


                }
                return teachers;
            }
            finally
            {
                connection.Close();
            }



        }

        public Teacher GetTeacher(Teacher aTeacher)
        {
            connection.Open();
            Teacher teacher = new Teacher();
            string query = "select * from t_Teacher where teacherId=@id and departmentId=@deptId";
            command.CommandText = query;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@id", aTeacher.TeacherId);
            command.Parameters.AddWithValue("@deptId", aTeacher.ADepartment.DepartmentId);
            SqlDataReader teacherReader = command.ExecuteReader();
            while (teacherReader.Read())
            {
                teacher.TeacherId = teacherReader[0].ToString();
                teacher.Name = teacherReader[1].ToString();
                teacher.Address = teacherReader[2].ToString();
                teacher.Email = teacherReader[3].ToString();
                teacher.ContactNo = teacherReader[4].ToString();
                teacher.ADesignation = new Designation();
                teacher.ADepartment = new Department();
                teacher.ADesignation.Id = Convert.ToInt16(teacherReader[5].ToString());
                teacher.AssignCredit = float.Parse(teacherReader[6].ToString());
                teacher.ADepartment.DepartmentId = Convert.ToInt16(teacherReader[7].ToString());



            }
            connection.Close();
            return teacher;
        }

        public Teacher GetTeacherCreditInfo(Teacher aTeacher)
        {
            try
            {

                connection.Open();
                Teacher teacher = new Teacher();
                string query = "select * from t_TeacherCredit where teacherId=@id";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", aTeacher.TeacherId);
                SqlDataReader teacherReader = command.ExecuteReader();
                while (teacherReader.Read())
                {
                    teacher.TeacherId = teacherReader[0].ToString();
                    teacher.AssignCredit = float.Parse(teacherReader[1].ToString());
                    teacher.RemaningCredit = float.Parse(teacherReader[2].ToString());
                }

                return teacher;
            }
            finally
            {
                connection.Close();
            }

        }

        public string SaveTeacerCourse(TeacherCourse aTeacherCourse, float credit)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO t_CourseAssignToTeacher VALUES(@deptId,@teacherId,@courseId,@assignDate,@status)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@deptId", aTeacherCourse.DepartmentId);
                command.Parameters.AddWithValue("@teacherId", aTeacherCourse.TeacherId);
                command.Parameters.AddWithValue("@courseId", aTeacherCourse.CourseId);
                command.Parameters.AddWithValue("@assignDate", aTeacherCourse.AssignDate);
                command.Parameters.AddWithValue("@status", aTeacherCourse.Status);
                command.ExecuteNonQuery();
                return "Saved";
            }
            finally
            {
                connection.Close();
                UpdateCourseStatus(aTeacherCourse);
                UpdateTeacherCredit(aTeacherCourse, credit);

            }
        }

        private void UpdateTeacherCredit(TeacherCourse aTeacherCourse, float credit)
        {

            try
            {
                Teacher aTeacher = new Teacher();
                aTeacher.TeacherId = aTeacherCourse.TeacherId;
                aTeacher.ADepartment = new Department();
                aTeacher.ADepartment.DepartmentId = aTeacherCourse.DepartmentId;
                aTeacher = GetTeacherCreditInfo(aTeacher);
                aTeacher.AssignCredit = Convert.ToDouble(aTeacher.AssignCredit) + credit;
                aTeacher.RemaningCredit = Convert.ToDouble(aTeacher.RemaningCredit) - credit;
                connection.Open();
                string query = "UPDATE t_TeacherCredit SET AssignCredit =@assignCredit,RemainingCredit=@remainingCredit Where teacherId =@teacherId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@assignCredit", aTeacher.AssignCredit);
                command.Parameters.AddWithValue("@remainingCredit", aTeacher.RemaningCredit);
                command.Parameters.AddWithValue("@teacherId", aTeacherCourse.TeacherId);
                command.ExecuteNonQuery();
            }

            finally
            {
                connection.Close();

            }



        }

        private void UpdateCourseStatus(TeacherCourse aTeacherCourse)
        {
            try
            {
                connection.Open();
                int courseStatus = 1;
                string query = "UPDATE t_Course SET CourseStatus =@status Where CourseId =@courseId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", courseStatus);
                command.Parameters.AddWithValue("@courseId", aTeacherCourse.CourseId);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public List<int> GetTeacherAssignCoursesId(TeacherCourse aTeacherCourse)
        {

            try
            {
                connection.Open();
                List<int> coursesId = new List<int>();
                string query = "SELECT courseId from t_CourseAssignToTeacher where teacherId=@teacherId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@teacherId", aTeacherCourse.TeacherId);
                SqlDataReader courseIdDataReader = command.ExecuteReader();
                while (courseIdDataReader.Read())
                {
                    coursesId.Add(Convert.ToInt16(courseIdDataReader[0]));

                }
                return coursesId;

            }
            finally
            {
                connection.Close();
            }
        }

        public List<string> GetAllEmails()
        {
            try
            {
                connection.Open();
                List<string> emails = new List<string>();
                string query = "SELECT email FROM t_Teacher";
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

        public void UpdateTeacherCredit()
        {
            List<Teacher> teachersId = new List<Teacher>();
            try
            {
                connection.Open();
                string query = "select teacherId,assignCredit from t_Teacher";
                command.CommandText = query;
                SqlDataReader idReader = command.ExecuteReader();
                while (idReader.Read())
                {
                    Teacher aTeacher = new Teacher();
                    aTeacher.TeacherId = idReader[0].ToString();
                    aTeacher.AssignCredit = double.Parse(idReader[1].ToString());
                    teachersId.Add(aTeacher);
                }
            }

            finally
            {
                connection.Close();
                UpdateCredit(teachersId);
            }
        }

        private void UpdateCredit(List<Teacher> teachersId)
        {
            float assignCredit = 0;
            foreach (Teacher teacher in teachersId)
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE t_TeacherCredit SET AssignCredit =@assignCredit,RemainingCredit=@remainingCredit Where teacherId =@teacherId";
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@assignCredit", assignCredit);
                    command.Parameters.AddWithValue("@remainingCredit", teacher.AssignCredit);
                    command.Parameters.AddWithValue("@teacherId", teacher.TeacherId);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }


            }
        }
    }
}