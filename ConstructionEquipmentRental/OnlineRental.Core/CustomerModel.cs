using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRental.Core
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string ContactNumber { get; set; }
        public string ShippingAddress { get; set; }
    }
}
