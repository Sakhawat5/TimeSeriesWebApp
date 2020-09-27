using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSeriesWebApp.Data;
using TimeSeriesWebApp.Models;
using TimeSeriesWebApp.Service;

namespace TimeSeriesWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsApiController : ControllerBase
    {
        private readonly BuildingService _buildingService;
        private readonly TimeSeriesContext _context;

        public BuildingsApiController(BuildingService buildingService, TimeSeriesContext context)
        {
            _buildingService = buildingService;
            _context = context;
        }

        // GET: api/BuildingsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuilding()
        {
            return await _buildingService.GetAll();
        }

        // GET: api/BuildingsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(int id)
        {
            var building = await _buildingService.GetById(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        // PUT: api/BuildingsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(int id, Building building)
        {
            if (id != building.Id)
            {
                return BadRequest();
            }

            bool updateBuilding = await _buildingService.UpdateBuilding(building);

            try
            {
                if(updateBuilding == true)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
        }

        // POST: api/BuildingsApi
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
            bool postBuilding = await _buildingService.CreateBuilding(building);
            if(postBuilding == true)
            {
                return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
            }
            else
            {
                return NotFound();
            }

        }

        // DELETE: api/BuildingsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Building>> DeleteBuilding(int id)
        {
            

            var building = await _context.Building.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        private bool BuildingExists(int id)
        {
            return _context.Building.Any(e => e.Id == id);
        }
    }
}
