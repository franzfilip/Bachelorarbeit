using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;

namespace Library.GraphQL.Contract {
    public interface IBookService : IDataService<Book>
    {
        public Task<Book> AddWithAuthorsAsync(string title, ICollection<int> authorsToAdd);
    }
}
