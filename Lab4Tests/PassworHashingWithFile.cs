using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.PasswordHashingUtils;
using IIG.FileWorker;

namespace Lab4Tests
{
    [TestClass]
    public class PasswordHashingWithFile
    {
        private string path = "C:/Users/yaros/source/repos/Lab4Tests/ForFileWorker/";
        [TestMethod]
        public void WriteFileToDisk()
        {
            Assert.IsTrue(BaseFileWorker.Write(PasswordHasher.GetHash("Test1234", "TestSalt") + "\r\n" + PasswordHasher.GetHash("Test365", "TestSalt"), path + "writedFileWithHash.txt"));
        }
        [TestMethod]
        public void GetLinesFromFile()
        {
            string[] lines = BaseFileWorker.ReadLines(path + "writedFileWithHash.txt");
            Assert.AreEqual(lines[0], PasswordHasher.GetHash("Test1234", "TestSalt"));
            Assert.AreEqual(lines[1], PasswordHasher.GetHash("Test365", "TestSalt"));
        }
        [TestMethod]
        public void GetLinesFromOtherManualFile()
        {
            string[] lines = BaseFileWorker.ReadLines(path + "manualWritedFile.txt");
            Assert.AreEqual(lines[0], PasswordHasher.GetHash("Test1234", "TestSalt"));
            Assert.AreEqual(lines[1], PasswordHasher.GetHash("Test365", "TestSalt"));
        }
        [TestMethod]
        public void GetAllFromFile()
        {
            string[] lines = BaseFileWorker.ReadAll(path + "writedFileWithHash.txt").Split("\r\n");
            Assert.AreEqual(lines[0], PasswordHasher.GetHash("Test1234", "TestSalt"));
            Assert.AreEqual(lines[1], PasswordHasher.GetHash("Test365", "TestSalt"));
        }
        [TestMethod]
        public void GetAllFromOtherManualFile()
        {
            string[] lines = BaseFileWorker.ReadAll(path + "manualWritedFile.txt").Split("\r\n");
            Assert.AreEqual(lines[0], PasswordHasher.GetHash("Test1234", "TestSalt"));
            Assert.AreEqual(lines[1], PasswordHasher.GetHash("Test365", "TestSalt"));
        }
    }
}