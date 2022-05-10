using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Library.Datamodel;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.Resolver {
    public class BookResolver : ObjectType<Book> {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor) {
            descriptor
                .Field("bookAdded")
                .Type<BookType>()
                .Resolve(context => context.GetEventMessage<Book>())
                .Subscribe(async context => {
                    var receiver = context.Service<ITopicEventReceiver>();

                    ISourceStream stream = await receiver.SubscribeAsync<string, Book>("bookAdded");

                    return stream;
                });
        }
    }
}
