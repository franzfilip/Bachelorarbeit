using AutoBetter.BusinessLogic.impl;
using Library.DataAccess;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLogic.Impl {
    public class BookService : BaseService<Book>, IBookService {
        private readonly IBaseService<Author> authorService;
        public BookService(IBookRepository bookRepository, IBaseService<Author> authorService) : base(bookRepository) {
            this.authorService = authorService;
        }

        public override async Task<Book> AddAsync(Book book) {
            return await base.AddAsync(book);
        }

        public override async Task<Book> UpdateAsync(Book book) {
            return await base.UpdateAsync(book);
        }
    }
}
