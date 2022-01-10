using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(Name = "Query")]
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

        [Authorize]
        public async Task<Book> Book(int id) {
            var book = await _bookService.GetByIdAsync(id);
            if(book is not null) {
                return book;
            }

            throw new NullReferenceException($"Cannot find Book with ID {id}");
        }
    }
}
