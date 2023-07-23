using noon.Domain.Contract;
using noon.Domain.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace noon.Domain.Models
{
    public class UserReview : ISoftDeleted
    {
        public int id { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool isDeleted { get; set; }

        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}