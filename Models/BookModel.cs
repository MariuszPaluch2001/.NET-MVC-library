using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BookModel
    {
        public int id { get; set; }
        [DisplayName("Autor")]
        public string author { get; set; }
        [DisplayName("Tytuł")]
        public string title { get; set; }
        [DisplayName("Data")]
        public int date { get; set; }
        [DisplayName("Wydawca")]
        public string publisher { get; set; }
        [DisplayName("Użytkownik")]
        public string user { get; set; }
        [DisplayName("Data zarezerwowania")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? reserved { get; set; }
        [DisplayName("Data wypożyczenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? leased { get; set; }
    }
}
