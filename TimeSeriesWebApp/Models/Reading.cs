using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSeriesWebApp.Models
{
    public class Reading
    {
        public int Id { get; set; }
        [Required]
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
        [Required]
        public int ObjectId { get; set; }
        public virtual Object Object { get; set; }
        [Required]
        public int DataFieldId { get; set; }
        public virtual DataField DataField { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }

    }
}
