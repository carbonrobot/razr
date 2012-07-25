using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarkdownSharp;

namespace Razr.Web.Components.Markdown
{
    public class RazrMarkdown
    {
        private MarkdownSharp.Markdown _markdown;
        private IEnumerable<Transformer> _tranformers;

        public RazrMarkdown()
        {
            _markdown = new MarkdownSharp.Markdown(new MarkdownOptions
            {
                AutoHyperlink = true,
                AutoNewLines = false,
                EncodeProblemUrlCharacters = true,
                LinkEmails = true
            });
            _tranformers = Transformer.GetAll();
        }

        public string Transform(string markdownText)
        {
            foreach (var transformer in _tranformers)
                markdownText = transformer.Transform(markdownText);
            
            return _markdown.Transform(markdownText);
        }

        /*
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
         */

    }
}