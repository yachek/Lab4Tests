using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.BinaryFlag;
using IIG.FileWorker;

namespace Lab4Tests
{
    [TestClass]
    public class BinaryFlagWithFile
    {
        private const string path = "C:/Users/yaros/source/repos/Lab4Tests/ForFileWorker/";
        [TestMethod]
        public void WriteFileToDisk()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(7, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(10, false);
            first.ResetFlag(0);
            first.ResetFlag(2);
            first.ResetFlag(5);
            second.SetFlag(1);
            second.SetFlag(3);
            second.SetFlag(7);
            second.SetFlag(9);
            Assert.IsTrue(BaseFileWorker.Write(first.ToString() + " " + first.GetFlag() + "\r\n" + second.ToString() + " " + second.GetFlag(), path + "writedFileWithFlag.txt"));
        }
        [TestMethod]
        public void GetLinesFromFile()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(7, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(10, false);
            first.ResetFlag(0);
            first.ResetFlag(2);
            first.ResetFlag(5);
            second.SetFlag(1);
            second.SetFlag(3);
            second.SetFlag(7);
            second.SetFlag(9);
            string[] lines = BaseFileWorker.ReadLines(path + "writedFileWithFlag.txt");
            Assert.AreEqual(lines[0], first.ToString() + " " + first.GetFlag());
            Assert.AreEqual(lines[1], second.ToString() + " " + second.GetFlag());
        }
        [TestMethod]
        public void GetLinesFromOtherManualFile()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(5, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(4, true);
            first.ResetFlag(2);
            first.ResetFlag(3);
            string[] lines = BaseFileWorker.ReadLines(path + "manualWritedFile.txt");
            Assert.AreEqual(lines[0], first.ToString() + " " + first.GetFlag());
            Assert.AreEqual(lines[1], second.ToString() + " " + second.GetFlag());
        }
        [TestMethod]
        public void GetWrongLinesFromOtherFile()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(7, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(10, false);
            first.ResetFlag(0);
            first.ResetFlag(2);
            first.ResetFlag(5);
            second.SetFlag(1);
            second.SetFlag(3);
            second.SetFlag(7);
            second.SetFlag(9);
            string[] lines = BaseFileWorker.ReadLines(path + "manualWritedFile.txt");
            Assert.AreNotEqual(lines[0], first.ToString() + " " + first.GetFlag());
            Assert.AreNotEqual(lines[1], second.ToString() + " " + second.GetFlag());
        }
        [TestMethod]
        public void GetAllFromFile()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(7, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(10, false);
            first.ResetFlag(0);
            first.ResetFlag(2);
            first.ResetFlag(5);
            second.SetFlag(1);
            second.SetFlag(3);
            second.SetFlag(7);
            second.SetFlag(9);
            string[] lines = BaseFileWorker.ReadAll(path + "writedFileWithFlag.txt").Split("\r\n");
            Assert.AreEqual(lines[0], first.ToString() + " " + first.GetFlag());
            Assert.AreEqual(lines[1], second.ToString() + " " + second.GetFlag());
        }
        [TestMethod]
        public void GetAllFromOtherManualFile()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(5, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(4, true);
            first.ResetFlag(2);
            first.ResetFlag(3);
            string[] lines = BaseFileWorker.ReadLines(path + "manualWritedFile.txt");
            Assert.AreEqual(lines[0], first.ToString() + " " + first.GetFlag());
            Assert.AreEqual(lines[1], second.ToString() + " " + second.GetFlag());
        }
        [TestMethod]
        public void GetAllWrongFromOtherFile()
        {
            MultipleBinaryFlag first = new MultipleBinaryFlag(5, true);
            MultipleBinaryFlag second = new MultipleBinaryFlag(4, true);
            first.ResetFlag(2);
            first.ResetFlag(3);
            string[] lines = BaseFileWorker.ReadLines(path + "writedFileWithFlag.txt");
            Assert.AreNotEqual(lines[0], first.ToString() + " " + first.GetFlag());
            Assert.AreNotEqual(lines[1], second.ToString() + " " + second.GetFlag());
        }
    }
}
