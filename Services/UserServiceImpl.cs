using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class UserServiceImpl : UserService
    {

        private List<UserModel> users;
        
        public UserServiceImpl()
        {
            users = new List<UserModel>
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
        }
        public UserModel Login(string login, string password)
        {
            return users.SingleOrDefault(x => x.login == login && x.password == password);
        }

        public UserModel Logout()
        {
            throw new NotImplementedException();
        }
    }
}
