using noon.Domain.Models.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace noon.Domain.Models.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string fullAddress { get; set; }
        public string phoneNumber { get; set; }
        public enum addressLabel
        {
            work,
            home
        }
        public List<UserAddress>? UserAddresses { get; set; }
        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}