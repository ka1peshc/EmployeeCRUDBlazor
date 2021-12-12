
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

    }
}
