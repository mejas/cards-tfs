using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cards.Extensions.Tfs.Core.Contracts
{
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

        [Key]
        public int ID { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }

        public Card Add(string name, string description, int areaID)
        {
            var card = new Card()
            {
                CreatedUser  = IdentityProvider.GetUserName(),
                CreatedDate  = DateProvider.Now(),
                ModifiedUser = IdentityProvider.GetUserName(),
                ModifiedDate = DateProvider.Now(),

                Name = name,
                Description = description,
                AreaId = areaID
            };

            return StorageProvider.Add(card);
        }

        public Card Add(int id, int areaID)
        {
            var tfsItem = ImportProvider.GetTFSItem(id);

            if (tfsItem != null)
            {
                return Add(tfsItem.Title, tfsItem.Description, areaID);
            }
            else
            {
                return null;
            }
        }

        public List<Card> GetAll(int areaID)
        {
            return StorageProvider.GetAllCards(areaID);
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
