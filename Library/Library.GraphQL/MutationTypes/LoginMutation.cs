using HotChocolate.Types;
using Library.GraphQL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Library.GraphQL.GraphQLTypes.InputTypes.UserInput;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class LoginMutation {

        private readonly IAuthService _authService;

        public LoginMutation(IAuthService authService) {
            _authService = authService;
        }

        public string Login(LoginInput input) {
            return _authService.Login(input.Email, input.Password);
        }
    }
}
