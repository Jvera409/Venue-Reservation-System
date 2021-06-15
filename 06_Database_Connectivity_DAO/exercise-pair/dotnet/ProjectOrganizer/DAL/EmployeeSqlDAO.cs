using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class EmployeeSqlDAO : IEmployeeDAO
    {
        private readonly string connectionString;

        private string sqlGetAllEmployees = "SELECT * FROM employee";

        private string sqlSearch = "SELECT * FROM employee " +
        "WHERE first_name LIKE '%@first_name%' " +
        "AND last_name LIKE '%@last_name%'";

        private string sqlGetEmployeesWithoutProjects = "SELECT* FROM employee " +
            "LEFT JOIN project_employee ON employee.employee_id = project_employee.employee_id " +
            "WHERE project_id IS NULL";

        // Single Parameter Constructor
        public EmployeeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            IList<Employee> result = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllEmployees, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Employee employee = new Employee();

                        employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        employee.FirstName = Convert.ToString(reader["first_name"]);
                        employee.LastName = Convert.ToString(reader["last_name"]);
                        employee.JobTitle = Convert.ToString(reader["job_title"]);
                        employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        employee.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        result.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Employee>();
            }
            return result;
        }

        /// <summary>
        /// Find all employees whose names contain the search strings.
        /// Returned employees names must contain *both* first and last names.
        /// </summary>
        /// <remarks>Be sure to use LIKE for proper search matching.</remarks>
        /// <param name="firstname">The string to search for in the first_name field</param>
        /// <param name="lastname">The string to search for in the last_name field</param>
        /// <returns>A list of employees that matches the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            IList<Employee> result = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                    cmd.Parameters.AddWithValue("first_name", firstname);
                    cmd.Parameters.AddWithValue("last_name", lastname);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();


                        employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        employee.FirstName = Convert.ToString(reader["first_name"]);
                        employee.LastName = Convert.ToString(reader["last_name"]);
                        employee.JobTitle = Convert.ToString(reader["job_title"]);
                        employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        employee.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        result.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Employee>();
            }
            return result;
        }

        /// <summary>
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            IList<Employee> result = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetEmployeesWithoutProjects, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Employee employee = new Employee();

                        employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        employee.FirstName = Convert.ToString(reader["first_name"]);
                        employee.LastName = Convert.ToString(reader["last_name"]);
                        employee.JobTitle = Convert.ToString(reader["job_title"]);
                        employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        employee.HireDate = Convert.ToDateTime(reader["hire_date"]);


                        result.Add(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Employee>();
            }
            return result;

        }
    }
}
