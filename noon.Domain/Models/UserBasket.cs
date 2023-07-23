using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class UserBasket
    {
        public int Id { get; set; }
        public virtual List<BasketItem> Items { get; set; }

        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
