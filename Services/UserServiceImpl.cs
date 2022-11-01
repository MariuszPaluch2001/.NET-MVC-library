using LibraryManagement.Models;
using LibraryManagement.Repositories;
using NuGet.Protocol.Plugins;

namespace LibraryManagement.Services
{
    public class UserServiceImpl : UserService
    {
        private IUserRepository userRepository;
        public UserServiceImpl(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        
        public User Login(string login, string password)
        {
            return userRepository.GetUser(login, password);
        }

        public User Register(string login, string password, string password_repeat)
        {
            User user = new User();
            if (userRepository.GetUser(login) is null && password == password_repeat)
            {
                user.login = login;
                user.password = password;
                user.isSuperUser = false;
                userRepository.Add(user);
            }
            return user;
        }

    }
}
