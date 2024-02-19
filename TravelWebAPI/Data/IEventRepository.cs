using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event Get(int id);

        void Update(int id,Event events);

        void Delete(int id, Event events);

        void Create(Event events);

        bool SaveChanges();
   
    }

}

