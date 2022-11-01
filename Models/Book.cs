using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    [Table("Books")]
    public class Book
    {
        private User _user;
        private ILazyLoader LazyLoader { get; set; }
        public Book() { }
        private Book(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        [Key]
        public int id { get; set; }
        [DisplayName("Autor")]
        [MaxLength(30)]
        public string? author { get; set; }
        [DisplayName("Tytuł")]
        [MaxLength(30)]
        public string? title { get; set; }
        [DisplayName("Data")]
        public int date { get; set; }
        [DisplayName("Wydawca")]
        [MaxLength(50)]
        public string? publisher { get; set; }
        [DisplayName("Użytkownik")]
        [ForeignKey("User")]
        public virtual User? user { 
            get => LazyLoader.Load(this, ref _user); 
            set => _user = value; 
        }
        [DisplayName("Data zarezerwowania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? reserved { get; set; }
        [DisplayName("Data wypożyczenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? leased { get; set; }
        public DateTime bookAddTimestamp { get; set; }
    }
}
