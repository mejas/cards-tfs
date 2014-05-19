using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Tests
{
    public class Area
    {

        protected static List<Area> Storage;
        public static void Reset()
        {
            Storage = new List<Area>();
        }

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
                CreatedDate = new DateTime(2014, 5, 19),
                ModifiedDate = new DateTime(2014, 5, 19)
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
    }
}
