using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Library.Datamodel;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.SubscriptionTypes {
    public class BookSubscription: ObjectTypeExtension<Subscription> {
        //[Subscribe]
        //[Topic("bookAdded")]
        //public Book BookAdded([EventMessage] Book book) => book;
        protected override void Configure(IObjectTypeDescriptor<Subscription> descriptor) {
            descriptor
            .Field("bookAdded")
            .Type<BookType>()
            .Resolve(context => context.GetEventMessage<Book>())
            .Subscribe(async context => {
                var receiver = context.Service<ITopicEventReceiver>();
                return await receiver.SubscribeAsync<string, Book>("bookAdded");
            });
        }
    }
}
