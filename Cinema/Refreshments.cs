using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema {
    public class Refreshments {
        public List<Food> Food;
        public List<Drink> Drinks;
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
        Cola, ColaSugarFree, Pepsi, PepsiSugarFree, Sprite
    }

    public enum PopcornType {
        Salted, Sweet, Cheese
    }

    public enum Size {
        Small, Medium, Large
    }
}
