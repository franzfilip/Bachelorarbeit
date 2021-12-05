using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HotChocolate.Types;
using Library.Datamodel;
using Library.GraphQL.Contract;
using Library.GraphQL.GraphQLTypes.InputTypes;
using Library.GraphQL.Mapping;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class BookMutation {
        private readonly IBookService _bookService;
        private readonly BookMapper _bookMapper;

        public BookMutation(IBookService bookService, BookMapper bookMapper) {
            _bookService = bookService;
            _bookMapper = bookMapper;
        }

        public async Task<Book> CreateBook(BookCreate input) {
            return await _bookService.AddAsync(await _bookMapper.MapBookCreateToBook(input));
        }

        public async Task<Book> UpdateBook(BookUpdate input) {
            return await _bookService.UpdateAsync(await _bookMapper.MapBookUpdateToBook(input));
        }

        public async Task<bool> Delete(int id) => await _bookService.RemoveAsync(id);
    }
}
