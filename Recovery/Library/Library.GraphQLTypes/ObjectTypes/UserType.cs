using HotChocolate.Types;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.ObjectTypes {
    public class UserType : ObjectType<User> {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor) {
            descriptor.Ignore(f => f.Password);
        }
    }
}
