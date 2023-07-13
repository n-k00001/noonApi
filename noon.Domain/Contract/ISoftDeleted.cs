using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Contract
{
    internal interface ISoftDeleted
    {
        public bool isDeleted { get; set; }
    }
}
