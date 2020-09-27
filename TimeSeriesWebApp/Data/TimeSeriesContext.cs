using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSeriesWebApp.Models;

namespace TimeSeriesWebApp.Data
{
    public class TimeSeriesContext : DbContext
    {
        public TimeSeriesContext (DbContextOptions<TimeSeriesContext> options)
            : base(options)
        {
        }

        public DbSet<TimeSeriesWebApp.Models.Building> Building { get; set; }

        public DbSet<TimeSeriesWebApp.Models.Object> Object { get; set; }

        public DbSet<TimeSeriesWebApp.Models.DataField> DataField { get; set; }

        public DbSet<TimeSeriesWebApp.Models.Reading> Reading { get; set; }
    }
}
