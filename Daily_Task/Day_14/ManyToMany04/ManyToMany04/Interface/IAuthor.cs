using ManyToMany04.Model;

namespace ManyToMany04.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAuthor();
        Task<Author> GetAuthorById(int AuthorId);
        Task AddAuthor(Author author);
        Task EditAuthor(int id, Author author);
        Task DeleteAuthor(int AuthorId);
    }
}
