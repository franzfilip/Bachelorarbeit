using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Resolvers;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.DataLoaders;
using Library.GraphQL.Resolver;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.QueryTypes {
    //[ExtendObjectType(typeof(Query))]
    public class AuthorQuery: ObjectType<Query> {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor) {
            descriptor.Field("authorsConnection")
                .ResolveWith<AuthorResolver>(r => r.Authors())
                .Authorize()
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Type<ListType<NonNullType<AuthorType>>>();

            descriptor.Field("authors")
                .ResolveWith<AuthorResolver>(r => r.Authors())
                .Authorize()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Type<ListType<NonNullType<AuthorType>>>();

            descriptor.Field("author")
                .ResolveWith<AuthorResolver>(r => r.Authors())
                .Authorize()
                .UseSingleOrDefault()
                .UseProjection()
                .UseFiltering()
                .UseSorting()
                .Type<ListType<NonNullType<AuthorType>>>();

            descriptor.Field("authorByDataLoader")
                .UseProjection()
                .ResolveWith<AuthorResolver>(g => g.AuthorByDataLoader(default, default, default))
                .Argument("id", a => a.Type<NonNullType<IntType>>())
                .Type<AuthorType>();
        }

    }
}
