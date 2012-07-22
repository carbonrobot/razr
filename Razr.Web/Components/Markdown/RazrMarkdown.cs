using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarkdownSharp;

namespace Razr.Web.Components.Markdown
{
    public class RazrMarkdown
    {
        
        public RazrMarkdown() { 
            _markdown = new MarkdownSharp.Markdown(createMarkdownOptions());
			_tranformers = new Tranformers();
        }

        private readonly ITranformers _tranformers;
        private readonly MarkdownSharp.Markdown _markdown;

        
        public string Transform(string markdownText)
        {
            foreach (var preTransformation in _tranformers.GetTransformers())
                markdownText = preTransformation.Invoke(markdownText);

            return _markdown.Transform(markdownText);
        }

        private MarkdownOptions createMarkdownOptions()
        {
            return new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = false,
                EncodeProblemUrlCharacters = true,
                LinkEmails = true
            };
        }

    }
}