using System.Collections.Generic;
using Cards.Extensions.Tfs.Core.Models;

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

        #region Card Activity Operations
        List<CardActivity> GetAllCardActivities(int cardID);
        CardActivity Add(CardActivity cardActivity);
        CardActivity GetCardActivity(int cardActivityID);
        #endregion

        #region Label Operations
        List<Label> GetAllLabels();
        Label GetLabel(string labelName);
        Label Add(Label label);
        Label Update(Label label);
        #endregion
    }
}
