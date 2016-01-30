using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Infra.Extensions
{
    public static class StringExt
    {
        public static bool IsNullOrEmpty(this string me)
        {
            return string.IsNullOrEmpty(me);
        }

        public static bool Is(this string me, string another)
        {
            return me == another;
        }
    }
}
