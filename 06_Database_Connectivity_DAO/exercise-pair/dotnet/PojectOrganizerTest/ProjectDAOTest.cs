using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Transactions;


namespace ProjectOrganizerTest
{


    class ProjectsDAOTest : DepartmentDAOTest
    {

        ProjectSqlDAO projectSqlDAO;

        private TransactionScope tran;

        [TestInitialize]

        public void Setup()
        {
            tran = new TransactionScope();

            projectSqlDAO = new ProjectSqlDAO(connectionString);
        }

        [TestCleanup]

        public void Cleanup()
        {
            tran.Dispose();
        }


        [TestMethod]
        public void GetProjects_Should_Return_Right_Number()
        {
            //Arrange 
            projectSqlDAO = new ProjectSqlDAO(connectionString);

            //Act
            IList<Project> projects = projectSqlDAO.GetAllProjects();

            //Assert
            Assert.AreEqual(6, projects.Count);
        }

        [TestMethod]
        [DataRow(2, 2)]
        public void AssignEmployee_To_Project_Should_Return_One_More_Project(int Id, int EmployeeID)
        {

            Project project = new Project();
            Employee employee = new Employee();

            project.ProjectId = Id;
            employee.EmployeeId = EmployeeID;

            IList<Project> projects = projectSqlDAO.GetAllProjects();
            int count = projects.Count;

            projectSqlDAO.AssignEmployeeToProject(Id, EmployeeID);
            projects = projectSqlDAO.GetAllProjects();

            Assert.AreEqual(count + 1, projects.Count);

        }
        [TestMethod]
        public void Remove_Employee_Should_Return_One_Less(int Id, int EmployeeID)
        {

            Project project = new Project();
            Employee employee = new Employee();

            project.ProjectId = Id;
            employee.EmployeeId = EmployeeID;

            IList<Project> projects = projectSqlDAO.GetAllProjects();
            int count = projects.Count;

            projectSqlDAO.AssignEmployeeToProject(Id, EmployeeID);
            projects = projectSqlDAO.GetAllProjects();

            Assert.AreEqual(count - 1, projects.Count);

        }
    }
}
