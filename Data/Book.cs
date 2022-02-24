using System.ComponentModel.DataAnnotations;
namespace Library.Data

{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? BookName { get; set; }
        public string? Author { get; set; }
        [Required]
        public int Price { get; set; }

        public Book()
        {

        }
    }
}
