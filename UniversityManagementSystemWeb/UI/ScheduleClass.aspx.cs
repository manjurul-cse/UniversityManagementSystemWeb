using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.Manager;

namespace UniversityManagementSystemWeb.UI
{
    public partial class ScheduleClass : System.Web.UI.Page
    {
        private DepartmentManager aDepartmentManager;
        private ScheduleManager aScheduleManager;
        private CourseManager aCourseManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";

            try
            {
                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                semesterDropDownList.DataTextField = "SemesterName";
                semesterDropDownList.DataValueField = "SemesterId";
                dayDropDownList.DataTextField = "dayName";
                dayDropDownList.DataValueField = "dayId";
                buildingDropDownList.DataTextField = "buildingName";
                buildingDropDownList.DataValueField = "buildingId";
                courseDropDownList.DataTextField = "courseCode";
                courseDropDownList.DataValueField = "courseId";
                roomDropDownList.DataTextField = "roomName";
                roomDropDownList.DataValueField = "roomId";

                if (!IsPostBack)
                {

                    List<Course> courses = new List<Course>();
                    List<Day> days = new List<Day>();
                    List<Department> departments = new List<Department>();
                    List<Semester> semester = new List<Semester>();
                    List<Building> buildings = new List<Building>();
                    aDepartmentManager = new DepartmentManager();
                    departments = aDepartmentManager.GetAllDepartments();
                    SemesterManager aSemesterManager = new SemesterManager();
                    semester = aSemesterManager.GetAllSemesters();
                    aScheduleManager = new ScheduleManager();
                    buildings = aScheduleManager.GetAllBuildings();
                    days = aScheduleManager.GetAllDays();
                    aCourseManager = new CourseManager();
                    courses = aCourseManager.GetAllCourses();
                    dayDropDownList.DataSource = days;
                    dayDropDownList.DataBind();
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();
                    semesterDropDownList.DataSource = semester;
                    semesterDropDownList.DataBind();
                    buildingDropDownList.DataSource = buildings;
                    buildingDropDownList.DataBind();
                    courseDropDownList.DataSource = courses;
                    courseDropDownList.DataBind();
                }
            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = exception.Message;
            }

           
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if(!IsValid)
            {return;}

            try
            {
                Schedule aSchedule = new Schedule();
                aScheduleManager = new ScheduleManager();
                aSchedule.Scheduledate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                aSchedule.DepartmentId = Convert.ToInt16(departmentDropDownList.Text);
                aSchedule.SemesterId = Convert.ToInt16(semesterDropDownList.Text);
                aSchedule.CourseId = Convert.ToInt16(courseDropDownList.Text);
                aSchedule.BuildingId = Convert.ToInt16(buildingDropDownList.Text);
                aSchedule.RoomId = roomDropDownList.Text;
                aSchedule.StartTime = float.Parse(startTimeDropDownList.Text);
                aSchedule.EndingTime = float.Parse(endingTimeDropDownList.Text);
                aSchedule.DayId = Convert.ToInt16(dayDropDownList.Text);
                aSchedule.ScheduleStatus = 0;
                string msg = aScheduleManager.SaveClassSchedule(aSchedule);
                if (msg == "Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text = msg;
                }
                else
                {
                    msgLabel.ForeColor = Color.Red;
                    msgLabel.Text = msg;
                }
            }

            catch (SqlException sqlException)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Database error.See details error: " + sqlException.Message;

            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                string errorMessage = "Unknow error occured.";
                errorMessage += exception.Message;
                if (exception.InnerException != null)
                {
                    errorMessage += exception.InnerException.Message;
                }
                msgLabel.Text = errorMessage;
            }
        }

        protected void semesterDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CourseManager aCourseManager = new CourseManager();
                int departmentId = Convert.ToInt16(departmentDropDownList.Text);
                int semesteId = Convert.ToInt16(semesterDropDownList.Text);
                List<Course> courses = new List<Course>();
                courses = aCourseManager.GetAllCoursesByDepartment(departmentId, semesteId);
                courseDropDownList.DataSource = courses;
                courseDropDownList.DataBind();
            }

            catch (SqlException sqlException)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Database error.See details error: " + sqlException.Message;

            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                string errorMessage = "Unknow error occured.";
                errorMessage += exception.Message;
                if (exception.InnerException != null)
                {
                    errorMessage += exception.InnerException.Message;
                }
                msgLabel.Text = errorMessage;
            }
           

        }

        protected void buildingDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Room> rooms = new List<Room>();
                aScheduleManager = new ScheduleManager();
                rooms = aScheduleManager.GetAllRooms(Convert.ToInt16(buildingDropDownList.Text));
                roomDropDownList.DataSource = rooms;
                roomDropDownList.DataBind();
            }
            catch (SqlException sqlException)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Database error.See details error: " + sqlException.Message;

            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                string errorMessage = "Unknow error occured.";
                errorMessage += exception.Message;
                if (exception.InnerException != null)
                {
                    errorMessage += exception.InnerException.Message;
                }
                msgLabel.Text = errorMessage;
            }

           
        }
    }
}