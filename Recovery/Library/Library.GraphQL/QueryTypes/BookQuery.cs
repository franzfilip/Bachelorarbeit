using HotChocolate.Types;
using Library.BusinessLogic;
using Library.Datamodel;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class BookQuery {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Book>> Books([Service] IBookService bookService) {
            return await bookService.GetAsync();
        }
    }
}
