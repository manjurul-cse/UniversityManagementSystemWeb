using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class ScheduleManager
    {
        private ScheduleGateway aScheduleGateway;
        public List<Day> GetAllDays()
        {
            aScheduleGateway = new ScheduleGateway();
            return aScheduleGateway.GetAllDays();
        }

        public List<Building> GetAllBuildings()
        {
            aScheduleGateway = new ScheduleGateway();
            return aScheduleGateway.GetAllBuildings();
        }

        public List<Room> GetAllRooms(int buildingId)
        {
            aScheduleGateway = new ScheduleGateway();
            return aScheduleGateway.GetAllRooms(buildingId);
        }
        public string SaveClassSchedule(Schedule aSchedule)
        {
            aScheduleGateway = new ScheduleGateway();
            
            if (!CheckRoomAndTimeScheduleOverlap(aSchedule))
                if (!CheckDepartmentAndSubjectOverlap(aSchedule))
                    return aScheduleGateway.SaveClassSchedule(aSchedule);
                else
                    return "Violation of Department or semester ";
            else
                return "Violation of Room or Time or day or building";
         
        }



        private bool CheckDepartmentAndSubjectOverlap(Schedule aSchedule)
        {
            aScheduleGateway = new ScheduleGateway();
            int status = aScheduleGateway.CheckDepartmentAndSubjectOverlap(aSchedule);
            if (status > 0)
                return true;
            return false;
        }

        private bool CheckRoomAndTimeScheduleOverlap(Schedule aSchedule)
        {
            aScheduleGateway = new ScheduleGateway();
            int status = aScheduleGateway.CheckRoomAndTimeScheduleOverlap(aSchedule);
            if (status > 0)
                return true;
            return false;
        }
    }
}