using HotChocolate.Types;
using Library.BusinessLogic;
using Library.Datamodel;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class BookQuery {
        public async Task<IQueryable<Book>> Books([Service] IBookService bookService) {
            return await bookService.GetAsync(includes: book => book.Authors);
        }

        public async Task<Book> BookById([Service] IBookService bookService, int id) {
            return await bookService.GetFirstAsync(book => book.Id == id, book => book.Authors);
        }
    }
}
