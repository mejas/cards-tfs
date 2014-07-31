using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;

namespace Cards.Extensions.Tfs.Core.Models
{
    public class Label
    {
        public Label() 
            : this(new DateProvider(), 
                   new WindowsIdentityProvider(),
                   new EntityFrameworkStorageProvider())
        {
            Active = true;
        }

        public Label(IDateProvider dateProvider,
                     IIdentityProvider identitiyProvider,
                     IStorageProvider storageProvider)
        {
            DateProvider     = dateProvider;
            IdentityProvider = identitiyProvider;
            StorageProvider  = storageProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }

        [Key]
        public int ID { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string Name { get; set; }
        public string ColorCode { get; set; }
        public bool Active { get; set; }

        public Label Add(string labelName, string colorCode)
        {
            var userName = IdentityProvider.GetUserName();
            var currentDate = DateProvider.Now();

            var label = new Label()
            {
                Name         = labelName,
                ColorCode    = colorCode,
                CreatedUser  = userName,
                CreatedDate  = currentDate,
                ModifiedUser = userName,
                ModifiedDate = currentDate
            };

            return StorageProvider.Add(label);
        }

        public List<Label> GetAll()
        {
            return StorageProvider.GetAllLabels();
        }

        public Label Get(int labelID)
        {
            return StorageProvider.GetLabel(labelID);
        }

        public Label Update(Label label)
        {
            if (label != null)
            {
                label.ModifiedDate = DateProvider.Now();
                label.ModifiedUser = IdentityProvider.GetUserName();

                return StorageProvider.Update(label);
            }
            else
            {
                return null;
            }
        }

        public void Remove(int labelID)
        {
            var label = Get(labelID);

            if (label != null)
            {
                label.ModifiedDate = DateProvider.Now();
                label.ModifiedUser = IdentityProvider.GetUserName();

                StorageProvider.RemoveLabel(label);
            }
        }
    }
}
