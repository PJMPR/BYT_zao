using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Byt.MyJobs.Web.Models;

namespace Byt.MyJobs.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Jobs")]
    public class JobsApiController : Controller
    {
        private readonly MyJobsContext _context;

        public JobsApiController(MyJobsContext context)
        {
            _context = context;
        }

        // GET: api/JobsApi
        [HttpGet]
        public IEnumerable<Job> GetJob()
        {
            return _context.Job;
        }

        // GET: api/JobsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/JobsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob([FromRoute] int id, [FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.Id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobsApi
        [HttpPost]
        public async Task<IActionResult> PostJob([FromBody] Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Job.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/JobsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Job.Remove(job);
            await _context.SaveChangesAsync();

            return Ok(job);
        }

        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.Id == id);
        }
    }
}