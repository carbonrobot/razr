namespace Razr.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Base model for all entities
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Unique model key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The DateTime this model was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The DateTime this model was last changed
        /// </summary>
        public DateTime ChangedDate { get; set; }

        // protected constructor
        protected BaseModel()
        {
            this.Id = -1;
            this.CreatedDate = DateTime.Now;
            this.ChangedDate = DateTime.Now;
        }
    }
}
