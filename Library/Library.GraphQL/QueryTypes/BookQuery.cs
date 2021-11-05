using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.QueryTypes {
    public class BookQuery
    {
        private readonly IBookService bookService;

        public BookQuery(IBookService bs)
        {
            bookService = bs;
        }

        public async Task<IEnumerable<Book>> Books()
        {
            return await bookService.GetAll();
        }
    }
}
