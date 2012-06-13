namespace Razr.Models.Annotations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Requires the string property to conform to an email address
    /// </summary>
    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute() : base("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$") { }
    }
}
