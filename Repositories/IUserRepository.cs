using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IUserRepository
    {
        UserModel GetUser(string login);
        UserModel GetUser(int id);
        IQueryable<UserModel> getUsers();
        void Add(UserModel user);
        void Update(int userId, UserModel user);
        void Delete(int userId);
    }
}
