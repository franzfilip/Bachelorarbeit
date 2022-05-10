using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class BookQuery {
        
        [Authorize]
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Book>> BooksWithPaging([Service] IBookService bookService) {
            return await bookService.GetAsync();
        }

        [Authorize]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Book>> Books([Service] IBookService bookService) {
            return await bookService.GetAsync();
        }

        [Authorize]
        [UseSingleOrDefault]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Book>> Book([Service] IBookService bookService) {
            return await bookService.GetAsync();
        }
    }
}
