using System.Collections.Generic;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Core.Interfaces
{
    public interface ITFSProvider
    {
        string GetTFSDisplayName(string identity);
        WorkItem GetTFSItem(int tfsID);
        List<WorkItem> GetTFSItems(string queryName);
    }
}
