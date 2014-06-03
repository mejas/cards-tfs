namespace Cards.Extensions.Tfs.Core.Contracts
{
    /// <summary>
    /// Contract for requesting items from TFS
    /// </summary>
    public class ImportRequest
    {
        /// <summary>
        /// Gets or sets the TFS work item.
        /// </summary>
        /// <value>
        /// The work item.
        /// </value>
        public int WorkItem { get; set; }

        /// <summary>
        /// Gets or sets the Cards area identifier.
        /// </summary>
        /// <value>
        /// The area identifier.
        /// </value>
        public int AreaID { get; set; }
    }
}
