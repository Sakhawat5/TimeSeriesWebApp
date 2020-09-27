using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSeriesWebApp.Data;
using TimeSeriesWebApp.Models;

namespace TimeSeriesWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsApiController : ControllerBase
    {
        private readonly TimeSeriesContext _context;

        public ReadingsApiController(TimeSeriesContext context)
        {
            _context = context;
        }

        // GET: api/ReadingsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reading>>> GetReading()
        {
            return await _context.Reading.ToListAsync();
        }

        // GET: api/ReadingsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reading>> GetReading(int id)
        {
            var reading = await _context.Reading.FindAsync(id);

            if (reading == null)
            {
                return NotFound();
            }

            return reading;
        }

        // PUT: api/ReadingsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReading(int id, Reading reading)
        {
            if (id != reading.Id)
            {
                return BadRequest();
            }

            _context.Entry(reading).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingExists(id))
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

        // POST: api/ReadingsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reading>> PostReading(Reading reading)
        {
            _context.Reading.Add(reading);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReading", new { id = reading.Id }, reading);
        }

        // DELETE: api/ReadingsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reading>> DeleteReading(int id)
        {
            var reading = await _context.Reading.FindAsync(id);
            if (reading == null)
            {
                return NotFound();
            }

            _context.Reading.Remove(reading);
            await _context.SaveChangesAsync();

            return reading;
        }

        private bool ReadingExists(int id)
        {
            return _context.Reading.Any(e => e.Id == id);
        }
    }
}
