﻿using System.Collections.Generic;
using System.Linq;
using Cards.Extensions.Tfs.Core.Data;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class EntityFrameworkStorageProvider : IStorageProvider
    {
        #region Areas
        public List<Area> GetAllAreas()
        {
            using (var db = new CardsDBContext())
            {
                var areas = db.Areas.Where(area=>area.Active).ToList();

                areas.ForEach(area => area.Cards = db.Cards.Where(card => card.AreaID == area.ID && card.Active).ToList());

                return areas;
            }
        }

        public Area GetArea(int id)
        {
            using (var db = new CardsDBContext())
            {
                var resultArea = db.Areas.FirstOrDefault(area => area.ID == id && area.Active);

                resultArea.Cards = db.Cards.Where(card => card.AreaID == resultArea.ID && card.Active).ToList();

                return resultArea;
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

        public void RemoveArea(Area area)
        {
            using (var db = new CardsDBContext())
            {
                var itemToDelete = db.Areas.FirstOrDefault(item => item.ID == area.ID);
                
                itemToDelete.ModifiedDate = area.ModifiedDate;
                itemToDelete.ModifiedUser = area.ModifiedUser;
                itemToDelete.Active       = false;

                db.SaveChanges();
            }
        }
        #endregion

        #region Cards
        public Card Add(Card card)
        {
            using (var db = new CardsDBContext())
            {
                if (card.TfsID != 0 && db.Cards.FirstOrDefault(item => item.TfsID == card.TfsID) != null)
                {
                    return null;
                }

                var result = db.Cards.Add(card);
                db.SaveChanges();

                return result;
            }
        }

        public List<Card> GetAllCards(int areaID)
        {
            using (var db = new CardsDBContext())
            {
                return db.Cards.Include("CardActivities").Where(card => card.AreaID == areaID && card.Active == true).ToList();
            }
        }

        public Card GetCard(int id)
        {
            using (var db = new CardsDBContext())
            {
                return db.Cards.FirstOrDefault(card => card.ID == id && card.Active == true);
            }
        }

        public Card Update(Card card)
        {
            using (var db = new CardsDBContext())
            {
                var cardToUpdate = db.Cards.FirstOrDefault(item => item.ID == card.ID);

                if (cardToUpdate != null)
                {
                    cardToUpdate.Name         = card.Name;
                    cardToUpdate.Description  = card.Description;
                    cardToUpdate.TfsID        = card.TfsID;
                    cardToUpdate.AreaID       = card.AreaID;
                    cardToUpdate.ModifiedDate = card.ModifiedDate;
                    cardToUpdate.ModifiedUser = card.ModifiedUser;
                    cardToUpdate.AssignedTo   = card.AssignedTo;

                    db.SaveChanges();

                    return cardToUpdate;
                }
                else
                {
                    return null;
                }
            }
        }

        public void RemoveCard(Card card)
        {
            using (var db = new CardsDBContext())
            {
                var cardToUpdate = db.Cards.FirstOrDefault(item => item.ID == card.ID);

                if (cardToUpdate != null)
                {
                    cardToUpdate.ModifiedDate = card.ModifiedDate;
                    cardToUpdate.ModifiedUser = card.ModifiedUser;
                    cardToUpdate.Active = false;

                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region CardActivities
        public CardActivity Add(CardActivity cardActivity)
        {
            using (var db = new CardsDBContext())
            {
                var result = db.CardActivities.Add(cardActivity);
                db.SaveChanges();

                return result;
            }
        }

        public CardActivity GetCardActivity(int cardActivityID)
        {
            using (var db = new CardsDBContext())
            {
                return db.CardActivities.Where(item => item.ID == cardActivityID).FirstOrDefault();
            }
        }

        public List<CardActivity> GetAllCardActivities(int cardID)
        {
            using (var db = new CardsDBContext())
            {
                return db.CardActivities.Where(item => item.CardID == cardID).ToList();
            }
        }
        #endregion

        #region Labels
        public Label Add(Label label)
        {
            using (var db = new CardsDBContext())
            {
                var existingItem = db.Labels.FirstOrDefault(item => item.Name == label.Name);

                if (existingItem == null)
                {
                    var result = db.Labels.Add(label);
                    db.SaveChanges();

                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Label> GetAllLabels()
        {
            using (var db = new CardsDBContext())
            {
                return db.Labels.Where(label => label.Active == true).ToList();
            }
        }

        public Label Update(Label label)
        {
            using (var db = new CardsDBContext())
            {
                var labelToUpdate = db.Labels.FirstOrDefault(item => item.ID == label.ID);
                var existingLabel = db.Labels.FirstOrDefault(item => item.Name == label.Name);

                if (labelToUpdate != null && existingLabel != null)
                {
                    labelToUpdate.Name = label.Name;
                    labelToUpdate.ColorCode = label.ColorCode;
                    labelToUpdate.ModifiedDate = label.ModifiedDate;
                    labelToUpdate.ModifiedUser = label.ModifiedUser;

                    db.SaveChanges();

                    return labelToUpdate;
                }
                else
                {
                    return null;
                }
            }
        }

        public Label GetLabel(int labelID)
        {
            using (var db = new CardsDBContext())
            {
                return db.Labels.FirstOrDefault(item => item.ID == labelID && item.Active == true);
            }
        }

        public void RemoveLabel(Label label)
        {
            using (var db = new CardsDBContext())
            {
                var labelToRemove = db.Labels.FirstOrDefault(item => item.ID == label.ID);

                if (labelToRemove != null)
                {
                    labelToRemove.ModifiedDate = label.ModifiedDate;
                    labelToRemove.ModifiedUser = label.ModifiedUser;
                    labelToRemove.Active       = false;

                    db.SaveChanges();
                }
            }
        }
        #endregion
    }
}
