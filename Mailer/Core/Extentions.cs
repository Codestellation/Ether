using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codestellation.Mailer.Core
{
    public static class Extentions
    {
        public static string[] SplitAndTrim(this string self)
        {
            return self
                .Split(',')
                .Select(v => v.Trim())
                .Where(v => !string.IsNullOrEmpty(v))
                .ToArray();
        }

        public static string Collect(this IEnumerable<string> self)
        {
            return string.Join(", ", self);
        }
    }
}
