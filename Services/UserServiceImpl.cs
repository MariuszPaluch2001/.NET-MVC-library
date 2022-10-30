using LibraryManagement.Models;
using NuGet.Protocol.Plugins;

namespace LibraryManagement.Services
{
    public class UserServiceImpl : UserService
    {

        private static IList<UserModel> users = new List<UserModel>()
            {
                new UserModel
                {
                    id = 1,
                    login = "SuperUser",
                    password = "123",
                    isSuperUser = true
                },
                new UserModel
                {
                    id = 2,
                    login = "NotSuperUser",
                    password = "123",
                    isSuperUser = false
                }
            };
        

        public UserModel Login(string login, string password)
        {
            return users.SingleOrDefault(x => x.login == login && x.password == password);
        }

        public UserModel Register(string login, string password, string password_repeat)
        {
            if (users.SingleOrDefault(x => x.login == login ) is null && password == password_repeat)
            {
                UserModel user = new UserModel();
                user.id = users.Count() + 1;
                user.login = login;
                user.password = password;
                user.isSuperUser = false;
                users.Add(user);
                return user;
            }
            return null;
        }

        public bool DeleteAccount(string login)
        {
            return users.Remove(users.FirstOrDefault(x => x.login == login));
        }

    }
}
