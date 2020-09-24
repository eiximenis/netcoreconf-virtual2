using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cpaint
{
    static class TokensExtension
    {
        public static (int value, bool found) GetTokenAt(this string[] tokens,int position, int defaultValue = default)
        {
            var numTokens = tokens.Length;
            if (numTokens <= position) return (value: defaultValue, found: false);
            return int.TryParse(tokens[position], out var value) ? (value, found: true) : (value: defaultValue, found: false);
        }
    }
}
