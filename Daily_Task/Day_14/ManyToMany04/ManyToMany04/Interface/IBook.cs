using ManyToMany04.Model;

namespace ManyToMany04.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetBook();
        Task<Book> GetBookById(int BookId);
        Task PostBook(Book book);
        Task PutBook(int id,Book book);
        Task DeleteBook(int BookId);


    }
}
