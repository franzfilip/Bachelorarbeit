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

        public async Task<Book> CreateBook(BookCreate input)
        {
            if (input.Authors is null)
            {
                return await _bookService.AddAsync(new Book
                {
                    Title = input.Title
                });
            }

            return await _bookService.AddWithAuthorsAsync(input.Title, input.Authors);
        }

        public async Task<Book> UpdateBook(Book input)
        {
            return await _bookService.UpdateAsync(input);
        }
        public async Task Delete(int id) => await _bookService.RemoveAsync(id);
    }
}
