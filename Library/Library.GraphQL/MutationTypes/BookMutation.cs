using AutoMapper;
using HotChocolate.Configuration;
using HotChocolate.Subscriptions;
using HotChocolate.Types.Descriptors.Definitions;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQL.Resolver;
using Library.GraphQLTypes.InputTypes;
using Library.GraphQLTypes.InputTypes.Book;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.MutationTypes {
    public class BookMutation: ObjectTypeExtension<Mutation>{
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor) {
            descriptor.Field("createBook")
                .Argument("input", a => a.Type<NonNullType<BookCreateInput>>())
                .ResolveWith<BookResolver>(r => r.CreateBook(default, default, default))
                .Type<BookType>();

            descriptor.Field("updateBook")
                .Argument("input", a => a.Type<NonNullType<BookUpdateInput>>())
                .ResolveWith<BookResolver>(r => r.UpdateBook(default, default))
                .Type<BookType>();
        }
    }
}
