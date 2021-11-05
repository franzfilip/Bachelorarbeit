using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;

namespace Library.GraphQL.Contract {
    public interface IAuthorService {
        public Task<IEnumerable<Author>> GetAll();
        public Task<Author> Add(Author author);
        public Task<Author> Update(Author author);
        public Task Remove(int id);
    }
}
