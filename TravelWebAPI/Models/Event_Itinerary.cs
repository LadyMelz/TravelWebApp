namespace TravelWebAPI.Models
{
    public class Event_Itinerary
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int ItineraryId { get; set; }

        public Itinerary Itinerary { get; set; }
    }
}
