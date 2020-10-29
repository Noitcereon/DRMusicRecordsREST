using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRMusicRecordsREST.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using DRMusicLib;
using DRMusicRecordsREST.Managers;

namespace DRMusicRecordsREST.Controllers.Tests
{
    [TestClass()]
    public class MusicRecordControllerTests
    {
        private static MusicRecordController controller;
        private static MusicRecordManager manager;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            controller = new MusicRecordController();
            manager = new MusicRecordManager();
        }

        [TestMethod()]
        public void GetAllRecordsTest()
        {
            Assert.IsNotNull(manager);
            Assert.AreEqual(manager.GetAllRecords().Count, 2);
        }

        [TestMethod]
        public void SearchRecordsTest()
        {
            FilterMusicRecord FMR = new FilterMusicRecord("Test","test",1090);
            Assert.IsNotNull(manager.SearchRecords(FMR));

        }
    }
}