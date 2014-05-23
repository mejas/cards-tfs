using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.Extensions.Tfs.Core
{
    public interface IStorageProvider
    {
        #region Area Operations
        List<Area> GetAllAreas();
        Area GetArea(int id);

        Area Add(Area area);
        Area Update(Area area);

        void RemoveArea(Area area);
        #endregion

        #region Card Operations
        List<Card> GetAllCards(int areaID);
        Card GetCard(int id);

        Card Add(Card card);
        Card Update(Card card);
        
        void RemoveCard(Card card);
        #endregion
    }
}
