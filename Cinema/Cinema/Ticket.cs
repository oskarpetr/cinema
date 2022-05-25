using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Cinema {

    [Serializable]
    public class Ticket {
        public DateTime Date { get; set; }
        public GuestType Guest { get; set; }
        public string Film { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public Refreshments Refreshments { get; set; }

        public decimal GetPrice() {
            int price = 0;

            // base prices
            int base_film = 200;
            int base_food = 40;
            int base_drink = 30;

            switch(Guest) {
                case GuestType.Child:
                    price += base_film / 3;
                    break;

                case GuestType.Student:
                case GuestType.Senior:
                    price += base_film / 2;
                    break;

                case GuestType.Adult:
                    price += base_film;
                    break;
            }

            foreach (Food food in Refreshments.Food) {
                price += ((int)food.Size + 1) * base_food;
            }

            foreach (Drink drink in Refreshments.Drinks) {
                price += ((int)drink.Size + 1) * base_drink;
            }

            return Math.Round((decimal)price);
        }  
    }

    public enum GuestType {
        Child, Student, Adult, Senior
    }
}