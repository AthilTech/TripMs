using System;
using System.Collections.Generic;
using System.Text;
using TripMs.Domain;

namespace TripMs.Domain.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
