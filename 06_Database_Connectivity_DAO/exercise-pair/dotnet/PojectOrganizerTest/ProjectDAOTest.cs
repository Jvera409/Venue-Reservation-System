using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Transactions;


namespace ProjectOrganizerTest
{
    [TestClass]

<<<<<<< HEAD
    public class ProjectsDAOTest
=======
    [TestClass]
    public class ProjectsDAOTest : TestParentDAO
>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f
    {

        ProjectSqlDAO projectSqlDAO;

        public string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";

        private TransactionScope tran;

        [TestInitialize]

        public override void Setup()
        {
            tran = new TransactionScope();

            projectSqlDAO = new ProjectSqlDAO(connectionString);
        }

        [TestCleanup]

        public override void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void ProjectsDAOConstructor() 
        {
            
        }

        [TestMethod]

        public void ProjectSqlDAOConstructor()
        {
            Assert.IsNotNull(projectSqlDAO);
        }


        [TestMethod]
        public void GetProjects_Should_Return_Right_Number()
        {
            //Arrange 
            projectSqlDAO = new ProjectSqlDAO(connectionString);

            //Act
            IList<Project> projects = projectSqlDAO.GetAllProjects();
            int count = projects.Count;

            int count = projects.Count;

            //Assert
            Assert.AreEqual(count, projects.Count);
        }

        [TestMethod]
        [DataRow(2, 2)]
        public void AssignEmployee_To_Project_Should_Return_One_More_Project(int Id, int EmployeeID)
        {
            projectSqlDAO = new ProjectSqlDAO(connectionString);

            //Project project = new Project();
            //Employee employee = new Employee();

            //project.ProjectId = Id;
            //employee.EmployeeId = EmployeeID;

            IList<Project> projects = projectSqlDAO.GetAllProjects();
            int count = projects.Count;

            projectSqlDAO.AssignEmployeeToProject(Id, EmployeeID);
            projects = projectSqlDAO.GetAllProjects();

            Assert.AreEqual(count, projects.Count);

        }
        [TestMethod]
        [DataRow(7,13)]
        public void Remove_Employee_Should_Return_One_Less(int Id, int EmployeeID)
        {
            projectSqlDAO = new ProjectSqlDAO(connectionString);



            Project project = new Project();
            Employee employee = new Employee();

            project.ProjectId = Id;
            employee.EmployeeId = EmployeeID;

            IList<Project> projects = projectSqlDAO.GetAllProjects();
            int count = projects.Count;

            projectSqlDAO.AssignEmployeeToProject(Id, EmployeeID);
            projects = projectSqlDAO.GetAllProjects();

            Assert.AreEqual(count, projects.Count);

        }
    }
}
