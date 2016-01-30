using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Core.Domain
{
    public class User : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }

    }
}
