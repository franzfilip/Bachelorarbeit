using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.Author;
using Library.GraphQLTypes.InputTypes.User;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.MutationTypes {
    //[ExtendObjectType(Name = "Mutation")]
    //public class AuthMutation {
    //    private readonly IAuthService authService;
    //    private readonly IMapper mapper;
    //    public AuthMutation(IAuthService authService, IMapper mapper) {
    //        this.authService = authService;
    //        this.mapper = mapper;
    //    }

    //    public async Task<string> Login(LoginData input) {
    //        return await authService.Login(input.Email, input.Password);
    //    }

    //    public async Task<string> Register(RegisterData input) {
    //        return await authService.Register(mapper.Map<User>(input));
    //    }
    //}

    //public class AuthMutationType: ObjectType<AuthMutation>{
    //    protected override void Configure(IObjectTypeDescriptor<AuthMutation> descriptor) {
    //        descriptor.ExtendsType<Mutation>();
    //        descriptor.Field(f => f.Register(default)).Type<UserType>();
    //    }
    //}


    public class AuthMutationTypeExtension : ObjectTypeExtension<Mutation> {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor) {
            //descriptor.ExtendsType<Mutation>();
            //descriptor.Field(f => f.Register(default)).Type<UserType>();
            descriptor.Field("Register")
                .ResolveWith<AuthResolver>(r => r.Register(default))
                .Argument("RegisterData", r => r.Type<RegisterData>())
                .Type<UserType>();
        }
    }

    public class AuthResolver {
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        public AuthResolver(IAuthService authService, IMapper mapper) {
            this.authService = authService;
            this.mapper = mapper;
        }

        public async Task<string> Login(LoginData input) {
            return await authService.Login(input.Email, input.Password);
        }

        public async Task<string> Register(RegisterData input) {
            return await authService.Register(mapper.Map<User>(input));
        }
    }
}
