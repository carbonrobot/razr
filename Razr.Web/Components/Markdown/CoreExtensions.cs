using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razr.Web.Components.Markdown
{
    internal static class CoreExtensions
    {
        internal static string Apply(this string format, params string[] formattingArgs)
        {
            return string.Format(format, formattingArgs);
        }
    }
}
