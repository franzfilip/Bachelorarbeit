using HotChocolate.Types;
using Library.BusinessLogic;
using Library.Datamodel;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class BookQuery {
        private readonly IBookService bookService;

        public BookQuery(IBookService bookService) {
            this.bookService = bookService;
        }

        public async Task<List<Book>> Books() {
            return await bookService.GetAsync(includes: book => book.Authors);
        }

        public async Task<Book> BookById(int id) {
            return await bookService.GetFirstAsync(book => book.Id == id, book => book.Authors);
        }
    }
}
