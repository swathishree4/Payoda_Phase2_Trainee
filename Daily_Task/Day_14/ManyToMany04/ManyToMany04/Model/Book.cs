using System.ComponentModel.DataAnnotations;

namespace ManyToMany04.Model
{
    public class Book
    {
        [Key]
        public int BookId { set; get; }
        public string? Title { set; get; }
        public int price {  set; get; }
        //navigation property
        public ICollection<BookAuthor>? BookAuthors { set; get; }
    }
}
