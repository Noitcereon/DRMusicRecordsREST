using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRMusicRecordsREST.Controllers;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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

        [ClassCleanup]
        public static void CleanUp()
        {
            foreach (var i in manager.GetAllRecords())
            {
                manager.DeleteRecord(i.Artist, i.Title);
            }

            List<MusicRecord> MusicRecords = new List<MusicRecord>
            {
                new MusicRecord("Running with the Wolves", "Aurora",
                    2015, 300,
                    false),
                new MusicRecord("Uprising", "Muse", 2009,
                    420, true),
                new MusicRecord("Knights of Cydonia", "Muse", 2006,
                    480, true),
                new MusicRecord("Moon Walker", "Safri Duo", 2003,
                    509, false),
                new MusicRecord("Roundabout", "Yes", 1980, 720, true)
            };
            foreach (var i in MusicRecords)
            {
                manager.AddRecord(i);
            }
        }

        [TestMethod()]
        public void GetAllRecordsTest()
        {
            Assert.IsNotNull(manager);
            Assert.AreEqual(manager.GetAllRecords().Count, 5);
        }

        [TestMethod]
        public void SearchRecordsTest()
        {
            FilterMusicRecord FMR = new FilterMusicRecord("Test","test",1090);
            Assert.IsNotNull(manager.SearchRecords(FMR));

        }

        [TestMethod]
        public void AddRecordTest()
        {
           int initCount = manager.GetAllRecords().Count;
           MusicRecord testOb = new MusicRecord("Oxygen","Three foot crunch",2011,200,false);
           manager.AddRecord(testOb);

           Assert.AreEqual(initCount +1,manager.GetAllRecords().Count);
        }

        [TestMethod]
        public void DeleteRecordTest()
        {
            int expectedResult = manager.GetAllRecords().Count -1;
            manager.DeleteRecord("Muse", "Uprising");
            int countAfterDelete = manager.GetAllRecords().Count;

            Assert.AreEqual(expectedResult, countAfterDelete);
        }

        [TestMethod]
        public void PutRecordTest()
        {
            IList<MusicRecord> beforeTestList = new List<MusicRecord>(manager.GetAllRecords());

            MusicRecord testRecord = new MusicRecord("testTitle","testArtist",7357,123,false);

            manager.UpdateRecord("Muse", "Uprising", testRecord);

            IList<MusicRecord> afterTestList = new List<MusicRecord>(manager.GetAllRecords());

            Assert.IsTrue(beforeTestList.Contains(testRecord) == false);
            Assert.IsTrue(afterTestList.Contains(testRecord));
            
        }
    }
}