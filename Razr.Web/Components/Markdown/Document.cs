using System;

namespace Razr.Web.Components.Markdown
{
    [Serializable]
    public class Document
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}