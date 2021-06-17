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
<<<<<<< HEAD
        DepartmentSqlDAO departmentSqlDAO;

        public string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";


=======

>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f
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
<<<<<<< HEAD
            departmentSqlDAO = new DepartmentSqlDAO(connectionString);
=======
          departmentSqlDAO = new DepartmentSqlDAO(connectionString);
>>>>>>> 4b7b781ccc815358b1db71a956adc442844a373f

            //Act
            IList<Department> departments = departmentSqlDAO.GetDepartments();

            //Assert
            Assert.AreEqual(4, departments.Count);
        }

    }
}