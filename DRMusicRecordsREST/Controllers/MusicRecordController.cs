using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DRMusicLib;
using DRMusicRecordsREST.Managers;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AddRecord([FromBody] MusicRecord musicRecord)
        {
            if (musicRecord == null)
            {
                return BadRequest();
            }
            string response = _manager?.AddRecord(musicRecord);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteRecord([FromQuery]string artist, [FromQuery]string title)
        {
            if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(artist))
            {
                return BadRequest();
            }

            int result = _manager.DeleteRecord(artist, title);
            if (result == 0)
            {
                return NotFound("No record found to delete");
            }

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateRecord([FromQuery]string artist, [FromQuery]string title, [FromBody] MusicRecord musicRecord)
        {
            if (String.IsNullOrEmpty(artist) || String.IsNullOrEmpty(title) || musicRecord == null)
            {
                return BadRequest();
            }

            int result = _manager.UpdateRecord(artist, title, musicRecord);
            if (result == 0)
            {
                return NotFound("No record to update");
            }

            return Ok(result);
        }
    }
}
