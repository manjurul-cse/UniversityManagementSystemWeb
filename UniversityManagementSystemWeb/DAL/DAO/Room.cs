using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Room
    {
        private string roomId;
        private string roomName;
        private int buildingId;

        public string RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }

        public int BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }
    }
}