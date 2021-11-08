using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HotChocolate.Types;
using Library.Datamodel;
using Library.GraphQL.Contract;
using Library.GraphQL.GraphQLTypes.InputTypes;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class BookMutation
    {
        private readonly IBookService _bookService;

        public BookMutation(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Book> CreateBook(Book input)
        {
            //var book2 = new Book()
            //{
            //    Title = book.
            //}
            //await _bookService.AddAsync(book);
            return new Book();
        }

        public async Task<Book> Update(BookCreateType input) {
            //await _bookService.UpdateAsync(book);
            return new Book();
        }
        //public async Task Delete(int id) => await _bookService.RemoveAsync(id);
    }
}
