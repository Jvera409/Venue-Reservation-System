using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using ProjectOrganizerTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PojectOrganizerTest
{
    [TestClass]
    public class EmployeeDAOTest : TestParentDAO
    {
        EmployeeSqlDAO employeeSqlDAO;

        private TransactionScope transaction;

        [TestInitialize]

        public override void Setup()
        {
            transaction = new TransactionScope();

            employeeSqlDAO = new EmployeeSqlDAO(connectionString);
        }

        [TestCleanup]

        public override void Cleanup()
        {
            transaction.Dispose();
        }


        [TestMethod]
        public void EmployeeDAO()
        {
            Assert.IsNotNull(employeeSqlDAO);
        }

        [TestMethod]

        public void GetAllEmployees_Should_ReturnAllEmployees()
        {
            //Arrange
            employeeSqlDAO = new EmployeeSqlDAO(connectionString);

            //Act
            IList<Employee> employees = employeeSqlDAO.GetAllEmployees();
            int count = employees.Count;

            //Assert
            Assert.AreEqual(count, employees.Count);
        }

        [TestMethod]
        public void GetEmployeesWithoutProjects_Should_Return_Correct_Number()
        {
            //Arrange
            employeeSqlDAO = new EmployeeSqlDAO(connectionString);

            //Act
            IList<Employee> employees = employeeSqlDAO.GetEmployeesWithoutProjects();
            int count = employees.Count;

            //Assert
            Assert.AreEqual(count, employees.Count);
        }

        [TestMethod]
        [DataRow ("Mitch", "Vera")]

        public void EmployeeSearchShouldReturnNewName(string firstname, string lastname)
        {
            //Arrange
            employeeSqlDAO = new EmployeeSqlDAO(connectionString);

            //Act
            IList<Employee> employees = employeeSqlDAO.GetAllEmployees();
            int count = employees.Count;
            employeeSqlDAO.Search(firstname, lastname);
            employees = employeeSqlDAO.GetAllEmployees();

            //Assert
            Assert.AreEqual(count, employees.Count);
        }




    }
}
