using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class ResultManager
    {
        private StudentManager aStudentManager;
        private ResultGateway aResultGateway;
        public string SaveASubjectGrade(StudentResult aStudentResult)
        {
            aResultGateway = new ResultGateway();

            if (DoesThisSubjectExist(aStudentResult))
                if (DoesThisSubjectResultExist(aStudentResult))
                {
                    if (aStudentResult.GradeLetter == "F")
                        aStudentResult.Status = 1;
                    else
                        aStudentResult.Status = 0;
                    return aResultGateway.SaveASubjectGrade(aStudentResult);
                }

                else
                    return "You already completed this subject";
            else
                return "You Does not Get this Subject";
        }

        private bool DoesThisSubjectResultExist(StudentResult aStudentResult)
        {
            List<StudentResult> studentResults = new List<StudentResult>();
            aResultGateway = new ResultGateway();
            studentResults = aResultGateway.GetSubjectResult(aStudentResult);
            if (studentResults.Count == 0)
                return true;
            foreach (StudentResult studentResult in studentResults)
            {
                if (studentResult.CourseId == aStudentResult.CourseId && studentResult.Status == 1)
                {
                    aResultGateway = new ResultGateway();
                    if (aResultGateway.DeletePreviousReselt(aStudentResult))
                        return true;
                }

            }

            return false;
        }



        private bool DoesThisSubjectExist(StudentResult aStudentResult)
        {
            List<Course> courses = new List<Course>();
            aStudentManager = new StudentManager();
            courses = aStudentManager.GetStudentCourses(aStudentResult.RegistationNo);
            foreach (Course course in courses)
            {
                if (course.CourseId == aStudentResult.CourseId)
                {
                    return true;
                }
            }
            return false;

        }
        public List<ViewCourseGradeAndCredit> GetCourseResult(string regNo)
        {
            aResultGateway = new ResultGateway();
            return aResultGateway.GetCourseResult(regNo);
        }

        public ViewResult GetSubjectCGPA(string regNo)
        {
            int NoOfenrollCourse = 1;
            int noOfRemaningCourse = 0;
            float remaningCredit = 0;
            double TotalGpa = 0;
            ViewResult aViewResult = new ViewResult();
            List<ViewCourseGradeAndCredit> viewCourseGradeAndCreditList = new List<ViewCourseGradeAndCredit>();
            viewCourseGradeAndCreditList = GetCourseResult(regNo);
            foreach (ViewCourseGradeAndCredit viewCourseGradeAndCreditObj in viewCourseGradeAndCreditList)
            {
                aViewResult.SubjectCgpa = GradePointCalculator.GetPoint(viewCourseGradeAndCreditObj.GradeLetter) *
                                   viewCourseGradeAndCreditObj.Credit;
                TotalGpa += aViewResult.SubjectCgpa;
                aViewResult.EnrolledCredit += viewCourseGradeAndCreditObj.Credit;
                aViewResult.NoOfEnrolledCourses += NoOfenrollCourse;
                NoOfenrollCourse++;
                if (viewCourseGradeAndCreditObj.GradeLetter == "F" || viewCourseGradeAndCreditObj.GradeLetter == "On Going..")
                {
                    noOfRemaningCourse++;
                    remaningCredit += viewCourseGradeAndCreditObj.Credit;
                }
            }
            aViewResult.Cgpa = GradePointCalculator.CGPA(TotalGpa, (aViewResult.EnrolledCredit - remaningCredit));
            aViewResult.GradeLetter = GradePointCalculator.GetGradeLetter(aViewResult.Cgpa);
            aViewResult.CompletedCredit = aViewResult.EnrolledCredit - remaningCredit;
            aViewResult.NoOfCompletedCourses = aViewResult.NoOfEnrolledCourses - noOfRemaningCourse;
            return aViewResult;
        }



    }
}