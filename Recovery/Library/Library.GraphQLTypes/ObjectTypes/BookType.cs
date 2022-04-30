using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Library.Datamodel;

namespace Library.GraphQLTypes.ObjectTypes {
    public class BookType: ObjectType<Book> {
        //protected override void Configure(IObjectTypeDescriptor<Book> descriptor) { }
    }

    //public class BookSubscriptionType: ObjectType {
    //    protected override void Configure(IObjectTypeDescriptor descriptor) {
    //        descriptor
    //            .Field("bookAdded")
    //            .Type<BookType>()
    //            .Resolve(context => context.GetEventMessage<Book>())
    //            .Subscribe(async context => {
    //                var receiver = context.Service<ITopicEventReceiver>();

    //                ISourceStream stream = await receiver.SubscribeAsync<string, Book>("bookAdded");

    //                return stream;
    //            });
    //    }
    //}
}
