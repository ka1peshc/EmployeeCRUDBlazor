using EmployeeModel;

namespace DataAccessLayer
{
    public interface IEmployeeDAL
    {
        string connectionString { get; set; }

        void AddNewEmp(Employee Emp);
    }
}