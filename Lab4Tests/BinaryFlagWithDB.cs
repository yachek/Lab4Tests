using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.BinaryFlag;
using IIG.CoSFE.DatabaseUtils;

namespace Lab4Tests
{
    [TestClass]
    public class BinaryFlagWithDB
    {
        private const string Server = @"DESKTOP-AH1R6IJ\FORLAB4TESTS";
        private const string Database = @"IIG.CoSWE.FlagpoleDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"lab4tests";
        private const int ConnectionTime = 75;
        private FlagpoleDatabaseUtils connectionWithDB = new FlagpoleDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTime);
        [TestMethod]
        public void InsertingToDBTest1()
        {
            MultipleBinaryFlag temp = new MultipleBinaryFlag(10, true);
            Assert.IsTrue(connectionWithDB.AddFlag(temp.ToString(), temp.GetFlag()));
        }
        [TestMethod]
        public void InsertingToDBTest2()
        {
            MultipleBinaryFlag temp = new MultipleBinaryFlag(10, true);
            temp.ResetFlag(2);
            temp.ResetFlag(9);
            temp.ResetFlag(6);
            Assert.IsTrue(connectionWithDB.AddFlag(temp.ToString(), temp.GetFlag()));
        }
        [TestMethod]
        public void InsertingToDBTest4()
        {
            MultipleBinaryFlag temp = new MultipleBinaryFlag(30, false);
            Assert.IsFalse(connectionWithDB.AddFlag(temp.ToString(), temp.GetFlag()));
        }
        [TestMethod]
        public void InsertingToDBTest5()
        {
            MultipleBinaryFlag temp = new MultipleBinaryFlag(50, false);
            Assert.IsFalse(connectionWithDB.AddFlag(temp.ToString(), temp.GetFlag()));
        }
        [TestMethod]
        public void InsertToDBManualTest1()
        {
            Assert.IsTrue(connectionWithDB.AddFlag("FFFT", false));
        }
        [TestMethod]
        public void InsertToDBManualTest2()
        {
            Assert.IsTrue(connectionWithDB.AddFlag("fFtFFttf", false));
        }
        [TestMethod]
        public void InsertToDBManualWrongDataTest1()
        {
            Assert.IsFalse(connectionWithDB.AddFlag("TTTTTTTT", false));
        }
        [TestMethod]
        public void InsertToDBManualWrongDataTest2()
        {
            Assert.IsFalse(connectionWithDB.AddFlag("FTFTTTTF", true));
        }
        [TestMethod]
        public void InsertToDBManualWrongDataTest3()
        {
            Assert.IsFalse(connectionWithDB.AddFlag("TestData", true));
        }
        [TestMethod]
        public void GetIntoDBTest1()
        {
            MultipleBinaryFlag temp = new MultipleBinaryFlag(4, false);
            temp.SetFlag(3);
            string flagView;
            bool? flagValue;
            connectionWithDB.GetFlag(3, out flagView, out flagValue);
            Assert.AreEqual(flagView, temp.ToString());
            Assert.AreEqual(flagValue, temp.GetFlag());
        }
        [TestMethod]
        public void GetIntoDBTest2()
        {
            MultipleBinaryFlag temp = new MultipleBinaryFlag(8, false);
            temp.SetFlag(2);
            temp.SetFlag(5);
            temp.SetFlag(6);
            string flagView;
            bool? flagValue;
            connectionWithDB.GetFlag(4, out flagView, out flagValue);
            Assert.AreNotEqual(flagView, temp.ToString());
            Assert.AreEqual(flagValue, temp.GetFlag());
        }
    }
}
