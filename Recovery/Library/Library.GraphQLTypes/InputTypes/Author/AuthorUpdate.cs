﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Author {
    public class AuthorUpdate {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<int> Books { get; set; }
    }
}
