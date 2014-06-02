using System;
using Cards.Extensions.Tfs.Core.Interfaces;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class TFSImportProvider : ITFSProvider
    {
        public Contracts.WorkItem GetTFSItem(int tfsID)
        {
            Uri uri = new Uri("");

            TfsTeamProjectCollection server = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);

            var workItemStore = server.GetService(typeof(WorkItemStore)) as WorkItemStore;

            if (workItemStore != null)
            {
                var workItem = workItemStore.GetWorkItem(tfsID);

                return new Contracts.WorkItem()
                {
                    ID          = workItem.Id,
                    Title       = workItem.Title,
                    Description = workItem.Description,
                    AssignedTo  = workItem.Fields[CoreField.AssignedTo].Value.ToString()
                };

            }

            return null;

        }
    }
}
