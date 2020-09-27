using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSeriesWebApp.Data;
using TimeSeriesWebApp.Models;
using Object = TimeSeriesWebApp.Models.Object;

namespace TimeSeriesWebApp.Controllers
{
    public class BuildingController : Controller
    {
        private readonly TimeSeriesContext _context;
        public BuildingController(TimeSeriesContext context)
        {
            _context = context;
        }
        // GET: Building
        public ActionResult Index()
        {
            IList<Reading> listOfReading = new List<Reading>();
            List<Building> buildings = _context.Building.ToList();
            List<Object> objects = _context.Object.ToList();
            List<DataField> dataFields = _context.DataField.ToList();
            for (int i = 0; i < 10; i++)
            {
                foreach (var builing in buildings)
                {

                    foreach (var obj in objects)
                    {
                        foreach (var dataFiled in dataFields)
                        {
                            Reading reading = new Reading();
                            reading.BuildingId = builing.Id;
                            reading.ObjectId = obj.Id;
                            reading.DataFieldId = dataFiled.Id;
                            reading.Timestamp = DateTime.Now;
                            reading.Value = i;
                            listOfReading.Add(reading);
                        }

                    }

                }

            }
            _context.Reading.AddRange(listOfReading);
            _context.SaveChanges();
            return View();
        }

        // GET: Building/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Building/Create
        public ActionResult Create()
        {
            for (int i = 0; i < 100; i++)
            {
                Object ob = new Object();
                ob.Name = "Building - " + i;
                _context.Object.Add(ob);

                DataField df = new DataField();
                df.Name = "DataField - " + i;
                _context.DataField.Add(df);
                _context.SaveChanges();
            }
            //for (int i = 0; i < 100; i++)
            //{
            //    Building building = new Building();
            //    building.Name = "Building - " + i;
            //    building.Location = "Location - "+i;
            //    _context.Building.Add(building);

            //    DataField df = new DataField();
            //    df.Name = "DataField - " + i;
            //    _context.DataField.Add(df);
            //    _context.SaveChanges();
            //}
            return View();
        }

        // POST: Building/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Building/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Building/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Building/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}