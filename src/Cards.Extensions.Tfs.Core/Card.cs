using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cards.Extensions.Tfs.Core
{
    public class Card
    {
        public Card()
            : this(new DateProvider(), new EntityFrameworkStorageProvider(), new WindowsIdentityProvider())
        {
            Active = true;
        }

        public Card(IDateProvider dateProvider, IStorageProvider storageProvider, IIdentityProvider identityProvider)
        {
            DateProvider     = dateProvider;
            StorageProvider  = storageProvider;
            IdentityProvider = identityProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }

        [Key]
        public int ID { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaID { get; set; }

        public Card Add(string name, string description, int areaID)
        {
            var card = new Card()
            {
                CreatedUser  = IdentityProvider.GetUserName(),
                CreatedDate  = DateProvider.Now(),
                ModifiedUser = IdentityProvider.GetUserName(),
                ModifiedDate = DateProvider.Now(),

                Name        = name,
                Description = description,
                AreaID      = areaID
            };

            return StorageProvider.Add(card);
        }

        public List<Card> GetAllCards(int area)
        {
            return StorageProvider.GetAllCards(area);
        }

        public Card Get(int id)
        {
            return StorageProvider.GetCard(id);
        }

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
    }
}
