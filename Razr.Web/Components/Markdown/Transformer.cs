using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Razr.Web.Components.Markdown
{
    /*
    public class Transformer
    {
        public const string CodeBlockFormat = @"^{0}([\s]?){1}([^`]+){0}";
        public const string CodeBlockMarker = "```";

        public Transformer(string regex, ILanguage language)
        {
            var pre = new Regex(CodeBlockFormat.Apply(CodeBlockMarker, regex), RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
            _transform = text => pre.Replace(text, m => FormatAndColorize(m.Value, language));
            _syntaxHighlighter = new CodeColorizer();
        }

        private Func<string, string> _transform;
        private CodeColorizer _syntaxHighlighter;

        public string Transform(string text)
        {
            // normalize line endings
            text = text.Replace("\r\n", "\n");

            // html encoding
            text = text.Replace(@"\<", "&lt;").Replace(@"\>", "&gt;");
            
            // colorize
            return _transform(text);
        }

        protected string FormatAndColorize(string value, ILanguage language = null)
        {
            var output = new System.Text.StringBuilder();
            foreach (var line in value.Split(new[] { "\n" }, StringSplitOptions.None).Where(s => !s.StartsWith(CodeBlockMarker)))
            {
                if (language == null)
                    output.Append(new string(' ', 4));

                if (line == "\n")
                    output.AppendLine();
                else
                    output.AppendLine(line);
            }

            return language != null
                ? _syntaxHighlighter.Colorize(output.ToString().Trim(), language)
                : output.ToString();
        }
        
        public static IEnumerable<Transformer> GetAll()
        {
            var list = new List<Transformer>();
            list.Add(new Transformer("asax", Languages.Asax));
            list.Add(new Transformer("ashx", Languages.Ashx));
            list.Add(new Transformer("aspx", Languages.Aspx));
            list.Add(new Transformer("aspx-cs", Languages.AspxCs));
            list.Add(new Transformer("aspx-vb", Languages.AspxVb));
            list.Add(new Transformer("(cpp|c\\+\\+){1}", Languages.Cpp));
            list.Add(new Transformer("(c#|csharp){1}", Languages.CSharp));
            list.Add(new Transformer("css", Languages.Css));
            list.Add(new Transformer("html", Languages.Html));
            list.Add(new Transformer("java", Languages.Java));
            list.Add(new Transformer("(js|jscript|javascript){1}", Languages.JavaScript));
            list.Add(new Transformer("php", Languages.Php));
            list.Add(new Transformer("ps", Languages.PowerShell));
            list.Add(new Transformer("sql", Languages.Sql));
            list.Add(new Transformer("(vbnet|vb\\.net){1}", Languages.VbDotNet));
            list.Add(new Transformer("xml", Languages.Xml));
            return list;
        }
        
    }*/
}