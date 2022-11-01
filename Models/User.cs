using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Pole 'login' jest wymagane")]
        [MaxLength(30)]
        [DisplayName("Login")]
        public string? login { get; set; }
        [Required(ErrorMessage = "Pole 'hasło' jest wymagane")]
        [MaxLength(50)]
        [DisplayName("Hasło")]
        public string? password { get; set; }
        [DisplayName("Administrator")]
        public bool isSuperUser { get; set; }

        public virtual List<Book> books { get; set; }
    }
}
