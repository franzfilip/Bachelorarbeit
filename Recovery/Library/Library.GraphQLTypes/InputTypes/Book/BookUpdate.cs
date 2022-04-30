using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Book {
    public class BookUpdate {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<int> Authors { get; set; }
    }
}
