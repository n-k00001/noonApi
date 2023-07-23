using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImgURL { get; set; }
        [ForeignKey("product")]
        public Guid productId { set; get; }
        public virtual Product product { get; set; }
    }
}
