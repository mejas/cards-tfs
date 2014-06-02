using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Core.Contracts
{
    public class ImportRequest
    {
        public int WorkItem { get; set; }
        public int AreaID { get; set; }
    }
}
