using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes {
    public record AuthorCreate(string FirstName, string LastName, ICollection<int> Books);
    public record AuthorUpdate(int Id, string FirstName, string LastName, ICollection<int> Books);
}
