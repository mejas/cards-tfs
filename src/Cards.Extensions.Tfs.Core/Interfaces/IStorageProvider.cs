using Cards.Extensions.Tfs.Core.Models;
using System.Collections.Generic;

namespace Cards.Extensions.Tfs.Core.Interfaces
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
