using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using Cards.Extensions.Tfs.Core.Interfaces;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Web;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class TFSProvider : ITFSProvider
    {
        Project _project = null;
        private const string AND_CLAUSE = " AND ";

        public Project Project
        {
            get
            {
                if (_project == null)
                {
                    var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(ConfigurationManager.ConnectionStrings["TFSConnectionString"].ConnectionString));

                    var workItemStore = tfs.GetService(typeof(WorkItemStore)) as WorkItemStore;

                    _project = workItemStore.Projects[ConfigurationManager.AppSettings["TFSProject"]];
                }

                return _project;
            }
        }

        public Models.WorkItem GetTFSItem(int tfsID)
        {
            if (Project != null)
            {
                var workItem = Project.Store.GetWorkItem(tfsID);

                return createCardsWorkItem(workItem);
            }

            return null;
        }

        public List<Models.WorkItem> GetTFSItems(IEnumerable<KeyValuePair<string, string>> tfsQueryArgs)
        {
            if (Project != null)
            {
                string wiql = buildWiqlString(tfsQueryArgs);

                var items = Project.Store.Query(wiql);

                List<Models.WorkItem> workItems = new List<Models.WorkItem>();
                foreach(WorkItem item in items)
                {
                    workItems.Add(createCardsWorkItem(item));
                }

                return workItems;
            }

            return null;
        }

        public List<Models.WorkItem> GetTFSItems(string queryName)
        {
            if (Project != null)
            {
                StoredQuery query = getStoredQuery(Project, queryName);

                Dictionary<string, string> parameters = new Dictionary<string,string>()
                {
                    { "project", Project.Name }
                };

                if (query != null)
                {
                    var results = Project.Store.Query(query.QueryText, parameters);

                    List<Models.WorkItem> workItems = new List<Models.WorkItem>();
                    foreach (WorkItem result in results)
                    {
                        workItems.Add(createCardsWorkItem(result));
                    }

                    return workItems;

                }
            }

            return null;
        }

        private StoredQuery getStoredQuery(Project project, string queryName)
        {
            foreach (StoredQuery query in project.StoredQueries)
            {
                if (String.Compare(query.Name, queryName, true, CultureInfo.InvariantCulture) == 0)
                {
                    return query;
                }
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

            query.AppendFormat(" [{0}] = '{1}' ", tfsQueryArg.Key, tfsQueryArg.Value);

            return query.ToString();
        }
    }
}
