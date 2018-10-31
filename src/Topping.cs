using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class Topping {
        String name = "";
        double price = -1.0;

        public double Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }

        public Object toString() {
            Object[] attributes = { Utility.quote(Name), Price };
            return String.Join(",", attributes);
        }
    }
    
}
