using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
    public class Ticket {
        public GuestType Guest { get; set; }
        public string Film { get; set; }
        public string Row { get; set; }
        public int Seat { get; set; }
        public List<Food> Food { get; set; }
        public List<Drink> Drinks { get; set; }

        public decimal Price() {
            int price = 0;

            // base prices
            int base_film = 150;
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

            foreach (Food food in Food) {
                price += (int)food.Size * base_food;
            }

            foreach (Drink drink in Drinks) {
                price += (int)drink.Size * base_drink;
            }

            return Math.Round((decimal)price);
        }  
    }

    public enum GuestType {
        Child, Student, Adult, Senior
    }
}
