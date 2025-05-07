using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        // GET: api/Buggy/notfound
        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            // Code
            return NotFound(); // 404
        }

        // GET: api/Buggy/servererror
        [HttpGet("servererror")]
        public IActionResult GetServerErrorRequest()
        {
            throw new Exception();
            return Ok();
        }


        // GET: api/Buggy/badrequest
        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(); // 400
        }

        // GET: api/Buggy/badrequest/{id}
        [HttpGet("badrequest/{id}")]
        public IActionResult GetBadRequest(int id) // Validation Error
        {
            return BadRequest(); // 400
        }

        [HttpGet("unauthorized")] // GET: api/Buggy/unauthorized
        public IActionResult GetUnauthorizedRequest()
        {
            // Code
            return Unauthorized(); // 401
        }
    }
}
