using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User Get(int id);

        void Update(int id, User user);

        void Delete(int id, User user);

        void Create(User user);

        bool SaveChanges();
    }
}
