using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.GraphQLTypes.InputTypes;

namespace Library.GraphQL.Contract {
    public interface IBookService : IDataService<Book> {
    }
}
