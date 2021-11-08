using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Library.Datamodel;

namespace Library.GraphQL.GraphQLTypes.InputTypes {
    //public class BookCreateType : InputObjectType<Book> {
    //    protected override void Configure(IInputObjectTypeDescriptor<Book> descriptor) {
    //        descriptor.Field(book => book.Id).Type<IntType>().Name("id").Ignore();
    //    }
    //}

    //public class BookUpdateType : ObjectType<Book> {
    //    //protected override void Configure(IInputObjectTypeDescriptor<Book> descriptor) { }
    //    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    //    {
    //        base.Configure(descriptor);
    //    }
    //}
    public record BookCreate(string Title, ICollection<int> Authors);
}
