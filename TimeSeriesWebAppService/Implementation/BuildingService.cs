using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSeriesWebApp.Data;
using TimeSeriesWebApp.Models;
using TimeSeriesWebApp.ViewModel;
using TimeSeriesWebAppService.Interface;

namespace TimeSeriesWebAppService.Implementation
{
    public class BuildingService : IBuildingService
    {
        private readonly TimeSeriesContext _context;
        public BuildingService(TimeSeriesContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Building building)
        {
            _context.Add(building);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Building building)
        {
            _context.Remove(building);
            await _context.SaveChangesAsync();
            return true;
        }

        public IList<ViewBuilding> GetAll()
        {
            List<Building> buildings = _context.Building.ToList();
            List<ViewBuilding> viewBuildings = new List<ViewBuilding>();
            foreach (var building in buildings)
            {
                ViewBuilding viewBuilding = new ViewBuilding(building);
                viewBuildings.Add(viewBuilding);
            }
            return viewBuildings;         
        }

        public ViewBuilding GetById(int id)
        {
            return _context.Building.Find(id);
        }

        public Task<bool> Update(Building building)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IBuildingService.Delete(Building building)
        {
            throw new NotImplementedException();
        }

    }
}
