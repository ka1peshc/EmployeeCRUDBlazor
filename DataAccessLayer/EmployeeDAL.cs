
namespace DataAccessLayer
{
    using EmployeeModel;
    using Microsoft.Extensions.Configuration;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly IConfiguration config;
        public string connectionString { get; set; } = "EmployeeDB";
        public EmployeeDAL(IConfiguration configration)
        {
            this.config = configration;
        }

        /// <summary>
        /// Create new Employee
        /// </summary>
        /// <param name="Emp"></param>
        public void AddNewEmp(Employee Emp)
        {
            string ConnectionStrings = config.GetConnectionString(connectionString);
            using (MySqlConnection con = new MySqlConnection(ConnectionStrings))
            {
                MySqlCommand cmd = new MySqlCommand("sp_AddEmp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ename", Emp.Name);
                cmd.Parameters.AddWithValue("@epath", Emp.ProfileImage);
                cmd.Parameters.AddWithValue("@egender", Emp.Gender);
                cmd.Parameters.AddWithValue("@edept", Emp.Department);
                cmd.Parameters.AddWithValue("@salary", Emp.Salary);
                cmd.Parameters.AddWithValue("@startdate", Emp.StartDate);
                cmd.Parameters.AddWithValue("@notes", Emp.Notes);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// Display all employees
        /// </summary>
        /// <returns>Employee model</returns>
        public IEnumerable<Employee> GetAllEmployee()
        {
            string ConnectionStrings = config.GetConnectionString(connectionString);
            List<Employee> lstCustomer = new List<Employee>();
            using (MySqlConnection con = new MySqlConnection(ConnectionStrings))
            {
                MySqlCommand cmd = new MySqlCommand("sp_DisplayEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(rdr["Empid"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = (DateTime)(rdr["StartDate"] == DBNull.Value ? default(DateTime) : rdr["StartDate"]);
                    employee.Notes = rdr["Note"].ToString();
                    lstCustomer.Add(employee);
                }
                con.Close();
            }
            return lstCustomer;
        }
        
        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>employee model</returns>
        public Employee GetEmployeeByID(int? id)
        {
            string ConnectionStrings = config.GetConnectionString(connectionString);
            Employee employee = new Employee();
            using (MySqlConnection con = new MySqlConnection(ConnectionStrings))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeId", id);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(rdr["Empid"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = (DateTime)(rdr["StartDate"] == DBNull.Value ? default(DateTime) : rdr["StartDate"]);
                    employee.Notes = rdr["Note"].ToString();
                }
                con.Close();
            }
            return employee;
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id">int id</param>
        public void DeleteEmployee(int? id)
        {
            string ConnectionStrings = config.GetConnectionString(connectionString);
            using (MySqlConnection con = new MySqlConnection(ConnectionStrings))
            {
                MySqlCommand cmd = new MySqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="Emp">employee model</param>
        public void UpdateEmployee(Employee Emp)
        {
            string ConnectionStrings = config.GetConnectionString(connectionString);
            using (MySqlConnection con = new MySqlConnection(ConnectionStrings))
            {
                MySqlCommand cmd = new MySqlCommand("sp_UpdateEmpData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", Emp.EmployeeId);
                cmd.Parameters.AddWithValue("@ename", Emp.Name);
                cmd.Parameters.AddWithValue("@esalary", Emp.Salary);
                cmd.Parameters.AddWithValue("@estartdate", Emp.StartDate);
                cmd.Parameters.AddWithValue("@enotes", Emp.Notes);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
