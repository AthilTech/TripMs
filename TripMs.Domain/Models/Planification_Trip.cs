using System;
using System.Collections.Generic;
using System.Text;

namespace TripMs.Domain.Models
{
    public class Planification_Trip
    {
        public Guid Planification_DeplacementId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
