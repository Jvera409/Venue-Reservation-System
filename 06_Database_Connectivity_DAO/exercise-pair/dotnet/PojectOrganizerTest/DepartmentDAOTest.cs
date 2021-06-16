using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Transactions;

namespace ProjectOrganizerTest
{
    [TestClass]
    public class DepartmentDAOTest : TestParentDAO
    {

        private TransactionScope tran;

        [TestInitialize]

        public override void Setup()
        {
            tran = new TransactionScope();

            departmentSqlDAO = new DepartmentSqlDAO(connectionString);
        }

        [TestCleanup]

        public override void Cleanup()
        {
            tran.Dispose();
        }
        DepartmentSqlDAO departmentSqlDAO;
        [TestMethod]

        public void DepartmentSqlDAOConstructor()
        {
            Assert.IsNotNull(departmentSqlDAO);
        }

        [TestMethod]
        [DataRow(5, "IT support")]

        public void DepartmentSqlDAOCreateDepartment(int Id, string Name)
        {
            Department department = new Department();
            department.Id = Id;
            department.Name = Name;

            IList<Department> departments = departmentSqlDAO.GetDepartments();
            int count = departments.Count;

            departmentSqlDAO.CreateDepartment(department);

            departments = departmentSqlDAO.GetDepartments();

            Assert.AreEqual(count + 1, departments.Count);
        }

        [TestMethod]

        public void GetDepartments_Should_ReturnAllDepartments()
        {
            //Arrange 
          departmentSqlDAO = new DepartmentSqlDAO(connectionString);

            //Act
            IList<Department> departments = departmentSqlDAO.GetDepartments();

            //Assert
            Assert.AreEqual(4, departments.Count);
        }

    }
}