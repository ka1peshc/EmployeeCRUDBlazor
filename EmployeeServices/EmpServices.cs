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
        public List<Employee> GetEmployee()
        {
            List<Employee> emp = this.employeeDataAccess.GetAllEmployee().ToList();
            return emp;
        }
        public Employee GetEmployeeByID(int id)
        {
            Employee customer = this.employeeDataAccess.GetEmployeeByID(id);
            return customer;
        }

        public string DeleteEmployee(Employee objEmp)
        {
            this.employeeDataAccess.DeleteEmployee(objEmp.EmployeeId);
            return "Delete successful";
        }
        public string UpdateEmployee(Employee objEmp)
        {
            this.employeeDataAccess.UpdateEmployee(objEmp);
            return "Update Successful";
        }
    }
}
