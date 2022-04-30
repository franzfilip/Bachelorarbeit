using System;
using System.Collections.Generic;

namespace Library.Datamodel {
    public class Book: BaseEntity {
        public string Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
