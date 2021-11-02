using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.Mutations {
    public class Mutation
    {
        private readonly IBookService bookService;

        public Mutation(IBookService bs)
        {
            bookService = bs;
        }

        public async Task<Book> Create(Book book) => await bookService.Add(book);
    }
}
