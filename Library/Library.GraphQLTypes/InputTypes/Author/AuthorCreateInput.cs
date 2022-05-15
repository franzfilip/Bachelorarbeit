using HotChocolate.Types;
using Library.GraphQLTypes.InputTypes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Author {
    public class AuthorCreateInput: InputObjectType<AuthorCreate> {
        protected override void Configure(IInputObjectTypeDescriptor<AuthorCreate> descriptor) {
            descriptor.Field(f => f.Books).Type<ListType<NonNullType<IntType>>>();
        }
    }
}
