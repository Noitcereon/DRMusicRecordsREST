﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRMusicRecordsREST.Managers;
using Microsoft.AspNetCore.Mvc;

namespace DRMusicRecordsREST.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class MusicRecordController : ControllerBase
    {
        private static MusicRecordManager _manager = new MusicRecordManager();

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetAllRecords()
        {
            var result = _manager.GetAllRecords();

            if (_manager == null)
            {
                return NotFound("No records found");
            }

            if (_manager.GetAllRecords() != null)
            {
                return Ok(result);
            }

            return NotFound("Not found, lel.");
        }
    }
}
