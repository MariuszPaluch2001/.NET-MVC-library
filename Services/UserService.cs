using LibraryManagement.Models;
namespace LibraryManagement.Services
{
    public interface UserService
    {
        public UserModel Login(string login, string password);

        public UserModel Register(string login, string password, string password_repeat);
        public bool DeleteAccount(string login);
        public IList<UserModel> getUsers();
    }
}
