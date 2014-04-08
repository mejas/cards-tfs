﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Extensions.Tfs.Core
{
    public class Area
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime CreatedDate { get; set;  }
        public DateTime ModifiedDate { get; set; }

    }
}