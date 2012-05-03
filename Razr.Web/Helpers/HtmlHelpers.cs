using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Markdown(this HtmlHelper helper, string text)
        {
            var markdown = new MarkdownSharp.Markdown();
            string html = markdown.Transform(text);
            return MvcHtmlString.Create(html);
        }
    }
}