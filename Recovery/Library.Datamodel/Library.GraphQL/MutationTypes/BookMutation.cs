using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes;
using Library.GraphQLTypes.InputTypes.Book;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class BookMutation {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookMutation(IBookService bookService, IMapper mapper) {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        public async Task<Book> CreateBook(BookCreate input) {
            if(input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Book book = mapper.Map<Book>(input);
            return await bookService.AddAsync(book);
        }

        public async Task<Book> UpdateBook(BookUpdate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Book book = mapper.Map<Book>(input);
            return await bookService.UpdateAsync(book);
        }
    }
}
