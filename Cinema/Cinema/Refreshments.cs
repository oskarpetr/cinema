using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Cinema {

    [Serializable]
    public class Refreshments {
        public List<Food> Food = new List<Food>();
        public List<Drink> Drinks = new List<Drink>();
    }

    [Serializable]
    public class Food {
        public PopcornType Name { get; set; }
        public Size Size { get; set; }

    }

    [Serializable]
    public class Drink {
        public DrinkType Name { get; set; }
        public Size Size { get; set; }
    }

    [Serializable]
    public enum DrinkType {
        Coca_Cola, Pepsi, Sprite, Fanta
    }

    [Serializable]
    public enum PopcornType {
        Salted, Sweet, Cheese
    }

    [Serializable]
    public enum Size {
        Small, Medium, Large
    }
}
