using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSeriesWebApp.Data;
using TimeSeriesWebApp.Models;

namespace TimeSeriesWebApp.Service
{
    public class BuildingService
    {
        private readonly TimeSeriesContext _context;

        public BuildingService(TimeSeriesContext context)
        {
            _context = context;
        }
        public async Task<List<Building>> GetAll()
        {
            List<Building> buildings = await _context.Building.ToListAsync();
            return buildings;
        }
        public async Task<Building> GetById(int id)
        {
            Building building = await _context.Building.FindAsync(id);
            return building;
        }

        public async Task<bool> UpdateBuilding(Building building)
        {
            await _context.Building.FindAsync(building.Id);
            _context.Building.Update(building);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateBuilding(Building building)
        {
            _context.Building.Add(building);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
