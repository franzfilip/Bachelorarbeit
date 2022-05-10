using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.User;

namespace Library.GraphQL.Resolver {
    public class AuthResolver {
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        public AuthResolver(IAuthService authService, IMapper mapper) {
            this.authService = authService;
            this.mapper = mapper;
        }

        public async Task<string> Login(string email, string password) {
            return await authService.Login(email, password);
        }

        public async Task<string> Register(RegisterData input) {
            return await authService.Register(mapper.Map<User>(input));
        }
    }
}
