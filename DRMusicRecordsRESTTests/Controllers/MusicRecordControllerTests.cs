﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRMusicRecordsREST.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
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
            Assert.AreEqual(manager.GetAllRecords().Count, 2);
        }
    }
}