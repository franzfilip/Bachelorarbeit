using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Datamodel;

namespace Library.GraphQLTypes.InputTypes.User {
    public class RegisterData : InputObjectType<Datamodel.User> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
