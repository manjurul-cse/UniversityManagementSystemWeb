using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    static class GradePointCalculator
    {
        public static double GetPoint(string gradeLetter)
        {
            switch (gradeLetter)
            {
                case "A+":
                    return 4.0;

                case "A":
                    return 3.75;

                case "A-":
                    return 3.50;

                case "B+":
                    return 3.25;

                case "B":
                    return 3.00;

                case "B-":
                    return 2.75;

                case "C+":
                    return 2.50;

                case "C":
                    return 2.25;

                case "C-":
                    return 2.00;

                default:
                    return 0.00;
            }
        }

        public static string GetGradeLetter(double gradePoint)
        {
            if (gradePoint == 4.00)
                return "A+";
            else if (gradePoint >= 3.75 && gradePoint < 4.00)
                return "A";
            else if (gradePoint >= 3.50 && gradePoint < 3.75)
                return "A-";
            else if (gradePoint >= 3.25 && gradePoint < 3.50)
                return "B+";
            else if (gradePoint >= 3.00 && gradePoint < 3.25)
                return "B";
            else if (gradePoint >= 2.75 && gradePoint < 3.00)
                return "B-";
            else if (gradePoint >= 2.50 && gradePoint < 2.75)
                return "C+";
            else if (gradePoint >= 2.25 && gradePoint < 2.50)
                return "C";
            else if (gradePoint >= 2.00 && gradePoint < 2.25)
                return "C-";
            else
                return "F";
        }

        public static double CGPA(double totalGpa, double TotalCredit)
        {
            double finalCgpa = totalGpa / TotalCredit;
            string newCgpa = "";
            string cgpa = finalCgpa.ToString();
            if(cgpa.Length>4)
            {
                for (int i = 0; i < 4; i++)
                {
                    newCgpa += cgpa[i].ToString();
                }
                finalCgpa = double.Parse(newCgpa.ToString());
                
            }
           
            return finalCgpa;
        }
    }
}
