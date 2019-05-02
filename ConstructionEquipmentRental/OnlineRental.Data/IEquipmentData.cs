using OnlineRental.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRental.Data
{
    public interface IEquipmentData
    {
        IEnumerable<EquipmentModel> GetAll();
        EquipmentModel GetEquipmentByID(int id);

        int CalculatePrice(int id,int rentDays);
    }

    public class InMemoryEquipmentData : IEquipmentData
    {
        public List<EquipmentModel> Equipments;

        public EquipmentModel eq = new EquipmentModel();
        public InMemoryEquipmentData()
        {
            Equipments = new List<EquipmentModel>()
            {
                new EquipmentModel{ Id=1,Name="Caterpillar bulldozer",Category=Category.Heavy},
                new EquipmentModel{ Id=2,Name="KamAZ truck",Category=Category.Regular},
                new EquipmentModel{ Id=3,Name="Komatsu crane",Category=Category.Heavy},
                new EquipmentModel{ Id=4,Name="Volvo steamroller",Category=Category.Regular},
                new EquipmentModel{ Id=5,Name="Bosch jackhammer",Category=Category.Specialized}

            };
        }

        public int CalculatePrice(int id,int rentDays)
        {
            int price = 0;
            var category = from cat in Equipments
                              where cat.Id == id
                              select cat.Category;
            switch (category.ElementAt(0).ToString())
                {
                case "Heavy":
                   price= eq.oneTimeFee + rentDays * eq.premiumFeePerDay;
                    break;
                case "Regular":
                    if (rentDays > 2)
                    {
                        price = eq.oneTimeFee + 2 * eq.premiumFeePerDay+(rentDays-2)*eq.regularFeePerDay;

                    }
                    else
                    {
                        price = eq.oneTimeFee + rentDays * eq.premiumFeePerDay;
                    }
                   
                    break;
                case "Specialized":
                    if (rentDays > 3)
                    {
                        price = 3 * eq.premiumFeePerDay + (rentDays - 3) * eq.regularFeePerDay;

                    }
                    else
                    {
                        price = rentDays * eq.premiumFeePerDay;
                    }
                    break;
            }
            return price;
        }

        public IEnumerable<EquipmentModel> GetAll()
        {
            return from equi in Equipments
                   orderby equi.Category
                   select equi;
        }

        public EquipmentModel GetEquipmentByID(int id)
        {
            return Equipments.SingleOrDefault(equi => equi.Id == id);
        }      
    }
}
