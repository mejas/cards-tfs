using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;

namespace Cards.Extensions.Tfs.Core.Contracts
{
    /// <summary>
    /// A work item
    /// </summary>
    public class Card
    {
        public Card()
            : this(new DateProvider(), new EntityFrameworkStorageProvider(), new WindowsIdentityProvider(), new TFSImportProvider())
        {
            Active = true;
        }

        public Card(IDateProvider dateProvider, 
                    IStorageProvider storageProvider, 
                    IIdentityProvider identityProvider, 
                    ITFSProvider importProvider)
        {
            DateProvider     = dateProvider;
            StorageProvider  = storageProvider;
            IdentityProvider = identityProvider;
            ImportProvider   = importProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }
        protected ITFSProvider ImportProvider { get; set; }

        /// <summary>
        /// Gets or sets the database identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Card"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

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
        /// Gets or sets the TFS identifier, if the item is linked to a TFS Work Item.
        /// </summary>
        /// <value>
        /// The TFS identifier.
        /// </value>
        public int TfsID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the area identifier.
        /// </summary>
        /// <value>
        /// The area identifier.
        /// </value>
        public int AreaId { get; set; }

        /// <summary>
        /// Gets or sets the assigned to.
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        public string AssignedTo { get; set; }

        /// <summary>
        /// Creates a card using the specified parameters.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="assignedTo">The person who this item is assigned to.</param>
        /// <param name="areaID">The area identifier.</param>
        /// <returns></returns>
        public Card Add(string name, string description, string assignedTo, int areaID)
        {
            var card = new Card()
            {
                CreatedUser  = IdentityProvider.GetUserName(),
                CreatedDate  = DateProvider.Now(),
                ModifiedUser = IdentityProvider.GetUserName(),
                ModifiedDate = DateProvider.Now(),
                
                Name = name,
                Description = description,
                AreaId = areaID,
                AssignedTo = assignedTo
            };

            return StorageProvider.Add(card);
        }


        /// <summary>
        /// Creates a card using the specified parameters.
        /// </summary>
        /// <param name="tfsID">The TFS identifier.</param>
        /// <param name="areaID">The area identifier.</param>
        /// <returns></returns>
        public Card Add(int tfsID, int areaID)
        {
            var tfsItem = ImportProvider.GetTFSItem(tfsID);

            if (tfsItem != null)
            {
                var card = new Card()
                {
                    CreatedUser = IdentityProvider.GetUserName(),
                    CreatedDate = DateProvider.Now(),
                    ModifiedUser = IdentityProvider.GetUserName(),
                    ModifiedDate = DateProvider.Now(),

                    Name        = tfsItem.Title,
                    Description = tfsItem.Description,
                    AreaId      = areaID,
                    AssignedTo  = tfsItem.AssignedTo,
                    TfsID       = tfsItem.ID
                };

                return StorageProvider.Add(card);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all Cards from a given area.
        /// </summary>
        /// <param name="areaID">The area identifier.</param>
        /// <returns></returns>
        public List<Card> GetAll(int areaID)
        {
            return StorageProvider.GetAllCards(areaID);
        }

        /// <summary>
        /// Gets the card with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Card Get(int id)
        {
            return StorageProvider.GetCard(id);
        }

        /// <summary>
        /// Updates the specified card.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <returns></returns>
        public Card Update(Card card)
        {
            if (card != null)
            {
                card.ModifiedDate = DateProvider.Now();
                card.ModifiedUser = IdentityProvider.GetUserName();
                return StorageProvider.Update(card);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes the card with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(int id)
        {
            var card = Get(id);

            if (card != null)
            {
                card.ModifiedDate = DateProvider.Now();
                card.ModifiedUser = IdentityProvider.GetUserName();

                StorageProvider.RemoveCard(card);
            }
        }

        /// <summary>
        /// Moves the card with the specified identifier to the target area.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="targetArea">The target area.</param>
        /// <returns></returns>
        public Card Move(int id, Area targetArea)
        {
            var card = Get(id);

            if (card != null)
            {
                card.AreaId = targetArea.ID;
                card.Update(card);

                return card;
            }
            else
            {
                return null;
            }
        }
    }
}
