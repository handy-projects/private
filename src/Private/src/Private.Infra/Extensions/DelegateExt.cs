using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Infra.Extensions
{
    public static class DelegateExt
    {
        public static void Raise(this Action ev)
        {
            if (ev != null)
            {
                ev();
            }
        }
    }
}
