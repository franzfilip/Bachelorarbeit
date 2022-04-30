using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes {
    public class UserInput {
        public record LoginInput(string Email, string Password);
    }
}
