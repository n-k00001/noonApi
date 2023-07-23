using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Order
{
    public class Order
    {

        [Key]
        public Guid OrderId { get; set; }

        public string? BuyerEmail { set; get; }
        
        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
<<<<<<< HEAD
        [ForeignKey("Address")]
        public int ? ShipToAddressId { set; get; }
        public Address? Address { get; set; }
        [ForeignKey("DeliveryMethod")]
        public int DeliveryMethodId { set; get; }
        public DeliveryMethod? DeliveryMethod { get; set; }
=======
        public virtual Address?  ShipToAddress { get; set; }
        public virtual DeliveryMethod? DeliveryMethod { get; set; }
>>>>>>> abdelrahman
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        /// Gets or sets the payment status identifier
        public int PaymentStatusId { get; set; }

        /// Gets or sets the payment status
        public PaymentStatus? PaymentStatus
        {
            get => (PaymentStatus)PaymentStatusId;
            set => PaymentStatusId = (int)value;
        }

        /// Gets or sets the shipping status identifier
        public int ShippingStatusId { get; set; }

        /// Gets or sets the shipping status
        public virtual ShippingStatus? ShippingStatus
        {
            get => (ShippingStatus)ShippingStatusId;
            set => ShippingStatusId = (int)value;
        }
        public virtual IReadOnlyList<OrderItem> Items { get; set; }
        public decimal? Subtotal { set; get; }
        public decimal? OrderDiscount { get; set; }
        public decimal? GetTotal()
            => (Subtotal + DeliveryMethod.Cost);

        [ForeignKey("paymentMethod")]
<<<<<<< HEAD
        public int? PaymentIntentId { set; get; }
        public UserPaymentMethod? paymentMethod { get; set; }
=======
        public int paymentMethodId { set; get; }
        public virtual UserPaymentMethod paymentMethod { get; set; }
>>>>>>> abdelrahman

    }
}
