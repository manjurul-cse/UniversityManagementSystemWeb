using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class ViewCourseGradeAndCredit
    {
        private int courseId;
        private string courseName;
        private float credit;
        private string gradeLetter;

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public string GradeLetter
        {
            get { return gradeLetter; }
            set { gradeLetter = value; }
        }

        public float Credit
        {
            get { return credit; }
            set { credit = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
    }
}