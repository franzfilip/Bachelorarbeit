using HotChocolate;
using HotChocolate.Types;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.SubscriptionTypes {
    [ExtendObjectType (Name="Subscription")]
    public class BookSubscription {
        [Subscribe]
        [Topic("bookAdded")]
        public Book BookAdded([EventMessage] Book book) => book;
    }
}
