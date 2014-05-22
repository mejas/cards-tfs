using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Core
{
    public class EntityFrameworkStorageProvider : IStorageProvider
    {
        #region Areas
        public List<Area> GetAllAreas()
        {
            using (var db = new CardsDBContext())
            {
                return db.Areas.Where(item => item.Active).ToList();
            }
        }

        public List<Area> GetAllActiveAreas()
        {
            using (var db = new CardsDBContext())
            {
                return db.Areas.Where(item => item.Active == true).ToList();
            }
        }

        public Area GetArea(int id)
        {
            using (var db = new CardsDBContext())
            {
                return db.Areas.FirstOrDefault(area => area.ID == id && area.Active);
            }
        }

        public Area Add(Area area)
        {
            using (var db = new CardsDBContext())
            {
                var result = db.Areas.Add(area);
                db.SaveChanges();

                return result;
            }
        }

        public Area Update(Area area)
        {
            using (var db = new CardsDBContext())
            {
                var areaToUpdate = db.Areas.FirstOrDefault(item => item.ID == area.ID);

                if (areaToUpdate != null)
                {
                    areaToUpdate.Name         = area.Name;
                    areaToUpdate.ModifiedDate = area.ModifiedDate;
                    areaToUpdate.ModifiedUser = area.ModifiedUser;

                    db.SaveChanges();

                    return areaToUpdate;
                }
                else
                {
                    return null;
                }
            }
        }

        public void RemoveArea(int id)
        {
            using (var db = new CardsDBContext())
            {
                var itemToDelete = db.Areas.FirstOrDefault(area => area.ID == id);

                itemToDelete.Active = false;

                db.SaveChanges();
            }
        }
        #endregion

        public Card Add(Card card)
        {
            throw new NotImplementedException();
        }

        public List<Card> GetAllCards(int areaID)
        {
            throw new NotImplementedException();
        }

        public Card GetCard(int id)
        {
            throw new NotImplementedException();
        }
    }
}
