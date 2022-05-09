using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Datamodel {
    public class Role : BaseEntity {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}