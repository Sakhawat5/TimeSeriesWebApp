using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeSeriesWebApp.Models;
using TimeSeriesWebApp.ViewModel;

namespace TimeSeriesWebAppService.Interface
{
    public interface IBuildingService
    {
        IList<ViewBuilding> GetAll();
        ViewBuilding GetById(int id);
        Task<bool> Create(Building building);
        Task<bool> Update(Building building);
        Task<bool> Delete(Building building);
    }
}
