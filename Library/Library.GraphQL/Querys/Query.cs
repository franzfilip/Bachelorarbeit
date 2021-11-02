using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.Querys {
    public class Query
    {
        private readonly IBookService bookService;

        public Query(IBookService bs)
        {
            bookService = bs;
        }

        public async Task<IEnumerable<Book>> Books()
        {
            return await bookService.GetAll();
        }
    }
}
