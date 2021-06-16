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

        //public void GetDepartments_Should_ReturnAllDepartments()
        //{
        //    //Arrange 
        //    departmentSqlDAO = new DepartmentSqlDAO(connectionString);

        //    //Act
        //    IList<Department> departments = departmentSqlDAO.GetDepartments();

        //    //Assert
        //    Assert.AreEqual(4, departments.Count);
        //}


    }
}
