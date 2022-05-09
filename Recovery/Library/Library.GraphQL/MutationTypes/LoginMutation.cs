using Library.BusinessLogic;
using Library.GraphQLTypes.InputTypes.Author;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class LoginMutation {
        private readonly IAuthService _authService;

        public LoginMutation(IAuthService authService) {
            _authService = authService;
        }

        public async Task<string> Login(LoginData input) {
            return await _authService.Login(input.Email, input.Password);
        }
    }
}
