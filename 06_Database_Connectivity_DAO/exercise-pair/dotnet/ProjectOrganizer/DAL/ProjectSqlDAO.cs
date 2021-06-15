using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class ProjectSqlDAO : IProjectDAO
    {
        private readonly string connectionString;

        private string sqlGetAllProjects = "SELECT * FROM project";

        private string sqlCreateProject = "INSERT INTO project(project_id, name, from_date, hire_date)" +
            "VALUES(@project_id, @name, @from_date, @hire_date);";

        private string sqlRemoveEmployeeFromProject = "DELETE FROM project_employee WHERE project_id = @project_Id AND employee_id = @employee_Id";

        private string sqlAddEmployeeToProject = "INSERT INTO project_employee (project_id, employee_id) VALUES (@project_id, @employee_id)";



        // Single Parameter Constructor
        public ProjectSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            IList<Project> result = new List<Project>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllProjects, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Project project = new Project();

                        project.ProjectId = Convert.ToInt32(reader["project_id"]);
                        project.Name = Convert.ToString(reader["name"]);
                        project.StartDate = Convert.ToDateTime(reader["from_date"]);
                        project.EndDate = Convert.ToDateTime(reader["hire_date"]);


                        result.Add(project);
                    }
                }
            }
            catch (Exception ex)
            {
                result = new List<Project>();
            }
            return result;
        }

        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            bool result = false;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddEmployeeToProject, conn);

                    cmd.Parameters.AddWithValue("@project_Id", projectId);
                    cmd.Parameters.AddWithValue("@employee_Id", employeeId);

                    int count = cmd.ExecuteNonQuery();
                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        /// 


 
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlRemoveEmployeeFromProject, conn);

                cmd.Parameters.AddWithValue("@project_Id", projectId);
                cmd.Parameters.AddWithValue("@employee_Id", employeeId);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    result = true;
                }

            }
            return result;
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {

            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlCreateProject, conn);

                    cmd.Parameters.AddWithValue("@project_id", newProject.ProjectId);
                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@from_date", newProject.StartDate);
                    cmd.Parameters.AddWithValue("@hire_date", newProject.EndDate);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = count;
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

    }
}
