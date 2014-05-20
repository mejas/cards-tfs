using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cards.Extensions.Tfs.Core
{
    public class Area
    {

        public Area()
            : this(new DateProvider(), new StorageProvider(), new IdentityProvider())
        { }

        public Area(IDateProvider dateProvider, IStorageProvider storageProvider, IIdentityProvider identityProvider)
        {
            DateProvider = dateProvider;
            StorageProvider = storageProvider;
            IdentityProvider = identityProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public Area Add(string areaName)
        {
            var area = new Area()
            {
                Name         = areaName,
                CreatedUser  = IdentityProvider.UserName(),
                ModifiedUser = IdentityProvider.UserName(),
                CreatedDate  = DateProvider.Now(),
                ModifiedDate = DateProvider.Now()
            };

            //add storage fugg
            return StorageProvider.Add(area);
        }

        public List<Area> GetAll()
        {
            return StorageProvider.GetAllAreas();
        }

        public Area Get(int id)
        {
            return StorageProvider.GetArea(id);
        }

        public Area Update(Area area)
        {
            if (area != null && this.Get(area.ID) != null)
            {
                area.ModifiedUser = IdentityProvider.UserName();
                area.ModifiedDate = DateProvider.Now();
                return StorageProvider.Update(area);
            }
            else
            {
                return null;
            }
        }

        public void Remove(int id)
        {
            StorageProvider.RemoveArea(id);
        }
    }
}
