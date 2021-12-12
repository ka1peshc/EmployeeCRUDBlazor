namespace EmployeeServices
{
    using DataAccessLayer;
    using EmployeeModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EmpServices : IEmpServices
    {
        private readonly IEmployeeDAL employeeDataAccess;
        public EmpServices(IEmployeeDAL employeeDataAccess)
        {
            this.employeeDataAccess = employeeDataAccess;
        }

        public string AddNewEmp(Employee objEmp)
        {
            this.employeeDataAccess.AddNewEmp(objEmp);
            return "Added Successfully";
        }
    }
}
