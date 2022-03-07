using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;
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

        [Authorize(Roles = new[] { "Admin", "Librarian" })]
        public async Task<Book> CreateBook(BookCreate input, [Service] ITopicEventSender sender) {
            try {
                var book = await _bookService.AddAsync(await _bookMapper.MapBookCreateToBook(input));
                await sender.SendAsync("bookAdded", book);
                return book;
            }
            catch (Exception) {
                throw new GraphQLException("Book could not have been created");
            }

        }

        [Authorize(Roles = new[] { "Admin", "Librarian" })]
        public async Task<Book> UpdateBook(BookUpdate input) {
            try {
                return await _bookService.UpdateAsync(await _bookMapper.MapBookUpdateToBook(input));
            }
            catch (Exception) {
                throw new GraphQLException("Book could not have been updated");
            }
        }

        [Authorize(Roles = new[] { "Admin", "Librarian" })]
        public async Task<bool> Delete(int id) {
            try {
                return await _bookService.RemoveAsync(id);
            }
            catch (Exception) {
                throw new GraphQLException("Book could not have been deleted");
            }
        }
    }
}
