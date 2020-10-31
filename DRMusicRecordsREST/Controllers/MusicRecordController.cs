using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRMusicLib;
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
                return NotFound("Manager not found (no records retrieved)");
            }

            if (_manager.GetAllRecords() != null)
            {
                return Ok(result);
            }

            return NotFound("No records found.");
        }

        [HttpGet("search")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult SearchRecords([FromQuery] FilterMusicRecord searchQuery)
        {
            if (searchQuery == null) return NotFound("Search query is empty.");
            var result = _manager.SearchRecords(searchQuery);

            if (_manager == null)
            {
                NotFound("Search didn't return any results.");
            }

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("Search did not get any results.");
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddRecord([FromBody]MusicRecord musicRecord)
        {
            if (musicRecord == null)
            {
                return BadRequest();
            }
            string response = _manager?.AddRecord(musicRecord);
            return Ok(response);
        }
    }
}
