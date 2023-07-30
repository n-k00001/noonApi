using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class WishList
    {
        public int id { get; set; }
        public Product product { get; set; }
        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
