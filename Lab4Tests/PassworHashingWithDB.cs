using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;
using IIG.CoSFE.DatabaseUtils;

namespace Lab4Tests
{
    [TestClass]
    public class PasswordHashingWithFile
    {
        private const string Server = @"DESKTOP-AH1R6IJ\FORLAB4TESTS";
        private const string Database = @"IIG.CoSWE.AuthDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"lab4tests";
        private const int ConnectionTime = 75;
        private AuthDatabaseUtils connectionWithDB = new AuthDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTime);
        private const string userName1 = "TestUserOleg";
        private const string password1 = "TestPassword";
        private const string salt1 = "Oleg";
        private const string userName2 = "qwert@feodkl.com";
        private const string password2 = "PasswordTest";
        private const string salt2 = "email";
        private const string userName3 = "[]``//z";
        private const string password3 = "PlovetsKPI";
        private const string salt3 = "swimming";
        private const string userName4 = "異體字";
        private const string password4 = "ChinaSymbols";
        private const string salt4 = "China";
        private const string passwordForManualUser = "ManualUserUpdate";
        private const string saltForManualUser = "ManualUserSalt";
        [TestMethod]
        public void InsertingCredentialsToDBTest1()
        {
            Assert.IsTrue(connectionWithDB.AddCredentials(userName1, PasswordHasher.GetHash(password1, salt1)));
        }
        [TestMethod]
        public void InsertingCredentialsToDBTest2()
        {
            Assert.IsTrue(connectionWithDB.AddCredentials(userName2, PasswordHasher.GetHash(password2, salt2)));
        }
        [TestMethod]
        public void InsertingCredentialsToDBTest3()
        {
            Assert.IsTrue(connectionWithDB.AddCredentials(userName3, PasswordHasher.GetHash(password3, salt3)));
        }
        [TestMethod]
        public void InsertingCredentialsToDBTest4()
        {
            Assert.IsTrue(connectionWithDB.AddCredentials(userName4, PasswordHasher.GetHash(password4, salt4)));
        }
        [TestMethod]
        public void InsertingManualCredentialsWithNullPasswdToDBTest()
        {
            Assert.IsFalse(connectionWithDB.AddCredentials("User228", ""));
        }
        [TestMethod]
        public void InsertingManualCredentialsWithNullUserToDBTest()
        {
            Assert.IsFalse(connectionWithDB.AddCredentials("", "vsdwm456765743895423895haudhfbveyrifubc3q47f6bqi76gufyb3qi74ugyfbrfhntrhgrec37y"));
        }
        [TestMethod]
        public void InsertingManualCredentialsToDBTest1()
        {
            Assert.IsFalse(connectionWithDB.AddCredentials("gerf", "  678pol[]]\\/*``wrfsfdgvsfsfsdf異體字異體字異體字異體字異體字異體字異體字異體字]`;;:"));
        }
        [TestMethod]
        public void InsertingManualCredentialsToDBTest2()
        {
            Assert.IsTrue(connectionWithDB.AddCredentials("gerf4", "  678pol[]]\\/*``ervfdsvsd;;;[]`][`][;[`:{};`][;`[]]{};`:cwrrrrrr"));
        }
        [TestMethod]
        public void CheckRightCredentialsTest()
        {
            Assert.IsTrue(connectionWithDB.CheckCredentials(userName1, PasswordHasher.GetHash(password1, salt1)));
            Assert.IsTrue(connectionWithDB.CheckCredentials(userName4, PasswordHasher.GetHash(password4, salt4)));
        }
        [TestMethod]
        public void CheckWrongCredentialsTest()
        {
            Assert.IsFalse(connectionWithDB.CheckCredentials(userName3, PasswordHasher.GetHash(password4, salt4)));
            Assert.IsFalse(connectionWithDB.CheckCredentials("NonExistentLogin", PasswordHasher.GetHash(password2, salt2)));
        }
        [TestMethod]
        public void UpdateRightCredentialsTest()
        {
            Assert.IsTrue(connectionWithDB.UpdateCredentials("gerf4", "  678pol[]]\\/*``ervfdsvsd;;;[]`][`][;[`:{};`][;`[]]{};`:cwrrrrrr", "gerf4",
                PasswordHasher.GetHash(passwordForManualUser, saltForManualUser)));
        }
        [TestMethod]
        public void UpdateNonExistentCredentialsTest()
        {
            Assert.IsFalse(connectionWithDB.UpdateCredentials("NonExistentLogin", "NonExistentPassword", "gerf96",
                PasswordHasher.GetHash(passwordForManualUser, saltForManualUser)));
        }
        [TestMethod]
        public void UpdateExistentCredentialsWithWrongPasswordTest()
        {
            Assert.IsFalse(connectionWithDB.UpdateCredentials(userName3, PasswordHasher.GetHash(password4, salt1), userName1,
                PasswordHasher.GetHash(passwordForManualUser, saltForManualUser)));
        }
        [TestMethod]
        public void DeleteCredentialsTest()
        {
            Assert.IsTrue(connectionWithDB.DeleteCredentials(userName1, PasswordHasher.GetHash(password1, salt1)));
        }
        [TestMethod]
        public void DeleteNonExistentCredentialsTest()
        {
            Assert.IsFalse(connectionWithDB.DeleteCredentials("NonExistentLogin", "NonExistentPassword"));
        }
        [TestMethod]
        public void DeleteExistentCredentialsWithWrongPasswordTest()
        {
            Assert.IsFalse(connectionWithDB.DeleteCredentials(userName3, PasswordHasher.GetHash(userName3, saltForManualUser)));
        }
    }
}