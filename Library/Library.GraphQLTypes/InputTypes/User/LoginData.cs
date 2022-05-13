using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.User {
    public class LoginData: InputObjectType {
        public string Email { get; set; }
        public string Password { get; set; }

        protected override void Configure(IInputObjectTypeDescriptor descriptor) {
            descriptor.Field("email").Type<NonNullType<StringType>>();
            descriptor.Field("password").Type<NonNullType<StringType>>();
        }
    }
}
