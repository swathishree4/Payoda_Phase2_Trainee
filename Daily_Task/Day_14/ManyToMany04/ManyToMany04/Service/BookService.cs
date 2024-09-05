using ManyToMany04.Interface;
using ManyToMany04.Model;

namespace ManyToMany04.Service
{
    public class BookService
    {
        private readonly IBook _bkrepo;
        public BookService(IBook bkrepo)
        {
            _bkrepo = bkrepo;
        }

        public async Task<IEnumerable<Book>> Getbk()
        {
            return await _bkrepo.GetBook();
        }

        public async Task<Book> Getbkbyid(int id)
        {
            return await _bkrepo.GetBookById(id);
        }

        public async Task Addbk(Book e)
        {
            await _bkrepo.PostBook(e);
        }

        public async Task Deletebk(int id)
        {
            await _bkrepo.DeleteBook(id);
        }

        public async Task Updatebk(int id, Book e)
        {
            await _bkrepo.PutBook(id, e);
        }
    }
}
