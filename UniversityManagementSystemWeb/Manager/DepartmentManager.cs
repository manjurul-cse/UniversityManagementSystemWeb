using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway aDepartmentGateway;
        public string SaveDepartment(Department aDepartment)
        {
            aDepartmentGateway = new DepartmentGateway();
            if (!HasThisDepartmentIdExist(aDepartment))

                if (!HasThisDepartmentNameExist(aDepartment))
                {

                    return aDepartmentGateway.SaveDepartment(aDepartment);
                }
                else
                {
                    return "This Department Name exist.";
                }

            else
            {
                return "This Department Code exist.";
            }
        }


        private bool HasThisDepartmentIdExist(Department aDepartment)
        {
            List<Department> departments = new List<Department>();
            departments = GetAllDepartments();
            foreach (Department departmentObj in departments)
            {
                if (departmentObj.DepartmentCode == aDepartment.DepartmentCode)
                    return true;
            }
            return false;
        }

        private bool HasThisDepartmentNameExist(Department aDepartment)
        {
            List<Department> departments = new List<Department>();
            departments = GetAllDepartments();
            foreach (Department departmentObj in departments)
            {

                if (departmentObj.DepartmentName == aDepartment.DepartmentName)
                    return true;

            }
            return false;
        }

        public List<Department> GetAllDepartments()
        {
            aDepartmentGateway = new DepartmentGateway();
            return aDepartmentGateway.GetAllDepartments();
        }



        public Department GetDepartment(Int16 departmentId)
        {
            aDepartmentGateway = new DepartmentGateway();
            List<Department> departments = new List<Department>();
            departments = GetAllDepartments();
            Department aDepartment = new Department();
            foreach (var department in departments)
            {
                if (department.DepartmentId == departmentId)
                {
                    aDepartment.DepartmentId = department.DepartmentId;
                    aDepartment.DepartmentCode = department.DepartmentCode;
                    aDepartment.DepartmentName = department.DepartmentName;
                    return aDepartment;
                }
            }
            return aDepartment;
        }
    }
}