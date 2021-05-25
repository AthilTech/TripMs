using System;

namespace TripMs.Api.Controllers
{
    public class TripDTO
    {

        public Guid TripId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Plannified { get; set; }
        public string Status { get; set; }


    }
}