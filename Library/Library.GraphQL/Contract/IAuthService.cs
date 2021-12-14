using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Contract {
    public interface IAuthService {
        public string Login(string email, string password);
    }
}
