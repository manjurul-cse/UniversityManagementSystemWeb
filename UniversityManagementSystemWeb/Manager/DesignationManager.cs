using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class DesignationManager
    {
        public Designation GetDesignation(int id)
        {
            Designation aDesignation = new Designation();
            List<Designation> designations = GetAllDesignations();
            foreach (Designation designation in designations)
            {
                if (designation.Id == id)
                {
                    aDesignation.Id = designation.Id;
                    aDesignation.DesignationName = designation.DesignationName;

                }

            }
            return aDesignation;
        }

        public List<Designation> GetAllDesignations()
        {
            DesignationGateway aDesignationGateway = new DesignationGateway();
            return aDesignationGateway.GetAllDesignations();
        }

    }
}