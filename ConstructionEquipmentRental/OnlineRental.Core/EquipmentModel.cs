using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRental.Core
{
    public enum Category
    {
        Regular,
        Heavy,
        Specialized
    }
    public class EquipmentModel
    {
        public  int oneTimeFee = 100;
        public int premiumFeePerDay = 60;
        public  int regularFeePerDay = 40;

        public int RentDays { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }
    }
}
