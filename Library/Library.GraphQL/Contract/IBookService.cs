using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;

namespace Library.GraphQL.Contract {
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAll();
        public Task<Book> Add(Book book);
        public Task<Book> Update(Book book);
        public Task Remove(int id);
    }
}
