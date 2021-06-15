using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Transactions;


namespace PojectOrganizerTest
{


    class ProjectsDAOTest
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
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";
      
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
    }
}
