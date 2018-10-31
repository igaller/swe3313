using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class Pizza {
        int pizzaID;
        String size = null;
        Topping topping1 = new Topping();
        Topping topping2 = new Topping();
        Topping topping3 = new Topping();
        Topping topping4 = new Topping();

        public string Size { get => size; set => size = value; }
        public int PizzaID { get => pizzaID; set => pizzaID = value; }
        public Topping Topping1 { get => topping1; set => topping1 = value; }
        public Topping Topping2 { get => topping2; set => topping2 = value; }
        public Topping Topping3 { get => topping3; set => topping3 = value; }
        public Topping Topping4 { get => topping4; set => topping4 = value; }


    }
}
