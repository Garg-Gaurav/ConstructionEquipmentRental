using OnlineRental.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRental.Data
{
   public interface ICustomerData
    {
        CustomerModel GetCustomer();
    }

    public class InMemoryCustomerData : ICustomerData
    {
        public CustomerModel Customer;
        public InMemoryCustomerData()
        {

            Customer = new CustomerModel { ID = 1, Name = "Gaurav Garg", ShippingAddress = "India", ContactNumber = "+91 7696541243" };
                
        }
        public CustomerModel GetCustomer()
        {
            return Customer;
        }
    }
}
