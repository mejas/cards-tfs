using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Cards.Extensions.Tfs.Core.Interfaces;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        const string CARDS_COMPLETED_AREA = "CardsCompletedArea";
        const string CARDS_PENDING_AREA = "CardsPendingArea";

        public Uri TFSProjectConnection
        {
            get { throw new NotImplementedException(); }
        }

        public string TFSProjectName
        {
            get { throw new NotImplementedException(); }
        }

        public int PendingWorkArea
        {
            get 
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings[CARDS_PENDING_AREA]);
            }
        }

        public int CompletedWorkArea
        {
            get 
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings[CARDS_COMPLETED_AREA]);
            }
        }
    }
}
