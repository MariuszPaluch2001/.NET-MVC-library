using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IUserRepository
    {
        UserModel GetUser(string login);
        UserModel GetUser(string login, string password);
        UserModel GetUser(int id);
        IList<UserModel> getUsers();
        void Add(UserModel user);
        void Update(int userId, UserModel user);
        void Delete(int userId);
    }
}
