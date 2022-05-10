using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQL.Resolver;
using Library.GraphQLTypes.InputTypes.User;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.MutationTypes {
    public class AuthMutationTypeExtension : ObjectTypeExtension<Mutation> {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor) {
            descriptor.Field("register")
                .Argument("input", r => r.Type<UserInput>())
                .ResolveWith<AuthResolver>(r => r.Register(default))
                .Type<UserType>();

            descriptor.Field("login")
                .Argument("email", r => r.Type<StringType>())
                .Argument("password", r => r.Type<StringType>())
                .ResolveWith<AuthResolver>(r => r.Login(default, default))
                .Type<StringType>();
        }
    }
}
