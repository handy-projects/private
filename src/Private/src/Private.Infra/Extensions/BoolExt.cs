using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Infra.Extensions
{
    public static class BoolExt
    {
        public static bool Is(this bool? me, bool val)
        {
            return me.HasValue && me.Value == val;
        }
    }
}
