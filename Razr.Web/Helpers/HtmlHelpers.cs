using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razr.Web.Components.Markdown;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Markdown(this HtmlHelper helper, string text)
        {
            var markdown = new RazrMarkdown();
            string html = markdown.Transform(text);
            return MvcHtmlString.Create(html);
        }
    }
}