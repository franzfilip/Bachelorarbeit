using AutoMapper;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.DTO;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.Resolver {
    public class BookResolver {
        private readonly IMapper mapper;

        public BookResolver(IMapper mapper) {
            this.mapper = mapper;
        }
        public async Task<IQueryable<Book>> Books([Service]IBookService bookService) {
            return await bookService.GetAsync();
        }

        public async Task<Book> CreateBook([Service] IBookService bookService, BookCreate input,[Service] ITopicEventSender sender) {
            var book = await bookService.AddAsync(mapper.Map<Book>(input));
            await sender.SendAsync("bookAdded", book);
            return book;
        }

        public async Task<Book> UpdateBook([Service] IBookService bookService, BookUpdate input) {
            return await bookService.UpdateAsync(mapper.Map<Book>(input));
        }

        //protected override void Configure(IObjectTypeDescriptor<Book> descriptor) {
        //    descriptor
        //        .Field("bookAdded")
        //        .Type<BookType>()
        //        .Resolve(context => context.GetEventMessage<Book>())
        //        .Subscribe(async context => {
        //            var receiver = context.Service<ITopicEventReceiver>();

        //            ISourceStream stream = await receiver.SubscribeAsync<string, Book>("bookAdded");

        //            return stream;
        //        });
        //}
    }
}
