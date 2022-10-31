using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("Users")]
    public class UserModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Pole 'login' jest wymagane")]
        [DisplayName("Login")]
        public string? login { get; set; }
        [Required(ErrorMessage = "Pole 'hasło' jest wymagane")]
        [DisplayName("Hasło")]
        public string? password { get; set; }
        [DisplayName("Administrator")]
        public bool isSuperUser { get; set; }
    }
}
