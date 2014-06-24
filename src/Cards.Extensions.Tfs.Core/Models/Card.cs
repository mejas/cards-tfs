using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;

namespace Cards.Extensions.Tfs.Core.Models
{
    /// <summary>
    /// A work item
    /// </summary>
    public class Card
    {
        public Card()
            : this( new DateProvider(), 
                    new EntityFrameworkStorageProvider(), 
                    new WindowsIdentityProvider())
        {
            Active         = true;
            CardActivities = new List<CardActivity>();
        }

        public Card(IDateProvider dateProvider, 
                    IStorageProvider storageProvider, 
                    IIdentityProvider identityProvider)
        {
            DateProvider     = dateProvider;
            StorageProvider  = storageProvider;
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
        public int AreaID { get; set; }

        /// <summary>
        /// Gets or sets the assigned to.
        /// </summary>
        /// <value>
        /// The assigned to.
        /// </value>
        public string AssignedTo { get; set; }

        /// <summary>
        /// Gets or sets the card activities.
        /// </summary>
        /// <value>
        /// The card activities.
        /// </value>
        public List<CardActivity> CardActivities { get; set; }

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
            var dateNow     = DateProvider.Now();
            var currentUser = IdentityProvider.GetUserName();

            var card = new Card()
            {
                CreatedUser = currentUser,
                CreatedDate = dateNow,
                ModifiedUser = currentUser,
                ModifiedDate = dateNow,

                Name        = name,
                Description = description,
                AreaID      = areaID,
                AssignedTo  = assignedTo
            };

            var result = StorageProvider.Add(card);

            CardActivity activity = new CardActivity(StorageProvider, IdentityProvider);
            activity = activity.Add(result.ID, CardActivityType.Add, dateNow);

            result.CardActivities.Add(activity);

            return result;
        }

        /// <summary>
        /// Creates a card using the specified TFS WorkItem
        /// </summary>
        /// <param name="workItem">The work item.</param>
        /// <param name="areaID">The area identifier.</param>
        /// <returns></returns>
        public List<Card> Add(List<WorkItem> workItems, int areaID)
        {
            var dateNow     = DateProvider.Now();
            var currentUser = IdentityProvider.GetUserName();

            List<Card> result = new List<Card>();

            foreach (var workItem in workItems)
            {
                var cardToAdd = new Card()
                {
                    CreatedUser  = currentUser,
                    CreatedDate  = dateNow,
                    ModifiedUser = currentUser,
                    ModifiedDate = dateNow,

                    Name        = workItem.Title,
                    Description = workItem.Description,
                    AreaID      = areaID,
                    AssignedTo  = workItem.AssignedTo,
                    TfsID       = workItem.ID
                };

                var storedCard = StorageProvider.Add(cardToAdd);

                CardActivity activity = new CardActivity(StorageProvider, IdentityProvider);
                storedCard.CardActivities.Add(activity.Add(storedCard.ID, CardActivityType.Add, dateNow));

                result.Add(storedCard);
            }

            return result;
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
                return onUpdate(card, CardActivityType.Modify);
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
                var NOW = DateProvider.Now();

                card.ModifiedDate = NOW;
                card.ModifiedUser = IdentityProvider.GetUserName();

                StorageProvider.RemoveCard(card);

                CardActivity cardActivity = new CardActivity(StorageProvider, IdentityProvider);

                cardActivity.Add(card.ID, CardActivityType.Delete, NOW);
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
                card.AreaID = targetArea.ID;

                return onUpdate(card, CardActivityType.Move);
            }
            else
            {
                return null;
            }
        }

        private Card onUpdate(Card card, CardActivityType cardActivityType)
        {
            var dateNow = DateProvider.Now();

            card.ModifiedDate = dateNow;
            card.ModifiedUser = IdentityProvider.GetUserName();

            var cardResult = StorageProvider.Update(card);

            CardActivity cardActivity = new CardActivity(StorageProvider, IdentityProvider);

            cardResult.CardActivities.Add(cardActivity.Add(card.ID, cardActivityType, dateNow));

            return cardResult;
        }
    }
}
