using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Extensions.Tfs.Core.Interfaces;
using Cards.Extensions.Tfs.Core.Services;

namespace Cards.Extensions.Tfs.Core.Models
{
    public sealed class CardActivityType
    {
        #region Constants
        private const string ADDCARD    = "ADD_CARD";
        private const string MOVECARD   = "MOVE_CARD";
        private const string MODIFYCARD = "MODIFY_CARD";
        private const string DELETECARD = "DELETE_CARD";
        #endregion

        #region Enumerable Types
        public static readonly CardActivityType Add    = new CardActivityType(ADDCARD);
        public static readonly CardActivityType Move   = new CardActivityType(MOVECARD);
        public static readonly CardActivityType Modify = new CardActivityType(MODIFYCARD);
        public static readonly CardActivityType Delete = new CardActivityType(DELETECARD);
        #endregion

        private readonly string _enumName;

        private CardActivityType(string name)
        {
            this._enumName = name;
        }

        public override string ToString()
        {
            return _enumName;
        }

        public static CardActivityType GetActivityType(string activityString)
        {
            switch(activityString)
            {
                case ADDCARD:
                    return CardActivityType.Add;
                case MOVECARD:
                    return CardActivityType.Move;
                case MODIFYCARD:
                    return CardActivityType.Modify;
                case DELETECARD:
                    return CardActivityType.Delete;
                default:
                    throw new InvalidCastException(String.Format("No type {0} exists for {1}", activityString, typeof(CardActivityType).Name));
            }
        }
    }

    public class CardActivity
    {
        public CardActivity()
            : this(new EntityFrameworkStorageProvider(), new WindowsIdentityProvider())
        { }

        public CardActivity(IStorageProvider storageProvider, IIdentityProvider identityProvider)
        {
            StorageProvider = storageProvider;
            IdentityProvider = identityProvider;
        }

        [Key]
        public int ID { get; set; }

        public int CardID { get; set; }
        public DateTime LoggedDate { get; set; }
        public string LoggedUser { get; set; }
        public string ActivityType { get; set; }

        protected IStorageProvider StorageProvider { get; set; }
        protected IIdentityProvider IdentityProvider { get; set; }

        public CardActivity Add(int cardID, CardActivityType cardActivityType, DateTime dateTime)
        {
            CardActivity cardActivity = new CardActivity()
            {
                CardID       = cardID,
                ActivityType = cardActivityType.ToString(),
                LoggedUser   = IdentityProvider.GetUserName(),
                LoggedDate   = dateTime
            };

            return StorageProvider.Add(cardActivity);
        }

        public CardActivity Get(int cardActivityID)
        {
            return StorageProvider.GetCardActivity(cardActivityID);
        }

        public List<CardActivity> GetAll(int cardID)
        {
            return StorageProvider.GetAllCardActivities(cardID);
        }
    }
}
