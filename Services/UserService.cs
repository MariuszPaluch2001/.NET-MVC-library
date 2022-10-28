using LibraryManagement.Models;
namespace LibraryManagement.Services
{
    public interface UserService
    {
        public UserModel Login(string login, string password);
        public UserModel Logout();
    }
}
