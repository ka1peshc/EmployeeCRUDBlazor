using EmployeeModel;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IEmployeeDAL
    {
        string connectionString { get; set; }

        void AddNewEmp(Employee Emp);
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeByID(int? id);
        void DeleteEmployee(int? id);
        void UpdateEmployee(Employee Emp);
    }
}