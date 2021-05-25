using System;
using System.Collections.Generic;
using System.Text;
using TripMs.Domain;

namespace TripMs.Domain.Models
{
    public class Trip
    { // adding all th enotes here so i dont forget like b we can do meetings without them being plannified so we have add ..we need to ask madame if we can do them in the same place and how exactly we're planning to do meeting actuaaly weird
        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description  { get; set; } 
        public bool Plannified { get; set; }
        public string Status { get; set; }

    }
}
