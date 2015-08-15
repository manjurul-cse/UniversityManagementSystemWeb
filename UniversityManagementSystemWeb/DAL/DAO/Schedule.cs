using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Schedule
    {
        private int scheduleId;
        private DateTime scheduledate;
        private int departmentId;
        private int semesterId;
        private int courseId;
        private int buildingId;
        private string roomId;
        private float startTime;
        private float endingTime;
        private int dayId;
        private int scheduleStatus;

        public int ScheduleId
        {
            get { return scheduleId; }
            set { scheduleId = value; }
        }

        public DateTime Scheduledate
        {
            get { return scheduledate; }
            set { scheduledate = value; }
        }

        public int DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        public int SemesterId
        {
            get { return semesterId; }
            set { semesterId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public int BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }

        public string RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }

        public float StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public float EndingTime
        {
            get { return endingTime; }
            set { endingTime = value; }
        }

        public int DayId
        {
            get { return dayId; }
            set { dayId = value; }
        }

        public int ScheduleStatus
        {
            get { return scheduleStatus; }
            set { scheduleStatus = value; }
        }
    }
}