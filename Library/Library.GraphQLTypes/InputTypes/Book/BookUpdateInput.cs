using HotChocolate.Types;
using Library.GraphQLTypes.InputTypes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Book {
    public class BookUpdateInput: InputObjectType<BookUpdate> {

        protected override void Configure(IInputObjectTypeDescriptor<BookUpdate> descriptor) {
            descriptor.Field(f => f.Authors).Type<ListType<NonNullType<IntType>>>();
        }
    }
}
