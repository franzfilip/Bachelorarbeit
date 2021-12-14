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
        public async Task<IEnumerable<Book>> Books() => await _bookService.GetAllAsync();
        [Authorize(Roles = new[] {"Admin"})]
        public async Task<Book> Book(int id) => await _bookService.GetByIdAsync(id);
    }
}
