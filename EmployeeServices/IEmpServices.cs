using EmployeeModel;
using System.Collections.Generic;

namespace EmployeeServices
{
    public interface IEmpServices
    {
        string AddNewEmp(Employee objEmp);
        List<Employee> GetEmployee();
    }
}