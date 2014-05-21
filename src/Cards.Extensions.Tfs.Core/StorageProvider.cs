using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Core
{
    public class StorageProvider : IStorageProvider
    {
        public List<Area> GetAllAreas()
        {
            using (var db = new CardsDBContext())
            {
                return db.Areas.ToList();
            }
        }

        public Area GetArea(int id)
        {
            throw new NotImplementedException();
        }

        public Area Add(Area area)
        {
            using (var db = new CardsDBContext())
            {
                return db.Areas.Add(area);
            }
        }

        public Area Update(Area area)
        {
            using (var db = new CardsDBContext())
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();

                return area;
            }
        }

        public void RemoveArea(int id)
        {
            throw new NotImplementedException();
        }
    }
}
