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
    public class ListModel : PageModel
    {

        public ListModel(IEquipmentData equipmentData)
        {
            this.EquipmentData = equipmentData;
        }

        private IEquipmentData EquipmentData { get; }
        public IEnumerable<EquipmentModel> Equipments { get; set; }

        public void OnGet()
        {
            Equipments = EquipmentData.GetAll();
        }      
    }
}