using HotChocolate.Types;
using Library.GraphQLTypes.ObjectTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.GraphQLTypes.InputTypes {
    public class AuthorInput {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Books { get; set; }
        //protected override void Configure(IInputObjectTypeDescriptor descriptor) {
        //    //descriptor.Field(a => a.Books).Type<ListType<NonNullType<IntType>>>();
        //    //descriptor.Field(a => a.FirstName).Type<StringType>();
        //    //descriptor.Field(a => a.LastName).Type<StringType>();
        //}
    }
}
