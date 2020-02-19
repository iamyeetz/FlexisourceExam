using NUnit.Framework;
using opg_201910_interview.Model;
using opg_201910_interview.Service;
using System;
using System.Collections.Generic;

namespace opg_201910_interview.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestClientA()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientA",
                FileFormat = "xml",
                FileOrder = "shovel,waghor,blaze,discus"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.AreEqual(5, fileManagement.getFiles(file).Count);
        }
        [Test]
        public void TestClientB()
        {
            Files file = new Files
            {
                ClientId = 2001,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientB",
                FileFormat = "xml",
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.AreEqual(5, fileManagement.getFiles(file).Count);
        }
        [Test]
        public void TestGetFiles_ClientIdEqualZero()
        {
            Files file = new Files
            {
                ClientId = 0,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientB",
                FileFormat = "xml",
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_ClientIdLessThanZero()
        {
            Files file = new Files
            {
                ClientId = -1,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientB",
                FileFormat = "xml",
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_FilePathIsEmpty()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = "",
                FileFormat = "xml",
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_FilePathIsNull()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = null,
                FileFormat = "xml",
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_FileFormatIsEmpty()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientA",
                FileFormat = "",
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_FileFormatIsNull()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientA",
                FileFormat = null,
                FileOrder = "orca,widget,eclair,talon"
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_FileOrderIsEmpty()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientA",
                FileFormat = "xml",
                FileOrder = ""
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }
        [Test]
        public void TestGetFiles_FileOrderIsNull()
        {
            Files file = new Files
            {
                ClientId = 1001,
                FilePath = "../../../../opg-201910Base-master/UploadFiles/ClientA",
                FileFormat = "xml",
                FileOrder = null
            };
            FileManagement fileManagement = new FileManagement();
            Assert.Throws<ArgumentOutOfRangeException>(() => fileManagement.getFiles(file));

        }

    }
}