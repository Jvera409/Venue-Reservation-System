using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Transactions;

namespace PojectOrganizerTest
{
    [TestClass]
    public class DepartmentDAOTest
    {
        DepartmentSqlDAO departmentSqlDAO;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";
        private TransactionScope tran;

        [TestInitialize]

        public void Setup()
        {
            tran = new TransactionScope();

            departmentSqlDAO = new DepartmentSqlDAO(connectionString);
        }

        [TestCleanup]

        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]

        public void DepartmentSqlDAOConstructor()
        {
            Assert.IsNotNull(departmentSqlDAO);
        }

        [TestMethod]
        [DataRow(5, "IT support")]

        //public void DepartmentSqlDAO(int id, string name)
        //{
        //    List<Department> departments = departmentSqlDAO.GetDepartments();
        //    int count = departmentSqlDAO

        //    departmenSqlDAO.
    }
}