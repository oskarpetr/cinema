using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
    public class Refreshments {
        public List<Food> Food;
        public List<Drink> Drinks;

        public Refreshments() {
            Food = new List<Food>();
            Drinks = new List<Drink>();
        }
    }

    public class Food {
        public PopcornType Name { get; set; }
        public Size Size { get; set; }

    }

    public class Drink {
        public DrinkType Name { get; set; }
        public Size Size { get; set; }
    }

    public enum DrinkType {
        Coca_Cola, Pepsi, Sprite, Fanta
    }

    public enum PopcornType {
        Salted, Sweet, Cheese
    }

    public enum Size {
        Small, Medium, Large
    }
}
