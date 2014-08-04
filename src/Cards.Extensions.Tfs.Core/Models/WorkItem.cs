using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;

namespace Cards.Extensions.Tfs.Core.Models
{
    /// <summary>
    /// Represents a TFS work item
    /// </summary>
    public class WorkItem
    {
        public WorkItem()
            : this(new TFSProvider())
        { }

        public WorkItem(ITFSProvider tfsProvider)
        {
            TFSProvider = tfsProvider;
        }

        /// <summary>
        /// Gets or sets the TFS identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
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

        protected ITFSProvider TFSProvider { get; set; }

        public WorkItem Get(int tfsID)
        {
            return TFSProvider.GetTFSItem(tfsID);
        }

        public List<WorkItem> Get(string queryName)
        {
            return TFSProvider.GetTFSItems(queryName);
        }
    }
}
