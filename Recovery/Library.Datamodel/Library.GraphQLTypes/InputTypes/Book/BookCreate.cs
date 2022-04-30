using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Book {
    public class BookCreate {
        public string Title { get; set; }
        public ICollection<int> Authors { get; set; }
    }
}
