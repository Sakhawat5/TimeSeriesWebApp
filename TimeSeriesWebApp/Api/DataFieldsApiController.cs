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
    public class DataFieldsApiController : ControllerBase
    {
        private readonly TimeSeriesContext _context;

        public DataFieldsApiController(TimeSeriesContext context)
        {
            _context = context;
        }

        // GET: api/DataFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataField>>> GetDataField()
        {
            return await _context.DataField.ToListAsync();
        }

        // GET: api/DataFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataField>> GetDataField(int id)
        {
            var dataField = await _context.DataField.FindAsync(id);

            if (dataField == null)
            {
                return NotFound();
            }

            return dataField;
        }

        // PUT: api/DataFields/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataField(int id, DataField dataField)
        {
            if (id != dataField.Id)
            {
                return BadRequest();
            }

            _context.Entry(dataField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataFieldExists(id))
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

        // POST: api/DataFields
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataField>> PostDataField(DataField dataField)
        {
            _context.DataField.Add(dataField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataField", new { id = dataField.Id }, dataField);
        }

        // DELETE: api/DataFields/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataField>> DeleteDataField(int id)
        {
            var dataField = await _context.DataField.FindAsync(id);
            if (dataField == null)
            {
                return NotFound();
            }

            _context.DataField.Remove(dataField);
            await _context.SaveChangesAsync();

            return dataField;
        }

        private bool DataFieldExists(int id)
        {
            return _context.DataField.Any(e => e.Id == id);
        }
    }
}
