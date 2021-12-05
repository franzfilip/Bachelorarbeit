using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Library.Datamodel;

namespace Library.GraphQL.GraphQLTypes.InputTypes {
    public record BookCreate(string Title, ICollection<int> Authors);
    public record BookUpdate(int Id, string Title, ICollection<int> Authors);
}
