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
        public string Location { get; set; }
        public string Description  { get; set; } 
        public bool plannified { get; set; } 
       
    }
}
