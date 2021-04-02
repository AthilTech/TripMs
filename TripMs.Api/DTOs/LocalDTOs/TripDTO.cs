using System;

namespace TripMs.Api.Controllers
{
    public class TripDTO
    {

        public Guid TripId { get; set; }
        public DateTime Deadline { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}