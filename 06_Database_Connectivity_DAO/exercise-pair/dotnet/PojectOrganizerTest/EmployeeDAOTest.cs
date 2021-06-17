using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PojectOrganizerTest
{
    [TestClass]
    public class EmployeeDAOTest
    {

        EmployeeSqlDAO employeeSqlDAO;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";
        private TransactionScope tran;

        [TestInitialize]

        public void Setup()
        {
            tran = new TransactionScope();

            employeeSqlDAO = new EmployeeSqlDAO(connectionString);
        }

        [TestCleanup]

        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]

        public void EmployeeDAOContructor()
        {
            Assert.IsNotNull(employeeSqlDAO);
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            //Arrange 
            employeeSqlDAO = new EmployeeSqlDAO(connectionString);

            //Act
            IList<Employee> employees = employeeSqlDAO.GetAllEmployees();
            int count = employees.Count;

            //Assert
            Assert.AreEqual(count, employees.Count);
        }
    }
}
