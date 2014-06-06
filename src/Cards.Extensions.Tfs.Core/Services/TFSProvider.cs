using System;
using System.Collections.Generic;
using System.Configuration;
using Cards.Extensions.Tfs.Core.Interfaces;
using Microsoft.TeamFoundation.Client;
using System.Linq;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Text;
using Cards.Extensions.Tfs.Core.Constants;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class TFSProvider : ITFSProvider
    {
        WorkItemStore _workItemStore = null;
        private const string AND_CLAUSE = " AND ";

        public WorkItemStore WorkItemStore
        {
            get
            {
                if (_workItemStore == null)
                {
                    var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(ConfigurationManager.ConnectionStrings["TFSConnectionString"].ConnectionString));

                    _workItemStore = tfs.GetService(typeof(WorkItemStore)) as WorkItemStore;
                }

                return _workItemStore;
            }
        }

        public Models.WorkItem GetTFSItem(int tfsID)
        {
            if (WorkItemStore != null)
            {
                var workItem = WorkItemStore.GetWorkItem(tfsID);

                return createCardsWorkItem(workItem);
            }

            return null;
        }

        public List<Models.WorkItem> GetTFSItems(IEnumerable<KeyValuePair<string, string>> tfsQueryArgs)
        {
            if (WorkItemStore != null)
            {
                string wiql = buildWiqlString(tfsQueryArgs);

                var items = WorkItemStore.Query(wiql);

                List<Models.WorkItem> workItems = new List<Models.WorkItem>();
                foreach(WorkItem item in items)
                {
                    workItems.Add(createCardsWorkItem(item));
                }

                return workItems;

            }

            return null;
        }

        private Models.WorkItem createCardsWorkItem(WorkItem workItem)
        {
            return new Models.WorkItem()
            {
                ID          = workItem.Id,
                Title       = workItem.Title,
                Description = workItem.Description,
                AssignedTo  = workItem.Fields[CoreField.AssignedTo].Value.ToString()
            };
        }

        private string buildWiqlString(IEnumerable<KeyValuePair<string, string>> tfsQueryArgs)
        {
            StringBuilder query = new StringBuilder();

            query.Append(@"select [Id], [Title], [Description], [Assigned To] from WorkItems");

            if (tfsQueryArgs.Count() > 0)
            {
                query.Append(" where");

                foreach (var tfsQueryArg in tfsQueryArgs)
                {
                    query.Append(buildWhereParam(tfsQueryArg));
                    query.Append(AND_CLAUSE);
                }

                query.Remove(query.Length - AND_CLAUSE.Length, AND_CLAUSE.Length); //remove last AND
            }

            return query.ToString().Trim();
        }

        private string buildWhereParam(KeyValuePair<string, string> tfsQueryArg)
        {
            StringBuilder query = new StringBuilder();

            switch (tfsQueryArg.Key)
            {
                case TFSArguments.WorkItemID:
                    query.Append(" [Id] = ");
                    break;
                case TFSArguments.AssignedTo:
                    query.Append(" [Assigned to] = ");
                    break;
                case TFSArguments.AreaPath:
                    query.Append(" [Area Path] = ");
                    break;
                case TFSArguments.WorkItemType:
                    query.Append(" [Work Item Type] = ");
                    break;
                case TFSArguments.IterationPath:
                    query.Append(" [Iteration Path] = ");
                    break;
                case TFSArguments.State:
                    query.Append(" [State] = ");
                    break;
                case TFSArguments.Project:
                    query.Append(" [Project] = ");
                    break;
            }

            query.AppendFormat(" '{0}' ", tfsQueryArg.Value);

            return query.ToString();
        }
    }
}
