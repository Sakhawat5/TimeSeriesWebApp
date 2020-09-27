using System;
using TimeSeriesWebApp.Models;

namespace TimeSeriesWebApp.ViewModel
{
    public class ViewBuilding
    {
        public ViewBuilding(Building building)
        {
            Id = building.Id;
            Name = building.Name;
            Location = building.Location;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
