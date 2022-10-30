using LibraryManagement.Models;
namespace LibraryManagement.Services
{
    public interface UserService
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
        public UserModel Login(string login, string password);

        public UserModel Register(string login, string password, string password_repeat);
        public bool DeleteAccount(string login);

        public static IList<UserModel> getUsers()
        {
            return users;
        }
    }
}
