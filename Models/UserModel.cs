using System.ComponentModel;

namespace LibraryManagement.Models
{
    public class UserModel
    {
        public int id { get; set; }
        [DisplayName("")]
        public string login { get; set; }
        [DisplayName("Hasło")]
        public string password { get; set; }
    }
}
