using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class Size {
        String name = "";
        double price = -1.0;

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public String toString() {
            Object[] attributes = new Object[2];
            attributes[0] = Utility.quote(Name);
            attributes[1] = Price;
            String str = String.Join(",", attributes);
            return str;
        }
    }
}
