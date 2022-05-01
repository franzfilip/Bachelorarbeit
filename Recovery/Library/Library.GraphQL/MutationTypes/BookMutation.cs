using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes;
using Library.GraphQLTypes.InputTypes.Book;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class BookMutation {
        private readonly IMapper mapper;

        public BookMutation(IMapper mapper) {
            this.mapper = mapper;
        }

        public async Task<Book> CreateBook([Service]IBookService bookService, BookCreate input) {
            if(input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Book book = mapper.Map<Book>(input);
            return await bookService.AddAsync(book);
        }

        public async Task<Book> UpdateBook([Service]IBookService bookService, BookUpdate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Book book = mapper.Map<Book>(input);
            return await bookService.UpdateAsync(book);
        }
    }
}
