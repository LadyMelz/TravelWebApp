using Microsoft.EntityFrameworkCore;
using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public class ItineraryRepository : IItineraryRepository
    {
        private readonly AppDataContext _context;
        public ItineraryRepository(AppDataContext context)
        {
            _context = context;
        }
        public void Create(Itinerary itineraries)
        {
            _context.Add(itineraries);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Itinerary Get(int id)
        {
            return _context.Itineraries.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Itinerary>> GetAll()
        {
            return await _context.Itineraries.Include(i=>i.User.FullName).ToListAsync();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Itinerary itineraries)
        {
            throw new NotImplementedException();
        }
    }
}
