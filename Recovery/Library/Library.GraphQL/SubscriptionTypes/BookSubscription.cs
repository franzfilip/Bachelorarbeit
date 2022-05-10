using Library.Datamodel;

namespace Library.GraphQL.SubscriptionTypes {
    [ExtendObjectType(Name = "Subscription")]
    public class BookSubscription {
        [Subscribe]
        [Topic("bookAdded")]
        public Book BookAdded([EventMessage] Book book) => book;
    }
}
