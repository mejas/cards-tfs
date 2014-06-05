using System;
using System.Collections.Generic;
using System.Configuration;
using Cards.Extensions.Tfs.Core.Interfaces;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class TFSImportProvider : ITFSProvider
    {
        public Contracts.WorkItem GetTFSItem(int tfsID)
        {
            Uri uri = new Uri(ConfigurationManager.ConnectionStrings["TFSConnectionString"].ConnectionString);

            TfsTeamProjectCollection server = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            var workItemStore = server.GetService(typeof(WorkItemStore)) as WorkItemStore;

            if (workItemStore != null)
            {
                var workItem = workItemStore.GetWorkItem(tfsID);

                return createCardsWorkItem(workItem);
            }

            return null;
        }

        public List<Contracts.WorkItem> GetTFSItems(string tfsQuery)
        {
            Uri uri = new Uri(ConfigurationManager.ConnectionStrings["TFSConnectionString"].ConnectionString);

            TfsTeamProjectCollection server = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            var workItemStore = server.GetService(typeof(WorkItemStore)) as WorkItemStore;

            if (workItemStore != null)
            {
                List<Contracts.WorkItem> cardsWorkItems = new List<Contracts.WorkItem>();

                var workItems = workItemStore.Query(tfsQuery);

                foreach (WorkItem workItem in workItems)
                {
                    cardsWorkItems.Add(createCardsWorkItem(workItem));
                }

                return cardsWorkItems;
            }
            else
            {
                return null;
            }
        }

        private Contracts.WorkItem createCardsWorkItem(WorkItem workItem)
        {
            return new Contracts.WorkItem()
            {
                ID          = workItem.Id,
                Title       = workItem.Title,
                Description = workItem.Description,
                AssignedTo  = workItem.Fields[CoreField.AssignedTo].Value.ToString()
            };
        }
    }
}
