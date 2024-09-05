using ManyToMany04.Interface;
using ManyToMany04.Model;

namespace ManyToMany04.Service
{
    public class AuthorService
    {
        private readonly IAuthor _akrepo;
        public AuthorService(IAuthor akrepo)
        {
            _akrepo = akrepo;
        }

        public async Task<IEnumerable<Author>> Getak()
        {
            return await _akrepo.GetAuthor();
        }

        public async Task<Author> Getakbyid(int id)
        {
            return await _akrepo.GetAuthorById(id);
        }

        public async Task Addak(Author e)
        {
            await _akrepo.AddAuthor(e);
        }

        public async Task Deleteak(int id)
        {
            await _akrepo.DeleteAuthor(id);
        }

        public async Task Updateak(int id, Author e)
        {
            await _akrepo.EditAuthor(id, e);
        }
    }
}
