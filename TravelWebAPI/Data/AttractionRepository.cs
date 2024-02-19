using TravelWebAPI.Data;

namespace TravelWebAPI.Models.Data
{
    public class AttractionRepository : IAttractionRepository
    {   
        private readonly AppDataContext _context;
        public AttractionRepository(AppDataContext context) {
            _context = context;
        }
        public void Create(Attraction attraction)
        {
            _context.Add(attraction);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Attraction Get(int id)
        {
            return _context.Attractions.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Attraction> GetAll()
        {
           return _context.Attractions.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(int id, Attraction attractions)
        {
            var _attraction = _context.Attractions.Find(id);
            if (_attraction != null)
            {
                _attraction.Title = attractions.Title;
                _attraction.Location = attractions.Location;
                _attraction.Short_Description = attractions.Short_Description;
                _attraction.Long_Description = attractions.Long_Description;
                _attraction.Link = attractions.Link;
                _attraction.ImgURL = attractions.ImgURL;

                _context.SaveChanges();
            }
        }

        public void Delete(int id, Attraction attraction)
        {
            var _attraction = _context.Attractions.FirstOrDefault(a => a.Id == id);
            if (_attraction != null)
            {
                _context.Attractions.Remove(_attraction);
                _context.SaveChanges();
            }

        }
    }
}
