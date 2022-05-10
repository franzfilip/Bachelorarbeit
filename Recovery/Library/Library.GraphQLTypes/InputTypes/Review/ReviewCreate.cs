using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GraphQLTypes.InputTypes.Review {
    public class ReviewCreate {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
    }
}
