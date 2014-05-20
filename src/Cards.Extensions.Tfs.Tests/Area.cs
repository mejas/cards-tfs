using System;
using System.Collections.Generic;

namespace Cards.Extensions.Tfs.Tests
{
    public class Area
    {

        public Area()
            : this(new DateProvider(), new StorageProvider())
        { }

        public Area(IDateProvider dateProvider, IStorageProvider storageProvider)
        {
            DateProvider = dateProvider;
            StorageProvider = storageProvider;
        }

        protected IDateProvider DateProvider { get; set; }
        protected IStorageProvider StorageProvider { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Area Add(string areaName)
        {
            var area = new Area()
            {
                Name = areaName,
                CreatedDate = DateProvider.Now(),
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
                area.ModifiedDate = DateProvider.Now();
                return StorageProvider.Update(area);
            }
            else
            {
                return null;
            }
        }
    }
}
