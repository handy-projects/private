using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Infra.Errors
{
    public class ValidationError : Exception
    {
        public ValidationError(string err): base(err)
        {

        }
    }
}
