using TravelWebAPI.Data;

namespace TravelWebAPI.Models.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDataContext _context;
        public EventRepository(AppDataContext context)
        {
            _context = context;
        }
        public void Create(Event events)
        {
            _context.Add(events);
        }

        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(int id,Event events)
        {
            var _event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (_event != null)
            {
                _event.Title = events.Title;
                _event.Price = events.Price;
                _event.Location = events.Location;
                _event.Date = events.Date;
                _event.Short_Description = events.Short_Description;
                _event.Long_Description = events.Long_Description;
                _event.Link = events.Link;
                _event.ImgURL = events.ImgURL;

                _context.SaveChanges();
            }
        }

        public void Delete(int id, Event events)
        {
            var _event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (_event != null)
            {
                _context.Events.Remove(_event);
                _context.SaveChanges();
            }

        }
    }
}
