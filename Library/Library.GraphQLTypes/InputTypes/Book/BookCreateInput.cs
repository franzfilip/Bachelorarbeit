using HotChocolate.Types;
using Library.GraphQLTypes.InputTypes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Book {
    public class BookCreateInput: InputObjectType<BookCreate> {
        protected override void Configure(IInputObjectTypeDescriptor<BookCreate> descriptor) {
            descriptor.Field(f => f.Authors).Type<ListType<NonNullType<IntType>>>();
        }
    }
}
