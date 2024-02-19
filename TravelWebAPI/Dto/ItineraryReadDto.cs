using System.ComponentModel.DataAnnotations;
using TravelWebAPI.Models;

namespace TravelWebAPI.Dto
{
    public class ItineraryReadDto
    {
        public int Id { get; set; }
        public string img { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Transportation { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }
        //public List<Attraction_Itinerary> Attraction_Itineraries { get; set; }
        //public List<Event_Itinerary> Event_Itineraries { get; set; }
    }
}
