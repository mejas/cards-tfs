using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Extensions.Tfs.Core.Models;

namespace Cards.Extensions.Tfs.Core.Interfaces
{
    public interface ITFSProvider
    {
        WorkItem GetTFSItem(int tfsID);
        List<WorkItem> GetTFSItems(IEnumerable<KeyValuePair<string, string>> tfsQueryArgs);
    }
}
