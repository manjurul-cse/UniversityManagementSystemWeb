using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class ScheduleGateway : DBGateway
    {
        public List<Day> GetAllDays()
        {
            try
            {
                List<Day> days = new List<Day>();
                connection.Open();
                string query = "SELECT * from t_Day";
                command.CommandText = query;
                SqlDataReader dayReader = command.ExecuteReader();
                while (dayReader.Read())
                {
                    Day aDay = new Day();
                    aDay.DayId = Convert.ToInt16(dayReader[0]);
                    aDay.DayName = dayReader[1].ToString();
                    days.Add(aDay);
                }
               
                return days;

            }
        
            finally
            {
                connection.Close();   
            }

          
        }

        public List<Building> GetAllBuildings()
        {

            try
            {
                List<Building> buildings = new List<Building>();
                connection.Open();
                string query = "SELECT * FROM t_Building";
                command.CommandText = query;
                SqlDataReader buildingReader = command.ExecuteReader();
                while (buildingReader.Read())
                {
                    Building aBuilding = new Building();
                    aBuilding.BuildingId = Convert.ToInt16(buildingReader[0].ToString());
                    aBuilding.BuildingName = buildingReader[1].ToString();
                    buildings.Add(aBuilding);
                }
               
                return buildings;
            }
     
            finally
            {
                connection.Close();  
            }
           
        }

        public List<Room> GetAllRooms(int buildingId)
        {

            try
            {
                List<Room> rooms = new List<Room>();
                connection.Open();
                string query = "SELECT * FROM t_Room where buildingId=@buildingId";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("buildingId", buildingId);
                SqlDataReader roomReader = command.ExecuteReader();
                while (roomReader.Read())
                {
                    Room aRoom = new Room();
                    aRoom.RoomId = roomReader[0].ToString();
                    aRoom.RoomName = roomReader[1].ToString();
                    aRoom.BuildingId = Convert.ToInt16(roomReader[2]);
                    rooms.Add(aRoom);
                }
                
                return rooms;
            }
       finally
            {
                connection.Close();   
            }


           
        }

        public string SaveClassSchedule(Schedule aSchedule)
        {

            try
            {
                connection.Open();
                string query = "INSERT INTO t_ScheduleClass VALUES(@date,@departmentId,@semesterId,@courseId,@buildingId,@roomId,@fromTime,@toTime,@dayId,@status)";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@date", aSchedule.Scheduledate);
                command.Parameters.AddWithValue("@departmentId", aSchedule.DepartmentId);
                command.Parameters.AddWithValue("@semesterId", aSchedule.SemesterId);
                command.Parameters.AddWithValue("@courseId", aSchedule.CourseId);
                command.Parameters.AddWithValue("@buildingId", aSchedule.BuildingId);
                command.Parameters.AddWithValue("@roomId", aSchedule.RoomId);
                command.Parameters.AddWithValue("@fromTime", aSchedule.StartTime);
                command.Parameters.AddWithValue("@toTime", aSchedule.EndingTime);
                command.Parameters.AddWithValue("@dayId", aSchedule.DayId);
                command.Parameters.AddWithValue("@status", aSchedule.ScheduleStatus);
                command.ExecuteNonQuery();
                return "Saved";
            }

            finally
            {
                connection.Close();
            }

        }


        public int CheckRoomAndTimeScheduleOverlap(Schedule aSchedule)
        {

            try
            {
                int status = 0;
                int scheduleStatus = 0;
                connection.Open();
                string query = "SELECT count(*) FROM t_ScheduleClass WHERE ScheduleStatus=@status and (BuildingId=@buildingId AND RoomId=@roomId AND DayId=@dayId)AND((StartTime<=@startTime AND EndingTime>=@startTime)or(StartTime<=@endingTime AND EndingTime>=@endingTime))";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", scheduleStatus);
                command.Parameters.AddWithValue("@buildingId", aSchedule.BuildingId);
                command.Parameters.AddWithValue("@roomId", aSchedule.RoomId);
                command.Parameters.AddWithValue("@dayId", aSchedule.DayId);
                command.Parameters.AddWithValue("@startTime", aSchedule.StartTime);
                command.Parameters.AddWithValue("@endingTime", aSchedule.EndingTime);
                SqlDataReader scheduleReader = command.ExecuteReader();
                while (scheduleReader.Read())
                {
                    if (Convert.ToInt16(scheduleReader[0].ToString()) != 0)
                        status++;
                }

                return status;
            }


            finally
            {
                connection.Close();
            }


        }

        public int CheckDepartmentAndSubjectOverlap(Schedule aSchedule)
        {
            try
            {
                int status = 0;
                connection.Open();
                int scheduleStatus = 0;
                string query = "SELECT count(*) FROM t_ScheduleClass WHERE ScheduleStatus=@status and (DepartmentId=@deptId AND SemesterId=@semId AND DayId=@dayId)AND((StartTime<=@startTime AND EndingTime>=@startTime)or(StartTime<=@endingTime AND EndingTime>=@endingTime))";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@status", scheduleStatus);
                command.Parameters.AddWithValue("@deptId", aSchedule.DepartmentId);
                command.Parameters.AddWithValue("@semId", aSchedule.SemesterId);
                command.Parameters.AddWithValue("@dayId", aSchedule.DayId);
                command.Parameters.AddWithValue("@startTime", aSchedule.StartTime);
                command.Parameters.AddWithValue("@endingTime", aSchedule.EndingTime);
                SqlDataReader scheduleReader = command.ExecuteReader();
                while (scheduleReader.Read())
                {
                    if (Convert.ToInt16(scheduleReader[0].ToString()) != 0)
                        status++;
                }

                return status;
            }


            finally
            {
                connection.Close();
            }

        }


        public List<Schedule> GetTeacherAllSchedules(List<int> coursesId)
        {
            try
            {
                int scheduleStatus = 0;
                List<Schedule> schedules = new List<Schedule>();
                foreach (int courseId in coursesId)
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT dayId,startTime,endingTime FROM t_ScheduleClass WHERE CourseId=@courseId and ScheduleStatus=@status";
                        command.CommandText = query;
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("@courseId", courseId);
                        command.Parameters.AddWithValue("@status", scheduleStatus);
                        SqlDataReader teacherCourseScheduleReader = command.ExecuteReader();
                        while (teacherCourseScheduleReader.Read())
                        {
                            Schedule aSchedule = new Schedule();
                            aSchedule.DayId = Convert.ToInt16(teacherCourseScheduleReader[0].ToString());
                            aSchedule.StartTime = float.Parse(teacherCourseScheduleReader[1].ToString());
                            aSchedule.EndingTime = float.Parse(teacherCourseScheduleReader[2].ToString());
                            schedules.Add(aSchedule);
                        }

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                return schedules;
            }


            finally
            {
                connection.Close();
            }


        }

        public List<Schedule> GetCurrentCourseSchedules(TeacherCourse aTeacherCourse)
        {
            try
            {
                int scheduleStatus = 0;
                List<Schedule> schedules = new List<Schedule>();
                connection.Open();
                string query = "SELECT dayId,startTime,endingTime FROM t_ScheduleClass WHERE CourseId=@courseId and ScheduleStatus=@status";
                command.CommandText = query;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@courseId", aTeacherCourse.CourseId);
                command.Parameters.AddWithValue("@status", scheduleStatus);
                SqlDataReader teacherCourseScheduleReader = command.ExecuteReader();
                while (teacherCourseScheduleReader.Read())
                {
                    Schedule aSchedule = new Schedule();
                    aSchedule.DayId = Convert.ToInt16(teacherCourseScheduleReader[0].ToString());
                    aSchedule.StartTime = float.Parse(teacherCourseScheduleReader[1].ToString());
                    aSchedule.EndingTime = float.Parse(teacherCourseScheduleReader[2].ToString());
                    schedules.Add(aSchedule);
                }

                return schedules;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}