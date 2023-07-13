using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models.Order
{
    public class OrderAddress
    {
        public OrderAddress()
        {

        }
        public OrderAddress(string firstName, string lastName, string country, string city, string street, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public int id { get; set; }
        public string fullAddress { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string phoneNumber { set; get; }
        public bool isDefualt { set; get; }
    }
}
