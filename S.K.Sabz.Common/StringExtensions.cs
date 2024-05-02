using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.K.Sabz.Common
{
    public static class StringExtensions
    {
        public static long? TryParseToLong(this string input)
        {
            if (long.TryParse(input, out long result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
