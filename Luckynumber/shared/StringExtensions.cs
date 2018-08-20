using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luckynumber.shared
{
    public static class StringExtensions
    {


        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length, length);






        }

        public static string Truncate(this string value, int maximumLength)
        {
            if (string.IsNullOrEmpty(value) == true) { return value; }
            if (maximumLength < 0) { return String.Empty; }
            if (value.Length > maximumLength) { return value.Substring(0, maximumLength); }
            return value;
        }



    }
}
