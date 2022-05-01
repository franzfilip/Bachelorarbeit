using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Author {
    public class AuthorCreate {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<int> Books { get; set; }
    }
}
