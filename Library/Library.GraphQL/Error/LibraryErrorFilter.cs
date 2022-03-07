using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Error {
    public class LibraryErrorFilter : IErrorFilter {
        public IError OnError(IError error) {
            if (error.Exception is NullReferenceException) {
                var code = "";
                if(error.Exception.Message is not null) {
                    code = error.Exception.Message;
                }
                error = error.RemovePath().RemoveLocations().RemoveExtensions();
                return code != "" ? error.WithCode(code): error.WithCode("NullRef");
            }
            error = error.RemovePath().RemoveLocations();
            return error;
        }
    }
}
