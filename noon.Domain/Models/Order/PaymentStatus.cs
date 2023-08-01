using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Order
{
    public enum PaymentStatus
    {
        /// Pending
        //Pending = 10,

        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Authorized")]
        Authorized,
        [EnumMember(Value = "Paid")]
        Paid,
        [EnumMember(Value = "Partially Refunded")]
        PartiallyRefunded,
        [EnumMember(Value = "Refunded")]
        Refunded,
        [EnumMember(Value = "Voided")]
        Voided
        /// Authorized
        //Authorized = 20,


        /// Paid
        //Paid = 30,


        /// Partially Refunded
        //PartiallyRefunded = 35,


        /// Refunded
        //Refunded = 40,


        /// Voided
        //Voided = 50


    }
}
