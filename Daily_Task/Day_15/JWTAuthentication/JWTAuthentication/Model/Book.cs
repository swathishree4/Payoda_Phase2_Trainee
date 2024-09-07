using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Model
{
    public class Book
    {
        [Key]
        public int BookId { set; get; } 
         public string BookName { set; get; }       
        public string AuthorName { set; get; }   
        public int price { set; get; }  
    }
}
