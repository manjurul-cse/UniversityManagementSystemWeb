using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Day
    {
        private int dayId;
        private string dayName;

        public int DayId
        {
            get { return dayId; }
            set { dayId = value; }
        }

        public string DayName
        {
            get { return dayName; }
            set { dayName = value; }
        }
    }
}