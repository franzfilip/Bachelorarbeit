using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQL.Resolver;
using Library.GraphQLTypes.InputTypes;
using Library.GraphQLTypes.InputTypes.Author;
using Library.GraphQLTypes.InputTypes.Book;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.MutationTypes {
    public class AuthorMutation: ObjectType<Mutation> {

        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor) {
            descriptor.Field("createAuthor")
                .Argument("input", a => a.Type<NonNullType<AuthorCreateInput>>())
                .ResolveWith<AuthorResolver>(r => r.CreateAuthor(default, default))
                .Type<AuthorType>();

            descriptor.Field("updateAuthor")
                .Argument("input", a => a.Type<NonNullType<AuthorUpdateInput>>())
                .ResolveWith<AuthorResolver>(r => r.UpdateAuthor(default, default))
                .Type<AuthorType>();
        }
    }
}
