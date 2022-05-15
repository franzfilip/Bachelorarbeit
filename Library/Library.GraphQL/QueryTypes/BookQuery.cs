using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.Resolver;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.QueryTypes {
    public class BookQuery: ObjectTypeExtension<Query>{

        protected override void Configure(IObjectTypeDescriptor<Query> descriptor) {
            descriptor.Field("booksConnection")
                .ResolveWith<BookResolver>(r => r.Books(default))
                .Authorize()
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Type<ListType<NonNullType<BookType>>>();

            descriptor.Field("books")
                .ResolveWith<BookResolver>(r => r.Books(default))
                .Authorize()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Type<ListType<NonNullType<AuthorType>>>();

            descriptor.Field("book")
                .ResolveWith<BookResolver>(r => r.Books(default))
                .Authorize()
                .UseSingleOrDefault()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Type<ListType<NonNullType<AuthorType>>>();
        }
    }
}
