using HotChocolate.Types;
using Library.Datamodel;

namespace Library.GraphQL.GraphQLTypes.ObjectTypes {
    public class BookType: ObjectType<Book> {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor) { }
    }
}
