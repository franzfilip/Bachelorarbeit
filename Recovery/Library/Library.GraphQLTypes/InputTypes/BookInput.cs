using HotChocolate.Types;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes {
    public class BookInput: InputObjectType {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> Authors { get; set; }

        protected override void Configure(IInputObjectTypeDescriptor descriptor) {
            //descriptor.Field("Authors").Type<ListType<IntType>>();

            //descriptor.Field(a => a.Authors).Type<ListType<IntType>>();
            //descriptor.Field(a => a.Title).Type<StringType>();
            //descriptor.Field(b => b.Reviews).Ignore();
        }
    }
}
