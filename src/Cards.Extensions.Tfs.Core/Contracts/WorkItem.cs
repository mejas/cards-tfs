
namespace Cards.Extensions.Tfs.Core.Contracts
{
    /// <summary>
    /// Represents a TFS work item
    /// </summary>
    public class WorkItem
    {
        /// <summary>
        /// Gets or sets the TFS identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the person this item is assigned to.
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        public string AssignedTo { get; set; }
    }
}
