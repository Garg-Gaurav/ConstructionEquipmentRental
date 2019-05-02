using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineRental.Core;
using OnlineRental.Data;

namespace OnlineRental.Pages.ConstructionEquipment
{
    public class ShoppingCartModel : PageModel
    {
        public ShoppingCartModel(IEquipmentData equipmentData,ICustomerData customerData)
        {
            this.EquipmentData = equipmentData;
            this.CustomerData = customerData;
        }

        private IEquipmentData EquipmentData { get; }
        public ICustomerData CustomerData { get; }

        [BindProperty]
        public EquipmentModel Equipment { get; set; }

        [BindProperty]
        public CustomerModel Customer { get; set; }


        public void OnGet(int equipmentId)
        {
            Equipment = EquipmentData.GetEquipmentByID(equipmentId);
            Customer = CustomerData.GetCustomer();
        }

        public void OnPost()
        {
            int price = 0;
            if (Equipment.RentDays > 0)
            {
               price= EquipmentData.CalculatePrice(Equipment.Id,Equipment.RentDays);
            }
            else
            {
                TempData["Message"] = "Enter Valid Days";
            }
            
            
       
        }
    }
}