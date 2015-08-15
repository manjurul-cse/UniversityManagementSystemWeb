using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class CourseGateway : DBGateway
    {




        public string SaveCourse(Course aCourse)
        {
            try
            {
                connection.Open();
                string courseQuery = "INSERT INTO t_Course VALUES(@code,@title,@credit,@description,@semester,@deptCode,@status)";
                command.CommandText = courseQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@code", aCourse.CourseCode);
                command.Parameters.AddWithValue("@title", aCourse.CourseName);
                command.Parameters.AddWithValue("@credit", aCourse.Credit);
                command.Parameters.AddWithValue("@description", aCourse.Description);
                command.Parameters.AddWithValue("@semester", aCourse.ASemester.SemesterId);
                command.Parameters.AddWithValue("@deptcode", aCourse.ADepartment.DepartmentId);
                command.Parameters.AddWithValue("@status", aCourse.CourseStatus);
                command.ExecuteNonQuery();
                return "Saved";
            }
            finally
            {
                connection.Close();
            }



        }

        public List<Course> GetAllCourses()
        {

            try
            {
                List<Course> courses = new List<Course>();
                connection.Open();
                string query = "SELECT * FROM T_COURSE";
                command.CommandText = query;
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseId = Convert.ToInt16(courseReader[0].ToString());
                    aCourse.CourseCode = courseReader[1].ToString();
                    aCourse.CourseName = courseReader[2].ToString();
                    aCourse.Credit = float.Parse(courseReader[3].ToString());
                    aCourse.Description = courseReader[4].ToString();
                    aCourse.ASemester = new Semester();
                    aCourse.ADepartment = new Department();
                    aCourse.ASemester.SemesterId = Convert.ToInt16(courseReader[5].ToString());
                    aCourse.ADepartment.DepartmentId = Convert.ToInt16(courseReader[6].ToString());
                    aCourse.CourseStatus = Convert.ToInt16(courseReader[7].ToString());
                    courses.Add(aCourse);


                }
                return courses;
            }


            finally
            {
                connection.Close();
            }
        }





        public List<Course> GetAllCoursesByDepartment(int departmentId, int semesteId)
        {
            try
            {
                List<Course> courses = new List<Course>();
                connection.Open();
                int status = 0;
                string query = "SELECT * FROM T_COURSE WHERE departmentId=@deptId AND semesterId=@semeId AND courseStatus=@status";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@deptId", departmentId);
                command.Parameters.AddWithValue("@semeId", semesteId);
                command.Parameters.AddWithValue("@status", status);
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseId = Convert.ToInt16(courseReader[0].ToString());
                    aCourse.CourseCode = courseReader[1].ToString();
                    aCourse.CourseName = courseReader[2].ToString();
                    aCourse.Credit = float.Parse(courseReader[3].ToString());
                    aCourse.Description = courseReader[4].ToString();
                    aCourse.ASemester = new Semester();
                    aCourse.ADepartment = new Department();
                    aCourse.ASemester.SemesterId = Convert.ToInt16(courseReader[5].ToString());
                    aCourse.ADepartment.DepartmentId = Convert.ToInt16(courseReader[6].ToString());
                    aCourse.CourseStatus = Convert.ToInt16(courseReader[7].ToString());
                    courses.Add(aCourse);
                }
                return courses;
            }
            finally
            {
                connection.Close();
            }


        }

        public List<Course> GetAllUnassignedCourses(Course aCourse)
        {

            try
            {
                connection.Open();
                List<Course> courses = new List<Course>();
                string query = "SELECT courseCode,courseTitle,credit,courseDescription FROM t_Course WHERE CourseStatus=@courseStatus AND DepartmentId=@departmentId AND SemesterId=@semesterId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@courseStatus", aCourse.CourseStatus);
                command.Parameters.AddWithValue("@departmentId", aCourse.ADepartment.DepartmentId);
                command.Parameters.AddWithValue("@semesterId", aCourse.ASemester.SemesterId);
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    Course course = new Course();
                    course.CourseCode = courseReader[0].ToString();
                    course.CourseName = courseReader[1].ToString();
                    course.Credit = Convert.ToDouble(courseReader[2].ToString());
                    course.Description = courseReader[3].ToString();
                    courses.Add(course);
                }

                return courses;
            }
            finally
            {
                connection.Close();
            }


        }



        public List<int> GetScheduleCoursesId(Course aCourse)
        {
            try
            {
                int scheduleStatus = 0;
                connection.Open();
                List<int> coursesId = new List<int>();
                string query = "SELECT DISTINCT(courseId) FROM t_ScheduleClass WHERE DepartmentId=@departmentId AND SemesterId=@semesterId and ScheduleStatus=@status";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@departmentId", aCourse.ADepartment.DepartmentId);
                command.Parameters.AddWithValue("@semesterId", aCourse.ASemester.SemesterId);
                command.Parameters.AddWithValue("@status", scheduleStatus);

                SqlDataReader courseIdReader = command.ExecuteReader();
                while (courseIdReader.Read())
                {
                    coursesId.Add(Convert.ToInt16(courseIdReader[0]));
                }

                return coursesId;
            }
            finally
            {
                connection.Close();
            }


        }


        public List<ShowCourse> GetScheduleCoursesByDepartmentId(int departmentId)
        {
            try
            {
                connection.Open();
                int scheduleStatus = 0;
                List<ShowCourse> showCourses = new List<ShowCourse>();
                string query = "select distinct(courseCode), courseTitle,Credit,semesterName,nameOfTheday,startTime,endingTime,roomName,buildingName,name from v_Courses WHERE DepartmentId=@departmentId and ScheduleStatus=@status order by courseCode";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@departmentId", departmentId);
                command.Parameters.AddWithValue("@status", scheduleStatus);
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    string schedule = "";
                    ShowCourse aShowCourse = new ShowCourse();
                    aShowCourse.courseCode = courseReader[0].ToString();
                    aShowCourse.courseName = courseReader[1].ToString();
                    aShowCourse.credit = Convert.ToDouble(courseReader[2].ToString());


                    aShowCourse.semesterName = courseReader[3].ToString();
                    schedule = schedule + courseReader[4].ToString() + ",";
                    schedule += courseReader[5].ToString() + " to";
                    string endTime = courseReader[6].ToString();
                    if (endTime.Length > 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (Convert.ToInt16(endTime[3].ToString()) < 9 && i == 3)
                                schedule += "9";
                            else
                                schedule += endTime[i];
                        }
                    }
                    schedule += ",";
                    schedule += courseReader[7].ToString() + ",";
                    schedule += courseReader[8].ToString() + "/";
                    aShowCourse.schedule = schedule;
                    aShowCourse.teacherName = courseReader[9].ToString() == "" ? "Not Assign" : courseReader[9].ToString();

                    showCourses.Add(aShowCourse);
                }

                return showCourses;
            }

            finally
            {
                connection.Close();
            }


        }

        public string ResetCourseScheduleAndUnassignedAllCourse()
        {
            try
            {
                ResetAssignedCourses();
                ResetCourseSchedule();
                ResetUnassignedTeacherCourses();
                TeacherGateway aTeacherGateway = new TeacherGateway();
                aTeacherGateway.UpdateTeacherCredit();
                DeleteTeacherSchedule();
                return "Unassigned & Unschedule All courses";
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }



        private void DeleteTeacherSchedule()
        {
            try
            {
                connection.Open();
                string query = "delete from t_CourseAssignToTeacher";
                command.CommandText = query;
                command.ExecuteNonQuery();

            }

            finally
            {
                connection.Close();
            }


        }

        private void ResetUnassignedTeacherCourses()
        {

            try
            {
                int status = 1;
                connection.Open();
                string query = "UPDATE t_CourseAssignToTeacher SET Status=@status";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();

            }
            finally
            {
                connection.Close();
            }

        }

        private void ResetCourseSchedule()
        {
            try
            {
                connection.Open();
                int status = 1;
                string query = "UPDATE t_ScheduleClass SET scheduleStatus=@status";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }


        }



        private void ResetAssignedCourses()
        {
            try
            {
                int status = 0;
                connection.Open();
                string query = "UPDATE t_Course SET courseStatus=@status";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }


        }

        public List<ShowCourse> GetScheduleCoursesByDepartmentIdAndSemester(int departmentId, int semesterId)
        {
            try
            {
                connection.Open();
                int scheduleStatus = 0;
                List<ShowCourse> showCourses = new List<ShowCourse>();
                string query = "select distinct(courseCode), courseTitle,Credit,semesterName,nameOfTheday,startTime,endingTime,roomName,buildingName,name from v_Courses WHERE DepartmentId=@departmentId and SemesterId=@semesterId AND ScheduleStatus=@status order by courseCode";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@departmentId", departmentId);
                command.Parameters.AddWithValue("@semesterId", semesterId);
                command.Parameters.AddWithValue("@status", scheduleStatus);
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    string schedule = "";
                    ShowCourse aShowCourse = new ShowCourse();
                    aShowCourse.courseCode = courseReader[0].ToString();
                    aShowCourse.courseName = courseReader[1].ToString();
                    aShowCourse.credit = Convert.ToDouble(courseReader[2].ToString());
                    aShowCourse.semesterName = courseReader[3].ToString();
                    schedule = schedule + courseReader[4].ToString() + ",";
                    schedule += courseReader[5].ToString() + " to";
                    string endTime = courseReader[6].ToString();

                    if (endTime.Length > 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (Convert.ToInt16(endTime[3].ToString()) < 9 && i == 3)
                                schedule += "9";
                            else
                                schedule += endTime[i];
                        }
                    }
                    schedule += ",";
                    schedule += courseReader[7].ToString() + ",";
                    schedule += courseReader[8].ToString() + "/";
                    aShowCourse.schedule = schedule;
                    aShowCourse.teacherName = courseReader[9].ToString();
                    showCourses.Add(aShowCourse);
                }

                return showCourses;

            }

            finally
            {
                connection.Close();
            }


        }



        public List<Course> GetCoursesByDepartment(ViewStudentInformation aViewStudentInformation)
        {
            try
            {
                List<Course> courses = new List<Course>();
                connection.Open();
                string query = "SELECT * FROM T_COURSE where DepartmentId=@departmentId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@departmentId", aViewStudentInformation.DepartmentId);
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseId = Convert.ToInt16(courseReader[0].ToString());
                    aCourse.CourseCode = courseReader[1].ToString();
                    aCourse.CourseName = courseReader[2].ToString();
                    aCourse.Credit = float.Parse(courseReader[3].ToString());
                    aCourse.Description = courseReader[4].ToString();
                    aCourse.ASemester = new Semester();
                    aCourse.ADepartment = new Department();
                    aCourse.ASemester.SemesterId = Convert.ToInt16(courseReader[5].ToString());
                    aCourse.ADepartment.DepartmentId = Convert.ToInt16(courseReader[6].ToString());
                    aCourse.CourseStatus = Convert.ToInt16(courseReader[7].ToString());
                    courses.Add(aCourse);

                }

                return courses;
            }

            finally
            {
                connection.Close();
            }


        }

        public List<Course> GetCoursesByDepartment()
        {
            try
            {
                List<Course> courses = new List<Course>();
                connection.Open();
                string query = "SELECT * FROM T_COURSE";
                command.CommandText = query;
                SqlDataReader courseReader = command.ExecuteReader();
                while (courseReader.Read())
                {
                    Course aCourse = new Course();
                    aCourse.CourseId = Convert.ToInt16(courseReader[0].ToString());
                    aCourse.CourseCode = courseReader[1].ToString();
                    aCourse.CourseName = courseReader[2].ToString();
                    aCourse.Credit = float.Parse(courseReader[3].ToString());
                    aCourse.Description = courseReader[4].ToString();
                    aCourse.ASemester = new Semester();
                    aCourse.ADepartment = new Department();
                    aCourse.ASemester.SemesterId = Convert.ToInt16(courseReader[5].ToString());
                    aCourse.ADepartment.DepartmentId = Convert.ToInt16(courseReader[6].ToString());
                    aCourse.CourseStatus = Convert.ToInt16(courseReader[7].ToString());
                    courses.Add(aCourse);

                }
               
                return courses;
            }
       
            finally
            {
                connection.Close();   
            }

           

        }
    }
}