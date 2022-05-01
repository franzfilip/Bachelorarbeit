using AutoBetter.BusinessLogic.impl;
using Library.DataAccess;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLogic.Impl {
    public class AuthorService : BaseService<Author>, IAuthorService {
        public AuthorService(IAuthorRepository repository) : base(repository) {
        }
    }
}
