using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Core.Interfaces
{
    public interface IConfigurationProvider
    {
        Uri TFSProjectConnection { get; }
        string TFSProjectName { get; }
        int PendingWorkArea { get; }
        int CompletedWorkArea { get; }
    }
}
