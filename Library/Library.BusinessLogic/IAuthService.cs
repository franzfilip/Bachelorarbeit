using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLogic {
    public interface IAuthService {
        public Task<string> Register(User entity);
        public Task<string> Login(string email, string password);
    }
}
