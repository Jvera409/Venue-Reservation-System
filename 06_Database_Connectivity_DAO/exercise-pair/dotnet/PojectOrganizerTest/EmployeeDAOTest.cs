using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
<<<<<<< HEAD
=======
using ProjectOrganizerTest;
>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PojectOrganizerTest
{
    [TestClass]
<<<<<<< HEAD
    public class EmployeeDAOTest
    {

        EmployeeSqlDAO employeeSqlDAO;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";
        private TransactionScope tran;

        [TestInitialize]

        public void Setup()
        {
            tran = new TransactionScope();
=======
    public class EmployeeDAOTest : TestParentDAO
    {
        EmployeeSqlDAO employeeSqlDAO;

        private TransactionScope transaction;

        [TestInitialize]

        public override void Setup()
        {
            transaction = new TransactionScope();
>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f

            employeeSqlDAO = new EmployeeSqlDAO(connectionString);
        }

        [TestCleanup]

<<<<<<< HEAD
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]

        public void EmployeeDAOContructor()
=======
        public override void Cleanup()
        {
            transaction.Dispose();
        }


        [TestMethod]
        public void EmployeeDAO()
>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f
        {
            Assert.IsNotNull(employeeSqlDAO);
        }

        [TestMethod]
<<<<<<< HEAD
        public void GetAllEmployees()
        {
            //Arrange 
=======

        public void GetAllEmployees_Should_ReturnAllEmployees()
        {
            //Arrange
>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f
            employeeSqlDAO = new EmployeeSqlDAO(connectionString);

            //Act
            IList<Employee> employees = employeeSqlDAO.GetAllEmployees();
            int count = employees.Count;

            //Assert
            Assert.AreEqual(count, employees.Count);
        }
<<<<<<< HEAD
=======

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




>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f
    }
}
