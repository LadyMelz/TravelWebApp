using Microsoft.EntityFrameworkCore;
using TravelWebAPI.Models;

namespace TravelWebAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;
        public UserRepository(AppDataContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Add(user);
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(int id, User user)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (_user != null)
            {
                _user.FullName = user.FullName;
                _user.Email = user.Email;
                _user.Password = user.Password;
                _user.Phone = user.Phone;
                _user.ImgURL = user.ImgURL;
               
                _context.SaveChanges();
            }
        }
        public void Delete(int id, User user)
        {
            var _user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (_user != null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
            }
           
        }
    }
}
