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
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Server;

namespace Cards.Extensions.Tfs.Core.Services
{
    public class TFSProvider : ITFSProvider
    {
        TfsTeamProjectCollection _projectCollection = null;
        Project _project = null;

        public TfsTeamProjectCollection ProjectCollection
        {
            get
            {
                if (_projectCollection == null)
                {
                    _projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(ConfigurationManager.AppSettings["TFSProjectCollection"]));
                }

                return _projectCollection;
            }
        }

        public Project Project
        {
            get
            {
                if (_project == null)
                {
                    var workItemStore = ProjectCollection.GetService(typeof(WorkItemStore)) as WorkItemStore;

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

        public List<Models.WorkItem> GetTFSItems(string queryName)
        {
            if (Project != null)
            {
                StoredQuery query = getStoredQuery(Project, queryName);

                Dictionary<string, string> parameters = new Dictionary<string, string>()
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
                ID = workItem.Id,
                Title = workItem.Title,
                Description = workItem.Description,
                AssignedTo = workItem.Fields[CoreField.AssignedTo].Value.ToString()
            };
        }

        public string GetTFSDisplayName(string identity)
        {
            var identityService = ProjectCollection.GetService<IGroupSecurityService>();

            var tfsIdentity = identityService.ReadIdentity(SearchFactor.AccountName, identity, QueryMembership.None);

            return tfsIdentity.DisplayName;
        }
    }
}
