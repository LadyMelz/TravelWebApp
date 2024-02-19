namespace TravelWebAPI.Models
{
    public class Attraction_Itinerary
    {
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }

        public int ItineraryId { get; set; }

        public Itinerary Itinerary { get; set; }
    }
}
