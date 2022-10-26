using System.ComponentModel;

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
        public string reserved { get; set; }
        [DisplayName("Data wypożyczenia")]
        public string leased { get; set; }
    }
}
