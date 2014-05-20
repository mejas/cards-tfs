using System;
using System.Collections.Generic;

namespace Cards.Extensions.Tfs.Tests
{
    public class Area
    {

        public Area()
            :this(new DateProvider())
        {

        }

        public Area(IDateProvider dateProvider)
        {
            DateProvider = dateProvider;
        }

        protected static List<Area> Storage;
        public static void Reset()
        {
            Storage = new List<Area>();
        }

        protected IDateProvider DateProvider { get; set; }


        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Area Add(string areaName)
        {
            var area = new Area()
            {
                Name = areaName,
                ID = 1,
                CreatedDate = DateProvider.Now(),
                ModifiedDate = DateProvider.Now()
            };

            //add storage fugg
            Storage.Add(area);

            return area;
        }

        public List<Area> GetAll()
        {
            return Storage;
        }

        public Area Get(int id)
        {
            return Storage.Find(item => item.ID == id);
        }

        public Area Update(Area area)
        {
            if (this.Get(area.ID) == null)
            {
                return null;
            }
            else
            {
                area.ModifiedDate = DateProvider.Now();
                return area;
            }
        }
    }
}
