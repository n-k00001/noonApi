﻿using noon.Domain.Models.Identity;
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
        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        [ForeignKey("Address")]
        public int ? ShipToAddressId { set; get; }
        public Address? Address { get; set; }
        [ForeignKey("DeliveryMethod")]
        public int DeliveryMethodId { set; get; }
        public DeliveryMethod? DeliveryMethod { get; set; }
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
        public ShippingStatus? ShippingStatus
        {
            get => (ShippingStatus)ShippingStatusId;
            set => ShippingStatusId = (int)value;
        }
        public virtual IQueryable<OrderItem> Items { get; set; }
        public decimal? Subtotal { set; get; }
        public decimal? OrderDiscount { get; set; }
        public decimal? GetTotal()
            => (Subtotal + DeliveryMethod.Cost);

        [ForeignKey("paymentMethod")]
        public int? paymentIntentId { set; get; }
        public UserPaymentMethod? paymentMethod { get; set; }

    }
}
