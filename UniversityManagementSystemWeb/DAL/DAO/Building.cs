using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Building
    {
        private int buildingId;
        private string buildingName;

        public int BuildingId
        {
            get { return buildingId; }
            set { buildingId = value; }
        }

        public string BuildingName
        {
            get { return buildingName; }
            set { buildingName = value; }
        }
    }
}