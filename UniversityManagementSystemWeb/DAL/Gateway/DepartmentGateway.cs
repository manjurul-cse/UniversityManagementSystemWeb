using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class DepartmentGateway : DBGateway
    {
        public DepartmentGateway()
        {

        }

        public string SaveDepartment(Department aDepartment)
        {
            try
            {
                connection.Open();
                string departmentAddQuery = "INSERT INTO t_Department VALUES(@code,@name)";
                command.CommandText = departmentAddQuery;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@code", aDepartment.DepartmentCode);
                command.Parameters.AddWithValue("@name", aDepartment.DepartmentName);
                command.ExecuteNonQuery();

                return "Saved";
            }

            finally
            {
                connection.Close();
            }


        }

        public List<Department> GetAllDepartments()
        {

            try
            {
                List<Department> departments = new List<Department>();
                connection.Open();
                string departmentQuery = "SELECT * FROM t_Department";
                command.CommandText = departmentQuery;
                command.Parameters.Clear();
                SqlDataReader departmentReader = command.ExecuteReader();
                while (departmentReader.Read())
                {
                    Department aDepartment = new Department();
                    aDepartment.DepartmentId = Convert.ToInt16(departmentReader[0].ToString());
                    aDepartment.DepartmentCode = departmentReader[1].ToString();
                    aDepartment.DepartmentName = departmentReader[2].ToString();
                    departments.Add(aDepartment);

                }
                return departments;
            }
            finally
            {
                connection.Close();
            }



        }
    }
}