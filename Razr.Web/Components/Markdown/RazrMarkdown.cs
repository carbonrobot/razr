using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Razr.Web.Components.Markdown
{
    
    public class RazrMarkdown
    {
        private MarkdownDeep.Markdown _markdown;

        public RazrMarkdown()
        {
            _markdown = new MarkdownDeep.Markdown();
            _markdown.ExtraMode = true;
        }

        public string Transform(string markdownText)
        {
            return _markdown.Transform(markdownText);
        }

    }
}