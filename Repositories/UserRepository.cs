using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace LibraryManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagerContext _context;
        public UserRepository(UserManagerContext context)
        {
            _context = context;
        }

        public void Add(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int userId)
        {
            var result = _context.Users.SingleOrDefault(x => x.id == userId);
            if (result is not null)
            {
                _context.Users.Remove(result);
                _context.SaveChanges();
            }
        }

        public UserModel GetUser(string login)
            => _context.Users.SingleOrDefault(x => x.login == login);
        public UserModel GetUser(string login, string password)
            => _context.Users.SingleOrDefault(x => x.login == login && x.password == password);
        public UserModel GetUser(int id)
            => _context.Users.SingleOrDefault(x => x.id == id);

        public IList<UserModel> getUsers()
            => _context.Users.ToList();

        public void Update(int userId, UserModel user)
        {
            var result = _context.Users.SingleOrDefault(x => x.id == userId);
            if (result is not null)
            {
                result.login = user.login;
                result.password = user.password;
            }
        }
    }
}
