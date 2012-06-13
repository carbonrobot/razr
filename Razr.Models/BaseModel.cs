namespace Razr.Models
{
    using System;

    /// <summary>
    /// Base model for all entities
    /// </summary>
    public class BaseModel
    {
        // protected constructor
        protected BaseModel()
        {
            this.Id = -1;
            this.CreatedDate = DateTime.Now;
            this.ChangedDate = DateTime.Now;
        }

        /// <summary>
        /// The DateTime this model was last changed
        /// </summary>
        public DateTime ChangedDate { get; set; }

        /// <summary>
        /// The DateTime this model was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Unique model key
        /// </summary>
        public int Id { get; set; }
    }
}