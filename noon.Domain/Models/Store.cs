using noon.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class Store : ISoftDeleted
    {
        public int id { get; set; }
        public string Name { get; set; }

        /// Gets or sets the store URL
        public string Url { get; set; }
        public bool isDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
