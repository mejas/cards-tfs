using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cards.Extensions.Tfs.Core.Models
{
    /// <summary>
    /// Defines a specific area where a set of cards can be associated
    /// </summary>
    public class Area
    {

        public Area()
            : this(new DateProvider(), new EntityFrameworkStorageProvider(), new WindowsIdentityProvider())
        {
            Active = true;
            Cards  = new List<Card>();
        }

        public Area(IDateProvider dateProvider, IStorageProvider storageProvider, IIdentityProvider identityProvider)
        {
            DateProvider = dateProvider;
            StorageProvider = storageProvider;
            IdentityProvider = identityProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }

        /// <summary>
        /// Gets or sets the database identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        /// <value>
        /// The cards.
        /// </value>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        /// <value>
        /// The created user.
        /// </value>
        public string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets the modified user.
        /// </summary>
        /// <value>
        /// The modified user.
        /// </value>
        public string ModifiedUser { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Area"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Creates an area given the name.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <returns></returns>
        public Area Add(string areaName)
        {
            var area = new Area()
            {
                Name         = areaName,
                CreatedUser  = IdentityProvider.GetUserName(),
                ModifiedUser = IdentityProvider.GetUserName(),
                CreatedDate  = DateProvider.Now(),
                ModifiedDate = DateProvider.Now()
            };

            return StorageProvider.Add(area);
        }

        /// <summary>
        /// Gets all areas.
        /// </summary>
        /// <returns></returns>
        public List<Area> GetAll()
        {
            return StorageProvider.GetAllAreas();
        }

        /// <summary>
        /// Gets the specified area given the identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Area Get(int id)
        {
            return StorageProvider.GetArea(id);
        }

        /// <summary>
        /// Updates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns></returns>
        public Area Update(Area area)
        {
            if (area != null)
            {
                area.ModifiedUser = IdentityProvider.GetUserName();
                area.ModifiedDate = DateProvider.Now();
                return StorageProvider.Update(area);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes the specified area given the id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(int id)
        {
            var area = Get(id);

            if (area != null)
            {
                area.ModifiedDate = DateProvider.Now();
                area.ModifiedUser = IdentityProvider.GetUserName();

                StorageProvider.RemoveArea(area);
            }
        }
    }
}
