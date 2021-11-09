using System;
using System.Collections.Generic;

namespace Library.Datamodel {
    public class Book {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
