using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Error {
    public class LibraryErrorFilter : IErrorFilter {
        public IError OnError(IError error) {
            return error.RemoveExtensions().WithMessage(error.Exception.Message);
        }
    }
}
