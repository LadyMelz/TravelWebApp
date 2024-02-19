using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public interface IItineraryRepository
    {
        Task<IEnumerable<Itinerary>> GetAll();

        Itinerary Get(int id);

        void Update(Itinerary itineraries);

        void Delete(int id);

        void Create(Itinerary itineraries);

        bool SaveChanges();
    }
}
