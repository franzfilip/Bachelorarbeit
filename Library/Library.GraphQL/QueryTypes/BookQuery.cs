using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Library.Datamodel;
using Library.GraphQL.Contract;
using Library.GraphQL.DataLoader;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class BookQuery
    {
        private readonly IBookService _bookService;

        public BookQuery(IBookService bs)
        {
            _bookService = bs;
        }

        [Authorize]
        public async Task<IEnumerable<Book>> Books() {
            return await _bookService.GetAllAsync();
        }

        public Book WillFail() {
            Book b = null;
            b.Title = "test";
            return b;
        }

        //[Authorize]
        //public async Task<Book> Book(int id) {
        //    var book = await _bookService.GetByIdAsync(id);
        //    if (book is not null) {
        //        return book;
        //    }

        //    throw new NullReferenceException($"Cannot find Book with ID {id}");
        //}

        [Authorize]
        public Task<Book> Book(int id, BookByIdDataLoader dataLoader, CancellationToken cancellationToken) {
            var data = dataLoader.LoadAsync(id, cancellationToken);
            if (data is null) {
                throw new NullReferenceException($"Cannot find Book with ID {id}");
            }
            return data;
        }
    }
}
