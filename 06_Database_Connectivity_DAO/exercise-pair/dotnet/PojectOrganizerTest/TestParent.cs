using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using ProjectOrganizer.Models;
using System.Collections.Generic;
using System.Transactions;

namespace ProjectOrganizerTest
{
    [TestClass]
    public class TestParentDAO
    {
        public string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";



        private TransactionScope tran;

        [TestInitialize]

        public virtual void Setup()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]

        public virtual void Cleanup()
        {
            tran.Dispose();
        }
    }
}