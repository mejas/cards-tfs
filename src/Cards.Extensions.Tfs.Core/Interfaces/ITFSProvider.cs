using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Extensions.Tfs.Core.Contracts;

namespace Cards.Extensions.Tfs.Core.Interfaces
{
    public interface ITFSProvider
    {
        WorkItem GetTFSItem(int tfsID);
        List<WorkItem> GetTFSItems(string tfsQuery);
    }
}
